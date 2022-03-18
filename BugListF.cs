using BugSearch.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSBugTracker;
using VSBugTracker.ADO;
using VSBugTracker.Models;

namespace BugSearch
{
    public partial class BugListF : Form
    {
        DelegateProcess _dlgProcess;
        BugTrackerProcess _bugProcess;
        int _sprintID, _taskID;
        Dictionary<int, string> _m_account, _m_status, _m_priority;
        CheckBox _chkall_bugs;
        Dictionary<string, Bitmap> _bugPriorityFormats;
        // Dictionary<string, BugStatusFormat> _bugColorFormats;

        TAccountADO _account;
        AccountRight[] _AccountRights;
        object _lockObj;

        Dictionary<string, DataGridViewStatusCell.StatusCell> _bugCellStatus;

        public BugListF(TAccountADO account, AccountRight[] AccountRights, int sprintID, int taskID, bool autoLoad = false)
        {
            InitializeComponent();
            _lockObj = new object();
            _account = account ?? new TAccountADO() { AccountType = -1 };
            _AccountRights = AccountRights ?? new AccountRight[0];
            _bugProcess = new BugTrackerProcess();
            _dlgProcess = new DelegateProcess();
            _sprintID = sprintID;
            _taskID = taskID;
            if (!SystemInformation.TerminalServerSession)
            {
                Type dgvType = dgv_bug.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dgv_bug, true, null);
            }
            _chkall_bugs = _dlgProcess.AddDataGridViewCheckBoxAll(dgv_bug, "col_bug_chk");
            dgv_bug.SelectionChanged += Dgv_bug_SelectionChanged;
            //@Giao 2020-03-11 Fix sort priority - Critical > High > Normal* > Normal
            dgv_bug.SortCompare += Dgv_bug_SortCompare;

            _bugCellStatus = new Dictionary<string, DataGridViewStatusCell.StatusCell>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "New", new  DataGridViewStatusCell.StatusCell(){ Value = "New", BackColor = Color.White, ForeColor = Color.Black } },
                { "In Process", new  DataGridViewStatusCell.StatusCell() { Value = "In Process", BackColor = Color.FromArgb(102, 153, 255), ForeColor = Color.White }},
                { "Resolved", new  DataGridViewStatusCell.StatusCell()  { Value = "Resolved", BackColor = Color.FromArgb(27, 54, 78), ForeColor = Color.White }},
                { "Reopen", new  DataGridViewStatusCell.StatusCell() { Value = "Reopen", BackColor = Color.White, ForeColor = Color.Red }},
                { "Verified", new  DataGridViewStatusCell.StatusCell()  { Value = "Verified", BackColor = Color.FromArgb(0,176,80), ForeColor = Color.White }},
                { "Not Fix", new  DataGridViewStatusCell.StatusCell() { Value = "Not Fix", BackColor = Color.FromArgb(255, 192, 0), ForeColor = Color.Red }},
                { "By Design", new  DataGridViewStatusCell.StatusCell() { Value = "By Design", BackColor = Color.FromArgb(248, 203, 173), ForeColor = Color.Black }},
                { "Unknown", new  DataGridViewStatusCell.StatusCell() { Value = "Unknown", BackColor = Color.White, ForeColor = Color.Black } },
                { "Fixed", new  DataGridViewStatusCell.StatusCell()  { Value = "Fixed", BackColor =  Color.FromArgb(0, 176, 240), ForeColor = Color.White }},
                { "Please Wait", new  DataGridViewStatusCell.StatusCell()  { Value = "Please Wait", BackColor =  Color.FromArgb(0, 176, 240), ForeColor = Color.White }},
            };

            _bugPriorityFormats = new Dictionary<string, Bitmap>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "Critical", Resources.critical },
                { "High", Resources.high },
                { "Normal", Resources.low },
                { "Normal*", Resources.up },
                { "Unknown", Resources.low },
            };

            ts_top_newbug.Enabled = _AccountRights.Contains(AccountRight.AddBug);

            cms_bug_moveto.Enabled = _AccountRights.Contains(AccountRight.MoveBug);
            cms_bug_delete.Enabled = _AccountRights.Contains(AccountRight.DeleteBug);

            cms_bug_setpriority.Enabled = _AccountRights.Contains(AccountRight.SetPriority);
            cms_bug_reopen.Enabled = _AccountRights.Contains(AccountRight.Reopen);
            cms_bug_verify.Enabled = _AccountRights.Contains(AccountRight.Verify);

            cms_bug_assigntome.Enabled = _AccountRights.Contains(AccountRight.AssignToMe);
            cms_bug_assignto.Enabled = _AccountRights.Contains(AccountRight.AssignBug);
            cms_bug_resolve.Enabled = _AccountRights.Contains(AccountRight.Resolve);
            cms_bug_notfix.Enabled = _AccountRights.Contains(AccountRight.NotFix);
            cms_bug_bydesign.Enabled = _AccountRights.Contains(AccountRight.ByDesign);

            cms_bug_fixed.Enabled = _AccountRights.Contains(AccountRight.Fixed);
            cms_bug_pleasewait.Enabled = _AccountRights.Contains(AccountRight.PleaseWait);

            //dgv_bug.SortCompare += Dgv_bug_SortCompare;

            ts_top_filters_Click(null, null);

            ts_version_com_reportversion.SelectedIndexChanged += ts_version_com_version_selected_index_Changed;
            ts_version_com_resolveversion.SelectedIndexChanged += ts_version_com_version_selected_index_Changed;

            new Thread(ite => InitializeValues(autoLoad)).Start();
        }

        private void Dgv_bug_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            try
            {
                //@Giao 2020-03-11 Normal* > Normal
                if (e.Column.Name == "col_bug_priority")
                {
                    string strValue1 = e.CellValue1.ToString(), strValue2 = e.CellValue2.ToString();

                    // Other compare
                    e.SortResult = strValue1.CompareTo(strValue2);

                    // Compare Normal && Normal*
                    if (strValue1 == "Normal" && strValue2 == "Normal*")
                        e.SortResult = 1;
                    else if (strValue1 == "Normal*" && strValue2 == "Normal")
                        e.SortResult = -1;

                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Dgv_bug_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv_bug.SelectedRows.Count > 0)
                {
                    var row = dgv_bug.SelectedRows[0];
                    int bugID = Convert.ToInt32(row.Cells["col_bug_id"].Value);
                    if (_m_bug != null && _m_bug.ContainsKey(bugID))
                    {
                        var bug = _m_bug[bugID];
                        rtxt_buginfo_description.Text = bug.Description;
                        rtxt_buginfo_comment.Text = bug.Comment;
                        rtxt_resolveversion.Text = bug.ResolveVersion;
                        rtxt_version.Text = bug.Version;
                        panel_attachment.Controls.Clear();
                        if (bug.Attachments?.Count > 0)
                        {
                            TableLayoutPanel tlp = new TableLayoutPanel() { Dock = DockStyle.Top, AutoScroll = true, ColumnCount = 1, RowCount = bug.Attachments.Count, CellBorderStyle = TableLayoutPanelCellBorderStyle.Single };

                            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                            int rowIdx = 0;
                            int height = 0;
                            foreach (var attachment in bug.Attachments)
                            {
                                var att = _bugProcess.GetAttachment(attachment.AttachmentID);
                                try
                                {
                                    PictureBox pic = new PictureBox() { Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom, ContextMenuStrip = cms_attachment };
                                    pic.Image = Image.FromStream(new MemoryStream(att.FileData));
                                    pic.Tag = attachment.AttachmentID;
                                    pic.MouseDoubleClick += Pic_MouseDoubleClick;
                                    tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, panel_attachment.Height - 10));
                                    height += panel_attachment.Height - 10;
                                    tlp.Controls.Add(pic, 0, rowIdx);
                                }
                                catch
                                {
                                    LinkLabel linkLabel = new LinkLabel() { Anchor = AnchorStyles.Left | AnchorStyles.Right, Text = att.FileName, ContextMenuStrip = cms_attachment };
                                    linkLabel.Tag = attachment.AttachmentID;
                                    linkLabel.LinkClicked += LinkLabel_LinkClicked;
                                    tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                                    height += 30;
                                    tlp.Controls.Add(linkLabel, 0, rowIdx);
                                }
                                rowIdx++;
                            }
                            tlp.Height = height + 10;
                            panel_attachment.Controls.Add(tlp);
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                LinkLabel linkLabel = sender as LinkLabel;
                int attachmentID = Convert.ToInt32(linkLabel.Tag);
                var att = _bugProcess.GetAttachment(attachmentID);
                SaveFileDialog sfd = new SaveFileDialog() { Title = "Save Attachment", FileName = att.FileName, DefaultExt = att.FileExtension };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sfd.FileName, att.FileData);
                    Process.Start(sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                PictureBox pic = sender as PictureBox;
                int attachmentID = Convert.ToInt32(pic.Tag);
                new PictureViewF(attachmentID) { WindowState = FormWindowState.Maximized }.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ts_top_refresh_Click(object sender, EventArgs e)
        {
            new Thread(LoadBugs).Start();
        }

        public void ReloadTasks()
        {

            try
            {
                var sprints = _bugProcess.GetAllSprints();
                if (sprints?.Count > 0)
                {
                    _dlgProcess.Execute(cms_bug, () =>
                    {
                        cms_bug_moveto.DropDownItems.Clear();
                        foreach (TSprintInfo sprint in sprints)
                        {
                            ToolStripMenuItem[] taskItems = sprint.Tasks.Select(ite => new ToolStripMenuItem(ite.Summary, Resources.task, cms_bug_moveto_Click, ite.SprintID + "-" + ite.TaskID)).ToArray();
                            ToolStripMenuItem sprintItem = new ToolStripMenuItem(sprint.SprintName, Resources.story, null, sprint.SprintID + "-0");
                            sprintItem.DropDownItems.AddRange(taskItems);
                            cms_bug_moveto.DropDownItems.Add(sprintItem);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        bool _valueInited;
        void InitializeValues(bool autoLoad)
        {
            try
            {
                _valueInited = false;
                var accounts = _bugProcess.GetAllAccounts();
                _m_account = accounts.ToDictionary(ite => ite.AccountID, ite => ite.AccountName);

                ReloadTasks();

                var coders = _bugProcess.GetAllCoders();
                if (coders?.Count > 0)
                {
                    _dlgProcess.Execute(cms_bug, () =>
                    {

                        ToolStripMenuItem[] assigneeItems = coders.Where(ite => ite.AccountID != _account.AccountID).Select(ite => new ToolStripMenuItem(ite.AccountName, Resources.generic, cms_bug_assignto_Click, ite.AccountID.ToString())).ToArray();
                        cms_bug_assignto.DropDownItems.AddRange(assigneeItems);
                    });
                    _dlgProcess.Execute(ts_assignee, () =>
                    {
                        ts_assignee.Items.Add(new ToolStripButton("Not Assigned", Resources.generic, ts_assignee_item_Click, "0") { CheckOnClick = true, Checked = true });
                        ToolStripButton[] items = coders.Select(ite => new ToolStripButton(ite.AccountName, Resources.generic, ts_assignee_item_Click, ite.AccountID.ToString()) { CheckOnClick = true, Checked = true }).ToArray();
                        ts_assignee.Items.AddRange(items);
                    });
                    _assigneeIds = coders.Select(ite => ite.AccountID).ToList();
                    _assigneeIds.Add(0);
                }
                else _assigneeIds = new List<int>() { -1 };

                var testers = _bugProcess.GetAllTesters();
                if (testers?.Count > 0)
                {
                    _dlgProcess.Execute(ts_reporter, () =>
                    {
                        ts_reporter.Items.Add(new ToolStripButton("Anonymous", Resources.generic, ts_reporter_item_Click, "0") { CheckOnClick = true, Checked = true });
                        ToolStripButton[] items = testers.Select(ite => new ToolStripButton(ite.AccountName, Resources.generic, ts_reporter_item_Click, ite.AccountID.ToString()) { CheckOnClick = true, Checked = true }).ToArray();
                        ts_reporter.Items.AddRange(items);
                    });
                    _reporterIds = testers.Select(ite => ite.AccountID).ToList();
                    _reporterIds.Add(0);
                }
                else _reporterIds = new List<int>() { -1 };

                var statuses = _bugProcess.GetAllStatuses();
                if (statuses?.Count > 0)
                {
                    _m_status = statuses.ToDictionary(ite => ite.StatusID, ite => ite.StatusName);
                    _dlgProcess.Execute(ts_status, () =>
                    {
                        ToolStripButton[] items = statuses.Select(ite => new ToolStripButton(ite.StatusName, null, ts_status_item_Click, ite.StatusID.ToString()) { CheckOnClick = true, Checked = true }).ToArray();
                        ts_status.Items.AddRange(items);
                    });
                    _statusIds = statuses.Select(ite => ite.StatusID).ToList();
                }
                else _statusIds = new List<int>() { -1 };


                var priorities = _bugProcess.GetAllPriorities();
                // 11/02/2020
                // Change index Normal* to 1. Normal -> Normal* -> High -> Critical
                // Copy last item (Normal*) -> Insert to 1 -> Remove last index
                if (priorities[priorities.Count - 1].PriorityName.ToString() == "Normal*")
                {
                    var prioritySwap = priorities[priorities.Count - 1];
                    priorities.Insert(1, prioritySwap);
                    priorities.RemoveAt(priorities.Count - 1);
                }

                if (priorities?.Count > 0)
                {
                    _m_priority = priorities.ToDictionary(ite => ite.PriorityID, ite => ite.PriorityName);
                    _dlgProcess.Execute(cms_bug, () =>
                    {

                        ToolStripMenuItem[] priorityItems = priorities.Select(ite => new ToolStripMenuItem(ite.PriorityName, _bugPriorityFormats.ContainsKey(ite.PriorityName) ? _bugPriorityFormats[ite.PriorityName] : null, cms_bug_setpriority_Click, ite.PriorityID.ToString())).ToArray();
                        cms_bug_setpriority.DropDownItems.AddRange(priorityItems);
                    });
                    _dlgProcess.Execute(ts_priority, () =>
                    {
                        ToolStripButton[] items = priorities.Select(ite => new ToolStripButton(ite.PriorityName, _bugPriorityFormats.ContainsKey(ite.PriorityName) ? _bugPriorityFormats[ite.PriorityName] : null, ts_priority_item_Click, ite.PriorityID.ToString()) { CheckOnClick = true, Checked = true }).ToArray();
                        ts_priority.Items.AddRange(items);
                    });
                    _priorityIds = priorities.Select(ite => ite.PriorityID).ToList();
                }
                else _priorityIds = new List<int>() { -1 };

                var versions = _bugProcess.GetAllBugVersions(_sprintID);
                if(versions?.Count > 0)
                {
                    List<string> rpVersions = new List<string>() { "- All -" };
                    rpVersions.AddRange(versions.Where(ite => !string.IsNullOrEmpty(ite?.Version)).Select(ite => ite.Version));

                    List<string> rsVersions = new List<string>() { "- All -" };
                    rsVersions.AddRange(versions.Where(ite => !string.IsNullOrEmpty(ite?.ResolveVersion)).Select(ite => ite.ResolveVersion));

                    _dlgProcess.Execute(ts_version, () => 
                    {
                        ts_version_com_reportversion.Items.AddRange(rpVersions.ToArray());
                        ts_version_com_reportversion.SelectedIndex = 0;

                        ts_version_com_resolveversion.Items.AddRange(rsVersions.ToArray());
                        ts_version_com_resolveversion.SelectedIndex = 0;
                    });
                }


                if (autoLoad) new Thread(LoadBugs).Start();
                _valueInited = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        List<int> _assigneeIds;
        private void ts_assignee_allassignees_Click(object sender, EventArgs e)
        {
            try
            {
                _assigneeIds = new List<int>();
                foreach (ToolStripButton button in ts_assignee.Items)
                {
                    if (button.Name.Equals("ts_assignee_allassignees", StringComparison.InvariantCultureIgnoreCase))
                    { }
                    else
                    {
                        button.Checked = ts_assignee_allassignees.Checked;
                        if (ts_assignee_allassignees.Checked) _assigneeIds.Add(int.Parse(button.Name));
                    }
                }
                if (_assigneeIds.Count == 0) _assigneeIds.Add(-1);
                new Thread(LoadBugs).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ts_assignee_item_Click(object sender, EventArgs e)
        {
            try
            {
                ts_assignee_allassignees.Checked = true;
                _assigneeIds = new List<int>();
                foreach (ToolStripButton button in ts_assignee.Items)
                {
                    if (button.Name.Equals("ts_assignee_allassignees", StringComparison.InvariantCultureIgnoreCase))
                    { }
                    else
                    {
                        if (button.Checked)
                        {
                            _assigneeIds.Add(int.Parse(button.Name));
                        }
                        else ts_assignee_allassignees.Checked = false;
                    }
                }
                if (_assigneeIds.Count == 0) _assigneeIds.Add(-1);
                new Thread(LoadBugs).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        List<int> _statusIds;
        private void ts_status_allstatuses_Click(object sender, EventArgs e)
        {
            try
            {
                _statusIds = new List<int>();
                foreach (ToolStripButton button in ts_status.Items)
                {
                    if (button.Name.Equals("ts_status_allstatuses", StringComparison.InvariantCultureIgnoreCase))
                    { }
                    else
                    {
                        button.Checked = ts_status_allstatuses.Checked;
                        if (ts_status_allstatuses.Checked) _statusIds.Add(int.Parse(button.Name));
                    }
                }
                if (_statusIds.Count == 0) _statusIds.Add(-1);
                new Thread(LoadBugs).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ts_status_item_Click(object sender, EventArgs e)
        {
            try
            {
                ts_status_allstatuses.Checked = true;
                _statusIds = new List<int>();
                foreach (ToolStripButton button in ts_status.Items)
                {
                    if (button.Name.Equals("ts_status_allstatuses", StringComparison.InvariantCultureIgnoreCase))
                    { }
                    else
                    {
                        if (button.Checked)
                        {
                            _statusIds.Add(int.Parse(button.Name));
                        }
                        else ts_status_allstatuses.Checked = false;
                    }
                }
                if (_statusIds.Count == 0) _statusIds.Add(-1);
                new Thread(LoadBugs).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        List<int> _priorityIds;
        private void ts_priority_allpriorities_Click(object sender, EventArgs e)
        {
            try
            {
                _priorityIds = new List<int>();
                foreach (ToolStripButton button in ts_priority.Items)
                {
                    if (button.Name.Equals("ts_priority_allpriorities", StringComparison.InvariantCultureIgnoreCase))
                    { }
                    else
                    {
                        button.Checked = ts_priority_allpriorities.Checked;
                        if (ts_priority_allpriorities.Checked) _priorityIds.Add(int.Parse(button.Name));
                    }
                }
                if (_priorityIds.Count == 0) _priorityIds.Add(-1);
                new Thread(LoadBugs).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void ts_priority_item_Click(object sender, EventArgs e)
        {
            try
            {
                ts_priority_allpriorities.Checked = true;
                _priorityIds = new List<int>();
                foreach (ToolStripButton button in ts_priority.Items)
                {
                    if (button.Name.Equals("ts_priority_allpriorities", StringComparison.InvariantCultureIgnoreCase))
                    { }
                    else
                    {
                        if (button.Checked)
                        {
                            _priorityIds.Add(int.Parse(button.Name));
                        }
                        else ts_priority_allpriorities.Checked = false;
                    }
                }
                if (_priorityIds.Count == 0) _priorityIds.Add(-1);
                new Thread(LoadBugs).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ts_buginfo_edit_Click(object sender, EventArgs e)
        {
            if (ts_buginfo_edit.Text.Equals("Edit", StringComparison.InvariantCultureIgnoreCase))
            {
                ts_buginfo_edit.Text = "Update";
                rtxt_buginfo_comment.ReadOnly = false;
                rtxt_buginfo_description.ReadOnly = false;
                rtxt_version.ReadOnly = false;
                rtxt_resolveversion.ReadOnly = false;
            }
            else if (ts_buginfo_edit.Text.Equals("Update", StringComparison.InvariantCultureIgnoreCase))
            {
                if (dgv_bug.SelectedRows.Count > 0)
                {
                    try
                    {
                        int bugID = Convert.ToInt32(dgv_bug.SelectedRows[0].Cells["col_bug_id"].Value);
                        _bugProcess.UpdateBugDescription(bugID, rtxt_buginfo_description.Text);
                        _bugProcess.UpdateBugComment(bugID, rtxt_buginfo_comment.Text);
                        _bugProcess.UpdateBugVersion(bugID, rtxt_version.Text);
                        _bugProcess.UpdateBugResolveVersion(bugID, rtxt_resolveversion.Text);
                        if (_m_bug != null && _m_bug.ContainsKey(bugID))
                        {
                            _m_bug[bugID].Description = rtxt_buginfo_description.Text;
                            _m_bug[bugID].Comment = rtxt_buginfo_comment.Text;
                            _m_bug[bugID].Version = rtxt_version.Text;
                            _m_bug[bugID].ResolveVersion = rtxt_resolveversion.Text;
                            _dlgProcess.SetDataGridViewValue(dgv_bug, dgv_bug.SelectedRows[0].Index, "col_bug_description", rtxt_buginfo_description.Text);
                            _dlgProcess.SetDataGridViewValue(dgv_bug, dgv_bug.SelectedRows[0].Index, "col_bug_resolveversion", rtxt_resolveversion.Text);
                            _dlgProcess.SetDataGridViewValue(dgv_bug, dgv_bug.SelectedRows[0].Index, "col_bug_version", rtxt_version.Text);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                ts_buginfo_edit.Text = "Edit";
                rtxt_buginfo_comment.ReadOnly = true;
                rtxt_buginfo_description.ReadOnly = true;
                rtxt_version.ReadOnly = true;
                rtxt_resolveversion.ReadOnly = true;
            }
        }

        private void ts_top_newbug_Click(object sender, EventArgs e)
        {

            try
            {
                AddBugF addBugF = new AddBugF(_account, _sprintID, _taskID);
                if (addBugF.ShowDialog() == DialogResult.OK)
                {
                    ts_top_refresh_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ts_top_filters_Click(object sender, EventArgs e)
        {
            try
            {
                ts_assignee.Visible = ts_top_filters.Checked;
                ts_priority.Visible = ts_top_filters.Checked;
                ts_status.Visible = ts_top_filters.Checked;
                ts_reporter.Visible = ts_top_filters.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ts_top_viewbugdetail_Click(object sender, EventArgs e)
        {
            sc_1.Panel2Collapsed = !ts_top_viewbugdetail.Checked;
            Dgv_bug_SelectionChanged(null, null);
        }

        Dictionary<int, TBugFullInfo> _m_bug;
        void LoadBugs()
        {
            lock (_lockObj)
            {
                _dlgProcess.Execute(_chkall_bugs, () => _chkall_bugs.Checked = false);
                _dlgProcess.Execute(panel_attachment, () => panel_attachment.Controls.Clear());
                _dlgProcess.ClearDataGridViewRows(dgv_bug);
                _dlgProcess.SetText(rtxt_buginfo_description, "");
                _dlgProcess.SetText(rtxt_buginfo_comment, "");
                try
                {
                    string rpVersion = _dlgProcess.GetControlValue(ts_version, ts_version => ts_version_com_reportversion.Text);
                    if (rpVersion.Equals("- ALL -", StringComparison.InvariantCultureIgnoreCase))
                        rpVersion = "";
                    string[] rpVersions = string.IsNullOrEmpty(rpVersion) ? new string[0] : new string[] { rpVersion };

                    string rsVersion = _dlgProcess.GetControlValue(ts_version, ts_version => ts_version_com_resolveversion.Text);
                    if (rsVersion.Equals("- ALL -", StringComparison.InvariantCultureIgnoreCase))
                        rsVersion = "";
                    string[] rsVersions = string.IsNullOrEmpty(rsVersion) ? new string[0] : new string[] { rsVersion };

                    //var bugs = _bugProcess.GetBugs(_sprintID, _taskID, _statusIds.ToArray(), _priorityIds.ToArray(), _assigneeIds.ToArray());
                    //var bugs = _bugProcess.GetBugs(_sprintID, _taskID, _statusIds.ToArray(), _priorityIds.ToArray(), _assigneeIds.ToArray(), _reporterIds.ToArray());
                    var bugs = _bugProcess.GetBugs(_sprintID, _taskID, _statusIds.ToArray(), _priorityIds.ToArray(), _assigneeIds.ToArray(), _reporterIds.ToArray(), rpVersions, rsVersions);


                    _m_bug = bugs.ToDictionary(ite => ite.BugID, ite => ite);
                    foreach (var bug in bugs)
                    {
                        string reporter = _m_account.ContainsKey(bug.AddedAccountID) ? _m_account[bug.AddedAccountID] : "Administrator";
                        string assignee = _m_account.ContainsKey(bug.AssignedAccountID) ? _m_account[bug.AssignedAccountID] : "Not Assigned";
                        string status = _m_status.ContainsKey(bug.StatusID) ? _m_status[bug.StatusID] : "Unknown";
                        string priority = _m_priority.ContainsKey(bug.PriorityID) ? _m_priority[bug.PriorityID] : "Unknown";

                        var priorityFormat = _bugPriorityFormats[priority];                       //
                        var statusCell = new DataGridViewStatusCell.StatusCell(status, _bugCellStatus[status].BackColor, _bugCellStatus[status].ForeColor);

                        DateTime createdDate;
                        if (!DateTime.TryParseExact(bug.CreatedDate.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out createdDate)) createdDate = DateTime.MinValue;

                        int rIdx = _dlgProcess.AddDataGridViewRow(dgv_bug, false, bug.BugID, priorityFormat, priority, statusCell, bug.Description, bug.Version, bug.ResolveVersion, reporter, assignee, createdDate == DateTime.MinValue ? "-" : createdDate.ToString("dd/MM/yyyy"));
                    }
                    _dlgProcess.SetText(grp_buglist, "BugList. Total Bugs: " + bugs.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        void cms_bug_moveto_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = _dlgProcess.GetDataGridViewCheckedRows(dgv_bug, "col_bug_chk");
                if (rows.Count == 0) rows = _dlgProcess.GetDataGridViewSelectedRows(dgv_bug);
                if (rows.Count == 0) return;

                if (MessageBox.Show("Do you want to move?", "Move Bug Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int[] bugIds = rows.Select(ite => Convert.ToInt32(ite.Cells["col_bug_id"].Value)).ToArray();

                    ToolStripMenuItem item = sender as ToolStripMenuItem;
                    string[] ids = item.Name.Split('-');
                    int sprintID, taskID;
                    if (!int.TryParse(ids[0], out sprintID)) sprintID = 0;
                    if (!int.TryParse(ids[1], out taskID)) taskID = 0;

                    _bugProcess.MoveBugs(sprintID, taskID, bugIds);
                    ts_top_refresh_Click(null, null);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void cms_bug_assignto_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = _dlgProcess.GetDataGridViewCheckedRows(dgv_bug, "col_bug_chk");
                if (rows.Count == 0) rows = _dlgProcess.GetDataGridViewSelectedRows(dgv_bug);
                if (rows.Count == 0) return;

                int[] bugIds = rows.Select(ite => Convert.ToInt32(ite.Cells["col_bug_id"].Value)).ToArray();

                ToolStripMenuItem item = sender as ToolStripMenuItem;
                int assigneeID;
                if (!int.TryParse(item.Name, out assigneeID)) assigneeID = 0;
                _bugProcess.AssignBug(assigneeID, bugIds);
                var statusCell = _bugCellStatus["New"];

                foreach (var row in rows)
                {
                    _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_assignee", item.Text);
                    _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_cellstatus", statusCell);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void cms_bug_setpriority_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = _dlgProcess.GetDataGridViewCheckedRows(dgv_bug, "col_bug_chk");
                if (rows.Count == 0) rows = _dlgProcess.GetDataGridViewSelectedRows(dgv_bug);
                if (rows.Count == 0) return;

                int[] bugIds = rows.Select(ite => Convert.ToInt32(ite.Cells["col_bug_id"].Value)).ToArray();

                ToolStripMenuItem item = sender as ToolStripMenuItem;
                int priorityID;
                if (!int.TryParse(item.Name, out priorityID)) priorityID = 0;
                _bugProcess.UpdatePriorityBugs(priorityID, bugIds);

                var priorityFormat = _bugPriorityFormats[item.Text];

                foreach (var row in rows)
                {
                    _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_priority", item.Text);
                    _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_prioritycolor", priorityFormat);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void cms_bug_delete_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = _dlgProcess.GetDataGridViewCheckedRows(dgv_bug, "col_bug_chk");
                if (rows.Count == 0) rows = _dlgProcess.GetDataGridViewSelectedRows(dgv_bug);
                if (rows.Count == 0) return;

                int[] bugIds = rows.Select(ite => Convert.ToInt32(ite.Cells["col_bug_id"].Value)).ToArray();
                if (MessageBox.Show("Are you sure?", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _bugProcess.DeleteBugs(bugIds);
                    ts_top_refresh_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void cms_bug_reopen_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = _dlgProcess.GetDataGridViewCheckedRows(dgv_bug, "col_bug_chk");
                if (rows.Count == 0) rows = _dlgProcess.GetDataGridViewSelectedRows(dgv_bug);
                if (rows.Count == 0) return;

                int[] bugIds = rows.Select(ite => Convert.ToInt32(ite.Cells["col_bug_id"].Value)).ToArray();
                _bugProcess.ReopenBugs(_account.AccountID, bugIds);
                var statusCell = _bugCellStatus["Reopen"];
                foreach (var row in rows)
                {
                    _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_cellstatus", statusCell);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void cms_bug_verify_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = _dlgProcess.GetDataGridViewCheckedRows(dgv_bug, "col_bug_chk");
                if (rows.Count == 0) rows = _dlgProcess.GetDataGridViewSelectedRows(dgv_bug);
                if (rows.Count == 0) return;

                int[] bugIds = rows.Select(ite => Convert.ToInt32(ite.Cells["col_bug_id"].Value)).ToArray();
                _bugProcess.VerifyBugs(_account.AccountID, bugIds);
                var statusCell = _bugCellStatus["Verified"];
                foreach (var row in rows)
                {
                    _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_cellstatus", statusCell);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void cms_bug_assigntome_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = _dlgProcess.GetDataGridViewCheckedRows(dgv_bug, "col_bug_chk");
                if (rows.Count == 0) rows = _dlgProcess.GetDataGridViewSelectedRows(dgv_bug);
                if (rows.Count == 0) return;

                int[] bugIds = rows.Select(ite => Convert.ToInt32(ite.Cells["col_bug_id"].Value)).ToArray();
                _bugProcess.AssignBugToMe(_account.AccountID, bugIds);
                var statusCell = _bugCellStatus["In Process"];
                foreach (var row in rows)
                {
                    _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_assignee", _account.AccountName);
                    _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_cellstatus", statusCell);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ts_top_compactview_Click(object sender, EventArgs e)
        {
            col_bug_priority.Visible = !ts_top_compactview.Checked;
            col_bug_status.Visible = !ts_top_compactview.Checked;
        }



        void cms_bug_resolve_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = _dlgProcess.GetDataGridViewCheckedRows(dgv_bug, "col_bug_chk");
                if (rows.Count == 0) rows = _dlgProcess.GetDataGridViewSelectedRows(dgv_bug);
                if (rows.Count == 0) return;

                AddTextF addTextF = new AddTextF("Resolve for version: ", "");
                if(addTextF.ShowDialog() == DialogResult.OK)
                {
                    int[] bugIds = rows.Select(ite => Convert.ToInt32(ite.Cells["col_bug_id"].Value)).ToArray();
                    _bugProcess.ResolveBugs(_account.AccountID, bugIds);
                    _bugProcess.UpdateBugResolveVersion(bugIds, addTextF.InputText);
                    var statusCell = _bugCellStatus["Resolved"];
                    foreach (var row in rows)
                    {
                        _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_assignee", _account.AccountName);
                        _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_cellstatus", statusCell);
                    }
                    foreach(int bugId in bugIds)
                    {
                        if(_m_bug.ContainsKey(bugId))
                        {
                            _m_bug[bugId].ResolveVersion = addTextF.InputText;
                        }
                    }
                    rtxt_resolveversion.Text = addTextF.InputText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        void cms_bug_notfix_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = _dlgProcess.GetDataGridViewCheckedRows(dgv_bug, "col_bug_chk");
                if (rows.Count == 0) rows = _dlgProcess.GetDataGridViewSelectedRows(dgv_bug);
                if (rows.Count == 0) return;

                int[] bugIds = rows.Select(ite => Convert.ToInt32(ite.Cells["col_bug_id"].Value)).ToArray();
                _bugProcess.NotFixBugs(_account.AccountID, bugIds);
                var statusCell = _bugCellStatus["Not Fix"];
                foreach (var row in rows)
                {
                    _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_assignee", _account.AccountName);
                    _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_cellstatus", statusCell);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        void cms_bug_bydesign_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = _dlgProcess.GetDataGridViewCheckedRows(dgv_bug, "col_bug_chk");
                if (rows.Count == 0) rows = _dlgProcess.GetDataGridViewSelectedRows(dgv_bug);
                if (rows.Count == 0) return;

                int[] bugIds = rows.Select(ite => Convert.ToInt32(ite.Cells["col_bug_id"].Value)).ToArray();
                _bugProcess.ByDesignBugs(_account.AccountID, bugIds);
                var statusCell = _bugCellStatus["By Design"];
                foreach (var row in rows)
                {
                    _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_assignee", _account.AccountName);
                    _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_cellstatus", statusCell);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cms_bug_fixed_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = _dlgProcess.GetDataGridViewCheckedRows(dgv_bug, "col_bug_chk");
                if (rows.Count == 0) rows = _dlgProcess.GetDataGridViewSelectedRows(dgv_bug);
                if (rows.Count == 0) return;

                int[] bugIds = rows.Select(ite => Convert.ToInt32(ite.Cells["col_bug_id"].Value)).ToArray();
                _bugProcess.FixedBugs(_account.AccountID, bugIds);
                var statusCell = _bugCellStatus["Fixed"];
                foreach (var row in rows)
                {
                    _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_assignee", _account.AccountName);
                    _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_cellstatus", statusCell);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cms_bug_pleasewait_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = _dlgProcess.GetDataGridViewCheckedRows(dgv_bug, "col_bug_chk");
                if (rows.Count == 0) rows = _dlgProcess.GetDataGridViewSelectedRows(dgv_bug);
                if (rows.Count == 0) return;

                int[] bugIds = rows.Select(ite => Convert.ToInt32(ite.Cells["col_bug_id"].Value)).ToArray();
                _bugProcess.PleaseWaitBugs(_account.AccountID, bugIds);
                var statusCell = _bugCellStatus["Please Wait"];
                foreach (var row in rows)
                {
                    _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_assignee", _account.AccountName);
                    _dlgProcess.SetDataGridViewValue(dgv_bug, row.Index, "col_bug_cellstatus", statusCell);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ts_top_but_searchbug_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ts_top_txt_bugids.Text.Trim())) return;

            try
            {
                string[] idStrs = ts_top_txt_bugids.Text.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                List<int> bugIds = new List<int>();
                foreach (var idStr in idStrs)
                {
                    int bugId;
                    if (int.TryParse(idStr, out bugId))
                    {
                        bugIds.Add(bugId);
                    }
                }
                if (bugIds.Count > 0)
                {
                    Task.Run(() => LoadBugs(bugIds));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void LoadBugs(List<int> bugIds)
        {
            lock (_lockObj)
            {
                _dlgProcess.Execute(_chkall_bugs, () => _chkall_bugs.Checked = false);
                _dlgProcess.Execute(panel_attachment, () => panel_attachment.Controls.Clear());
                _dlgProcess.ClearDataGridViewRows(dgv_bug);
                _dlgProcess.SetText(rtxt_buginfo_description, "");
                _dlgProcess.SetText(rtxt_buginfo_comment, "");
                try
                {
                    var bugs = _bugProcess.GetBugs(bugIds?.ToArray());
                    _m_bug = bugs.ToDictionary(ite => ite.BugID, ite => ite);
                    foreach (var bug in bugs)
                    {
                        string reporter = _m_account.ContainsKey(bug.AddedAccountID) ? _m_account[bug.AddedAccountID] : "Administrator";
                        string assignee = _m_account.ContainsKey(bug.AssignedAccountID) ? _m_account[bug.AssignedAccountID] : "Not Assigned";
                        string status = _m_status.ContainsKey(bug.StatusID) ? _m_status[bug.StatusID] : "Unknown";
                        string priority = _m_priority.ContainsKey(bug.PriorityID) ? _m_priority[bug.PriorityID] : "Unknown";

                        var priorityFormat = _bugPriorityFormats[priority];                       //
                        var statusCell = new DataGridViewStatusCell.StatusCell(status, _bugCellStatus[status].BackColor, _bugCellStatus[status].ForeColor);

                        DateTime createdDate;
                        if (!DateTime.TryParseExact(bug.CreatedDate.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out createdDate)) createdDate = DateTime.MinValue;

                        int rIdx = _dlgProcess.AddDataGridViewRow(dgv_bug, false, bug.BugID, priorityFormat, priority, statusCell, bug.Description, bug.Version, bug.ResolveVersion, reporter, assignee, createdDate == DateTime.MinValue ? "-" : createdDate.ToString("dd/MM/yyyy"));
                    }
                    _dlgProcess.SetText(grp_buglist, "BugList. Total Bugs: " + bugs.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ts_buginfo_addattachment_Click(object sender, EventArgs e)
        {

            try
            {
                var rows = _dlgProcess.GetDataGridViewSelectedRows(dgv_bug);
                if (rows?.Count > 0)
                {
                    int bugID = Convert.ToInt32(rows[0].Cells["col_bug_id"].Value);
                    OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true, Title = "Select Attachment" };
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo[] files = ofd.FileNames.Select(ite => new FileInfo(ite)).ToArray();
                        TAttachmentADO[] attachments = files.Select(ite => new TAttachmentADO() { BugID = bugID, FileData = File.ReadAllBytes(ite.FullName), FileExtension = ite.Extension, FileName = ite.Name }).ToArray();

                        foreach (var att in attachments)
                        {
                            _bugProcess.AddAttachment(att);
                            att.FileData = null;
                        }
                        _m_bug[bugID] = _bugProcess.GetBug(bugID);
                        Dgv_bug_SelectionChanged(null, null);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cms_attachment_delete_Click(object sender, EventArgs e)
        {

            try
            {
                if (_account.AccountLogin.Equals("admin") || _account.AccountType == 2)
                {
                    var rows = _dlgProcess.GetDataGridViewSelectedRows(dgv_bug);
                    if (rows?.Count > 0)
                    {
                        int bugID = Convert.ToInt32(rows[0].Cells["col_bug_id"].Value);
                        Control control = cms_attachment.SourceControl;
                        int attachemt_ID = Convert.ToInt32(control.Tag);
                        if (MessageBox.Show("You want to delete this attachment?", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _bugProcess.DeleteAttachments(attachemt_ID);
                            _m_bug[bugID] = _bugProcess.GetBug(bugID);
                            Dgv_bug_SelectionChanged(null, null);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You cannot delete, please contact tester or administrator.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ts_buginfo_deleteallattachment_Click(object sender, EventArgs e)
        {
            var rows = _dlgProcess.GetDataGridViewSelectedRows(dgv_bug);
            if (rows?.Count > 0)
            {
                try
                {
                    int bugID = Convert.ToInt32(rows[0].Cells["col_bug_id"].Value);
                    if (MessageBox.Show("You want to delete this attachment?", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _bugProcess.DeleteAttachmentsFollowBug(bugID);
                        _m_bug[bugID] = _bugProcess.GetBug(bugID);
                        Dgv_bug_SelectionChanged(null, null);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        List<int> _reporterIds;

        private void ts_top_txt_bugids_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                ts_top_but_searchbug_Click(null, null);
            }
        }

        private void ts_reporter_allreporters_Click(object sender, EventArgs e)
        {
            try
            {
                _reporterIds = new List<int>();
                foreach (ToolStripButton button in ts_reporter.Items)
                {
                    if (button.Name.Equals("ts_reporter_allreporters", StringComparison.InvariantCultureIgnoreCase))
                    { }
                    else
                    {
                        button.Checked = ts_reporter_allreporters.Checked;
                        if (ts_reporter_allreporters.Checked) _reporterIds.Add(int.Parse(button.Name));
                    }
                }
                if (_reporterIds.Count == 0) _reporterIds.Add(-1);
                new Thread(LoadBugs).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void ts_reporter_item_Click(object sender, EventArgs e)
        {
            try
            {
                ts_reporter_allreporters.Checked = true;
                _reporterIds = new List<int>();
                foreach (ToolStripButton button in ts_reporter.Items)
                {
                    if (button.Name.Equals("ts_reporter_allreporters", StringComparison.InvariantCultureIgnoreCase))
                    { }
                    else
                    {
                        if (button.Checked)
                        {
                            _reporterIds.Add(int.Parse(button.Name));
                        }
                        else ts_reporter_allreporters.Checked = false;
                    }
                }
                if (_reporterIds.Count == 0) _reporterIds.Add(-1);
                new Thread(LoadBugs).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ts_version_com_version_selected_index_Changed(object sender, EventArgs e)
        {
            try
            {
                if(_valueInited)
                {
                    new Thread(LoadBugs).Start();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

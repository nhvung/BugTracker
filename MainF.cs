using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSBugTracker;
using VSBugTracker.ADO;

namespace BugSearch
{
    public partial class MainF : Form
    {
        BugTrackerProcess _bugProcess;
        DelegateProcess _dlgProcess;
        TAccountADO _account;
        AccountRight[] _AccountRights;
        BugListF _bugListF;

        System.Timers.Timer _tmrAutoRefresh;

        public MainF()
        {
            InitializeComponent();
            _dlgProcess = new DelegateProcess();
            _bugProcess = new BugTrackerProcess();

            SizeChanged += (o, e) =>
            {
                sc_1.SplitterDistance = 300;
            };
            sc_1.SplitterDistance = 300;

            tv_task.NodeMouseClick += Tv_task_NodeMouseClick;
            tv_task.NodeMouseDoubleClick += Tv_task_NodeMouseDoubleClick;

            _AccountRights = new AccountRight[] { AccountRight.AddAccount, AccountRight.AddBug, AccountRight.AddSprint, AccountRight.AddTask, AccountRight.AssignBug, AccountRight.ByDesign, AccountRight.DeleteAccount, AccountRight.DeleteBug, AccountRight.DeleteSprint, AccountRight.DeleteTask, AccountRight.NotFix, AccountRight.Reopen, AccountRight.Resolve, AccountRight.SetPriority, AccountRight.Verify, AccountRight.MoveBug, AccountRight.AssignToMe };

            Load += MainF_Load;
        }

        private void MainF_Load(object sender, EventArgs e)
        {
            Text = "BUGSEARCH - 2.0.2 - 20220906.1440";

            menu_database_open_Click(null, null);
        }

        private void Tv_task_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tv_task.SelectedNode = e.Node;
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    int sprintID = -1, taskID = -1;
                    if (e.Node.Parent == null)
                    {
                        if (!int.TryParse(e.Node.Name, out sprintID)) sprintID = -1;
                        ts_bottom_task.Text = e.Node.Text + " - No Task";
                    }
                    else
                    {
                        string[] ids = e.Node.Name.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                        if (!int.TryParse(ids.First(), out sprintID)) sprintID = -1;
                        if (!int.TryParse(ids.Last(), out taskID)) taskID = -1;

                        ts_bottom_task.Text = e.Node.Parent.Text + " - " + e.Node.Text;
                    }
                    panel_buglist.Controls.Clear();
                    _bugListF = new BugListF(_account, _AccountRights, sprintID, taskID, true) { TopLevel = false, Dock = DockStyle.Fill, Enabled = true };
                    panel_buglist.Controls.Add(_bugListF);
                    _bugListF.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Tv_task_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            try
            {
                tv_task.SelectedNode = e.Node;
                cms_task.Items.Clear();
                int sprintID = -1, taskID = -1;
                if (e.Node.Parent == null) // sprint node
                {
                    if (!int.TryParse(e.Node.Name, out sprintID)) sprintID = -1;
                    if (sprintID == 0)
                    {
                    }
                    else
                    {
                        if (_AccountRights.Contains(AccountRight.AddTask)) cms_task.Items.Add(new ToolStripMenuItem("Add Task...", null, cms_task_addtask_Click, "cms_task_addtask") { Tag = sprintID });
                        if (cms_task.Items.Count > 0) cms_task.Items.Add(new ToolStripSeparator());
                        if (_AccountRights.Contains(AccountRight.DeleteSprint)) cms_task.Items.Add(new ToolStripMenuItem("Delete", null, cms_task_deletesprint_Click, "cms_task_deletesprint") { Tag = sprintID });
                    }
                }
                else // task node
                {
                    string[] ids = e.Node.Name.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    if (!int.TryParse(ids.First(), out sprintID)) sprintID = -1;
                    if (!int.TryParse(ids.Last(), out taskID)) taskID = -1;
                    if (_AccountRights.Contains(AccountRight.DeleteTask))
                    {
                        cms_task.Items.Add(new ToolStripMenuItem("Rename", null, cms_task_renametask_Click, "cms_task_renametask") { Tag = taskID });
                        if (cms_task.Items.Count > 0) cms_task.Items.Add(new ToolStripSeparator());
                        cms_task.Items.Add(new ToolStripMenuItem("Delete", null, cms_task_deletetask_Click, "cms_task_deletetask") { Tag = taskID });
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void cms_task_addtask_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                int sprintID = Convert.ToInt32(item.Tag);
                AddTextF addTextF = new AddTextF();
                if (addTextF.ShowDialog() == DialogResult.OK)
                {
                    if (addTextF.InputText == "")
                    {
                        throw new Exception("Task cannot be empty!");
                    }
                    TTaskADO task = new TTaskADO() { SprintID = sprintID, Summary = addTextF.InputText };

                    try
                    {
                        _bugProcess.AddTasks(task);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Thread th = new Thread(LoadTasks);
                    th.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void cms_task_deletesprint_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                int sprintID = Convert.ToInt32(item.Tag);
                if (sprintID == 0) return;
                if (MessageBox.Show("Are you sure?", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    try
                    {
                        _bugProcess.DeleteSprint(sprintID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Thread th = new Thread(LoadTasks);
                    th.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void cms_task_deletetask_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                int taskID = Convert.ToInt32(item.Tag);
                if (taskID == 0) return;
                if (MessageBox.Show("Are you sure?", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    try
                    {
                        _bugProcess.DeleteTasks(taskID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Thread th = new Thread(LoadTasks);
                    th.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void cms_task_renametask_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                int taskID = Convert.ToInt32(item.Tag);
                if (taskID == 0) return;

                AddTextF addTextF = new AddTextF("Name:", tv_task.SelectedNode.Text);
                if (addTextF.ShowDialog() == DialogResult.OK)
                {
                    if (addTextF.InputText == "")
                    {
                        throw new Exception("Task cannot be empty!");
                    }

                    try
                    {
                        _bugProcess.UpdateTaskName(taskID, addTextF.InputText);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Thread th = new Thread(LoadTasks);
                    th.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menu_database_open_Click(object sender, EventArgs e)
        {
            try
            {
                LoginDatabaseF loginDatabaseF = new LoginDatabaseF();
                if (loginDatabaseF.ShowDialog() == DialogResult.OK)
                {
                    ts_bottom_database.Text = loginDatabaseF.BugDatabase;
                    menu_database_login_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void LoadTasks()
        {

            try
            {
                _dlgProcess.Execute(tv_task, () => { tv_task.Nodes.Clear(); });
                var sprints = _bugProcess.GetAllSprints();
                if (sprints != null && sprints.Count > 0)
                {
                    _dlgProcess.Execute(tv_task, () =>
                    {

                        foreach (var sprint in sprints)
                        {
                            TreeNode sprintNode = new TreeNode(sprint.SprintName, 0, 0) { Name = sprint.SprintID.ToString() };
                            if (sprint.Tasks?.Count > 0)
                            {
                                TreeNode[] taskNodes = sprint.Tasks.Select(ite => new TreeNode(ite.Summary, 1, 1) { Name = ite.SprintID + "-" + ite.TaskID }).ToArray();
                                sprintNode.Nodes.AddRange(taskNodes);
                            }
                            tv_task.Nodes.Add(sprintNode);
                        }
                    });
                    Thread.Sleep(1000);
                    if (_bugListF != null) _bugListF.ReloadTasks();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void menu_database_login_Click(object sender, EventArgs e)
        {

            try
            {
            ReLogin:
                LogInF logInF = new LogInF();
                var loginRes = logInF.ShowDialog();
                if (loginRes == DialogResult.OK)
                {
                    _account = logInF.Account;
                    _AccountRights = new AccountRight[] { AccountRight.AddAccount, AccountRight.AddBug, AccountRight.AddSprint, AccountRight.AddTask, AccountRight.AssignBug, AccountRight.ByDesign, AccountRight.DeleteAccount, AccountRight.DeleteBug, AccountRight.DeleteSprint, AccountRight.DeleteTask, AccountRight.NotFix, AccountRight.Reopen, AccountRight.Resolve, AccountRight.SetPriority, AccountRight.Verify, AccountRight.MoveBug, AccountRight.AssignToMe, AccountRight.Fixed, AccountRight.PleaseWait };
                    _AccountRights = _AccountRights.Where(ite => (_account.AccountRight & (int)ite) == (int)ite).ToArray();

                    ts_bottom_user.Text = _account.AccountName;

                    menu_admintool.Visible = _account.AccountType == 0;
                    ts_task.Visible = _AccountRights.Contains(AccountRight.AddSprint);

                    panel_buglist.Controls.Clear();
                    _bugListF = new BugListF(_account, _AccountRights, -1, -1, false) { TopLevel = false, Dock = DockStyle.Fill, Enabled = false };
                    panel_buglist.Controls.Add(_bugListF);
                    _bugListF.Show();

                    Thread th = new Thread(LoadTasks);
                    th.Start();
                }
                else if (loginRes == DialogResult.Ignore)
                {
                    if (MessageBox.Show("Login Failed. Try Again?", "Login", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        goto ReLogin;
                    }
                    else
                    {

                        _account = null;
                    }
                }
                else
                {
                    ts_bottom_user.Text = "Not Logged In";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void menu_view_sprintandtask_Click(object sender, EventArgs e)
        {
            try
            {
                sc_1.Panel1Collapsed = !menu_view_sprintandtask.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ts_task_addsprint_Click(object sender, EventArgs e)
        {
            try
            {
                AddTextF addTextF = new AddTextF();
                if (addTextF.ShowDialog() == DialogResult.OK)
                {
                    if (addTextF.InputText == "")
                    {
                        throw new Exception("Sprint cannot be empty!");
                    }
                    _bugProcess.AddSprint(new TSprintADO() { SprintName = addTextF.InputText });
                    Thread th = new Thread(LoadTasks);
                    th.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menu_admintool_accountmanager_Click(object sender, EventArgs e)
        {

            try
            {

                AccountF accountF = new AccountF(_account);
                if (accountF.ShowDialog() == DialogResult.OK)
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menu_account_changepassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure?", "Change password confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    AddTextF addTextF = new AddTextF("New Password: ", FSEncode.FSSecurity.Decrypt(_account.EncryptedPassword));
                    if (addTextF.ShowDialog() == DialogResult.OK)
                    {
                        if (addTextF.InputText == "") throw new Exception("Password cannot be empty.");
                        _account.EncryptedPassword = FSEncode.FSSecurity.Encrypt(addTextF.InputText);
                        _bugProcess.UpdateAccount(_account);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menu_database_relogin_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(LoadTasks);
            th.Start();
        }

        private void menu_database_exit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void ts_bottom_notify_Click(object sender, EventArgs e)
        {
            AlarmF alarmF = new AlarmF(_account);
            if (alarmF.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void menu_statistic_Click(object sender, EventArgs e)
        {
            BugStatisticF bugStatisticF = new BugStatisticF(_bugProcess);
            bugStatisticF.Show();
        }
    }
}

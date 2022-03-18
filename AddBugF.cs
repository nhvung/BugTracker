using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSBugTracker;
using VSBugTracker.ADO;
using VSBugTracker.Models;

namespace BugSearch
{
    public partial class AddBugF : Form
    {
        BugTrackerProcess _bugProcess;
        DelegateProcess _dlgProcess;
        List<FileInfo> _attachments;
        TAccountADO _account;
        int _bugCount;

        int _sprintID, _taskID;

        public AddBugF(TAccountADO account, int sprintID, int taskID)
        {
            InitializeComponent();

            _sprintID = sprintID;
            _taskID = taskID;
            _bugCount = 0;
            _account = account ?? new TAccountADO();
            _dlgProcess = new DelegateProcess();
            _bugProcess = new BugTrackerProcess();

            com_priority.DisplayMember = "PriorityName";
            com_priority.ValueMember = "PriorityID";

            com_assignee.DisplayMember = "AccountName";
            com_assignee.ValueMember = "AccountID";

            _attachments = new List<FileInfo>();

            

            Task task = new Task(InitializeValues);
            task.Start();
        }
        void InitializeValues()
        {

            try
            {
                _dlgProcess.SetText(rtxt_description, "");

                _dlgProcess.SetText(lab_attachmentcount, "No Attachment");

                var priorities = _bugProcess.GetAllPriorities();
                if (priorities?.Count > 0) { _dlgProcess.AddComboBoxItems(com_priority, priorities.ToArray()); _dlgProcess.SetComboBoxIndex(com_priority, 0); }

                var coders = _bugProcess.GetAllCoders();
                if (coders?.Count > 0) { _dlgProcess.AddComboBoxItems(com_assignee, coders.ToArray()); _dlgProcess.SetComboBoxIndex(com_assignee, 0); }

                _dlgProcess.SetText(rtxt_comment, "");

                _dlgProcess.Execute(ts_bottom, () => ts_bottom_status.Text = "Ready");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void but_close_Click(object sender, EventArgs e)
        {
            if (_bugCount > 0)
                DialogResult = DialogResult.OK;
            else DialogResult = DialogResult.Ignore;
        }

        private void but_add_Click(object sender, EventArgs e)
        {

            try
            {
                string description = rtxt_description.Text;
                var priority = com_priority.SelectedItem as TPriorityADO;
                var assignee = com_assignee.SelectedItem as TAccountADO;
                string comment = rtxt_comment.Text;
                string version = txt_version.Text;

                TBugFullInfo bug = new TBugFullInfo();
                bug.Description = description;
                bug.PriorityID = priority.PriorityID;
                bug.AssignedAccountID = assignee.AccountID;
                bug.Attachments = _attachments.Select(ite => new TAttachmentADO() { FileData = File.ReadAllBytes(ite.FullName), FileExtension = ite.Extension, FileName = ite.Name }).ToList();
                bug.Comment = comment;
                bug.AddedAccountID = _account.AccountID;
                bug.SprintID = _sprintID;
                bug.TaskID = _taskID;
                bug.StatusID = 1;
                bug.Version = version;
                bug.ResolveVersion = "";

                _bugProcess.AddBugs(bug);
                _bugCount++;
                _dlgProcess.Execute(ts_bottom, () => ts_bottom_status.Text = string.Format("{0} Bug{1} Added", _bugCount, _bugCount <= 1 ? "" : "s"));

                rtxt_description.Text = "";
                com_priority.SelectedIndex =0;
                com_assignee.SelectedIndex = 0;
                rtxt_comment.Text = "";
                _attachments = new List<FileInfo>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void but_addattachment_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog ofd = new OpenFileDialog() { Title = "Add Attachment", Multiselect = true };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _attachments.AddRange(ofd.FileNames.Select(ite => new FileInfo(ite)));
                    _dlgProcess.SetText(lab_attachmentcount, string.Format("{0} Attachment{1} Added", _attachments.Count, _attachments.Count <= 1 ? "" : "s"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

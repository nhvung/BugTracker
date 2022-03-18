using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSBugTracker.ADO;
using VSBugTracker.Models;

namespace BugSearch
{
	public partial class BugStatisticF : Form
	{
		VSBugTracker.BugTrackerProcess __bugProcess;
		DelegateProcess _dlg;
		List<TSprintInfo> lstSprints = new List<TSprintInfo>();

		CheckBox _chkall_status, _chkall_priority, _chkall_rpversion, _chkall_rsversion;

		public BugStatisticF(VSBugTracker.BugTrackerProcess bugTrackerProcess)
		{
			InitializeComponent();
			__bugProcess = bugTrackerProcess;
			com_sprint.DisplayMember = "sprintname";
			com_task.DisplayMember = "Summary";
			_dlg = new DelegateProcess();

			com_sprint.SelectedIndexChanged += Com_sprint_SelectedIndexChanged;

			if (!SystemInformation.TerminalServerSession)
			{
				Type dgvType = dgv_priority.GetType();
				PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
				pi.SetValue(dgv_priority, true, null);

				dgvType = dgv_status.GetType();
				pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
				pi.SetValue(dgv_status, true, null);
			}

			_chkall_status = _dlg.AddDataGridViewCheckBoxAll(dgv_status, "col_sts_chk");
			_chkall_priority = _dlg.AddDataGridViewCheckBoxAll(dgv_priority, "col_pri_chk");
			_chkall_rpversion = _dlg.AddDataGridViewCheckBoxAll(dgv_reportedversion, "col_reportedversion_chk");
			_chkall_rsversion = _dlg.AddDataGridViewCheckBoxAll(dgv_resolvedversion, "col_resolvedversion_chk");

			Task.Run(LoadFilters);
		}

		void LoadFilters()
        {
            try
            {
				_dlg.ClearDataGridViewRows(dgv_priority);
				_dlg.Execute(_chkall_priority, () => _chkall_priority.Checked = true);
				_dlg.ClearDataGridViewRows(dgv_status);
				_dlg.Execute(_chkall_status, () => _chkall_status.Checked = true);
				_dlg.ClearDataGridViewRows(dgv_reportedversion);
				_dlg.Execute(_chkall_rpversion, () => _chkall_rpversion.Checked = true);
				_dlg.ClearDataGridViewRows(dgv_resolvedversion);
				_dlg.Execute(_chkall_rsversion, () => _chkall_rsversion.Checked = true);

				_dlg.AddDataGridViewRow(dgv_priority, true, 4, "Critical");
				_dlg.AddDataGridViewRow(dgv_priority, true, 2, "High");
				_dlg.AddDataGridViewRow(dgv_priority, true, 8, "Normal*");
				_dlg.AddDataGridViewRow(dgv_priority, true, 1, "Normal");

				var statuses = __bugProcess.GetAllStatuses();
				if (statuses?.Count > 0)
                {
					foreach(var status in statuses)
                    {
						_dlg.AddDataGridViewRow(dgv_status, true, status.StatusID, status.StatusName);
					}
                }

				var versions = __bugProcess.GetAllBugVersions();
				string[] rpVersions = versions.Select(ite => ite?.Version).Where(ite => !string.IsNullOrEmpty(ite))?.ToArray();
				string[] rsVersions = versions.Select(ite => ite?.ResolveVersion).Where(ite => !string.IsNullOrEmpty(ite))?.ToArray();

				_dlg.AddDataGridViewRow(dgv_reportedversion, true, "", "No Version");
				if(rpVersions?.Length > 0)
                {
					foreach(var version in rpVersions)
                    {
						_dlg.AddDataGridViewRow(dgv_reportedversion, true, version, version);
                    }
                }

				_dlg.AddDataGridViewRow(dgv_resolvedversion, true, "", "No Version");
				if (rsVersions?.Length > 0)
				{
					foreach (var version in rsVersions)
					{
						_dlg.AddDataGridViewRow(dgv_resolvedversion, true, version, version);
					}
				}
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

		private void Com_sprint_SelectedIndexChanged(object sender, EventArgs e)
		{
			int intSelectedIndex = com_sprint.SelectedIndex;
			com_task.Items.Clear();
			com_task.Items.Add("All Tasks");

			if (intSelectedIndex >= 0 && lstSprints.Count > intSelectedIndex)
			{
				com_task.Items.AddRange(lstSprints[intSelectedIndex].Tasks.ToArray());
				com_task.SelectedIndex = 0;
				com_task.DropDownWidth = DropDownWidth(com_task) > com_task.Width ? (int)(DropDownWidth(com_task) * 1.25) : DropDownWidth(com_task);
			}
		}

		private void but_view_Click(object sender, EventArgs e)
		{

			try
			{
				var priorities = _dlg.GetDataGridViewCheckedRows(dgv_priority, "col_pri_chk");
				var statuses = _dlg.GetDataGridViewCheckedRows(dgv_status, "col_sts_chk");
				var rpVersions = _dlg.GetDataGridViewCheckedRows(dgv_reportedversion, "col_reportedversion_chk");
				var rsVersions = _dlg.GetDataGridViewCheckedRows(dgv_resolvedversion, "col_resolvedversion_chk");
				int[] priIDs = priorities.Select(ite => Convert.ToInt32(ite.Cells["col_pri_id"].Value)).ToArray();
				int[] stsIDs = statuses.Select(ite => Convert.ToInt32(ite.Cells["col_sts_id"].Value)).ToArray();
				string[] rpVersionVals = rpVersions.Select(ite => ite.Cells["col_reportedversion_value"].Value.ToString()).ToArray();
				string[] rsVersionVals = rsVersions.Select(ite => ite.Cells["col_resolvedversion_value"].Value.ToString()).ToArray();
				if (rad_sprint.Checked)
				{
					var sprint = com_sprint.SelectedItem as VSBugTracker.Models.TSprintInfo;
					var task = com_task.SelectedItem as VSBugTracker.ADO.TTaskADO;
					if(task == null)
					{
						task = new VSBugTracker.ADO.TTaskADO();
						task.TaskID = -1;
					}
					new Task(() => View(sprint, task, stsIDs, priIDs, rpVersionVals, rsVersionVals)).Start();
				}
				else
				{
					DateTime beginTime = dtp_begintime.Value;
					DateTime endTime = dtp_totime.Value;
					new Task(() => View(beginTime, endTime, stsIDs, priIDs, rpVersionVals, rsVersionVals)).Start();
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		protected override void OnShown(EventArgs e)
		{

			try
			{
				var sprints = __bugProcess.GetAllSprints();
				if (sprints?.Count > 0)
				{
					com_sprint.Items.AddRange(sprints.OrderByDescending(ite=>ite.SprintID).ToArray());
					com_sprint.SelectedIndex = 0;

					com_task.Items.Clear();
					com_task.Items.Add("All Tasks");
					com_task.Items.AddRange(sprints[0].Tasks.ToArray());
					com_task.SelectedIndex = 0;
					com_task.DropDownWidth = DropDownWidth(com_task) > com_task.Width ? (int)(DropDownWidth(com_task) * 1.25) : DropDownWidth(com_task);

					lstSprints = sprints;
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		void View(TSprintInfo sprint, VSBugTracker.ADO.TTaskADO task, int[] statusIDs, int[] priorityIDs, string[] rpVersions, string[] rsVersions)
		{

			try
			{
				var bugs = __bugProcess.GetBugsForStatistic(sprint.SprintID, task.TaskID, statusIDs, priorityIDs, -1, rpVersions, rsVersions);
				View(bugs);

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		void View(DateTime beginTime, DateTime toTime, int[] statusIDs, int[] priorityIDs, string[] rpVersions, string[] rsVersions)
		{

			try
			{
				var bugs = __bugProcess.GetBugsForStatistic(beginTime, toTime, statusIDs, priorityIDs, rpVersions, rsVersions);
				View(bugs);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		void View(List<TBugFullInfo> bugs)
		{

			try
			{
				_dlg.ClearDataGridViewRows(dgv_detail);
				_dlg.ClearDataGridViewRows(dgv_summary);
				if (bugs?.Count > 0)
				{				

					var m_status = __bugProcess.GetAllStatuses().ToDictionary(ite => ite.StatusID, ite => ite.StatusName);
					var m_priotiry = __bugProcess.GetAllPriorities().ToDictionary(ite => ite.PriorityID, ite => ite.PriorityName);
					var m_account = __bugProcess.GetAllAccounts().ToDictionary(ite => ite.AccountID, ite => ite.AccountName);

					var m_bug = bugs.GroupBy(ite => ite.StatusID).ToDictionary(ite => m_status.ContainsKey(ite.Key) ? m_status[ite.Key] : "Unknown", ite => ite.Count());
					foreach (var kv in m_bug)
					{
						_dlg.AddDataGridViewRow(dgv_summary, kv.Key, kv.Value);
					}
					_dlg.AddDataGridViewRow(dgv_summary, "Total", m_bug.Sum(ite => ite.Value));

					foreach (var bug in bugs)
					{
						string reporter = m_account.ContainsKey(bug.AddedAccountID) ? m_account[bug.AddedAccountID] : "Administrator";
						string assignee = m_account.ContainsKey(bug.AssignedAccountID) ? m_account[bug.AssignedAccountID] : "Not Assigned";
						string status = m_status.ContainsKey(bug.StatusID) ? m_status[bug.StatusID] : "Unknown";
						string priority = m_priotiry.ContainsKey(bug.PriorityID) ? m_priotiry[bug.PriorityID] : "Unknown";
						
						DateTime createdDate;
						if (!DateTime.TryParseExact(bug.CreatedDate.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out createdDate)) createdDate = DateTime.MinValue;

						int rIdx = _dlg.AddDataGridViewRow(dgv_detail, bug.BugID, bug.Description, bug.Version, bug.ResolveVersion, status, priority, reporter, assignee, createdDate == DateTime.MinValue ? "-" : createdDate.ToString("dd/MM/yyyy"));
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		int DropDownWidth(ComboBox myCombo)
		{
			int maxWidth = 0;
			int temp = 0;
			Label lblText = new Label();

			foreach (var obj in myCombo.Items)
			{
				TTaskADO task = obj as TTaskADO;
				if (task == null)
					continue;
				lblText.Text = task.Summary;
				temp = lblText.PreferredWidth;
				if (temp > maxWidth)
				{
					maxWidth = temp;
				}
			}
			lblText.Dispose();
			
			return maxWidth >= myCombo.Width ? maxWidth : myCombo.Width;
		}
	}
}

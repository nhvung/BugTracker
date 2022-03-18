using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VSBugTracker;
using VSBugTracker.ADO;
using VSBugTracker.Models;

namespace BugSearch
{
    public partial class AlarmF : Form
    {
        BugTrackerProcess _bugProcess;
        TAccountADO _account;
        public AlarmF(TAccountADO account)
        {
            InitializeComponent();
            _bugProcess = new BugTrackerProcess();
            _account = account;

            rad_coder.Click += Rad_coder_Click;
            rad_tester.Click += Rad_tester_Click;

            chk_status_bydesign.Click += chk_bug_status_Click;
            chk_status_inprocess.Click += chk_bug_status_Click;
            chk_status_new.Click += chk_bug_status_Click;
            chk_status_notfix.Click += chk_bug_status_Click;
            chk_status_reopen.Click += chk_bug_status_Click;
            chk_status_resolved.Click += chk_bug_status_Click;
            InitializeValues();
        }

        void InitializeValues()
        {

            try
            {
                var notify = _bugProcess.GetNotify(_account.AccountID);
                if (notify != null)
                {
                    chk_status_new.Checked = (notify.BugStatus & 1) == 1;
                    chk_status_inprocess.Checked = (notify.BugStatus & 2) == 2;
                    chk_status_resolved.Checked = (notify.BugStatus & 4) == 4;
                    chk_status_reopen.Checked = (notify.BugStatus & 8) == 8;
                    chk_status_notfix.Checked = (notify.BugStatus & 32) == 32;
                    chk_status_bydesign.Checked = (notify.BugStatus & 64) == 64;

                    chk_monday.Checked = (notify.RepeatDays & TNotifyFullInfo.RepeatDayOfWeek.Monday) == TNotifyFullInfo.RepeatDayOfWeek.Monday;
                    chk_tuesday.Checked = (notify.RepeatDays & TNotifyFullInfo.RepeatDayOfWeek.Tuesday) == TNotifyFullInfo.RepeatDayOfWeek.Tuesday;
                    chk_wednesday.Checked = (notify.RepeatDays & TNotifyFullInfo.RepeatDayOfWeek.Wednesday) == TNotifyFullInfo.RepeatDayOfWeek.Wednesday;
                    chk_thursday.Checked = (notify.RepeatDays & TNotifyFullInfo.RepeatDayOfWeek.Thursday) == TNotifyFullInfo.RepeatDayOfWeek.Thursday;
                    chk_friday.Checked = (notify.RepeatDays & TNotifyFullInfo.RepeatDayOfWeek.Friday) == TNotifyFullInfo.RepeatDayOfWeek.Friday;
                    chk_saturday.Checked = (notify.RepeatDays & TNotifyFullInfo.RepeatDayOfWeek.Saturday) == TNotifyFullInfo.RepeatDayOfWeek.Saturday;
                    chk_sunday.Checked = (notify.RepeatDays & TNotifyFullInfo.RepeatDayOfWeek.Sunday) == TNotifyFullInfo.RepeatDayOfWeek.Sunday;

                    DateTime time;
                    if (!DateTime.TryParseExact(notify.RepeatTime.ToString("0#####"), "Hmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out time)) time = DateTime.Now;
                    dtp_time.Value = time;
                    txt_email.Text = notify.Email ?? "";
                    txt_skypeid.Text = notify.SkypeID ?? "";
                    rad_on.Checked = notify.Status == 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Rad_tester_Click(object sender, EventArgs e)
        {
            chk_status_new.Checked = false;

            chk_status_inprocess.Checked = false;

            chk_status_reopen.Checked = false;

            chk_status_resolved.Checked = true;

            chk_status_bydesign.Checked = true;

            chk_status_notfix.Checked = true;
        }

        private void Rad_coder_Click(object sender, EventArgs e)
        {
            chk_status_new.Checked = true;

            chk_status_inprocess.Checked = true;

            chk_status_reopen.Checked = true;

            chk_status_resolved.Checked = false;

            chk_status_bydesign.Checked = false;

            chk_status_notfix.Checked = false;
        }
        void chk_bug_status_Click(object sender, EventArgs e)
        {
            rad_other.Checked = true;
        }

        private void but_update_Click(object sender, EventArgs e)
        {

            try
            {
                TNotifyFullInfo notify = new TNotifyFullInfo() { RepeatDays = TNotifyFullInfo.RepeatDayOfWeek.None };
                notify.AccountID = _account.AccountID;
                notify.Email = txt_email.Text;
                notify.SkypeID = txt_skypeid.Text;
                notify.RepeatTime = int.Parse(dtp_time.Value.ToString("HHmmss"));
                if (chk_monday.Checked) notify.RepeatDays |= TNotifyFullInfo.RepeatDayOfWeek.Monday;
                if (chk_tuesday.Checked) notify.RepeatDays |= TNotifyFullInfo.RepeatDayOfWeek.Tuesday;
                if (chk_wednesday.Checked) notify.RepeatDays |= TNotifyFullInfo.RepeatDayOfWeek.Wednesday;
                if (chk_thursday.Checked) notify.RepeatDays |= TNotifyFullInfo.RepeatDayOfWeek.Thursday;
                if (chk_friday.Checked) notify.RepeatDays |= TNotifyFullInfo.RepeatDayOfWeek.Friday;
                if (chk_saturday.Checked) notify.RepeatDays |= TNotifyFullInfo.RepeatDayOfWeek.Saturday;
                if (chk_sunday.Checked) notify.RepeatDays |= TNotifyFullInfo.RepeatDayOfWeek.Sunday;
                notify.Status = (byte)(rad_on.Checked ? 1 : 0);
                notify.BugStatus = 0;
                if (chk_status_new.Checked) notify.BugStatus += 1;
                if (chk_status_inprocess.Checked) notify.BugStatus += 2;
                if (chk_status_resolved.Checked) notify.BugStatus += 4;
                if (chk_status_reopen.Checked) notify.BugStatus += 8;
                if (chk_status_notfix.Checked) notify.BugStatus += 32;
                if (chk_status_bydesign.Checked) notify.BugStatus += 64;

                _bugProcess.AddNotify(notify);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

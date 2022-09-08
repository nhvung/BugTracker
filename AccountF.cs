using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using VSBugTracker;
using VSBugTracker.ADO;

namespace BugSearch
{
    public partial class AccountF : Form
    {
        BugTrackerProcess _bugProcess;
        DelegateProcess _dlgProcess;
        CheckBox _chkall_accounts;
        TAccountADO _account;
        bool _canDelete;
        public AccountF(TAccountADO account)
        {
            InitializeComponent();
            _account = account;
            _bugProcess = new BugTrackerProcess();
            _dlgProcess = new DelegateProcess();
            _allRightButton = new ToolStripButton("All Rights", null, ts_right_allrights_Click, "ts_right_allrights") { Tag = 0, Name = "0", CheckOnClick = true };

            dgv_account.SelectionChanged += Dgv_account_SelectionChanged;
            _chkall_accounts = _dlgProcess.AddDataGridViewCheckBoxAll(dgv_account, "col_account_chk");
            sc_1.Panel2Collapsed = true;
            _canDelete = (_account.AccountRight & (int)AccountRight.DeleteAccount) == (int)AccountRight.DeleteAccount;
            if (!_canDelete)
            {
                but_deleteaccount.Visible = false;
            }

            Thread th = new Thread(InitializeValues);
            th.Start();
        }

        bool _editMode;
        private void Dgv_account_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv_account.SelectedRows.Count > 0 && _editMode)
                {
                    var row = dgv_account.SelectedRows[0];
                    txt_username.Text = row.Cells["col_account_username"].Value.ToString();
                    txt_fullname.Text = row.Cells["col_account_name"].Value.ToString();
                    txt_password.Text = FSEncode.FSSecurity.Decrypt(row.Cells["col_account_password"].Value.ToString());
                    int type = Convert.ToInt32(row.Cells["col_account_type"].Value);
                    if (type == 1) rad_accouttype_coder.Checked = true;
                    else if (type == 2) rad_accouttype_tester.Checked = true;
                    else if (type == 3) rad_accouttype_full.Checked = true;
                    else rad_accouttype_other.Checked = true;

                    int[] rights = new int[] { (int)AccountRight.AddAccount, (int)AccountRight.AddBug, (int)AccountRight.AddSprint,
                        (int)AccountRight.AddTask, (int)AccountRight.AssignBug, (int)AccountRight.ByDesign,(int)AccountRight.DeleteAccount,
                        (int)AccountRight.DeleteBug, (int)AccountRight.DeleteSprint,(int) AccountRight.DeleteTask,(int) AccountRight.NotFix, (int)AccountRight.Reopen,
                        (int)AccountRight.Resolve,(int) AccountRight.SetPriority, (int)AccountRight.Verify, (int)AccountRight.MoveBug,(int) AccountRight.AssignToMe, (int)AccountRight.Fixed, (int)AccountRight.PleaseWait };

                    int right = Convert.ToInt32(row.Cells["col_account_right"].Value);
                    rights = rights.Where(ite => (right & ite) == ite).ToArray();
                    foreach (ToolStripButton button in ts_right.Items)
                    {
                        if (rights.Contains(Convert.ToInt32(button.Tag))) button.Checked = true;
                        else button.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ToolStripButton _allRightButton;
        void InitializeValues()
        {
            try
            {
                _dlgProcess.Execute(ts_right, () => ts_right.Items.Clear());
                _dlgProcess.ClearDataGridViewRows(dgv_account);
                var rights = _bugProcess.GetAllRights();
                rights = rights.Where(ite => ite.RightID!=(int)AccountRight.AddAccount && ite.RightID != (int)AccountRight.DeleteAccount).ToList();
                _dlgProcess.Execute(ts_right, () => {
                    
                    ts_right.Items.Add(_allRightButton);                    
                    ToolStripButton[] buttons = rights.Select(ite => new ToolStripButton(ite.RightName, null, ts_right_item_Click, ite.RightID.ToString()) { Name = ite.RightID.ToString(), Tag = ite.RightID, CheckOnClick = true }).ToArray();
                    ts_right.Items.AddRange(buttons);
                });

                var accounts = _bugProcess.GetAllAccounts();
                foreach (var account in accounts)
                {
                    if (account.AccountType == 0 || account.AccountID == _account.AccountID) continue;                    
                    _dlgProcess.AddDataGridViewRow(dgv_account, false, account.AccountID, account.AccountLogin, account.AccountName, account.EncryptedPassword, account.AccountType, account.AccountRight);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ts_right_allrights_Click(object sender, EventArgs e)
        {
            try
            {
                rad_accouttype_other.Checked = true;
                foreach (ToolStripButton button in ts_right.Items)
                {
                    if (button.Name.Equals("ts_right_allrights", StringComparison.InvariantCultureIgnoreCase))
                    { }
                    else
                    {
                        button.Checked = _allRightButton.Checked;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ts_right_item_Click(object sender, EventArgs e)
        {
            try
            {
                rad_accouttype_other.Checked = true;
                _allRightButton.Checked = true;
                foreach (ToolStripButton button in ts_right.Items)
                {
                    if (button.Name.Equals("ts_right_allrights", StringComparison.InvariantCultureIgnoreCase))
                    { }
                    else
                    {
                        if (button.Checked)
                        {
                        }
                        else _allRightButton.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rad_accouttype_admin_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                _allRightButton.Checked = false;
                foreach (ToolStripButton button in ts_right.Items)
                {
                    button.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rad_accouttype_coder_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (ToolStripButton button in ts_right.Items)
                {
                    switch (button.Name)
                    {
                        case "16":
                        case "64":
                        case "1024":
                        case "2048":
                        case "4096":
                        case "65536":
                        case "131072":
                        case "262144":
                            button.Checked = true;
                            break;
                        default:
                            button.Checked = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rad_accouttype_tester_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (ToolStripButton button in ts_right.Items)
                {
                    switch (button.Name)
                    {
                        case "16":
                        case "64":
                        case "128":
                        case "256":
                        case "512":
                        case "32768":
                            button.Checked = true;
                            break;
                        default:
                            button.Checked = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void but_addaccount_Click(object sender, EventArgs e)
        {

            try
            {
                grp_right.Visible = true;
                grp_accountinfo.Visible = true;
                sc_1.Panel2Collapsed = false;
                txt_username.Text = "";
                txt_fullname.Text = "";
                txt_password.Text = "";
                rad_accouttype_other.Checked = true;
                foreach (ToolStripButton button in ts_right.Items)
                {
                    button.Checked = false;
                }
                but_execute.Text = "Add";
                _editMode = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void but_execute_Click(object sender, EventArgs e)
        {

            try
            {
                if (but_execute.Text == "Add")
                {
                    TAccountADO account = new TAccountADO();
                    if (txt_username.Text == "") return;

                    account.AccountLogin = txt_username.Text;
                    account.AccountName = txt_fullname.Text;
                    account.EncryptedPassword = FSEncode.FSSecurity.EncryptSHA512(string.Format("{0};{1}", txt_username.Text, txt_password.Text));
                    account.AccountType = rad_accouttype_coder.Checked ? 1 : rad_accouttype_tester.Checked ? 2 : rad_accouttype_full.Checked ? 3 : 4;
                    int right = 0;
                    foreach (ToolStripButton button in ts_right.Items)
                    {
                        if (button.Checked)
                        {
                            right += Convert.ToInt32(button.Tag);
                        }
                    }
                    account.AccountRight = right;
                    try
                    {
                        _bugProcess.AddAccount(account);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Thread th = new Thread(InitializeValues);
                    th.Start();
                }
                else if (but_execute.Text == "Update Info")
                {
                    if (MessageBox.Show("Do you want to update?", "Update Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var row = dgv_account.SelectedRows[0];
                        TAccountADO account = new TAccountADO();
                        account.AccountID = Convert.ToInt32(row.Cells["col_account_id"].Value);
                        account.AccountLogin = txt_username.Text;
                        account.AccountName = txt_fullname.Text;
                        if (!string.IsNullOrWhiteSpace(txt_password.Text))
                        {
                            account.EncryptedPassword = FSEncode.FSSecurity.EncryptSHA512(string.Format("{0};{1}", txt_username.Text, txt_password.Text));
                        }

                        account.AccountType = rad_accouttype_coder.Checked ? 1 : rad_accouttype_tester.Checked ? 2 : rad_accouttype_full.Checked ? 3 : 4;
                        int right = 0;
                        foreach (ToolStripButton button in ts_right.Items)
                        {
                            if (button.Checked)
                            {
                                right += Convert.ToInt32(button.Tag);
                            }
                        }
                        account.AccountRight = right;
                        try
                        {
                            _bugProcess.UpdateAccount(account);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        Thread th = new Thread(InitializeValues);
                        th.Start();
                    }
                        
                }
                else if (but_execute.Text == "Update Right")
                {
                    var rows = _dlgProcess.GetDataGridViewCheckedRows(dgv_account, "col_account_chk");
                    if(rows.Count == 0)
                    {
                        rows = _dlgProcess.GetDataGridViewSelectedRows(dgv_account);
                    }
                    if(rows.Count > 0)
                    {
                        if (MessageBox.Show("Do you want to update?", "Update Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            int type = rad_accouttype_coder.Checked ? 1 : rad_accouttype_tester.Checked ? 2 : rad_accouttype_full.Checked ? 3 : 4;

                            int right = 0;
                            foreach (ToolStripButton button in ts_right.Items)
                            {
                                if (button.Checked)
                                {
                                    right += Convert.ToInt32(button.Tag);
                                }
                            }

                            int[] accountIds = rows.Select(ite => Convert.ToInt32(ite.Cells["col_account_id"].Value)).ToArray();
                            _bugProcess.AssignRight(accountIds, type, right);

                            Thread th = new Thread(InitializeValues);
                            th.Start();
                        }
                            
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sc_1.Panel2Collapsed = true;
            }
        }

        private void but_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_account.SelectedRows.Count > 0)
                {
                    grp_right.Visible = true;
                    grp_accountinfo.Visible = true;
                    sc_1.Panel2Collapsed = false;
                    var row = dgv_account.SelectedRows[0];
                    //txt_username.Text = row.Cells["col_account_username"].Value.ToString();
                    //txt_fullname.Text = row.Cells["col_account_name"].Value.ToString();
                    txt_password.Text = FSEncode.FSSecurity.Decrypt(row.Cells["col_account_password"].Value.ToString());
                    int type = Convert.ToInt32(row.Cells["col_account_type"].Value);
                    if (type == 1) rad_accouttype_coder.Checked = true;
                    else if (type == 2) rad_accouttype_tester.Checked = true;
                    else if (type == 3) rad_accouttype_full.Checked = true;
                    else rad_accouttype_other.Checked = true;

                    int[] rights = new int[] { (int)AccountRight.AddAccount, (int)AccountRight.AddBug, (int)AccountRight.AddSprint,
                        (int)AccountRight.AddTask, (int)AccountRight.AssignBug, (int)AccountRight.ByDesign,(int)AccountRight.DeleteAccount,
                        (int)AccountRight.DeleteBug, (int)AccountRight.DeleteSprint,(int) AccountRight.DeleteTask,(int) AccountRight.NotFix, (int)AccountRight.Reopen,
                        (int)AccountRight.Resolve,(int) AccountRight.SetPriority, (int)AccountRight.Verify, (int)AccountRight.MoveBug,(int) AccountRight.AssignToMe, (int)AccountRight.Fixed, (int)AccountRight.PleaseWait };

                    int right = Convert.ToInt32(row.Cells["col_account_right"].Value);
                    rights = rights.Where(ite => (right & ite) == ite).ToArray();
                    foreach (ToolStripButton button in ts_right.Items)
                    {
                        if (rights.Contains(Convert.ToInt32(button.Tag))) button.Checked = true;
                        else button.Checked = false;
                    }
                    but_execute.Text = "Update Info";
                    _editMode = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void but_close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            sc_1.Panel2Collapsed = true;
        }

        private void but_deleteaccount_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = _dlgProcess.GetDataGridViewCheckedRows(dgv_account, "col_account_chk");
                if (rows.Count == 0) return;
                if (MessageBox.Show("Are you sure?", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int[] accountIDs = rows.Select(ite => Convert.ToInt32(ite.Cells["col_account_id"].Value)).ToArray();
                    _bugProcess.DeleteAccounts(accountIDs);
                    Thread th = new Thread(InitializeValues);
                    th.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void but_assignright_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_account.SelectedRows.Count > 0)
                {
                    var row = dgv_account.SelectedRows[0];

                    int type = Convert.ToInt32(row.Cells["col_account_type"].Value);
                    if (type == 1) rad_accouttype_coder.Checked = true;
                    else if (type == 2) rad_accouttype_tester.Checked = true;
                    else if (type == 3) rad_accouttype_full.Checked = true;
                    else rad_accouttype_other.Checked = true;

                    int[] rights = new int[] { (int)AccountRight.AddAccount, (int)AccountRight.AddBug, (int)AccountRight.AddSprint,
                        (int)AccountRight.AddTask, (int)AccountRight.AssignBug, (int)AccountRight.ByDesign,(int)AccountRight.DeleteAccount,
                        (int)AccountRight.DeleteBug, (int)AccountRight.DeleteSprint,(int) AccountRight.DeleteTask,(int) AccountRight.NotFix, (int)AccountRight.Reopen,
                        (int)AccountRight.Resolve,(int) AccountRight.SetPriority, (int)AccountRight.Verify, (int)AccountRight.MoveBug,(int) AccountRight.AssignToMe, (int)AccountRight.Fixed, (int)AccountRight.PleaseWait };

                    int right = Convert.ToInt32(row.Cells["col_account_right"].Value);
                    rights = rights.Where(ite => (right & ite) == ite).ToArray();
                    foreach (ToolStripButton button in ts_right.Items)
                    {
                        if (rights.Contains(Convert.ToInt32(button.Tag))) button.Checked = true;
                        else button.Checked = false;
                    }

                    grp_right.Visible = true;
                    grp_accountinfo.Visible = false;
                    sc_1.Panel2Collapsed = false;
                    but_execute.Text = "Update Right";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

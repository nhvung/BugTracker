using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VSBugTracker.ADO;

namespace BugSearch
{
    public partial class LogInF : Form
    {
        public TAccountADO Account { get; set; }

        public LogInF()
        {
            InitializeComponent();

            FileInfo rememberFile = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "login.txt");
            if (rememberFile.Exists)
            {
                StreamReader reader = rememberFile.OpenText();
                string line = null;
                if ((line = reader.ReadLine()) != null) txt_username.Text = line;
                if ((line = reader.ReadLine()) != null) txt_password.Text = FSEncode.FSSecurity.Decrypt(line);
                reader.Close();
            }
        }

        private void but_login_Click(object sender, EventArgs e)
        {
            try
            {
                VSBugTracker.BugTrackerProcess bugProcess = new VSBugTracker.BugTrackerProcess();
                string username = txt_username.Text;
                string password = FSEncode.FSSecurity.Encrypt(txt_password.Text);
                string password512 = FSEncode.FSSecurity.EncryptSHA512(username + ";" + txt_password.Text);

                FileInfo rememberFile = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "login.txt");
                StreamWriter writer = new StreamWriter(rememberFile.FullName);
                writer.WriteLine(username);
                writer.WriteLine(password);
                writer.Close();

                Account = bugProcess.Login(username, password512);
                if (Account != null) DialogResult = DialogResult.OK;
                else DialogResult = DialogResult.Ignore;
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

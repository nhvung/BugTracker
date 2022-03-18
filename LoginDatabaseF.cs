using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BugSearch
{
    public partial class LoginDatabaseF : Form
    {
        DelegateProcess dlgProcess;
        public string BugDatabase { get; private set; }
        public LoginDatabaseF()
        {
            InitializeComponent();
            dlgProcess = new DelegateProcess();
            List<string> drivers = GetSystemDriverList();
            com_driver.Items.AddRange(drivers.OrderBy(ite => ite).ToArray());
            FileInfo rememberFile = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "bugtracker_auth.txt");
            try
            {
                if (rememberFile.Exists)
                {
                    StreamReader reader = new StreamReader(rememberFile.FullName);
                    string line = null;
                    if ((line = reader.ReadLine()) != null) com_driver.Text = line;
                    if ((line = reader.ReadLine()) != null) txt_server.Text = line;
                    if ((line = reader.ReadLine()) != null) txt_username.Text = line;
                    if ((line = reader.ReadLine()) != null) txt_password.Text = line;
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void but_close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            string driver = com_driver.Text;
            string server = txt_server.Text;
            string username = txt_username.Text;
            string password = txt_password.Text;
            string database = com_database.Text;
            VSBugTracker.GlobalVariables.Init(server, username, password, database, driver);
            BugDatabase = database + "@" + server;
            DialogResult = DialogResult.OK;
        }

        List<string> GetSystemDriverList()
        {
            List<string> names = new List<string>();            
            Microsoft.Win32.RegistryKey reg = (Microsoft.Win32.Registry.LocalMachine).OpenSubKey("Software");
            if (reg != null)
            {
                reg = reg.OpenSubKey("ODBC");
                if (reg != null)
                {
                    reg = reg.OpenSubKey("ODBCINST.INI");
                    if (reg != null)
                    {

                        reg = reg.OpenSubKey("ODBC Drivers");
                        if (reg != null)
                        {
                            foreach (string sName in reg.GetValueNames())
                            {
                                names.Add(sName);
                            }
                        }
                        try
                        {
                            reg.Close();
                        }
                        catch { }
                    }
                }
            }

            return names;
        }

        void but_refresh_Click(object sender, EventArgs e)
        {
            try
            {
                dlgProcess.SetEnabled(but_ok, false);
                string driver = com_driver.Text;
                string server = txt_server.Text;
                string username = txt_username.Text;
                string password = txt_password.Text;

                FileInfo rememberFile = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "bugtracker_auth.txt");
                StreamWriter writer = new StreamWriter(rememberFile.FullName);
                writer.WriteLine(driver);
                writer.WriteLine(server);
                writer.WriteLine(username);
                writer.WriteLine(password);
                writer.Close();

                Thread th = new Thread(ite => ConnectServer(driver, server, username, password));
                th.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void ConnectServer(string driver, string server, string username, string password)
        {
            try
            {
                dlgProcess.ClearComboBoxItems(com_database);
                string connectionString = string.Format("driver={0}; server={1}; uid={2}; password={3};", driver, server, username, password);
                OdbcConnection connection = new OdbcConnection(connectionString);
                connection.Open();
                try
                {
                    OdbcCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "show databases;";
                    OdbcDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string database = reader[0].ToString();
                        dlgProcess.AddComboBoxItem(com_database, database);
                    }
                    reader.Close();
                    cmd.Dispose();

                    dlgProcess.Execute(com_database, () => { if (com_database.Items.Count > 0) com_database.SelectedIndex = 0; });
                    dlgProcess.SetEnabled(but_ok, true);
                }
                catch
                {

                }
                finally
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

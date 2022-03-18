using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugSearch
{
    public partial class AddTextF : Form
    {
        public string InputText { get; private set; }
        public AddTextF()
        {
            InitializeComponent();
        }

        public AddTextF(string labelName, string text)
        {
            InitializeComponent();
            txt_text.Text = text;
            lab_name.Text = labelName;
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            try
            {
                InputText = txt_text.Text;
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

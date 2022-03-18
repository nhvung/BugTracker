using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VSBugTracker;

namespace BugSearch
{
    public partial class PictureViewF : Form
    {
        BugTrackerProcess _bugProcess;
        public PictureViewF(int attachmentID)
        {
            InitializeComponent();
            FormClosed += PictureViewF_FormClosed;
            _bugProcess = new BugTrackerProcess();
            try
            {
                var att = _bugProcess.GetAttachment(attachmentID);
                pictureBox1.Image = Image.FromStream(new MemoryStream(att.FileData));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PictureViewF_FormClosed(object sender, FormClosedEventArgs e)
        {
            pictureBox1.Dispose();
        }
    }
}

namespace BugSearch
{
    partial class AlarmF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_sunday = new System.Windows.Forms.CheckBox();
            this.chk_saturday = new System.Windows.Forms.CheckBox();
            this.chk_friday = new System.Windows.Forms.CheckBox();
            this.chk_thursday = new System.Windows.Forms.CheckBox();
            this.chk_wednesday = new System.Windows.Forms.CheckBox();
            this.chk_tuesday = new System.Windows.Forms.CheckBox();
            this.chk_monday = new System.Windows.Forms.CheckBox();
            this.dtp_time = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.but_update = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rad_off = new System.Windows.Forms.RadioButton();
            this.rad_on = new System.Windows.Forms.RadioButton();
            this.but_cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_skypeid = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rad_other = new System.Windows.Forms.RadioButton();
            this.rad_tester = new System.Windows.Forms.RadioButton();
            this.rad_coder = new System.Windows.Forms.RadioButton();
            this.chk_status_bydesign = new System.Windows.Forms.CheckBox();
            this.chk_status_notfix = new System.Windows.Forms.CheckBox();
            this.chk_status_reopen = new System.Windows.Forms.CheckBox();
            this.chk_status_resolved = new System.Windows.Forms.CheckBox();
            this.chk_status_inprocess = new System.Windows.Forms.CheckBox();
            this.chk_status_new = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 40);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "ALARM";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dtp_time);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(230, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 212);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Schedule";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chk_sunday);
            this.groupBox2.Controls.Add(this.chk_saturday);
            this.groupBox2.Controls.Add(this.chk_friday);
            this.groupBox2.Controls.Add(this.chk_thursday);
            this.groupBox2.Controls.Add(this.chk_wednesday);
            this.groupBox2.Controls.Add(this.chk_tuesday);
            this.groupBox2.Controls.Add(this.chk_monday);
            this.groupBox2.Location = new System.Drawing.Point(12, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 138);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Repeat";
            // 
            // chk_sunday
            // 
            this.chk_sunday.AutoSize = true;
            this.chk_sunday.Location = new System.Drawing.Point(21, 108);
            this.chk_sunday.Name = "chk_sunday";
            this.chk_sunday.Size = new System.Drawing.Size(67, 19);
            this.chk_sunday.TabIndex = 6;
            this.chk_sunday.Text = "Sunday";
            this.chk_sunday.UseVisualStyleBackColor = true;
            // 
            // chk_saturday
            // 
            this.chk_saturday.AutoSize = true;
            this.chk_saturday.Location = new System.Drawing.Point(119, 83);
            this.chk_saturday.Name = "chk_saturday";
            this.chk_saturday.Size = new System.Drawing.Size(74, 19);
            this.chk_saturday.TabIndex = 5;
            this.chk_saturday.Text = "Saturday";
            this.chk_saturday.UseVisualStyleBackColor = true;
            // 
            // chk_friday
            // 
            this.chk_friday.AutoSize = true;
            this.chk_friday.Location = new System.Drawing.Point(22, 83);
            this.chk_friday.Name = "chk_friday";
            this.chk_friday.Size = new System.Drawing.Size(59, 19);
            this.chk_friday.TabIndex = 4;
            this.chk_friday.Text = "Friday";
            this.chk_friday.UseVisualStyleBackColor = true;
            // 
            // chk_thursday
            // 
            this.chk_thursday.AutoSize = true;
            this.chk_thursday.Location = new System.Drawing.Point(119, 58);
            this.chk_thursday.Name = "chk_thursday";
            this.chk_thursday.Size = new System.Drawing.Size(77, 19);
            this.chk_thursday.TabIndex = 3;
            this.chk_thursday.Text = "Thursday";
            this.chk_thursday.UseVisualStyleBackColor = true;
            // 
            // chk_wednesday
            // 
            this.chk_wednesday.AutoSize = true;
            this.chk_wednesday.Location = new System.Drawing.Point(22, 58);
            this.chk_wednesday.Name = "chk_wednesday";
            this.chk_wednesday.Size = new System.Drawing.Size(91, 19);
            this.chk_wednesday.TabIndex = 2;
            this.chk_wednesday.Text = "Wednesday";
            this.chk_wednesday.UseVisualStyleBackColor = true;
            // 
            // chk_tuesday
            // 
            this.chk_tuesday.AutoSize = true;
            this.chk_tuesday.Location = new System.Drawing.Point(119, 33);
            this.chk_tuesday.Name = "chk_tuesday";
            this.chk_tuesday.Size = new System.Drawing.Size(73, 19);
            this.chk_tuesday.TabIndex = 1;
            this.chk_tuesday.Text = "Tuesday";
            this.chk_tuesday.UseVisualStyleBackColor = true;
            // 
            // chk_monday
            // 
            this.chk_monday.AutoSize = true;
            this.chk_monday.Location = new System.Drawing.Point(22, 33);
            this.chk_monday.Name = "chk_monday";
            this.chk_monday.Size = new System.Drawing.Size(68, 19);
            this.chk_monday.TabIndex = 0;
            this.chk_monday.Text = "Monday";
            this.chk_monday.UseVisualStyleBackColor = true;
            // 
            // dtp_time
            // 
            this.dtp_time.CustomFormat = "hh:mm tt";
            this.dtp_time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_time.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtp_time.Location = new System.Drawing.Point(76, 26);
            this.dtp_time.Name = "dtp_time";
            this.dtp_time.ShowUpDown = true;
            this.dtp_time.Size = new System.Drawing.Size(149, 21);
            this.dtp_time.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time:";
            // 
            // but_update
            // 
            this.but_update.Location = new System.Drawing.Point(134, 455);
            this.but_update.Name = "but_update";
            this.but_update.Size = new System.Drawing.Size(80, 25);
            this.but_update.TabIndex = 2;
            this.but_update.Text = "Update";
            this.but_update.UseVisualStyleBackColor = true;
            this.but_update.Click += new System.EventHandler(this.but_update_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rad_off);
            this.groupBox3.Controls.Add(this.rad_on);
            this.groupBox3.Location = new System.Drawing.Point(12, 372);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(454, 57);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // rad_off
            // 
            this.rad_off.AutoSize = true;
            this.rad_off.Checked = true;
            this.rad_off.Location = new System.Drawing.Point(344, 23);
            this.rad_off.Name = "rad_off";
            this.rad_off.Size = new System.Drawing.Size(40, 19);
            this.rad_off.TabIndex = 1;
            this.rad_off.TabStop = true;
            this.rad_off.Text = "Off";
            this.rad_off.UseVisualStyleBackColor = true;
            // 
            // rad_on
            // 
            this.rad_on.AutoSize = true;
            this.rad_on.Location = new System.Drawing.Point(78, 23);
            this.rad_on.Name = "rad_on";
            this.rad_on.Size = new System.Drawing.Size(41, 19);
            this.rad_on.TabIndex = 0;
            this.rad_on.Text = "On";
            this.rad_on.UseVisualStyleBackColor = true;
            // 
            // but_cancel
            // 
            this.but_cancel.Location = new System.Drawing.Point(242, 455);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(80, 25);
            this.but_cancel.TabIndex = 3;
            this.but_cancel.Text = "Cancel";
            this.but_cancel.UseVisualStyleBackColor = true;
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Skype ID:";
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(78, 28);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(348, 21);
            this.txt_email.TabIndex = 6;
            // 
            // txt_skypeid
            // 
            this.txt_skypeid.Location = new System.Drawing.Point(78, 55);
            this.txt_skypeid.Name = "txt_skypeid";
            this.txt_skypeid.Size = new System.Drawing.Size(348, 21);
            this.txt_skypeid.TabIndex = 7;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rad_other);
            this.groupBox4.Controls.Add(this.rad_tester);
            this.groupBox4.Controls.Add(this.rad_coder);
            this.groupBox4.Controls.Add(this.chk_status_bydesign);
            this.groupBox4.Controls.Add(this.chk_status_notfix);
            this.groupBox4.Controls.Add(this.chk_status_reopen);
            this.groupBox4.Controls.Add(this.chk_status_resolved);
            this.groupBox4.Controls.Add(this.chk_status_inprocess);
            this.groupBox4.Controls.Add(this.chk_status_new);
            this.groupBox4.Location = new System.Drawing.Point(12, 46);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(212, 212);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bug Status";
            // 
            // rad_other
            // 
            this.rad_other.AutoSize = true;
            this.rad_other.Checked = true;
            this.rad_other.Location = new System.Drawing.Point(147, 29);
            this.rad_other.Name = "rad_other";
            this.rad_other.Size = new System.Drawing.Size(55, 19);
            this.rad_other.TabIndex = 8;
            this.rad_other.TabStop = true;
            this.rad_other.Text = "Other";
            this.rad_other.UseVisualStyleBackColor = true;
            // 
            // rad_tester
            // 
            this.rad_tester.AutoSize = true;
            this.rad_tester.Location = new System.Drawing.Point(82, 29);
            this.rad_tester.Name = "rad_tester";
            this.rad_tester.Size = new System.Drawing.Size(59, 19);
            this.rad_tester.TabIndex = 7;
            this.rad_tester.Text = "Tester";
            this.rad_tester.UseVisualStyleBackColor = true;
            // 
            // rad_coder
            // 
            this.rad_coder.AutoSize = true;
            this.rad_coder.Location = new System.Drawing.Point(17, 29);
            this.rad_coder.Name = "rad_coder";
            this.rad_coder.Size = new System.Drawing.Size(59, 19);
            this.rad_coder.TabIndex = 6;
            this.rad_coder.Text = "Coder";
            this.rad_coder.UseVisualStyleBackColor = true;
            // 
            // chk_status_bydesign
            // 
            this.chk_status_bydesign.AutoSize = true;
            this.chk_status_bydesign.Location = new System.Drawing.Point(93, 146);
            this.chk_status_bydesign.Name = "chk_status_bydesign";
            this.chk_status_bydesign.Size = new System.Drawing.Size(82, 19);
            this.chk_status_bydesign.TabIndex = 5;
            this.chk_status_bydesign.Text = "By Design";
            this.chk_status_bydesign.UseVisualStyleBackColor = true;
            // 
            // chk_status_notfix
            // 
            this.chk_status_notfix.AutoSize = true;
            this.chk_status_notfix.Location = new System.Drawing.Point(17, 146);
            this.chk_status_notfix.Name = "chk_status_notfix";
            this.chk_status_notfix.Size = new System.Drawing.Size(63, 19);
            this.chk_status_notfix.TabIndex = 4;
            this.chk_status_notfix.Text = "Not Fix";
            this.chk_status_notfix.UseVisualStyleBackColor = true;
            // 
            // chk_status_reopen
            // 
            this.chk_status_reopen.AutoSize = true;
            this.chk_status_reopen.Location = new System.Drawing.Point(17, 121);
            this.chk_status_reopen.Name = "chk_status_reopen";
            this.chk_status_reopen.Size = new System.Drawing.Size(70, 19);
            this.chk_status_reopen.TabIndex = 3;
            this.chk_status_reopen.Text = "Reopen";
            this.chk_status_reopen.UseVisualStyleBackColor = true;
            // 
            // chk_status_resolved
            // 
            this.chk_status_resolved.AutoSize = true;
            this.chk_status_resolved.Location = new System.Drawing.Point(93, 121);
            this.chk_status_resolved.Name = "chk_status_resolved";
            this.chk_status_resolved.Size = new System.Drawing.Size(78, 19);
            this.chk_status_resolved.TabIndex = 2;
            this.chk_status_resolved.Text = "Resolved";
            this.chk_status_resolved.UseVisualStyleBackColor = true;
            // 
            // chk_status_inprocess
            // 
            this.chk_status_inprocess.AutoSize = true;
            this.chk_status_inprocess.Location = new System.Drawing.Point(93, 96);
            this.chk_status_inprocess.Name = "chk_status_inprocess";
            this.chk_status_inprocess.Size = new System.Drawing.Size(85, 19);
            this.chk_status_inprocess.TabIndex = 1;
            this.chk_status_inprocess.Text = "In Process";
            this.chk_status_inprocess.UseVisualStyleBackColor = true;
            // 
            // chk_status_new
            // 
            this.chk_status_new.AutoSize = true;
            this.chk_status_new.Location = new System.Drawing.Point(17, 96);
            this.chk_status_new.Name = "chk_status_new";
            this.chk_status_new.Size = new System.Drawing.Size(51, 19);
            this.chk_status_new.TabIndex = 0;
            this.chk_status_new.Text = "New";
            this.chk_status_new.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txt_skypeid);
            this.groupBox5.Controls.Add(this.txt_email);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Location = new System.Drawing.Point(12, 264);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(454, 102);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Notify Information";
            // 
            // AlarmF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 494);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.but_update);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AlarmF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ALARM";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rad_off;
        private System.Windows.Forms.RadioButton rad_on;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chk_sunday;
        private System.Windows.Forms.CheckBox chk_saturday;
        private System.Windows.Forms.CheckBox chk_friday;
        private System.Windows.Forms.CheckBox chk_thursday;
        private System.Windows.Forms.CheckBox chk_wednesday;
        private System.Windows.Forms.CheckBox chk_tuesday;
        private System.Windows.Forms.CheckBox chk_monday;
        private System.Windows.Forms.DateTimePicker dtp_time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_update;
        private System.Windows.Forms.Button but_cancel;
        private System.Windows.Forms.TextBox txt_skypeid;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rad_other;
        private System.Windows.Forms.RadioButton rad_tester;
        private System.Windows.Forms.RadioButton rad_coder;
        private System.Windows.Forms.CheckBox chk_status_bydesign;
        private System.Windows.Forms.CheckBox chk_status_notfix;
        private System.Windows.Forms.CheckBox chk_status_reopen;
        private System.Windows.Forms.CheckBox chk_status_resolved;
        private System.Windows.Forms.CheckBox chk_status_inprocess;
        private System.Windows.Forms.CheckBox chk_status_new;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}
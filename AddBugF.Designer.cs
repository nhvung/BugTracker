namespace BugSearch
{
    partial class AddBugF
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
            this.label6 = new System.Windows.Forms.Label();
            this.ts_bottom = new System.Windows.Forms.ToolStrip();
            this.ts_bottom_status = new System.Windows.Forms.ToolStripLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rtxt_description = new System.Windows.Forms.RichTextBox();
            this.but_addattachment = new System.Windows.Forms.Button();
            this.com_priority = new System.Windows.Forms.ComboBox();
            this.com_assignee = new System.Windows.Forms.ComboBox();
            this.rtxt_comment = new System.Windows.Forms.RichTextBox();
            this.lab_attachmentcount = new System.Windows.Forms.Label();
            this.but_close = new System.Windows.Forms.Button();
            this.but_add = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_version = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.ts_bottom.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 40);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "ADD BUG";
            // 
            // ts_bottom
            // 
            this.ts_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ts_bottom.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_bottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_bottom_status});
            this.ts_bottom.Location = new System.Drawing.Point(0, 560);
            this.ts_bottom.Name = "ts_bottom";
            this.ts_bottom.Size = new System.Drawing.Size(659, 25);
            this.ts_bottom.TabIndex = 1;
            this.ts_bottom.Text = "toolStrip1";
            // 
            // ts_bottom_status
            // 
            this.ts_bottom_status.Name = "ts_bottom_status";
            this.ts_bottom_status.Size = new System.Drawing.Size(39, 22);
            this.ts_bottom_status.Text = "Status";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 520);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(654, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 520);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(5, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(649, 5);
            this.panel4.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(5, 555);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(649, 5);
            this.panel5.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 399F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.rtxt_description, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.but_addattachment, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.com_priority, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.com_assignee, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.rtxt_comment, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lab_attachmentcount, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txt_version, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 45);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.2411F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.7589F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(649, 510);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Attachments:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Priority:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Assignee:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Comment:";
            // 
            // rtxt_description
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.rtxt_description, 2);
            this.rtxt_description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_description.Location = new System.Drawing.Point(102, 3);
            this.rtxt_description.Name = "rtxt_description";
            this.rtxt_description.Size = new System.Drawing.Size(544, 221);
            this.rtxt_description.TabIndex = 6;
            this.rtxt_description.Text = "";
            // 
            // but_addattachment
            // 
            this.but_addattachment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_addattachment.Location = new System.Drawing.Point(102, 230);
            this.but_addattachment.Name = "but_addattachment";
            this.but_addattachment.Size = new System.Drawing.Size(77, 24);
            this.but_addattachment.TabIndex = 7;
            this.but_addattachment.Text = "Add...";
            this.but_addattachment.UseVisualStyleBackColor = true;
            this.but_addattachment.Click += new System.EventHandler(this.but_addattachment_Click);
            // 
            // com_priority
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.com_priority, 2);
            this.com_priority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.com_priority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_priority.FormattingEnabled = true;
            this.com_priority.Location = new System.Drawing.Point(102, 260);
            this.com_priority.Name = "com_priority";
            this.com_priority.Size = new System.Drawing.Size(544, 23);
            this.com_priority.TabIndex = 8;
            // 
            // com_assignee
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.com_assignee, 2);
            this.com_assignee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.com_assignee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_assignee.FormattingEnabled = true;
            this.com_assignee.Location = new System.Drawing.Point(102, 290);
            this.com_assignee.Name = "com_assignee";
            this.com_assignee.Size = new System.Drawing.Size(544, 23);
            this.com_assignee.TabIndex = 9;
            // 
            // rtxt_comment
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.rtxt_comment, 2);
            this.rtxt_comment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_comment.Location = new System.Drawing.Point(102, 320);
            this.rtxt_comment.Name = "rtxt_comment";
            this.rtxt_comment.Size = new System.Drawing.Size(544, 126);
            this.rtxt_comment.TabIndex = 10;
            this.rtxt_comment.Text = "";
            // 
            // lab_attachmentcount
            // 
            this.lab_attachmentcount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lab_attachmentcount.AutoSize = true;
            this.lab_attachmentcount.Location = new System.Drawing.Point(185, 234);
            this.lab_attachmentcount.Name = "lab_attachmentcount";
            this.lab_attachmentcount.Size = new System.Drawing.Size(87, 15);
            this.lab_attachmentcount.TabIndex = 12;
            this.lab_attachmentcount.Text = "No attachment";
            // 
            // but_close
            // 
            this.but_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.but_close.Location = new System.Drawing.Point(543, 0);
            this.but_close.Name = "but_close";
            this.but_close.Size = new System.Drawing.Size(100, 25);
            this.but_close.TabIndex = 0;
            this.but_close.Text = "Close";
            this.but_close.UseVisualStyleBackColor = true;
            this.but_close.Click += new System.EventHandler(this.but_close_Click);
            // 
            // but_add
            // 
            this.but_add.Dock = System.Windows.Forms.DockStyle.Right;
            this.but_add.Location = new System.Drawing.Point(443, 0);
            this.but_add.Name = "but_add";
            this.but_add.Size = new System.Drawing.Size(100, 25);
            this.but_add.TabIndex = 1;
            this.but_add.Text = "Add";
            this.but_add.UseVisualStyleBackColor = true;
            this.but_add.Click += new System.EventHandler(this.but_add_Click);
            // 
            // panel6
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel6, 3);
            this.panel6.Controls.Add(this.but_add);
            this.panel6.Controls.Add(this.but_close);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 482);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(643, 25);
            this.panel6.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 456);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Version:";
            // 
            // txt_version
            // 
            this.txt_version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txt_version, 2);
            this.txt_version.Location = new System.Drawing.Point(102, 453);
            this.txt_version.Name = "txt_version";
            this.txt_version.Size = new System.Drawing.Size(544, 21);
            this.txt_version.TabIndex = 14;
            // 
            // AddBugF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 585);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ts_bottom);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddBugF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD BUG";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ts_bottom.ResumeLayout(false);
            this.ts_bottom.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip ts_bottom;
        private System.Windows.Forms.ToolStripLabel ts_bottom_status;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtxt_description;
        private System.Windows.Forms.Button but_addattachment;
        private System.Windows.Forms.ComboBox com_priority;
        private System.Windows.Forms.ComboBox com_assignee;
        private System.Windows.Forms.Label lab_attachmentcount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtxt_comment;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button but_add;
        private System.Windows.Forms.Button but_close;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_version;
    }
}
namespace BugSearch
{
    partial class MainF
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainF));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menu_database = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_database_open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_database_login = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_database_relogin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_database_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_view = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_view_sprintandtask = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_account_changepassword = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_admintool = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_admintool_accountmanager = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_statistic = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ts_bottom = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ts_bottom_database = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.ts_bottom_user = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.ts_bottom_task = new System.Windows.Forms.ToolStripLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ts_top = new System.Windows.Forms.ToolStrip();
            this.panel3 = new System.Windows.Forms.Panel();
            this.sc_1 = new System.Windows.Forms.SplitContainer();
            this.grp_task = new System.Windows.Forms.GroupBox();
            this.tv_task = new System.Windows.Forms.TreeView();
            this.cms_task = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.il_task = new System.Windows.Forms.ImageList(this.components);
            this.ts_task = new System.Windows.Forms.ToolStrip();
            this.ts_task_addsprint = new System.Windows.Forms.ToolStripButton();
            this.panel_buglist = new System.Windows.Forms.Panel();
            this.menu.SuspendLayout();
            this.ts_bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_1)).BeginInit();
            this.sc_1.Panel1.SuspendLayout();
            this.sc_1.Panel2.SuspendLayout();
            this.sc_1.SuspendLayout();
            this.grp_task.SuspendLayout();
            this.ts_task.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_database,
            this.menu_view,
            this.accountToolStripMenuItem,
            this.menu_admintool,
            this.menu_statistic});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(1067, 24);
            this.menu.TabIndex = 0;
            // 
            // menu_database
            // 
            this.menu_database.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_database_open,
            this.toolStripSeparator1,
            this.menu_database_login,
            this.menu_database_relogin,
            this.toolStripSeparator2,
            this.menu_database_exit});
            this.menu_database.Name = "menu_database";
            this.menu_database.Size = new System.Drawing.Size(67, 20);
            this.menu_database.Text = "Database";
            // 
            // menu_database_open
            // 
            this.menu_database_open.Name = "menu_database_open";
            this.menu_database_open.Size = new System.Drawing.Size(180, 22);
            this.menu_database_open.Text = "Open...";
            this.menu_database_open.Click += new System.EventHandler(this.menu_database_open_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // menu_database_login
            // 
            this.menu_database_login.Name = "menu_database_login";
            this.menu_database_login.Size = new System.Drawing.Size(180, 22);
            this.menu_database_login.Text = "Login";
            this.menu_database_login.Click += new System.EventHandler(this.menu_database_login_Click);
            // 
            // menu_database_relogin
            // 
            this.menu_database_relogin.Name = "menu_database_relogin";
            this.menu_database_relogin.Size = new System.Drawing.Size(180, 22);
            this.menu_database_relogin.Text = "Relogin";
            this.menu_database_relogin.Click += new System.EventHandler(this.menu_database_relogin_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // menu_database_exit
            // 
            this.menu_database_exit.Name = "menu_database_exit";
            this.menu_database_exit.Size = new System.Drawing.Size(180, 22);
            this.menu_database_exit.Text = "Exit";
            this.menu_database_exit.Click += new System.EventHandler(this.menu_database_exit_Click);
            // 
            // menu_view
            // 
            this.menu_view.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_view_sprintandtask});
            this.menu_view.Name = "menu_view";
            this.menu_view.Size = new System.Drawing.Size(44, 20);
            this.menu_view.Text = "View";
            // 
            // menu_view_sprintandtask
            // 
            this.menu_view_sprintandtask.Checked = true;
            this.menu_view_sprintandtask.CheckOnClick = true;
            this.menu_view_sprintandtask.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menu_view_sprintandtask.Name = "menu_view_sprintandtask";
            this.menu_view_sprintandtask.Size = new System.Drawing.Size(148, 22);
            this.menu_view_sprintandtask.Text = "Sprints && Task";
            this.menu_view_sprintandtask.Click += new System.EventHandler(this.menu_view_sprintandtask_Click);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_account_changepassword});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // menu_account_changepassword
            // 
            this.menu_account_changepassword.Name = "menu_account_changepassword";
            this.menu_account_changepassword.Size = new System.Drawing.Size(168, 22);
            this.menu_account_changepassword.Text = "Change Password";
            this.menu_account_changepassword.Click += new System.EventHandler(this.menu_account_changepassword_Click);
            // 
            // menu_admintool
            // 
            this.menu_admintool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_admintool_accountmanager});
            this.menu_admintool.Name = "menu_admintool";
            this.menu_admintool.Size = new System.Drawing.Size(117, 20);
            this.menu_admintool.Text = "Administrator Tool";
            this.menu_admintool.Visible = false;
            // 
            // menu_admintool_accountmanager
            // 
            this.menu_admintool_accountmanager.Name = "menu_admintool_accountmanager";
            this.menu_admintool_accountmanager.Size = new System.Drawing.Size(169, 22);
            this.menu_admintool_accountmanager.Text = "Account Manager";
            this.menu_admintool_accountmanager.Click += new System.EventHandler(this.menu_admintool_accountmanager_Click);
            // 
            // menu_statistic
            // 
            this.menu_statistic.Name = "menu_statistic";
            this.menu_statistic.Size = new System.Drawing.Size(60, 20);
            this.menu_statistic.Text = "Statistic";
            this.menu_statistic.Click += new System.EventHandler(this.menu_statistic_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(6, 676);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1061, 24);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(6, 676);
            this.panel2.TabIndex = 2;
            // 
            // ts_bottom
            // 
            this.ts_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ts_bottom.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_bottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.ts_bottom_database,
            this.toolStripLabel2,
            this.ts_bottom_user,
            this.toolStripLabel3,
            this.ts_bottom_task});
            this.ts_bottom.Location = new System.Drawing.Point(6, 675);
            this.ts_bottom.Name = "ts_bottom";
            this.ts_bottom.Size = new System.Drawing.Size(1055, 25);
            this.ts_bottom.TabIndex = 3;
            this.ts_bottom.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(61, 22);
            this.toolStripLabel1.Text = "Database:";
            // 
            // ts_bottom_database
            // 
            this.ts_bottom_database.Name = "ts_bottom_database";
            this.ts_bottom_database.Size = new System.Drawing.Size(73, 22);
            this.ts_bottom_database.Text = "Not connect";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel2.Text = "User:";
            // 
            // ts_bottom_user
            // 
            this.ts_bottom_user.Name = "ts_bottom_user";
            this.ts_bottom_user.Size = new System.Drawing.Size(80, 22);
            this.ts_bottom_user.Text = "Not logged in";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(34, 22);
            this.toolStripLabel3.Text = "Task:";
            // 
            // ts_bottom_task
            // 
            this.ts_bottom_task.Name = "ts_bottom_task";
            this.ts_bottom_task.Size = new System.Drawing.Size(109, 22);
            this.ts_bottom_task.Text = "No Sprint - No Task";
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(6, 669);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1055, 6);
            this.panel4.TabIndex = 5;
            // 
            // ts_top
            // 
            this.ts_top.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_top.Location = new System.Drawing.Point(6, 24);
            this.ts_top.Name = "ts_top";
            this.ts_top.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ts_top.Size = new System.Drawing.Size(1055, 25);
            this.ts_top.TabIndex = 6;
            this.ts_top.Text = "toolStrip2";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(6, 49);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1055, 6);
            this.panel3.TabIndex = 7;
            // 
            // sc_1
            // 
            this.sc_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sc_1.Location = new System.Drawing.Point(6, 55);
            this.sc_1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.sc_1.Name = "sc_1";
            // 
            // sc_1.Panel1
            // 
            this.sc_1.Panel1.Controls.Add(this.grp_task);
            this.sc_1.Panel1.Controls.Add(this.ts_task);
            // 
            // sc_1.Panel2
            // 
            this.sc_1.Panel2.Controls.Add(this.panel_buglist);
            this.sc_1.Size = new System.Drawing.Size(1055, 614);
            this.sc_1.SplitterDistance = 304;
            this.sc_1.SplitterWidth = 5;
            this.sc_1.TabIndex = 8;
            // 
            // grp_task
            // 
            this.grp_task.Controls.Add(this.tv_task);
            this.grp_task.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_task.Location = new System.Drawing.Point(0, 25);
            this.grp_task.Name = "grp_task";
            this.grp_task.Size = new System.Drawing.Size(304, 589);
            this.grp_task.TabIndex = 10;
            this.grp_task.TabStop = false;
            this.grp_task.Text = "Sprints && Tasks";
            // 
            // tv_task
            // 
            this.tv_task.ContextMenuStrip = this.cms_task;
            this.tv_task.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_task.ImageIndex = 0;
            this.tv_task.ImageList = this.il_task;
            this.tv_task.Location = new System.Drawing.Point(3, 17);
            this.tv_task.Name = "tv_task";
            this.tv_task.SelectedImageIndex = 0;
            this.tv_task.ShowLines = false;
            this.tv_task.Size = new System.Drawing.Size(298, 569);
            this.tv_task.TabIndex = 0;
            // 
            // cms_task
            // 
            this.cms_task.Name = "cms_task";
            this.cms_task.Size = new System.Drawing.Size(61, 4);
            // 
            // il_task
            // 
            this.il_task.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il_task.ImageStream")));
            this.il_task.TransparentColor = System.Drawing.Color.Transparent;
            this.il_task.Images.SetKeyName(0, "story.png");
            this.il_task.Images.SetKeyName(1, "task.png");
            // 
            // ts_task
            // 
            this.ts_task.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_task.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_task_addsprint});
            this.ts_task.Location = new System.Drawing.Point(0, 0);
            this.ts_task.Name = "ts_task";
            this.ts_task.Size = new System.Drawing.Size(304, 25);
            this.ts_task.TabIndex = 1;
            this.ts_task.Text = "toolStrip1";
            // 
            // ts_task_addsprint
            // 
            this.ts_task_addsprint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_task_addsprint.Image = ((System.Drawing.Image)(resources.GetObject("ts_task_addsprint.Image")));
            this.ts_task_addsprint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_task_addsprint.Name = "ts_task_addsprint";
            this.ts_task_addsprint.Size = new System.Drawing.Size(67, 22);
            this.ts_task_addsprint.Text = "Add Sprint";
            this.ts_task_addsprint.Click += new System.EventHandler(this.ts_task_addsprint_Click);
            // 
            // panel_buglist
            // 
            this.panel_buglist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_buglist.Location = new System.Drawing.Point(0, 0);
            this.panel_buglist.Name = "panel_buglist";
            this.panel_buglist.Size = new System.Drawing.Size(746, 614);
            this.panel_buglist.TabIndex = 0;
            // 
            // MainF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 700);
            this.Controls.Add(this.sc_1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.ts_top);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.ts_bottom);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUGSEARCH";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ts_bottom.ResumeLayout(false);
            this.ts_bottom.PerformLayout();
            this.sc_1.Panel1.ResumeLayout(false);
            this.sc_1.Panel1.PerformLayout();
            this.sc_1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc_1)).EndInit();
            this.sc_1.ResumeLayout(false);
            this.grp_task.ResumeLayout(false);
            this.ts_task.ResumeLayout(false);
            this.ts_task.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip ts_bottom;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem menu_database;
        private System.Windows.Forms.ToolStrip ts_top;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer sc_1;
        private System.Windows.Forms.ToolStripMenuItem menu_database_open;
        private System.Windows.Forms.Panel panel_buglist;
        private System.Windows.Forms.ImageList il_task;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menu_database_login;
        private System.Windows.Forms.ToolStripMenuItem menu_database_relogin;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menu_database_exit;
        private System.Windows.Forms.ContextMenuStrip cms_task;
        private System.Windows.Forms.ToolStripMenuItem menu_view;
        private System.Windows.Forms.ToolStripMenuItem menu_view_sprintandtask;
        private System.Windows.Forms.ToolStrip ts_task;
        private System.Windows.Forms.ToolStripButton ts_task_addsprint;
        private System.Windows.Forms.GroupBox grp_task;
        private System.Windows.Forms.TreeView tv_task;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_account_changepassword;
        private System.Windows.Forms.ToolStripMenuItem menu_admintool;
        private System.Windows.Forms.ToolStripMenuItem menu_admintool_accountmanager;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel ts_bottom_database;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel ts_bottom_user;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel ts_bottom_task;
		private System.Windows.Forms.ToolStripMenuItem menu_statistic;
    }
}
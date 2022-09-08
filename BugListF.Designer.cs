namespace BugSearch
{
    partial class BugListF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BugListF));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ts_top = new System.Windows.Forms.ToolStrip();
            this.ts_top_newbug = new System.Windows.Forms.ToolStripButton();
            this.ts_top_refresh = new System.Windows.Forms.ToolStripSplitButton();
            this.ts_top_refresh_auto60s = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_top_refresh_auto30s = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_top_refresh_auto15s = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_top_filters = new System.Windows.Forms.ToolStripButton();
            this.ts_top_viewbugdetail = new System.Windows.Forms.ToolStripButton();
            this.ts_top_compactview = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ts_top_txt_bugids = new System.Windows.Forms.ToolStripTextBox();
            this.ts_top_but_searchbug = new System.Windows.Forms.ToolStripButton();
            this.sc_1 = new System.Windows.Forms.SplitContainer();
            this.grp_buglist = new System.Windows.Forms.GroupBox();
            this.panel_buglist = new System.Windows.Forms.Panel();
            this.ts_version = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.ts_version_com_reportversion = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.ts_version_com_resolveversion = new System.Windows.Forms.ToolStripComboBox();
            this.dgv_bug = new System.Windows.Forms.DataGridView();
            this.col_bug_chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_bug_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bug_prioritycolor = new System.Windows.Forms.DataGridViewImageColumn();
            this.col_bug_priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bug_cellstatus = new System.Windows.Forms.DataGridViewStatusColumn();
            this.col_bug_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bug_version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bug_resolveversion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bug_reporter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bug_assignee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bug_createddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cms_bug = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_bug_moveto = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_bug_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cms_bug_reopen = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_bug_setpriority = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_bug_verify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cms_bug_assigntome = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_bug_assignto = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_bug_fixed = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_bug_pleasewait = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_bug_resolve = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_bug_notfix = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_bug_bydesign = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_status = new System.Windows.Forms.ToolStrip();
            this.ts_status_allstatuses = new System.Windows.Forms.ToolStripButton();
            this.ts_priority = new System.Windows.Forms.ToolStrip();
            this.ts_priority_allpriorities = new System.Windows.Forms.ToolStripButton();
            this.ts_assignee = new System.Windows.Forms.ToolStrip();
            this.ts_assignee_allassignees = new System.Windows.Forms.ToolStripButton();
            this.ts_reporter = new System.Windows.Forms.ToolStrip();
            this.ts_reporter_allreporters = new System.Windows.Forms.ToolStripButton();
            this.grp_bugdetail = new System.Windows.Forms.GroupBox();
            this.tlp_buginfo = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxt_buginfo_description = new System.Windows.Forms.RichTextBox();
            this.rtxt_buginfo_comment = new System.Windows.Forms.RichTextBox();
            this.panel_attachment = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rtxt_version = new System.Windows.Forms.RichTextBox();
            this.rtxt_resolveversion = new System.Windows.Forms.RichTextBox();
            this.ts_buginfo = new System.Windows.Forms.ToolStrip();
            this.ts_buginfo_edit = new System.Windows.Forms.ToolStripButton();
            this.ts_buginfo_deleteallattachment = new System.Windows.Forms.ToolStripButton();
            this.ts_buginfo_addattachment = new System.Windows.Forms.ToolStripButton();
            this.cms_attachment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_attachment_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewStatusColumn1 = new System.Windows.Forms.DataGridViewStatusColumn();
            this.col_bug_status = new System.Windows.Forms.DataGridViewImageColumn();
            this.ts_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_1)).BeginInit();
            this.sc_1.Panel1.SuspendLayout();
            this.sc_1.Panel2.SuspendLayout();
            this.sc_1.SuspendLayout();
            this.grp_buglist.SuspendLayout();
            this.panel_buglist.SuspendLayout();
            this.ts_version.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bug)).BeginInit();
            this.cms_bug.SuspendLayout();
            this.ts_status.SuspendLayout();
            this.ts_priority.SuspendLayout();
            this.ts_assignee.SuspendLayout();
            this.ts_reporter.SuspendLayout();
            this.grp_bugdetail.SuspendLayout();
            this.tlp_buginfo.SuspendLayout();
            this.ts_buginfo.SuspendLayout();
            this.cms_attachment.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 643);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1296, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 643);
            this.panel2.TabIndex = 1;
            // 
            // ts_top
            // 
            this.ts_top.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ts_top.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_top.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_top_newbug,
            this.ts_top_refresh,
            this.ts_top_filters,
            this.ts_top_viewbugdetail,
            this.ts_top_compactview,
            this.toolStripLabel1,
            this.ts_top_txt_bugids,
            this.ts_top_but_searchbug});
            this.ts_top.Location = new System.Drawing.Point(5, 0);
            this.ts_top.Name = "ts_top";
            this.ts_top.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ts_top.Size = new System.Drawing.Size(1291, 25);
            this.ts_top.TabIndex = 2;
            this.ts_top.Text = "toolStrip1";
            // 
            // ts_top_newbug
            // 
            this.ts_top_newbug.Image = ((System.Drawing.Image)(resources.GetObject("ts_top_newbug.Image")));
            this.ts_top_newbug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_top_newbug.Name = "ts_top_newbug";
            this.ts_top_newbug.Size = new System.Drawing.Size(53, 22);
            this.ts_top_newbug.Text = "&New";
            this.ts_top_newbug.Click += new System.EventHandler(this.ts_top_newbug_Click);
            // 
            // ts_top_refresh
            // 
            this.ts_top_refresh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_top_refresh_auto60s,
            this.ts_top_refresh_auto30s,
            this.ts_top_refresh_auto15s});
            this.ts_top_refresh.Image = ((System.Drawing.Image)(resources.GetObject("ts_top_refresh.Image")));
            this.ts_top_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_top_refresh.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.ts_top_refresh.Name = "ts_top_refresh";
            this.ts_top_refresh.Size = new System.Drawing.Size(84, 22);
            this.ts_top_refresh.Text = "Refresh";
            this.ts_top_refresh.Click += new System.EventHandler(this.ts_top_refresh_Click);
            // 
            // ts_top_refresh_auto60s
            // 
            this.ts_top_refresh_auto60s.Name = "ts_top_refresh_auto60s";
            this.ts_top_refresh_auto60s.Size = new System.Drawing.Size(160, 22);
            this.ts_top_refresh_auto60s.Text = "Auto each 60s";
            this.ts_top_refresh_auto60s.Click += new System.EventHandler(this.ts_top_refresh_auto60s_Click);
            // 
            // ts_top_refresh_auto30s
            // 
            this.ts_top_refresh_auto30s.Name = "ts_top_refresh_auto30s";
            this.ts_top_refresh_auto30s.Size = new System.Drawing.Size(160, 22);
            this.ts_top_refresh_auto30s.Text = "Auto each 30s";
            this.ts_top_refresh_auto30s.Click += new System.EventHandler(this.ts_top_refresh_auto30s_Click);
            // 
            // ts_top_refresh_auto15s
            // 
            this.ts_top_refresh_auto15s.Name = "ts_top_refresh_auto15s";
            this.ts_top_refresh_auto15s.Size = new System.Drawing.Size(160, 22);
            this.ts_top_refresh_auto15s.Text = "Auto each 15s";
            this.ts_top_refresh_auto15s.Click += new System.EventHandler(this.autoEach15sToolStripMenuItem_Click);
            // 
            // ts_top_filters
            // 
            this.ts_top_filters.Checked = true;
            this.ts_top_filters.CheckOnClick = true;
            this.ts_top_filters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ts_top_filters.Image = ((System.Drawing.Image)(resources.GetObject("ts_top_filters.Image")));
            this.ts_top_filters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_top_filters.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.ts_top_filters.Name = "ts_top_filters";
            this.ts_top_filters.Size = new System.Drawing.Size(64, 22);
            this.ts_top_filters.Text = "Filters";
            this.ts_top_filters.Click += new System.EventHandler(this.ts_top_filters_Click);
            // 
            // ts_top_viewbugdetail
            // 
            this.ts_top_viewbugdetail.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ts_top_viewbugdetail.Checked = true;
            this.ts_top_viewbugdetail.CheckOnClick = true;
            this.ts_top_viewbugdetail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ts_top_viewbugdetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_top_viewbugdetail.Image = ((System.Drawing.Image)(resources.GetObject("ts_top_viewbugdetail.Image")));
            this.ts_top_viewbugdetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_top_viewbugdetail.Name = "ts_top_viewbugdetail";
            this.ts_top_viewbugdetail.Size = new System.Drawing.Size(72, 22);
            this.ts_top_viewbugdetail.Text = "Bug Detail";
            this.ts_top_viewbugdetail.Click += new System.EventHandler(this.ts_top_viewbugdetail_Click);
            // 
            // ts_top_compactview
            // 
            this.ts_top_compactview.CheckOnClick = true;
            this.ts_top_compactview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_top_compactview.Image = ((System.Drawing.Image)(resources.GetObject("ts_top_compactview.Image")));
            this.ts_top_compactview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_top_compactview.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.ts_top_compactview.Name = "ts_top_compactview";
            this.ts_top_compactview.Size = new System.Drawing.Size(96, 22);
            this.ts_top_compactview.Text = "Compact View";
            this.ts_top_compactview.Visible = false;
            this.ts_top_compactview.Click += new System.EventHandler(this.ts_top_compactview_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(58, 22);
            this.toolStripLabel1.Text = "Bug IDs:";
            // 
            // ts_top_txt_bugids
            // 
            this.ts_top_txt_bugids.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ts_top_txt_bugids.Name = "ts_top_txt_bugids";
            this.ts_top_txt_bugids.Size = new System.Drawing.Size(200, 25);
            this.ts_top_txt_bugids.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ts_top_txt_bugids_KeyPress);
            // 
            // ts_top_but_searchbug
            // 
            this.ts_top_but_searchbug.Image = ((System.Drawing.Image)(resources.GetObject("ts_top_but_searchbug.Image")));
            this.ts_top_but_searchbug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_top_but_searchbug.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.ts_top_but_searchbug.Name = "ts_top_but_searchbug";
            this.ts_top_but_searchbug.Size = new System.Drawing.Size(69, 22);
            this.ts_top_but_searchbug.Text = "Search";
            this.ts_top_but_searchbug.Click += new System.EventHandler(this.ts_top_but_searchbug_Click);
            // 
            // sc_1
            // 
            this.sc_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sc_1.Location = new System.Drawing.Point(5, 25);
            this.sc_1.Name = "sc_1";
            // 
            // sc_1.Panel1
            // 
            this.sc_1.Panel1.Controls.Add(this.grp_buglist);
            // 
            // sc_1.Panel2
            // 
            this.sc_1.Panel2.Controls.Add(this.grp_bugdetail);
            this.sc_1.Size = new System.Drawing.Size(1291, 618);
            this.sc_1.SplitterDistance = 976;
            this.sc_1.TabIndex = 3;
            // 
            // grp_buglist
            // 
            this.grp_buglist.Controls.Add(this.panel_buglist);
            this.grp_buglist.Controls.Add(this.ts_priority);
            this.grp_buglist.Controls.Add(this.ts_assignee);
            this.grp_buglist.Controls.Add(this.ts_reporter);
            this.grp_buglist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_buglist.Location = new System.Drawing.Point(0, 0);
            this.grp_buglist.Name = "grp_buglist";
            this.grp_buglist.Size = new System.Drawing.Size(976, 618);
            this.grp_buglist.TabIndex = 0;
            this.grp_buglist.TabStop = false;
            this.grp_buglist.Text = "Bug List";
            // 
            // panel_buglist
            // 
            this.panel_buglist.AutoScroll = true;
            this.panel_buglist.Controls.Add(this.ts_version);
            this.panel_buglist.Controls.Add(this.dgv_bug);
            this.panel_buglist.Controls.Add(this.ts_status);
            this.panel_buglist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_buglist.Location = new System.Drawing.Point(3, 17);
            this.panel_buglist.Name = "panel_buglist";
            this.panel_buglist.Size = new System.Drawing.Size(970, 523);
            this.panel_buglist.TabIndex = 3;
            // 
            // ts_version
            // 
            this.ts_version.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ts_version.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_version.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.ts_version_com_reportversion,
            this.toolStripLabel3,
            this.ts_version_com_resolveversion});
            this.ts_version.Location = new System.Drawing.Point(0, 473);
            this.ts_version.Name = "ts_version";
            this.ts_version.Size = new System.Drawing.Size(970, 25);
            this.ts_version.TabIndex = 7;
            this.ts_version.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.ForeColor = System.Drawing.Color.DarkRed;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(100, 22);
            this.toolStripLabel2.Text = "Reported Version:";
            // 
            // ts_version_com_reportversion
            // 
            this.ts_version_com_reportversion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ts_version_com_reportversion.Name = "ts_version_com_reportversion";
            this.ts_version_com_reportversion.Size = new System.Drawing.Size(300, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.ForeColor = System.Drawing.Color.DarkRed;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(99, 22);
            this.toolStripLabel3.Text = "Resolved Version:";
            // 
            // ts_version_com_resolveversion
            // 
            this.ts_version_com_resolveversion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ts_version_com_resolveversion.Name = "ts_version_com_resolveversion";
            this.ts_version_com_resolveversion.Size = new System.Drawing.Size(300, 25);
            // 
            // dgv_bug
            // 
            this.dgv_bug.AllowUserToAddRows = false;
            this.dgv_bug.AllowUserToDeleteRows = false;
            this.dgv_bug.AllowUserToResizeRows = false;
            this.dgv_bug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_bug.BackgroundColor = System.Drawing.Color.White;
            this.dgv_bug.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_bug.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_bug.ColumnHeadersHeight = 35;
            this.dgv_bug.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_bug.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_bug_chk,
            this.col_bug_id,
            this.col_bug_prioritycolor,
            this.col_bug_priority,
            this.col_bug_cellstatus,
            this.col_bug_description,
            this.col_bug_version,
            this.col_bug_resolveversion,
            this.col_bug_reporter,
            this.col_bug_assignee,
            this.col_bug_createddate});
            this.dgv_bug.ContextMenuStrip = this.cms_bug;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_bug.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_bug.Location = new System.Drawing.Point(4, 3);
            this.dgv_bug.Name = "dgv_bug";
            this.dgv_bug.RowHeadersVisible = false;
            this.dgv_bug.RowTemplate.Height = 30;
            this.dgv_bug.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_bug.Size = new System.Drawing.Size(963, 467);
            this.dgv_bug.TabIndex = 0;
            // 
            // col_bug_chk
            // 
            this.col_bug_chk.HeaderText = "";
            this.col_bug_chk.Name = "col_bug_chk";
            this.col_bug_chk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_bug_chk.Width = 30;
            // 
            // col_bug_id
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_bug_id.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_bug_id.HeaderText = "Bug ID";
            this.col_bug_id.Name = "col_bug_id";
            this.col_bug_id.ReadOnly = true;
            this.col_bug_id.Width = 69;
            // 
            // col_bug_prioritycolor
            // 
            this.col_bug_prioritycolor.HeaderText = "";
            this.col_bug_prioritycolor.Name = "col_bug_prioritycolor";
            this.col_bug_prioritycolor.ReadOnly = true;
            this.col_bug_prioritycolor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_bug_prioritycolor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_bug_prioritycolor.Width = 30;
            // 
            // col_bug_priority
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_bug_priority.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_bug_priority.HeaderText = "Priority";
            this.col_bug_priority.Name = "col_bug_priority";
            this.col_bug_priority.ReadOnly = true;
            this.col_bug_priority.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_bug_priority.Width = 80;
            // 
            // col_bug_cellstatus
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_bug_cellstatus.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_bug_cellstatus.HeaderText = "Status";
            this.col_bug_cellstatus.Name = "col_bug_cellstatus";
            this.col_bug_cellstatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_bug_cellstatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_bug_description
            // 
            this.col_bug_description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_bug_description.HeaderText = "Description";
            this.col_bug_description.MinimumWidth = 250;
            this.col_bug_description.Name = "col_bug_description";
            this.col_bug_description.ReadOnly = true;
            // 
            // col_bug_version
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_bug_version.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_bug_version.HeaderText = "Reported Version";
            this.col_bug_version.MinimumWidth = 180;
            this.col_bug_version.Name = "col_bug_version";
            this.col_bug_version.Width = 180;
            // 
            // col_bug_resolveversion
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_bug_resolveversion.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_bug_resolveversion.HeaderText = "Resolved Version";
            this.col_bug_resolveversion.MinimumWidth = 180;
            this.col_bug_resolveversion.Name = "col_bug_resolveversion";
            this.col_bug_resolveversion.Width = 180;
            // 
            // col_bug_reporter
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_bug_reporter.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_bug_reporter.HeaderText = "Reporter";
            this.col_bug_reporter.Name = "col_bug_reporter";
            this.col_bug_reporter.ReadOnly = true;
            this.col_bug_reporter.Width = 150;
            // 
            // col_bug_assignee
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_bug_assignee.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_bug_assignee.HeaderText = "Assignee";
            this.col_bug_assignee.Name = "col_bug_assignee";
            this.col_bug_assignee.ReadOnly = true;
            this.col_bug_assignee.Width = 150;
            // 
            // col_bug_createddate
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_bug_createddate.DefaultCellStyle = dataGridViewCellStyle9;
            this.col_bug_createddate.HeaderText = "Created Date";
            this.col_bug_createddate.Name = "col_bug_createddate";
            this.col_bug_createddate.Width = 150;
            // 
            // cms_bug
            // 
            this.cms_bug.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_bug_moveto,
            this.cms_bug_delete,
            this.toolStripSeparator1,
            this.cms_bug_reopen,
            this.cms_bug_setpriority,
            this.cms_bug_verify,
            this.toolStripSeparator2,
            this.cms_bug_assigntome,
            this.cms_bug_assignto,
            this.cms_bug_fixed,
            this.cms_bug_pleasewait,
            this.cms_bug_resolve,
            this.cms_bug_notfix,
            this.cms_bug_bydesign});
            this.cms_bug.Name = "cms_bug";
            this.cms_bug.Size = new System.Drawing.Size(145, 280);
            // 
            // cms_bug_moveto
            // 
            this.cms_bug_moveto.Name = "cms_bug_moveto";
            this.cms_bug_moveto.Size = new System.Drawing.Size(144, 22);
            this.cms_bug_moveto.Text = "Move To";
            // 
            // cms_bug_delete
            // 
            this.cms_bug_delete.Name = "cms_bug_delete";
            this.cms_bug_delete.Size = new System.Drawing.Size(144, 22);
            this.cms_bug_delete.Text = "Delete";
            this.cms_bug_delete.Click += new System.EventHandler(this.cms_bug_delete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // cms_bug_reopen
            // 
            this.cms_bug_reopen.Image = global::BugSearch.Properties.Resources.reopened;
            this.cms_bug_reopen.Name = "cms_bug_reopen";
            this.cms_bug_reopen.Size = new System.Drawing.Size(144, 22);
            this.cms_bug_reopen.Text = "Reopen";
            this.cms_bug_reopen.Click += new System.EventHandler(this.cms_bug_reopen_Click);
            // 
            // cms_bug_setpriority
            // 
            this.cms_bug_setpriority.Name = "cms_bug_setpriority";
            this.cms_bug_setpriority.Size = new System.Drawing.Size(144, 22);
            this.cms_bug_setpriority.Text = "Set Priority";
            // 
            // cms_bug_verify
            // 
            this.cms_bug_verify.Image = global::BugSearch.Properties.Resources.closed;
            this.cms_bug_verify.Name = "cms_bug_verify";
            this.cms_bug_verify.Size = new System.Drawing.Size(144, 22);
            this.cms_bug_verify.Text = "Verify";
            this.cms_bug_verify.Click += new System.EventHandler(this.cms_bug_verify_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // cms_bug_assigntome
            // 
            this.cms_bug_assigntome.Name = "cms_bug_assigntome";
            this.cms_bug_assigntome.Size = new System.Drawing.Size(144, 22);
            this.cms_bug_assigntome.Text = "Assign To Me";
            this.cms_bug_assigntome.Click += new System.EventHandler(this.cms_bug_assigntome_Click);
            // 
            // cms_bug_assignto
            // 
            this.cms_bug_assignto.Name = "cms_bug_assignto";
            this.cms_bug_assignto.Size = new System.Drawing.Size(144, 22);
            this.cms_bug_assignto.Text = "Assign To";
            // 
            // cms_bug_fixed
            // 
            this.cms_bug_fixed.Name = "cms_bug_fixed";
            this.cms_bug_fixed.Size = new System.Drawing.Size(144, 22);
            this.cms_bug_fixed.Text = "Fixed";
            this.cms_bug_fixed.Click += new System.EventHandler(this.cms_bug_fixed_Click);
            // 
            // cms_bug_pleasewait
            // 
            this.cms_bug_pleasewait.Name = "cms_bug_pleasewait";
            this.cms_bug_pleasewait.Size = new System.Drawing.Size(144, 22);
            this.cms_bug_pleasewait.Text = "Please Wait";
            this.cms_bug_pleasewait.Click += new System.EventHandler(this.cms_bug_pleasewait_Click);
            // 
            // cms_bug_resolve
            // 
            this.cms_bug_resolve.Image = global::BugSearch.Properties.Resources.resolved;
            this.cms_bug_resolve.Name = "cms_bug_resolve";
            this.cms_bug_resolve.Size = new System.Drawing.Size(144, 22);
            this.cms_bug_resolve.Text = "Resolve";
            this.cms_bug_resolve.Click += new System.EventHandler(this.cms_bug_resolve_Click);
            // 
            // cms_bug_notfix
            // 
            this.cms_bug_notfix.Image = global::BugSearch.Properties.Resources.trash;
            this.cms_bug_notfix.Name = "cms_bug_notfix";
            this.cms_bug_notfix.Size = new System.Drawing.Size(144, 22);
            this.cms_bug_notfix.Text = "Not Fix";
            this.cms_bug_notfix.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cms_bug_notfix.Click += new System.EventHandler(this.cms_bug_notfix_Click);
            // 
            // cms_bug_bydesign
            // 
            this.cms_bug_bydesign.Image = global::BugSearch.Properties.Resources.document;
            this.cms_bug_bydesign.Name = "cms_bug_bydesign";
            this.cms_bug_bydesign.Size = new System.Drawing.Size(144, 22);
            this.cms_bug_bydesign.Text = "By Design";
            this.cms_bug_bydesign.Click += new System.EventHandler(this.cms_bug_bydesign_Click);
            // 
            // ts_status
            // 
            this.ts_status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ts_status.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_status_allstatuses});
            this.ts_status.Location = new System.Drawing.Point(0, 498);
            this.ts_status.Name = "ts_status";
            this.ts_status.Size = new System.Drawing.Size(970, 25);
            this.ts_status.TabIndex = 6;
            this.ts_status.Text = "toolStrip1";
            // 
            // ts_status_allstatuses
            // 
            this.ts_status_allstatuses.Checked = true;
            this.ts_status_allstatuses.CheckOnClick = true;
            this.ts_status_allstatuses.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ts_status_allstatuses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_status_allstatuses.Image = ((System.Drawing.Image)(resources.GetObject("ts_status_allstatuses.Image")));
            this.ts_status_allstatuses.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_status_allstatuses.Name = "ts_status_allstatuses";
            this.ts_status_allstatuses.Size = new System.Drawing.Size(71, 22);
            this.ts_status_allstatuses.Text = "All Statuses";
            this.ts_status_allstatuses.Click += new System.EventHandler(this.ts_status_allstatuses_Click);
            // 
            // ts_priority
            // 
            this.ts_priority.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ts_priority.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_priority.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_priority_allpriorities});
            this.ts_priority.Location = new System.Drawing.Point(3, 540);
            this.ts_priority.Name = "ts_priority";
            this.ts_priority.Size = new System.Drawing.Size(970, 25);
            this.ts_priority.TabIndex = 5;
            this.ts_priority.Text = "toolStrip1";
            // 
            // ts_priority_allpriorities
            // 
            this.ts_priority_allpriorities.Checked = true;
            this.ts_priority_allpriorities.CheckOnClick = true;
            this.ts_priority_allpriorities.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ts_priority_allpriorities.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_priority_allpriorities.Image = ((System.Drawing.Image)(resources.GetObject("ts_priority_allpriorities.Image")));
            this.ts_priority_allpriorities.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_priority_allpriorities.Name = "ts_priority_allpriorities";
            this.ts_priority_allpriorities.Size = new System.Drawing.Size(74, 22);
            this.ts_priority_allpriorities.Text = "All Priorities";
            this.ts_priority_allpriorities.Click += new System.EventHandler(this.ts_priority_allpriorities_Click);
            // 
            // ts_assignee
            // 
            this.ts_assignee.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ts_assignee.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_assignee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_assignee_allassignees});
            this.ts_assignee.Location = new System.Drawing.Point(3, 565);
            this.ts_assignee.Name = "ts_assignee";
            this.ts_assignee.Size = new System.Drawing.Size(970, 25);
            this.ts_assignee.TabIndex = 4;
            this.ts_assignee.Text = "toolStrip1";
            // 
            // ts_assignee_allassignees
            // 
            this.ts_assignee_allassignees.Checked = true;
            this.ts_assignee_allassignees.CheckOnClick = true;
            this.ts_assignee_allassignees.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ts_assignee_allassignees.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_assignee_allassignees.Image = ((System.Drawing.Image)(resources.GetObject("ts_assignee_allassignees.Image")));
            this.ts_assignee_allassignees.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_assignee_allassignees.Name = "ts_assignee_allassignees";
            this.ts_assignee_allassignees.Size = new System.Drawing.Size(80, 22);
            this.ts_assignee_allassignees.Text = "All Assignees";
            this.ts_assignee_allassignees.Click += new System.EventHandler(this.ts_assignee_allassignees_Click);
            // 
            // ts_reporter
            // 
            this.ts_reporter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ts_reporter.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_reporter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_reporter_allreporters});
            this.ts_reporter.Location = new System.Drawing.Point(3, 590);
            this.ts_reporter.Name = "ts_reporter";
            this.ts_reporter.Size = new System.Drawing.Size(970, 25);
            this.ts_reporter.TabIndex = 3;
            this.ts_reporter.Text = "toolStrip1";
            // 
            // ts_reporter_allreporters
            // 
            this.ts_reporter_allreporters.Checked = true;
            this.ts_reporter_allreporters.CheckOnClick = true;
            this.ts_reporter_allreporters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ts_reporter_allreporters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_reporter_allreporters.Image = ((System.Drawing.Image)(resources.GetObject("ts_reporter_allreporters.Image")));
            this.ts_reporter_allreporters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_reporter_allreporters.Name = "ts_reporter_allreporters";
            this.ts_reporter_allreporters.Size = new System.Drawing.Size(78, 22);
            this.ts_reporter_allreporters.Text = "All Reporters";
            this.ts_reporter_allreporters.Click += new System.EventHandler(this.ts_reporter_allreporters_Click);
            // 
            // grp_bugdetail
            // 
            this.grp_bugdetail.Controls.Add(this.tlp_buginfo);
            this.grp_bugdetail.Controls.Add(this.ts_buginfo);
            this.grp_bugdetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_bugdetail.Location = new System.Drawing.Point(0, 0);
            this.grp_bugdetail.Name = "grp_bugdetail";
            this.grp_bugdetail.Size = new System.Drawing.Size(311, 618);
            this.grp_bugdetail.TabIndex = 0;
            this.grp_bugdetail.TabStop = false;
            this.grp_bugdetail.Text = "Bug Details";
            // 
            // tlp_buginfo
            // 
            this.tlp_buginfo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlp_buginfo.ColumnCount = 2;
            this.tlp_buginfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.2766F));
            this.tlp_buginfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.7234F));
            this.tlp_buginfo.Controls.Add(this.label1, 0, 0);
            this.tlp_buginfo.Controls.Add(this.label2, 0, 1);
            this.tlp_buginfo.Controls.Add(this.label3, 0, 2);
            this.tlp_buginfo.Controls.Add(this.rtxt_buginfo_description, 1, 0);
            this.tlp_buginfo.Controls.Add(this.rtxt_buginfo_comment, 1, 1);
            this.tlp_buginfo.Controls.Add(this.panel_attachment, 1, 2);
            this.tlp_buginfo.Controls.Add(this.label4, 0, 3);
            this.tlp_buginfo.Controls.Add(this.label5, 0, 4);
            this.tlp_buginfo.Controls.Add(this.rtxt_version, 1, 3);
            this.tlp_buginfo.Controls.Add(this.rtxt_resolveversion, 1, 4);
            this.tlp_buginfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_buginfo.Location = new System.Drawing.Point(3, 42);
            this.tlp_buginfo.Name = "tlp_buginfo";
            this.tlp_buginfo.RowCount = 5;
            this.tlp_buginfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.727F));
            this.tlp_buginfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.727F));
            this.tlp_buginfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.16244F));
            this.tlp_buginfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.191781F));
            this.tlp_buginfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.191781F));
            this.tlp_buginfo.Size = new System.Drawing.Size(305, 573);
            this.tlp_buginfo.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Comment:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Attachments:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtxt_buginfo_description
            // 
            this.rtxt_buginfo_description.BackColor = System.Drawing.Color.White;
            this.rtxt_buginfo_description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_buginfo_description.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_buginfo_description.Location = new System.Drawing.Point(69, 4);
            this.rtxt_buginfo_description.Name = "rtxt_buginfo_description";
            this.rtxt_buginfo_description.ReadOnly = true;
            this.rtxt_buginfo_description.Size = new System.Drawing.Size(232, 100);
            this.rtxt_buginfo_description.TabIndex = 3;
            this.rtxt_buginfo_description.Text = "";
            // 
            // rtxt_buginfo_comment
            // 
            this.rtxt_buginfo_comment.BackColor = System.Drawing.Color.White;
            this.rtxt_buginfo_comment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_buginfo_comment.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_buginfo_comment.Location = new System.Drawing.Point(69, 111);
            this.rtxt_buginfo_comment.Name = "rtxt_buginfo_comment";
            this.rtxt_buginfo_comment.ReadOnly = true;
            this.rtxt_buginfo_comment.Size = new System.Drawing.Size(232, 100);
            this.rtxt_buginfo_comment.TabIndex = 4;
            this.rtxt_buginfo_comment.Text = "";
            // 
            // panel_attachment
            // 
            this.panel_attachment.AutoScroll = true;
            this.panel_attachment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_attachment.Location = new System.Drawing.Point(69, 218);
            this.panel_attachment.Name = "panel_attachment";
            this.panel_attachment.Size = new System.Drawing.Size(232, 267);
            this.panel_attachment.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 494);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "Reported Version:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 530);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 42);
            this.label5.TabIndex = 7;
            this.label5.Text = "Resolved Version:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtxt_version
            // 
            this.rtxt_version.BackColor = System.Drawing.Color.White;
            this.rtxt_version.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_version.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_version.Location = new System.Drawing.Point(69, 492);
            this.rtxt_version.Name = "rtxt_version";
            this.rtxt_version.ReadOnly = true;
            this.rtxt_version.Size = new System.Drawing.Size(232, 34);
            this.rtxt_version.TabIndex = 8;
            this.rtxt_version.Text = "";
            // 
            // rtxt_resolveversion
            // 
            this.rtxt_resolveversion.BackColor = System.Drawing.Color.White;
            this.rtxt_resolveversion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_resolveversion.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_resolveversion.Location = new System.Drawing.Point(69, 533);
            this.rtxt_resolveversion.Name = "rtxt_resolveversion";
            this.rtxt_resolveversion.ReadOnly = true;
            this.rtxt_resolveversion.Size = new System.Drawing.Size(232, 36);
            this.rtxt_resolveversion.TabIndex = 9;
            this.rtxt_resolveversion.Text = "";
            // 
            // ts_buginfo
            // 
            this.ts_buginfo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_buginfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_buginfo_edit,
            this.ts_buginfo_deleteallattachment,
            this.ts_buginfo_addattachment});
            this.ts_buginfo.Location = new System.Drawing.Point(3, 17);
            this.ts_buginfo.Name = "ts_buginfo";
            this.ts_buginfo.Size = new System.Drawing.Size(305, 25);
            this.ts_buginfo.TabIndex = 1;
            this.ts_buginfo.Text = "toolStrip1";
            // 
            // ts_buginfo_edit
            // 
            this.ts_buginfo_edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_buginfo_edit.Image = ((System.Drawing.Image)(resources.GetObject("ts_buginfo_edit.Image")));
            this.ts_buginfo_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_buginfo_edit.Name = "ts_buginfo_edit";
            this.ts_buginfo_edit.Size = new System.Drawing.Size(31, 22);
            this.ts_buginfo_edit.Text = "Edit";
            this.ts_buginfo_edit.Click += new System.EventHandler(this.ts_buginfo_edit_Click);
            // 
            // ts_buginfo_deleteallattachment
            // 
            this.ts_buginfo_deleteallattachment.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ts_buginfo_deleteallattachment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_buginfo_deleteallattachment.Image = ((System.Drawing.Image)(resources.GetObject("ts_buginfo_deleteallattachment.Image")));
            this.ts_buginfo_deleteallattachment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_buginfo_deleteallattachment.Name = "ts_buginfo_deleteallattachment";
            this.ts_buginfo_deleteallattachment.Size = new System.Drawing.Size(132, 22);
            this.ts_buginfo_deleteallattachment.Text = "Delete All Attachments";
            this.ts_buginfo_deleteallattachment.Click += new System.EventHandler(this.ts_buginfo_deleteallattachment_Click);
            // 
            // ts_buginfo_addattachment
            // 
            this.ts_buginfo_addattachment.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ts_buginfo_addattachment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_buginfo_addattachment.Image = ((System.Drawing.Image)(resources.GetObject("ts_buginfo_addattachment.Image")));
            this.ts_buginfo_addattachment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_buginfo_addattachment.Name = "ts_buginfo_addattachment";
            this.ts_buginfo_addattachment.Size = new System.Drawing.Size(99, 22);
            this.ts_buginfo_addattachment.Text = "Add Attachment";
            this.ts_buginfo_addattachment.Click += new System.EventHandler(this.ts_buginfo_addattachment_Click);
            // 
            // cms_attachment
            // 
            this.cms_attachment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_attachment_delete});
            this.cms_attachment.Name = "cms_attachment";
            this.cms_attachment.Size = new System.Drawing.Size(108, 26);
            // 
            // cms_attachment_delete
            // 
            this.cms_attachment_delete.Name = "cms_attachment_delete";
            this.cms_attachment_delete.Size = new System.Drawing.Size(107, 22);
            this.cms_attachment_delete.Text = "Delete";
            this.cms_attachment_delete.Click += new System.EventHandler(this.cms_attachment_delete_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // dataGridViewStatusColumn1
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewStatusColumn1.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewStatusColumn1.HeaderText = "Status";
            this.dataGridViewStatusColumn1.Name = "dataGridViewStatusColumn1";
            this.dataGridViewStatusColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStatusColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_bug_status
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle12.NullValue")));
            this.col_bug_status.DefaultCellStyle = dataGridViewCellStyle12;
            this.col_bug_status.HeaderText = "Status";
            this.col_bug_status.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.col_bug_status.Name = "col_bug_status";
            this.col_bug_status.ReadOnly = true;
            this.col_bug_status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_bug_status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // BugListF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 643);
            this.Controls.Add(this.sc_1);
            this.Controls.Add(this.ts_top);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BugListF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BugListF";
            this.ts_top.ResumeLayout(false);
            this.ts_top.PerformLayout();
            this.sc_1.Panel1.ResumeLayout(false);
            this.sc_1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc_1)).EndInit();
            this.sc_1.ResumeLayout(false);
            this.grp_buglist.ResumeLayout(false);
            this.grp_buglist.PerformLayout();
            this.panel_buglist.ResumeLayout(false);
            this.panel_buglist.PerformLayout();
            this.ts_version.ResumeLayout(false);
            this.ts_version.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bug)).EndInit();
            this.cms_bug.ResumeLayout(false);
            this.ts_status.ResumeLayout(false);
            this.ts_status.PerformLayout();
            this.ts_priority.ResumeLayout(false);
            this.ts_priority.PerformLayout();
            this.ts_assignee.ResumeLayout(false);
            this.ts_assignee.PerformLayout();
            this.ts_reporter.ResumeLayout(false);
            this.ts_reporter.PerformLayout();
            this.grp_bugdetail.ResumeLayout(false);
            this.grp_bugdetail.PerformLayout();
            this.tlp_buginfo.ResumeLayout(false);
            this.tlp_buginfo.PerformLayout();
            this.ts_buginfo.ResumeLayout(false);
            this.ts_buginfo.PerformLayout();
            this.cms_attachment.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip ts_top;
        private System.Windows.Forms.ToolStripButton ts_top_newbug;
        private System.Windows.Forms.SplitContainer sc_1;
        private System.Windows.Forms.GroupBox grp_buglist;
        private System.Windows.Forms.GroupBox grp_bugdetail;
        private System.Windows.Forms.Panel panel_buglist;
        private System.Windows.Forms.DataGridView dgv_bug;
        private System.Windows.Forms.TableLayoutPanel tlp_buginfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip ts_buginfo;
        private System.Windows.Forms.ToolStripButton ts_top_filters;
        private System.Windows.Forms.RichTextBox rtxt_buginfo_description;
        private System.Windows.Forms.RichTextBox rtxt_buginfo_comment;
        private System.Windows.Forms.ToolStripButton ts_buginfo_edit;
        private System.Windows.Forms.Panel panel_attachment;
        private System.Windows.Forms.ContextMenuStrip cms_bug;
        private System.Windows.Forms.ToolStripMenuItem cms_bug_moveto;
        private System.Windows.Forms.ToolStripMenuItem cms_bug_delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cms_bug_reopen;
        private System.Windows.Forms.ToolStripMenuItem cms_bug_setpriority;
        private System.Windows.Forms.ToolStripMenuItem cms_bug_verify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cms_bug_assigntome;
        private System.Windows.Forms.ToolStripMenuItem cms_bug_assignto;
        private System.Windows.Forms.ToolStripMenuItem cms_bug_resolve;
        private System.Windows.Forms.ToolStripMenuItem cms_bug_notfix;
        private System.Windows.Forms.ToolStripMenuItem cms_bug_bydesign;
        private System.Windows.Forms.ToolStripButton ts_top_viewbugdetail;
        private System.Windows.Forms.ToolStripButton ts_top_compactview;
        private System.Windows.Forms.ContextMenuStrip cms_attachment;
        private System.Windows.Forms.ToolStripMenuItem cms_attachment_delete;
        private System.Windows.Forms.ToolStripButton ts_buginfo_deleteallattachment;
        private System.Windows.Forms.ToolStripButton ts_buginfo_addattachment;
        private System.Windows.Forms.ToolStripMenuItem cms_bug_fixed;
        private System.Windows.Forms.ToolStripMenuItem cms_bug_pleasewait;
        private System.Windows.Forms.DataGridViewImageColumn col_bug_status;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox ts_top_txt_bugids;
        private System.Windows.Forms.ToolStripButton ts_top_but_searchbug;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewStatusColumn dataGridViewStatusColumn1;
        private System.Windows.Forms.ToolStrip ts_status;
        private System.Windows.Forms.ToolStripButton ts_status_allstatuses;
        private System.Windows.Forms.ToolStrip ts_priority;
        private System.Windows.Forms.ToolStripButton ts_priority_allpriorities;
        private System.Windows.Forms.ToolStrip ts_assignee;
        private System.Windows.Forms.ToolStripButton ts_assignee_allassignees;
        private System.Windows.Forms.ToolStrip ts_reporter;
        private System.Windows.Forms.ToolStripButton ts_reporter_allreporters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtxt_version;
        private System.Windows.Forms.RichTextBox rtxt_resolveversion;
        private System.Windows.Forms.ToolStrip ts_version;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox ts_version_com_reportversion;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox ts_version_com_resolveversion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_bug_chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bug_id;
        private System.Windows.Forms.DataGridViewImageColumn col_bug_prioritycolor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bug_priority;
        private System.Windows.Forms.DataGridViewStatusColumn col_bug_cellstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bug_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bug_version;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bug_resolveversion;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bug_reporter;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bug_assignee;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bug_createddate;
        private System.Windows.Forms.ToolStripSplitButton ts_top_refresh;
        private System.Windows.Forms.ToolStripMenuItem ts_top_refresh_auto60s;
        private System.Windows.Forms.ToolStripMenuItem ts_top_refresh_auto30s;
        private System.Windows.Forms.ToolStripMenuItem ts_top_refresh_auto15s;
    }
}
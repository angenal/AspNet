namespace ShareX.HistoryLib
{
    partial class HistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryForm));
            this.scMain = new ShareX.HelpersLib.SplitContainerCustomSplitter();
            this.lvHistory = new ShareX.HelpersLib.MyListView();
            this.chIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbThumbnail = new ShareX.HelpersLib.MyPictureBox();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.lblURLFilter = new System.Windows.Forms.Label();
            this.txtURLFilter = new System.Windows.Forms.TextBox();
            this.lblFilenameFilter = new System.Windows.Forms.Label();
            this.cbHostFilterSelection = new System.Windows.Forms.ComboBox();
            this.btnRemoveFilters = new System.Windows.Forms.Button();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.cbTypeFilterSelection = new System.Windows.Forms.ComboBox();
            this.cbHostFilter = new System.Windows.Forms.CheckBox();
            this.cbTypeFilter = new System.Windows.Forms.CheckBox();
            this.dtpFilterFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFilterFrom = new System.Windows.Forms.Label();
            this.lblFilterTo = new System.Windows.Forms.Label();
            this.cbDateFilter = new System.Windows.Forms.CheckBox();
            this.dtpFilterTo = new System.Windows.Forms.DateTimePicker();
            this.txtFilenameFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            resources.ApplyResources(this.scMain, "scMain");
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.lvHistory);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.panel1);
            this.scMain.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.scMain_SplitterMoved);
            // 
            // lvHistory
            // 
            this.lvHistory.AllowColumnSort = true;
            this.lvHistory.AutoFillColumn = true;
            this.lvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chIcon,
            this.chDateTime,
            this.chFilename,
            this.chURL});
            resources.ApplyResources(this.lvHistory, "lvHistory");
            this.lvHistory.FullRowSelect = true;
            this.lvHistory.HideSelection = false;
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            this.lvHistory.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvHistory_ItemDrag);
            this.lvHistory.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvHistory_ItemSelectionChanged);
            this.lvHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvHistory_KeyDown);
            this.lvHistory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvHistory_MouseDoubleClick);
            this.lvHistory.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvHistory_MouseUp);
            // 
            // chIcon
            // 
            resources.ApplyResources(this.chIcon, "chIcon");
            // 
            // chDateTime
            // 
            resources.ApplyResources(this.chDateTime, "chDateTime");
            // 
            // chFilename
            // 
            resources.ApplyResources(this.chFilename, "chFilename");
            // 
            // chURL
            // 
            resources.ApplyResources(this.chURL, "chURL");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbThumbnail);
            this.panel1.Controls.Add(this.gbFilters);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // pbThumbnail
            // 
            resources.ApplyResources(this.pbThumbnail, "pbThumbnail");
            this.pbThumbnail.BackColor = System.Drawing.SystemColors.Window;
            this.pbThumbnail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbThumbnail.DrawCheckeredBackground = true;
            this.pbThumbnail.FullscreenOnClick = true;
            this.pbThumbnail.Name = "pbThumbnail";
            this.pbThumbnail.ShowImageSizeLabel = true;
            // 
            // gbFilters
            // 
            resources.ApplyResources(this.gbFilters, "gbFilters");
            this.gbFilters.Controls.Add(this.lblURLFilter);
            this.gbFilters.Controls.Add(this.txtURLFilter);
            this.gbFilters.Controls.Add(this.lblFilenameFilter);
            this.gbFilters.Controls.Add(this.cbHostFilterSelection);
            this.gbFilters.Controls.Add(this.btnRemoveFilters);
            this.gbFilters.Controls.Add(this.btnApplyFilters);
            this.gbFilters.Controls.Add(this.cbTypeFilterSelection);
            this.gbFilters.Controls.Add(this.cbHostFilter);
            this.gbFilters.Controls.Add(this.cbTypeFilter);
            this.gbFilters.Controls.Add(this.dtpFilterFrom);
            this.gbFilters.Controls.Add(this.lblFilterFrom);
            this.gbFilters.Controls.Add(this.lblFilterTo);
            this.gbFilters.Controls.Add(this.cbDateFilter);
            this.gbFilters.Controls.Add(this.dtpFilterTo);
            this.gbFilters.Controls.Add(this.txtFilenameFilter);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.TabStop = false;
            // 
            // lblURLFilter
            // 
            resources.ApplyResources(this.lblURLFilter, "lblURLFilter");
            this.lblURLFilter.Name = "lblURLFilter";
            // 
            // txtURLFilter
            // 
            resources.ApplyResources(this.txtURLFilter, "txtURLFilter");
            this.txtURLFilter.Name = "txtURLFilter";
            // 
            // lblFilenameFilter
            // 
            resources.ApplyResources(this.lblFilenameFilter, "lblFilenameFilter");
            this.lblFilenameFilter.Name = "lblFilenameFilter";
            // 
            // cbHostFilterSelection
            // 
            this.cbHostFilterSelection.FormattingEnabled = true;
            resources.ApplyResources(this.cbHostFilterSelection, "cbHostFilterSelection");
            this.cbHostFilterSelection.Name = "cbHostFilterSelection";
            // 
            // btnRemoveFilters
            // 
            resources.ApplyResources(this.btnRemoveFilters, "btnRemoveFilters");
            this.btnRemoveFilters.Name = "btnRemoveFilters";
            this.btnRemoveFilters.UseVisualStyleBackColor = true;
            this.btnRemoveFilters.Click += new System.EventHandler(this.btnRemoveFilters_Click);
            // 
            // btnApplyFilters
            // 
            resources.ApplyResources(this.btnApplyFilters, "btnApplyFilters");
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.UseVisualStyleBackColor = true;
            this.btnApplyFilters.Click += new System.EventHandler(this.btnApplyFilters_Click);
            // 
            // cbTypeFilterSelection
            // 
            this.cbTypeFilterSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeFilterSelection.FormattingEnabled = true;
            resources.ApplyResources(this.cbTypeFilterSelection, "cbTypeFilterSelection");
            this.cbTypeFilterSelection.Name = "cbTypeFilterSelection";
            // 
            // cbHostFilter
            // 
            resources.ApplyResources(this.cbHostFilter, "cbHostFilter");
            this.cbHostFilter.Name = "cbHostFilter";
            this.cbHostFilter.UseVisualStyleBackColor = true;
            // 
            // cbTypeFilter
            // 
            resources.ApplyResources(this.cbTypeFilter, "cbTypeFilter");
            this.cbTypeFilter.Name = "cbTypeFilter";
            this.cbTypeFilter.UseVisualStyleBackColor = true;
            // 
            // dtpFilterFrom
            // 
            resources.ApplyResources(this.dtpFilterFrom, "dtpFilterFrom");
            this.dtpFilterFrom.Name = "dtpFilterFrom";
            // 
            // lblFilterFrom
            // 
            resources.ApplyResources(this.lblFilterFrom, "lblFilterFrom");
            this.lblFilterFrom.Name = "lblFilterFrom";
            // 
            // lblFilterTo
            // 
            resources.ApplyResources(this.lblFilterTo, "lblFilterTo");
            this.lblFilterTo.Name = "lblFilterTo";
            // 
            // cbDateFilter
            // 
            resources.ApplyResources(this.cbDateFilter, "cbDateFilter");
            this.cbDateFilter.Name = "cbDateFilter";
            this.cbDateFilter.UseVisualStyleBackColor = true;
            // 
            // dtpFilterTo
            // 
            resources.ApplyResources(this.dtpFilterTo, "dtpFilterTo");
            this.dtpFilterTo.Name = "dtpFilterTo";
            // 
            // txtFilenameFilter
            // 
            resources.ApplyResources(this.txtFilenameFilter, "txtFilenameFilter");
            this.txtFilenameFilter.Name = "txtFilenameFilter";
            // 
            // HistoryForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.scMain);
            this.KeyPreview = true;
            this.Name = "HistoryForm";
            this.Shown += new System.EventHandler(this.HistoryForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HistoryForm_KeyDown);
            this.Resize += new System.EventHandler(this.HistoryForm_Resize);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion Windows Form Designer generated code

        private ShareX.HelpersLib.MyListView lvHistory;
        private System.Windows.Forms.ColumnHeader chFilename;
        private System.Windows.Forms.ColumnHeader chDateTime;
        private System.Windows.Forms.ColumnHeader chURL;
        private System.Windows.Forms.ColumnHeader chIcon;
        private ShareX.HelpersLib.SplitContainerCustomSplitter scMain;
        private System.Windows.Forms.Panel panel1;
        private HelpersLib.MyPictureBox pbThumbnail;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.ComboBox cbHostFilterSelection;
        private System.Windows.Forms.Button btnRemoveFilters;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.ComboBox cbTypeFilterSelection;
        private System.Windows.Forms.CheckBox cbHostFilter;
        private System.Windows.Forms.CheckBox cbTypeFilter;
        private System.Windows.Forms.DateTimePicker dtpFilterFrom;
        private System.Windows.Forms.Label lblFilterFrom;
        private System.Windows.Forms.Label lblFilterTo;
        private System.Windows.Forms.CheckBox cbDateFilter;
        private System.Windows.Forms.DateTimePicker dtpFilterTo;
        private System.Windows.Forms.TextBox txtFilenameFilter;
        private System.Windows.Forms.Label lblFilenameFilter;
        private System.Windows.Forms.Label lblURLFilter;
        private System.Windows.Forms.TextBox txtURLFilter;
    }
}
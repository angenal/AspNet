namespace EOPDFDemo
{
    partial class MainForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("All Demos");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tvDemos = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.tbViewInst = new System.Windows.Forms.ToolStripButton();
            this.tbViewCSCode = new System.Windows.Forms.ToolStripButton();
            this.tbViewVBCode = new System.Windows.Forms.ToolStripButton();
            this.tbViewPDF = new System.Windows.Forms.ToolStripButton();
            this.panClient = new System.Windows.Forms.Panel();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvDemos
            // 
            this.tvDemos.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvDemos.HideSelection = false;
            this.tvDemos.Location = new System.Drawing.Point(0, 25);
            this.tvDemos.Name = "tvDemos";
            treeNode1.Name = "";
            treeNode1.Text = "All Demos";
            this.tvDemos.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvDemos.Size = new System.Drawing.Size(167, 489);
            this.tvDemos.TabIndex = 1;
            this.tvDemos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDemos_AfterSelect);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(167, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 489);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // toolBar
            // 
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbViewInst,
            this.tbViewCSCode,
            this.tbViewVBCode,
            this.tbViewPDF});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(841, 25);
            this.toolBar.TabIndex = 8;
            this.toolBar.Text = "toolStrip1";
            // 
            // tbViewInst
            // 
            this.tbViewInst.Enabled = false;
            this.tbViewInst.Image = ((System.Drawing.Image)(resources.GetObject("tbViewInst.Image")));
            this.tbViewInst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbViewInst.Name = "tbViewInst";
            this.tbViewInst.Size = new System.Drawing.Size(89, 22);
            this.tbViewInst.Text = "Instructions";
            this.tbViewInst.Click += new System.EventHandler(this.tbViewInst_Click);
            // 
            // tbViewCSCode
            // 
            this.tbViewCSCode.Enabled = false;
            this.tbViewCSCode.Image = ((System.Drawing.Image)(resources.GetObject("tbViewCSCode.Image")));
            this.tbViewCSCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbViewCSCode.Name = "tbViewCSCode";
            this.tbViewCSCode.Size = new System.Drawing.Size(112, 22);
            this.tbViewCSCode.Text = "C# Source Code";
            this.tbViewCSCode.ToolTipText = "View C# Source Code for this sample";
            this.tbViewCSCode.Click += new System.EventHandler(this.tbViewCSCode_Click);
            // 
            // tbViewVBCode
            // 
            this.tbViewVBCode.Enabled = false;
            this.tbViewVBCode.Image = ((System.Drawing.Image)(resources.GetObject("tbViewVBCode.Image")));
            this.tbViewVBCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbViewVBCode.Name = "tbViewVBCode";
            this.tbViewVBCode.Size = new System.Drawing.Size(136, 22);
            this.tbViewVBCode.Text = "VB.NET Source Code";
            this.tbViewVBCode.ToolTipText = "View VB.NET Source Code for this sample";
            this.tbViewVBCode.Click += new System.EventHandler(this.tbViewVBCode_Click);
            // 
            // tbViewPDF
            // 
            this.tbViewPDF.Enabled = false;
            this.tbViewPDF.Image = ((System.Drawing.Image)(resources.GetObject("tbViewPDF.Image")));
            this.tbViewPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbViewPDF.Name = "tbViewPDF";
            this.tbViewPDF.Size = new System.Drawing.Size(104, 22);
            this.tbViewPDF.Text = "Result PDF File";
            this.tbViewPDF.ToolTipText = "View Result PDF File";
            this.tbViewPDF.Click += new System.EventHandler(this.tbViewPDF_Click);
            // 
            // panClient
            // 
            this.panClient.BackColor = System.Drawing.SystemColors.Window;
            this.panClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panClient.Location = new System.Drawing.Point(170, 25);
            this.panClient.Name = "panClient";
            this.panClient.Size = new System.Drawing.Size(671, 489);
            this.panClient.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 514);
            this.Controls.Add(this.panClient);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tvDemos);
            this.Controls.Add(this.toolBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "EO.Pdf Demo";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvDemos;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton tbViewCSCode;
        private System.Windows.Forms.ToolStripButton tbViewVBCode;
        private System.Windows.Forms.Panel panClient;
        private System.Windows.Forms.ToolStripButton tbViewInst;
        private System.Windows.Forms.ToolStripButton tbViewPDF;
    }
}


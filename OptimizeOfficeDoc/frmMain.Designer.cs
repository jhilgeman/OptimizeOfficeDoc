namespace OptimizeOfficeDoc
{
    partial class frmMain
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
                workDocument.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnOptimize = new System.Windows.Forms.Button();
            this.pnlFile = new System.Windows.Forms.Panel();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.pnlImageWorkUIs = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusHeader = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.lblTotalOriginalSize = new System.Windows.Forms.Label();
            this.pnlResults = new System.Windows.Forms.Panel();
            this.tlpResults = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotalOptimizedSize = new System.Windows.Forms.Label();
            this.pnlContents = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnQuickAdjustments = new System.Windows.Forms.Button();
            this.ctlPercentageBar1 = new OptimizeOfficeDoc.ctlPercentageBar();
            this.pnlFile.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlResults.SuspendLayout();
            this.tlpResults.SuspendLayout();
            this.pnlContents.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(12, 17);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(26, 13);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "File:";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(44, 14);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(602, 20);
            this.txtFile.TabIndex = 1;
            this.txtFile.TextChanged += new System.EventHandler(this.txtFile_TextChanged);
            // 
            // btnOptimize
            // 
            this.btnOptimize.Enabled = false;
            this.btnOptimize.Location = new System.Drawing.Point(733, 12);
            this.btnOptimize.Name = "btnOptimize";
            this.btnOptimize.Size = new System.Drawing.Size(90, 23);
            this.btnOptimize.TabIndex = 2;
            this.btnOptimize.Text = "Optimize";
            this.btnOptimize.UseVisualStyleBackColor = true;
            this.btnOptimize.Click += new System.EventHandler(this.btnOptimize_Click);
            // 
            // pnlFile
            // 
            this.pnlFile.Controls.Add(this.btnOpen);
            this.pnlFile.Controls.Add(this.btnOptimize);
            this.pnlFile.Controls.Add(this.lblFile);
            this.pnlFile.Controls.Add(this.txtFile);
            this.pnlFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFile.Location = new System.Drawing.Point(0, 0);
            this.pnlFile.Name = "pnlFile";
            this.pnlFile.Size = new System.Drawing.Size(835, 44);
            this.pnlFile.TabIndex = 5;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSaveChanges.Location = new System.Drawing.Point(742, 3);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(90, 23);
            this.btnSaveChanges.TabIndex = 3;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // pnlImageWorkUIs
            // 
            this.pnlImageWorkUIs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlImageWorkUIs.AutoScroll = true;
            this.pnlImageWorkUIs.Location = new System.Drawing.Point(3, 3);
            this.pnlImageWorkUIs.Name = "pnlImageWorkUIs";
            this.pnlImageWorkUIs.Size = new System.Drawing.Size(829, 377);
            this.pnlImageWorkUIs.TabIndex = 6;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusHeader,
            this.lblStatus,
            this.pbStatus});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(835, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusHeader
            // 
            this.lblStatusHeader.Name = "lblStatusHeader";
            this.lblStatusHeader.Size = new System.Drawing.Size(42, 17);
            this.lblStatusHeader.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(29, 17);
            this.lblStatus.Text = "Idle.";
            // 
            // pbStatus
            // 
            this.pbStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(100, 16);
            // 
            // lblTotalOriginalSize
            // 
            this.lblTotalOriginalSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalOriginalSize.AutoSize = true;
            this.lblTotalOriginalSize.Location = new System.Drawing.Point(3, 8);
            this.lblTotalOriginalSize.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.lblTotalOriginalSize.Name = "lblTotalOriginalSize";
            this.lblTotalOriginalSize.Size = new System.Drawing.Size(91, 13);
            this.lblTotalOriginalSize.TabIndex = 4;
            this.lblTotalOriginalSize.Text = "Original Size: N/A";
            // 
            // pnlResults
            // 
            this.pnlResults.Controls.Add(this.tlpResults);
            this.pnlResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResults.Location = new System.Drawing.Point(0, 430);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.pnlResults.Size = new System.Drawing.Size(835, 37);
            this.pnlResults.TabIndex = 7;
            this.pnlResults.Visible = false;
            // 
            // tlpResults
            // 
            this.tlpResults.ColumnCount = 5;
            this.tlpResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpResults.Controls.Add(this.lblTotalOriginalSize, 0, 0);
            this.tlpResults.Controls.Add(this.lblTotalOptimizedSize, 1, 0);
            this.tlpResults.Controls.Add(this.btnSaveChanges, 4, 0);
            this.tlpResults.Controls.Add(this.ctlPercentageBar1, 2, 0);
            this.tlpResults.Controls.Add(this.btnQuickAdjustments, 3, 0);
            this.tlpResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpResults.Location = new System.Drawing.Point(0, 0);
            this.tlpResults.Name = "tlpResults";
            this.tlpResults.RowCount = 1;
            this.tlpResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResults.Size = new System.Drawing.Size(835, 29);
            this.tlpResults.TabIndex = 8;
            // 
            // lblTotalOptimizedSize
            // 
            this.lblTotalOptimizedSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalOptimizedSize.AutoSize = true;
            this.lblTotalOptimizedSize.Location = new System.Drawing.Point(103, 8);
            this.lblTotalOptimizedSize.Name = "lblTotalOptimizedSize";
            this.lblTotalOptimizedSize.Size = new System.Drawing.Size(151, 13);
            this.lblTotalOptimizedSize.TabIndex = 7;
            this.lblTotalOptimizedSize.Text = "Estimated Optimized Size: N/A";
            // 
            // pnlContents
            // 
            this.pnlContents.Controls.Add(this.pnlImageWorkUIs);
            this.pnlContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContents.Location = new System.Drawing.Point(0, 44);
            this.pnlContents.Name = "pnlContents";
            this.pnlContents.Size = new System.Drawing.Size(835, 386);
            this.pnlContents.TabIndex = 8;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(652, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnQuickAdjustments
            // 
            this.btnQuickAdjustments.Location = new System.Drawing.Point(574, 3);
            this.btnQuickAdjustments.Name = "btnQuickAdjustments";
            this.btnQuickAdjustments.Size = new System.Drawing.Size(162, 23);
            this.btnQuickAdjustments.TabIndex = 9;
            this.btnQuickAdjustments.Text = "Show Quick Adjustments";
            this.btnQuickAdjustments.UseVisualStyleBackColor = true;
            this.btnQuickAdjustments.Click += new System.EventHandler(this.btnQuickAdjustments_Click);
            // 
            // ctlPercentageBar1
            // 
            this.ctlPercentageBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlPercentageBar1.Location = new System.Drawing.Point(260, 4);
            this.ctlPercentageBar1.Name = "ctlPercentageBar1";
            this.ctlPercentageBar1.Size = new System.Drawing.Size(308, 21);
            this.ctlPercentageBar1.TabIndex = 8;
            this.ctlPercentageBar1.Total = 100F;
            this.ctlPercentageBar1.Value = 50F;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 489);
            this.Controls.Add(this.pnlContents);
            this.Controls.Add(this.pnlResults);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlFile);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Optimize Office Document v1.0";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlFile.ResumeLayout(false);
            this.pnlFile.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlResults.ResumeLayout(false);
            this.tlpResults.ResumeLayout(false);
            this.tlpResults.PerformLayout();
            this.pnlContents.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnOptimize;
        private System.Windows.Forms.Panel pnlFile;
        private System.Windows.Forms.Panel pnlImageWorkUIs;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusHeader;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar pbStatus;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label lblTotalOriginalSize;
        private System.Windows.Forms.Panel pnlResults;
        private System.Windows.Forms.Panel pnlContents;
        private System.Windows.Forms.Label lblTotalOptimizedSize;
        private System.Windows.Forms.TableLayoutPanel tlpResults;
        private ctlPercentageBar ctlPercentageBar1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnQuickAdjustments;
    }
}


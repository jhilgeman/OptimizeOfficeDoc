namespace OptimizeOfficeDoc
{
    partial class frmQuickAdjustments
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
            this.cbQualityLevel = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.chkSetJPGQualityLevel = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbQualityLevel
            // 
            this.cbQualityLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQualityLevel.FormattingEnabled = true;
            this.cbQualityLevel.Location = new System.Drawing.Point(180, 12);
            this.cbQualityLevel.Name = "cbQualityLevel";
            this.cbQualityLevel.Size = new System.Drawing.Size(137, 21);
            this.cbQualityLevel.TabIndex = 1;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(180, 39);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(137, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // chkSetJPGQualityLevel
            // 
            this.chkSetJPGQualityLevel.AutoSize = true;
            this.chkSetJPGQualityLevel.Checked = true;
            this.chkSetJPGQualityLevel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSetJPGQualityLevel.Location = new System.Drawing.Point(12, 14);
            this.chkSetJPGQualityLevel.Name = "chkSetJPGQualityLevel";
            this.chkSetJPGQualityLevel.Size = new System.Drawing.Size(162, 17);
            this.chkSetJPGQualityLevel.TabIndex = 3;
            this.chkSetJPGQualityLevel.Text = "Set all JPGs to Quality Level:";
            this.chkSetJPGQualityLevel.UseVisualStyleBackColor = true;
            // 
            // frmQuickAdjustments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 74);
            this.Controls.Add(this.chkSetJPGQualityLevel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cbQualityLevel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmQuickAdjustments";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quick Adjustments";
            this.Load += new System.EventHandler(this.frmQuickAdjustments_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbQualityLevel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.CheckBox chkSetJPGQualityLevel;
    }
}
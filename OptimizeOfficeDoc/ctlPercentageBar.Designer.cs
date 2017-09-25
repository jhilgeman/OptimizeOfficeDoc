namespace OptimizeOfficeDoc
{
    partial class ctlPercentageBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.pnlPercentage = new System.Windows.Forms.Panel();
            this.lblPercentOutside = new System.Windows.Forms.Label();
            this.lblPercentInside = new System.Windows.Forms.Label();
            this.pnlTotal.SuspendLayout();
            this.pnlPercentage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.Color.White;
            this.pnlTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotal.Controls.Add(this.lblPercentOutside);
            this.pnlTotal.Controls.Add(this.pnlPercentage);
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTotal.Location = new System.Drawing.Point(0, 0);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(266, 21);
            this.pnlTotal.TabIndex = 0;
            // 
            // pnlPercentage
            // 
            this.pnlPercentage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pnlPercentage.Controls.Add(this.lblPercentInside);
            this.pnlPercentage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPercentage.Location = new System.Drawing.Point(0, 0);
            this.pnlPercentage.Name = "pnlPercentage";
            this.pnlPercentage.Size = new System.Drawing.Size(19, 19);
            this.pnlPercentage.TabIndex = 0;
            // 
            // lblPercentOutside
            // 
            this.lblPercentOutside.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPercentOutside.AutoSize = true;
            this.lblPercentOutside.Location = new System.Drawing.Point(25, 2);
            this.lblPercentOutside.Margin = new System.Windows.Forms.Padding(3);
            this.lblPercentOutside.Name = "lblPercentOutside";
            this.lblPercentOutside.Size = new System.Drawing.Size(10, 13);
            this.lblPercentOutside.TabIndex = 1;
            this.lblPercentOutside.Text = "-";
            // 
            // lblPercentInside
            // 
            this.lblPercentInside.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPercentInside.AutoSize = true;
            this.lblPercentInside.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentInside.ForeColor = System.Drawing.Color.White;
            this.lblPercentInside.Location = new System.Drawing.Point(6, 2);
            this.lblPercentInside.Margin = new System.Windows.Forms.Padding(3);
            this.lblPercentInside.Name = "lblPercentInside";
            this.lblPercentInside.Size = new System.Drawing.Size(10, 13);
            this.lblPercentInside.TabIndex = 2;
            this.lblPercentInside.Text = "-";
            // 
            // ctlPercentageBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTotal);
            this.Name = "ctlPercentageBar";
            this.Size = new System.Drawing.Size(266, 21);
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            this.pnlPercentage.ResumeLayout(false);
            this.pnlPercentage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblPercentOutside;
        private System.Windows.Forms.Panel pnlPercentage;
        private System.Windows.Forms.Label lblPercentInside;
    }
}

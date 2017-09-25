namespace OptimizeOfficeDoc
{
    partial class ImageWorkUI
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
                Original.Dispose();
                Optimized.Dispose();
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
            this.tlpImageOptimizations = new System.Windows.Forms.TableLayoutPanel();
            this.pbOptimized = new System.Windows.Forms.PictureBox();
            this.pbOriginal = new System.Windows.Forms.PictureBox();
            this.pnlOptimizeSettings = new System.Windows.Forms.Panel();
            this.tlpPreviewSettings = new System.Windows.Forms.TableLayoutPanel();
            this.cbResolutions = new System.Windows.Forms.ComboBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.lblFormatSettings = new System.Windows.Forms.Label();
            this.pnlFormats = new System.Windows.Forms.Panel();
            this.cbFormats = new System.Windows.Forms.ComboBox();
            this.pnlOriginalImageHeader = new System.Windows.Forms.Panel();
            this.lblOriginalImage = new System.Windows.Forms.Label();
            this.pnlOptimizedImageHeader = new System.Windows.Forms.Panel();
            this.lblOptimizedImage = new System.Windows.Forms.Label();
            this.lblOriginalFormat = new System.Windows.Forms.Label();
            this.tlpImageOptimizations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOptimized)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginal)).BeginInit();
            this.pnlOptimizeSettings.SuspendLayout();
            this.tlpPreviewSettings.SuspendLayout();
            this.pnlFormats.SuspendLayout();
            this.pnlOriginalImageHeader.SuspendLayout();
            this.pnlOptimizedImageHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpImageOptimizations
            // 
            this.tlpImageOptimizations.AutoSize = true;
            this.tlpImageOptimizations.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpImageOptimizations.ColumnCount = 2;
            this.tlpImageOptimizations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpImageOptimizations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpImageOptimizations.Controls.Add(this.lblOriginalFormat, 0, 2);
            this.tlpImageOptimizations.Controls.Add(this.pbOptimized, 1, 1);
            this.tlpImageOptimizations.Controls.Add(this.pbOriginal, 0, 1);
            this.tlpImageOptimizations.Controls.Add(this.pnlOptimizeSettings, 1, 2);
            this.tlpImageOptimizations.Controls.Add(this.pnlOriginalImageHeader, 0, 0);
            this.tlpImageOptimizations.Controls.Add(this.pnlOptimizedImageHeader, 1, 0);
            this.tlpImageOptimizations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpImageOptimizations.Location = new System.Drawing.Point(0, 0);
            this.tlpImageOptimizations.Name = "tlpImageOptimizations";
            this.tlpImageOptimizations.RowCount = 3;
            this.tlpImageOptimizations.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpImageOptimizations.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpImageOptimizations.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpImageOptimizations.Size = new System.Drawing.Size(836, 231);
            this.tlpImageOptimizations.TabIndex = 5;
            // 
            // pbOptimized
            // 
            this.pbOptimized.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbOptimized.Location = new System.Drawing.Point(421, 34);
            this.pbOptimized.Name = "pbOptimized";
            this.pbOptimized.Size = new System.Drawing.Size(412, 132);
            this.pbOptimized.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOptimized.TabIndex = 5;
            this.pbOptimized.TabStop = false;
            // 
            // pbOriginal
            // 
            this.pbOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbOriginal.Location = new System.Drawing.Point(3, 34);
            this.pbOriginal.MaximumSize = new System.Drawing.Size(100, 100);
            this.pbOriginal.Name = "pbOriginal";
            this.pbOriginal.Size = new System.Drawing.Size(100, 100);
            this.pbOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOriginal.TabIndex = 3;
            this.pbOriginal.TabStop = false;
            // 
            // pnlOptimizeSettings
            // 
            this.pnlOptimizeSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOptimizeSettings.AutoSize = true;
            this.pnlOptimizeSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlOptimizeSettings.Controls.Add(this.tlpPreviewSettings);
            this.pnlOptimizeSettings.Location = new System.Drawing.Point(421, 172);
            this.pnlOptimizeSettings.Name = "pnlOptimizeSettings";
            this.pnlOptimizeSettings.Size = new System.Drawing.Size(412, 56);
            this.pnlOptimizeSettings.TabIndex = 7;
            // 
            // tlpPreviewSettings
            // 
            this.tlpPreviewSettings.AutoSize = true;
            this.tlpPreviewSettings.ColumnCount = 2;
            this.tlpPreviewSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPreviewSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPreviewSettings.Controls.Add(this.cbResolutions, 1, 1);
            this.tlpPreviewSettings.Controls.Add(this.lblFormat, 0, 0);
            this.tlpPreviewSettings.Controls.Add(this.lblFormatSettings, 0, 1);
            this.tlpPreviewSettings.Controls.Add(this.pnlFormats, 1, 0);
            this.tlpPreviewSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPreviewSettings.Location = new System.Drawing.Point(0, 0);
            this.tlpPreviewSettings.Name = "tlpPreviewSettings";
            this.tlpPreviewSettings.RowCount = 2;
            this.tlpPreviewSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPreviewSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPreviewSettings.Size = new System.Drawing.Size(412, 56);
            this.tlpPreviewSettings.TabIndex = 0;
            // 
            // cbResolutions
            // 
            this.cbResolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbResolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResolutions.FormattingEnabled = true;
            this.cbResolutions.Location = new System.Drawing.Point(69, 32);
            this.cbResolutions.Name = "cbResolutions";
            this.cbResolutions.Size = new System.Drawing.Size(340, 21);
            this.cbResolutions.TabIndex = 3;
            // 
            // lblFormat
            // 
            this.lblFormat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(3, 8);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(42, 13);
            this.lblFormat.TabIndex = 0;
            this.lblFormat.Text = "Format:";
            // 
            // lblFormatSettings
            // 
            this.lblFormatSettings.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFormatSettings.AutoSize = true;
            this.lblFormatSettings.Location = new System.Drawing.Point(3, 36);
            this.lblFormatSettings.Name = "lblFormatSettings";
            this.lblFormatSettings.Size = new System.Drawing.Size(60, 13);
            this.lblFormatSettings.TabIndex = 1;
            this.lblFormatSettings.Text = "Resolution:";
            // 
            // pnlFormats
            // 
            this.pnlFormats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFormats.Controls.Add(this.cbFormats);
            this.pnlFormats.Location = new System.Drawing.Point(69, 3);
            this.pnlFormats.Name = "pnlFormats";
            this.pnlFormats.Size = new System.Drawing.Size(340, 23);
            this.pnlFormats.TabIndex = 2;
            // 
            // cbFormats
            // 
            this.cbFormats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormats.FormattingEnabled = true;
            this.cbFormats.Location = new System.Drawing.Point(0, 0);
            this.cbFormats.Name = "cbFormats";
            this.cbFormats.Size = new System.Drawing.Size(340, 21);
            this.cbFormats.TabIndex = 1;
            // 
            // pnlOriginalImageHeader
            // 
            this.pnlOriginalImageHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOriginalImageHeader.AutoSize = true;
            this.pnlOriginalImageHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlOriginalImageHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pnlOriginalImageHeader.Controls.Add(this.lblOriginalImage);
            this.pnlOriginalImageHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlOriginalImageHeader.Name = "pnlOriginalImageHeader";
            this.pnlOriginalImageHeader.Padding = new System.Windows.Forms.Padding(6);
            this.pnlOriginalImageHeader.Size = new System.Drawing.Size(412, 25);
            this.pnlOriginalImageHeader.TabIndex = 9;
            // 
            // lblOriginalImage
            // 
            this.lblOriginalImage.AutoSize = true;
            this.lblOriginalImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOriginalImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriginalImage.ForeColor = System.Drawing.Color.White;
            this.lblOriginalImage.Location = new System.Drawing.Point(6, 6);
            this.lblOriginalImage.Name = "lblOriginalImage";
            this.lblOriginalImage.Size = new System.Drawing.Size(88, 13);
            this.lblOriginalImage.TabIndex = 0;
            this.lblOriginalImage.Text = "Original Image";
            this.lblOriginalImage.Click += new System.EventHandler(this.lblOriginalImage_Click);
            // 
            // pnlOptimizedImageHeader
            // 
            this.pnlOptimizedImageHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOptimizedImageHeader.AutoSize = true;
            this.pnlOptimizedImageHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlOptimizedImageHeader.BackColor = System.Drawing.Color.Blue;
            this.pnlOptimizedImageHeader.Controls.Add(this.lblOptimizedImage);
            this.pnlOptimizedImageHeader.Location = new System.Drawing.Point(421, 3);
            this.pnlOptimizedImageHeader.Name = "pnlOptimizedImageHeader";
            this.pnlOptimizedImageHeader.Padding = new System.Windows.Forms.Padding(6);
            this.pnlOptimizedImageHeader.Size = new System.Drawing.Size(412, 25);
            this.pnlOptimizedImageHeader.TabIndex = 10;
            // 
            // lblOptimizedImage
            // 
            this.lblOptimizedImage.AutoSize = true;
            this.lblOptimizedImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOptimizedImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptimizedImage.ForeColor = System.Drawing.Color.White;
            this.lblOptimizedImage.Location = new System.Drawing.Point(6, 6);
            this.lblOptimizedImage.Name = "lblOptimizedImage";
            this.lblOptimizedImage.Size = new System.Drawing.Size(100, 13);
            this.lblOptimizedImage.TabIndex = 1;
            this.lblOptimizedImage.Text = "Optimized Image";
            // 
            // lblOriginalFormat
            // 
            this.lblOriginalFormat.AutoSize = true;
            this.lblOriginalFormat.Location = new System.Drawing.Point(3, 169);
            this.lblOriginalFormat.Name = "lblOriginalFormat";
            this.lblOriginalFormat.Size = new System.Drawing.Size(0, 13);
            this.lblOriginalFormat.TabIndex = 8;
            // 
            // ImageWorkUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tlpImageOptimizations);
            this.Name = "ImageWorkUI";
            this.Size = new System.Drawing.Size(836, 231);
            this.tlpImageOptimizations.ResumeLayout(false);
            this.tlpImageOptimizations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOptimized)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginal)).EndInit();
            this.pnlOptimizeSettings.ResumeLayout(false);
            this.pnlOptimizeSettings.PerformLayout();
            this.tlpPreviewSettings.ResumeLayout(false);
            this.tlpPreviewSettings.PerformLayout();
            this.pnlFormats.ResumeLayout(false);
            this.pnlOriginalImageHeader.ResumeLayout(false);
            this.pnlOriginalImageHeader.PerformLayout();
            this.pnlOptimizedImageHeader.ResumeLayout(false);
            this.pnlOptimizedImageHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpImageOptimizations;
        private System.Windows.Forms.PictureBox pbOptimized;
        private System.Windows.Forms.Label lblOptimizedImage;
        private System.Windows.Forms.PictureBox pbOriginal;
        private System.Windows.Forms.Label lblOriginalImage;
        private System.Windows.Forms.Panel pnlOptimizeSettings;
        private System.Windows.Forms.TableLayoutPanel tlpPreviewSettings;
        private System.Windows.Forms.ComboBox cbResolutions;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.Label lblFormatSettings;
        private System.Windows.Forms.Panel pnlFormats;
        private System.Windows.Forms.ComboBox cbFormats;
        private System.Windows.Forms.Panel pnlOriginalImageHeader;
        private System.Windows.Forms.Panel pnlOptimizedImageHeader;
        private System.Windows.Forms.Label lblOriginalFormat;
    }
}

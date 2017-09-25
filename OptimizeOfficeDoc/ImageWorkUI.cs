using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OptimizeOfficeDoc
{
    public partial class ImageWorkUI : UserControl, IDisposable
    {
        // public string fileName;
        public XmlNode RelationshipNode;

        public ImageWithInfo Original;
        public ImageWithInfo Optimized;

        public bool Changed
        {
            get
            {
                return (_currentFormatPreset != FormatPreset.Original);
            }
        }

        public event EventHandler OptimizedChanged;

        private FormatPreset _currentFormatPreset;
        private ResolutionPreset _currentResolutionPreset;

        public void SetJPEGQuality(int QualityLevel)
        {
            if(_currentFormatPreset.FormatName == "JPG")
            {
                FormatPreset result = FormatPreset.ComboBoxOptions.FirstOrDefault(opt => (opt.FormatName == "JPG") && (opt.QualityLevel == QualityLevel));
                if(result == null)
                {
                    // Find nearest %
                    int NewQualityLevel = (int)((float)Math.Round(QualityLevel / (float)10) * 10);
                    SetJPEGQuality(NewQualityLevel);
                    //result = new FormatPreset("JPEG " + QualityLevel + "%", "JPG", QualityLevel, 24);
                    //FormatPreset.ComboBoxOptions.Add(result);
                    return;
                }
                cbFormats.SelectedItem = result;
            }
        }

//        public long dstImageFileSize;

        public long SizeDifference
        {
            get
            {
                return Original.FileSize - Optimized.FileSize;
            }
        }

        private bool _Initialized = false;
        private bool Initialized
        {
            get
            {
                return _Initialized;
            }
            set
            {
                // Only let it be initialized once
                if (_Initialized == true) { return; }
                _Initialized = value;

                // When we change initialized to true, trigger the optimized preview update
                if(_Initialized == true)
                {
                    updatePreview();
                    cbFormats.SelectedIndexChanged += cbFormats_SelectedIndexChanged;
                    cbResolutions.SelectedIndexChanged += cbResolutions_SelectedIndexChanged;
                    this.Resize += ImageWorkUI_Resize;
                }
            }
        }

        private void ImageWorkUI_Resize(object sender, EventArgs e)
        {
            int[] scaledSizes = Original.GetScaledSizeFromWidth(pbOriginal.Size.Width);
            pbOriginal.Size = new Size(scaledSizes[0], scaledSizes[1]);
            pbOptimized.Size = new Size(scaledSizes[0], scaledSizes[1]);

        }

        public ImageWorkUI()
        {
            InitializeComponent();

            cbFormats.DataSource = new BindingSource(FormatPreset.ComboBoxOptions, null);
            cbFormats.DisplayMember = "Name";
            _currentFormatPreset = FormatPreset.Original;

            cbResolutions.DataSource = new BindingSource(ResolutionPreset.ComboBoxOptions, null);
            cbResolutions.DisplayMember = "Name";
            _currentResolutionPreset = ResolutionPreset.Original;
        }

        public ImageWorkUI(string imageFile, XmlNode relationshipXmlNode) : this()
        {
            Original = new ImageWithInfo(imageFile);
            Optimized = Original;

            this.RelationshipNode = relationshipXmlNode;

            // Automatic recommendation - set the upper max resolution to 1600x900 and change to 80% JPEG
            if ((Original.Width > 1600) || (Original.Height > 900))
            {
                _currentResolutionPreset = ResolutionPreset.ComboBoxOptions.First(opt => (opt.Width == 1600) && (opt.Height == 900));
                _currentFormatPreset = FormatPreset.ComboBoxOptions.First(opt => (opt.FormatName == "JPG") && (opt.QualityLevel == 80));
            }
            cbResolutions.SelectedItem = _currentResolutionPreset;

            // Automatic recommendation - if pixel-byte density is higher than 20% and the format is PNG, convert to a 70% JPG
            if ((Original.BytesPerPixel > 0.2) && (Original.Type == ImageWithInfo.ImageTypes.Png) && (_currentFormatPreset == FormatPreset.Original))
            {
                _currentFormatPreset = FormatPreset.ComboBoxOptions.First(opt => (opt.FormatName == "JPG") && (opt.QualityLevel == 70));
            }

            // If we're scaling a JPG, try to preserve the quality (use 80% instead of 70%)
            //if ((_currentResolutionPreset != ResolutionPreset.Original) && (Original.Type == ImageWithInfo.ImageTypes.Jpg))
            //{
            //    _currentFormatPreset = FormatPreset.ComboBoxOptions.First(opt => (opt.FormatName == "JPG") && (opt.QualityLevel == 80));
            //}

            cbFormats.SelectedItem = _currentFormatPreset;

            // Set up originals
            pbOriginal.Image = Original.Image;
            pbOptimized.Image = Original.Image; // This will get updated with the optimized image when initialization is done
            pbOriginal.MaximumSize = new Size(Original.Width, Original.Height);
            pbOptimized.MaximumSize = pbOriginal.MaximumSize;
            int[] scaledSizes = Original.GetScaledSizeFromWidth(pbOriginal.Size.Width);
            pbOriginal.Size = new Size(scaledSizes[0], scaledSizes[1]);
            pbOptimized.Size = new Size(scaledSizes[0], scaledSizes[1]);

            // Populate info about the original file
            lblOriginalImage.Text = "Original Image: " + Original.GetShortInfo();

            // Finished
            Initialized = true;
        }
        

        #region UI Interaction
        private void cbFormats_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentFormatPreset = (FormatPreset)cbFormats.SelectedItem;
            if (Initialized)
            {
                updatePreview();
            }
        }

        private void cbResolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentResolutionPreset = (ResolutionPreset)cbResolutions.SelectedItem;
            if (Initialized)
            {
                updatePreview();
            }
        }

        private void updatePreview()
        {
            if ((_currentFormatPreset == FormatPreset.Original) && (_currentResolutionPreset == ResolutionPreset.Original))
            {
                Optimized = Original;
            }
            else
            {
                if (_currentFormatPreset.FormatName == "PNG")
                {
                    Optimized = Original.GenerateOptimized_PNG(_currentFormatPreset.ColorDepth, _currentResolutionPreset);
                }
                else if (_currentFormatPreset.FormatName == "JPG")
                {
                    Optimized = Original.GenerateOptimized_JPEG(_currentFormatPreset.QualityLevel, _currentResolutionPreset);
                }
                else
                {
                    // Original format, but scaled
                    Optimized = Original.GenerateOptimized_JPEG(100, _currentResolutionPreset);
                }
            }

            pbOptimized.Image = Optimized.Image;
            pbOptimized.MaximumSize = new Size(Optimized.Width, Optimized.Height);
            lblOptimizedImage.Text = "Optimized Image: " + Optimized.GetShortInfo();

            if (OptimizedChanged != null)
            {
                OptimizedChanged(this, new EventArgs());
            }

        }

        #endregion

        private void lblOriginalImage_Click(object sender, EventArgs e)
        {

        }
    }
}

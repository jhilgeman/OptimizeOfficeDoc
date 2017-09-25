using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimizeOfficeDoc
{
    public partial class frmQuickAdjustments : Form
    {
        private List<ImageWorkUI> imageWorkUIs;

        public frmQuickAdjustments()
        {
            InitializeComponent();
        }

        public frmQuickAdjustments(List<ImageWorkUI> imageWorkUIs) : this()
        {
            this.imageWorkUIs = imageWorkUIs;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if(chkSetJPGQualityLevel.Checked)
            {
                FormatPreset format = (FormatPreset)cbQualityLevel.SelectedItem;
                foreach (ImageWorkUI iwui in imageWorkUIs)
                {
                    // SetJPEGQuality only applies to JPEGs
                    iwui.SetJPEGQuality((int)format.QualityLevel);
                }
            }
            this.Close();
        }

        private void frmQuickAdjustments_Load(object sender, EventArgs e)
        {
            List<FormatPreset> jpgOptions = FormatPreset.ComboBoxOptions.Where(x => x.FormatName == "JPG").ToList();
            cbQualityLevel.DataSource = new BindingSource(jpgOptions, null);
            cbQualityLevel.DisplayMember = "Name";
            cbQualityLevel.SelectedItem = jpgOptions.First(opt => (opt.FormatName == "JPG") && (opt.QualityLevel == 70));
        }
    }
}

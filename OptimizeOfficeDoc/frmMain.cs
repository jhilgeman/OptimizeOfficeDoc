using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace OptimizeOfficeDoc
{
    public partial class frmMain : Form
    {
        // Stores the work in progress
        OfficeDocument workDocument;

        public frmMain()
        {
            InitializeComponent();

            // Initialize optimization presets
            FormatPreset.ComboBoxOptions.Add(new FormatPreset("Preserve Original", "SRC", null, null));
            FormatPreset.ComboBoxOptions.Add(new FormatPreset("PNG 8-bit", "PNG", null, 8));
            FormatPreset.ComboBoxOptions.Add(new FormatPreset("PNG 24-bit", "PNG", null, 24));
            for (long i = 100; i >= 0; i -= 5)
            {
                FormatPreset.ComboBoxOptions.Add(new FormatPreset("JPEG " + i + "%", "JPG", i, 24));
            }

            // Initialize resolution presets
            ResolutionPreset.ComboBoxOptions.Add(new ResolutionPreset("Preserve Original", -1, -1));
            ResolutionPreset.ComboBoxOptions.Add(new ResolutionPreset("Up to 1920x1080"));
            ResolutionPreset.ComboBoxOptions.Add(new ResolutionPreset("Up to 1600x900"));
            ResolutionPreset.ComboBoxOptions.Add(new ResolutionPreset("Up to 1024x768"));
            ResolutionPreset.ComboBoxOptions.Add(new ResolutionPreset("Up to 800x600"));
            ResolutionPreset.ComboBoxOptions.Add(new ResolutionPreset("Up to 640x480"));
            ResolutionPreset.ComboBoxOptions.Add(new ResolutionPreset("Up to 320x200"));

            // Initialize status controls
            Status.Initialize(lblStatus, pbStatus);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ctlPercentageBar1.Total = 100;
            ctlPercentageBar1.Value = 100;
        }


        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }

        List<ImageWorkUI> imageWorkUIs;
        private void AddImageWorkUIsToLayout(OfficeDocument doc)
        {
            imageWorkUIs = _getAllImageWorkUIs(doc);
            imageWorkUIs = imageWorkUIs.OrderBy(x => x.Original.FileSize).ToList();

            // Add the results to the UI
            int count = 0;
            int totalImagesFound = imageWorkUIs.Count;

            // Determine how much the progress bar advances for each image
            Status.SetProgress(0);
            float stepProgress = 100 / (float)totalImagesFound;
            float floatProgress = 0;
            int intProgress = 0;

            foreach (ImageWorkUI iwui in imageWorkUIs)
            {
                count++;
                iwui.Dock = DockStyle.Top;
                pnlImageWorkUIs.Controls.Add(iwui);

                Status.SetStatus("Adding image optimizers to layout... " + count + " of " + totalImagesFound);
                statusStrip1.Invalidate();
                statusStrip1.Refresh();

                // Hook into their changed events
                iwui.OptimizedChanged += Iwui_OptimizedChanged;

                // Update progress
                floatProgress += stepProgress;
                if (intProgress != (int)floatProgress)
                {
                    intProgress = (int)floatProgress;
                    Status.SetProgress(intProgress);
                }
            }
        }

        private List<ImageWorkUI> _getAllImageWorkUIs(OfficeDocument doc, List<ImageWorkUI> results = null)
        {
            if(results == null)
            {
                results = new List<ImageWorkUI>();
            }
            foreach (XmlRelsDoc xmlRelDoc in doc.XmlRelsDocs)
            {
                foreach (ImageWorkUI iwui in xmlRelDoc.ImageWorkUIs.Values)
                {
                    iwui.Dock = DockStyle.Top;
                    results.Add(iwui);
                }
            }

            // Recurse into embedded documents
            foreach (OfficeDocument embeddedDocument in doc.EmbeddedDocuments)
            {
                _getAllImageWorkUIs(embeddedDocument, results);
            }

            return results;
        }

        private void Iwui_OptimizedChanged(object sender, EventArgs e)
        {
            // Recalculate
            _updateResults();
        }

        private void _updateResults()
        {
            Console.WriteLine("_updateResults");

            long sizeSavings = 0;
            foreach (ImageWorkUI iwui in imageWorkUIs)
            {
                if (iwui.Changed)
                {
                    sizeSavings += iwui.SizeDifference;
                }
            }

            lblTotalOriginalSize.Text = "Original Size: " + Helpers.SizeSuffix(workDocument.Size);
            lblTotalOptimizedSize.Text = "Estimated Optimized Size: " + Helpers.SizeSuffix(workDocument.Size - sizeSavings);

            ctlPercentageBar1.Total = workDocument.Size;
            ctlPercentageBar1.Value = (workDocument.Size - sizeSavings);
        }

        private async void btnOptimize_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure the file exists
                txtFile.Text = txtFile.Text.Trim();
                if (!File.Exists(txtFile.Text))
                {
                    throw new FileNotFoundException("That file does not exist!", txtFile.Text);
                }

                // Okay, start by disabling the controls
                btnOptimize.Enabled = false;
                txtFile.Enabled = false;

                // Now unpack the document recursively
                workDocument = new OfficeDocument(txtFile.Text);
                await workDocument.Unpack();
                Status.SetProgress(50);

                // Now recursively search for potentially-optimizable components
                await Task.Run(() => workDocument.SearchForOptimizationOpportunities());

                // Add the controls to the layout
                imageWorkUIs = new List<ImageWorkUI>();
                SuspendDrawing(pnlContents);
                AddImageWorkUIsToLayout(workDocument);
                pnlResults.Visible = true;
                ResumeDrawing(pnlContents);
                _updateResults();

                Status.SetStatus("Finished.", 0);

            }
            catch (Exception ex)
            {
                btnOptimize.Enabled = true;
                txtFile.Enabled = true;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string extension = Path.GetExtension(workDocument.File);
            string filenameWithoutExtension = Path.GetFileNameWithoutExtension(workDocument.File);
            string path = new FileInfo(workDocument.File).DirectoryName;

            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = extension.Substring(1) + " files (*" + extension + ")|*" + extension + "|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                InitialDirectory = path,
                FileName = path + "\\" + filenameWithoutExtension + " (Optimized)" + extension
            };

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string originalSize = Helpers.SizeSuffix(new FileInfo(workDocument.File).Length);
                    workDocument.Repack(sfd.FileName); //  path + "\\" + filenameWithoutExtension + " (Optimized)workDocument.File);

                    if (File.Exists(sfd.FileName))
                    {
                        long finalSize = new FileInfo(sfd.FileName).Length;
                        if (MessageBox.Show("Successfully optimized the document.\r\n\r\nOriginal Size: " + originalSize + "\r\nOptimized Size: " + Helpers.SizeSuffix(finalSize) + "\r\n\r\nWould you like to open the optimized file?",
                            "Optimization Complete",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            Process.Start(sfd.FileName);
                        }
                    }

                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error while saving the optimized document: " + ex.Message, "Error While Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



            
        }

        private void Reset()
        {
            pnlContents.Controls.Clear();
            txtFile.Text = "";
            btnOptimize.Enabled = true;
            txtFile.Enabled = true;
            pnlResults.Visible = false;
            imageWorkUIs.Clear();
            workDocument.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trkGlobalJPEG_Scroll(object sender, EventArgs e)
        {

        }

        private void txtFile_TextChanged(object sender, EventArgs e)
        {
            btnOptimize.Enabled = File.Exists(txtFile.Text);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Word (*.docx)|*.docx|Excel (*.xlsx)|*.xlsx|PowerPoint (*.pptx)|*.pptx|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofd.FileName;
            }
        }

        private void btnQuickAdjustments_Click(object sender, EventArgs e)
        {
            frmQuickAdjustments frmQA = new frmQuickAdjustments(imageWorkUIs);
            frmQA.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OptimizeOfficeDoc
{
    public class OfficeDocument : IDisposable
    {
        private static string[] officeDocExtensions = new string[] { ".docx", ".xlsx", ".pptx" };


        public string File;
        public string UnpackedFolder;
        public long Size;
        public List<OfficeDocument> EmbeddedDocuments = new List<OfficeDocument>();
        public List<XmlRelsDoc> XmlRelsDocs = new List<XmlRelsDoc>();

        public OfficeDocument(string File)
        {
            this.File = File;
            this.Size = new FileInfo(File).Length;
        }

        public async Task Unpack()
        {
            // Set the status
            Status.SetStatus("Unpacking " + new FileInfo(File).Name + "...");

            // Create a new temp folder
            do
            {
                UnpackedFolder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            } while (Directory.Exists(UnpackedFolder));


            // Unzip the contents
            await Task.Run(() => Compression.UnZIPFile(File, UnpackedFolder));

            // Search the contents for embedded documents
            Status.SetStatus("Searching for embedded documents...");
            string[] unpackedFiles = Directory.EnumerateFiles(UnpackedFolder, "*", SearchOption.AllDirectories).ToArray();
            foreach (string unpackedFile in unpackedFiles)
            {
                string lcExtension = unpackedFile.Substring(unpackedFile.LastIndexOf('.')).ToLower();
                if (officeDocExtensions.Contains(lcExtension))
                {
                    // Unpack the child document and add it to the list
                    OfficeDocument embeddedDoc = new OfficeDocument(unpackedFile);
                    EmbeddedDocuments.Add(embeddedDoc);
                    await embeddedDoc.Unpack();
                }
            }
        }

        /// <summary>
        /// Ensures that the [Content_Types].xml file understands both JPG and PNG files
        /// </summary>
        private void UpdateContentTypes()
        {
            XmlDocument doc = new XmlDocument() { PreserveWhitespace = true };
            doc.Load(UnpackedFolder + "\\[Content_Types].xml");

            // Get all <Default> nodes
            XmlNode jpgTypeNode = null;
            XmlNode jpegTypeNode = null;
            XmlNode pngTypeNode = null;
            XmlNode defaultNode = null;
            XmlNodeList nodes = doc.SelectNodes("//*[name()='Default']");
            foreach (XmlNode node in nodes)
            {
                defaultNode = node;

                string extension = node.Attributes["Extension"].Value;
                if (extension == "jpg") { jpgTypeNode = node; continue;  }
                if (extension == "jpeg") { jpegTypeNode = node; continue; }
                if (extension == "png") { pngTypeNode = node; continue; }
            }

            XmlNode typesNode = doc.SelectSingleNode("//*[name()='Types']");
            if (jpgTypeNode == null)
            {
                jpgTypeNode = defaultNode.CloneNode(false);
                jpgTypeNode.Attributes["Extension"].Value = "jpg";
                jpgTypeNode.Attributes["ContentType"].Value = "image/jpeg";
                typesNode.AppendChild(jpgTypeNode);
            }
            if (jpegTypeNode == null)
            {
                jpegTypeNode = defaultNode.CloneNode(false);
                jpegTypeNode.Attributes["Extension"].Value = "jpeg";
                jpegTypeNode.Attributes["ContentType"].Value = "image/jpeg";
                typesNode.AppendChild(jpegTypeNode);
            }
            if (pngTypeNode == null)
            {
                pngTypeNode = defaultNode.CloneNode(false);
                pngTypeNode.Attributes["Extension"].Value = "png";
                pngTypeNode.Attributes["ContentType"].Value = "image/png";
                typesNode.AppendChild(pngTypeNode);
            }

            doc.Save(UnpackedFolder + "\\[Content_Types].xml");
        }

        public void Repack(string ToFile = null)
        {
            // First handle any embedded documents (deepest to shallowest)
            foreach(OfficeDocument embeddedDoc in EmbeddedDocuments)
            {
                embeddedDoc.Repack();
            }

            // Make sure the Content Types doc has both PNG and JPG nodes
            UpdateContentTypes();

            // Loop through images and swap them out for their optimized versions
            foreach (XmlRelsDoc xmlRelDoc in XmlRelsDocs)
            {
                bool saveXmlRelDoc = false;
                foreach (string relTarget in xmlRelDoc.ImageWorkUIs.Keys)
                {
                    ImageWorkUI iwui = xmlRelDoc.ImageWorkUIs[relTarget];
                    if (iwui.Changed)
                    {
                        if(iwui.Original.Type != iwui.Optimized.Type)
                        {
                            // Remove original, add optimized
                            iwui.Optimized.FullFilename = iwui.Original.FullFilename.Substring(0, iwui.Original.FullFilename.Length - Path.GetExtension(iwui.Original.FullFilename).Length) + "." + iwui.Optimized.Type.ToString().ToLower();
                            iwui.Optimized.Save();
                            iwui.Original.Delete();

                            // Update target in XML Rels document
                            string relTargetPath = relTarget.Substring(0, relTarget.Length - Path.GetFileName(relTarget).Length);
                            iwui.RelationshipNode.Attributes["Target"].Value = relTargetPath + Path.GetFileName(iwui.Optimized.FullFilename);
                            saveXmlRelDoc = true;
                        }
                        else
                        {
                            // Overwrite original and we're done
                            iwui.Optimized.FullFilename = iwui.Original.FullFilename;
                            iwui.Optimized.Save();
                        }
                    }
                }

                if(saveXmlRelDoc)
                {
                    xmlRelDoc.Document.Save(xmlRelDoc.File);
                }
            }

            // Recreate / rezip original file
            Compression.CreateZIPFile(((ToFile != null) ? ToFile : File), UnpackedFolder);
        }

        public void SearchForOptimizationOpportunities()
        {
            int totalImagesFound = 0;
            XmlRelsDocs = new List<XmlRelsDoc>();

            // Set the status
            Status.SetStatus("Reviewing unpacked contents...");

            // Search for the relationships XML document(s)
            List<string> files = Directory.EnumerateFiles(UnpackedFolder, "*.xml.rels", SearchOption.AllDirectories).ToList<string>();
            foreach (string file in files)
            {
                // Parse the relationships documents (builds the UIs)
                XmlRelsDoc xmlRelsDoc = new XmlRelsDoc(file);
                if (xmlRelsDoc.ImageWorkUIs.Count > 0)
                {
                    totalImagesFound += xmlRelsDoc.ImageWorkUIs.Count;
                    XmlRelsDocs.Add(xmlRelsDoc);
                }
            }

            // Recurse into embedded docs
            foreach (OfficeDocument embeddedDoc in EmbeddedDocuments)
            {
                embeddedDoc.SearchForOptimizationOpportunities();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Dispose embedded docs
                    foreach (OfficeDocument embeddedDoc in EmbeddedDocuments)
                    {
                        embeddedDoc.Dispose();
                    }
                    
                    // Dispose XmlRelDoc
                    foreach(XmlRelsDoc xmlRelDoc in XmlRelsDocs)
                    {
                        xmlRelDoc.Dispose();
                    }

                    // Remove folder
                    Directory.Delete(UnpackedFolder, true);
                    System.Windows.Forms.MessageBox.Show(UnpackedFolder);
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~OfficeDocument() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}

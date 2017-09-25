using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OptimizeOfficeDoc
{
    public class XmlRelsDoc : IDisposable
    {
        public string File;
        public string BaseFolder;
        public Dictionary<string, ImageWorkUI> ImageWorkUIs = new Dictionary<string, ImageWorkUI>();
        public XmlDocument Document;

        private static RelationshipFilter[] relationshipFilters;

        public XmlRelsDoc(string file)
        {
            File = file;
            BaseFolder = new FileInfo(file).Directory.Parent.FullName;
            if(relationshipFilters == null)
            {
                relationshipFilters = new RelationshipFilter[]
                {
                    new RelationshipFilter("image", ".png", 20000),
                    new RelationshipFilter("image", ".jpg", 50000),
                    new RelationshipFilter("image", ".jpeg", 50000),
                };
            }

            // Load the XML document into memory
            Document = new XmlDocument() { PreserveWhitespace = true };
            Document.Load(File);

            // Search for images
            FindAllImages(relationshipFilters);
        }

        /// <summary>
        /// Loop through the relationships XML document and look for relationships that 
        /// have a type ending with "/image", then filter down the results to just 
        /// JPGs and PNGs (or whatever is in imageExensions), and finally skip over
        /// JPEGs that are under 50k and PNGs under 20k.
        /// </summary>
        /// <param name="imageExtensions"></param>
        /// <param name="sizeThreshold"></param>
        private void FindAllImages(RelationshipFilter[] filters)
        {
            XmlNodeList rels = Document.SelectNodes("//*[name()='Relationship']");
            foreach(XmlNode rel in rels)
            {
                string relType = rel.Attributes["Type"].Value;
                string relTarget = rel.Attributes["Target"].Value;
                string fullFile = Path.Combine(BaseFolder, relTarget).Replace("/", @"\");

                foreach (RelationshipFilter filter in filters)
                {
                    if (filter.PassesFilter(relType, fullFile))
                    {
                        ImageWorkUIs.Add(relTarget, new ImageWorkUI(fullFile, rel));
                        break;
                    }
                }
            }
        }

        private class RelationshipFilter
        {
            private int _SizeThreshold;
            private string _FileExtension;
            private string _RelationshipType;

            public RelationshipFilter(string RelationshipType, string FileExtension, int SizeThreshold)
            {
                _RelationshipType = RelationshipType;
                _FileExtension = FileExtension.ToLower();
                _SizeThreshold = SizeThreshold;
            }

            public bool PassesFilter(string relType, string fullFile)
            {
                // Skip files already marked as optimized
                if (fullFile.Contains("_optimized"))
                {
                    return false;
                }
                // Skip files that don't match the relationship type
                if (!relType.EndsWith("/" + _RelationshipType))
                {
                    return false;
                }
                // Skip files that don't match this extension
                if (fullFile.Substring(fullFile.LastIndexOf('.')).ToLower() != _FileExtension)
                {
                    return false;
                }
                // Skip files that are below the file size threshold
                if (new FileInfo(fullFile).Length < _SizeThreshold)
                {
                    return false;
                }
                // Passes all the conditions
                return true;
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
                    Document = null;
                    foreach(ImageWorkUI iwui in ImageWorkUIs.Values)
                    {
                        iwui.Dispose();
                    }
                    ImageWorkUIs.Clear();
                }

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~XmlRelsDoc() {
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

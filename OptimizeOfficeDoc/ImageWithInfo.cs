using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeOfficeDoc
{
    public class ImageWithInfo : IDisposable
    {
        public string Filename;
        public string FullFilename;

        public Bitmap Image;
        private MemoryStream _stream;

        public int Width;
        public int Height;
        public long FileSize;
        public ImageTypes Type;
        public string MimeType;
        public int ColorDepth;
        public double BytesPerPixel;

        public EncoderParameters EncoderParams;

        public enum ImageTypes
        {
            Png,
            Jpg,
            Unknown
        };

        public ImageWithInfo(string file) : this(new MemoryStream(File.ReadAllBytes(file)))
        {
            FullFilename = file;
            Filename = Path.GetFileName(file);
        }

        public ImageWithInfo(MemoryStream stream)
        {
            Image = new Bitmap(stream);
            FileSize = stream.Length;
            _stream = stream;
            _SetParametersFromBitmap();
        }

        private void _SetParametersFromBitmap()
        {
            Width = Image.Width;
            Height = Image.Height;

            ColorDepth = (Image.PixelFormat == PixelFormat.Format8bppIndexed ? 8 : 24); // Yes, there are 16-bit and 32-bit values but we really only care about distinguishing 8-bit PNGs from 24-bit ones

            MimeType = Helpers.GetMimeType(Image);

            if (MimeType == "image/png")
            {
                Type = ImageTypes.Png;
            }
            else if (MimeType == "image/jpeg")
            {
                Type = ImageTypes.Jpg;
            }
            else
            {
                Type = ImageTypes.Unknown;
            }

            BytesPerPixel = (double)FileSize / (double)(Width * Height);
        }

        public string GetShortInfo()
        {
            StringBuilder sb = new StringBuilder();
            if(Type == ImageTypes.Png)
            {
                sb.Append(ColorDepth + "-bit PNG");
            }
            else if(Type == ImageTypes.Jpg)
            {
                sb.Append("JPG");
            }
            else
            {
                sb.Append("???");
            }
            sb.Append(", ");
            sb.Append(Width);
            sb.Append("x");
            sb.Append(Height);
            sb.Append(", ");
            sb.Append(Helpers.SizeSuffix(FileSize));
            return sb.ToString();
        }

        public void Save()
        {
            if(!string.IsNullOrEmpty(FullFilename))
            {
                EncoderParameters toFormatParams = new EncoderParameters(1);
                toFormatParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);

                Image.Save(Path.GetFullPath(FullFilename), _jpgEncoder, toFormatParams);
            }
        }

        public void Delete()
        {
            if (!string.IsNullOrEmpty(FullFilename))
            {
                File.Delete(Path.GetFullPath(FullFilename));
            }
        }

        #region Static - Image Codecs/Encoders
        private static ImageCodecInfo _jpgEncoder;
        private static ImageCodecInfo _pngEncoder;

        private static void _initEncoderInfo()
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == "image/jpeg")
                {
                    _jpgEncoder = encoders[j];
                }
                else if (encoders[j].MimeType == "image/png")
                {
                    _pngEncoder = encoders[j];
                }
            }
        }
        #endregion


        public ImageWithInfo GenerateOptimized_JPEG(long QualityLevel, ResolutionPreset Resolution)
        {
            // Initialize encoders
            if (_jpgEncoder == null)
            {
                _initEncoderInfo();
            }

            EncoderParameters toFormatParams = new EncoderParameters(1);
            toFormatParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, QualityLevel);

            MemoryStream ms = new MemoryStream();
            Bitmap scaledImage = Image;
            if (Resolution.Width > 0)
            {
                scaledImage = GetScaledImage(Resolution);
            }
            scaledImage.Save(ms, _jpgEncoder, toFormatParams);

            return new ImageWithInfo(ms);
        }

        public ImageWithInfo GenerateOptimized_PNG(long BitDepth, ResolutionPreset Resolution)
        {
            // Initialize encoders
            if (_pngEncoder == null)
            {
                _initEncoderInfo();
            }

            EncoderParameters toFormatParams = new EncoderParameters(1);
            toFormatParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.ColorDepth, BitDepth);

            MemoryStream ms = new MemoryStream();
            Bitmap scaledImage = Image;
            if (Resolution.Width > 0)
            {
                scaledImage = GetScaledImage(Resolution);
            }
            scaledImage.Save(ms, _pngEncoder, toFormatParams);

            return new ImageWithInfo(ms);
        }

        #region Scaling and Preview Methods

        public int[] GetScaledSizeFromWidth(float maxWidth)
        {
            // Allow scaling down but prevent scaling up (we don't want to increase file size!)
            float scale = Math.Min(1, maxWidth / Width);

            // If we're not scaling down, just skip the rest of the process
            if (scale == 1)
            {
                return new int[] { Width, Height };
            }

            // If we're scaling down, calculate the new width/height
            int scaledWidth = (int)(Width * scale);
            int scaledHeight = (int)(Height * scale);
            return new int[] { scaledWidth, scaledHeight };
        }

        public Bitmap GetScaledImage(ResolutionPreset Resolution)
        {
            // Set our maximum height/width
            float maxWidth = Resolution.Width;
            float maxHeight = Resolution.Height;

            // Allow scaling down but prevent scaling up (we don't want to increase file size!)
            float scale = Math.Min(1, Math.Min(maxWidth / Width, maxHeight / Height));

            // If we're not scaling down, just skip the rest of the process
            if (scale == 1)
            {
                return Image;
            }

            // If we're scaling down, calculate the new width/height
            int scaledWidth = (int)(Width * scale);
            int scaledHeight = (int)(Height * scale);

            // Create a target, empty image with the new size
            Bitmap scaledImage = new Bitmap((int)scaledWidth, (int)scaledHeight);
            using (Graphics g = Graphics.FromImage(scaledImage))
            {
                // Use the highest quality scaling operations available
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.High;
                g.CompositingQuality = CompositingQuality.HighQuality;

                // Fill in our background with black
                g.FillRectangle(Brushes.Black, new RectangleF(0, 0, scaledWidth, scaledHeight));

                // Copy our scaled image into place
                g.DrawImage(Image, new Rectangle(0, 0, scaledWidth, scaledHeight));
            }

            // Return the result
            return scaledImage;
        }


        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _stream.Dispose();
                    Image.Dispose();
                    _stream = null;
                    Image = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ImageWithInfo() {
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

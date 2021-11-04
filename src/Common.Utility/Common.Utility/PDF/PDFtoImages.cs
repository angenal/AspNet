using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Ghostscript.NET;
using Ghostscript.NET.Rasterizer;

namespace Common.Utility
{
    /// <summary>
    /// Pdf文件转换成图片文件
    /// </summary>
    public class PDFtoImages
    {
        /// <summary>
        /// 转换器
        /// </summary>
        public static PDFtoImages Converter;

        /// <summary>
        /// Pdf文件转换成图片文件
        /// </summary>
        /// <param name="pdfPath">Pdf文件</param>
        /// <param name="imgPath">图片文件保存目录</param>
        /// <param name="imgFile">图片文件名称前缀</param>
        /// <returns>图片文件数量</returns>
        public static int SavePDFToImages(string pdfPath, string imgPath = "", string imgFile = "")
        {
            var images = Converter.ConvertPDFToImages(pdfPath);
            int count = images.Count();
            if (count > 0)
            {
                string dir = !string.IsNullOrEmpty(imgPath) ? imgPath : Path.GetDirectoryName(pdfPath);
                string file = !string.IsNullOrEmpty(imgFile) ? imgFile : Path.GetFileNameWithoutExtension(pdfPath);
                for (int num = 0; num < count; num++)
                {
                    var img = images.ElementAt(num);
                    string str = Path.Combine(dir, string.Format("{0}_{1}", file, num + 1) + ".jpg");
                    img.Save(str, ImageFormat.Jpeg);
                    img.Dispose();
                }
            }
            return count;
        }

        public IEnumerable<Image> ConvertPDFToImages(string pdfPath)
        {
            IEnumerable<Image> retorno = new List<Image>();
            Task.Factory.StartNew(delegate
            {
                retorno = this.ExtractImages(pdfPath);
            }).Wait();
            return retorno;
        }

        public IEnumerable<Image> ConvertPDFToImages(Stream pdfStream)
        {
            IEnumerable<Image> retorno = new List<Image>();
            Task.Factory.StartNew(delegate
            {
                retorno = this.ExtractImages(pdfStream);
            }).Wait();
            return retorno;
        }

        #region 内部实现

        public Size NewSize { get; set; }

        private string PathToDll { get; set; }

        private PDFtoImages()
        {
            if (HttpContext.Current != null)
            {
                PathToDll = HttpContext.Current.Server.MapPath("~/bin/");
            }
            else
            {
                PathToDll = AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        static PDFtoImages()
        {
            Converter = new PDFtoImages();
        }

        private IEnumerable<Image> ExtractImages(string file)
        {
            GhostscriptRasterizer rasterizer = null;
            GhostscriptVersionInfo vesion = new GhostscriptVersionInfo(new Version(0, 0, 0), this.PathToDll + "\\gsdll32.dll", string.Empty, GhostscriptLicense.GPL);
            GhostscriptRasterizer ghostscriptRasterizer;
            rasterizer = (ghostscriptRasterizer = new GhostscriptRasterizer());
            IEnumerable<Image> imagesFromRasterizer;
            try
            {
                rasterizer.Open(file, vesion, false);
                imagesFromRasterizer = this.GetImagesFromRasterizer(rasterizer);
            }
            catch
            {
                vesion = new GhostscriptVersionInfo(new Version(0, 0, 0), this.PathToDll + "\\gsdll64.dll", string.Empty, GhostscriptLicense.GPL);
                rasterizer.Open(file, vesion, false);
                imagesFromRasterizer = this.GetImagesFromRasterizer(rasterizer);
            }
            finally
            {
                if (ghostscriptRasterizer != null)
                {
                    ((IDisposable)ghostscriptRasterizer).Dispose();
                }
            }
            return imagesFromRasterizer;
        }

        private IEnumerable<Image> ExtractImages(Stream pdfStream)
        {
            GhostscriptRasterizer rasterizer = null;
            GhostscriptVersionInfo vesion = new GhostscriptVersionInfo(new Version(0, 0, 0), this.PathToDll + "\\gsdll32.dll", string.Empty, GhostscriptLicense.GPL);
            GhostscriptRasterizer ghostscriptRasterizer;
            rasterizer = (ghostscriptRasterizer = new GhostscriptRasterizer());
            IEnumerable<Image> imagesFromRasterizer;
            try
            {
                rasterizer.Open(pdfStream, vesion, false);
                imagesFromRasterizer = this.GetImagesFromRasterizer(rasterizer);
            }
            catch
            {
                vesion = new GhostscriptVersionInfo(new Version(0, 0, 0), this.PathToDll + "\\gsdll64.dll", string.Empty, GhostscriptLicense.GPL);
                rasterizer.Open(pdfStream, vesion, false);
                imagesFromRasterizer = this.GetImagesFromRasterizer(rasterizer);
            }
            finally
            {
                if (ghostscriptRasterizer != null)
                {
                    ((IDisposable)ghostscriptRasterizer).Dispose();
                }
            }
            return imagesFromRasterizer;
        }

        private IEnumerable<Image> GetImagesFromRasterizer(GhostscriptRasterizer rasterizer)
        {
            List<Image> imagesList = new List<Image>();
            Task.Factory.StartNew(delegate
            {
                for (int i = 1; i <= rasterizer.PageCount; i++)
                {
                    Image img = rasterizer.GetPage(300, 300, i);
                    EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, 60L);
                    EncoderParameters encoderParams = new EncoderParameters
                    {
                        Param = new EncoderParameter[]
                        {
                            qualityParam
                        }
                    };
                    MemoryStream imageStream = new MemoryStream();
                    img.Save(imageStream, GetEncoderInfo("image/jpeg"), encoderParams);
                    Image imageExported = new Bitmap(imageStream);
                    Size newSize = this.NewSize;
                    imageExported = ResizeImage(imageExported, this.NewSize);
                    imagesList.Add(imageExported);
                }
            }).Wait();
            rasterizer.Close();
            return imagesList;
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < codecs.Length; i++)
            {
                if (codecs[i].MimeType == mimeType)
                {
                    return codecs[i];
                }
            }
            return null;
        }

        public static Image ResizeImage(Image imgToResize, Size size)
        {
            Bitmap b = new Bitmap(1, 1);
            Task.Factory.StartNew(delegate
            {
                int sourceWidth = imgToResize.Width;
                int sourceHeight = imgToResize.Height;
                float nPercentW = 0f;
                float nPercentH = 0f;
                if (size.Width > 0)
                {
                    nPercentW = (float)size.Width / (float)sourceWidth;
                }
                if (size.Height > 0)
                {
                    nPercentH = (float)size.Height / (float)sourceHeight;
                }
                float nPercent;
                if (nPercentH < nPercentW && nPercentH > 0f)
                {
                    nPercent = nPercentH;
                }
                else
                {
                    nPercent = nPercentW;
                }
                if (nPercent <= 0f)
                {
                    nPercent = 1f;
                }
                int destWidth = (int)((float)sourceWidth * nPercent);
                int destHeight = (int)((float)sourceHeight * nPercent);
                b = new Bitmap(destWidth, destHeight);
                Graphics graphics = Graphics.FromImage(b);
                graphics.InterpolationMode = InterpolationMode.Default;
                graphics.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
                graphics.Dispose();
            }).Wait();
            return b;
        }

        #endregion

    }
}

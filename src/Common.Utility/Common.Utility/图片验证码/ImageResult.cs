using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.Mvc;

namespace Common.Utility
{
    /// <summary>
    /// 图片动作结果
    /// </summary>
    public class ImageResult : ActionResult
    {
        private byte[] _image;
        public byte[] Image
        {
            get { return _image; }
            set { _image = value; }
        }

        private string _contenttype;
        public string ContentType
        {
            get { return _contenttype; }
            set { _contenttype = value; }
        }

        public ImageResult(byte[] image, string contenttype)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            _image = image;
            _contenttype = contenttype;
        }

        public static ImageResult FromImageFile(string path)
        {
            using (Image image = System.Drawing.Image.FromFile(path, true))
            {
                string contenttype = "image/jpeg";
                byte[] bytes = ImageToBytes(image, ref contenttype);
                return new ImageResult(bytes, contenttype);
            }
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            HttpResponseBase response = context.HttpContext.Response;
            if (!string.IsNullOrWhiteSpace(_contenttype)) response.ContentType = _contenttype;
            response.OutputStream.Write(this._image, 0, this._image.Length);
        }

        /// <summary>
        /// Convert Image to Byte[]
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        static byte[] ImageToBytes(Image image, ref string contenttype)
        {
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                if (format.Equals(ImageFormat.Jpeg))
                {
                    image.Save(ms, ImageFormat.Jpeg);
                    contenttype = "image/jpeg";
                }
                else if (format.Equals(ImageFormat.Png))
                {
                    image.Save(ms, ImageFormat.Png);
                    contenttype = "image/png";
                }
                else if (format.Equals(ImageFormat.Bmp))
                {
                    image.Save(ms, ImageFormat.Bmp);
                    contenttype = "image/bmp";
                }
                else if (format.Equals(ImageFormat.Gif))
                {
                    image.Save(ms, ImageFormat.Gif);
                    contenttype = "image/gif";
                }
                else if (format.Equals(ImageFormat.Icon))
                {
                    image.Save(ms, ImageFormat.Icon);
                    contenttype = "image/icon";
                }
                byte[] buffer = new byte[ms.Length];
                //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }
    }

    /// <summary>
    /// 控制器MVC
    /// </summary>
    public partial class ImageController : Controller
    {

        private MallConfigInfo mallConfigInfo = BMAConfig.MallConfig;//商城配置信息
        private UserInfo partUserInfo = null;//用户信息

        /// <summary>
        /// 验证图片
        /// </summary>
        /// <param name="width">图片宽度</param>
        /// <param name="height">图片高度</param>
        /// <returns></returns>
        public ImageResult Verify(int width = 74, int height = 33)
        {
            //生成验证值
            string verifyValue = Randoms.CreateRandomValue(4).ToLower();
            //生成验证图片
            RandomImage verifyImage = Randoms.CreateRandomImage(verifyValue, width, height, Color.White, Color.Blue, Color.DarkRed);
            //将验证值保存到session中
            Session["verifyCode"] = verifyValue;

            //输出验证图片
            return new ImageResult(verifyImage.Image, verifyImage.ContentType);
        }
    }
}

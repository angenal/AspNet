using System;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WindowsWPF.Helpers
{
    public static class FrameworkElementHelper
    {
        public static System.Drawing.Bitmap CopyAsBitmap(this Screen screen)
        {
            var image = new System.Drawing.Bitmap(screen.Bounds.Width, screen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CopyFromScreen(0, 0, 0, 0, image.Size, System.Drawing.CopyPixelOperation.SourceCopy);
            }
            return image;
        }

        public static System.Drawing.Bitmap CopyAsBitmap(this Rect rect)
        {
            var image = new System.Drawing.Bitmap((int)rect.Width, (int)rect.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CopyFromScreen((int)rect.X, (int)rect.Y, 0, 0, image.Size, System.Drawing.CopyPixelOperation.SourceCopy);
            }
            return image;
        }

        public static ImageSource ToImageSource(this System.Drawing.Bitmap bitmap)
        {
            IntPtr hBitmap = bitmap.GetHbitmap();
            ImageSource wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap(
                hBitmap,
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            if (!Interop.WinApi.DeleteObject(hBitmap)) throw new System.ComponentModel.Win32Exception();
            return wpfBitmap;
        }

        public static RenderTargetBitmap CopyAsBitmap(this FrameworkElement frameworkElement)
        {
            int targetWidth = (int)frameworkElement.ActualWidth, targetHeight = (int)frameworkElement.ActualHeight;

            // Exit if there's no 'area' to render
            if (targetWidth == 0 || targetHeight == 0)
            {
                return null;
            }

            // Prepare the rendering target
            RenderTargetBitmap result = new RenderTargetBitmap(targetWidth, targetHeight, 96, 96, PixelFormats.Pbgra32);

            // Render the framework element into the target
            result.Render(frameworkElement);

            return result;
        }

        public static void SaveAsBitmap(this FrameworkElement frameworkElement, string filename, BitmapEncoder bitmapEncoder)
        {
            var image = frameworkElement.CopyAsBitmap();
            var data = image.Encode(bitmapEncoder);
            File.WriteAllBytes(filename, data);
        }

        public static byte[] Encode(this BitmapSource bitmapSource, BitmapEncoder bitmapEncoder)
        {
            // Create a 'frame' for the BitmapSource, then add it to the encoder
            BitmapFrame bitmapFrame = BitmapFrame.Create(bitmapSource);
            bitmapEncoder.Frames.Add(bitmapFrame);

            // Prepare a memory stream to receive the encoded data, then 'save' into it
            MemoryStream memoryStream = new MemoryStream();
            bitmapEncoder.Save(memoryStream);

            // Return the results of the stream as a byte array
            return memoryStream.ToArray();
        }
    }
}

using Microsoft.Win32;
using System;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WindowsWPF.Controls
{
    [TemplatePart(Name = CanvasTemplateName, Type = typeof(Canvas))]
    [TemplatePart(Name = RectangleLeftTemplateName, Type = typeof(Rectangle))]
    [TemplatePart(Name = RectangleTopTemplateName, Type = typeof(Rectangle))]
    [TemplatePart(Name = RectangleRightTemplateName, Type = typeof(Rectangle))]
    [TemplatePart(Name = RectangleBottomTemplateName, Type = typeof(Rectangle))]
    [TemplatePart(Name = BorderTemplateName, Type = typeof(Border))]
    [TemplatePart(Name = WrapPanelTemplateName, Type = typeof(WrapPanel))]
    [TemplatePart(Name = ButtonSaveTemplateName, Type = typeof(Button))]
    [TemplatePart(Name = ButtonCancelTemplateName, Type = typeof(Button))]
    [TemplatePart(Name = ButtonCompleteTemplateName, Type = typeof(Button))]
    public class ScreenCut : Window
    {
        private const string CanvasTemplateName = "PART_Canvas";
        private const string RectangleLeftTemplateName = "PART_RectangleLeft";
        private const string RectangleTopTemplateName = "PART_RectangleTop";
        private const string RectangleRightTemplateName = "PART_RectangleRight";
        private const string RectangleBottomTemplateName = "PART_RectangleBottom";
        private const string BorderTemplateName = "PART_Border";
        private const string WrapPanelTemplateName = "PART_WrapPanel";
        private const string ButtonSaveTemplateName = "PART_ButtonSave";
        private const string ButtonCancelTemplateName = "PART_ButtonCancel";
        private const string ButtonCompleteTemplateName = "PART_ButtonComplete";

        private Canvas _canvas;
        private Rectangle _rectangleLeft, _rectangleTop, _rectangleRight, _rectangleBottom;
        private Border _border;
        private WrapPanel _wrapPanel;
        private Button _buttonSave, _buttonCancel, _buttonComplete;
        private Rect rect;
        private Point pointStart, pointEnd;
        private bool isMouseUp = false;
        public string InitialDirectory { get; set; }

        static ScreenCut()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScreenCut), new FrameworkPropertyMetadata(typeof(ScreenCut)));
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _canvas = GetTemplateChild(CanvasTemplateName) as Canvas;
            _rectangleLeft = GetTemplateChild(RectangleLeftTemplateName) as Rectangle;
            _rectangleTop = GetTemplateChild(RectangleTopTemplateName) as Rectangle;
            _rectangleRight = GetTemplateChild(RectangleRightTemplateName) as Rectangle;
            _rectangleBottom = GetTemplateChild(RectangleBottomTemplateName) as Rectangle;
            _border = GetTemplateChild(BorderTemplateName) as Border;
            _wrapPanel = GetTemplateChild(WrapPanelTemplateName) as WrapPanel;
            _buttonSave = GetTemplateChild(ButtonSaveTemplateName) as Button;
            if (_buttonSave != null)
                _buttonSave.Click += _buttonSave_Click;
            _buttonCancel = GetTemplateChild(ButtonCancelTemplateName) as Button;
            if (_buttonCancel != null)
                _buttonCancel.Click += _buttonCancel_Click;
            _buttonComplete = GetTemplateChild(ButtonCompleteTemplateName) as Button;
            if (_buttonComplete != null)
                _buttonComplete.Click += _buttonComplete_Click;
            _canvas.Background = new ImageBrush(ChangeBitmapToImageSource(CaptureScreen()));
            _rectangleLeft.Width = _canvas.Width;
            _rectangleLeft.Height = _canvas.Height;
        }

        private void _buttonSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "保存";
            dlg.FileName = string.Concat("截图", DateTime.Now.ToString("yyyyMMddHHmmss"));
            dlg.Filter = "JPG 图片 (*.jpg)|*.jpg|PNG 图片 (*.png)|*.png|BMP 图片 (*.bmp)|*.bmp";
            dlg.FilterIndex = 1;
            dlg.AddExtension = true;
            dlg.DefaultExt = ".jpg";
            if (string.IsNullOrEmpty(InitialDirectory)) dlg.RestoreDirectory = true; else dlg.InitialDirectory = InitialDirectory;
            if (dlg.ShowDialog() == true)
            {
                var extension = System.IO.Path.GetExtension(dlg.FileName);
                BitmapEncoder encoder = extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ? new JpegBitmapEncoder() : extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase) ? new BmpBitmapEncoder() : new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(CutBitmap()));
                using (var fs = System.IO.File.OpenWrite(dlg.FileName))
                {
                    encoder.Save(fs);
                    fs.Dispose();
                    fs.Close();
                }
            }
            Close();
        }

        private void _buttonComplete_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetImage(CutBitmap());
            Close();
        }
        CroppedBitmap CutBitmap()
        {
            var renderTargetBitmap = new RenderTargetBitmap((int)_canvas.Width, (int)_canvas.Height, 96d, 96d, PixelFormats.Default);
            renderTargetBitmap.Render(_canvas);
            return new CroppedBitmap(renderTargetBitmap, new Int32Rect((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height));
        }
        private void _buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Escape) Close();
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (!isMouseUp)
            {
                _wrapPanel.Visibility = Visibility.Hidden;
                pointStart = e.GetPosition(_canvas);
                pointEnd = pointStart;
                rect = new Rect(pointStart, pointEnd);
            }
        }
        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && !isMouseUp)
            {
                var current = e.GetPosition(_canvas);
                MoveAllRectangle(current);
            }
        }
        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            if (!isMouseUp)
            {
                _wrapPanel.Visibility = Visibility.Visible;
                Canvas.SetLeft(_wrapPanel, rect.X + rect.Width - _wrapPanel.ActualWidth);
                Canvas.SetTop(_wrapPanel, rect.Y + rect.Height + 4);
                isMouseUp = true;
            }
        }

        void MoveAllRectangle(Point current)
        {
            pointEnd = current;
            rect = new Rect(pointStart, pointEnd);
            _rectangleLeft.Width = rect.X;
            _rectangleLeft.Height = _canvas.Height;

            Canvas.SetLeft(_rectangleTop, _rectangleLeft.Width);
            _rectangleTop.Width = rect.Width;
            _rectangleTop.Height = current.Y < pointStart.Y ? current.Y : current.Y - rect.Height;

            Canvas.SetLeft(_rectangleRight, _rectangleLeft.Width + rect.Width);
            _rectangleRight.Width = _canvas.Width - (rect.Width + _rectangleLeft.Width);
            _rectangleRight.Height = _canvas.Height;

            Canvas.SetLeft(_rectangleBottom, _rectangleLeft.Width);
            Canvas.SetTop(_rectangleBottom, rect.Height + _rectangleTop.Height);
            _rectangleBottom.Width = rect.Width;
            _rectangleBottom.Height = _canvas.Height - (rect.Height + _rectangleTop.Height);

            _border.Height = rect.Height;
            _border.Width = rect.Width;
            Canvas.SetLeft(_border, rect.X);
            Canvas.SetTop(_border, rect.Y);
        }

        System.Drawing.Bitmap CaptureScreen()
        {
            var bmpCaptured = new System.Drawing.Bitmap((int)SystemParameters.PrimaryScreenWidth, (int)SystemParameters.PrimaryScreenHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmpCaptured))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CopyFromScreen(0, 0, 0, 0, bmpCaptured.Size, System.Drawing.CopyPixelOperation.SourceCopy);
            }
            return bmpCaptured;
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        static extern bool DeleteObject(IntPtr hObject);
        ImageSource ChangeBitmapToImageSource(System.Drawing.Bitmap bitmap)
        {
            IntPtr hBitmap = bitmap.GetHbitmap();
            ImageSource wpfBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                hBitmap,
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            if (!DeleteObject(hBitmap)) throw new System.ComponentModel.Win32Exception();
            return wpfBitmap;
        }
    }
}

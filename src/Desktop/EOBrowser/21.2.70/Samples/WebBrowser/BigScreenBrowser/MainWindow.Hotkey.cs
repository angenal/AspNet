using ShareX.ScreenCaptureLib;
using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Threading;

namespace BigScreenBrowser
{
    /// <summary></summary>
    public partial class MainWindow
    {
        /// <summary>
        /// 添加快捷键功能
        /// </summary>
        protected void RegisterHotkey()
        {
            // 快捷键 Alt+F1 获取应用程序信息
            altF1 = new Hotkey(HotkeyModifiers.Alt, Hotkeys.F1, this, true);
            altF1.HotkeyPressed += AltF1_HotkeyPressed;
            // 快捷键 Alt+F2 获取访问历史记录
            altF2 = new Hotkey(HotkeyModifiers.Alt, Hotkeys.F2, this, true);
            altF2.HotkeyPressed += AltF2_HotkeyPressed;
            // 快捷键 Alt+F5 拆分窗口为一半/还原
            altF5 = new Hotkey(HotkeyModifiers.Alt, Hotkeys.F5, this, true);
            altF5.HotkeyPressed += AltF5_HotkeyPressed;
            // 快捷键 Alt+F11 全屏(显示或隐藏)
            altF11 = new Hotkey(HotkeyModifiers.Alt, Hotkeys.F11, this, true);
            altF11.HotkeyPressed += AltF11_HotkeyPressed;
            //// 快捷键 Alt+A 截图
            //altA = new Hotkey(HotkeyModifiers.Alt, Hotkeys.A, this, true);
            //altA.HotkeyPressed += AltA_HotkeyPressed;
            // 快捷键 Alt+Q 询问关闭该应用程序
            altQ = new Hotkey(HotkeyModifiers.Alt, Hotkeys.Q, this, true);
            altQ.HotkeyPressed += AltQ_HotkeyPressed;
            // 快捷键 Alt+T 该应用程序置顶显示
            altT = new Hotkey(HotkeyModifiers.Alt, Hotkeys.T, this, true);
            altT.HotkeyPressed += AltT_HotkeyPressed;
        }

        // 快捷键 Alt+F1 获取应用程序信息
        private Hotkey altF1;
        private void AltF1_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            Alert(WebPageObjectForScripting._GetAppInfo());
        }

        // 快捷键 Alt+F2 获取访问历史记录
        private Hotkey altF2;
        private void AltF2_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            Alert(WebPageObjectForScripting._GetUrls());
        }

        // 快捷键 Alt+F5 拆分窗口为一半/还原
        private Hotkey altF5;
        private void AltF5_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            HalveApp();
        }
        public void HalveApp()
        {
            if (!IsVisible) return;
            bool i = App.Width == grid.Width;
            double x = i ? App.Width * 0.5 : App.Left, y = App.Top;
            double w = App.Width * (i ? 0.5 : 1), h = App.Height;
            Dispatcher.BeginInvoke(new Action(() => { Left = x; Top = y; Width = w; Height = h; }));
            IntPtr hWnd = new WindowInteropHelper(this).Handle;
            Application.Current.Dispatcher.Invoke(new Action(() => SetWindowPos(hWnd, -1, (int)x, (int)y, (int)w, (int)h, 0)));
            grid.Dispatcher.BeginInvoke(new Action(() => { grid.Width = w; grid.Height = h; }));
        }

        // 快捷键 Alt+F11 全屏(显示或隐藏)
        private Hotkey altF11;
        private void AltF11_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            ToggleApp();
        }
        public void ToggleApp()
        {
            if (IsVisible)
            {
                HideApp();
            }
            else
            {
                ShowApp();
            }
        }
        public void HideApp()
        {
            //Topmost = false;
            Hide();
        }
        public void ShowApp()
        {
            //Topmost = true;
            Show();
        }

        // 快捷键 Alt+A 截图
        //private Hotkey altA;
        private bool isScreenCut = false;
        //private void AltA_HotkeyPressed(object sender, HotkeyEventArgs e)
        //{
        //    if (!IsVisible || isScreenCut) return;
        //    isScreenCut = true;
        //    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(ScreenCut));
        //}
        internal void ScreenCut()
        {
            if (!isScreenCut) return;
            System.Threading.Thread.Sleep(500);
            WindowsWPF.Controls.ScreenCut screenCut = new WindowsWPF.Controls.ScreenCut() { Topmost = true, InitialDirectory = m_SaveFilePath };
            screenCut.ShowDialog();
            isScreenCut = false;
        }
        internal void ScreenCut1()
        {
            if (!isScreenCut) return;
            System.Threading.Thread.Sleep(500);
            RegionCaptureOptions options = new RegionCaptureOptions() { ShowMagnifier = false, EnableAnimations = false };
            using (RegionCaptureForm form = new RegionCaptureForm(RegionCaptureMode.Default, options))
            {
                Screenshot screenshot = new Screenshot() { AutoHideTaskbar = true };
                System.Drawing.Image img = screenshot.CaptureFullscreen();
                form.TopMost = true;
                form.Prepare(img);
                form.ShowDialog();
                isScreenCut = false;
                System.Drawing.Image image = form.GetResultImage();
                if (image == null) return;
                System.Windows.Forms.Clipboard.SetImage(image);
                var dlg = new System.Windows.Forms.SaveFileDialog();
                dlg.Title = "保存";
                dlg.FileName = string.Concat("截图", DateTime.Now.ToString("yyyyMMddHHmmss"));
                dlg.Filter = "JPG 图片 (*.jpg)|*.jpg|PNG 图片 (*.png)|*.png|BMP 图片 (*.bmp)|*.bmp";
                dlg.FilterIndex = 1;
                dlg.AddExtension = true;
                dlg.DefaultExt = ".jpg";
                dlg.InitialDirectory = m_SaveFilePath;
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                var extension = System.IO.Path.GetExtension(dlg.FileName);
                if (extension.Equals(".jpg")) image.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                if (extension.Equals(".png")) image.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
                if (extension.Equals(".bmp")) image.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }
        internal void ScreenCut2()
        {
            try
            {
                //捕获屏幕
                if (!isScreenCut) return;
                System.Threading.Thread.Sleep(500);
                RegionCaptureOptions options = new RegionCaptureOptions() { ShowMagnifier = false, EnableAnimations = false, QuickCrop = false };
                System.Drawing.Image img = RegionCaptureTasks.GetRegionImage_Mo(options, out string flag, out System.Drawing.Point flag_location, out System.Drawing.Rectangle[] rectangle_flag);
                if (img == null) return;
                //快捷键Esc
                int id = options.GetHashCode();
                uint key = (uint)System.Windows.Forms.Keys.Escape;
                IntPtr hWnd = new WindowInteropHelper(this).Handle;
                HotkeyRef.RegisterHotKey(hWnd, id, 0, key);
                //高级截图
                var mode = RegionCaptureMode.Annotation;
                options = new RegionCaptureOptions();
                using (var form = new RegionCaptureForm(mode, options))
                {
                    form.TopMost = true;
                    form.Image_get = false;
                    form.Prepare(img);
                    form.ShowDialog();
                    img = null;
                    img = form.GetResultImage();
                    flag = form.Mode_flag;
                }
                isScreenCut = false;
                HotkeyRef.UnregisterHotKey(hWnd, id);
                if (img == null) return;
                //保存图片到剪贴板
                System.Windows.Forms.Clipboard.SetImage(img);
                //保存图片到磁盘
                var dlg = new System.Windows.Forms.SaveFileDialog();
                dlg.Title = "保存";
                dlg.FileName = string.Concat("截图", DateTime.Now.ToString("yyyyMMddHHmmss"));
                dlg.Filter = "JPG 图片 (*.jpg)|*.jpg|PNG 图片 (*.png)|*.png|BMP 图片 (*.bmp)|*.bmp";
                dlg.FilterIndex = 1;
                dlg.AddExtension = true;
                dlg.DefaultExt = ".jpg";
                dlg.InitialDirectory = m_SaveFilePath;
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                var extension = System.IO.Path.GetExtension(dlg.FileName);
                if (extension.Equals(".jpg")) img.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                if (extension.Equals(".png")) img.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
                if (extension.Equals(".bmp")) img.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            catch (Exception e)
            {
                Alert(e.Message, MessageBoxImage.Error, "截图错误");
            }
        }

        // 快捷键 Alt+Q 询问关闭该应用程序
        private Hotkey altQ;
        private void AltQ_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            if (IsVisible) Window_ComfirmExit();
        }
        //private void CommandBinding_ExitClick_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}
        //private void CommandBinding_ExitClick_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    //Window_ComfirmExit();
        //}

        // 快捷键 Alt+T 该应用程序置顶显示
        private Hotkey altT;
        private void AltT_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            if (IsVisible) Topmost = !Topmost;
        }
    }
}

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
            // 快捷键 Alt+A 截图
            altA = new Hotkey(HotkeyModifiers.Alt, Hotkeys.A, this, true);
            altA.HotkeyPressed += AltA_HotkeyPressed;
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
        private Hotkey altA;
        private bool isScreenCut = false;
        private void AltA_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            if (!IsVisible || isScreenCut) return;
            isScreenCut = true;
            App.Instance.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(ScreenCut));
        }
        internal void ScreenCut()
        {
            using (RegionCaptureForm form = new RegionCaptureForm(RegionCaptureMode.Default, new RegionCaptureOptions()
            {
                ShowHotkeys = false,
                ShowMagnifier = false,
                UseSquareMagnifier = false,
                MagnifierPixelCount = 15,
                MagnifierPixelSize = 10
            }))
            {
                form.TopMost = true;
                form.Prepare();
                form.ShowDialog();
                isScreenCut = false;
                System.Drawing.Image image = form.GetResultImage();
                if (image == null) return;
                System.Windows.Forms.Clipboard.SetImage(image);
                var saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog.Filter = "png图片(*.png)|*.png|jpg图片(*.jpg)|*.jpg|bmp图片(*.bmp)|*.bmp";
                saveFileDialog.AddExtension = false;
                saveFileDialog.FileName = string.Concat("截图", DateTime.Now.ToString("yyyyMMddHHmmss"));
                saveFileDialog.Title = "保存图片";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                var extension = System.IO.Path.GetExtension(saveFileDialog.FileName);
                if (extension.Equals(".jpg")) image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                if (extension.Equals(".png")) image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                if (extension.Equals(".bmp")) image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
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

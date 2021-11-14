using System;
using System.Windows;
using System.Windows.Threading;

namespace BigScreenBrowser
{
    /// <summary></summary>
    public partial class MainWindow
    {
        private const string HotkeyMessageBoxText = @"功能说明：
  快捷键`Alt+A`截图；
  快捷键`Alt+Q`退出该应用程序；";

        /// <summary>
        /// 添加快捷键功能
        /// </summary>
        protected void RegisterHotkey()
        {
            // 快捷键 Alt+F5 拆分窗口为以前的一半
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

        // 快捷键 Alt+F5 拆分窗口为以前的一半
        private Hotkey altF5;
        private void AltF5_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            HalveApp();
        }
        public void HalveApp()
        {
            if (!IsVisible) return;
            grid.Dispatcher.BeginInvoke(new Action(() =>
            {
                grid.Width = App.Width * (App.Width == grid.Width ? 0.5 : 1);
            }));
            Dispatcher.BeginInvoke(new Action(() =>
            {
                Left = App.Width == grid.Width ? App.Left : App.Width * 0.5;
            }));
        }

        // 快捷键 Alt+F11 全屏(显示或隐藏)
        private Hotkey altF11;
        private bool isFullScreen = true;
        private void AltF11_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            ToggleApp();
        }
        public void ToggleApp()
        {
            if (isFullScreen)
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
            isFullScreen = false;
            Topmost = false;
            Hide();
        }
        public void ShowApp()
        {
            isFullScreen = true;
            Topmost = true;
            Show();
        }

        // 快捷键 Alt+A 截图
        private Hotkey altA;
        private WindowsWPF.Controls.ScreenCut screenCut;
        private void AltA_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            if (!IsVisible) return;
            if (screenCut != null && screenCut.IsActive) return;
            screenCut = new WindowsWPF.Controls.ScreenCut { Topmost = true, ShowInTaskbar = false, WindowStyle = WindowStyle.None, AllowsTransparency = true };
            App.Instance.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => screenCut.ShowDialog()));
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

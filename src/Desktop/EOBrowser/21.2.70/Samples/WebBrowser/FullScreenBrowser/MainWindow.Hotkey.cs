using System;
using System.Windows;
using System.Windows.Threading;

namespace FullScreenBrowser
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
            // 快捷键 Alt+F11 全屏(或显示工具栏)
            altF11 = new Hotkey(HotkeyModifiers.Alt, Hotkeys.F11, this, true);
            altF11.HotkeyPressed += AltF11_HotkeyPressed;
            // 快捷键 Alt+A 截图
            altA = new Hotkey(HotkeyModifiers.Alt, Hotkeys.A, this, true);
            altA.HotkeyPressed += AltA_HotkeyPressed;
            // 快捷键 Alt+Q 询问关闭该应用程序
            altQ = new Hotkey(HotkeyModifiers.Alt, Hotkeys.Q, this, true);
            altQ.HotkeyPressed += AltQ_HotkeyPressed;
        }

        // 快捷键 Alt+F11 全屏(或显示工具栏)
        private Hotkey altF11;
        private bool isFullScreen;
        private void AltF11_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            if (isFullScreen)
            {
                isFullScreen = false;
                toolbar.Visibility = Visibility.Visible;
            }
            else
            {
                isFullScreen = true;
                toolbar.Visibility = Visibility.Hidden;
            }
        }

        // 快捷键 Alt+A 截图
        private Hotkey altA;
        private WindowsWPF.Controls.ScreenCut screenCut;
        private void AltA_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            if (screenCut != null && screenCut.IsActive) return;
            screenCut = new WindowsWPF.Controls.ScreenCut { Topmost = true, ShowInTaskbar = false, WindowStyle = WindowStyle.None, AllowsTransparency = true };
            App.Instance.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => screenCut.ShowDialog()));
        }

        // 快捷键 Alt+Q 询问关闭该应用程序
        private Hotkey altQ;
        private void AltQ_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            Window_ComfirmExit();
        }
        //private void CommandBinding_ExitClick_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}
        //private void CommandBinding_ExitClick_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    //Window_ComfirmExit();
        //}
    }
}

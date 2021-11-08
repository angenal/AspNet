using System;
using System.Windows;
using System.Windows.Threading;

namespace WPF.FullScreen
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
            // 快捷键 F5 刷新
            f5Hotkey = new Hotkey(HotkeyModifiers.NoMod, Hotkeys.F5, this, true);
            f5Hotkey.HotkeyPressed += f5_HotkeyPressed;
            ctrlF5 = new Hotkey(HotkeyModifiers.Ctrl, Hotkeys.F5, this, true);
            ctrlF5.HotkeyPressed += ctrlF5_HotkeyPressed;
            // 快捷键 Alt+A 截图
            altA = new Hotkey(HotkeyModifiers.Alt, Hotkeys.A, this, true);
            altA.HotkeyPressed += AltA_HotkeyPressed;
            // 快捷键 Alt+Q 询问关闭该应用程序
            altQ = new Hotkey(HotkeyModifiers.Alt, Hotkeys.Q, this, true);
            altQ.HotkeyPressed += AltQ_HotkeyPressed;
        }

        // 快捷键 F5 刷新
        private Hotkey f5Hotkey;
        private void f5_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            WebBrowser1.Browser.Reload();
        }
        private Hotkey ctrlF5;
        private void ctrlF5_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            WebBrowser1.Browser.ReloadIgnoringCache();
        }

        // 快捷键 Alt+A 截图
        private Hotkey altA;
        private WindowsWPF.Controls.ScreenCut screenCut;
        private void AltA_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            if (screenCut != null && screenCut.IsActive) return;
            screenCut = new WindowsWPF.Controls.ScreenCut { Topmost = true };
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => screenCut.ShowDialog()));
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

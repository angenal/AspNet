using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Interop;

namespace BigScreenBrowser
{
    /// <summary></summary>
    public partial class MainWindow
    {
        #region 彻底去除关闭按钮
        /// <summary>
        /// 彻底去除关闭按钮
        /// </summary>
        private void RemoveCloseButton()
        {
            IntPtr hWnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hWnd, -16, GetWindowLong(hWnd, -16) & ~0x80000);
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        #endregion

        #region 窗体一直置顶
        /// <summary>
        /// 窗体一直置顶
        /// </summary>
        private void SetTopMost()
        {
            IntPtr hWnd = new WindowInteropHelper(this).Handle;
            new Thread(() =>
            {
                Thread.Sleep(2000);
                while (true)
                {
                    Application.Current.Dispatcher.Invoke(new Action(() => WindowsWPF.Interop.WinApi.SetWindowPos(hWnd, -1, 0, 0, 0, 0, 0x0040)));
                    Thread.Sleep(1000);
                }
            }).Start();
        }
        internal Rect GetWindowRect()
        {
            IntPtr hWnd = new WindowInteropHelper(this).Handle;
            WindowsWPF.Interop.WinApi.GetWindowRect(hWnd, out Rect rect);
            return rect;
        }
        #endregion

        #region 内存优化
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, EntryPoint = "SetProcessWorkingSetSize")]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        public void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT) SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
        }
        #endregion
    }
}

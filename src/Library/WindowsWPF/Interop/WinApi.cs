using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Interop;

namespace WindowsWPF.Interop
{
    /// <summary>
    /// Win32 API imports.
    /// </summary>
    public static class WinApi
    {
        private const string User32 = "user32.dll";

        #region 内存优化 ClearMemory
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform != PlatformID.Win32NT) return;
            SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
        }
        #endregion

        #region 彻底去除关闭按钮 RemoveCloseButton
        [DllImport(User32, CharSet = CharSet.Auto)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport(User32, CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        /// <summary>
        /// 彻底去除关闭按钮
        /// </summary>
        public static void RemoveCloseButton(this Window window)
        {
            IntPtr hWnd = new WindowInteropHelper(window).Handle;
            SetWindowLong(hWnd, -16, GetWindowLong(hWnd, -16) & ~0x80000);
        }
        #endregion

        #region 窗体一直置顶 SetTopMost
        [DllImport(User32, CharSet = CharSet.Auto)] // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowpos
        public static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
        /// <summary>
        /// 窗体一直置顶
        /// </summary>
        public static void SetTopMost(this Window window)
        {
            IntPtr hWnd = new WindowInteropHelper(window).Handle;
            new Thread(() =>
            {
                Thread.Sleep(2000);
                while (true)
                {
                    Application.Current.Dispatcher.Invoke(new Action(() => SetWindowPos(hWnd, -1, 0, 0, 0, 0, 0x0040)));
                    Thread.Sleep(1000);
                }
            }).Start();
        }
        //[DllImport(User32, CharSet = CharSet.Auto)] // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowrect
        //public static extern int GetWindowRect(IntPtr hwnd, out Rect lpRect);
        //public static Rect GetWindowRect(this Window window)
        //{
        //    IntPtr hWnd = new WindowInteropHelper(window).Handle;
        //    GetWindowRect(hWnd, out Rect rect);
        //    return rect;
        //}
        #endregion

        [DllImport(User32, CharSet = CharSet.Auto)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport(User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SetParent(IntPtr hChild, IntPtr hParent);
        [DllImport(User32, CharSet = CharSet.Auto)]
        public static extern IntPtr GetForegroundWindow();

        private const string Gdi32 = "gdi32.dll";

        [DllImport(Gdi32)]
        public static extern bool BitBlt(IntPtr hdcDst, int xDst, int yDst, int cx, int cy, IntPtr hdcSrc, int xSrc, int ySrc, uint ulRop);
        [DllImport(Gdi32)]
        public static extern uint SetPixel(IntPtr hdc, int X, int Y, uint crColor);
        [DllImport(Gdi32)]
        public static extern bool DeleteObject(IntPtr hObject);

        /// <summary>
        /// Creates, updates or deletes the taskbar icon.
        /// </summary>
        [DllImport("shell32.Dll", CharSet = CharSet.Unicode)]
        public static extern bool Shell_NotifyIcon(NotifyCommand cmd, [In] ref NotifyIconData data);


        /// <summary>
        /// Creates the helper window that receives messages from the taskar icon.
        /// </summary>
        [DllImport(User32, EntryPoint = "CreateWindowExW", SetLastError = true)]
        public static extern IntPtr CreateWindowEx(int dwExStyle, [MarshalAs(UnmanagedType.LPWStr)] string lpClassName,
            [MarshalAs(UnmanagedType.LPWStr)] string lpWindowName, int dwStyle, int x, int y,
            int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance,
            IntPtr lpParam);


        /// <summary>
        /// Processes a default windows procedure.
        /// </summary>
        [DllImport(User32)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint msg, IntPtr wparam, IntPtr lparam);

        /// <summary>
        /// Registers the helper window class.
        /// </summary>
        [DllImport(User32, EntryPoint = "RegisterClassW", SetLastError = true)]
        public static extern short RegisterClass(ref WindowClass lpWndClass);

        /// <summary>
        /// Registers a listener for a window message.
        /// </summary>
        /// <param name="lpString"></param>
        /// <returns>uint</returns>
        [DllImport(User32, EntryPoint = "RegisterWindowMessageW")]
        public static extern uint RegisterWindowMessage([MarshalAs(UnmanagedType.LPWStr)] string lpString);

        /// <summary>
        /// Used to destroy the hidden helper window that receives messages from the
        /// taskbar icon.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns>bool</returns>
        [DllImport(User32, SetLastError = true)]
        public static extern bool DestroyWindow(IntPtr hWnd);


        /// <summary>
        /// Gives focus to a given window.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns>bool</returns>
        [DllImport(User32)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);


        /// <summary>
        /// Gets the maximum number of milliseconds that can elapse between a
        /// first click and a second click for the OS to consider the
        /// mouse action a double-click.
        /// </summary>
        /// <returns>The maximum amount of time, in milliseconds, that can
        /// elapse between a first click and a second click for the OS to
        /// consider the mouse action a double-click.</returns>
        [DllImport(User32, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int GetDoubleClickTime();


        /// <summary>
        /// Gets the screen coordinates of the current mouse position.
        /// </summary>
        [DllImport(User32, SetLastError = true)]
        public static extern bool GetPhysicalCursorPos(ref Point lpPoint);


        [DllImport(User32, SetLastError = true)]
        public static extern bool GetCursorPos(ref Point lpPoint);
    }
}

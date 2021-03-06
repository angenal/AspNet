using System.Util.Win32.Enums;
using System.Util.Win32.Extensions;
using System;
using System.Threading;
using static System.Util.Win32.Enums.RasterCodes;
using static System.Util.Win32.Enums.SetWindowPosFlags;
using static System.Util.Win32.Enums.ShowWindowCommands;
using static System.Util.Win32.User32;

namespace System.Util.Win32.NativeUI
{
    public partial class Win32Window
    {
        /// <summary>
        /// Start Message Loop
        /// </summary>
        [Obsolete("This method will block current thread. Use UIThreadManager for better control UI thread.")]
        public UIThreadManager StartMessageLoop() => new UIThreadManager(Thread.CurrentThread);

        /// <summary>
        /// Show
        /// </summary>
        public void Show() => ShowWindow(_handle, SW_SHOWNORMAL);


        /// <summary>
        /// Hide
        /// </summary>
        public void Hide() => ShowWindow(_handle, SW_HIDE);

        /// <summary>
        /// Set TopMost
        /// </summary>
        public void SetTopMost()
        {
            SetForegroundWindow(_handle);
            if (!SetWindowPos(_handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE))
            {
                ThrowExceptionIfError();
            }
        }

        /// <summary>
        /// Set No TopMost
        /// </summary>
        public void SetNoTopMost()
        {
            if (!SetWindowPos(_handle, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE))
            {
                ThrowExceptionIfError();
            }
        }

        /// <summary>
        /// Get ScreenShot
        /// </summary>
        public void GetScreenShot() => WindowExtensions.GetWindowScreenshot(_handle);

        /// <summary>
        /// Get ScreenShot with <see cref="CAPTUREBLT"/>
        /// </summary>
        public void GetScreenShotWithCaptureBlt() => WindowExtensions.GetWindowScreenshotWithCaptureBlt(_handle);

        /// <summary>
        /// Register Touch Window
        /// </summary>
        /// <param name="flags"></param>
        public void RegisterTouchWindow(TouchWindowFlags flags = 0)
        {
            if (!User32.RegisterTouchWindow(_handle, flags))
            {
                ThrowExceptionIfError();
            }
        }

        /// <summary>
        /// Unregister Touch Window
        /// </summary>
        public void UnregisterTouchWindow()
        {
            if (!User32.UnregisterTouchWindow(_handle))
            {
                ThrowExceptionIfError();
            }
        }
    }
}

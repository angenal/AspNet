using System.Util.Win32.BaseTypes;
using System.Util.Win32.Enums;
using System.Util.Win32.Marshals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static System.Util.Win32.Constants;
using static System.Util.Win32.Enums.RasterCodes;
using static System.Util.Win32.Gdi32;
using static System.Util.Win32.Kernel32;
using static System.Util.Win32.User32;

namespace System.Util.Win32.Extensions
{
    /// <summary>
    /// Window Extensions
    /// </summary>
    public static class WindowExtensions
    {
        /// <summary>
        /// Get All Top-Level Window Handle (Use <see cref="EnumWindows"/>)
        /// </summary>
        /// <returns></returns>
        public static HWND[] GetAllTopLevelWindowHandle()
        {
            var result = new List<HWND>();
            EnumWindows((handle, _) =>
            {
                result.Add(handle);
                return true;
            }, IntPtr.Zero);
            return result.ToArray();
        }

        /// <summary>
        /// Get All Window Handle (Use <see cref="EnumWindows"/> with <see cref="EnumChildWindows(HWND, WNDENUMPROC, LPARAM)"/>)
        /// </summary>
        /// <returns></returns>
        public static HWND[] GetAllWindowHandle()
        {
            var result = new List<HWND>();
            EnumWindows((handle, _) =>
            {
                result.Add(handle);
                EnumChildWindows(handle, (childHandle, _) =>
                {
                    result.Add(childHandle);
                    return true;
                }, NULL);
                return true;
            }, IntPtr.Zero);
            return result.ToArray();
        }

#if !NET40 && !NET45
        /// <summary>
        /// Get All Top-Level Window Handle (Use <see cref="EnumWindows"/>
        /// </summary>
        /// <returns></returns>
        public static (HWND WindowHandle, string Text)[] GetAllTopLevelWindowHandleWithText()
        {
            var result = new List<(HWND, string)>();
            EnumWindows((handle, _) =>
            {
                SetLastError(0);
                var length = GetWindowTextLength(handle);
                var code = GetLastError();
                if (code == 0)
                {
                    var sb = new StringBuffer(length);
                    GetWindowText(handle, sb, 20);
                    code = GetLastError();
                    if (code == 0)
                    {
                        result.Add((handle, sb.ToString()));
                        return true;
                    }
                }
                result.Add((handle, null));
                return true;
            }, IntPtr.Zero);
            return result.ToArray();
        }
#endif

        /// <summary>
        /// Get Window Screenshot (Use GDI)
        /// </summary>
        /// <param name="hwnd">
        /// The window to screenshot. If <see cref="NULL"/>, the result will be of the main display monitor.
        /// </param>
        /// <returns>The <see cref="HBITMAP"/>, must use <see cref="DeleteObject"/> to delete it.</returns>
        public static HBITMAP GetWindowScreenshot(HWND hwnd) => GetWindowScreenshot(hwnd, SRCCOPY);

        /// <summary>
        /// Get Window Screenshot (Use GDI with <see cref="CAPTUREBLT"/>)
        /// </summary>
        /// <param name="hwnd">
        /// The window to screenshot. If <see cref="NULL"/>, the result will be of the main display monitor.
        /// </param>
        /// <returns>The <see cref="HBITMAP"/>, must use <see cref="DeleteObject"/> to delete it.</returns>
        public static HBITMAP GetWindowScreenshotWithCaptureBlt(HWND hwnd) => GetWindowScreenshot(hwnd, SRCCOPY | CAPTUREBLT);

        /// <summary>
        /// Get Window Screenshot (Use GDI)
        /// </summary>
        /// <param name="hwnd">
        /// The window to screenshot. If <see cref="NULL"/>, the result will be of the main display monitor.
        /// </param>
        /// <param name="rasterCodes">
        /// The rasterCodes for <see cref="BitBlt"/>
        /// </param>
        /// <returns>The <see cref="HBITMAP"/>, must use <see cref="DeleteObject"/> to delete it.</returns>
        public static HBITMAP GetWindowScreenshot(HWND hwnd, RasterCodes rasterCodes)
        {
            HDC windowDC = NULL;
            HDC destDC = NULL;
            HBITMAP destBitmap = NULL;

            try
            {
                windowDC = GetWindowDC(hwnd);
                if (windowDC == NULL)
                {
                    throw new Win32Exception();
                }

                if (!GetWindowRect(hwnd == NULL ? GetDesktopWindow() : hwnd, out var rect))
                {
                    throw new Win32Exception();
                }
                var width = rect.right - rect.left;
                var height = rect.bottom - rect.top;

                destDC = CreateCompatibleDC(windowDC);
                if (destDC == NULL)
                {
                    throw new Win32Exception();
                }

                destBitmap = CreateCompatibleBitmap(windowDC, width, height);
                if (destBitmap == NULL)
                {
                    throw new Win32Exception();
                }

                var oldObject = SelectObject(destDC, destBitmap);
                if (oldObject == NULL)
                {
                    throw new Win32Exception();
                }

                if (!BitBlt(destDC, 0, 0, width, height, windowDC, 0, 0, rasterCodes))
                {
                    throw new Win32Exception();
                }

                SelectObject(destDC, oldObject);
            }
            finally
            {
                if (windowDC != NULL)
                {
                    ReleaseDC(hwnd, windowDC);
                }
                if (destDC != NULL)
                {
                    DeleteDC(destDC);
                }
            }
            return destBitmap;
        }
    }
}

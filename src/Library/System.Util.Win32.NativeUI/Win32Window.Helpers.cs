using System.Util.Win32.BaseTypes;
using System.Util.Win32.ComInterfaces;
using System.Util.Win32.Enums;
using System.Util.Win32.Marshals;
using System.Util.Win32.Structs;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.Util.Win32.ComInterfaces.CLSIDs;
using static System.Util.Win32.ComInterfaces.IIDs;
using static System.Util.Win32.Constants;
using static System.Util.Win32.Enums.ClassStyles;
using static System.Util.Win32.Enums.CLSCTX;
using static System.Util.Win32.Enums.ImageTypes;
using static System.Util.Win32.Enums.LoadImageFlags;
using static System.Util.Win32.Enums.SystemColors;
using static System.Util.Win32.Enums.SystemCursors;
using static System.Util.Win32.Enums.SystemIcons;
using static System.Util.Win32.Kernel32;
using static System.Util.Win32.Ole32;
using static System.Util.Win32.UnsafePInvokeExtensions;
using static System.Util.Win32.User32;

namespace System.Util.Win32.NativeUI
{
    public partial class Win32Window
    {
        static LPVOID _virtualDesktopManager;

        static Win32Window()
        {
            if (Environment.OSVersion.Version.Major >= 10)
            {
                CoCreateInstance(CLSID_VirtualDesktopManager, NullRef<IUnknown>(), CLSCTX_INPROC_SERVER, in IID_IVirtualDesktopManager, out _virtualDesktopManager);
            }
        }

        /// <summary>
        /// Custom Error Handler
        /// </summary>
        public Action<SystemErrorCodes?, HRESULT?>? CustomErrorHandler { get; set; }

        private Win32WindowFlags _flags;

        [Flags]
        internal enum Win32WindowFlags
        {
            OwnWindow = 0x1,
            OtherProcess = 0x10,
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CleanUpUnmanagedResources()
        {
            if (_handle != NULL)
            {
                DestroyWindow(_handle);
                _handle = NULL;
            }
        }

        private void RegisterWindowClass(HINSTANCE hInstance, string className)
        {
            using var marshal = new StringToIntPtrMarshaler(className);
            var wndclass = new WNDCLASSEX
            {
                cbSize = (uint)Marshal.SizeOf(typeof(WNDCLASSEX)),
                style = CS_DBLCLKS,
                lpfnWndProc = _wndProc,
                cbClsExtra = 0,
                cbWndExtra = 0,
                hInstance = hInstance,
                hIcon = LoadImage(NULL, (IntPtr)IDI_APPLICATION, IMAGE_ICON, 0, 0, LR_SHARED),
                hCursor = LoadImage(NULL, (IntPtr)IDC_ARROW, IMAGE_CURSOR, 0, 0, LR_SHARED),
                hbrBackground = COLOR_WINDOW,
                lpszMenuName = NULL,
                lpszClassName = marshal.GetPtr(),
            };
            if (RegisterClassEx(wndclass) == 0)
            {
                throw new Win32Exception();
            }
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal bool CheckFlag(Win32WindowFlags flags) => (_flags & flags) != 0;

#if! NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal void ThrowExceptionIfError() => ThrowExceptionIfError(GetLastError());

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal void ThrowExceptionIfError(SystemErrorCodes errorCode)
        {
            if (errorCode != SystemErrorCodes.ERROR_SUCCESS)
            {
                OnWin32Exception(errorCode);
            }
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal void OnWin32Exception(SystemErrorCodes errorCode)
        {
            if (CustomErrorHandler != null)
            {
                CustomErrorHandler.Invoke(errorCode, null);
            }
            else
            {
                throw new Win32Exception((int)errorCode);
            }
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal void OnComException(HRESULT hresult)
        {
            if (CustomErrorHandler != null)
            {
                CustomErrorHandler.Invoke(null, hresult);
            }
            else
            {
                Marshal.ThrowExceptionForHR(hresult);
            }
        }
    }
}

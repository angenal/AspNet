using System;
using System.Runtime.InteropServices;

namespace System.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A handle to a window.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/winprog/windows-data-types"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HWND : IPointer
    {
        /// <summary>
        /// HWND_DESKTOP
        /// </summary>
        public static readonly HWND HWND_DESKTOP = new HWND();

        private HANDLE _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <inheritdoc/>
        public IntPtr ToIntPtr() => _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HANDLE(HWND val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HWND(HANDLE val) => new HWND { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(HWND val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HWND(IntPtr val) => new HWND { _value = val };
    }
}

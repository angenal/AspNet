using System.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace System.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="SIZE"/> structure defines the width and height of a rectangle.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/windef/ns-windef-size"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SIZE
    {
        /// <summary>
        /// Specifies the rectangle's width. The units depend on which function uses this structure.
        /// </summary>
        public LONG cx;

        /// <summary>
        /// Specifies the rectangle's height. The units depend on which function uses this structure.
        /// </summary>
        public LONG cy;
    }
}

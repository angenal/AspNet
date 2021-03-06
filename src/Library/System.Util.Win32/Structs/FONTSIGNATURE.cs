using System.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace System.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information identifying the code pages and Unicode subranges for which a given font provides glyphs.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-fontsignature"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// GDI relies on Windows code pages fitting within a 32-bit value.
    /// Furthermore, the highest 2 bits within this value are reserved for GDI internal use and may not be assigned to code pages.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FONTSIGNATURE
    {
        /// <summary>
        /// A 128-bit Unicode subset bitfield (USB) identifying up to 126 Unicode subranges.
        /// Each bit, except the two most significant bits, represents a single subrange.
        /// The most significant bit is always 1 and identifies the bitfield as a font signature;
        /// the second most significant bit is reserved and must be 0.
        /// Unicode subranges are numbered in accordance with the ISO 10646 standard.
        /// For more information, see Unicode Subset Bitfields.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U4, SizeConst = 4)]
        public DWORD[] fsUsb;

        /// <summary>
        /// A 64-bit, code-page bitfield (CPB) that identifies a specific character set or code page.
        /// Code pages are in the lower 32 bits of this bitfield.
        /// The high 32 are used for non-Windows code pages.
        /// For more information, see Code Page Bitfields.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U4, SizeConst = 2)]
        public DWORD[] fsCsb;
    }
}

using System.Util.Win32.BaseTypes;
using System.Util.Win32.Marshals.ByValStringStructs;
using System.Runtime.InteropServices;
using static System.Util.Win32.Kernel32;


namespace System.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a file that the <see cref="OpenFile"/> function opened or attempted to open.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-ofstruct"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct OFSTRUCT
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        public BYTE cBytes;

        /// <summary>
        /// If this member is nonzero, the file is on a hard (fixed) disk. Otherwise, it is not.
        /// </summary>
        public BYTE fFixedDisk;

        /// <summary>
        /// The MS-DOS error code if the <see cref="OpenFile"/> function failed.
        /// </summary>
        public WORD nErrCode;

        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        public WORD Reserved1;

        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        public WORD Reserved2;

        /// <summary>
        /// The path and file name of the file.
        /// </summary>
        public ByValStringStructForSize128 szPathName;
    }
}

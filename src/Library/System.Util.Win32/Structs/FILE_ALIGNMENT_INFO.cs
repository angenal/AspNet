using System.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static System.Util.Win32.Enums.FILE_INFO_BY_HANDLE_CLASS;
using static System.Util.Win32.Kernel32;

namespace System.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains alignment information for a file.
    /// This structure is returned from the <see cref="GetFileInformationByHandleEx"/> function
    /// when <see cref="FileAlignmentInfo"/> is passed in the FileInformationClass parameter.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-file_alignment_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_ALIGNMENT_INFO
    {
        /// <summary>
        /// Minimum alignment requirement, in bytes.
        /// </summary>
        public ULONG AlignmentRequirement;
    }
}

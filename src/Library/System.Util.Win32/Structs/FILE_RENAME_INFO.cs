using System.Runtime.InteropServices;
using static System.Util.Win32.Kernel32;

namespace System.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// This struct is just a PLACEHOLDER, which cannot be defined in C#.
    /// </para>
    /// <para>
    /// Contains the name to which the file should be renamed.
    /// Use only when calling <see cref="SetFileInformationByHandle"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-file_rename_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_RENAME_INFO
    {
    }
}

using static System.Util.Win32.Kernel32;

namespace System.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="DuplicateHandle"/> Options
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/handleapi/nf-handleapi-duplicatehandle"/>
    /// </para>
    /// </summary>
    public enum DuplicateHandleOptions : uint
    {
        /// <summary>
        /// Closes the source handle. This occurs regardless of any error status returned.
        /// </summary>
        DUPLICATE_CLOSE_SOURCE = 0x00000001,

        /// <summary>
        /// Ignores the dwDesiredAccess parameter. The duplicate handle has the same access as the source handle.
        /// </summary>
        DUPLICATE_SAME_ACCESS = 0x00000002,
    }
}

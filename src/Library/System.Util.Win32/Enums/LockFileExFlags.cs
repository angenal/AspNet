using static System.Util.Win32.Kernel32;

namespace System.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="LockFileEx"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-lockfileex"/>
    /// </para>
    /// </summary>
    public enum LockFileExFlags : uint
    {
        /// <summary>
        /// The function requests an exclusive lock. Otherwise, it requests a shared lock.
        /// </summary>
        LOCKFILE_EXCLUSIVE_LOCK = 0x00000002,

        /// <summary>
        /// The function returns immediately if it is unable to acquire the requested lock. Otherwise, it waits.
        /// </summary>
        LOCKFILE_FAIL_IMMEDIATELY = 0x00000001,
    }
}

using static System.Util.Win32.User32;

namespace System.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="MonitorFromWindow"/> flags.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-monitorfromwindow"/>
    /// </para>
    /// </summary>
    public enum MonitorDefaultFlags
    {
        /// <summary>
        /// Returns NULL.
        /// </summary>
        MONITOR_DEFAULTTONULL = 0,

        /// <summary>
        /// MONITOR_DEFAULTTOPRIMARY
        /// </summary>
        MONITOR_DEFAULTTONEAREST = 1,

        /// <summary>
        /// MONITOR_DEFAULTTONEAREST
        /// </summary>
        MONITOR_DEFAULTTOPRIMARY = 2,
    }
}

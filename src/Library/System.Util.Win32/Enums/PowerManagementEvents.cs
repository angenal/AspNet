using static System.Util.Win32.Enums.WindowsMessages;

namespace System.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Power Management Events
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/power/power-management-events"/>
    /// </para>
    /// </summary>
    public enum PowerManagementEvents
    {
        /// <summary>
        /// <para>
        /// Power setting change event sent with a <see cref="WM_POWERBROADCAST"/> window message or
        /// in a HandlerEx notification callback for services.
        /// </para>
        /// </summary>
        PBT_POWERSETTINGCHANGE = 0x8013
    }
}

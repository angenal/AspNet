using System.Util.Win32.Enums;
using System.Util.Win32.Extensions;
using System;
using static System.Util.Win32.Enums.EditControlMessages;

namespace System.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// <para>
        /// Prevents a single-line edit control from receiving keyboard focus.
        /// You can use this macro or send the <see cref="EM_NOSETFOCUS"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-edit_nosetfocus"/>
        /// </para>
        /// </summary>
        /// <param name="hwndCtl">
        /// A handle to the edit control.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The <see cref="EM_NOSETFOCUS"/> message is ignored if the edit control is not a single-line edit control.
        /// After this message is sent, the effect is permanent.
        /// </remarks>
        [Obsolete("Intended for internal use; not recommended for use in applications." +
            "This macro may not be supported in future versions of Windows.")]
        public static uint Edit_NoSetFocus(IntPtr hwndCtl) =>
            SendMessage(hwndCtl, (WindowsMessages)EM_NOSETFOCUS, UIntPtr.Zero, IntPtr.Zero).SafeToUInt32();

        /// <summary>
        /// Forces a single-line edit control to receive keyboard focus.
        /// You can use this macro or send the <see cref="EM_TAKEFOCUS"/> message explicitly.
        /// </summary>
        /// <param name="hwndCtl">
        /// A handle to the edit control.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The <see cref="EM_TAKEFOCUS"/> message is ignored if the edit control is not a single-line edit control.
        /// If the edit control previously received an <see cref="EM_NOSETFOCUS"/> message,
        /// the edit control will appear to have the focus without actually having it; otherwise, the edit control will receive focus.
        /// </remarks>
        [Obsolete("Intended for internal use; not recommended for use in applications." +
            "This macro may not be supported in future versions of Windows.")]
        public static uint Edit_TakeFocus(IntPtr hwndCtl) =>
            SendMessage(hwndCtl, (WindowsMessages)EM_TAKEFOCUS, UIntPtr.Zero, IntPtr.Zero).SafeToUInt32();
    }
}

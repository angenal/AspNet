using System.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static System.Util.Win32.Shell32;

namespace System.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains data used by <see cref="SHAddToRecentDocs"/> to identify both an item—
    /// in this case as an <see cref="IShellItem"/>—and the process that it is associated with.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shlobj_core/ns-shlobj_core-shardappidinfo"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHARDAPPIDINFO
    {
        /// <summary>
        /// Pointer to an <see cref="IShellItem"/> object that represents the object in the Shell namespace.
        /// </summary>
        [MarshalAs(UnmanagedType.Interface)]
        public IShellItem psi;

        /// <summary>
        /// The application-defined AppUserModelID associated with the item.
        /// </summary>
        public IntPtr pszAppID;
    }
}

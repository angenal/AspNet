using System.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace System.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a dynamic-link library (DLL) that has just been unloaded.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/minwinbase/ns-minwinbase-unload_dll_debug_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct UNLOAD_DLL_DEBUG_INFO
    {
        /// <summary>
        /// A pointer to the base address of the DLL in the address space of the process unloading the DLL.
        /// </summary>
        public LPVOID lpBaseOfDll;
    }
}

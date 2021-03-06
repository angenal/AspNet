using System.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static System.Util.Win32.Kernel32;

namespace System.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents information about a NUMA node in a processor group.
    /// This structure is used with the <see cref="GetLogicalProcessorInformationEx"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-numa_node_relationship"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct NUMA_NODE_RELATIONSHIP
    {
        /// <summary>
        /// The number of the NUMA node.
        /// </summary>
        public DWORD NodeNumber;

        /// <summary>
        /// This member is reserved.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public BYTE[] Reserved;

        /// <summary>
        /// A <see cref="GROUP_AFFINITY"/> structure that specifies a group number and processor affinity within the group.
        /// </summary>
        public GROUP_AFFINITY GroupMask;
    }
}

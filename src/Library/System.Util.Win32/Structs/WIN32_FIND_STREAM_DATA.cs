using System.Util.Win32.BaseTypes;
using System.Util.Win32.Marshals.ByValStringStructs;
using System.Runtime.InteropServices;
using static System.Util.Win32.Kernel32;

namespace System.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the stream found by the <see cref="FindFirstStreamW"/> or <see cref="FindNextStreamW"/> function.
    /// </para>
    /// <para>
    /// From: 
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WIN32_FIND_STREAM_DATA
    {
        /// <summary>
        /// A <see cref="LARGE_INTEGER"/> value that specifies the size of the stream, in bytes.
        /// </summary>
        public LARGE_INTEGER StreamSize;

        /// <summary>
        /// The name of the stream.
        /// The string name format is ":streamname:$streamtype".
        /// </summary>
        public ByValStringStructForSize296 cStreamName;
    }
}

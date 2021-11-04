using System.Util.Win32.Structs;

namespace System.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="PROFILEINFO"/> Flags
    /// </summary>
    public enum PROFILEINFOFlags : uint
    {
        /// <summary>
        /// PI_NOUI
        /// </summary>
        PI_NOUI = 0x00000001,

        /// <summary>
        /// PI_APPLYPOLICY
        /// </summary>
        PI_APPLYPOLICY = 0x00000002,
    }
}

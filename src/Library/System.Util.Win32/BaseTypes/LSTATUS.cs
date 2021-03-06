using System.Runtime.InteropServices;

namespace System.Util.Win32.BaseTypes
{
    /// <summary>
    /// LSTATUS
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct LSTATUS
    {
        [FieldOffset(0)]
        private int _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator int(LSTATUS val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LSTATUS(int val) => new LSTATUS { _value = val };
    }
}

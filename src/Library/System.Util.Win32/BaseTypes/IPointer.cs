using System;

namespace System.Util.Win32.BaseTypes
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPointer
    {
        /// <summary>
        /// To <see cref="IntPtr"/>
        /// </summary>
        /// <returns></returns>
        IntPtr ToIntPtr();
    }
}

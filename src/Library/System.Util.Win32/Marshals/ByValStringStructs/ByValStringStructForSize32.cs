﻿using System.Util.IL;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace System.Util.Win32.Marshals.ByValStringStructs
{
    /// <summary>
    /// By Val String Struct For Size 32
    /// </summary>
    [DebuggerDisplay("{ToString()}")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 32 * sizeof(char))]
    public unsafe struct ByValStringStructForSize32
    {
        char _firstChar;

        /// <inheritdoc/>
        public override string ToString()
        {
            fixed (char* charPtr = &_firstChar)
            {
                return new string(charPtr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ByValStringStructForSize32(string val)
        {
            if (val.Length > 32 - 1)
            {
                throw new ArgumentException("String too long");
            }
            var result = new ByValStringStructForSize32();
            fixed (char* strPtr = val)
            {
                Unsafe.CopyBlock(&result, strPtr, (uint)(val.Length * sizeof(char)));
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator string(ByValStringStructForSize32 val) => val.ToString();
    }
}

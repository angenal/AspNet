using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Util.Win32.Marshals
{
    internal class AlternativeStructObjectMarshaler<T1, T2> : ICustomMarshaler where T1 : struct where T2 : struct
    {
        static AlternativeStructObjectMarshaler<T1, T2> instance = new AlternativeStructObjectMarshaler<T1, T2>();

        public static ICustomMarshaler GetInstance(string cookie) => instance;

        [ThreadStatic] IntPtr? marshaledIntPtr;

        public void CleanUpManagedData(object ManagedObj)
        {
            if (marshaledIntPtr != null)
            {
                Marshal.FreeHGlobal(marshaledIntPtr.Value);
            }
        }

        public void CleanUpNativeData(IntPtr pNativeData) => throw new NotImplementedException();

        public int GetNativeDataSize() => IntPtr.Size;

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            if (ManagedObj is AlternativeStructObject<T1, T2> obj)
            {
                if (obj.IsStruct1)
                {
                    marshaledIntPtr = MarshalExtensions.StructureToPtr(obj.T1Val);
                    return marshaledIntPtr.Value;
                }
                else if (obj.IsStruct2)
                {
                    marshaledIntPtr = MarshalExtensions.StructureToPtr(obj.T2Val);
                    return marshaledIntPtr.Value;
                }
                else
                {
                    return IntPtr.Zero;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public object MarshalNativeToManaged(IntPtr pNativeData) => throw new NotImplementedException();
    }
}

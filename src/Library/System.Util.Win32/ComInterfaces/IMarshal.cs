﻿using System.Util.Win32.BaseTypes;
using System.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static System.Util.Win32.BaseTypes.HRESULT;
using static System.Util.Win32.Constants;
using static System.Util.Win32.Enums.MSHCTX;
using static System.Util.Win32.Ole32;

namespace System.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables a COM object to define and manage the marshaling of its interface pointers.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/nn-objidl-imarshal"/>
    /// </para>
    /// </summary>
    public unsafe struct IMarshal
    {
        IntPtr* _vTable;

        /// <summary>
        /// Retrieves the CLSID of the unmarshaling code.
        /// </summary>
        /// <param name="riid">
        /// A reference to the identifier of the interface to be marshaled.
        /// </param>
        /// <param name="pv">
        /// A pointer to the interface to be marshaled; can be <see cref="NULL"/> if the caller does not have a pointer to the desired interface.
        /// </param>
        /// <param name="dwDestContext">
        /// The destination context where the specified interface is to be unmarshaled.
        /// Possible values come from the enumeration <see cref="MSHCTX"/>.
        /// Unmarshaling can occur either in another apartment of the current process (<see cref="MSHCTX_INPROC"/>)
        /// or in another process on the same computer as the current process (<see cref="MSHCTX_LOCAL"/>).
        /// </param>
        /// <param name="pvDestContext">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <param name="mshlflags">
        /// Indicates whether the data to be marshaled is to be transmitted back
        /// to the client processâ€”the typical caseâ€”or written to a global table, where it can be retrieved by multiple clients.
        /// Possible values come from the <see cref="MSHLFLAGS"/> enumeration.
        /// </param>
        /// <param name="pCid">
        /// A pointer that receives the CLSID to be used to create a proxy in the client process.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="S_OK"/>.
        /// Otherwise, it is <see cref="S_FALSE"/>.
        /// </returns>
        /// <remarks>
        /// This method is called indirectly, in a call to <see cref="CoMarshalInterface"/>,
        /// by whatever code in the server process is responsible for marshaling a pointer to an interface on an object.
        /// This marshaling code is usually a stub generated by COM for one of several interfaces
        /// that can marshal a pointer to an interface implemented on an entirely different object.
        /// Examples include the <see cref="IClassFactory"/> and <see cref="IOleItemContainer"/> interfaces.
        /// For purposes of discussion, the code responsible for marshaling a pointer is called the marshaling stub.
        /// To create a proxy for an object, COM requires two pieces of information from the original object:
        /// the amount of data to be written to the marshaling stream and the proxy's CLSID.
        /// The marshaling stub obtains these two pieces of information
        /// with successive calls to <see cref="CoGetMarshalSizeMax"/> and <see cref="CoMarshalInterface"/>.
        /// Notes to Callers
        /// The marshaling stub calls the object's implementation of this method to obtain the CLSID to be used in creating an instance of the proxy.
        /// The client, upon receiving the CLSID, loads the DLL listed for it in the system registry.
        /// You do not explicitly call this method if you are implementing existing COM interfaces
        /// or using the Microsoft Interface Definition Language (MIDL) to define your own interfaces.
        /// In either case, the stub automatically makes the call. See Defining COM Interfaces.
        /// If you are not using MIDL to define your own interface, your stub must call this method, either directly or indirectly,
        /// to get the CLSID that the client-side COM library needs to create a proxy for the object implementing the interface.
        /// If the caller has a pointer to the interface to be marshaled, it should,
        /// as a matter of efficiency, use the <paramref name="pv"/> parameter to pass that pointer.
        /// In this way, an implementation that may use such a pointer to determine the appropriate CLSID
        /// for the proxy does not have to call QueryInterface on itself.
        /// If a caller does not have a pointer to the interface to be marshaled, it can pass <see cref="NULL"/>.
        /// Notes to Implementers
        /// COM calls <see cref="GetUnmarshalClass"/> to obtain the CLSID to be used for creating a proxy in the client process.
        /// The CLSID to be used for a proxy is normally not that of the original object,
        /// but one you will have generated (using the Guidgen.exe tool) specifically for your proxy object.
        /// Implement this method for each object that provides marshaling for one or more of its interfaces.
        /// The code responsible for marshaling the object writes the CLSID, along with the marshaling data, to a stream;
        /// COM extracts the CLSID and data from the stream on the receiving side.
        /// If your proxy implementation consists simply of copying the entire original object into the client process,
        /// thereby eliminating the need to forward calls to the original object, the CLSID returned would be the same as that of the original object.
        /// This strategy, of course, is advisable only for objects that are not expected to change.
        /// If the <paramref name="pv"/> parameter is <see cref="NULL"/> and your implementation needs an interface pointer,
        /// it can call QueryInterface on the current object to get it.
        /// The <paramref name="pv"/> parameter exists merely to improve efficiency.
        /// To ensure that your implementation of <see cref="GetUnmarshalClass"/> continues to work properly
        /// as new destination contexts are supported in the future, delegate marshaling to the COM default implementation
        /// for all <paramref name="dwDestContext"/> values that your implementation does not handle.
        /// To delegate marshaling to the COM default implementation, call the <see cref="CoGetStandardMarshal"/> function.
        /// Note
        /// The ThreadingModel registry value must be Both for an in-process server
        /// that implements the CLSID returned from the <see cref="GetUnmarshalClass"/> method.
        /// For more information, see InprocServer32.
        /// </remarks>
        public HRESULT GetUnmarshalClass([In] in IID riid, [In] IntPtr pv, [In] MSHCTX dwDestContext, [In] IntPtr pvDestContext,
            [In] MSHLFLAGS mshlflags, [Out] out CLSID pCid)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IID, PVOID, MSHCTX, IntPtr, MSHLFLAGS, out CLSID, HRESULT>)_vTable[3])(thisPtr, riid, pv, dwDestContext, pvDestContext, mshlflags, out pCid);
            }
        }

        /// <summary>
        /// Retrieves the maximum size of the buffer that will be needed during marshaling.
        /// </summary>
        /// <param name="riid">
        /// A reference to the identifier of the interface to be marshaled.
        /// </param>
        /// <param name="pv">
        /// The interface pointer to be marshaled. This parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="dwDestContext">
        /// The destination context where the specified interface is to be unmarshaled.
        /// Possible values come from the enumeration <see cref="MSHCTX"/>.
        /// Unmarshaling can occur either in another apartment of the current process (<see cref="MSHCTX_INPROC"/>)
        /// or in another process on the same computer as the current process (<see cref="MSHCTX_LOCAL"/>).
        /// </param>
        /// <param name="pvDestContext">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <param name="mshlflags">
        /// Indicates whether the data to be marshaled is to be transmitted back
        /// to the client processâ€”the typical caseâ€”or written to a global table, where it can be retrieved by multiple clients.
        /// Possible values come from the <see cref="MSHLFLAGS"/> enumeration.
        /// </param>
        /// <param name="pSize">
        /// A pointer to a variable that receives the maximum size of the buffer.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_FAIL"/> and <see cref="S_OK"/>, as well as the following value.
        /// <see cref="E_NOINTERFACE"/>: The specified interface is not supported. 
        /// </returns>
        /// <remarks>
        /// This method is called indirectly, in a call to <see cref="CoGetMarshalSizeMax"/>,
        /// by whatever code in the server process is responsible for marshaling a pointer to an interface on an object.
        /// This marshaling code is usually a stub generated by COM for one of several interfaces
        /// that can marshal a pointer to an interface implemented on an entirely different object.
        /// Examples include the <see cref="IClassFactory"/> and <see cref="IOleItemContainer"/> interfaces.
        /// For purposes of discussion, the code responsible for marshaling a pointer is called the marshaling stub.
        /// To create a proxy for an object, COM requires two pieces of information from the original object:
        /// the amount of data to be written to the marshaling stream and the proxy's CLSID.
        /// The marshaling stub obtains these two pieces of information
        /// with successive calls to <see cref="CoGetMarshalSizeMax"/> and <see cref="CoMarshalInterface"/>.
        /// Notes to Callers
        /// The marshaling stub, through a call to <see cref="CoGetMarshalSizeMax"/>,
        /// calls the object's implementation of this method to preallocate the stream buffer that will be passed to <see cref="MarshalInterface"/>.
        /// You do not explicitly call this method if you are implementing existing COM interfaces
        /// or using the Microsoft Interface Definition Language (MIDL) to define your own custom interfaces.
        /// In either case, the MIDL-generated stub automatically makes the call.
        /// If you are not using MIDL to define your own interface (see Defining COM Interfaces),
        /// your marshaling stub does not have to call <see cref="GetMarshalSizeMax"/>, although doing so is highly recommended.
        /// An object knows better than an interface stub what the maximum size of a marshaling data packet is likely to be.
        /// Therefore, unless you are providing an automatically growing stream that
        /// is so efficient that the overhead of expanding it is insignificant,
        /// you should call this method even when implementing your own interfaces.
        /// The value returned by this method is guaranteed to be valid
        /// only as long as the internal state of the object being marshaled does not change.
        /// Therefore, the actual marshaling should be done immediately after this function returns,
        /// or the stub runs the risk that the object, because of some change in state,
        /// might require more memory to marshal than it originally indicated.
        /// Notes to Implementers
        /// Your implementation of <see cref="MarshalInterface"/> will use the preallocated buffer to write marshaling data into the stream.
        /// If the buffer is too small, the marshaling operation will fail.
        /// Therefore, the value returned by this method must be a conservative estimate of the amount of data
        /// that will be needed to marshal the interface.
        /// Violation of this requirement should be treated as a catastrophic error.
        /// In a subsequent call to <see cref="MarshalInterface"/>, your <see cref="IMarshal"/> implementation
        /// cannot rely on the caller actually having called <see cref="GetMarshalSizeMax"/> beforehand.
        /// It must still be wary of <see cref="STG_E_MEDIUMFULL"/> errors returned by the stream and be prepared to handle them gracefully.
        /// To ensure that your implementation of <see cref="GetMarshalSizeMax"/> will continue to work properly
        /// as new destination contexts are supported in the future, delegate marshaling to the COM default implementation
        /// for all <paramref name="dwDestContext"/> values that your implementation does not understand.
        /// To delegate marshaling to the COM default implementation, call the <see cref="CoGetStandardMarshal"/> function.
        /// </remarks>
        public HRESULT GetMarshalSizeMax([In] in IID riid, [In] IntPtr pv, [In] MSHCTX dwDestContext, [In] IntPtr pvDestContext,
               [In] MSHLFLAGS mshlflags, [Out] out DWORD pSize)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IID, IntPtr, MSHCTX, IntPtr, MSHLFLAGS, out DWORD, HRESULT>)_vTable[4])(thisPtr, riid, pv, dwDestContext, pvDestContext, mshlflags, out pSize);
            }
        }

        /// <summary>
        /// Marshals an interface pointer.
        /// </summary>
        /// <param name="pStm">
        /// A pointer to the stream to be used during marshaling.
        /// </param>
        /// <param name="riid">
        /// A reference to the identifier of the interface to be marshaled.
        /// This interface must be derived from the <see cref="IUnknown"/> interface.
        /// </param>
        /// <param name="pv">
        /// A pointer to the interface pointer to be marshaled.
        /// This parameter can be <see cref="NULL"/> if the caller does not have a pointer to the desired interface.
        /// </param>
        /// <param name="dwDestContext">
        /// The destination context where the specified interface is to be unmarshaled.
        /// Possible values for <paramref name="dwDestContext"/> come from the enumeration <see cref="MSHCTX"/>.
        /// Currently, unmarshaling can occur either in another apartment of the current process (<see cref="MSHCTX_INPROC"/>)
        /// or in another process on the same computer as the current process (<see cref="MSHCTX_LOCAL"/>).
        /// </param>
        /// <param name="pvDestContext">
        /// This parameter is reserved and must be 0.
        /// </param>
        /// <param name="mshlflags">
        /// Indicates whether the data to be marshaled is to be transmitted back
        /// to the client process—the typical case—or written to a global table, where it can be retrieved by multiple clients.
        /// Possible values come from the <see cref="MSHLFLAGS"/> enumeration.
        /// </param>
        /// <returns></returns>
        public HRESULT MarshalInterface([In] in IStream pStm, [In] in IID riid, [In] IntPtr pv, [In] MSHCTX dwDestContext,
            [In] IntPtr pvDestContext, [In] MSHLFLAGS mshlflags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IStream, in IID, IntPtr, MSHCTX, IntPtr, MSHLFLAGS, HRESULT>)_vTable[5])(thisPtr, pStm, riid, pv, dwDestContext, pvDestContext, mshlflags);
            }
        }

        /// <summary>
        /// Unmarshals an interface pointer.
        /// </summary>
        /// <param name="pStm">
        /// A pointer to the stream from which the interface pointer is to be unmarshaled.
        /// </param>
        /// <param name="riid">
        /// A reference to the identifier of the interface to be unmarshaled.
        /// </param>
        /// <param name="ppv">
        /// The address of pointer variable that receives the interface pointer.
        /// Upon successful return, *<paramref name="ppv"/> contains the requested interface pointer of the interface to be unmarshaled.
        /// </param>
        /// <returns>
        /// This method can return the standard return value <see cref="E_FAIL"/>, as well as the following values.
        /// <see cref="S_OK"/>: The interface pointer was unmarshaled successfully.
        /// <see cref="E_NOINTERFACE"/>: The specified interface is not supported. 
        /// </returns>
        /// <remarks>
        /// The COM library in the process where unmarshaling is to occur calls the proxy's implementation of this method.
        /// Notes to Callers
        /// You do not call this method directly.
        /// There are, however, some situations in which you might call it indirectly through a call to <see cref="CoUnmarshalInterface"/>.
        /// For example, if you are implementing a stub, your implementation would call <see cref="CoUnmarshalInterface"/>
        /// when the stub receives an interface pointer as a parameter in a method call.
        /// Notes to Implementers
        /// The proxy's implementation should read the data written to the stream
        /// by the original object's implementation of <see cref="MarshalInterface"/> and use that data
        /// to initialize the proxy object whose CLSID was returned by the marshaling stub's call
        /// to the original object's implementation of <see cref="GetUnmarshalClass"/>.
        /// To return the appropriate interface pointer, the proxy implementation can simply call QueryInterface on itself,
        /// passing the <paramref name="riid"/> and <paramref name="ppv"/> parameters.
        /// However, your implementation of <see cref="UnmarshalInterface"/> is free
        /// to create a different object and, if necessary, return a pointer to it.
        /// Just before exiting, even if exiting with an error, your implementation should reposition
        /// the seek pointer in the stream immediately after the last byte of data read.
        /// </remarks>
        public HRESULT UnmarshalInterface([In] in IStream pStm, [In] in IID riid, [Out] out IntPtr ppv)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IStream, in IID, out IntPtr, HRESULT>)_vTable[6])(thisPtr, pStm, riid, out ppv);
            }
        }

        /// <summary>
        /// Destroys a marshaled data packet.
        /// </summary>
        /// <param name="pStm">
        /// A pointer to a stream that contains the data packet to be destroyed.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="S_OK"/> and <see cref="E_FAIL"/>,
        /// as well as any of the stream-access errors for the <see cref="IStream"/> interface.
        /// </returns>
        /// <remarks>
        /// If an object's marshaled data packet does not get unmarshaled in the client process space and the packet is no longer needed,
        /// the client calls <see cref="ReleaseMarshalData"/> on the proxy's <see cref="IMarshal"/> implementation
        /// to instruct the object to destroy the data packet.
        /// The call occurs within the <see cref="CoReleaseMarshalData"/> function.
        /// The data packet serves as an additional reference on the object,
        /// and releasing the data is like releasing an interface pointer by calling Release.
        /// If the marshaled data packet somehow does not arrive in the client process
        /// or if <see cref="ReleaseMarshalData"/> is not successfully re-created in the proxy, COM can call this method on the object itself.
        /// Notes to Callers
        /// You will rarely if ever have occasion to call this method yourself.
        /// A possible exception would be if you were to implement <see cref="IMarshal"/> on a class factory
        /// for a class object on which you are also implementing <see cref="IMarshal"/>.
        /// In this case, if you were marshaling the object to a table where it could be retrieved by multiple clients,
        /// you might, as part of your unmarshaling routine, call <see cref="ReleaseMarshalData"/> to release the data packet for each proxy.
        /// Notes to Implementers
        /// If your implementation stores state information about marshaled data packets,
        /// you can use this method to release the state information associated with the data packet represented by <paramref name="pStm"/>.
        /// Your implementation should also position the seek pointer in the stream past the last byte of data. 
        /// </remarks>
        public HRESULT ReleaseMarshalData([In] in IStream pStm)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IStream, HRESULT>)_vTable[7])(thisPtr, pStm);
            }
        }

        /// <summary>
        /// Releases all connections to an object.
        /// The object's server calls the object's implementation of this method prior to shutting down.
        /// </summary>
        /// <param name="dwReserved">
        /// This parameter is reserved and must be 0.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="S_OK"/>.
        /// Otherwise, it is <see cref="E_FAIL"/>.
        /// </returns>
        /// <remarks>
        /// This method is implemented on the object, not the proxy.
        /// Notes to Callers
        /// The usual case in which this method is called occurs when an end user forcibly closes a COM server
        /// that has one or more running objects that implement <see cref="IMarshal"/>.
        /// Prior to shutting down, the server calls the <see cref="CoDisconnectObject"/> function
        /// to release external connections to all its running objects.
        /// For each object that implements <see cref="IMarshal"/>, however, this function calls <see cref="DisconnectObject"/>
        /// so that each object that manages its own marshaling can take steps to notify its proxy that it is about to shut down.
        /// Notes to Implementers
        /// As part of its normal shutdown code, a server should call <see cref="CoDisconnectObject"/>,
        /// which in turn calls <see cref="DisconnectObject"/>, on each of its running objects that implements <see cref="IMarshal"/>.
        /// The outcome of any implementation of this method should be to enable a proxy to respond to all subsequent calls
        /// from its client by returning <see cref="RPC_E_DISCONNECTED"/> or <see cref="CO_E_OBJNOTCONNECTED"/> rather than
        /// attempting to forward the calls on to the original object.
        /// It is up to the client to destroy the proxy.
        /// If you are implementing this method for an immutable object, such as a moniker,
        /// your implementation does not need to do anything because such objects are typically copied whole into the client's address space.
        /// Therefore, they have neither a proxy nor a connection to the original object.
        /// For more information on marshaling immutable objects, see the "When to Implement" section of the IMarshal topic.
        /// </remarks>
        public HRESULT DisconnectObject([In] DWORD dwReserved)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, HRESULT>)_vTable[7])(thisPtr, dwReserved);
            }
        }
    }
}

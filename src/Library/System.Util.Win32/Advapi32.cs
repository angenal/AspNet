using System.Util.Win32.BaseTypes;
using System.Util.Win32.Enums;
using System.Util.Win32.Marshals;
using System.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static System.Util.Win32.BaseTypes.ACCESS_MASK;
using static System.Util.Win32.BaseTypes.BOOL;
using static System.Util.Win32.BaseTypes.WaitResult;
using static System.Util.Win32.Constants;
using static System.Util.Win32.Enums.AclRevisions;
using static System.Util.Win32.Enums.GroupAttributes;
using static System.Util.Win32.Enums.LoginProviders;
using static System.Util.Win32.Enums.LogonFlags;
using static System.Util.Win32.Enums.LogonTypes;
using static System.Util.Win32.Enums.NTSTATUS;
using static System.Util.Win32.Enums.PrivilegeAttributes;
using static System.Util.Win32.Enums.ProcessAccessRights;
using static System.Util.Win32.Enums.ProcessCreationFlags;
using static System.Util.Win32.Enums.ProcessPriorityClasses;
using static System.Util.Win32.Enums.SECURITY_DESCRIPTOR_CONTROL;
using static System.Util.Win32.Enums.SECURITY_IMPERSONATION_LEVEL;
using static System.Util.Win32.Enums.SystemErrorCodes;
using static System.Util.Win32.Enums.ThreadAccessRights;
using static System.Util.Win32.Enums.TOKEN_INFORMATION_CLASS;
using static System.Util.Win32.Enums.TOKEN_TYPE;
using static System.Util.Win32.Enums.TokenAccessRights;
using static System.Util.Win32.Kernel32;
using static System.Util.Win32.Shell32;
using static System.Util.Win32.UnsafePInvokeExtensions;
using static System.Util.Win32.User32;
using static System.Util.Win32.Userenv;

namespace System.Util.Win32
{
    /// <summary>
    /// Advapi32.dll
    /// </summary>
    public static partial class Advapi32
    {
        /// <summary>
        /// MAX_SHUTDOWN_TIMEOUT
        /// </summary>
        public const int MAX_SHUTDOWN_TIMEOUT = 10 * 365 * 24 * 60 * 60;

        /// <summary>
        /// <para>
        /// The <see cref="AccessCheck"/> function determines whether a security descriptor
        /// grants a specified set of access rights to the client identified by an access token.
        /// Typically, server applications use this function to check access to a private object.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/securitybaseapi/nf-securitybaseapi-accesscheck"/>
        /// </para>
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure against which access is checked.
        /// </param>
        /// <param name="ClientToken">
        /// A handle to an impersonation token that represents the client that is attempting to gain access.
        /// The handle must have <see cref="TOKEN_QUERY"/> access to the token; otherwise, the function fails with <see cref="ERROR_ACCESS_DENIED"/>.
        /// </param>
        /// <param name="DesiredAccess">
        /// Access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function to contain no generic access rights.
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>, the function sets the <paramref name="GrantedAccess"/> access mask
        /// to indicate the maximum access rights the security descriptor allows the client.
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to the <see cref="GENERIC_MAPPING"/> structure associated with the object for which access is being checked.
        /// </param>
        /// <param name="PrivilegeSet">
        /// A pointer to a <see cref="PRIVILEGE_SET"/> structure that receives the privileges used to perform the access validation.
        /// If no privileges were used, the function sets the <see cref="PrivilegeCount"/> member to zero.
        /// </param>
        /// <param name="PrivilegeSetLength">
        /// Specifies the size, in bytes, of the buffer pointed to by the <paramref name="PrivilegeSet"/> parameter.
        /// </param>
        /// <param name="GrantedAccess">
        /// A pointer to an access mask that receives the granted access rights.
        /// If <paramref name="AccessStatus"/> is set to FALSE, the function sets the access mask to zero.
        /// If the function fails, it does not set the access mask.
        /// </param>
        /// <param name="AccessStatus">
        /// A pointer to a variable that receives the results of the access check.
        /// If the security descriptor allows the requested access rights to the client identified by the access token,
        /// <paramref name="AccessStatus"/> is set to <see cref="TRUE"/>.
        /// Otherwise, <paramref name="AccessStatus"/> is set to <see cref="FALSE"/>,
        /// and you can call <see cref="GetLastError"/> to get extended error information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For more information, see the How AccessCheck Works overview.
        /// The <see cref="AccessCheck"/> function compares the specified security descriptor with the specified access token and indicates,
        /// in the <paramref name="AccessStatus"/> parameter, whether access is granted or denied.
        /// If access is granted, the requested access mask becomes the object's granted access mask.
        /// If the security descriptor's DACL is <see cref="NULL"/>, the <paramref name="AccessStatus"/> parameter returns <see cref="TRUE"/>,
        /// which indicates that the client has the requested access.
        /// The <see cref="AccessCheck"/> function fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>
        /// if the security descriptor does not contain owner and group SIDs.
        /// The <see cref="AccessCheck"/> function does not generate an audit.
        /// If your application requires audits for access checks, use functions such as <see cref="AccessCheckAndAuditAlarm"/>,
        /// <see cref="AccessCheckByTypeAndAuditAlarm"/>, <see cref="AccessCheckByTypeResultListAndAuditAlarm"/>,
        /// or <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/>, instead of <see cref="AccessCheck"/>.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessCheck", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AccessCheck([In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] HANDLE ClientToken, [In] ACCESS_MASK DesiredAccess,
            [In] in GENERIC_MAPPING GenericMapping, [In] in PPRIVILEGE_SET PrivilegeSet, [In][Out] ref DWORD PrivilegeSetLength,
            [Out] out ACCESS_MASK GrantedAccess, [Out] out BOOL AccessStatus);

        /// <summary>
        /// <para>
        /// The <see cref="AccessCheckAndAuditAlarm"/> function determines whether a security descriptor
        /// grants a specified set of access rights to the client being impersonated by the calling thread.
        /// If the security descriptor has a SACL with ACEs that apply to the client,
        /// the function generates any necessary audit messages in the security event log.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/securitybaseapi/nf-securitybaseapi-accesscheckandauditalarmw"/>
        /// </para>
        /// </summary>
        /// <param name="SubsystemName">
        /// A pointer to a null-terminated string specifying the name of the subsystem calling the function.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="HandleId">
        /// A pointer to a unique value representing the client's handle to the object.
        /// If the access is denied, the system ignores this value.
        /// </param>
        /// <param name="ObjectTypeName">
        /// A pointer to a null-terminated string specifying the type of object being created or accessed.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="ObjectName">
        /// A pointer to a null-terminated string specifying the name of the object being created or accessed.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="SecurityDescriptor">
        /// A pointer to the <see cref="SECURITY_DESCRIPTOR"/> structure against which access is checked.
        /// </param>
        /// <param name="DesiredAccess">
        /// Access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function to contain no generic access rights.
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>, the function sets the <paramref name="GrantedAccess"/> access mask
        /// to indicate the maximum access rights the security descriptor allows the client.
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to the <see cref="GENERIC_MAPPING"/> structure associated with the object for which access is being checked.
        /// </param>
        /// <param name="ObjectCreation">
        /// Specifies a flag that determines whether the calling application will create a new object when access is granted.
        /// A value of <see cref="TRUE"/> indicates the application will create a new object.
        /// A value of <see cref="FALSE"/> indicates the application will open an existing object.
        /// </param>
        /// <param name="GrantedAccess">
        /// A pointer to an access mask that receives the granted access rights.
        /// If <paramref name="AccessStatus"/> is set to <see cref="FALSE"/>, the function sets the access mask to zero.
        /// If the function fails, it does not set the access mask.
        /// </param>
        /// <param name="AccessStatus">
        /// A pointer to a variable that receives the results of the access check.
        /// If the security descriptor allows the requested access rights to the client, 
        /// <paramref name="AccessStatus"/> is set to <see cref="TRUE"/>.
        /// Otherwise, <paramref name="AccessStatus"/> is set to <see cref="FALSE"/>.
        /// </param>
        /// <param name="pfGenerateOnClose">
        /// A pointer to a flag set by the audit-generation routine when the function returns.
        /// Pass this flag to the <see cref="ObjectCloseAuditAlarm"/> function when the object handle is closed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For more information, see the How AccessCheck Works overview.
        /// The <see cref="AccessCheckAndAuditAlarm"/> function requires the calling process to have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The test for this privilege is performed against the primary token of the calling process, not the impersonation token of the thread.
        /// The <see cref="AccessCheckAndAuditAlarm"/> function fails if the calling thread is not impersonating a client.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessCheckAndAuditAlarmW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AccessCheckAndAuditAlarm([In] LPCWSTR SubsystemName, [In] LPVOID HandleId, [In] LPCWSTR ObjectTypeName,
            [In] LPCWSTR ObjectName, [In] PSECURITY_DESCRIPTOR SecurityDescriptor, [In] ACCESS_MASK DesiredAccess,
            [In] in GENERIC_MAPPING GenericMapping, [In] BOOL ObjectCreation, [Out] out ACCESS_MASK GrantedAccess,
            [Out] out BOOL AccessStatus, [Out] out BOOL pfGenerateOnClose);

        /// <summary>
        /// <para>
        /// The <see cref="AccessCheckByType"/> function determines whether a security descriptor
        /// grants a specified set of access rights to the client identified by an access token.
        /// The function can check the client's access to a hierarchy of objects, such as an object, its property sets, and properties.
        /// The function grants or denies access to the hierarchy as a whole.
        /// Typically, server applications use this function to check access to a private object.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-accesscheckbytype"/>
        /// </para> 
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure against which access is checked.
        /// </param>
        /// <param name="PrincipalSelfSid">
        /// A pointer to a security identifier (SID).
        /// If the security descriptor is associated with an object that represents a principal (for example, a user object),
        /// the <paramref name="PrincipalSelfSid"/> parameter should be the SID of the object.
        /// When evaluating access, this SID logically replaces the SID in any ACE that contains the well-known PRINCIPAL_SELF SID (S-1-5-10).
        /// For information about well-known SIDs, see Well-known SIDs.
        /// Set this parameter to <see cref="NULL"/> if the protected object does not represent a principal.
        /// </param>
        /// <param name="ClientToken">
        /// A handle to an impersonation token that represents the client attempting to gain access.
        /// The handle must have <see cref="TOKEN_QUERY"/> access to the token;
        /// otherwise, the function fails with <see cref="ERROR_ACCESS_DENIED"/>.
        /// </param>
        /// <param name="DesiredAccess">
        /// An access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function so that it contains no generic access rights.
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>, the function sets the access mask in <paramref name="GrantedAccess"/>
        /// to indicate the maximum access rights the security descriptor allows the client.
        /// </param>
        /// <param name="ObjectTypeList">
        /// A pointer to an array of <see cref="OBJECT_TYPE_LIST"/> structures that identify the hierarchy of object types for which to check access.
        /// Each element in the array specifies a GUID that identifies the object type
        /// and a value that indicates the level of the object type in the hierarchy of object types.
        /// The array should not have two elements with the same GUID.
        /// The array must have at least one element.
        /// The first element in the array must be at level zero and identify the object itself.
        /// The array can have only one level zero element.
        /// The second element is a subobject, such as a property set, at level 1.
        /// Following each level 1 entry are subordinate entries for the level 2 through 4 subobjects.
        /// Thus, the levels for the elements in the array might be {0, 1, 2, 2, 1, 2, 3}.
        /// If the object type list is out of order, <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> fails,
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// If <paramref name="ObjectTypeList"/> is <see cref="NULL"/>,
        /// <see cref="AccessCheckByType"/> is the same as the <see cref="AccessCheck"/> function.
        /// </param>
        /// <param name="ObjectTypeListLength">
        /// The number of elements in the <paramref name="ObjectTypeList"/> array.
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to the <see cref="GENERIC_MAPPING"/> structure associated with the object for which access is being checked.
        ///  The <see cref="GENERIC_MAPPING.GenericAll"/> member of the <see cref="GENERIC_MAPPING"/> structure
        ///  should contain all the access rights that can be granted by the resource manager,
        ///  including <see cref="STANDARD_RIGHTS_ALL"/> and all of the rights that are set in the <see cref="GENERIC_MAPPING.GenericRead"/>,
        ///  <see cref="GENERIC_MAPPING.GenericWrite"/>, and <see cref="GENERIC_MAPPING.GenericExecute"/> members.
        /// </param>
        /// <param name="PrivilegeSet">
        /// A pointer to a <see cref="PRIVILEGE_SET"/> structure that receives the privileges used to perform the access validation.
        /// If no privileges were used, the function sets the <see cref="PrivilegeCount"/> member to zero.
        /// </param>
        /// <param name="PrivilegeSetLength">
        /// The size, in bytes, of the buffer pointed to by the <paramref name="PrivilegeSet"/> parameter.
        /// </param>
        /// <param name="GrantedAccess">
        /// A pointer to an access mask that receives the granted access rights.
        /// If <paramref name="AccessStatus"/> is set to <see cref="FALSE"/>, the function sets the access mask to zero.
        /// If the function fails, it does not set the access mask.
        /// </param>
        /// <param name="AccessStatus">
        /// A pointer to a variable that receives the results of the access check.
        /// If the security descriptor allows the requested access rights to the client identified by the access token,
        /// <paramref name="AccessStatus"/> is set to <see cref="TRUE"/>.
        /// Otherwise, <paramref name="AccessStatus"/> is set to <see cref="FALSE"/>,
        /// and you can call <see cref="GetLastError"/> to get extended error information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For more information, see the How AccessCheck Works overview.
        /// The <see cref="AccessCheckByType"/> function compares the specified security descriptor with the specified access token and indicates,
        /// in the <paramref name="AccessStatus"/> parameter, whether access is granted or denied.
        /// The <paramref name="ObjectTypeList"/> array does not necessarily represent the entire defined object.
        /// Rather, it represents that subset of the object for which to check access.
        /// For instance, to check access to two properties in a property set, specify an object type list with four elements:
        /// the object itself at level zero, the property set at level 1, and the two properties at level 2.
        /// The <see cref="AccessCheckByType"/> function evaluates ACEs that apply to the object itself
        /// and object-specific ACEs for the object types listed in the <paramref name="ObjectTypeList"/> array.
        /// The function ignores object-specific ACEs for object types not listed in the <paramref name="ObjectTypeList"/> array.
        /// Thus, the results returned in the <paramref name="AccessStatus"/> parameter indicate the access
        /// allowed to the subset of the object defined by the <paramref name="ObjectTypeList"/> parameter, not to the entire object.
        /// For more information about how a hierarchy of ACEs controls access to an object and its subobjects, see ACEs to Control Access to an Object's Properties.
        /// If the security descriptor's DACL is NULL, the <paramref name="AccessStatus"/> parameter returns <see cref="TRUE"/>, indicating that the client has the requested access.
        /// If the security descriptor does not contain owner and group SIDs, <see cref="AccessCheckByType"/> fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessCheckByType", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AccessCheckByType([In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] PSID PrincipalSelfSid,
            [In] HANDLE ClientToken, [In] ACCESS_MASK DesiredAccess, [In][Out] OBJECT_TYPE_LIST[] ObjectTypeList, [In] DWORD ObjectTypeListLength,
            [In] in GENERIC_MAPPING GenericMapping, [In] PPRIVILEGE_SET PrivilegeSet, [In][Out] ref DWORD PrivilegeSetLength,
            [Out] out DWORD GrantedAccess, [Out] out DWORD AccessStatus);

        /// <summary>
        /// <para>
        /// The <see cref="AccessCheckByTypeAndAuditAlarm"/> function determines whether a security descriptor
        /// grants a specified set of access rights to the client being impersonated by the calling thread.
        /// The function can check the client's access to a hierarchy of objects, such as an object, its property sets, and properties.
        /// The function grants or denies access to the hierarchy as a whole.
        /// If the security descriptor has a system access control list (SACL) with access control entries (ACEs) that apply to the client,
        /// the function generates any necessary audit messages in the security event log.
        /// Alarms are not currently supported.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-accesscheckbytypeandauditalarmw"/>
        /// </para>
        /// </summary>
        /// <param name="SubsystemName">
        /// A pointer to a null-terminated string that specifies the name of the subsystem calling the function.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="HandleId">
        /// A pointer to a unique value that represents the client's handle to the object.
        /// If the access is denied, the system ignores this value.
        /// </param>
        /// <param name="ObjectTypeName">
        /// A pointer to a null-terminated string that specifies the type of object being created or accessed.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="ObjectName">
        /// A pointer to a null-terminated string that specifies the name of the object being created or accessed.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="SecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure against which access is checked.
        /// </param>
        /// <param name="PrincipalSelfSid">
        /// A pointer to a security identifier (SID).
        /// If the security descriptor is associated with an object that represents a principal (for example, a user object),
        /// the <paramref name="PrincipalSelfSid"/> parameter should be the SID of the object.
        /// When evaluating access, this SID logically replaces the SID in any ACE containing the well-known <see cref="PRINCIPAL_SELF"/> SID (S-1-5-10).
        /// For information about well-known SIDs, see Well-known SIDs.
        /// If the protected object does not represent a principal, set this parameter to <see cref="NULL"/>.
        /// </param>
        /// <param name="DesiredAccess">
        /// An access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function to contain no generic access rights.
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>, the function sets the <paramref name="GrantedAccess"/> access mask
        /// to indicate the maximum access rights the security descriptor allows the client.
        /// </param>
        /// <param name="AuditType">
        /// The type of audit to be generated.
        /// This can be one of the values from the <see cref="AUDIT_EVENT_TYPE"/> enumeration type.
        /// </param>
        /// <param name="Flags">
        /// A flag that controls the function's behavior if the calling process does not have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// If the <see cref="AUDIT_ALLOW_NO_PRIVILEGE"/> flag is set, the function performs the access check without generating audit messages when the privilege is not enabled.
        /// If this parameter is zero, the function fails if the privilege is not enabled.
        /// </param>
        /// <param name="ObjectTypeList">
        /// A pointer to an array of <see cref="OBJECT_TYPE_LIST"/> structures that identify the hierarchy of object types for which to check access.
        /// Each element in the array specifies a GUID that identifies the object type and a value that indicates the level of the object type in the hierarchy of object types.
        /// The array should not have two elements with the same GUID.
        /// The array must have at least one element. The first element in the array must be at level zero and identify the object itself.
        /// The array can have only one level zero element.
        /// The second element is a subobject, such as a property set, at level 1. Following each level 1 entry are subordinate entries for the level 2 through 4 subobjects.
        /// Thus, the levels for the elements in the array might be {0, 1, 2, 2, 1, 2, 3}.
        /// If the object type list is out of order, <see cref="AccessCheckByTypeAndAuditAlarm"/> fails and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </param>
        /// <param name="ObjectTypeListLength">
        /// The number of elements in the <paramref name="ObjectTypeList"/> array.
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to the <see cref="GENERIC_MAPPING"/> structure associated with the object for which access is being checked.
        /// </param>
        /// <param name="ObjectCreation">
        /// A flag that determines whether the calling application will create a new object when access is granted.
        /// A value of <see cref="TRUE"/> indicates the application will create a new object.
        /// A value of <see cref="FALSE"/> indicates the application will open an existing object.
        /// </param>
        /// <param name="GrantedAccess">
        /// A pointer to an access mask that receives the granted access rights.
        /// If <paramref name="AccessStatus"/> is set to <see cref="FALSE"/>, the function sets the access mask to zero.
        /// If the function fails, it does not set the access mask.
        /// </param>
        /// <param name="AccessStatus">
        /// A pointer to a variable that receives the results of the access check.
        /// If the security descriptor allows the requested access rights to the client, <paramref name="AccessStatus"/> is set to <see cref="TRUE"/>.
        /// Otherwise, <paramref name="AccessStatus"/> is set to <see cref="FALSE"/> and you can call <see cref="GetLastError"/> to get extended error information.
        /// </param>
        /// <param name="pfGenerateOnClose">
        /// A pointer to a flag set by the audit-generation routine when the function returns.
        /// Pass this flag to the <see cref="ObjectCloseAuditAlarm"/> function when the object handle is closed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For more information, see the How AccessCheck Works overview.
        /// If the <paramref name="PrincipalSelfSid"/> and <paramref name="ObjectTypeList"/> parameters are <see cref="NULL"/>,
        /// the <paramref name="AuditType"/> parameter is <see cref="AuditEventObjectAccess"/>, and the <paramref name="Flags"/> parameter is zero,
        /// <see cref="AccessCheckByTypeAndAuditAlarm"/> performs in the same way as the <see cref="AccessCheckAndAuditAlarm"/> function.
        /// The <paramref name="ObjectTypeList"/> array does not necessarily represent the entire defined object. Rather,
        /// it represents that subset of the object for which to check access.
        /// For instance, to check access to two properties in a property set, specify an object type list with four elements:
        /// the object itself at level zero, the property set at level 1, and the two properties at level 2.
        /// The <see cref="AccessCheckByTypeAndAuditAlarm"/> function evaluates ACEs that apply to the object itself
        /// and object-specific ACEs for the object types listed in the <paramref name="ObjectTypeList"/> array.
        /// The function ignores object-specific ACEs for object types not listed in the <paramref name="ObjectTypeList"/> array.
        /// Thus, the results returned in the <paramref name="AccessStatus"/> parameter
        /// indicate the access allowed to the subset of the object defined by the <paramref name="ObjectTypeList"/> parameter, not to the entire object.
        /// For more information about how a hierarchy of ACEs controls access to an object and its subobjects, see ACEs to Control Access to an Object's Properties.
        /// To generate audit messages in the security event log, the calling process must have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The system checks for this privilege in the primary token of the calling process, not the impersonation token of the thread.
        /// If the Flags parameter includes the <see cref="AUDIT_ALLOW_NO_PRIVILEGE"/> flag, the function performs the access check without generating audit messages when the privilege is not enabled.
        /// The <see cref="AccessCheckByTypeAndAuditAlarm"/> function fails if the calling thread is not impersonating a client.
        /// If the security descriptor does not contain owner and group SIDs, <see cref="AccessCheckByTypeAndAuditAlarm"/> fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessCheckByTypeAndAuditAlarmW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AccessCheckByTypeAndAuditAlarm([In] LPCWSTR SubsystemName, [In] LPVOID HandleId, [In] LPCWSTR ObjectTypeName,
            [In] LPCWSTR ObjectName, [In] PSECURITY_DESCRIPTOR SecurityDescriptor, [In] PSID PrincipalSelfSid, [In] ACCESS_MASK DesiredAccess,
            [In] AUDIT_EVENT_TYPE AuditType, [In] DWORD Flags, [In][Out] OBJECT_TYPE_LIST[] ObjectTypeList, [In] DWORD ObjectTypeListLength,
            [In] in GENERIC_MAPPING GenericMapping, [In] BOOL ObjectCreation, [Out] out ACCESS_MASK GrantedAccess,
            [Out] out BOOL AccessStatus, [Out] out BOOL pfGenerateOnClose);

        /// <summary>
        /// <para>
        /// The <see cref="AccessCheckByTypeResultList"/> function determines whether a security descriptor
        /// grants a specified set of access rights to the client identified by an access token.
        /// The function can check the client's access to a hierarchy of objects, such as an object, its property sets, and properties.
        /// The function reports the access rights granted or denied to each object type in the hierarchy.
        /// Typically, server applications use this function to check access to a private object.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-accesscheckbytyperesultlist"/>
        /// </para> 
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure against which access is checked.
        /// </param>
        /// <param name="PrincipalSelfSid">
        /// A pointer to a security identifier (SID).
        /// If the security descriptor is associated with an object that represents a principal (for example, a user object),
        /// the <paramref name="PrincipalSelfSid"/> parameter should be the SID of the object.
        /// When evaluating access, this SID logically replaces the SID in any ACE that contains the well-known PRINCIPAL_SELF SID (S-1-5-10).
        /// For information about well-known SIDs, see Well-known SIDs.
        /// Set this parameter to <see cref="NULL"/> if the protected object does not represent a principal.
        /// </param>
        /// <param name="ClientToken">
        /// A handle to an impersonation token that represents the client attempting to gain access.
        /// The handle must have <see cref="TOKEN_QUERY"/> access to the token;
        /// otherwise, the function fails with <see cref="ERROR_ACCESS_DENIED"/>.
        /// </param>
        /// <param name="DesiredAccess">
        /// An access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function so that it contains no generic access rights.
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>, the function sets the access mask in <paramref name="GrantedAccessList"/>
        /// to indicate the maximum access rights the security descriptor allows the client.
        /// </param>
        /// <param name="ObjectTypeList">
        /// A pointer to an array of <see cref="OBJECT_TYPE_LIST"/> structures that identify the hierarchy of object types for which to check access.
        /// Each element in the array specifies a GUID that identifies the object type
        /// and a value that indicates the level of the object type in the hierarchy of object types.
        /// The array should not have two elements with the same GUID.
        /// The array must have at least one element.
        /// The first element in the array must be at level zero and identify the object itself.
        /// The array can have only one level zero element.
        /// The second element is a subobject, such as a property set, at level 1.
        /// Following each level 1 entry are subordinate entries for the level 2 through 4 subobjects.
        /// Thus, the levels for the elements in the array might be {0, 1, 2, 2, 1, 2, 3}.
        /// If the object type list is out of order, <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> fails,
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </param>
        /// <param name="ObjectTypeListLength">
        /// The number of elements in the <paramref name="ObjectTypeList"/> array.
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to the <see cref="GENERIC_MAPPING"/> structure associated with the object for which access is being checked.
        /// </param>
        /// <param name="PrivilegeSet">
        /// A pointer to a <see cref="PRIVILEGE_SET"/> structure that receives the privileges used to perform the access validation.
        /// If no privileges were used, the function sets the <see cref="PrivilegeCount"/> member to zero.
        /// </param>
        /// <param name="PrivilegeSetLength">
        /// The size, in bytes, of the buffer pointed to by the <paramref name="PrivilegeSet"/> parameter.
        /// </param>
        /// <param name="GrantedAccessList">
        /// A pointer to an array of access masks.
        /// The function sets each access mask to indicate the access rights granted to the corresponding element in the object type list.
        /// If the function fails, it does not set the access masks.
        /// </param>
        /// <param name="AccessStatusList">
        /// A pointer to an array of status codes for the corresponding elements in the object type list.
        /// The function sets an element to zero to indicate success or to a nonzero value to indicate the specific error during the access check.
        /// If the function fails, it does not set any of the elements in the array.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For more information, see the How AccessCheck Works overview.
        /// The <see cref="AccessCheckByTypeResultList"/> function compares the specified security descriptor with the specified access token and indicates,
        /// in the <paramref name="AccessStatusList"/> parameter, whether access is granted or denied for each of the elements in the object types list.
        /// The <paramref name="ObjectTypeList"/> array does not necessarily represent the entire defined object.
        /// Rather, it represents that subset of the object for which to check access.
        /// For instance, to check access to two properties in a property set, specify an object type list with four elements:
        /// the object itself at level zero, the property set at level 1, and the two properties at level 2.
        /// The <see cref="AccessCheckByTypeResultList"/> function evaluates ACEs that apply to the object itself
        /// and object-specific ACEs for the object types listed in the <paramref name="ObjectTypeList"/> array.
        /// The function ignores object-specific ACEs for object types not listed in the <paramref name="ObjectTypeList"/> array.
        /// Thus, the results returned for element zero in the <paramref name="AccessStatusList"/> parameter indicate
        /// the access allowed to the subset of the object defined by the <paramref name="ObjectTypeList"/> parameter, not to the entire object.
        /// For more information about how a hierarchy of ACEs controls access to an object and its subobjects, see ACEs to Control Access to an Object's Properties.
        /// If the security descriptor's discretionary access control list (DACL) is NULL, the function grants the requested access to all of the elements in the object type list.
        /// If the security descriptor does not contain owner and group SIDs, <see cref="AccessCheckByTypeResultList"/> fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessCheckByTypeResultList", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AccessCheckByTypeResultList([In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] PSID PrincipalSelfSid,
            [In] HANDLE ClientToken, [In] ACCESS_MASK DesiredAccess, [In][Out] OBJECT_TYPE_LIST[] ObjectTypeList, [In] DWORD ObjectTypeListLength,
            [In] in GENERIC_MAPPING GenericMapping, [In] PPRIVILEGE_SET PrivilegeSet, [In][Out] ref DWORD PrivilegeSetLength,
            [In][Out] DWORD[] GrantedAccessList, [In][Out] DWORD[] AccessStatusList);

        /// <summary>
        /// <para>
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> function determines whether a security descriptor
        /// grants a specified set of access rights to the client being impersonated by the calling thread.
        /// The function can check access to a hierarchy of objects, such as an object, its property sets, and properties.
        /// The function reports the access rights granted or denied to each object type in the hierarchy.
        /// If the security descriptor has a system access control list (SACL) with access control entries (ACEs) that apply to the client,
        /// the function generates any necessary audit messages in the security event log. Alarms are not currently supported.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-accesscheckbytyperesultlistandauditalarmw"/>
        /// </para> 
        /// </summary>
        /// <param name="SubsystemName">
        /// A pointer to a null-terminated string that specifies the name of the subsystem calling the function.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="HandleId">
        /// A pointer to a unique value that represents the client's handle to the object.
        /// If the access is denied, the system ignores this value.
        /// </param>
        /// <param name="ObjectTypeName">
        /// A pointer to a null-terminated string that specifies the type of object being created or accessed.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="ObjectName">
        /// A pointer to a null-terminated string that specifies the name of the object being created or accessed.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="SecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure against which access is checked.
        /// </param>
        /// <param name="PrincipalSelfSid">
        /// A pointer to a security identifier (SID).
        /// If the security descriptor is associated with an object that represents a principal (for example, a user object),
        /// the <paramref name="PrincipalSelfSid"/> parameter should be the SID of the object.
        /// When evaluating access, this SID logically replaces the SID in any ACE that contains the well-known PRINCIPAL_SELF SID (S-1-5-10).
        /// For information about well-known SIDs, see Well-known SIDs.
        /// Set this parameter to <see cref="NULL"/> if the protected object does not represent a principal.
        /// </param>
        /// <param name="DesiredAccess">
        /// An access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function so that it contains no generic access rights.
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>, the function sets the access mask in <paramref name="GrantedAccessList"/>
        /// to indicate the maximum access rights the security descriptor allows the client.
        /// </param>
        /// <param name="AuditType">
        /// The type of audit to be generated.
        /// This can be one of the values from the <see cref="AUDIT_EVENT_TYPE"/> enumeration type.
        /// </param>
        /// <param name="Flags">
        /// A flag that controls the function's behavior if the calling process does not have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// If the <see cref="AUDIT_ALLOW_NO_PRIVILEGE"/> flag is set,
        /// the function performs the access check without generating audit messages when the privilege is not enabled.
        /// If this parameter is zero, the function fails if the privilege is not enabled.
        /// </param>
        /// <param name="ObjectTypeList">
        /// A pointer to an array of <see cref="OBJECT_TYPE_LIST"/> structures that identify the hierarchy of object types for which to check access.
        /// Each element in the array specifies a GUID that identifies the object type
        /// and a value that indicates the level of the object type in the hierarchy of object types.
        /// The array should not have two elements with the same GUID.
        /// The array must have at least one element.
        /// The first element in the array must be at level zero and identify the object itself.
        /// The array can have only one level zero element.
        /// The second element is a subobject, such as a property set, at level 1.
        /// Following each level 1 entry are subordinate entries for the level 2 through 4 subobjects.
        /// Thus, the levels for the elements in the array might be {0, 1, 2, 2, 1, 2, 3}.
        /// If the object type list is out of order, <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> fails,
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </param>
        /// <param name="ObjectTypeListLength">
        /// The number of elements in the <paramref name="ObjectTypeList"/> array.
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to the <see cref="GENERIC_MAPPING"/> structure associated with the object for which access is being checked.
        /// </param>
        /// <param name="ObjectCreation">
        /// A flag that determines whether the calling application will create a new object when access is granted.
        /// A value of <see cref="TRUE"/> indicates the application will create a new object.
        /// A value of <see cref="FALSE"/> indicates the application will open an existing object.
        /// </param>
        /// <param name="GrantedAccessList">
        /// A pointer to an array of status codes for the corresponding elements in the object type list.
        /// The function sets an element to zero to indicate success or to a nonzero value to indicate the specific error during the access check.
        /// If the function fails, it does not set any of the elements in the array.
        /// </param>
        /// <param name="AccessStatusList">
        /// A pointer to an array of status codes for the corresponding elements in the object type list.
        /// The function sets an element to zero to indicate success or to a nonzero value to indicate the specific error during the access check.
        /// If the function fails, it does not set any of the elements in the array.
        /// </param>
        /// <param name="pfGenerateOnClose">
        /// A pointer to a flag set by the audit-generation routine when the function returns.
        /// Pass this flag to the <see cref="ObjectCloseAuditAlarm"/> function when the object handle is closed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For more information, see the How AccessCheck Works overview.
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> function is a combination
        /// of the <see cref="AccessCheckByTypeResultList"/> and <see cref="AccessCheckAndAuditAlarm"/> functions.
        /// The <paramref name="ObjectTypeList"/> array does not necessarily represent the entire defined object.
        /// Rather, it represents that subset of the object for which to check access.
        /// For instance, to check access to two properties in a property set, specify an object type list with four elements:
        /// the object itself at level zero, the property set at level 1, and the two properties at level 2.
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> function evaluates ACEs that apply to the object itself
        /// and object-specific ACEs for the object types listed in the <paramref name="ObjectTypeList"/> array.
        /// The function ignores object-specific ACEs for object types not listed in the <paramref name="ObjectTypeList"/> array.
        /// For more information about how a hierarchy of ACEs controls access to an object and its subobjects, see ACEs to Control Access to an Object's Properties.
        /// To generate audit messages in the security event log, the calling process must have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The system checks for this privilege in the primary token of the calling process, not the impersonation token of the thread.
        /// If the Flags parameter includes the <see cref="AUDIT_ALLOW_NO_PRIVILEGE"/> flag,
        /// the function performs the access check without generating audit messages when the privilege is not enabled.
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> function fails if the calling thread is not impersonating a client.
        /// If the security descriptor does not contain owner and group SIDs,
        /// <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessCheckByTypeResultListAndAuditAlarmW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AccessCheckByTypeResultListAndAuditAlarm([In] LPCWSTR SubsystemName, [In] LPVOID HandleId, [In] LPCWSTR ObjectTypeName,
            [In] LPCWSTR ObjectName, [In] PSECURITY_DESCRIPTOR SecurityDescriptor, [In] PSID PrincipalSelfSid, [In] ACCESS_MASK DesiredAccess,
            [In] AUDIT_EVENT_TYPE AuditType, [In] DWORD Flags, [In][Out] OBJECT_TYPE_LIST[] ObjectTypeList, [In] DWORD ObjectTypeListLength,
            [In] in GENERIC_MAPPING GenericMapping, [In] BOOL ObjectCreation, [In][Out] DWORD[] GrantedAccessList,
            [In][Out] DWORD[] AccessStatusList, [Out] out BOOL pfGenerateOnClose);

        /// <summary>
        /// <para>
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> function determines whether a security descriptor
        /// grants a specified set of access rights to the client that the calling thread is impersonating.
        /// The difference between this function and <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> is that
        /// this function allows the calling thread to perform the access check before impersonating the client.
        /// The function can check access to a hierarchy of objects, such as an object, its property sets, and properties.
        /// The function reports the access rights granted or denied to each object type in the hierarchy.
        /// If the security descriptor has a system access control list (SACL) with access control entries (ACEs) that apply to the client,
        /// the function generates any necessary audit messages in the security event log.
        /// Alarms are not currently supported.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-accesscheckbytyperesultlistandauditalarmbyhandlew"/>
        /// </para> 
        /// </summary>
        /// <param name="SubsystemName">
        /// A pointer to a null-terminated string that specifies the name of the subsystem calling the function.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="HandleId">
        /// A pointer to a unique value that represents the client's handle to the object.
        /// If the access is denied, the system ignores this value.
        /// </param>
        /// <param name="ClientToken">
        /// A handle to a token object that represents the client that requested the operation.
        /// This handle must be obtained through a communication session layer, such as a local named pipe, to prevent possible security policy violations.
        /// The caller must have <see cref="TOKEN_QUERY"/> access for the specified token.
        /// </param>
        /// <param name="ObjectTypeName">
        /// A pointer to a null-terminated string that specifies the type of object being created or accessed.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="ObjectName">
        /// A pointer to a null-terminated string that specifies the name of the object being created or accessed.
        /// This string appears in any audit message that the function generates.
        /// </param>
        /// <param name="SecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure against which access is checked.
        /// </param>
        /// <param name="PrincipalSelfSid">
        /// A pointer to a security identifier (SID).
        /// If the security descriptor is associated with an object that represents a principal (for example, a user object),
        /// the <paramref name="PrincipalSelfSid"/> parameter should be the SID of the object.
        /// When evaluating access, this SID logically replaces the SID in any ACE that contains the well-known PRINCIPAL_SELF SID (S-1-5-10).
        /// For information about well-known SIDs, see Well-known SIDs.
        /// Set this parameter to <see cref="NULL"/> if the protected object does not represent a principal.
        /// </param>
        /// <param name="DesiredAccess">
        /// An access mask that specifies the access rights to check.
        /// This mask must have been mapped by the <see cref="MapGenericMask"/> function so that it contains no generic access rights.
        /// If this parameter is <see cref="MAXIMUM_ALLOWED"/>, the function sets the access mask in <paramref name="GrantedAccessList"/>
        /// to indicate the maximum access rights the security descriptor allows the client.
        /// </param>
        /// <param name="AuditType">
        /// The type of audit to be generated.
        /// This can be one of the values from the <see cref="AUDIT_EVENT_TYPE"/> enumeration type.
        /// </param>
        /// <param name="Flags">
        /// A flag that controls the function's behavior if the calling process does not have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// If the <see cref="AUDIT_ALLOW_NO_PRIVILEGE"/> flag is set,
        /// the function performs the access check without generating audit messages when the privilege is not enabled.
        /// If this parameter is zero, the function fails if the privilege is not enabled.
        /// </param>
        /// <param name="ObjectTypeList">
        /// A pointer to an array of <see cref="OBJECT_TYPE_LIST"/> structures that identify the hierarchy of object types for which to check access.
        /// Each element in the array specifies a GUID that identifies the object type
        /// and a value that indicates the level of the object type in the hierarchy of object types.
        /// The array should not have two elements with the same GUID.
        /// The array must have at least one element.
        /// The first element in the array must be at level zero and identify the object itself.
        /// The array can have only one level zero element.
        /// The second element is a subobject, such as a property set, at level 1.
        /// Following each level 1 entry are subordinate entries for the level 2 through 4 subobjects.
        /// Thus, the levels for the elements in the array might be {0, 1, 2, 2, 1, 2, 3}.
        /// If the object type list is out of order, <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> fails,
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </param>
        /// <param name="ObjectTypeListLength">
        /// The number of elements in the <paramref name="ObjectTypeList"/> array.
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to the <see cref="GENERIC_MAPPING"/> structure associated with the object for which access is being checked.
        /// </param>
        /// <param name="ObjectCreation">
        /// A flag that determines whether the calling application will create a new object when access is granted.
        /// A value of <see cref="TRUE"/> indicates the application will create a new object.
        /// A value of <see cref="FALSE"/> indicates the application will open an existing object.
        /// </param>
        /// <param name="GrantedAccessList">
        /// A pointer to an array of status codes for the corresponding elements in the object type list.
        /// The function sets an element to zero to indicate success or to a nonzero value to indicate the specific error during the access check.
        /// If the function fails, it does not set any of the elements in the array.
        /// </param>
        /// <param name="AccessStatusList">
        /// A pointer to an array of status codes for the corresponding elements in the object type list.
        /// The function sets an element to zero to indicate success or to a nonzero value to indicate the specific error during the access check.
        /// If the function fails, it does not set any of the elements in the array.
        /// </param>
        /// <param name="pfGenerateOnClose">
        /// A pointer to a flag set by the audit-generation routine when the function returns.
        /// Pass this flag to the <see cref="ObjectCloseAuditAlarm"/> function when the object handle is closed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For more information, see the How AccessCheck Works overview.
        /// Like <see cref="AccessCheckByTypeResultListAndAuditAlarm"/>, the <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> function
        /// is a combination of the <see cref="AccessCheckByTypeResultList"/> and <see cref="AccessCheckAndAuditAlarm"/> functions.
        /// However, <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> also requires a client token handle to provide security information on the client.
        /// The <paramref name="ObjectTypeList"/> array does not necessarily represent the entire defined object.
        /// Rather, it represents that subset of the object for which to check access.
        /// For instance, to check access to two properties in a property set, specify an object type list with four elements:
        /// the object itself at level zero, the property set at level 1, and the two properties at level 2.
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> function evaluates ACEs that apply to the object itself
        /// and object-specific ACEs for the object types listed in the <paramref name="ObjectTypeList"/> array.
        /// The function ignores object-specific ACEs for object types not listed in the <paramref name="ObjectTypeList"/> array.
        /// For more information about how a hierarchy of ACEs controls access to an object and its subobjects, see ACEs to Control Access to an Object's Properties.
        /// To generate audit messages in the security event log, the calling process must have the <see cref="SE_AUDIT_NAME"/> privilege enabled.
        /// The system checks for this privilege in the primary token of the calling process, not the impersonation token of the thread.
        /// If the Flags parameter includes the <see cref="AUDIT_ALLOW_NO_PRIVILEGE"/> flag,
        /// the function performs the access check without generating audit messages when the privilege is not enabled.
        /// The <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> function fails if the calling thread is not impersonating a client.
        /// If the security descriptor does not contain owner and group SIDs,
        /// <see cref="AccessCheckByTypeResultListAndAuditAlarmByHandle"/> fails with <see cref="ERROR_INVALID_SECURITY_DESCR"/>.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessCheckByTypeResultListAndAuditAlarmByHandleW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AccessCheckByTypeResultListAndAuditAlarmByHandle([In] LPCWSTR SubsystemName, [In] LPVOID HandleId, [In] HANDLE ClientToken,
            [In] LPCWSTR ObjectTypeName, [In] LPCWSTR ObjectName, [In] PSECURITY_DESCRIPTOR SecurityDescriptor, [In] PSID PrincipalSelfSid,
            [In] ACCESS_MASK DesiredAccess, [In] AUDIT_EVENT_TYPE AuditType, [In] DWORD Flags, [In][Out] OBJECT_TYPE_LIST[] ObjectTypeList,
            [In] DWORD ObjectTypeListLength, [In] in GENERIC_MAPPING GenericMapping, [In] BOOL ObjectCreation, [In][Out] DWORD[] GrantedAccessList,
            [In][Out] DWORD[] AccessStatusList, [Out] out BOOL pfGenerateOnClose);

        /// <summary>
        /// <para>
        /// Stops a system shutdown that has been initiated.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-abortsystemshutdownw"/>
        /// </para>
        /// </summary>
        /// <param name="lpMachineName">
        /// The network name of the computer where the shutdown is to be stopped.
        /// If <paramref name="lpMachineName"/> is <see langword="null"/> or an empty string, the function stops the shutdown on the local computer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="InitiateSystemShutdown"/> and <see cref="InitiateSystemShutdownEx"/> functions display a dialog box
        /// that notifies the user that the system is shutting down.
        /// During the shutdown time-out period, the <see cref="AbortSystemShutdown"/> function can prevent the system from shutting down.
        /// Windows Server 2003 and Windows XP with SP1:
        /// If the computer to be shut down is a Terminal Services server, the system displays a dialog box
        /// to all local and remote users warning them that shutdown has been initiated.
        /// If shutdown is prevented by <see cref="AbortSystemShutdown"/>,
        /// the system displays dialog box to the users informing them that the server is no longer shutting down.
        /// To stop the local computer from shutting down, the calling process must have the SE_SHUTDOWN_NAME privilege.
        /// To stop a remote computer from shutting down, the calling process must have the SE_REMOTE_SHUTDOWN_NAME privilege on the remote computer.
        /// By default, users can enable the SE_SHUTDOWN_NAME privilege on the computer they are logged onto,
        /// and administrators can enable the SE_REMOTE_SHUTDOWN_NAME privilege on remote computers.
        /// For more information, see Running with Special Privileges.
        /// Common reasons for failure include an invalid computer name, an inaccessible computer, or insufficient privilege.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AbortSystemShutdownW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AbortSystemShutdown([MarshalAs(UnmanagedType.LPWStr)][In] string lpMachineName);

        /// <summary>
        /// <para>
        /// The <see cref="AdjustTokenGroups"/> function enables or disables groups already present in the specified access token.
        /// Access to <see cref="TOKEN_ADJUST_GROUPS"/> is required to enable or disable groups in an access token.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-adjusttokengroups"/>
        /// </para>
        /// </summary>
        /// <param name="TokenHandle">
        /// A handle to the access token that contains the groups to be enabled or disabled.
        /// The handle must have <see cref="TOKEN_ADJUST_GROUPS"/> access to the token.
        /// If the <paramref name="PreviousState"/> parameter is not <see cref="NullRef{TOKEN_GROUPS}"/>,
        /// the handle must also have <see cref="TOKEN_QUERY"/> access.
        /// </param>
        /// <param name="ResetToDefault">
        /// Boolean value that indicates whether the groups are to be set to their default enabled and disabled states.
        /// If this value is <see cref="TRUE"/>, the groups are set to their default states and the <paramref name="NewState"/> parameter is ignored.
        /// If this value is <see cref="FALSE"/>, the groups are set according to the information pointed to by the <paramref name="NewState"/> parameter.
        /// </param>
        /// <param name="NewState">
        /// A pointer to a <see cref="TOKEN_GROUPS"/> structure that contains the groups to be enabled or disabled.
        /// If the <paramref name="ResetToDefault"/> parameter is <see cref="FALSE"/>,
        /// the function sets each of the groups to the value of that group's <see cref="SE_GROUP_ENABLED"/> attribute
        /// in the <see cref="TOKEN_GROUPS"/> structure.
        /// If <paramref name="ResetToDefault"/> is <see cref="TRUE"/>, this parameter is ignored.
        /// </param>
        /// <param name="BufferLength">
        /// The size, in bytes, of the buffer pointed to by the <paramref name="PreviousState"/> parameter.
        /// This parameter can be zero if the <paramref name="PreviousState"/> parameter is <see cref="NullRef{TOKEN_GROUPS}"/>,
        /// </param>
        /// <param name="PreviousState">
        /// A pointer to a buffer that receives a <see cref="TOKEN_GROUPS"/> structure containing the previous state of any groups the function modifies.
        /// That is, if a group has been modified by this function, the group and its previous state are contained
        /// in the <see cref="TOKEN_GROUPS"/> structure referenced by <paramref name="PreviousState"/>.
        /// If the <see cref="TOKEN_GROUPS.GroupCount"/> member of <see cref="TOKEN_GROUPS"/> is zero,
        /// then no groups have been changed by this function.
        /// This parameter can be <see cref="NullRef{TOKEN_GROUPS}"/>,
        /// If a buffer is specified but it does not contain enough space to receive the complete list of modified groups,
        /// no group states are changed and the function fails.
        /// In this case, the function sets the variable pointed to by the <paramref name="ReturnLength"/> parameter
        /// to the number of bytes required to hold the complete list of modified groups.
        /// </param>
        /// <param name="ReturnLength">
        /// A pointer to a variable that receives the actual number of bytes needed
        /// for the buffer pointed to by the <paramref name="PreviousState"/> parameter.
        /// This parameter can be <see cref="NullRef{DWORD}"/> and is ignored if <paramref name="PreviousState"/> is <see cref="NullRef{TOKEN_GROUPS}"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The information retrieved in the <paramref name="PreviousState"/> parameter is formatted as a <see cref="TOKEN_GROUPS"/> structure.
        /// This means a pointer to the buffer can be passed as the <paramref name="NewState"/> parameter in a subsequent call
        /// to the <see cref="AdjustTokenGroups"/> function, restoring the original state of the groups.
        /// The <paramref name="NewState"/> parameter can list groups to be changed that are not present in the access token.
        /// This does not affect the successful modification of the groups in the token.
        /// The <see cref="AdjustTokenGroups"/> function cannot disable groups
        /// with the <see cref="SE_GROUP_MANDATORY"/> attribute in the <see cref="TOKEN_GROUPS"/> structure.
        /// Use <see cref="CreateRestrictedToken"/> instead.
        /// You cannot enable a group that has the <see cref="SE_GROUP_USE_FOR_DENY_ONLY"/> attribute.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AdjustTokenGroups", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AdjustTokenGroups([In] HANDLE TokenHandle, [In] BOOL ResetToDefault, [In] in TOKEN_GROUPS NewState,
            [In] DWORD BufferLength, [Out] out TOKEN_GROUPS PreviousState, [Out] out DWORD ReturnLength);

        /// <summary>
        /// <para>
        /// The <see cref="AdjustTokenPrivileges"/> function enables or disables privileges in the specified access token.
        /// Enabling or disabling privileges in an access token requires <see cref="TOKEN_ADJUST_PRIVILEGES"/> access.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-adjusttokenprivileges"/>
        /// </para>
        /// </summary>
        /// <param name="TokenHandle">
        /// A handle to the access token that contains the privileges to be modified.
        /// The handle must have <see cref="TOKEN_ADJUST_PRIVILEGES"/> access to the token.
        /// If the <paramref name="PreviousState"/> parameter is not <see cref="NullRef{TOKEN_PRIVILEGES}"/>,
        /// the handle must also have <see cref="TOKEN_QUERY"/> access.
        /// </param>
        /// <param name="DisableAllPrivileges">
        /// Specifies whether the function disables all of the token's privileges.
        /// If this value is <see cref="TRUE"/>, the function disables all privileges and ignores the <paramref name="NewState"/> parameter.
        /// If it is <see cref="FALSE"/>, the function modifies privileges based on the information pointed to by the <paramref name="NewState"/> parameter.
        /// </param>
        /// <param name="NewState">
        /// A pointer to a <see cref="TOKEN_PRIVILEGES"/> structure that specifies an array of privileges and their attributes.
        /// If the <paramref name="DisableAllPrivileges"/> parameter is <see cref="FALSE"/>,
        /// the <see cref="AdjustTokenPrivileges"/> function enables, disables, or removes these privileges for the token.
        /// The following table describes the action taken by the <see cref="AdjustTokenPrivileges"/> function, based on the privilege attribute.
        /// <see cref="SE_PRIVILEGE_ENABLED"/>: The function enables the privilege.
        /// <see cref="SE_PRIVILEGE_REMOVED"/>:
        /// The privilege is removed from the list of privileges in the token.
        /// The other privileges in the list are reordered to remain contiguous.
        /// <see cref="SE_PRIVILEGE_REMOVED"/> supersedes <see cref="SE_PRIVILEGE_ENABLED"/>.
        /// Because the privilege has been removed from the token, attempts to reenable the privilege result in
        /// the warning <see cref="ERROR_NOT_ALL_ASSIGNED"/> as if the privilege had never existed.
        /// Attempting to remove a privilege that does not exist in the token results in <see cref="ERROR_NOT_ALL_ASSIGNED"/> being returned.
        /// Privilege checks for removed privileges result in <see cref="STATUS_PRIVILEGE_NOT_HELD"/>.
        /// Failed privilege check auditing occurs as normal.
        /// The removal of the privilege is irreversible, so the name of the removed privilege is not included
        /// in the <paramref name="PreviousState"/> parameter after a call to <see cref="AdjustTokenPrivileges"/>.
        /// Windows XP with SP1: The function cannot remove privileges. This value is not supported.
        /// None: The function disables the privilege.
        /// If <paramref name="DisableAllPrivileges"/> is <see cref="TRUE"/>, the function ignores this parameter.
        /// </param>
        /// <param name="BufferLength">
        /// Specifies the size, in bytes, of the buffer pointed to by the <paramref name="PreviousState"/> parameter.
        /// This parameter can be zero if the <paramref name="PreviousState"/> parameter is NULL.
        /// </param>
        /// <param name="PreviousState">
        /// A pointer to a buffer that the function fills with a <see cref="TOKEN_PRIVILEGES"/> structure
        /// that contains the previous state of any privileges that the function modifies.
        /// That is, if a privilege has been modified by this function, the privilege and its previous state are contained
        /// in the <see cref="TOKEN_PRIVILEGES"/> structure referenced by <paramref name="PreviousState"/>.
        /// If the <see cref="TOKEN_PRIVILEGES.PrivilegeCount"/> member of <see cref="TOKEN_PRIVILEGES"/> is zero,
        /// then no privileges have been changed by this function.
        /// This parameter can be <see cref="NullRef{TOKEN_PRIVILEGES}"/>.
        /// If you specify a buffer that is too small to receive the complete list of modified privileges,
        /// the function fails and does not adjust any privileges.
        /// In this case, the function sets the variable pointed to by the <paramref name="ReturnLength"/> parameter
        /// to the number of bytes required to hold the complete list of modified privileges.
        /// </param>
        /// <param name="ReturnLength">
        /// A pointer to a variable that receives the required size, in bytes, of the buffer pointed to by the <paramref name="PreviousState"/> parameter.
        /// This parameter can be <see cref="NullRef{DWORD}"/> if <paramref name="PreviousState"/> is <see cref="NullRef{TOKEN_PRIVILEGES}"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// To determine whether the function adjusted all of the specified privileges, call <see cref="GetLastError"/>,
        /// which returns one of the following values when the function succeeds:
        /// <see cref="ERROR_SUCCESS"/>: The function adjusted all specified privileges.
        /// <see cref="ERROR_NOT_ALL_ASSIGNED"/>:
        /// The token does not have one or more of the privileges specified in the <paramref name="NewState"/> parameter.
        /// The function may succeed with this error value even if no privileges were adjusted.
        /// The <paramref name="PreviousState"/> parameter indicates the privileges that were adjusted.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="AdjustTokenPrivileges"/> function cannot add new privileges to the access token.
        /// It can only enable or disable the token's existing privileges.
        /// To determine the token's privileges, call the <see cref="GetTokenInformation"/> function.
        /// The <paramref name="NewState"/> parameter can specify privileges that the token does not have, without causing the function to fail.
        /// In this case, the function adjusts the privileges that the token does have and ignores the other privileges so that the function succeeds.
        /// Call the <see cref="GetLastError"/> function to determine whether the function adjusted all of the specified privileges.
        /// The <paramref name="PreviousState"/> parameter indicates the privileges that were adjusted.
        /// The <paramref name="PreviousState"/> parameter retrieves a <see cref="TOKEN_PRIVILEGES"/> structure
        /// that contains the original state of the adjusted privileges.
        /// To restore the original state, pass the <paramref name="PreviousState"/> pointer as the <paramref name="NewState"/> parameter
        /// in a subsequent call to the <see cref="AdjustTokenPrivileges"/> function.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AdjustTokenPrivileges", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AdjustTokenPrivileges([In] HANDLE TokenHandle, [In] BOOL DisableAllPrivileges, [In] in TOKEN_PRIVILEGES NewState,
            [In] DWORD BufferLength, [Out] out TOKEN_PRIVILEGES PreviousState, [Out] out DWORD ReturnLength);

        /// <summary>
        /// <para>
        /// The <see cref="CheckTokenMembership"/> function determines whether a specified security identifier (SID) is enabled in an access token.
        /// If you want to determine group membership for app container tokens, you need to use the <see cref="CheckTokenMembershipEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-checktokenmembership"/>
        /// </para>
        /// </summary>
        /// <param name="TokenHandle">
        /// A handle to an access token.
        /// The handle must have <see cref="TOKEN_QUERY"/> access to the token.
        /// The token must be an impersonation token.
        /// If <paramref name="TokenHandle"/> is <see cref="IntPtr.Zero"/>,
        /// <see cref="CheckTokenMembership"/> uses the impersonation token of the calling thread.
        /// If the thread is not impersonating, the function duplicates the thread's primary token to create an impersonation token.
        /// </param>
        /// <param name="SidToCheck">
        /// A pointer to a <see cref="SID"/> structure.
        /// The <see cref="CheckTokenMembership"/> function checks for the presence of this SID in the user and group SIDs of the access token.
        /// </param>
        /// <param name="IsMember">
        /// A pointer to a variable that receives the results of the check
        /// If the <see cref="SID"/> is present and has the <see cref="SE_GROUP_ENABLED"/> attribute,
        /// IsMember returns <see langword="true"/>; otherwise, it returns <see langword="false"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CheckTokenMembership"/> function simplifies the process of determining whether a SID is both present and enabled in an access token.
        /// Even if a SID is present in the token, the system may not use the SID in an access check.
        /// The SID may be disabled or have the <see cref="SE_GROUP_USE_FOR_DENY_ONLY"/> attribute.
        /// The system uses only enabled SIDs to grant access when performing an access check.
        /// For more information, see SID Attributes in an Access Token.
        /// If <paramref name="TokenHandle"/> is a restricted token, or if <paramref name="TokenHandle"/> is <see cref="IntPtr.Zero"/>
        /// and the current effective token of the calling thread is a restricted token,
        /// <see cref="CheckTokenMembership"/> also checks whether the SID is present in the list of restricting SIDs.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CheckTokenMembership", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CheckTokenMembership([In] HANDLE TokenHandle, [In] PSID SidToCheck, [Out] out BOOL IsMember);

        /// <summary>
        /// <para>
        /// The <see cref="ConvertToAutoInheritPrivateObjectSecurity"/> function converts a security descriptor
        /// and its access control lists (ACLs) to a format that supports automatic propagation of inheritable access control entries (ACEs).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-converttoautoinheritprivateobjectsecurity"/>
        /// </para>
        /// </summary>
        /// <param name="ParentDescriptor">
        /// A pointer to the security descriptor for the parent container of the object.
        /// If there is no parent container, this parameter is <see cref="NULL"/>.
        /// </param>
        /// <param name="CurrentSecurityDescriptor">
        /// A pointer to the current security descriptor of the object.
        /// </param>
        /// <param name="NewSecurityDescriptor">
        /// A pointer to a variable that receives a pointer to the newly allocated self-relative security descriptor.
        /// It is the caller's responsibility to call the <see cref="DestroyPrivateObjectSecurity"/> function to free this security descriptor.
        /// </param>
        /// <param name="ObjectType">
        /// A pointer to a <see cref="GUID"/> structure that identifies the type of object
        /// associated with the <paramref name="CurrentSecurityDescriptor"/> parameter.
        /// If the object does not have a GUID, this parameter must be <see cref="NULL"/>.
        /// </param>
        /// <param name="IsDirectoryObject">
        /// If <see cref="BOOLEAN.TRUE"/>, the new object is a container and can contain other objects.
        /// If <see cref="BOOLEAN.FALSE"/>, the new object is not a container.
        /// </param>
        /// <param name="GenericMapping">
        /// A pointer to a <see cref="GENERIC_MAPPING"/> structure that specifies the mapping from each generic right to specific rights for the object.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="ConvertToAutoInheritPrivateObjectSecurity"/> function attempts to determine
        /// whether the ACEs in the discretionary access control list (DACL) and system access control list (SACL) of the current security descriptor
        /// were inherited from the parent security descriptor.
        /// The function passes the <paramref name="ParentDescriptor"/> parameter to the <see cref="CreatePrivateObjectSecurityEx"/> function
        /// to get ACLs that contain only inherited ACEs.
        /// Then it compares these ACEs to the ACEs in the original security descriptor to determine which of the original ACEs were inherited.
        /// The ACEs do not need to match one-to-one.
        /// For instance, an ACE that allows read and write access to a trustee can be equivalent to two ACEs:
        /// an ACE that allows read access and an ACE that allows write access.
        /// Any ACEs in the original security descriptor that are equivalent to the ACEs inherited from the parent security descriptor
        /// are marked with the <see cref="INHERITED_ACE"/> flag and added to the new security descriptor.
        /// All other ACEs in the original security descriptor are added to the new security descriptor as noninherited ACEs.
        /// If the original DACL does not have any inherited ACEs, the function sets the <see cref="SE_DACL_PROTECTED"/> flag
        /// in the control bits of the new security descriptor.
        /// Similarly, the <see cref="SE_SACL_PROTECTED"/> flag is set if none of the ACEs in the SACL is inherited.
        /// For DACLs that have inherited ACEs, the function reorders the ACEs into two groups.
        /// The first group has ACEs that were directly applied to the object.
        /// The second group has inherited ACEs. This ordering ensures that noninherited ACEs have precedence over inherited ACEs.
        /// For more information, see Order of ACEs in a DACL.
        /// The function sets the <see cref="SE_DACL_AUTO_INHERITED"/> and <see cref="SE_SACL_AUTO_INHERITED"/> flags
        /// in the control bits of the new security descriptor.
        /// The function does not change the ordering of access-allowed ACEs in relation to access-denied ACEs in the DACL
        /// because to do so would change the semantics of the resulting security descriptor.
        /// If the function cannot convert the DACL without changing the semantics,
        /// it leaves the DACL unchanged and sets the <see cref="SE_DACL_PROTECTED"/> flag.
        /// The new security descriptor has the same owner and primary group as the original security descriptor.
        /// The new security descriptor is equivalent to the original security descriptor,
        /// so the caller needs no access rights or privileges to update the security descriptor to the new format.
        /// This function works with <see cref="ACL_REVISION"/> and <see cref="ACL_REVISION_DS"/> ACLs.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ConvertToAutoInheritPrivateObjectSecurity", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ConvertToAutoInheritPrivateObjectSecurity([In] PSECURITY_DESCRIPTOR ParentDescriptor,
            [In] PSECURITY_DESCRIPTOR CurrentSecurityDescriptor, [Out] out PSECURITY_DESCRIPTOR NewSecurityDescriptor, [In] in GUID ObjectType,
            [In] BOOLEAN IsDirectoryObject, [In] in GENERIC_MAPPING GenericMapping);

        /// <summary>
        /// <para>
        /// Creates a new process and its primary thread. Then the new process runs the specified executable file in the security context
        /// of the specified credentials (user, domain, and password).
        /// It can optionally load the user profile for a specified user.
        /// This function is similar to the <see cref="CreateProcessAsUser"/> and <see cref="CreateProcessWithTokenW"/> functions,
        /// except that the caller does not need to call the <see cref="LogonUser"/> function to authenticate the user and get a token.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createprocesswithlogonw"/>
        /// </para>
        /// </summary>
        /// <param name="lpUsername">
        /// The name of the user.
        /// This is the name of the user account to log on to.
        /// If you use the UPN format, user@DNS_domain_name, the lpDomain parameter must be <see langword="null"/>.
        /// The user account must have the Log On Locally permission on the local computer.
        /// This permission is granted to all users on workstations and servers, but only to administrators on domain controllers.
        /// </param>
        /// <param name="lpDomain">
        /// The name of the domain or server whose account database contains the <paramref name="lpUsername"/> account.
        /// If this parameter is <see langword="null"/>, the user name must be specified in UPN format.
        /// </param>
        /// <param name="lpPassword">
        /// The clear-text password for the <paramref name="lpUsername"/> account.
        /// </param>
        /// <param name="dwLogonFlags">
        /// The logon option. This parameter can be 0 (zero) or one of the following values.
        /// <see cref="LOGON_WITH_PROFILE"/>, <see cref="LOGON_NETCREDENTIALS_ONLY"/>
        /// </param>
        /// <param name="lpApplicationName">
        /// The name of the module to be executed. This module can be a Windows-based application.
        /// It can be some other type of module (for example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
        /// The string can specify the full path and file name of the module to execute or it can specify a partial name.
        /// In the case of a partial name, the function uses the current drive and current directory to complete the specification.
        /// The function will not use the search path.
        /// This parameter must include the file name extension; no default extension is assumed.
        /// The <paramref name="lpApplicationName"/> parameter can be <see langword="null"/>.
        /// In that case, the module name must be the first white space–delimited token in the <paramref name="lpCommandLine"/> string.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin;
        /// otherwise, the file name is ambiguous.
        /// For example, consider the string "c:\program files\sub dir\program name".
        /// This string can be interpreted in a number of ways.
        /// The system tries to interpret the possibilities in the following order:
        /// c:\program.exe c:\program files\sub.exe c:\program files\sub dir\program.exe c:\program files\sub dir\program name.exe
        /// If the executable module is a 16-bit application, <paramref name="lpApplicationName"/> should be NULL,
        /// and the string pointed to by <paramref name="lpCommandLine"/> should specify the executable module as well as its arguments.
        /// </param>
        /// <param name="lpCommandLine">
        /// The command line to be executed.
        /// The maximum length of this string is 1024 characters.
        /// If lpApplicationName is <see langword="null"/>,
        /// the module name portion of <paramref name="lpCommandLine"/> is limited to <see cref="MAX_PATH"/> characters.
        /// The function can modify the contents of this string.
        /// Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string).
        /// If this parameter is a constant string, the function may cause an access violation.
        /// The <paramref name="lpCommandLine"/> parameter can be <see langword="null"/>,
        /// and the function uses the string pointed to by <paramref name="lpApplicationName"/> as the command line.
        /// If both <paramref name="lpApplicationName"/> and <paramref name="lpCommandLine"/> are non-NULL,
        /// the null-terminated string pointed to by <paramref name="lpApplicationName"/> specifies the module to execute,
        /// and the null-terminated string pointed to by <paramref name="lpCommandLine"/> specifies the command line.
        /// The new process can use <see cref="GetCommandLine"/> to retrieve the entire command line.
        /// Console processes written in C can use the argc and argv arguments to parse the command line.
        /// Because argv[0] is the module name, C programmers generally repeat the module name as the first token in the command line.
        /// If <paramref name="lpApplicationName"/> is <see langword="null"/>,
        /// the first white space–delimited token of the command line specifies the module name.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and
        /// the arguments begin (see the explanation for the <paramref name="lpApplicationName"/> parameter).
        /// If the file name does not contain an extension, .exe is appended.
        /// Therefore, if the file name extension is .com, this parameter must include the .com extension.
        /// If the file name ends in a period (.) with no extension, or if the file name contains a path, .exe is not appended.
        /// If the file name does not contain a directory path, the system searches for the executable file in the following sequence:
        /// 1.The directory from which the application loaded.
        /// 2. The current directory for the parent process.
        /// 3. The 32-bit Windows system directory. Use the <see cref="GetSystemDirectory"/> function to get the path of this directory.
        /// 4.The 16-bit Windows system directory. 
        /// There is no function that obtains the path of this directory, but it is searched. The name of this directory is System.
        /// 5. The Windows directory. Use the <see cref="GetWindowsDirectory"/> function to get the path of this directory.
        /// 6.The directories that are listed in the PATH environment variable.
        /// Note that this function does not search the per-application path specified by the App Paths registry key.
        /// To include this per-application path in the search sequence, use the <see cref="ShellExecute"/> function.
        /// The system adds a terminating null character to the command-line string to separate the file name from the arguments.
        /// This divides the original string into two strings for internal processing.
        /// </param>
        /// <param name="dwCreationFlags">
        /// The flags that control how the process is created.
        /// The <see cref="CREATE_DEFAULT_ERROR_MODE"/>, <see cref="CREATE_NEW_CONSOLE"/>,
        /// and <see cref="CREATE_NEW_PROCESS_GROUP"/> flags are enabled by default— even if you do not set the flag,
        /// the system functions as if it were set. You can specify additional flags as noted.
        /// <see cref="CREATE_DEFAULT_ERROR_MODE"/>, <see cref="CREATE_NEW_CONSOLE"/>,
        /// <see cref="CREATE_NEW_PROCESS_GROUP"/>, <see cref="CREATE_SEPARATE_WOW_VDM"/>,
        /// <see cref="CREATE_SUSPENDED"/>, <see cref="CREATE_UNICODE_ENVIRONMENT"/>
        /// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the process's threads.
        /// For a list of values, see <see cref="GetPriorityClass"/>.
        /// If none of the priority class flags is specified, the priority class defaults to <see cref="NORMAL_PRIORITY_CLASS"/>
        /// unless the priority class of the creating process is <see cref="IDLE_PRIORITY_CLASS"/>
        /// or <see cref="BELOW_NORMAL_PRIORITY_CLASS"/>.
        /// In this case, the child process receives the default priority class of the calling process.
        /// </param>
        /// <param name="lpEnvironment">
        /// A pointer to an environment block for the new process.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the new process uses an environment created
        /// from the profile of the user specified by <paramref name="lpUsername"/>.
        /// An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:
        /// name=value
        /// Because the equal sign (=) is used as a separator, it must not be used in the name of an environment variable.
        /// An environment block can contain Unicode or ANSI characters.
        /// If the environment block pointed to by <paramref name="lpEnvironment"/> contains Unicode characters,
        /// ensure that <paramref name="dwCreationFlags"/> includes <see cref="CREATE_UNICODE_ENVIRONMENT"/>.
        /// If this parameter is <see cref="IntPtr.Zero"/> and the environment block of the parent process contains Unicode characters,
        /// you must also ensure that <paramref name="dwCreationFlags"/> includes <see cref="CREATE_UNICODE_ENVIRONMENT"/>.
        /// An ANSI environment block is terminated by two 0 (zero) bytes: one for the last string and one more to terminate the block.
        /// A Unicode environment block is terminated by four zero bytes: two for the last string and two more to terminate the block.
        /// To retrieve a copy of the environment block for a specific user, use the <see cref="CreateEnvironmentBlock"/> function.
        /// </param>
        /// <param name="lpCurrentDirectory">
        /// The full path to the current directory for the process. The string can also specify a UNC path.
        /// If this parameter is <see langword="null"/>, the new process has the same current drive and directory as the calling process.
        /// This feature is provided primarily for shells that need to start an application, and specify its initial drive and working directory.
        /// </param>
        /// <param name="lpStartupInfo">
        /// A pointer to a <see cref="STARTUPINFO"/> structure.
        /// The application must add permission for the specified user account to the specified window station and desktop, even for WinSta0\Default.
        /// If the <see cref="STARTUPINFO.lpDesktop"/> member is <see cref="IntPtr.Zero"/> or an empty string,
        /// the new process inherits the desktop and window station of its parent process.
        /// The application must add permission for the specified user account to the inherited window station and desktop.
        /// Windows XP:  <see cref="CreateProcessWithLogonW"/> adds permission for the specified user account to the inherited window station and desktop.
        /// Handles in <see cref="STARTUPINFO"/> must be closed with <see cref="CloseHandle"/> when they are no longer needed.
        /// If the <see cref="STARTUPINFO.dwFlags"/> member of the <see cref="STARTUPINFO"/> structure
        /// specifies <see cref="STARTUPINFOFlags.STARTF_USESTDHANDLES"/>, 
        /// the standard handle fields are copied unchanged to the child process without validation.
        /// The caller is responsible for ensuring that these fields contain valid handle values.
        /// Incorrect values can cause the child process to misbehave or crash.
        /// Use the Application Verifier runtime verification tool to detect invalid handles.
        /// </param>
        /// <param name="lpProcessInformation">
        /// A pointer to a <see cref="PROCESS_INFORMATION"/> structure that receives identification information for the new process,
        /// including a handle to the process.
        /// Handles in <see cref="PROCESS_INFORMATION"/> must be closed with the <see cref="CloseHandle"/> function when they are not needed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Note that the function returns before the process has finished initialization.
        /// If a required DLL cannot be located or fails to initialize, the process is terminated.
        /// To get the termination status of a process, call <see cref="GetExitCodeProcess"/>.
        /// </returns>
        /// <remarks>
        /// By default, <see cref="CreateProcessWithLogonW"/> does not load the specified user profile into the HKEY_USERS registry key.
        /// This means that access to information in the HKEY_CURRENT_USER registry key may not produce results that are consistent
        /// with a normal interactive logon.
        /// It is your responsibility to load the user registry hive into HKEY_USERS before calling <see cref="CreateProcessWithLogonW"/>,
        /// by using <see cref="LOGON_WITH_PROFILE"/>, or by calling the <see cref="LoadUserProfile"/> function.
        /// If the <paramref name="lpEnvironment"/> parameter is <see cref="IntPtr.Zero"/>,
        /// the new process uses an environment block created from the profile of the user specified by <paramref name="lpUsername"/>.
        /// If the HOMEDRIVE and HOMEPATH variables are not set, <see cref="CreateProcessWithLogonW"/> modifies the environment block
        /// to use the drive and path of the user's working directory.
        /// When created, the new process and thread handles receive full access rights
        /// (<see cref="PROCESS_ALL_ACCESS"/> and <see cref="THREAD_ALL_ACCESS"/>).
        /// For either handle, if a security descriptor is not provided, the handle can be used in any function that requires an object handle of that type.
        /// When a security descriptor is provided, an access check is performed on all subsequent uses of the handle before access is granted.
        /// If access is denied, the requesting process cannot use the handle to gain access to the process or thread.
        /// To retrieve a security token, pass the process handle in the <see cref="PROCESS_INFORMATION"/> structure
        /// to the <see cref="OpenProcessToken"/> function.
        /// The process is assigned a process identifier. The identifier is valid until the process terminates.
        /// It can be used to identify the process, or it can be specified in the <see cref="OpenProcess"/> function to open a handle to the process.
        /// The initial thread in the process is also assigned a thread identifier.
        /// It can be specified in the <see cref="OpenThread"/> function to open a handle to the thread.
        /// The identifier is valid until the thread terminates and can be used to uniquely identify the thread within the system.
        /// These identifiers are returned in <see cref="PROCESS_INFORMATION"/>.
        /// The calling thread can use the <see cref="WaitForInputIdle"/> function to wait until the new process has completed
        /// its initialization and is waiting for user input with no input pending.
        /// This can be useful for synchronization between parent and child processes
        /// , because <see cref="CreateProcessWithLogonW"/> returns without waiting for the new process to finish its initialization.
        /// For example, the creating process would use <see cref="WaitForInputIdle"/> before trying to
        /// find a window that is associated with the new process.
        /// The preferred way to shut down a process is by using the <see cref="ExitProcess"/> function,
        /// because this function sends notification of approaching termination to all DLLs attached to the process.
        /// Other means of shutting down a process do not notify the attached DLLs.
        /// Note that when a thread calls <see cref="ExitProcess"/>, other threads of the process are terminated 
        /// without an opportunity to execute any additional code (including the thread termination code of attached DLLs).
        /// For more information, see Terminating a Process.
        /// <see cref="CreateProcessWithLogonW"/> accesses the specified directory and executable image in the security context of the target user.
        /// If the executable image is on a network and a network drive letter is specified in the path,
        /// the network drive letter is not available to the target user, as network drive letters can be assigned for each logon.
        /// If a network drive letter is specified, this function fails. If the executable image is on a network, use the UNC path.
        /// There is a limit to the number of child processes that can be created by this function and run simultaneously.
        /// For example, on Windows XP, this limit is <see cref="MAXIMUM_WAIT_OBJECTS"/>*4.
        /// However, you may not be able to create this many processes due to system-wide quota limits.
        /// Windows XP with SP2,Windows Server 2003, or later:  You cannot call <see cref="CreateProcessWithLogonW"/> from a process
        /// that is running under the "LocalSystem" account, because the function uses the logon SID in the caller token,
        /// and the token for the "LocalSystem" account does not contain this SID.
        /// As an alternative, use the <see cref="CreateProcessAsUser"/> and <see cref="LogonUser"/> functions.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// 
        /// Security Remarks
        /// The first parameter, <paramref name="lpApplicationName"/>, can be <see langword="null"/>,
        /// in which case the executable name must be in the white space–delimited string pointed to by <paramref name="lpCommandLine"/>.
        /// If the executable or path name has a space in it, there is a risk that a different executable
        /// could be run because of the way the function parses spaces.
        /// The following example is dangerous because the function will attempt to run "Program.exe", if it exists, instead of "MyApp.exe".
        /// <code>
        /// LPTSTR szCmdline = _tcsdup(TEXT("C:\\Program Files\\MyApp -L -S"));
        /// CreateProcessWithLogonW(NULL, szCmdline, /* ... */);
        /// </code>
        /// If a malicious user were to create an application called "Program.exe" on a system,
        /// any program that incorrectly calls <see cref="CreateProcessWithLogonW"/> using the Program Files directory will run this application
        /// instead of the intended application.
        /// To avoid this problem, do not pass <see langword="null"/> for <paramref name="lpApplicationName"/>.
        /// If you do pass <see langword="null"/> for <paramref name="lpApplicationName"/>,
        /// use quotation marks around the executable path in <paramref name="lpCommandLine"/>, as shown in the example below.
        /// <code>
        /// LPTSTR szCmdline[] = _tcsdup(TEXT("\"C:\\Program Files\\MyApp\" -L -S"));
        /// CreateProcessWithLogonW(NULL, szCmdline, /*...*/);
        /// </code>
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessWithLogonW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateProcessWithLogonW([MarshalAs(UnmanagedType.LPWStr)][In] string lpUsername,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpDomain, [MarshalAs(UnmanagedType.LPWStr)][In] string lpPassword,
            [In] LogonFlags dwLogonFlags, [MarshalAs(UnmanagedType.LPWStr)][In] string lpApplicationName,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpCommandLine, [In] ProcessCreationFlags dwCreationFlags,
            [In] IntPtr lpEnvironment, [MarshalAs(UnmanagedType.LPWStr)][In] string lpCurrentDirectory,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AlternativeStructObjectMarshaler<STARTUPINFO, STARTUPINFOEX>))]
            [In]AlternativeStructObject<STARTUPINFO, STARTUPINFOEX> lpStartupInfo, [Out] out PROCESS_INFORMATION lpProcessInformation);


        /// <summary>
        /// <para>
        /// Creates a new process and its primary thread. The new process runs in the security context of the specified token.
        /// It can optionally load the user profile for the specified user.
        /// The process that calls CreateProcessWithTokenW must have the SE_IMPERSONATE_NAME privilege.
        /// If this function fails with <see cref="SystemErrorCodes.ERROR_PRIVILEGE_NOT_HELD"/>, use the <see cref="CreateProcessAsUser"/>
        /// or <see cref="CreateProcessWithLogonW"/> function instead.
        /// Typically, the process that calls <see cref="CreateProcessAsUser"/> must have the SE_INCREASE_QUOTA_NAME privilege
        /// and may require the SE_ASSIGNPRIMARYTOKEN_NAME privilege if the token is not assignable.
        /// <see cref="CreateProcessWithLogonW"/> requires no special privileges, but the specified user account must be allowed to log on interactively.
        /// Generally, it is best to use <see cref="CreateProcessWithLogonW"/> to create a process with alternate credentials.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createprocesswithtokenw"/>
        /// </para>
        /// </summary>
        /// <param name="hToken">
        /// A handle to the primary token that represents a user.
        /// The handle must have the <see cref="TOKEN_QUERY"/>, <see cref="TOKEN_DUPLICATE"/>, and <see cref="TOKEN_ASSIGN_PRIMARY"/> access rights.
        /// For more information, see Access Rights for Access-Token Objects.
        /// The user represented by the token must have read and execute access to the application specified
        /// by the <paramref name="lpApplicationName"/> or the <paramref name="lpCommandLine"/> parameter.
        /// To get a primary token that represents the specified user, call the <see cref="LogonUser"/> function.
        /// Alternatively, you can call the <see cref="DuplicateTokenEx"/> function to convert an impersonation token into a primary token.
        /// This allows a server application that is impersonating a client to create a process that has the security context of the client.
        /// Terminal Services:  The process is run in the session specified in the token.
        /// By default, this is the same session that called <see cref="LogonUser"/>.
        /// To change the session, use the <see cref="SetTokenInformation"/> function.
        /// </param>
        /// <param name="dwLogonFlags">
        /// The logon option. This parameter can be zero or one of the following values.
        /// <see cref="LOGON_WITH_PROFILE"/>, <see cref="LOGON_NETCREDENTIALS_ONLY"/>
        /// </param>
        /// <param name="lpApplicationName">
        /// The name of the module to be executed. This module can be a Windows-based application.
        /// It can be some other type of module (for example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
        /// The string can specify the full path and file name of the module to execute or it can specify a partial name.
        /// In the case of a partial name, the function uses the current drive and current directory to complete the specification.
        /// The function will not use the search path. This parameter must include the file name extension; no default extension is assumed.
        /// The <paramref name="lpApplicationName"/> parameter can be <see langword="null"/>.
        /// In that case, the module name must be the first white space–delimited token in the <paramref name="lpCurrentDirectory"/> string.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin;
        /// otherwise, the file name is ambiguous.
        /// For example, consider the string "c:\program files\sub dir\program name".
        /// This string can be interpreted in a number of ways.
        /// The system tries to interpret the possibilities in the following order:
        /// c:\program.exe c:\program files\sub.exe c:\program files\sub dir\program.exe c:\program files\sub dir\program name.exe
        /// If the executable module is a 16-bit application, <paramref name="lpApplicationName"/> should be <see langword="null"/>,
        /// and the string pointed to by <paramref name="lpCommandLine"/> should specify the executable module as well as its arguments.
        /// </param>
        /// <param name="lpCommandLine">
        /// The command line to be executed.
        /// The maximum length of this string is 1024 characters.
        /// If <paramref name="lpApplicationName"/> is <see langword="null"/>, the module name
        /// portion of <paramref name="lpCommandLine"/> is limited to <see cref="MAX_PATH"/> characters.
        /// The function can modify the contents of this string.
        /// Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string).
        /// If this parameter is a constant string, the function may cause an access violation.
        /// The <paramref name="lpCommandLine"/> parameter can be <see langword="null"/>.
        /// In that case, the function uses the string pointed to by <paramref name="lpApplicationName"/> as the command line.
        /// If both <paramref name="lpApplicationName"/> and <paramref name="lpCommandLine"/> are non-NULL,
        /// <paramref name="lpApplicationName"/> specifies the module to execute, and <paramref name="lpCommandLine"/> specifies the command line. 
        /// The new process can use <see cref="GetCommandLine"/> to retrieve the entire command line.
        /// Console processes written in C can use the argc and argv arguments to parse the command line.
        /// Because argv[0] is the module name, C programmers generally repeat the module name as the first token in the command line.
        /// If <paramref name="lpApplicationName"/> is <see langword="null"/>,
        /// the first white space–delimited token of the command line specifies the module name.
        /// If you are using a long file name that contains a space, use quoted strings to indicate
        /// where the file name ends and the arguments begin (see the explanation for the <paramref name="lpApplicationName"/> parameter).
        /// If the file name does not contain an extension, .exe is appended.
        /// Therefore, if the file name extension is .com, this parameter must include the .com extension.
        /// If the file name ends in a period (.) with no extension, or if the file name contains a path, .exe is not appended.
        /// If the file name does not contain a directory path, the system searches for the executable file in the following sequence:
        /// 1. The directory from which the application loaded.
        /// 2. The current directory for the parent process.
        /// 3. The 32-bit Windows system directory. Use the <see cref="GetSystemDirectory"/> function to get the path of this directory.
        /// 4. The 16-bit Windows system directory. There is no function that obtains the path of this directory, but it is searched.
        /// 5. The Windows directory. Use the <see cref="GetWindowsDirectory"/> function to get the path of this directory.
        /// 6. The directories that are listed in the PATH environment variable.
        /// Note that this function does not search the per-application path specified by the App Paths registry key.
        /// To include this per-application path in the search sequence, use the <see cref="ShellExecute"/> function.
        /// The system adds a null character to the command line string to separate the file name from the arguments.
        /// This divides the original string into two strings for internal processing.
        /// </param>
        /// <param name="dwCreationFlags">
        /// The flags that control how the process is created.
        /// The <see cref="CREATE_DEFAULT_ERROR_MODE"/>, <see cref="CREATE_NEW_CONSOLE"/>,
        /// and <see cref="CREATE_NEW_PROCESS_GROUP"/> flags are enabled by default— even if you do not set the flag,
        /// the system functions as if it were set. You can specify additional flags as noted.
        /// <see cref="CREATE_DEFAULT_ERROR_MODE"/>, <see cref="CREATE_NEW_CONSOLE"/>,
        /// <see cref="CREATE_NEW_PROCESS_GROUP"/>, <see cref="CREATE_SEPARATE_WOW_VDM"/>,
        /// <see cref="CREATE_SUSPENDED"/>, <see cref="CREATE_UNICODE_ENVIRONMENT"/>,
        /// <see cref="EXTENDED_STARTUPINFO_PRESENT"/>
        /// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the process's threads.
        /// For a list of values, see <see cref="GetPriorityClass"/>.
        /// If none of the priority class flags is specified, the priority class defaults to <see cref="NORMAL_PRIORITY_CLASS"/>
        /// unless the priority class of the creating process is <see cref="IDLE_PRIORITY_CLASS"/>
        /// or <see cref="BELOW_NORMAL_PRIORITY_CLASS"/>.
        /// In this case, the child process receives the default priority class of the calling process.
        /// </param>
        /// <param name="lpEnvironment">
        /// A pointer to an environment block for the new process.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the new process uses an environment created
        /// from the profile of the user specified by <paramref name="hToken"/>.
        /// An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:
        /// name=value
        /// Because the equal sign (=) is used as a separator, it must not be used in the name of an environment variable.
        /// An environment block can contain Unicode or ANSI characters.
        /// If the environment block pointed to by <paramref name="lpEnvironment"/> contains Unicode characters,
        /// ensure that <paramref name="dwCreationFlags"/> includes <see cref="CREATE_UNICODE_ENVIRONMENT"/>.
        /// If this parameter is <see cref="IntPtr.Zero"/> and the environment block of the parent process contains Unicode characters,
        /// you must also ensure that <paramref name="dwCreationFlags"/> includes <see cref="CREATE_UNICODE_ENVIRONMENT"/>.
        /// An ANSI environment block is terminated by two 0 (zero) bytes: one for the last string and one more to terminate the block.
        /// A Unicode environment block is terminated by four zero bytes: two for the last string and two more to terminate the block.
        /// To retrieve a copy of the environment block for a specific user, use the <see cref="CreateEnvironmentBlock"/> function.
        /// </param>
        /// <param name="lpCurrentDirectory">
        /// The full path to the current directory for the process. The string can also specify a UNC path.
        /// If this parameter is <see langword="null"/>, the new process has the same current drive and directory as the calling process.
        /// This feature is provided primarily for shells that need to start an application, and specify its initial drive and working directory.
        /// </param>
        /// <param name="lpStartupInfo">
        /// A pointer to a <see cref="STARTUPINFO"/> structure.
        /// The application must add permission for the specified user account to the specified window station and desktop, even for WinSta0\Default.
        /// If the <see cref="STARTUPINFO.lpDesktop"/> member is <see cref="IntPtr.Zero"/> or an empty string,
        /// the new process inherits the desktop and window station of its parent process.
        /// The application must add permission for the specified user account to the inherited window station and desktop.
        /// Windows XP:  <see cref="CreateProcessWithLogonW"/> adds permission for the specified user account to the inherited window station and desktop.
        /// Handles in <see cref="STARTUPINFO"/> must be closed with <see cref="CloseHandle"/> when they are no longer needed.
        /// If the <see cref="STARTUPINFO.dwFlags"/> member of the <see cref="STARTUPINFO"/> structure
        /// specifies <see cref="STARTUPINFOFlags.STARTF_USESTDHANDLES"/>, 
        /// the standard handle fields are copied unchanged to the child process without validation.
        /// The caller is responsible for ensuring that these fields contain valid handle values.
        /// Incorrect values can cause the child process to misbehave or crash.
        /// Use the Application Verifier runtime verification tool to detect invalid handles.
        /// </param>
        /// <param name="lpProcessInformation">
        /// A pointer to a <see cref="PROCESS_INFORMATION"/> structure that receives identification information for the new process,
        /// including a handle to the process.
        /// Handles in <see cref="PROCESS_INFORMATION"/> must be closed with the <see cref="CloseHandle"/> function when they are not needed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Note that the function returns before the process has finished initialization.
        /// If a required DLL cannot be located or fails to initialize, the process is terminated.
        /// To get the termination status of a process, call <see cref="GetExitCodeProcess"/>.
        /// </returns>
        /// <remarks>
        /// By default, <see cref="CreateProcessWithTokenW"/> does not load the specified user profile into the HKEY_USERS registry key.
        /// This means that access to information in the HKEY_CURRENT_USER registry key may not produce results that are consistent
        /// with a normal interactive logon.
        /// It is your responsibility to load the user registry hive into HKEY_USERS before calling <see cref="CreateProcessWithTokenW"/>,
        /// by using <see cref="LOGON_WITH_PROFILE"/>, or by calling the <see cref="LoadUserProfile"/> function.
        /// If the <paramref name="lpEnvironment"/> parameter is <see cref="IntPtr.Zero"/>,
        /// the new process uses an environment block created from the profile of the user specified by <paramref name="hToken"/>.
        /// If the HOMEDRIVE and HOMEPATH variables are not set, <see cref="CreateProcessWithTokenW"/> modifies the environment block
        /// to use the drive and path of the user's working directory.
        /// When created, the new process and thread handles receive full access rights
        /// (<see cref="PROCESS_ALL_ACCESS"/> and <see cref="THREAD_ALL_ACCESS"/>).
        /// For either handle, if a security descriptor is not provided, the handle can be used in any function that requires an object handle of that type.
        /// When a security descriptor is provided, an access check is performed on all subsequent uses of the handle before access is granted.
        /// If access is denied, the requesting process cannot use the handle to gain access to the process or thread.
        /// To retrieve a security token, pass the process handle in the <see cref="PROCESS_INFORMATION"/> structure
        /// to the <see cref="OpenProcessToken"/> function.
        /// The process is assigned a process identifier. The identifier is valid until the process terminates.
        /// It can be used to identify the process, or it can be specified in the <see cref="OpenProcess"/> function to open a handle to the process.
        /// The initial thread in the process is also assigned a thread identifier.
        /// It can be specified in the <see cref="OpenThread"/> function to open a handle to the thread.
        /// The identifier is valid until the thread terminates and can be used to uniquely identify the thread within the system.
        /// These identifiers are returned in <see cref="PROCESS_INFORMATION"/>.
        /// The calling thread can use the <see cref="WaitForInputIdle"/> function to wait until the new process has completed
        /// its initialization and is waiting for user input with no input pending.
        /// This can be useful for synchronization between parent and child processes,
        /// because <see cref="CreateProcessWithTokenW"/> returns without waiting for the new process to finish its initialization.
        /// For example, the creating process would use <see cref="WaitForInputIdle"/> before trying to
        /// find a window that is associated with the new process.
        /// The preferred way to shut down a process is by using the <see cref="ExitProcess"/> function,
        /// because this function sends notification of approaching termination to all DLLs attached to the process.
        /// Other means of shutting down a process do not notify the attached DLLs.
        /// Note that when a thread calls <see cref="ExitProcess"/>, other threads of the process are terminated 
        /// without an opportunity to execute any additional code (including the thread termination code of attached DLLs).
        /// For more information, see Terminating a Process.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// 
        /// Security Remarks
        /// The first parameter, <paramref name="lpApplicationName"/>, can be <see langword="null"/>,
        /// in which case the executable name must be in the white space–delimited string pointed to by <paramref name="lpCommandLine"/>.
        /// If the executable or path name has a space in it, there is a risk that a different executable
        /// could be run because of the way the function parses spaces.
        /// The following example is dangerous because the function will attempt to run "Program.exe", if it exists, instead of "MyApp.exe".
        /// <code>
        /// LPTSTR szCmdline = _tcsdup(TEXT("C:\\Program Files\\MyApp -L -S"));
        /// CreateProcessWithTokenW(NULL, szCmdline, /* ... */);
        /// </code>
        /// If a malicious user were to create an application called "Program.exe" on a system,
        /// any program that incorrectly calls <see cref="CreateProcessWithTokenW"/> using the Program Files directory will run this application
        /// instead of the intended application.
        /// To avoid this problem, do not pass <see langword="null"/> for <paramref name="lpApplicationName"/>.
        /// If you do pass <see langword="null"/> for <paramref name="lpApplicationName"/>,
        /// use quotation marks around the executable path in <paramref name="lpCommandLine"/>, as shown in the example below.
        /// <code>
        /// LPTSTR szCmdline[] = _tcsdup(TEXT("\"C:\\Program Files\\MyApp\" -L -S"));
        /// CreateProcessWithTokenW(NULL, szCmdline, /*...*/);
        /// </code>
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessWithTokenW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateProcessWithTokenW([In] HANDLE hToken, [In] LogonFlags dwLogonFlags,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpApplicationName, [MarshalAs(UnmanagedType.LPWStr)][In] string lpCommandLine,
            [In] ProcessCreationFlags dwCreationFlags, [In] IntPtr lpEnvironment, [MarshalAs(UnmanagedType.LPWStr)][In] string lpCurrentDirectory,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AlternativeStructObjectMarshaler<STARTUPINFO, STARTUPINFOEX>))]
            [In]AlternativeStructObject<STARTUPINFO, STARTUPINFOEX> lpStartupInfo, [Out] out PROCESS_INFORMATION lpProcessInformation);

        /// <summary>
        /// <para>
        /// Creates a new process and its primary thread.
        /// The new process runs in the security context of the user represented by the specified token.
        /// Typically, the process that calls the <see cref="CreateProcessAsUser"/> function must have the SE_INCREASE_QUOTA_NAME privilege
        /// and may require the SE_ASSIGNPRIMARYTOKEN_NAME privilege if the token is not assignable.
        /// If this function fails with <see cref="SystemErrorCodes.ERROR_PRIVILEGE_NOT_HELD"/>,
        /// use the <see cref="CreateProcessWithLogonW"/> function instead.
        /// <see cref="CreateProcessWithLogonW"/> requires no special privileges,
        /// but the specified user account must be allowed to log on interactively.
        /// Generally, it is best to use <see cref="CreateProcessWithLogonW"/> to create a process with alternate credentials.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-createprocessasuserw"/>
        /// </para>
        /// </summary>
        /// <param name="hToken">
        /// A handle to the primary token that represents a user.
        /// The handle must have the <see cref="TOKEN_QUERY"/>, <see cref="TOKEN_DUPLICATE"/>, and <see cref="TOKEN_ASSIGN_PRIMARY"/> access rights.
        /// For more information, see Access Rights for Access-Token Objects.
        /// The user represented by the token must have read and execute access to the application specified by
        /// the <paramref name="lpApplicationName"/> or the <paramref name="lpCommandLine"/> parameter.
        /// To get a primary token that represents the specified user, call the <see cref="LogonUser"/> function.
        /// Alternatively, you can call the <see cref="DuplicateTokenEx"/> function to convert an impersonation token into a primary token.
        /// This allows a server application that is impersonating a client to create a process that has the security context of the client.
        /// If <paramref name="hToken"/> is a restricted version of the caller's primary token,
        /// the SE_ASSIGNPRIMARYTOKEN_NAME privilege is not required.
        /// If the necessary privileges are not already enabled, <see cref="CreateProcessAsUser"/> enables them for the duration of the call.
        /// For more information, see Running with Special Privileges.
        /// Terminal Services:  The process is run in the session specified in the token.
        /// By default, this is the same session that called <see cref="LogonUser"/>.
        /// To change the session, use the <see cref="SetTokenInformation"/> function.
        /// </param>
        /// <param name="lpApplicationName">
        /// The name of the module to be executed. This module can be a Windows-based application.
        /// It can be some other type of module (for example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
        /// The string can specify the full path and file name of the module to execute or it can specify a partial name.
        /// In the case of a partial name, the function uses the current drive and current directory to complete the specification.
        /// The function will not use the search path.
        /// This parameter must include the file name extension; no default extension is assumed.
        /// The <paramref name="lpApplicationName"/> parameter can be <see langword="null"/>.
        /// In that case, the module name must be the first white space–delimited token in the <paramref name="lpCommandLine"/> string.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin;
        /// otherwise, the file name is ambiguous.
        /// For example, consider the string "c:\program files\sub dir\program name".
        /// This string can be interpreted in a number of ways.
        /// The system tries to interpret the possibilities in the following order:
        /// c:\program.exe c:\program files\sub.exe c:\program files\sub dir\program.exe c:\program files\sub dir\program name.exe
        /// If the executable module is a 16-bit application, <paramref name="lpApplicationName"/> should be NULL,
        /// and the string pointed to by <paramref name="lpCommandLine"/> should specify the executable module as well as its arguments.
        /// By default, all 16-bit Windows-based applications created by <see cref="CreateProcessAsUser"/> are run in a separate VDM
        /// (equivalent to <see cref="CREATE_SEPARATE_WOW_VDM"/> in <see cref="CreateProcess"/>).
        /// </param>
        /// <param name="lpCommandLine">
        /// The command line to be executed.
        /// The maximum length of this string is 32,768 characters, including the Unicode terminating null character.
        /// If lpApplicationName is <see langword="null"/>,
        /// the module name portion of <paramref name="lpCommandLine"/> is limited to <see cref="MAX_PATH"/> characters.
        /// The Unicode version of this function, <see cref="CreateProcess"/>, can modify the contents of this string.
        /// Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string).
        /// If this parameter is a constant string, the function may cause an access violation.
        /// The <paramref name="lpCommandLine"/> parameter can be <see langword="null"/>.
        /// In that case, the function uses the string pointed to by <paramref name="lpApplicationName"/> as the command line.
        /// If both <paramref name="lpApplicationName"/> and <paramref name="lpCommandLine"/> are non-NULL,
        /// the null-terminated string pointed to by <paramref name="lpApplicationName"/> specifies the module to execute,
        /// and the null-terminated string pointed to by <paramref name="lpCommandLine"/> specifies the command line.
        /// The new process can use <see cref="GetCommandLine"/> to retrieve the entire command line.
        /// Console processes written in C can use the argc and argv arguments to parse the command line.
        /// Because argv[0] is the module name, C programmers generally repeat the module name as the first token in the command line.
        /// If <paramref name="lpApplicationName"/> is <see langword="null"/>,
        /// the first white space–delimited token of the command line specifies the module name.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and
        /// the arguments begin (see the explanation for the <paramref name="lpApplicationName"/> parameter).
        /// If the file name does not contain an extension, .exe is appended.
        /// Therefore, if the file name extension is .com, this parameter must include the .com extension.
        /// If the file name ends in a period (.) with no extension, or if the file name contains a path, .exe is not appended.
        /// If the file name does not contain a directory path, the system searches for the executable file in the following sequence:
        /// 1.The directory from which the application loaded.
        /// 2. The current directory for the parent process.
        /// 3. The 32-bit Windows system directory. Use the <see cref="GetSystemDirectory"/> function to get the path of this directory.
        /// 4.The 16-bit Windows system directory. 
        /// There is no function that obtains the path of this directory, but it is searched. The name of this directory is System.
        /// 5. The Windows directory. Use the <see cref="GetWindowsDirectory"/> function to get the path of this directory.
        /// 6.The directories that are listed in the PATH environment variable.
        /// Note that this function does not search the per-application path specified by the App Paths registry key.
        /// To include this per-application path in the search sequence, use the <see cref="ShellExecute"/> function.
        /// The system adds a terminating null character to the command-line string to separate the file name from the arguments.
        /// This divides the original string into two strings for internal processing.
        /// </param>
        /// <param name="lpProcessAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether
        /// the returned handle to the new process object can be inherited by child processes.
        /// If <paramref name="lpProcessAttributes"/> is <see langword="null"/>, the handle cannot be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new process.
        /// If <paramref name="lpProcessAttributes"/> is <see langword="null"/> or
        /// <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> is <see cref="IntPtr.Zero"/>, the process gets a default security descriptor
        /// and the handle cannot be inherited..
        /// The default security descriptor is that of the user referenced in the <paramref name="hToken"/> parameter.
        /// This security descriptor may not allow access for the caller, in which case the process may not be opened again after it is run.
        /// The process handle is valid and will continue to have full access rights.
        /// </param>
        /// <param name="lpThreadAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether
        /// the returned handle to the new thread object can be inherited by child processes.
        /// If <paramref name="lpThreadAttributes"/> is <see langword="null"/>, the handle cannot be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the main thread.
        /// If <paramref name="lpThreadAttributes"/> is <see langword="null"/> or
        /// <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> is <see cref="IntPtr.Zero"/>, the thread gets a default security descriptor
        /// and the handle cannot be inherited.
        /// The default security descriptor is that of the user referenced in the <paramref name="hToken"/> parameter.
        /// This security descriptor may not allow access for the caller.
        /// </param>
        /// <param name="bInheritHandles">
        /// If this parameter is <see langword="true"/>, each inheritable handle in the calling process is inherited by the new process.
        /// If the parameter is <see langword="false"/>, the handles are not inherited.
        /// Note that inherited handles have the same value and access rights as the original handles.
        /// For additional discussion of inheritable handles, see Remarks.
        /// Terminal Services:  You cannot inherit handles across sessions.
        /// Additionally, if this parameter is <see langword="true"/>, you must create the process in the same session as the caller.
        /// Protected Process Light (PPL) processes:  The generic handle inheritance is blocked
        /// when a PPL process creates a non-PPL process since <see cref="PROCESS_DUP_HANDLE"/> is not allowed from a non-PPL process to a PPL process.
        /// See Process Security and Access Rights
        /// </param>
        /// <param name="dwCreationFlags">
        /// The flags that control the priority class and the creation of the process.
        /// For a list of values, see Process Creation Flags.
        /// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the process's threads.
        /// For a list of values, see <see cref="GetPriorityClass"/>.
        /// If none of the priority class flags is specified, the priority class defaults to <see cref="NORMAL_PRIORITY_CLASS"/>
        /// unless the priority class of the creating process is <see cref="IDLE_PRIORITY_CLASS"/> 
        /// or <see cref="BELOW_NORMAL_PRIORITY_CLASS"/>.
        /// In this case, the child process receives the default priority class of the calling process.
        /// </param>
        /// <param name="lpEnvironment">
        /// A pointer to the environment block for the new process.
        /// If this parameter is <see langword="null"/>, the new process uses the environment of the calling process.
        /// An environment block consists of a null-terminated block of null-terminated strings.
        /// Each string is in the following form: name=value\0
        /// Because the equal sign is used as a separator, it must not be used in the name of an environment variable.
        /// An environment block can contain either Unicode or ANSI characters.
        /// If the environment block pointed to by <paramref name="lpEnvironment"/> contains Unicode characters,
        /// be sure that <paramref name="dwCreationFlags"/> includes <see cref="CREATE_UNICODE_ENVIRONMENT"/>.
        /// If this parameter is <see langword="null"/> and the environment block of the parent process contains Unicode characters,
        /// you must also ensure that <paramref name="dwCreationFlags"/> includes <see cref="CREATE_UNICODE_ENVIRONMENT"/>.
        /// The ANSI version of this function, <see cref="CreateProcessAsUser"/> fails if the total size of
        /// the environment block for the process exceeds 32,767 characters.
        /// Note that an ANSI environment block is terminated by two zero bytes: one for the last string, one more to terminate the block.
        /// A Unicode environment block is terminated by four zero bytes: two for the last string, two more to terminate the block.
        /// Windows Server 2003 and Windows XP:  If the size of the combined user and system environment variable exceeds 8192 bytes, 
        /// the process created by CreateProcessAsUser no longer runs with the environment block passed to the function by the parent process.
        /// Instead, the child process runs with the environment block returned by the <see cref="CreateEnvironmentBlock"/> function.
        /// To retrieve a copy of the environment block for a given user, use the <see cref="CreateEnvironmentBlock"/> function.
        /// </param>
        /// <param name="lpCurrentDirectory">
        /// The full path to the current directory for the process. The string can also specify a UNC path.
        /// If this parameter is <see langword="null"/>, the new process will have the same current drive and directory as the calling process.
        /// (This feature is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
        /// </param>
        /// <param name="lpStartupInfo">
        /// A pointer to a <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> structure.
        /// To set extended attributes, use a <see cref="STARTUPINFOEX"/> structure and
        /// specify <see cref="EXTENDED_STARTUPINFO_PRESENT"/> in the <paramref name="dwCreationFlags"/> parameter.
        /// Handles in <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> must be closed
        /// with <see cref="CloseHandle"/> when they are no longer needed.
        /// Important  The caller is responsible for ensuring that the standard handle fields in <see cref="STARTUPINFO"/> contain valid handle values.
        /// These fields are copied unchanged to the child process without validation,
        /// even when the dwFlags member specifies <see cref="STARTUPINFOFlags.STARTF_USESTDHANDLES"/>.
        /// Incorrect values can cause the child process to misbehave or crash.
        /// Use the Application Verifier runtime verification tool to detect invalid handles.
        /// </param>
        /// <param name="lpProcessInformation">
        /// A pointer to a <see cref="PROCESS_INFORMATION"/> structure that receives identification information about the new process.
        /// Handles in <see cref="PROCESS_INFORMATION"/> must be closed with <see cref="CloseHandle"/> when they are no longer needed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Note that the function returns before the process has finished initialization.
        /// If a required DLL cannot be located or fails to initialize, the process is terminated.
        /// To get the termination status of a process, call <see cref="GetExitCodeProcess"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="CreateProcessAsUser"/> must be able to open the primary token of the calling process
        /// with the <see cref="TOKEN_DUPLICATE"/> and <see cref="TOKEN_IMPERSONATE"/> access rights.
        /// By default, <see cref="CreateProcessAsUser"/> creates the new process on a noninteractive window station
        /// with a desktop that is not visible and cannot receive user input.
        /// To enable user interaction with the new process, you must specify the name of
        /// the default interactive window station and desktop, "winsta0\default", in the <see cref="STARTUPINFO.lpDesktop"/> member
        /// of the <see cref="STARTUPINFO"/> structure.
        /// In addition, before calling <see cref="CreateProcessAsUser"/>, you must change the discretionary access control list (DACL) of both
        /// the default interactive window station and the default desktop.
        /// The DACLs for the window station and desktop must grant access to the user or the logon session
        /// represented by the <paramref name="hToken"/> parameter.
        /// <see cref="CreateProcessAsUser"/> does not load the specified user's profile into the HKEY_USERS registry key.
        /// Therefore, to access the information in the HKEY_CURRENT_USER registry key,
        /// you must load the user's profile information into HKEY_USERS with the <see cref="LoadUserProfile"/> function
        /// before calling <see cref="CreateProcessAsUser"/>.
        /// Be sure to call <see cref="UnloadUserProfile"/> after the new process exits.
        /// If the <paramref name="lpEnvironment"/> parameter is <see langword="null"/>, the new process inherits the environment of the calling process.
        /// <see cref="CreateProcessAsUser"/> does not automatically modify the environment block to include environment variables
        /// specific to the user represented by <paramref name="hToken"/>.
        /// For example, the USERNAME and USERDOMAIN variables are inherited from the calling process
        /// if <paramref name="lpEnvironment"/> is <see langword="null"/>.
        /// It is your responsibility to prepare the environment block for the new process and specify it in <paramref name="lpEnvironment"/>.
        /// The <see cref="CreateProcessWithLogonW"/> and <see cref="CreateProcessWithTokenW"/> functions are similar to
        /// <see cref="CreateProcessAsUser"/>, except that the caller does not need to call the <see cref="LogonUser"/> function
        /// to authenticate the user and get a token.
        /// <see cref="CreateProcessAsUser"/> allows you to access the specified directory and executable image in the security context
        /// of the caller or the target user.
        /// By default, <see cref="CreateProcessAsUser"/> accesses the directory and executable image in the security context of the caller.
        /// In this case, if the caller does not have access to the directory and executable image, the function fails.
        /// To access the directory and executable image using the security context of the target user, specify <paramref name="hToken"/> in a call
        /// to the <see cref="ImpersonateLoggedOnUser"/> function before calling <see cref="CreateProcessAsUser"/>.
        /// The process is assigned a process identifier.
        /// The identifier is valid until the process terminates.
        /// It can be used to identify the process, or specified in the <see cref="OpenProcess"/> function to open a handle to the process.
        /// The initial thread in the process is also assigned a thread identifier.
        /// It can be specified in the <see cref="OpenThread"/> function to open a handle to the thread.
        /// The identifier is valid until the thread terminates and can be used to uniquely identify the thread within the system.
        /// These identifiers are returned in the <see cref="PROCESS_INFORMATION"/> structure.
        /// The name of the executable in the command line that the operating system provides to a process is not necessarily identical
        /// to that in the command line that the calling process gives to the <see cref="CreateProcess"/> function.
        /// The operating system may prepend a fully qualified path to an executable name that is provided without a fully qualified path.
        /// The calling thread can use the <see cref="WaitForInputIdle"/> function to wait until the new process has finished its initialization
        /// and is waiting for user input with no input pending.
        /// For example, the creating process would use <see cref="WaitForInputIdle"/> before trying to find a window associated with the new process.
        /// This can be useful for synchronization between parent and child processes,
        /// because <see cref="CreateProcess"/> returns without waiting for the new process to finish its initialization.
        /// The preferred way to shut down a process is by using the <see cref="ExitProcess"/> function,
        /// because this function sends notification of approaching termination to all DLLs attached to the process.
        /// Other means of shutting down a process do not notify the attached DLLs.
        /// Note that when a thread calls <see cref="ExitProcess"/>, other threads of the process are terminated
        /// without an opportunity to execute any additional code (including the thread termination code of attached DLLs).
        /// For more information, see Terminating a Process.
        /// By default, passing <see langword="true"/> as the value of the <paramref name="bInheritHandles"/> parameter
        /// causes all inheritable handles to be inherited by the new process.
        /// This can be problematic for applications which create processes from multiple threads simultaneously
        /// yet desire each process to inherit different handles.
        /// Applications can use the <see cref="UpdateProcThreadAttribute"/> function
        /// with the <see cref="PROC_THREAD_ATTRIBUTE_HANDLE_LIST"/> parameter to provide a list of handles to be inherited by a particular process.
        /// 
        /// Security Remarks
        /// The first parameter, <paramref name="lpApplicationName"/>, can be <see langword="null"/>,
        /// in which case the executable name must be in the white space–delimited string pointed to by <paramref name="lpCommandLine"/>.
        /// If the executable or path name has a space in it, there is a risk that a different executable
        /// could be run because of the way the function parses spaces.
        /// The following example is dangerous because the function will attempt to run "Program.exe", if it exists, instead of "MyApp.exe".
        /// <code>
        /// LPTSTR szCmdline = _tcsdup(TEXT("C:\\Program Files\\MyApp -L -S"));
        /// CreateProcess(NULL, szCmdline, /* ... */);
        /// </code>
        /// If a malicious user were to create an application called "Program.exe" on a system,
        /// any program that incorrectly calls <see cref="CreateProcessAsUser"/> using the Program Files directory will run this application
        /// instead of the intended application.
        /// To avoid this problem, do not pass <see langword="null"/> for <paramref name="lpApplicationName"/>.
        /// If you do pass <see langword="null"/> for <paramref name="lpApplicationName"/>,
        /// use quotation marks around the executable path in <paramref name="lpCommandLine"/>, as shown in the example below.
        /// <code>
        /// LPTSTR szCmdline[] = _tcsdup(TEXT("\"C:\\Program Files\\MyApp\" -L -S"));
        /// CreateProcess(NULL, szCmdline, /*...*/);
        /// </code>
        /// PowerShell:  When the <see cref="CreateProcessAsUser"/> function is used to implement a cmdlet in PowerShell version 2.0,
        /// the cmdlet operates correctly for both fan-in and fan-out remote sessions.
        /// Because of certain security scenarios, however, a cmdlet implemented with <see cref="CreateProcessAsUser"/> only operates correctly
        /// in PowerShell version 3.0 for fan-in remote sessions; fan-out remote sessions will fail because of insufficient client security privileges.
        /// To implement a cmdlet that works for both fan-in and fan-out remote sessions in PowerShell version 3.0,
        /// use the <see cref="CreateProcess"/> function.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessAsUserW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateProcessAsUser([In] HANDLE hToken, [MarshalAs(UnmanagedType.LPWStr)][In] string lpApplicationName,
          [MarshalAs(UnmanagedType.LPWStr)][In] string lpCommandLine, [In] in SECURITY_ATTRIBUTES lpProcessAttributes,
          [In] in SECURITY_ATTRIBUTES lpThreadAttributes, [In] BOOL bInheritHandles, [In] ProcessCreationFlags dwCreationFlags,
          [In] LPVOID lpEnvironment, [MarshalAs(UnmanagedType.LPWStr)][In] string lpCurrentDirectory,
          [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AlternativeStructObjectMarshaler<STARTUPINFO, STARTUPINFOEX>))]
          [In]AlternativeStructObject<STARTUPINFO, STARTUPINFOEX> lpStartupInfo, [Out] out PROCESS_INFORMATION lpProcessInformation);

        /// <summary>
        /// <para>
        /// The <see cref="DestroyPrivateObjectSecurity"/> function deletes a private object's security descriptor.
        /// For background information, see the Security Descriptors for Private Objects topic.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-destroyprivateobjectsecurity"/>
        /// </para>
        /// </summary>
        /// <param name="ObjectDescriptor">
        /// A pointer to a pointer to the <see cref="SECURITY_DESCRIPTOR"/> structure to be deleted.
        /// This security descriptor must have been created by a call to the <see cref="CreatePrivateObjectSecurity"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyPrivateObjectSecurity", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyPrivateObjectSecurity([In] in PSECURITY_DESCRIPTOR ObjectDescriptor);

        /// <summary>
        /// <para>
        /// The <see cref="DuplicateToken"/> function creates a new access token that duplicates one already in existence.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-duplicatetoken"/>
        /// </para>
        /// </summary>
        /// <param name="ExistingTokenHandle">
        /// A handle to an access token opened with <see cref="TOKEN_DUPLICATE"/> access.
        /// </param>
        /// <param name="ImpersonationLevel">
        /// Specifies a <see cref="SECURITY_IMPERSONATION_LEVEL"/> enumerated type that supplies the impersonation level of the new token.
        /// </param>
        /// <param name="DuplicateTokenHandle">
        /// A pointer to a variable that receives a handle to the duplicate token.
        /// This handle has <see cref="TOKEN_IMPERSONATE"/> and <see cref="TOKEN_QUERY"/> access to the new token.
        /// When you have finished using the new token, call the <see cref="CloseHandle"/> function to close the token handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="DuplicateToken"/> function creates an impersonation token,
        /// which you can use in functions such as <see cref="SetThreadToken"/> and <see cref="ImpersonateLoggedOnUser"/>.
        /// The token created by <see cref="DuplicateToken"/> cannot be used in the <see cref="CreateProcessAsUser"/> function,
        /// which requires a primary token.
        /// To create a token that you can pass to <see cref="CreateProcessAsUser"/>, use the <see cref="DuplicateTokenEx"/> function.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DuplicateToken", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DuplicateToken([In] HANDLE ExistingTokenHandle, [In] SECURITY_IMPERSONATION_LEVEL ImpersonationLevel,
            [Out] out HANDLE DuplicateTokenHandle);

        /// <summary>
        /// <para>
        /// The <see cref="DuplicateTokenEx"/> function creates a new access token that duplicates an existing token.
        /// This function can create either a primary token or an impersonation token.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-duplicatetokenex"/>
        /// </para>
        /// </summary>
        /// <param name="ExistingTokenHandle">
        /// A handle to an access token opened with <see cref="TOKEN_DUPLICATE"/> access.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// Specifies the requested access rights for the new token.
        /// The <see cref="DuplicateTokenEx"/> function compares the requested access rights with the existing token's
        /// discretionary access control list (DACL) to determine which rights are granted or denied.
        /// To request the same access rights as the existing token, specify zero.
        /// To request all access rights that are valid for the caller, specify <see cref="MAXIMUM_ALLOWED"/>.
        /// For a list of access rights for access tokens, see Access Rights for Access-Token Objects.
        /// </param>
        /// <param name="lpTokenAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor for the new token and
        /// determines whether child processes can inherit the token.
        /// If <paramref name="lpTokenAttributes"/> is <see langword="null"/>, the token gets a default security descriptor and
        /// the handle cannot be inherited.
        /// If the security descriptor contains a system access control list (SACL), the token gets <see cref="ACCESS_SYSTEM_SECURITY"/> access right,
        /// even if it was not requested in <paramref name="dwDesiredAccess"/>.
        /// To set the owner in the security descriptor for the new token,
        /// the caller's process token must have the SeRestorePrivilege privilege set.
        /// </param>
        /// <param name="ImpersonationLevel">
        /// Specifies a value from the <see cref="SECURITY_IMPERSONATION_LEVEL"/> enumeration that indicates the impersonation level of the new token.
        /// </param>
        /// <param name="TokenType">
        /// Specifies one of the following values from the <see cref="TOKEN_TYPE"/> enumeration.
        /// <see cref="TokenPrimary"/>: The new token is a primary token that you can use in the <see cref="CreateProcessAsUser"/> function.
        /// <see cref="TokenImpersonation"/>: The new token is an impersonation token.
        /// </param>
        /// <param name="DuplicateTokenHandle">
        /// A pointer to a HANDLE variable that receives the new token.
        /// When you have finished using the new token, call the <see cref="CloseHandle"/> function to close the token handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="DuplicateTokenEx"/> function allows you to create a primary token
        /// that you can use in the <see cref="CreateProcessAsUser"/> function.
        /// This allows a server application that is impersonating a client to create a process that has the security context of the client.
        /// Note that the <see cref="DuplicateToken"/> function can create only impersonation tokens,
        /// which are not valid for <see cref="CreateProcessAsUser"/>.
        /// The following is a typical scenario for using <see cref="DuplicateTokenEx"/> to create a primary token.
        /// A server application creates a thread that calls one of the impersonation functions,
        /// such as <see cref="ImpersonateNamedPipeClient"/>, to impersonate a client.
        /// The impersonating thread then calls the <see cref="OpenThreadToken"/> function to get its own token,
        /// which is an impersonation token that has the security context of the client.
        /// The thread specifies this impersonation token in a call to <see cref="DuplicateTokenEx"/>, specifying the <see cref="TokenPrimary"/> flag.
        /// The <see cref="DuplicateTokenEx"/> function creates a primary token that has the security context of the client.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DuplicateTokenEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DuplicateTokenEx([In] HANDLE ExistingTokenHandle, [In] ACCESS_MASK dwDesiredAccess, [In] in SECURITY_ATTRIBUTES lpTokenAttributes,
            [In] SECURITY_IMPERSONATION_LEVEL ImpersonationLevel, [In] TOKEN_TYPE TokenType, [Out] out HANDLE DuplicateTokenHandle);

        /// <summary>
        /// <para>
        /// The <see cref="GetTokenInformation"/> function retrieves a specified type of information about an access token.
        /// The calling process must have appropriate access rights to obtain the information.
        /// To determine if a user is a member of a specific group, use the <see cref="CheckTokenMembership"/> function.
        /// To determine group membership for app container tokens, use the <see cref="CheckTokenMembershipEx"/> function.
        /// </para>
        /// </summary>
        /// <param name="TokenHandle">
        /// A handle to an access token from which information is retrieved.
        /// If <paramref name="TokenInformationClass"/> specifies <see cref="TokenSource"/>, the handle must have <see cref="TOKEN_QUERY_SOURCE"/> access.
        /// For all other <paramref name="TokenInformationClass"/> values, the handle must have <see cref="TOKEN_QUERY"/> access.
        /// </param>
        /// <param name="TokenInformationClass">
        /// Specifies a value from the <see cref="TOKEN_INFORMATION_CLASS"/> enumerated type to identify the type of information the function retrieves.
        /// Any callers who check the TokenIsAppContainer and have it return 0 should also verify that
        /// the caller token is not an identify level impersonation token.
        /// If the current token is not an app container but is an identity level token, you should return AccessDenied.
        /// </param>
        /// <param name="TokenInformation">
        /// A pointer to a buffer the function fills with the requested information.
        /// The structure put into this buffer depends upon the type of information specified by the <paramref name="TokenInformationClass"/> parameter.
        /// </param>
        /// <param name="TokenInformationLength">
        /// Specifies the size, in bytes, of the buffer pointed to by the <paramref name="TokenInformation"/> parameter.
        /// If <paramref name="TokenInformation"/> is NULL, this parameter must be zero.
        /// </param>
        /// <param name="ReturnLength">
        /// A pointer to a variable that receives the number of bytes needed for the buffer pointed to by the <paramref name="TokenInformation"/> parameter.
        /// If this value is larger than the value specified in the <paramref name="TokenInformationLength"/> parameter,
        /// the function fails and stores no data in the buffer.
        /// If the value of the <paramref name="TokenInformationClass"/> parameter is <see cref="TokenDefaultDacl"/> and the token has no default DACL,
        /// the function sets the variable pointed to by <paramref name="ReturnLength"/> to sizeof("TOKEN_DEFAULT_DACL) and
        /// sets the <see cref="TOKEN_DEFAULT_DACL.DefaultDacl"/> member of the <see cref="TOKEN_DEFAULT_DACL"/> structure to <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTokenInformation", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetTokenInformation([In] HANDLE TokenHandle, [In] TOKEN_INFORMATION_CLASS TokenInformationClass,
            [In] LPVOID TokenInformation, [In] DWORD TokenInformationLength, [Out] out DWORD ReturnLength);

        /// <summary>
        /// <para>
        /// The <see cref="GetSecurityDescriptorControl"/> function retrieves a security descriptor control and revision information.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-getsecuritydescriptorcontrol"/>
        /// </para>
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure whose control and revision information the function retrieves.
        /// </param>
        /// <param name="pControl">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR_CONTROL"/> structure that receives the security descriptor's control information.
        /// </param>
        /// <param name="lpdwRevision">
        /// A pointer to a variable that receives the security descriptor's revision value.
        /// This value is always set, even when <see cref="GetSecurityDescriptorControl"/> returns an error.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSecurityDescriptorControl", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetSecurityDescriptorControl([In] PSECURITY_DESCRIPTOR pSecurityDescriptor,
            [Out] out SECURITY_DESCRIPTOR_CONTROL pControl, [Out] out DWORD lpdwRevision);

        /// <summary>
        /// <para>
        /// The <see cref="ImpersonateAnonymousToken"/> function enables the specified thread to impersonate the system's anonymous logon token.
        /// To ensure that a token matches the operating system's concept of anonymous access,
        /// this function should be called before attempting network access to generate an anonymous token on the remote server.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-impersonateanonymoustoken"/>
        /// </para>
        /// </summary>
        /// <param name="ThreadHandle">
        /// A handle to the thread to impersonate the system's anonymous logon token.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// An error of ACCESS_DENIED may indicate that the token is for a restricted process.
        /// Use <see cref="OpenProcessToken"/> and <see cref="IsTokenRestricted"/> to check if the process is restricted.
        /// </returns>
        /// <remarks>
        /// Anonymous tokens do not include the Everyone Group SID unless the system default has been overridden
        /// by setting the HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Lsa\EveryoneIncludesAnonymous registry value to DWORD=1.
        /// To cancel the impersonation call <see cref="RevertToSelf"/>.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImpersonateAnonymousToken", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImpersonateAnonymousToken([In] HANDLE ThreadHandle);

        /// <summary>
        /// <para>
        /// Enables a Dynamic Data Exchange (DDE) server application to impersonate a DDE client application's security context.
        /// This protects secure server data from unauthorized DDE clients.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/dde/nf-dde-impersonateddeclientwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hWndClient">
        /// A handle to the DDE client window to be impersonated.
        /// The client window must have established a DDE conversation
        /// with the server window identified by the <paramref name="hWndServer"/> parameter.
        /// </param>
        /// <param name="hWndServer">
        /// A handle to the DDE server window.
        /// An application must create the server window before calling this function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// An application should call the <see cref="RevertToSelf"/> function
        /// to undo the impersonation set by the <see cref="ImpersonateDdeClientWindow"/> function.
        /// A DDEML application should use the <see cref="DdeImpersonateClient"/> function.
        /// Security Considerations
        /// Using this function incorrectly might compromise the security of your program.
        /// It is very important to check the return value of the call.
        /// If the function fails for any reason, the client is not impersonated
        /// and any subsequent client request is made in the security context of the calling process.
        /// If the calling process is running as a highly privileged account, such as LocalSystem or as a member of an administrative group,
        /// the user may be able to perform actions that would otherwise be disallowed.
        /// Therefore, if the call fails or raises an error do not continue execution of the client request. 
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImpersonateDdeClientWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImpersonateDdeClientWindow([In] HWND hWndClient, [In] HWND hWndServer);

        /// <summary>
        /// <para>
        /// The <see cref="ImpersonateLoggedOnUser"/> function lets the calling thread impersonate the security context of a logged-on user.
        /// The user is represented by a token handle.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-impersonateloggedonuser"/>
        /// </para>
        /// </summary>
        /// <param name="hToken">
        /// A handle to a primary or impersonation access token that represents a logged-on user.
        /// This can be a token handle returned by a call to <see cref="LogonUser"/>, <see cref="CreateRestrictedToken"/>,
        /// <see cref="DuplicateToken"/>, <see cref="DuplicateTokenEx"/>, <see cref="OpenProcessToken"/>, or <see cref="OpenThreadToken"/> functions.
        /// If <paramref name="hToken"/> is a handle to a primary token, the token must
        /// have <see cref="TOKEN_QUERY"/> and <see cref="TOKEN_DUPLICATE"/> access.
        /// If <paramref name="hToken"/> is a handle to an impersonation token,
        /// the token must have <see cref="TOKEN_QUERY"/> and <see cref="TOKEN_IMPERSONATE"/> access.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The impersonation lasts until the thread exits or until it calls <see cref="RevertToSelf"/>.
        /// The calling thread does not need to have any particular privileges to call <see cref="ImpersonateLoggedOnUser"/>.
        /// If the call to <see cref="ImpersonateLoggedOnUser"/> fails, the client connection is not impersonated
        /// and the client request is made in the security context of the process.
        /// If the process is running as a highly privileged account, such as LocalSystem, or as a member of an administrative group,
        /// the user may be able to perform actions they would otherwise be disallowed.
        /// Therefore, it is important to always check the return value of the call, and if it fails, raise an error;
        /// do not continue execution of the client request.
        /// All impersonate functions, including <see cref="ImpersonateLoggedOnUser"/> allow the requested impersonation if one of the following is true:
        /// The requested impersonation level of the token is less than <see cref="SecurityImpersonation"/>,
        /// such as <see cref="SecurityIdentification"/> or <see cref="SecurityAnonymous"/>.
        /// The caller has the SeImpersonatePrivilege privilege.
        /// A process (or another process in the caller's logon session) created the token using explicit credentials
        /// through <see cref="LogonUser"/> or <see cref="LsaLogonUser"/> function.
        /// The authenticated identity is same as the caller.
        /// Windows XP with SP1 and earlier:  The SeImpersonatePrivilege privilege is not supported.
        /// For more information about impersonation, see Client Impersonation.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImpersonateLoggedOnUser", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImpersonateLoggedOnUser([In] HANDLE hToken);

        /// <summary>
        /// <para>
        /// The <see cref="ImpersonateNamedPipeClient"/> function impersonates a named-pipe client application.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/namedpipeapi/nf-namedpipeapi-impersonatenamedpipeclient"/>
        /// </para>
        /// </summary>
        /// <param name="hNamedPipe">
        /// A handle to a named pipe.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="ImpersonateNamedPipeClient"/> function allows the server end of a named pipe to impersonate the client end.
        /// When this function is called, the named-pipe file system changes the thread of the calling process
        /// to start impersonating the security context of the last message read from the pipe.
        /// Only the server end of the pipe can call this function.
        /// The server can call the <see cref="RevertToSelf"/> function when the impersonation is complete.
        /// Important If the <see cref="ImpersonateNamedPipeClient"/> function fails, the client is not impersonated,
        /// and all subsequent client requests are made in the security context of the process that called the function.
        /// If the calling process is running as a privileged account, it can perform actions that the client would not be allowed to perform.
        /// To avoid security risks, the calling process should always check the return value.
        /// If the return value indicates that the function call failed, no client requests should be executed.
        /// ll impersonate functions, including <see cref="ImpersonateNamedPipeClient"/> allow the requested impersonation if one of the following is true:
        /// The requested impersonation level of the token is less than <see cref="SecurityImpersonation"/>,
        /// such as <see cref="SecurityIdentification"/> or <see cref="SecurityAnonymous"/>.
        /// The caller has the SeImpersonatePrivilege privilege.
        /// A process (or another process in the caller's logon session) created the token using explicit credentials
        /// through <see cref="LogonUser"/> or <see cref="LsaLogonUser"/> function.
        /// The authenticated identity is same as the caller.
        /// Windows XP with SP1 and earlier:  The SeImpersonatePrivilege privilege is not supported.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImpersonateNamedPipeClient", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImpersonateNamedPipeClient([In] HANDLE hNamedPipe);

        /// <summary>
        /// <para>
        /// The <see cref="ImpersonateSelf"/> function obtains an access token that impersonates the security context of the calling process.
        /// The token is assigned to the calling thread.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-impersonateself"/>
        /// </para>
        /// </summary>
        /// <param name="ImpersonationLevel">
        /// Specifies a <see cref="SECURITY_IMPERSONATION_LEVEL"/> enumerated type that supplies the impersonation level of the new token.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>. 
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="ImpersonateSelf"/> function is used for tasks such as enabling a privilege for a single thread
        /// rather than for the entire process or for changing the default discretionary access control list (DACL) for a single thread.
        /// The server can call the <see cref="RevertToSelf"/> function when the impersonation is complete.
        /// For this function to succeed, the DACL protecting the process token must grant the <see cref="TOKEN_DUPLICATE"/> right to itself.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImpersonateSelf", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImpersonateSelf([In] SECURITY_IMPERSONATION_LEVEL ImpersonationLevel);

        /// <summary>
        /// <para>
        /// Initiates a shutdown and optional restart of the specified computer.
        /// To record a reason for the shutdown in the event log, call the <see cref="InitiateSystemShutdownEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-initiatesystemshutdownw"/>
        /// </para>
        /// </summary>
        /// <param name="lpMachineName">
        /// The network name of the computer to be shut down.
        /// If <paramref name="lpMachineName"/> is <see langword="null"/>or an empty string, the function shuts down the local computer.
        /// </param>
        /// <param name="lpMessage">
        /// The message to be displayed in the shutdown dialog box.
        /// This parameter can be <see langword="null"/> if no message is required.
        /// Windows Server 2003 and Windows XP: This string is also stored as a comment in the event log entry.
        /// Windows Server 2003 and Windows XP with SP1: The string is limited to 3072 TCHARs.
        /// </param>
        /// <param name="dwTimeout">
        /// The length of time that the shutdown dialog box should be displayed, in seconds.
        /// While this dialog box is displayed, the shutdown can be stopped by the <see cref="AbortSystemShutdown"/> function.
        /// If dwTimeout is not zero, <see cref="InitiateSystemShutdown"/> displays a dialog box on the specified computer.
        /// The dialog box displays the name of the user who called the function,
        /// displays the message specified by the <paramref name="lpMessage"/> parameter, and prompts the user to log off.
        /// The dialog box beeps when it is created and remains on top of other windows in the system.
        /// The dialog box can be moved but not closed.
        /// A timer counts down the remaining time before a forced shutdown.
        /// If <paramref name="dwTimeout"/> is zero, the computer shuts down without displaying the dialog box,
        /// and the shutdown cannot be stopped by <see cref="AbortSystemShutdown"/>.
        /// Windows Server 2003 and Windows XP with SP1:
        /// The time-out value is limited to <see cref="MAX_SHUTDOWN_TIMEOUT"/> seconds.
        /// Windows Server 2003 and Windows XP with SP1:
        /// If the computer to be shut down is a Terminal Services server, the system displays a dialog box to all local
        /// and remote users warning them that shutdown has been initiated.
        /// The dialog box includes who requested the shutdown, the display message (see <paramref name="lpMessage"/>),
        /// and how much time there is until the server is shut down.
        /// </param>
        /// <param name="bForceAppsClosed">
        /// If this parameter is <see cref="TRUE"/>, applications with unsaved changes are to be forcibly closed.
        /// Note that this can result in data loss.
        /// If this parameter is <see cref="FALSE"/>, the system displays a dialog box instructing the user to close the applications.
        /// </param>
        /// <param name="bRebootAfterShutdown">
        /// If this parameter is <see cref="TRUE"/>, the computer is to restart immediately after shutting down.
        /// If this parameter is <see cref="FALSE"/>, the system flushes all caches to disk and safely powers down the system.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To shut down the local computer, the calling thread must have the SE_SHUTDOWN_NAME privilege.
        /// To shut down a remote computer, the calling thread must have the SE_REMOTE_SHUTDOWN_NAME privilege on the remote computer.
        /// By default, users can enable the SE_SHUTDOWN_NAME privilege on the computer they are logged onto,
        /// and administrators can enable the SE_REMOTE_SHUTDOWN_NAME privilege on remote computers.
        /// For more information, see Running with Special Privileges.
        /// Common reasons for failure include an invalid or inaccessible computer name or insufficient privilege.
        /// The error <see cref="ERROR_SHUTDOWN_IN_PROGRESS"/> is returned if a shutdown is already in progress on the specified computer.
        /// The error <see cref="ERROR_NOT_READY"/> can be returned if fast-user switching is enabled but no user is logged on.
        /// A non-zero return value does not mean the logoff was or will be successful.
        /// The shutdown is an asynchronous process, and it can occur long after the API call has returned, or not at all.
        /// Even if the timeout value is zero, the shutdown can still be aborted by applications, services or even the system.
        /// The non-zero return value indicates that the validation of the rights
        /// and parameters was successful and that the system accepted the shutdown request.
        /// When this function is called, the caller must specify whether or not applications with unsaved changes should be forcibly closed.
        /// If the caller chooses not to force these applications closed, and an application with unsaved changes is running on the console session,
        /// the shutdown will remain in progress until the user logged into the console session aborts the shutdown, saves changes,
        /// closes the application, or forces the application to close.
        /// During this period, the shutdown may not be aborted except by the console user, and another shutdown may not be initiated.
        /// Note that calling this function with the value of the <paramref name="bForceAppsClosed"/> parameter
        /// set to <see cref="TRUE"/> avoids this situation.
        /// Remember that doing this may result in loss of data.
        /// Windows Server 2003 and Windows XP: 
        /// If the computer is locked and the <paramref name="bForceAppsClosed"/> parameter is <see cref="FALSE"/>,
        /// the last error code is <see cref="ERROR_MACHINE_LOCKED"/>.
        /// If the system is not ready to handle the request, the last error code is <see cref="ERROR_NOT_READY"/>.
        /// The application should wait a short while and retry the call.
        /// For example, the system can be unready to initiate a shutdown, and return <see cref="ERROR_NOT_READY"/>,
        /// if the shutdown request comes at the same time a user tries to log onto the system.
        /// In this case, the application should wait a short while and retry the call.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitiateSystemShutdownW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitiateSystemShutdown([MarshalAs(UnmanagedType.LPWStr)][In] string lpMachineName,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpMessage, [In] DWORD dwTimeout, [In] BOOL bForceAppsClosed, [In] BOOL bRebootAfterShutdown);

        /// <summary>
        /// <para>
        /// Initiates a shutdown and optional restart of the specified computer, and optionally records the reason for the shutdown.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-initiatesystemshutdownexw"/>
        /// </para>
        /// </summary>
        /// <param name="lpMachineName">
        /// The network name of the computer to be shut down.
        /// If <paramref name="lpMachineName"/> is <see langword="null"/> or an empty string, the function shuts down the local computer.
        /// </param>
        /// <param name="lpMessage">
        /// The message to be displayed in the shutdown dialog box.
        /// This parameter can be <see langword="null"/> if no message is required.
        /// Windows Server 2003 and Windows XP: This string is also stored as a comment in the event log entry.
        /// Windows Server 2003 and Windows XP with SP1: The string is limited to 3072 TCHARs.
        /// </param>
        /// <param name="dwTimeout">
        /// The length of time that the shutdown dialog box should be displayed, in seconds.
        /// While this dialog box is displayed, shutdown can be stopped by the <see cref="AbortSystemShutdown"/> function.
        /// If <paramref name="dwTimeout"/> is not zero, <see cref="InitiateSystemShutdownEx"/> displays a dialog box on the specified computer.
        /// The dialog box displays the name of the user who called the function,
        /// displays the message specified by the <paramref name="lpMessage"/> parameter, and prompts the user to log off.
        /// The dialog box beeps when it is created and remains on top of other windows in the system.
        /// The dialog box can be moved but not closed. A timer counts down the remaining time before shutdown.
        /// If <paramref name="dwTimeout"/> is zero, the computer shuts down without displaying the dialog box,
        /// and the shutdown cannot be stopped by <see cref="AbortSystemShutdown"/>.
        /// Windows Server 2003 and Windows XP with SP1: The time-out value is limited to <see cref="MAX_SHUTDOWN_TIMEOUT"/> seconds.
        /// Windows Server 2003 and Windows XP with SP1: If the computer to be shut down is a Terminal Services server,
        /// the system displays a dialog box to all local and remote users warning them that shutdown has been initiated.
        /// The dialog box includes who requested the shutdown, the display message (see <paramref name="lpMessage"/>),
        /// and how much time there is until the server is shut down.
        /// </param>
        /// <param name="bForceAppsClosed">
        /// If this parameter is <see cref="TRUE"/>, applications with unsaved changes are to be forcibly closed.
        /// If this parameter is <see cref="FALSE"/>, the system displays a dialog box instructing the user to close the applications.
        /// </param>
        /// <param name="bRebootAfterShutdown">
        /// If this parameter is <see cref="TRUE"/>, the computer is to restart immediately after shutting down.
        /// If this parameter is <see cref="FALSE"/>, the system flushes all caches to disk and safely powers down the system.
        /// </param>
        /// <param name="dwReason">
        /// The reason for initiating the shutdown. This parameter must be one of the system shutdown reason codes.
        /// If this parameter is zero, the default is an undefined shutdown that is logged as "No title for this reason could be found".
        /// By default, it is also an unplanned shutdown.
        /// Depending on how the system is configured, an unplanned shutdown triggers the creation of a file
        /// that contains the system state information, which can delay shutdown.
        /// Therefore, do not use zero for this parameter.
        /// Windows XP: System state information is not saved during an unplanned system shutdown. The preceding text does not apply.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="FALSE"/>.
        /// If the function fails, the return value is <see cref="TRUE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To shut down the local computer, the calling thread must have the SE_SHUTDOWN_NAME privilege.
        /// To shut down a remote computer, the calling thread must have the SE_REMOTE_SHUTDOWN_NAME privilege on the remote computer.
        /// By default, users can enable the SE_SHUTDOWN_NAME privilege on the computer they are logged onto,
        /// and administrators can enable the SE_REMOTE_SHUTDOWN_NAME privilege on remote computers.
        /// For more information, see Running with Special Privileges.
        /// Common reasons for failure include an invalid or inaccessible computer name or insufficient privilege.
        /// The error <see cref="ERROR_SHUTDOWN_IN_PROGRESS"/> is returned if a shutdown is already in progress on the specified computer.
        /// The error <see cref="ERROR_NOT_READY"/> can be returned if fast-user switching is enabled but no user is logged on.
        /// A <see cref="TRUE"/> return value does not mean the logoff was or will be successful.
        /// The shutdown is an asynchronous process, and it can occur long after the API call has returned, or not at all.
        /// Even if the timeout value is zero, the shutdown can still be aborted by applications, services, or even the system.
        /// The non-zero return value indicates that the validation of the rights and parameters was successful
        /// and that the system accepted the shutdown request.
        /// When this function is called, the caller must specify whether or not applications with unsaved changes should be forcibly closed.
        /// If the caller chooses not to force these applications to close and an application with unsaved changes is running on the console session,
        /// the shutdown will remain in progress until the user logged into the console session aborts the shutdown,
        /// saves changes, closes the application, or forces the application to close.
        /// During this period the shutdown may not be aborted except by the console user, and another shutdown may not be initiated.
        /// Note that calling this function with the value of the <paramref name="bForceAppsClosed"/> parameter
        /// set to <see cref="TRUE"/> avoids this situation.
        /// Remember that doing this may result in loss of data.
        /// Windows Server 2003 and Windows XP:
        /// If the computer is locked and the <paramref name="bForceAppsClosed"/> parameter is <see cref="FALSE"/>,
        /// the last error code is <see cref="ERROR_MACHINE_LOCKED"/>.
        /// If the system is not ready to handle the request, the last error code is <see cref="ERROR_NOT_READY"/>.
        /// The application should wait a short while and retry the call.
        /// For example, the system can be unready to initiate a shutdown, and return <see cref="ERROR_NOT_READY"/>,
        /// if the shutdown request comes at the same time a user tries to log onto the system.
        /// In this case, the application should wait a short while and retry the call.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitiateSystemShutdownExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitiateSystemShutdownEx([MarshalAs(UnmanagedType.LPWStr)][In] string lpMachineName,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpMessage, [In] DWORD dwTimeout, [In] BOOL bForceAppsClosed,
            [In] BOOL bRebootAfterShutdown, [In] SystemShutdownReasonCodes dwReason);

        /// <summary>
        /// <para>
        /// The <see cref="IsTokenRestricted"/> function indicates whether a token contains a list of restricted security identifiers (SIDs).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-istokenrestricted"/>
        /// </para>
        /// </summary>
        /// <param name="TokenHandle">
        /// A handle to an access token to test.
        /// </param>
        /// <returns>
        /// If the token contains a list of restricting SIDs, the return value is <see cref="TRUE"/>.
        /// If the token does not contain a list of restricting SIDs, the return value is <see cref="FALSE"/>.
        /// If an error occurs, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateRestrictedToken"/> function can restrict a token by disabling SIDs,
        /// deleting privileges, and specifying a list of restricting SIDs.
        /// The <see cref="IsTokenRestricted"/> function checks only for the list of restricting SIDs.
        /// If a token does not have any restricting SIDs, <see cref="IsTokenRestricted"/> returns <see cref="FALSE"/>,
        /// even though the token was created by a call to <see cref="CreateRestrictedToken"/>.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsTokenRestricted", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsTokenRestricted([In] HANDLE TokenHandle);

        /// <summary>
        /// <para>
        /// The <see cref="LogonUser"/> function attempts to log a user on to the local computer.
        /// The local computer is the computer from which LogonUser was called.
        /// You cannot use <see cref="LogonUser"/> to log on to a remote computer.
        /// You specify the user with a user name and domain and authenticate the user with a plaintext password.
        /// If the function succeeds, you receive a handle to a token that represents the logged-on user.
        /// You can then use this token handle to impersonate the specified user or, in most cases,
        /// to create a process that runs in the context of the specified user.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-logonuserw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszUsername">
        /// A pointer to a null-terminated string that specifies the name of the user.
        /// This is the name of the user account to log on to.
        /// If you use the user principal name (UPN) format, User@DNSDomainName, the <paramref name="lpszDomain"/> parameter must be <see langword="null"/>.
        /// </param>
        /// <param name="lpszDomain">
        /// A pointer to a null-terminated string that specifies the name of the domain or server
        /// whose account database contains the <paramref name="lpszUsername"/> account.
        /// If this parameter is <see langword="null"/>, the user name must be specified in UPN format.
        /// If this parameter is ".", the function validates the account by using only the local account database.
        /// </param>
        /// <param name="lpszPassword">
        /// A pointer to a null-terminated string that specifies the plaintext password for the user account specified by <paramref name="lpszUsername"/>.
        /// When you have finished using the password, clear the password from memory by calling the <see cref="SecureZeroMemory"/> function.
        /// For more information about protecting passwords, see Handling Passwords.
        /// </param>
        /// <param name="dwLogonType">
        /// The type of logon operation to perform. This parameter can be one of the following values, defined in Winbase.h.
        /// <see cref="LOGON32_LOGON_BATCH"/>:
        /// This logon type is intended for batch servers, where processes may be executing on behalf of a user without their direct intervention.
        /// This type is also for higher performance servers that process many plaintext authentication attempts at a time, such as mail or web servers.
        /// <see cref="LOGON32_LOGON_INTERACTIVE"/>:
        /// This logon type is intended for users who will be interactively using the computer,
        /// such as a user being logged on by a terminal server,remote shell, or similar process.
        /// This logon type has the additional expense of caching logon information for disconnected operations;
        /// therefore, it is inappropriate for some client/server applications, such as a mail server.
        /// <see cref="LOGON32_LOGON_NETWORK"/>:
        /// This logon type is intended for high performance servers to authenticate plaintext passwords.
        /// The <see cref="LogonUser"/> function does not cache credentials for this logon type.
        /// <see cref="LOGON32_LOGON_NETWORK_CLEARTEXT"/>:
        /// This logon type preserves the name and password in the authentication package,
        /// which allows the server to make connections to other network servers while impersonating the client.
        /// A server can accept plaintext credentials from a client, call <see cref="LogonUser"/>,
        /// verify that the user can access the system across the network, and still communicate with other servers.
        /// <see cref="LOGON32_LOGON_NEW_CREDENTIALS"/>:
        /// This logon type allows the caller to clone its current token and specify new credentials for outbound connections.
        /// The new logon session has the same local identifier but uses different credentials for other network connections.
        /// This logon type is supported only by the <see cref="LOGON32_PROVIDER_WINNT50"/> logon provider.
        /// <see cref="LOGON32_LOGON_SERVICE"/>:
        /// Indicates a service-type logon. The account provided must have the service privilege enabled.
        /// <see cref="LOGON32_LOGON_UNLOCK"/>:
        /// GINAs are no longer supported.
        /// Windows Server 2003 and Windows XP:
        /// This logon type is for GINA DLLs that log on users who will be interactively using the computer.
        /// This logon type can generate a unique audit record that shows when the workstation was unlocked.
        /// </param>
        /// <param name="dwLogonProvider">
        /// Specifies the logon provider. This parameter can be one of the following values.
        /// <see cref="LOGON32_PROVIDER_DEFAULT"/>:
        /// Use the standard logon provider for the system.
        /// The default security provider is negotiate, unless you pass <see langword="null"/> for the domain name and the user name is not in UPN format.
        /// In this case, the default provider is NTLM.
        /// <see cref="LOGON32_PROVIDER_WINNT50"/>:
        /// Use the negotiate logon provider.
        /// <see cref="LOGON32_PROVIDER_WINNT40"/>:
        /// Use the NTLM logon provider.
        /// </param>
        /// <param name="phToken">
        /// A pointer to a handle variable that receives a handle to a token that represents the specified user.
        /// You can use the returned handle in calls to the <see cref="ImpersonateLoggedOnUser"/> function.
        /// In most cases, the returned handle is a primary token that you can use in calls to the <see cref="CreateProcessAsUser"/> function.
        /// However, if you specify the <see cref="LOGON32_LOGON_NETWORK"/> flag, <see cref="LogonUser"/> returns an impersonation token
        /// that you cannot use in <see cref="CreateProcessAsUser"/> unless you call <see cref="DuplicateTokenEx"/> to convert it to a primary token.
        /// When you no longer need this handle, close it by calling the <see cref="CloseHandle"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="LOGON32_LOGON_NETWORK"/> logon type is fastest, but it has the following limitations:
        /// The function returns an impersonation token, not a primary token.
        /// You cannot use this token directly in the <see cref="CreateProcessAsUser"/> function.
        /// However, you can call the <see cref="DuplicateTokenEx"/> function to convert the token to a primary token,
        /// and then use it in <see cref="CreateProcessAsUser"/>.
        /// If you convert the token to a primary token and use it in <see cref="CreateProcessAsUser"/> to start a process,
        /// the new process cannot access other network resources, such as remote servers or printers, through the redirector.
        /// An exception is that if the network resource is not access controlled, then the new process will be able to access it.
        /// The SE_TCB_NAME privilege is not required for this function unless you are logging onto a Passport account.
        /// The account specified by <paramref name="lpszUsername"/>, must have the necessary account rights.
        /// For example, to log on a user with the <see cref="LOGON32_LOGON_INTERACTIVE"/> flag,
        /// the user (or a group to which the user belongs) must have the SE_INTERACTIVE_LOGON_NAME account right.
        /// For a list of the account rights that affect the various logon operations, see Account Rights Constants.
        /// A user is considered logged on if at least one token exists.
        /// If you call <see cref="CreateProcessAsUser"/> and then close the token,
        /// the system considers the user as still logged on until the process (and all child processes) have ended.
        /// If the <see cref="LogonUser"/> call is successful, the system notifies network providers that the logon occurred
        /// by calling the provider's NPLogonNotify entry-point function.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "LogonUserW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LogonUser([MarshalAs(UnmanagedType.LPWStr)][In] string lpszUsername,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpszDomain, [MarshalAs(UnmanagedType.LPWStr)][In] string lpszPassword,
            [In] LogonTypes dwLogonType, [In] LoginProviders dwLogonProvider, [Out] out HANDLE phToken);

        /// <summary>
        /// <para>
        /// The LookupPrivilegeName function retrieves the name that corresponds to the privilege
        /// represented on a specific system by a specified locally unique identifier (LUID).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-lookupprivilegenamew"/>
        /// </para>
        /// </summary>
        /// <param name="lpSystemName">
        /// A pointer to a null-terminated string that specifies the name of the system on which the privilege name is retrieved.
        /// If a null string is specified, the function attempts to find the privilege name on the local system.
        /// </param>
        /// <param name="lpLuid">
        /// A pointer to the LUID by which the privilege is known on the target system.
        /// </param>
        /// <param name="lpName">
        /// A pointer to a buffer that receives a null-terminated string that represents the privilege name.
        /// For example, this string could be "SeSecurityPrivilege".
        /// </param>
        /// <param name="cchName">
        /// A pointer to a variable that specifies the size, in a TCHAR value, of the <paramref name="lpName"/> buffer.
        /// When the function returns, this parameter contains the length of the privilege name, not including the terminating null character.
        /// If the buffer pointed to by the <paramref name="lpName"/> parameter is too small, this variable contains the required size.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="LookupPrivilegeName"/> function supports only the privileges specified in the Defined Privileges section of Winnt.h.
        /// For a list of values, see Privilege Constants.
        /// Note
        /// The winbase.h header defines <see cref="LookupPrivilegeName"/> as an alias which automatically selects the ANSI or Unicode version
        /// of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to
        /// mismatches that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "LookupPrivilegeNameW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LookupPrivilegeName([MarshalAs(UnmanagedType.LPWStr)][In] string lpSystemName, [In] in LUID lpLuid,
            [In] IntPtr lpName, [In][Out] ref DWORD cchName);

        /// <summary>
        /// <para>
        /// The <see cref="OpenProcessToken"/> function opens the access token associated with a process.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-openprocesstoken"/>
        /// </para>
        /// </summary>
        /// <param name="ProcessHandle">
        /// A handle to the process whose access token is opened.
        /// The process must have the <see cref="PROCESS_QUERY_INFORMATION"/> access permission.
        /// </param>
        /// <param name="DesiredAccess">
        /// Specifies an access mask that specifies the requested types of access to the access token.
        /// These requested access types are compared with the discretionary access control list (DACL) of the token
        /// to determine which accesses are granted or denied.
        /// For a list of access rights for access tokens, see Access Rights for Access-Token Objects.
        /// </param>
        /// <param name="TokenHandle">
        /// A pointer to a handle that identifies the newly opened access token when the function returns.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Close the access token handle returned through the <paramref name="TokenHandle"/> parameter by calling <see cref="CloseHandle"/>.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenProcessToken", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL OpenProcessToken([In] HANDLE ProcessHandle, [In] ACCESS_MASK DesiredAccess, [Out] out HANDLE TokenHandle);

        /// <summary>
        /// <para>
        /// The <see cref="OpenThreadToken"/> function opens the access token associated with a thread.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-openthreadtoken"/>
        /// </para>
        /// </summary>
        /// <param name="ThreadHandle">
        /// A handle to the thread whose access token is opened.
        /// </param>
        /// <param name="DesiredAccess">
        /// Specifies an access mask that specifies the requested types of access to the access token.
        /// These requested access types are reconciled against the token's discretionary access control list (DACL) to determine
        /// which accesses are granted or denied.
        /// For a list of access rights for access tokens, see Access Rights for Access-Token Objects.
        /// </param>
        /// <param name="OpenAsSelf">
        /// <see cref="TRUE"/> if the access check is to be made against the process-level security context.
        /// <see cref="FALSE"/> if the access check is to be made against
        /// the current security context of the thread calling the <see cref="OpenThreadToken"/> function.
        /// The <paramref name="OpenAsSelf"/> parameter allows the caller of this function to open the access token of a specified thread
        /// when the caller is impersonating a token at <see cref="SecurityIdentification"/> level.
        /// Without this parameter, the calling thread cannot open the access token on the specified thread
        /// because it is impossible to open executive-level objects by using the <see cref="SecurityIdentification"/> impersonation level.
        /// </param>
        /// <param name="TokenHandle">
        /// A pointer to a variable that receives the handle to the newly opened access token.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the token has the anonymous impersonation level, the token will not be opened
        /// and <see cref="OpenThreadToken"/> sets <see cref="ERROR_CANT_OPEN_ANONYMOUS"/> as the error.
        /// </returns>
        /// <remarks>
        /// Tokens with the anonymous impersonation level cannot be opened.
        /// Close the access token handle returned through the <paramref name="TokenHandle"/> parameter by calling <see cref="CloseHandle"/>.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenThreadToken", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL OpenThreadToken([In] HANDLE ThreadHandle, [In] ACCESS_MASK DesiredAccess, [In] BOOL OpenAsSelf, [Out] out HANDLE TokenHandle);

        /// <summary>
        /// <para>
        /// The <see cref="RevertToSelf"/> function terminates the impersonation of a client application.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-reverttoself"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A process should call the <see cref="RevertToSelf"/> function after finishing any impersonation begun
        /// by using the <see cref="DdeImpersonateClient"/>, <see cref="ImpersonateDdeClientWindow"/>, <see cref="ImpersonateLoggedOnUser"/>,
        /// <see cref="ImpersonateNamedPipeClient"/>, <see cref="ImpersonateSelf"/>, <see cref="ImpersonateAnonymousToken"/>
        /// or <see cref="SetThreadToken"/> function.
        /// An RPC server that used the <see cref="RpcImpersonateClient"/> function to impersonate a client must call
        /// the <see cref="RpcRevertToSelf"/> or <see cref="RpcRevertToSelfEx"/> to end the impersonation.
        /// If <see cref="RevertToSelf"/> fails, your application continues to run in the context of the client, which is not appropriate.
        /// You should shut down the process if <see cref="RevertToSelf"/> fails.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RevertToSelf", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RevertToSelf();

        /// <summary>
        /// <para>
        /// The <see cref="SetSecurityDescriptorControl"/> function sets the control bits of a security descriptor.
        /// The function can set only the control bits that relate to automatic inheritance of ACEs.
        /// To set the other control bits of a security descriptor, use the functions,
        /// such as <see cref="SetSecurityDescriptorDacl"/>, for modifying the components of a security descriptor.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-setsecuritydescriptorcontrol"/>
        /// </para>
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure whose control and revision information are set.
        /// </param>
        /// <param name="ControlBitsOfInterest">
        /// A <see cref="SECURITY_DESCRIPTOR_CONTROL"/> mask that indicates the control bits to set.
        /// </param>
        /// <param name="ControlBitsToSet">
        /// A <see cref="SECURITY_DESCRIPTOR_CONTROL"/> mask that indicates the new values
        /// for the control bits specified by the <paramref name="ControlBitsToSet"/> mask.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="SetSecurityDescriptorControl"/> function specifies the control bit or bits to modify, and whether the bits are on or off.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSecurityDescriptorControl", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetSecurityDescriptorControl([In] PSECURITY_DESCRIPTOR pSecurityDescriptor,
            [In] SECURITY_DESCRIPTOR_CONTROL ControlBitsOfInterest, [In] SECURITY_DESCRIPTOR_CONTROL ControlBitsToSet);

        /// <summary>
        /// <para>
        /// The <see cref="SetSecurityDescriptorDacl"/> function sets information in a discretionary access control list (DACL).
        /// If a DACL is already present in the security descriptor, the DACL is replaced.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-setsecuritydescriptordacl"/>
        /// </para>
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to the <see cref="SECURITY_DESCRIPTOR"/> structure to which the function adds the DACL.
        /// This security descriptor must be in absolute format,
        /// meaning that its members must be pointers to other structures, rather than offsets to contiguous data.
        /// </param>
        /// <param name="bDaclPresent">
        /// A flag that indicates the presence of a DACL in the security descriptor.
        /// If this parameter is <see cref="TRUE"/>, the function sets the <see cref="SE_DACL_PRESENT"/> flag
        /// in the <see cref="SECURITY_DESCRIPTOR_CONTROL"/> structure and uses the values
        /// in the <paramref name="pDacl"/> and <paramref name="bDaclDefaulted"/> parameters.
        /// If this parameter is <see cref="FALSE"/>, the function clears the <see cref="SE_DACL_PRESENT"/> flag,
        /// and <paramref name="pDacl"/> and <paramref name="bDaclDefaulted"/> are ignored.
        /// </param>
        /// <param name="pDacl">
        /// A pointer to an <see cref="ACL"/> structure that specifies the DACL for the security descriptor.
        /// If this parameter is <see cref="NullRef{ACL}"/>, a NULL DACL is assigned to the security descriptor, which allows all access to the object.
        /// The DACL is referenced by, not copied into, the security descriptor.
        /// </param>
        /// <param name="bDaclDefaulted">
        /// A flag that indicates the source of the DACL.
        /// If this flag is <see cref="TRUE"/>, the DACL has been retrieved by some default mechanism.
        /// If <see cref="FALSE"/>, the DACL has been explicitly specified by a user.
        /// The function stores this value in the <see cref="SE_DACL_DEFAULTED"/> flag of the <see cref="SECURITY_DESCRIPTOR_CONTROL"/> structure.
        /// If this parameter is not specified, the <see cref="SE_DACL_DEFAULTED"/> flag is cleared.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// There is an important difference between an empty and a nonexistent DACL.
        /// When a DACL is empty, it contains no access control entries (ACEs); therefore, no access rights are explicitly granted.
        /// As a result, access to the object is implicitly denied.
        /// When an object has no DACL (when the <paramref name="pDacl"/> parameter is <see cref="NullRef{ACL}"/>),
        /// no protection is assigned to the object, and all access requests are granted.
        /// To help maintain security, restrict access by using a DACL.
        /// There are three possible outcomes in different configurations
        /// of the <paramref name="bDaclPresent"/> flag and the <paramref name="pDacl"/> parameter:
        /// When the <paramref name="pDacl"/> parameter points to a DACL and the <paramref name="bDaclPresent"/> flag is <see cref="TRUE"/>,
        /// a DACL is specified and it must contain access-allowed ACEs to allow access to the object.
        /// When the <paramref name="pDacl"/> parameter does not point to a DACL and the <paramref name="bDaclPresent"/> flag is <see cref="TRUE"/>,
        /// a NULL DACL is specified. All access is allowed.
        /// You should not use a NULL DACL with an object because any user can change the DACL and owner of the security descriptor.
        /// This will interfere with use of the object.
        /// When the <paramref name="pDacl"/> parameter does not point to a DACL and the <paramref name="bDaclPresent"/> flag is <see cref="FALSE"/>,
        /// a DACL can be provided for the object through an inheritance or default mechanism.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSecurityDescriptorDacl", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetSecurityDescriptorDacl([In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] BOOL bDaclPresent,
            [In] in ACL pDacl, [In] BOOL bDaclDefaulted);

        /// <summary>
        /// <para>
        /// The <see cref="SetSecurityDescriptorGroup"/> function sets the primary group information of an absolute-format security descriptor,
        /// replacing any primary group information already present in the security descriptor.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-setsecuritydescriptorgroup"/>
        /// </para>
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to the <see cref="SECURITY_DESCRIPTOR"/> structure whose primary group is set by this function.
        /// The function replaces any existing primary group with the new primary group.
        /// </param>
        /// <param name="pGroup">
        /// A pointer to a <see cref="SID"/> structure for the security descriptor's new primary group.
        /// The <see cref="SID"/> structure is referenced by, not copied into, the security descriptor.
        /// If this parameter is <see cref="NULL"/>, the function clears the security descriptor's primary group information.
        /// This marks the security descriptor as having no primary group.
        /// </param>
        /// <param name="bGroupDefaulted">
        /// Indicates whether the primary group information was derived from a default mechanism.
        /// If this value is <see cref="TRUE"/>, it is default information, and the function stores
        /// this value as the <see cref="SE_GROUP_DEFAULTED"/> flag in the <see cref="SECURITY_DESCRIPTOR_CONTROL"/> structure.
        /// If this parameter is <see cref="FALSE"/>, the <see cref="SE_GROUP_DEFAULTED"/> flag is cleared.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSecurityDescriptorGroup", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetSecurityDescriptorGroup([In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] PSID pGroup, [In] BOOL bGroupDefaulted);

        /// <summary>
        /// <para>
        /// The <see cref="SetSecurityDescriptorOwner"/> function sets the owner information of an absolute-format security descriptor.
        /// It replaces any owner information already present in the security descriptor.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-setsecuritydescriptorowner"/>
        /// </para>
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to the <see cref="SECURITY_DESCRIPTOR"/> structure whose owner is set by this function.
        /// The function replaces any existing owner with the new owner.
        /// </param>
        /// <param name="pOwner">
        /// A pointer to a <see cref="SID"/> structure for the security descriptor's new primary owner.
        /// The <see cref="SID"/> structure is referenced by, not copied into, the security descriptor.
        /// If this parameter is <see cref="NULL"/>, the function clears the security descriptor's owner information.
        /// This marks the security descriptor as having no owner.
        /// </param>
        /// <param name="bOwnerDefaulted">
        /// Indicates whether the owner information is derived from a default mechanism.
        /// If this value is <see cref="TRUE"/>, it is default information.
        /// The function stores this value as the <see cref="SE_OWNER_DEFAULTED"/> flag in the <see cref="SECURITY_DESCRIPTOR_CONTROL"/> structure.
        /// If this parameter is <see cref="FALSE"/>, the <see cref="SE_OWNER_DEFAULTED"/> flag is cleared.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSecurityDescriptorOwner", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetSecurityDescriptorOwner([In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] PSID pOwner, [In] BOOL bOwnerDefaulted);

        /// <summary>
        /// <para>
        /// The <see cref="SetSecurityDescriptorSacl"/> function sets information in a system access control list (SACL).
        /// If there is already a SACL present in the security descriptor, it is replaced.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-setsecuritydescriptorsacl"/>
        /// </para>
        /// </summary>
        /// <param name="pSecurityDescriptor">
        /// A pointer to the <see cref="SECURITY_DESCRIPTOR"/> structure to which the function adds the SACL.
        /// This security descriptor must be in absolute format, meaning that its members must be pointers to other structures,
        /// rather than offsets to contiguous data.
        /// </param>
        /// <param name="bSaclPresent">
        /// Indicates the presence of a SACL in the security descriptor.
        /// If this parameter is <see cref="TRUE"/>, the function sets the <see cref="SE_SACL_PRESENT"/> flag
        /// in the <see cref="SECURITY_DESCRIPTOR_CONTROL"/> structure and uses the values
        /// in the <paramref name="pSacl"/> and <paramref name="bSaclDefaulted"/> parameters.
        /// If it is <see cref="FALSE"/>, the function does not set the <see cref="SE_SACL_PRESENT"/> flag,
        /// and <paramref name="pSacl"/> and <paramref name="bSaclDefaulted"/> are ignored.
        /// </param>
        /// <param name="pSacl">
        /// A pointer to an <see cref="ACL"/> structure that specifies the SACL for the security descriptor.
        /// If this parameter is <see cref="NullRef{ACL}"/>, a NULL SACL is assigned to the security descriptor.
        /// The SACL is referenced by, not copied into, the security descriptor.
        /// </param>
        /// <param name="bSaclDefaulted">
        /// Indicates the source of the SACL.
        /// If this flag is <see cref="TRUE"/>, the SACL has been retrieved by some default mechanism.
        /// If it is <see cref="FALSE"/>, the SACL has been explicitly specified by a user.
        /// The function stores this value in the <see cref="SE_SACL_DEFAULTED"/> flag of the <see cref="SECURITY_DESCRIPTOR_CONTROL"/> structure.
        /// If this parameter is not specified, the <see cref="SE_SACL_DEFAULTED"/> flag is cleared.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSecurityDescriptorSacl", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetSecurityDescriptorSacl([In] PSECURITY_DESCRIPTOR pSecurityDescriptor,
            [In] BOOL bSaclPresent, [In] in ACL pSacl, [In] BOOL bSaclDefaulted);

        /// <summary>
        /// The <see cref="SetTokenInformation"/> function sets various types of information for a specified access token. 
        /// The information that this function sets replaces existing information.
        /// The calling process must have appropriate access rights to set the information.
        /// <para>
        /// From : https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-settokeninformation
        /// </para>
        /// </summary>
        /// <param name="TokenHandle">
        /// A handle to the access token for which information is to be set.
        /// </param>
        /// <param name="TokenInformationClass">
        /// A value from the<see cref="TOKEN_INFORMATION_CLASS"/> enumerated type that identifies the type of information the function sets. 
        /// The valid values from <see cref="TOKEN_INFORMATION_CLASS"/> are described in the <paramref name="TokenInformation"/> parameter.
        /// </param>
        /// <param name="TokenInformation">
        /// A pointer to a buffer that contains the information set in the access token.
        /// The structure of this buffer depends on the type of information specified by the TokenInformationClass parameter.
        /// </param>
        /// <param name="TokenInformationLength">
        /// Specifies the length, in bytes, of the buffer pointed to by <paramref name="TokenInformation"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call<see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To set privilege information, an application can call the <see cref="AdjustTokenPrivileges"/> function.
        /// To set a token's groups, an application can call the <see cref="AdjustTokenGroups"/> function.
        /// Token-type information can be set only when an access token is created.
        /// </remarks>

        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetTokenInformation", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetTokenInformation([In] HANDLE TokenHandle, [In] TOKEN_INFORMATION_CLASS TokenInformationClass,
            [In] LPVOID TokenInformation, [In] DWORD TokenInformationLength);
    }
}

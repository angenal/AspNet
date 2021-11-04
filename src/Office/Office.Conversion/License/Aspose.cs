/*
in ASP.Net Projects you must disable shadow copy
To disable shadow copy add following setting in web.config file:

<configuration>
  <system.web>
    <hostingEnvironment shadowCopyBinAssemblies="false" />
  </system.web>
</configuration>
*/

using System;
using System.IO;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(Office.Conversion.Licenses), "Autoload")]
namespace Office.Conversion
{
    /// <summary>
    /// Aspose License Tools.
    /// Cracked, No Need To Install License.
    /// </summary>
    public sealed class Licenses
    {
        /// <summary>
        /// GroupDocs.Conversion - Aspose GroupDocs.Total Product Family - Enterprise Version license - Excel,Word,PowerPoint,Pdf.
        /// </summary>
        //const string GroupDocsLicense_19_6 = "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiPz4NCjxMaWNlbnNlPg0KICAgIDxEYXRhPg0KICAgICAgICA8TGljZW5zZWRUbz5MaWNlbnNlZTwvTGljZW5zZWRUbz4NCiAgICAgICAgPEVtYWlsVG8+bGljZW5zZWVAZW1haWwuY29tPC9FbWFpbFRvPg0KICAgICAgICA8TGljZW5zZVR5cGU+RGV2ZWxvcGVyIE9FTTwvTGljZW5zZVR5cGU+DQogICAgICAgIDxMaWNlbnNlTm90ZT5MaW1pdGVkIHRvIDEwMDAgZGV2ZWxvcGVyLCB1bmxpbWl0ZWQgcGh5c2ljYWwgbG9jYXRpb25zPC9MaWNlbnNlTm90ZT4NCiAgICAgICAgPE9yZGVySUQ+Nzg0Mzc4NTc3ODU8L09yZGVySUQ+DQogICAgICAgIDxVc2VySUQ+MTE5Nzg5MjQzNzk8L1VzZXJJRD4NCiAgICAgICAgPE9FTT5UaGlzIGlzIGEgcmVkaXN0cmlidXRhYmxlIGxpY2Vuc2U8L09FTT4NCiAgICAgICAgPFByb2R1Y3RzPg0KICAgICAgICAgICAgPFByb2R1Y3Q+R3JvdXBEb2NzLlRvdGFsIFByb2R1Y3QgRmFtaWx5PC9Qcm9kdWN0Pg0KICAgICAgICA8L1Byb2R1Y3RzPg0KICAgICAgICA8RWRpdGlvblR5cGU+RW50ZXJwcmlzZTwvRWRpdGlvblR5cGU+DQogICAgICAgIDxTZXJpYWxOdW1iZXI+e0YyQjk3MDQ1LTFCMjktNEIzRi1CRDUzLTYwMUVGRkExNUFBOX08L1NlcmlhbE51bWJlcj4NCiAgICAgICAgPFN1YnNjcmlwdGlvbkV4cGlyeT4yMDk5MTIzMTwvU3Vic2NyaXB0aW9uRXhwaXJ5Pg0KICAgICAgICA8TGljZW5zZVZlcnNpb24+MTcuMDwvTGljZW5zZVZlcnNpb24+DQogICAgPC9EYXRhPg0KICAgIDxTaWduYXR1cmU+UVhOd2IzTmxMbFJ2ZEdGc0lGQnliMlIxWTNRZ1JtRnRhV3g1PC9TaWduYXR1cmU+DQo8L0xpY2Vuc2U+";
        const string GroupDocsLicense_19_11 = "PExpY2Vuc2U+DQogIDxEYXRhPg0KICAgIDxMaWNlbnNlZFRvPmlyRGV2ZWxvcGVycy5jb208L0xpY2Vuc2VkVG8+DQogICAgPEVtYWlsVG8+aW5mb0BpckRldmVsb3BlcnMuY29tPC9FbWFpbFRvPg0KICAgIDxMaWNlbnNlVHlwZT5TaXRlIE9FTTwvTGljZW5zZVR5cGU+DQogICAgPExpY2Vuc2VOb3RlPkxpbWl0ZWQgdG8gMTAwMCBkZXZlbG9wZXJzLCB1bmxpbWl0ZWQgcGh5c2ljYWwgbG9jYXRpb25zPC9MaWNlbnNlTm90ZT4NCiAgICA8T3JkZXJJRD4zNjk4MTUwODU0ODI8L09yZGVySUQ+DQogICAgPFVzZXJJRD42NTQxMzI0ODY8L1VzZXJJRD4NCiAgICA8T0VNPlRoaXMgaXMgYSByZWRpc3RyaWJ1dGFibGUgbGljZW5zZTwvT0VNPg0KICAgIDxQcm9kdWN0cz4NCiAgICAgIDxQcm9kdWN0Pkdyb3VwRG9jcy5Ub3RhbCBmb3IgLk5FVDwvUHJvZHVjdD4NCiAgICA8L1Byb2R1Y3RzPg0KICAgIDxFZGl0aW9uVHlwZT5FbnRlcnByaXNlPC9FZGl0aW9uVHlwZT4NCiAgICA8U2VyaWFsTnVtYmVyPjg4Yjc1Yzk5LTIyYTEtNGU1NS05NDE0LTA1M2VhMzAyMmRhNzwvU2VyaWFsTnVtYmVyPg0KICAgIDxTdWJzY3JpcHRpb25FeHBpcnk+MjA5OTEyMTU8L1N1YnNjcmlwdGlvbkV4cGlyeT4NCiAgICA8TGljZW5zZUV4cGlyeT4yMDk5MDExNDwvTGljZW5zZUV4cGlyeT4NCiAgICA8TGljZW5zZVZlcnNpb24+My4wPC9MaWNlbnNlVmVyc2lvbj4NCiAgPC9EYXRhPg0KICA8U2lnbmF0dXJlPkxrWnRmMXZ3WUF2MVA2c2JYRU00Z3Jod0FCTVFvdkdaWjFLZi9YOGlyV0Yzdm1WcW8vVzdLaWZ6T1dBNEErZVRmUWZRWmcvTHkxVGgzMTFqNzZZWm9CM0IrQ0tKbjFYZlR6cDRhL1hYUHgvdlNPNzYwbHp5SVRpck5lQXA1NE90VVRwOHRDdmhNbVJnS3luaE1oU25qdjAwdDNZMTlXRFpoUGJ4Qi8wbFhkMD08L1NpZ25hdHVyZT4NCjwvTGljZW5zZT4=";

        static void Load()
        {
            new GroupDocs.Conversion.License().SetLicense(GetLicense(GroupDocsLicense_19_11));
        }

        #region Autoload
        /// <summary>
        /// Autoload product licenses.
        /// </summary>
        public static void Autoload(Action beforeAction = null, Action afterAction = null)
        {
            if (loaded) return;
            lock (_lock)
            {
                if (loaded) return;
                beforeAction?.Invoke(); Load(); afterAction?.Invoke();
                loaded = true;
            }
        }
        /// <summary>
        /// Read from base64String license.
        /// </summary>
        static Stream GetLicense(string base64String) => new MemoryStream(Convert.FromBase64String(base64String));
        static readonly object _lock = new object();
        static bool loaded = false;
        Licenses() { }
        #endregion
    }
}

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
using System.Reflection;
using System.Web;

#region Aspese has been cracked. Only Aspose.Email needs to install license manually.

[assembly: PreApplicationStartMethod(typeof(Aspose.Licenses), "Autoload")]
namespace Aspose
{
    /// <summary>
    /// Aspose License Tools.
    /// Cracked, No Need To Install License.
    /// </summary>
    public sealed class Licenses
    {
        /// <summary>
        /// Aspose.Cells license - Excel.
        /// </summary>
        const string CellsLicense_18_11 = "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiPz48TGljZW5zZT48RGF0YT48UHJvZHVjdHM+PFByb2R1Y3Q+QXNwb3NlLlRvdGFsPC9Qcm9kdWN0PjwvUHJvZHVjdHM+PEVkaXRpb25UeXBlPlByb2Zlc3Npb25hbDwvRWRpdGlvblR5cGU+PFNlcmlhbE51bWJlcj4wOTYzNmFkOC1kMzAzLTQ2NzAtYjY5NC02Y2JkOTEyOTZjNDk8L1NlcmlhbE51bWJlcj48U3Vic2NyaXB0aW9uRXhwaXJ5Pjk5OTkxMjMxPC9TdWJzY3JpcHRpb25FeHBpcnk+PExpY2Vuc2VFeHBpcnk+OTk5OTEyMzE8L0xpY2Vuc2VFeHBpcnk+PC9EYXRhPjxTaWduYXR1cmU+b2lmZE93cTBkeUZKZTNncGNsVWZIZU1OUmVFY0t3TkZQZi9EM3pwUmRxSWtoaHJoZE9xdEwwSzVuTDFYWStqVEZHdXkzWWNTSFR5bG11VWxUNHd5bVA5RGUwcjBjaDVGVVB2anpsUEdhUkhQTU10T1FVTlV6bGNZRUN0Q2QrZURWaTZJS282bW1UTmtaMDc2UVlzZzZwOU0ybmJkS1FmRGRWazBNRkphRWNzPTwvU2lnbmF0dXJlPjwvTGljZW5zZT4=";
        /// <summary>
        /// Aspose.Words license - Word.
        /// </summary>
        //const string WordsLicense_18_11 = "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiPz48TGljZW5zZT48RGF0YT48UHJvZHVjdHM+PFByb2R1Y3Q+QXNwb3NlLlRvdGFsPC9Qcm9kdWN0PjwvUHJvZHVjdHM+PEVkaXRpb25UeXBlPlByb2Zlc3Npb25hbDwvRWRpdGlvblR5cGU+PFNlcmlhbE51bWJlcj5iYmExNTgzYi1kZDkyLTRiNWYtYWU1NC02YTFhZTBhZDU0Yjc8L1NlcmlhbE51bWJlcj48U3Vic2NyaXB0aW9uRXhwaXJ5Pjk5OTkxMjMxPC9TdWJzY3JpcHRpb25FeHBpcnk+PExpY2Vuc2VFeHBpcnk+OTk5OTEyMzE8L0xpY2Vuc2VFeHBpcnk+PC9EYXRhPjxTaWduYXR1cmU+SkpFUGNwdks0QWNzd1V1YWtLV3ZQR2g4QnBRTkl1NHcvY1U3VTZiVW9qancrTjg5SkViNkozZ2UvQURaNWRmVFcvOUpvQjFLdFBwenYzY1MzQjdFMjgwUm9za1NWVnJqMUo2dkpXd3BBeTNXMEdXVXV5SzNOdWZDVng3ejcwTEZTcUUyWFpNZVpXbGo5ZVVlcTNhN0JscndsTWNqWGRwRG84bmFkL2dUbm9BPTwvU2lnbmF0dXJlPjwvTGljZW5zZT4=";
        /// <summary>
        /// Aspose.Slides license - PowerPoint.
        /// </summary>
        //const string SlidesLicense_18_10 = "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiID8+CjxMaWNlbnNlPgogIDxEYXRhPgogICAgPExpY2Vuc2VkVG8+QXNwb3NlIFNjb3RsYW5kIFRlYW08L0xpY2Vuc2VkVG8+CiAgICA8RW1haWxUbz5iaWxseS5sdW5kaWVAYXNwb3NlLmNvbTwvRW1haWxUbz4KICAgIDxMaWNlbnNlVHlwZT5EZXZlbG9wZXIgT0VNPC9MaWNlbnNlVHlwZT4KICAgIDxMaWNlbnNlTm90ZT5MaW1pdGVkIHRvIDEgZGV2ZWxvcGVyLCB1bmxpbWl0ZWQgcGh5c2ljYWwgbG9jYXRpb25zPC9MaWNlbnNlTm90ZT4KICAgIDxPcmRlcklEPjE0MDQwODA1MjMyNDwvT3JkZXJJRD4KICAgIDxVc2VySUQ+OTQyMzY8L1VzZXJJRD4KICAgIDxPRU0+VGhpcyBpcyBhIHJlZGlzdHJpYnV0YWJsZSBsaWNlbnNlPC9PRU0+CiAgICA8UHJvZHVjdHM+CiAgICAgIDxQcm9kdWN0PkFzcG9zZS5Ub3RhbCBmb3IgLk5FVDwvUHJvZHVjdD4KICAgIDwvUHJvZHVjdHM+CiAgICA8RWRpdGlvblR5cGU+RW50ZXJwcmlzZTwvRWRpdGlvblR5cGU+CiAgICA8U2VyaWFsTnVtYmVyPjlhNTk1NDdjLTQxZjAtNDI4Yi1iYTcyLTdjNDM2OGYxNTFkNzwvU2VyaWFsTnVtYmVyPgogICAgPFN1YnNjcmlwdGlvbkV4cGlyeT4yMDE1MTIzMTwvU3Vic2NyaXB0aW9uRXhwaXJ5PgogICAgPExpY2Vuc2VWZXJzaW9uPjMuMDwvTGljZW5zZVZlcnNpb24+CiAgICA8TGljZW5zZUluc3RydWN0aW9ucz5odHRwOi8vd3d3LmFzcG9zZS5jb20vY29ycG9yYXRlL3B1cmNoYXNlL2xpY2Vuc2UtaW5zdHJ1Y3Rpb25zLmFzcHg8L0xpY2Vuc2VJbnN0cnVjdGlvbnM+CiAgPC9EYXRhPgogIDxTaWduYXR1cmU+Rk8zUEhzYmxnRHQ4RjU5c01UMWwxYW15aTlxazJWNkU4ZFFrSVA3TGRUSlN4RGliTkVGdTF6T2luUWJxRmZLdi9ydXR0dmN4b1JPa2MxdFVlMER0TzZjUDFaZjZKMFZlbWdTWThpL0xaRUNUR3N6UnFKVlFSWjBNb1ZuQmh1UEFKazVlbGk3ZmhWY0Y4aFdkM0U0WFEzTHpmbUpDdWFqMk5FdGVSaTVIcmZnPTwvU2lnbmF0dXJlPgo8L0xpY2Vuc2U+";
        /// <summary>
        /// Aspose.Pdf license - Pdf.
        /// </summary>
        //const string PdfLicense_10_1 = "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiID8+CjxMaWNlbnNlPgogIDxEYXRhPgogICAgPExpY2Vuc2VkVG8+QXNwb3NlIFNjb3RsYW5kIFRlYW08L0xpY2Vuc2VkVG8+CiAgICA8RW1haWxUbz5iaWxseS5sdW5kaWVAYXNwb3NlLmNvbTwvRW1haWxUbz4KICAgIDxMaWNlbnNlVHlwZT5EZXZlbG9wZXIgT0VNPC9MaWNlbnNlVHlwZT4KICAgIDxMaWNlbnNlTm90ZT5MaW1pdGVkIHRvIDEgZGV2ZWxvcGVyLCB1bmxpbWl0ZWQgcGh5c2ljYWwgbG9jYXRpb25zPC9MaWNlbnNlTm90ZT4KICAgIDxPcmRlcklEPjE0MDQwODA1MjMyNDwvT3JkZXJJRD4KICAgIDxVc2VySUQ+OTQyMzY8L1VzZXJJRD4KICAgIDxPRU0+VGhpcyBpcyBhIHJlZGlzdHJpYnV0YWJsZSBsaWNlbnNlPC9PRU0+CiAgICA8UHJvZHVjdHM+CiAgICAgIDxQcm9kdWN0PkFzcG9zZS5Ub3RhbCBmb3IgLk5FVDwvUHJvZHVjdD4KICAgIDwvUHJvZHVjdHM+CiAgICA8RWRpdGlvblR5cGU+RW50ZXJwcmlzZTwvRWRpdGlvblR5cGU+CiAgICA8U2VyaWFsTnVtYmVyPjlhNTk1NDdjLTQxZjAtNDI4Yi1iYTcyLTdjNDM2OGYxNTFkNzwvU2VyaWFsTnVtYmVyPgogICAgPFN1YnNjcmlwdGlvbkV4cGlyeT4yMDE1MTIzMTwvU3Vic2NyaXB0aW9uRXhwaXJ5PgogICAgPExpY2Vuc2VWZXJzaW9uPjMuMDwvTGljZW5zZVZlcnNpb24+CiAgICA8TGljZW5zZUluc3RydWN0aW9ucz5odHRwOi8vd3d3LmFzcG9zZS5jb20vY29ycG9yYXRlL3B1cmNoYXNlL2xpY2Vuc2UtaW5zdHJ1Y3Rpb25zLmFzcHg8L0xpY2Vuc2VJbnN0cnVjdGlvbnM+CiAgPC9EYXRhPgogIDxTaWduYXR1cmU+Rk8zUEhzYmxnRHQ4RjU5c01UMWwxYW15aTlxazJWNkU4ZFFrSVA3TGRUSlN4RGliTkVGdTF6T2luUWJxRmZLdi9ydXR0dmN4b1JPa2MxdFVlMER0TzZjUDFaZjZKMFZlbWdTWThpL0xaRUNUR3N6UnFKVlFSWjBNb1ZuQmh1UEFKazVlbGk3ZmhWY0Y4aFdkM0U0WFEzTHpmbUpDdWFqMk5FdGVSaTVIcmZnPTwvU2lnbmF0dXJlPgo8L0xpY2Vuc2U+";

        static void Load()
        {
            SetEmailLicense();
            new Cells.License().SetLicense(GetLicense(CellsLicense_18_11));
            ////new Words.License().SetLicense(GetLicense(WordsLicense_18_11));
            ////new Slides.License().SetLicense(GetLicense(SlidesLicense_18_10));
            ////new Pdf.License().SetLicense(GetLicense(PdfLicense_10_1));
        }

        /// <summary>
        /// Aspose.Email - Version 6.1 - Email.
        /// Need To Install License Manually.
        /// </summary>
        public static void SetEmailLicense()
        {
            string name = Assembly.CreateQualifiedName(typeof(Email.License).Assembly.FullName, "\u0008\u2002\u2005");
            Type licType = Type.GetType(name, false, false);
            if (licType == null) throw new NotSupportedException("Unsupported version of Aspose.Email");
            int findCount = 0;
            object lic = Activator.CreateInstance(licType);
            foreach (FieldInfo field in licType.GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance))
            {
                if (field.FieldType == typeof(int) && field.Name == "\u0002")
                {
                    field.SetValue(lic, 256);
                    findCount++;
                }
                else if (field.FieldType.Name == "\u0002\u2000" && field.Name == "\u0008")
                {
                    field.SetValue(lic, 1);
                    findCount++;
                }
                else if (field.FieldType.Name == "\u0006\u2002\u2005" && field.Name == "\u0002\u2000")
                {
                    field.SetValue(lic, 1);
                    findCount++;
                }
                else if (field.FieldType.Name == "\u0008\u2002\u2005" && field.Name == "\u0005\u2000")
                {
                    field.SetValue(null, lic);
                    findCount++;
                }
            }
            if (findCount < 4) throw new NotSupportedException("Unsupported version of Aspose.Email");
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

#endregion

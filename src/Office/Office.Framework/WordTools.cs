using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using Xceed.Words.NET;

namespace Office.Framework
{
    /// <summary>
    /// Microsoft Word 2013 Tools, Limit to install on windows.
    /// </summary>
    public sealed class WordTools
    {
        /// <summary>
        /// 导出 Word 文档(*.docx)
        /// </summary>
        /// <param name="filename">导出的文件名</param>
        /// <param name="template">参考的模板</param>
        /// <param name="data">数据来源</param>
        /// <param name="prefix">前缀</param>
        /// <param name="suffix">后缀</param>
        public static void ExportData(string filename, string template, Dictionary<string, string> data, char prefix = '<', char suffix = '>')
        {
            using (var document = DocX.Load(template))
            {
                foreach (string key in data.Keys)
                {
                    string searchValue = prefix + key + suffix;
                    if (document.FindUniqueByPattern(searchValue, RegexOptions.Compiled).Count > 0)
                    {
                        document.ReplaceText(searchValue, _ => data[key], false, RegexOptions.Compiled);
                    }
                }
                document.SaveAs(filename);
            }
        }

        /// <summary>
        /// 保护 Word 文档(*.doc,*.docx)
        /// </summary>
        /// <param name="filename">原始文件名</param>
        /// <param name="password">打开文档的密码</param>
        /// <param name="passwordFilename">另存为新文件</param>
        /// <param name="allowOnlyReading">设置只读保护</param>
        /// <param name="alertsNone">禁止弹出对话框</param>
        /// <param name="final">标记为最终状态</param>
        /// <returns></returns>
        public static bool Protect(string filename, string password, string passwordFilename = null, bool allowOnlyReading = false, bool alertsNone = false, bool final = false)
        {
            try
            {
                object passwordDocument = password, filePath = passwordFilename, pathToFile = filename;
                object Nothing = Missing.Value; object readOnly = false; object isVisible = true; object objFalse = false;
                var app = new Microsoft.Office.Interop.Word.ApplicationClass();
                // 打开文档
                var doc = app.Documents.Open(ref pathToFile, ref Nothing, ref readOnly, ref Nothing, ref passwordDocument, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref isVisible, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                // 激活文档
                doc.Activate();
                // 判断是否有密码
                //if (word.HasPassword) word.Password = null;
                // 检查是否设置了保护功能，没有设置保护功能，就解除密码保护
                //if (word.ProtectionType != Microsoft.Office.Interop.Word.WdProtectionType.wdNoProtection) word.Unprotect(ref passwordDocument);
                // 设置打开文档的密码
                doc.Password = password;
                // 设置只读保护
                if (allowOnlyReading) doc.Protect(Microsoft.Office.Interop.Word.WdProtectionType.wdAllowOnlyReading, ref objFalse, ref passwordDocument, ref Nothing, ref Nothing);
                // 保存文档
                if (string.IsNullOrEmpty(passwordFilename))
                {
                    doc.Save();
                }
                else
                {
                    doc.SaveAs(ref filePath, ref Nothing, ref Nothing, ref Nothing, ref objFalse, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref isVisible, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                }
                // 禁止弹出对话框
                if (alertsNone) app.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsNone;
                // 标记为最终状态
                if (final) doc.Final = true;
                // 关闭文档
                doc.Close(ref Nothing, ref Nothing, ref Nothing);
                // 退出
                app.Quit(ref Nothing, ref Nothing, ref Nothing);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}

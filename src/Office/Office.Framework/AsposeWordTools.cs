using Aspose.Words;
using Aspose.Words.Replacing;
using Aspose.Words.Saving;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Office.Framework
{
    /// <summary>
    /// Aspose.Words - Version 18.11 - Word Tool.
    /// Cracked, No Need To Install License.
    /// </summary>
    public static class AsposeWordTools
    {
        /// <summary>
        /// 替换文本时的模板字符串前缀
        /// </summary>
        public static char[] ReplaceCharacterPrefix = "<[{".ToArray();

        /// <summary>
        /// 处理替换文本时的模板字符串
        /// </summary>
        /// <param name="data">数据来源</param>
        /// <param name="prefix">前缀</param>
        /// <param name="suffix">后缀</param>
        public static void ReplaceCharacterPrefixForKey(Dictionary<string, string> data, char prefix = '<', char suffix = '>')
        {
            var keys = data.Keys.ToArray();
            foreach (string key in keys) data.Add(prefix + key + suffix, data[key]);
            foreach (string key in keys) data.Remove(key);
        }

        /// <summary>
        /// 替换模板文档的书签
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="dictReplace"></param>
        static void ReplaceDocument(Document doc, Dictionary<string, string> dictBookMark)
        {
            var builder = new DocumentBuilder(doc);
            foreach (Bookmark bookmark in doc.Range.Bookmarks)
            {
                string key = bookmark.Name;
                if (!dictBookMark.ContainsKey(key)) continue;
                builder.MoveTo(bookmark.BookmarkStart.PreviousSibling);
                builder.Write(dictBookMark[key]);
                bookmark.Text = ""; //TODO: the bug isn't solved.
            }
            foreach (string key in dictBookMark.Keys.Where(k => ReplaceCharacterPrefix.Contains(k[0])))
            {
                doc.Range.Replace(key, dictBookMark[key], new FindReplaceOptions() { MatchCase = true });
            }
        }

        /// <summary>
        /// 替换模板文档的书签,导出文档到指定文件
        /// </summary>
        /// <param name="templateFile">Word模板文档</param>
        /// <param name="saveFileName">导出文件路径</param>
        /// <param name="dictBookMark">数据字典</param>
        /// <param name="password">文件密码,输入密码才能打开</param>
        /// <param name="readOnlyProtect">只读保护</param>
        public static void ExportWithBookMark(string templateFile, string saveFileName, Dictionary<string, string> dictBookMark, string password = null, bool readOnlyProtect = false, bool saveRoutingSlip = false)
        {
            if (string.IsNullOrEmpty(templateFile))
                throw new ArgumentNullException(nameof(templateFile));
            if (string.IsNullOrEmpty(saveFileName))
                throw new ArgumentNullException(nameof(saveFileName));
            if (dictBookMark == null || dictBookMark.Count == 0)
                throw new ArgumentNullException(nameof(dictBookMark));
            if (!File.Exists(templateFile))
                throw new ArgumentException(templateFile, string.Format("{0} 文件不存在", Path.GetFileName(templateFile)));

            var doc = new Document(templateFile);
            ReplaceDocument(doc, dictBookMark);

            var filename = saveFileName;
            if (string.IsNullOrEmpty(password))
            {
                doc.Save(filename, SaveOptions.CreateSaveOptions(filename.EndsWith("doc", StringComparison.OrdinalIgnoreCase) ? SaveFormat.Doc : SaveFormat.Docx));
                return;
            }
            if (readOnlyProtect) doc.Protect(ProtectionType.ReadOnly, password);
            var options = new DocSaveOptions(SaveFormat.Doc);
            //options.SaveFormat = filename.EndsWith("doc", StringComparison.OrdinalIgnoreCase) ? SaveFormat.Doc : SaveFormat.Docx;
            if (!filename.EndsWith("doc", StringComparison.OrdinalIgnoreCase)) filename = filename.Substring(0, filename.Length - Path.GetExtension(filename).Length) + ".doc";
            options.Password = password;
            options.SaveRoutingSlip = saveRoutingSlip;
            doc.Save(filename, options);
        }

        /// <summary>
        /// 替换模板文档的书签,导出文档到HTTP输出流
        /// </summary>
        /// <param name="templateFile"></param>
        /// <param name="saveFileName"></param>
        /// <param name="dictBookMark"></param>
        public static void WebExportWithBookMark(string templateFile, string saveFileName, Dictionary<string, string> dictBookMark, string password = null, bool readOnlyProtect = false, bool saveRoutingSlip = false)
        {
            if (string.IsNullOrEmpty(templateFile))
                throw new ArgumentNullException(nameof(templateFile));
            if (string.IsNullOrEmpty(saveFileName))
                throw new ArgumentNullException(nameof(saveFileName));
            if (dictBookMark == null || dictBookMark.Count == 0)
                throw new ArgumentNullException(nameof(dictBookMark));

            var httpContext = HttpContext.Current;
            if (httpContext == null)
                return;

            string fileName = httpContext.Server.MapPath(templateFile);
            if (!File.Exists(fileName))
                throw new ArgumentException(templateFile, string.Format("{0} 文件不存在，", templateFile));

            var doc = new Document(fileName);
            ReplaceDocument(doc, dictBookMark);

            var filename = saveFileName;
            if (string.IsNullOrEmpty(password))
            {
                doc.Save(httpContext.Response, filename, ContentDisposition.Attachment, SaveOptions.CreateSaveOptions(filename.EndsWith("doc", StringComparison.OrdinalIgnoreCase) ? SaveFormat.Doc : SaveFormat.Docx));
                return;
            }
            if (readOnlyProtect) doc.Protect(ProtectionType.ReadOnly, password);
            var options = new DocSaveOptions(SaveFormat.Doc);
            //options.SaveFormat = filename.EndsWith("doc", StringComparison.OrdinalIgnoreCase) ? SaveFormat.Doc : SaveFormat.Docx;
            if (!filename.EndsWith("doc", StringComparison.OrdinalIgnoreCase)) filename = filename.Substring(0, filename.Length - Path.GetExtension(filename).Length) + ".doc";
            options.Password = password;
            options.SaveRoutingSlip = saveRoutingSlip;
            doc.Save(httpContext.Response, filename, ContentDisposition.Attachment, options);
        }

        /// <summary>
        /// 保护 Word 文档(*.doc,*.docx)
        /// </summary>
        /// <param name="filename">文件路径</param>
        /// <param name="password">文件密码</param>
        /// <param name="saveFileName">加密文件路径</param>
        /// <param name="encryptOpen">输入密码才能打开</param>
        /// <param name="readOnlyProtect">只读保护</param>
        /// <param name="saveRoutingSlip">如果文档包含传送名单，我们可以通过将此标志设置为true在保存时保留它。</param>
        public static void EncryptProtect(string filename, string password, string saveFileName = null, bool encryptOpen = true, bool readOnlyProtect = false, bool saveRoutingSlip = false)
        {
            if (string.IsNullOrEmpty(password) || (!encryptOpen && !readOnlyProtect)) return;
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException(nameof(filename));
            if (!File.Exists(filename))
                throw new ArgumentException(filename, string.Format("{0} 文件不存在", Path.GetFileName(filename)));

            var doc = new Document(filename);
            if (readOnlyProtect) doc.Protect(ProtectionType.ReadOnly, password);
            if (!string.IsNullOrEmpty(saveFileName)) filename = saveFileName;
            var options = new DocSaveOptions(SaveFormat.Doc);
            //options.SaveFormat = filename.EndsWith("doc", StringComparison.OrdinalIgnoreCase) ? SaveFormat.Doc : SaveFormat.Docx;
            if (!filename.EndsWith("doc", StringComparison.OrdinalIgnoreCase)) filename = filename.Substring(0, filename.Length - Path.GetExtension(filename).Length) + ".doc";
            if (encryptOpen) options.Password = password;
            options.SaveRoutingSlip = saveRoutingSlip;
            doc.Save(filename, options);
        }
    }
}

using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Office.Framework
{
    /// <summary>
    /// DevExpress.RichEdit - Version 20.1.3.0 - Word Tool.
    /// Cracked, No Need To Install License.
    /// </summary>
    public sealed class DevExpressWordTools
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
        /// 导出 Word 文档(*.doc,*.docx)替换模板文档的书签
        /// </summary>
        /// <param name="templateFile">Word模板文档</param>
        /// <param name="saveFileName">导出文件路径</param>
        /// <param name="dictBookMark">数据字典</param>
        /// <param name="password">文件密码,输入密码才能打开</param>
        /// <param name="readOnlyProtect">只读保护</param>
        public static void ExportWithBookMark(string templateFile, string saveFileName, Dictionary<string, string> dictBookMark, string password = null, bool readOnlyProtect = false)
        {
            if (string.IsNullOrEmpty(templateFile))
                throw new ArgumentNullException(nameof(templateFile));
            if (string.IsNullOrEmpty(saveFileName))
                throw new ArgumentNullException(nameof(saveFileName));
            if (dictBookMark == null || dictBookMark.Count == 0)
                throw new ArgumentNullException(nameof(dictBookMark));
            if (!File.Exists(templateFile))
                throw new ArgumentException(templateFile, string.Format("{0} 文件不存在", Path.GetFileName(templateFile)));

            var doc = new RichEditDocumentServer();
            doc.LoadDocument(templateFile);
            var removedBookmarks = new List<string>();
            // 替换文档的书签
            var bookmarks = doc.Document.Bookmarks;
            for (int i = bookmarks.Count; i > 0; i--)
            {
                Bookmark bookmark = bookmarks[i - 1];
                string key = bookmark.Name;
                if (!dictBookMark.ContainsKey(key)) continue;
                removedBookmarks.Add(key);
                var s = doc.Document.CreateRange(bookmark.Range.Start, bookmark.Range.Length > 0 ? bookmark.Range.Length : 1);
                var c = doc.Document.BeginUpdateCharacters(s);
                doc.Document.Replace(s, dictBookMark[key]);
                doc.Document.EndUpdateCharacters(c);
            }
            for (int i = bookmarks.Count; i > 0; i--)
            {
                Bookmark bookmark = bookmarks[i - 1];
                if (!removedBookmarks.Contains(bookmark.Name)) continue;
                if (bookmark.Range.Length > 0) doc.Document.Delete(bookmark.Range); else bookmarks.Remove(bookmark);
            }
            // 替换文档的模板字符串
            foreach (string key in dictBookMark.Keys.Where(k => ReplaceCharacterPrefix.Contains(k[0])))
            {
                foreach (var s in doc.Document.FindAll(key, SearchOptions.None, doc.Document.Range))
                {
                    var c = doc.Document.BeginUpdateCharacters(s);
                    doc.Document.Replace(s, dictBookMark[key]);
                    doc.Document.EndUpdateCharacters(c);
                }
            }
            // 加密文档与只读保护
            if (!string.IsNullOrEmpty(password))
            {
                doc.Document.Encryption.Password = password;
                doc.Document.Encryption.Type = EncryptionType.Strong;
                if (readOnlyProtect) doc.Document.Protect(password, DocumentProtectionType.ReadOnly);
            }
            doc.SaveDocument(saveFileName, saveFileName.EndsWith("doc", StringComparison.OrdinalIgnoreCase) ? DocumentFormat.Doc : DocumentFormat.OpenXml);
            doc.Dispose();
        }

        /// <summary>
        /// 保护 Word 文档(*.doc,*.docx)
        /// </summary>
        /// <param name="filename">文件路径</param>
        /// <param name="password">文件密码</param>
        /// <param name="saveFileName">加密文件路径</param>
        /// <param name="encryptOpen">输入密码才能打开</param>
        /// <param name="readOnlyProtect">只读保护</param>
        public static void EncryptProtect(string filename, string password, string saveFileName = null, bool encryptOpen = true, bool readOnlyProtect = false)
        {
            if (string.IsNullOrEmpty(password) || (!encryptOpen && !readOnlyProtect)) return;
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException(nameof(filename));
            if (!File.Exists(filename))
                throw new ArgumentException(filename, string.Format("{0} 文件不存在", Path.GetFileName(filename)));

            var doc = new RichEditDocumentServer();
            doc.LoadDocument(filename);
            if (encryptOpen)
            {
                doc.Document.Encryption.Password = password;
                doc.Document.Encryption.Type = EncryptionType.Strong;
            }
            if (readOnlyProtect) doc.Document.Protect(password, DocumentProtectionType.ReadOnly);
            if (!string.IsNullOrEmpty(saveFileName)) filename = saveFileName;
            doc.SaveDocument(filename, filename.EndsWith("doc", StringComparison.OrdinalIgnoreCase) ? DocumentFormat.Doc : DocumentFormat.OpenXml);
            doc.Dispose();
        }
    }
}

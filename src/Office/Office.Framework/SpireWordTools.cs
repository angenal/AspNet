using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using Spire.Doc.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace Office.Framework
{
    /// <summary>
    /// Spire.Doc - Version 9.4 - Word Tool.
    /// Cracked, No Need To Install License.
    /// </summary>
    public static class SpireWordTools
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
        public void ExportWithBookMark(string templateFile, string saveFileName, Dictionary<string, string> dictBookMark, string password = null, bool readOnlyProtect = false)
        {
            if (string.IsNullOrEmpty(templateFile))
                throw new ArgumentNullException(nameof(templateFile));
            if (string.IsNullOrEmpty(saveFileName))
                throw new ArgumentNullException(nameof(saveFileName));
            if (dictBookMark == null || dictBookMark.Count == 0)
                throw new ArgumentNullException(nameof(dictBookMark));
            if (!File.Exists(templateFile))
                throw new ArgumentException(templateFile, string.Format("{0} 文件不存在", Path.GetFileName(templateFile)));

            var doc = new Document();
            doc.LoadFromFile(templateFile);
            // 替换文档的书签
            var nav = new BookmarksNavigator(doc);
            foreach (Bookmark bookmark in doc.Bookmarks)
            {
                string key = bookmark.Name;
                if (!dictBookMark.ContainsKey(key)) continue;
                var textRange = FindBookmarkText(bookmark);
                if (textRange == null) continue;
                // 创建文本内容
                var sec = doc.AddSection();
                var range = sec.AddParagraph().AppendText(dictBookMark[key]);
                // 创建文本格式
                ImportContainerMethod.Invoke(range.CharacterFormat, new[] { textRange.CharacterFormat });
                var par1 = sec.Paragraphs[0].Items.FirstItem as ParagraphBase;
                var par2 = sec.Paragraphs[sec.Paragraphs.Count > 1 ? sec.Paragraphs.Count - 1 : 0].Items.LastItem as ParagraphBase;
                var text = new TextBodyPart(new TextBodySelection(par1, par2));
                // 定位书签
                nav.MoveToBookmark(key, true, true);
                // 删除原有的书签内容
                nav.DeleteBookmarkContent(true);
                // 替换为新的书签内容
                nav.ReplaceBookmarkContent(text);
                // 移除内容区域
                doc.Sections.Remove(sec);
            }
            // 替换文档的模板字符串
            foreach (string key in dictBookMark.Keys.Where(k => ReplaceCharacterPrefix.Contains(k[0])))
            {
                foreach (var s in doc.FindAllString(key, true, false))
                {
                    var text = s.GetAsOneRange();
                    text.Text = dictBookMark[key];
                }
            }
            // 加密文档与只读保护
            if (string.IsNullOrEmpty(password))
            {
                if (readOnlyProtect) doc.Protect(ProtectionType.AllowOnlyReading);
            }
            else
            {
                doc.Encrypt(password);
                if (readOnlyProtect) doc.Protect(ProtectionType.AllowOnlyReading, password);
            }
            doc.SaveToFile(saveFileName);
            doc.Dispose();
        }

        /// <summary>CharacterFormat's ImportContainer protected internal method</summary>
        static readonly MethodInfo ImportContainerMethod = typeof(Spire.Doc.Formatting.CharacterFormat).GetMethod("ImportContainer", BindingFlags.NonPublic | BindingFlags.Instance);

        /// <summary>Find bookmark textRange</summary>
        static ITextRange FindBookmarkText(Bookmark bookmark)
        {
            var t = FindBookmarkTextRange(bookmark.BookmarkStart.Owner.ChildObjects);
            if (t != null) return t;
            t = FindBookmarkTextRange(bookmark.BookmarkStart.PreviousSibling.Owner.ChildObjects);
            if (t != null) return t;
            t = FindBookmarkTextRange(bookmark.BookmarkEnd.NextSibling.Owner.ChildObjects);
            return t;
        }

        /// <summary>Find bookmark textRange</summary>
        static ITextRange FindBookmarkTextRange(DocumentObjectCollection s)
        {
            int c = s.Count, b = c / 2, i;
            if (b > 1)
            {
                for (i = b; i < c; i++) if (s[i] is ITextRange t) return t;
                for (i = b - 1; i >= 0; i--) if (s[i] is ITextRange t) return t;
            }
            else
            {
                for (i = c - 1; i >= 0; i--) if (s[i] is ITextRange t) return t;
            }
            return null;
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

            var doc = new Document();
            doc.LoadFromFile(filename);
            if (encryptOpen) doc.Encrypt(password);
            if (readOnlyProtect) doc.Protect(ProtectionType.AllowOnlyReading, password);
            if (!string.IsNullOrEmpty(saveFileName)) filename = saveFileName;
            doc.SaveToFile(filename);
            doc.Dispose();
        }

        /// <summary>
        /// 导出图片png格式
        /// </summary>
        /// <param name="filename">文件路径</param>
        /// <param name="outputDirectory">保存图片的相对路径目录</param>
        /// <param name="httpRootPath">http绝对路径</param>
        /// <param name="password">文件打开密码</param>
        /// <returns></returns>
        public static string ImagePreview(string filename, string outputDirectory, string httpRootPath = "", string password = "")
        {
            return SaveToFile(filename, outputDirectory, ".png", httpRootPath, password);
        }

        /// <summary>
        /// 导出文档pdf格式
        /// </summary>
        /// <param name="filename">word文件路径</param>
        /// <param name="outputDirectory">保存的相对路径目录</param>
        /// <param name="httpRootPath">http绝对路径</param>
        /// <param name="password">文件打开密码</param>
        /// <returns></returns>
        public static string PdfPreview(string filename, string outputDirectory, string httpRootPath = "", string password = "")
        {
            return SaveToFile(filename, outputDirectory, ".pdf", httpRootPath, password);
        }

        /// <summary>
        /// 导出网页html格式
        /// </summary>
        /// <param name="filename">word文件路径</param>
        /// <param name="outputDirectory">保存的相对路径目录</param>
        /// <param name="httpRootPath">http绝对路径</param>
        /// <param name="password">文件打开密码</param>
        /// <returns></returns>
        public static string HtmlPreview(string filename, string outputDirectory, string httpRootPath = "", string password = "")
        {
            return SaveToFile(filename, outputDirectory, ".html", httpRootPath, password);
        }

        static string SaveToFile(string filename, string outputDirectory, string outputFileFormat, string httpRootPath, string password)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException(nameof(filename));
            if (string.IsNullOrEmpty(outputDirectory))
                throw new ArgumentNullException(nameof(outputDirectory));
            var source = new FileInfo(filename);
            if (!source.Exists)
                throw new ArgumentException(filename, string.Format("{0} 文件不存在", source.Name));
            if (Path.IsPathRooted(outputDirectory))
                throw new ArgumentException(outputDirectory, string.Format("{0} 相对路径错误", nameof(outputDirectory)));

            if (HttpContext.Current != null)
            {
                var uri = HttpContext.Current.Request.Url;
                if (string.IsNullOrEmpty(httpRootPath)) httpRootPath = uri.Scheme + "://" + uri.Authority + "/";
            }

            if (string.IsNullOrEmpty(httpRootPath))
                throw new ArgumentNullException(nameof(httpRootPath));
            var uriString = httpRootPath + outputDirectory.Trim('/');
            if (!Uri.TryCreate(uriString, UriKind.Absolute, out _))
                throw new ArgumentException(outputDirectory, string.Format("{0} 相对路径错误", nameof(outputDirectory)));
            var dirString = HttpContext.Current != null ? HttpContext.Current.Server.MapPath("/" + outputDirectory.Trim('/')) : Path.Combine(Directory.GetCurrentDirectory(), outputDirectory);
            var dir = new DirectoryInfo(dirString);
            if (!dir.Exists) dir.Create();

            DateTime dt = source.LastWriteTime, epoch = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            var ts = ((long)Math.Round(((dt < epoch ? DateTime.Now : dt) - epoch).TotalSeconds, MidpointRounding.AwayFromZero)).ToString("x8");
            string name = Path.GetFileNameWithoutExtension(filename), fName, fPath;

            if (outputFileFormat == ".pdf")
            {
                fName = name + ts + outputFileFormat;
                fPath = Path.Combine(dirString, fName);
                if (File.Exists(fPath)) return uriString + "/" + fName;

                var oldFiles = dir.GetFiles(name + "*" + outputFileFormat);
                foreach (var oldFile in oldFiles) oldFile.Delete();

                var doc = new Document();
                if (string.IsNullOrEmpty(password)) doc.LoadFromFile(filename);
                else doc.LoadFromFile(filename, FileFormat.Auto, password);
                doc.SaveToFile(fPath, FileFormat.PDF);
                doc.Dispose();

                return uriString + "/" + fName;
            }

            if (outputFileFormat == ".html")
            {
                fName = name + ts + outputFileFormat;
                fPath = Path.Combine(dirString, fName);
                if (File.Exists(fPath)) return uriString + "/" + fName;

                var oldFiles = dir.GetFiles(name + "*" + outputFileFormat);
                foreach (var oldFile in oldFiles) oldFile.Delete();

                var doc = new Document();
                if (string.IsNullOrEmpty(password)) doc.LoadFromFile(filename);
                else doc.LoadFromFile(filename, FileFormat.Auto, password);
                doc.SaveToFile(fPath, FileFormat.Html);
                doc.Dispose();

                // merge html css
                var fileEncoding = Encoding.UTF8;
                var htmlContent = File.ReadAllText(fPath, fileEncoding);
                string cssExtension = "_styles.css", cssFile = Path.Combine(dirString, name + ts + cssExtension);
                var cssContent = File.ReadAllText(cssFile, fileEncoding);
                var content = htmlContent.Replace($"<link href=\"{name}{ts}{cssExtension}\" type=\"text/css\" rel=\"stylesheet\"/>", "<style>" + cssContent + "</style>");
                File.WriteAllText(fPath, content, fileEncoding);
                File.Delete(cssFile);

                return uriString + "/" + fName;
            }

            if (outputFileFormat == ".png")
            {
                fName = name + ts + outputFileFormat;
                fPath = Path.Combine(dirString, fName);
                if (File.Exists(fPath)) return uriString + "/" + fName;

                var oldFiles = dir.GetFiles(name + "*" + outputFileFormat);
                foreach (var oldFile in oldFiles) oldFile.Delete();

                var doc = new Document();
                if (string.IsNullOrEmpty(password)) doc.LoadFromFile(filename);
                else doc.LoadFromFile(filename, FileFormat.Auto, password);
                var count = doc.PageCount;
                int width = 0, height = 0;
                var images = new Image[count];
                for (var i = 0; i < count; i++)
                {
                    images[i] = doc.SaveToImages(i, ImageType.Metafile);
                    width = images[i].Width;
                    height += images[i].Height;
                }
                doc.Dispose();

                // merge image
                var b = new Bitmap(width, height);
                var g = Graphics.FromImage(b);
                for (int i = 0, y = 0; i < count; i++)
                {
                    g.DrawImage(images[i], new Point(0, y));
                    y += images[i].Height;
                }
                b.Save(fPath, ImageFormat.Png);
                foreach (var img in images) img.Dispose();
                b.Dispose(); g.Dispose();

                return uriString + "/" + fName;
            }

            throw new ArgumentNullException(nameof(outputFileFormat));
        }
    }
}

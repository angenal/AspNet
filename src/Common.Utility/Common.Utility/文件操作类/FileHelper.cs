using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Common.Utility
{
    /// <summary>
    /// 文件帮忙类
    /// </summary>
    public static class FileHelper
    {
        #region log4net

        /// <summary>
        /// 读取 log4net 日志文件 set log4net.config
        ///   &lt;appender name="[Debug|Error|Info|Warn]Log" type="log4net.Appender.RollingFileAppender"&gt;
        ///     &lt;param name="DatePattern" value="/yyyy-MM-dd/&quot;Debug.log&quot;"/&gt;
        /// </summary>
        /// <param name="appenderName">[Debug|Error|Info|Warn]Log</param>
        /// <param name="dateQuery">选择日期</param>
        /// <param name="linesQuery">几行</param>
        /// <param name="encodingQuery">文本编码</param>
        /// <param name="query">请求数据</param>
        /// <returns></returns>
        public static string ReadFromLog4Net(this string appenderName, string dateQuery = "t", string linesQuery = "n", string encodingQuery = "ie", NameValueCollection query = null)
        {
            var appender = ((Hierarchy)LogManager.GetRepository()).Root.Appenders.OfType<RollingFileAppender>().FirstOrDefault(t => t.Name.Contains(appenderName));
            if (appender == null) throw new Exception("log4net.config not found or config error");

            if (query == null) query = HttpContext.Current.Request.QueryString;

            var dt = query[dateQuery];
            DateTime date = new DateTime(), now = DateTime.Now;
            if (!string.IsNullOrEmpty(dt) && DateTime.TryParse(dt, out var dateTime)) date = dateTime;
            var isNow = date == new DateTime();
            string Get(DateTime t) => t.ToString(appender.DatePattern).Trim('/', '\\').Split('/', '\\').FirstOrDefault();
            var filename = isNow ? appender.File : appender.File.Replace(Get(now), Get(date));
            var fileInfo = new FileInfo(filename);
            if (!fileInfo.Exists) throw new Exception("log file not found");

            const int minLines = 10;
            string n = query[linesQuery], ie = query[encodingQuery];
            var tail = int.TryParse(n, out var lines);
            var encoding = Encoding.Default;
            if (!string.IsNullOrEmpty(ie)) encoding = Encoding.GetEncoding(ie);

            var s = new StringBuilder("{{");
            var logfile = (isNow ? now : date).ToString(appender.DatePattern);
            if (fileInfo.Length == 0)
            {
                s.Append($" file: {logfile}  0KB ");
            }
            else if (fileInfo.Length >= 1024 * 1024)
            {
                s.Append($" file: {logfile}  {fileInfo.Length.ToFileSize()} ");
                if (lines < minLines) lines = minLines;
            }
            else
            {
                s.Append($" file: {logfile}  {fileInfo.Length.ToFileSize()} ");
                if (!tail) lines = 0;
                else if (lines < minLines) lines = minLines;
            }
            s.Append("}}");
            s.Append(Environment.NewLine);

            if (fileInfo.Length == 0) return s.ToString();

            s.Append(Environment.NewLine);
            var text = fileInfo.FullName.ReadFromTail(lines, encoding);
            s.Append(text);

            return s.ToString();
        }

        /// <summary>
        /// 删除 log4net 日志文件 set log4net.config
        ///   &lt;appender name="[Debug|Error|Info|Warn]Log" type="log4net.Appender.RollingFileAppender"&gt;
        ///     &lt;param name="DatePattern" value="/yyyy-MM-dd/&quot;Debug.log&quot;"/&gt;
        /// </summary>
        /// <param name="appenderName">[Debug|Error|Info|Warn]Log | *</param>
        /// <param name="dateQuery">截至日期</param>
        /// <param name="daysQuery">前几天</param>
        /// <param name="query">请求数据</param>
        /// <returns></returns>
        public static string DeleteFromLog4Net(this string appenderName, string dateQuery = "t", string daysQuery = "n", NameValueCollection query = null)
        {
            var appenders = new List<RollingFileAppender>();
            if (!string.IsNullOrEmpty(appenderName) && appenderName != "*")
            {
                var appender = ((Hierarchy)LogManager.GetRepository()).Root.Appenders.OfType<RollingFileAppender>().FirstOrDefault(t => t.Name.Contains(appenderName));
                if (appender == null) throw new Exception("log4net.config not found or config error");
                appenders.Add(appender);
            }
            else
            {
                appenders.AddRange(((Hierarchy)LogManager.GetRepository()).Root.Appenders.OfType<RollingFileAppender>());
            }

            if (appenders.Count == 0) throw new Exception("log4net.config not found or config error");

            if (query == null) query = HttpContext.Current.Request.QueryString;

            string dt = query[dateQuery], n = query[daysQuery];
            int.TryParse(n, out var days);
            if (days < 1) days = 1;
            DateTime now = DateTime.Now, fromTime = now;
            if (!string.IsNullOrEmpty(dt) && DateTime.TryParse(dt, out var dateTime)) fromTime = dateTime;
            if (fromTime.ToString("M/d/yy").Equals(now.ToString("M/d/yy")) || fromTime > now) fromTime = now;
            else fromTime = fromTime.AddDays(1);

            StringBuilder s = new StringBuilder("{{"), tmp = new StringBuilder();
            var filesCount = 0;
            while (days > 0)
            {
                var date = fromTime.AddDays(days * -1);
                string dir = null;
                foreach (var appender in appenders)
                {
                    var file = now.ToString(appender.DatePattern);
                    var logfile = date.ToString(appender.DatePattern);
                    var fileInfo = new FileInfo(appender.File.Replace(file, logfile));
                    dir = Path.GetDirectoryName(fileInfo.FullName);
                    if (!fileInfo.Exists) continue;

                    filesCount++;
                    tmp.Append(Environment.NewLine);
                    tmp.Append($"  {logfile}  {(fileInfo.Length == 0 ? "0KB" : fileInfo.Length.ToFileSize())} ");
                    fileInfo.Delete();
                }

                if (dir != null && Directory.Exists(dir) && Directory.GetFiles(dir).Length == 0)
                    Directory.Delete(dir, true);

                days--;
            }
            s.Append($" delete files count: {filesCount} ");
            s.Append("}}");
            s.Append(Environment.NewLine);
            s.Append(tmp);
            s.Append(Environment.NewLine);

            return s.ToString();
        }

        #endregion


        /// <summary>
        /// 读取文件尾部的几行文本
        /// </summary>
        /// <param name="filename">文件路径</param>
        /// <param name="lines">几行</param>
        /// <param name="encoding">文本编码</param>
        /// <returns></returns>
        public static string ReadFromTail(this string filename, int lines, Encoding encoding)
        {
            if (lines <= 0)
            {
                using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var streamReader = new StreamReader(stream, encoding))
                        return streamReader.ReadToEnd();
                }
            }

            var delimiter = Environment.NewLine[0];
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                for (int newline = 0, offset = 1; newline < lines; offset++)
                {
                    try
                    {
                        stream.Seek(-offset, SeekOrigin.End);
                    }
                    catch (Exception)
                    {
                        break;
                    }

                    if (stream.ReadByte() == delimiter) newline++;
                }

                using (var streamReader = new StreamReader(stream, encoding))
                    return streamReader.ReadToEnd();
            }
        }

        /// <summary>
        /// 转换文件大小单位 B, KB, MB, GB, TB
        /// </summary>
        /// <param name="i">字节大小</param>
        /// <param name="suffix">后缀</param>
        /// <returns></returns>
        public static string ToFileSize(this long i, string suffix = "")
        {
            if (i == 0)
                return "";
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            var order = 0; double len = i;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                len = len / 1024;
                order++;
            }
            return string.Format("{0:0.##}{1}{2}", len, sizes[order], suffix);
        }

    }
}

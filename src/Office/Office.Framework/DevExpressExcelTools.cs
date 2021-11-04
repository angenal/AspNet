using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Office.Framework
{
    /// <summary>
    /// DevExpress Excel Tools
    /// </summary>
    public static class DevExpressExcelTools
    {
        #region 导出Excel

        public static MemoryStream ExportDataTable(DataTable dt, string template, string dateTimeFormat = "yyyy/MM/dd HH:mm")
        {
            if (dt == null || template == null) return null;
            if (template.StartsWith("/") || template.StartsWith("~"))
                template = HttpContext.Current.Server.MapPath(template);
            if (!File.Exists(template)) return null;

            // 读取excel
            using (var workbook = new Workbook())
            {
                workbook.LoadDocument(template);
                if (workbook.Worksheets.Count == 0) return null;
                var sheet = workbook.Worksheets[0];
                var header = sheet.GetUsedRange();
                //模板行
                var rowIndex = -1;
                for (var i = header.TopRowIndex; i < header.RowCount; i++)
                {
                    if (string.IsNullOrWhiteSpace(header[i, 0].DisplayText))
                    {
                        rowIndex = i;
                        break;
                    }
                }

                if (rowIndex == -1) return null;

                //复制行
                for (var i = 0; i < dt.Rows.Count - 1; i++)
                {
                    sheet.Rows[rowIndex + i + 1].CopyFrom(sheet.Rows[rowIndex], PasteSpecial.All);
                }

                //填充数据
                for (int i = 0, index = rowIndex, coloumCount = dt.Columns.Count; i < dt.Rows.Count; i++, index++)
                {
                    var row = dt.Rows[i];
                    var cells = sheet.Rows[index].ExistingCells.GetEnumerator();
                    for (var j = 0; j < coloumCount; j++)
                    {
                        if (!cells.MoveNext()) continue;

                        var v = row[j];
                        if (v == null || v == DBNull.Value) continue;

                        switch (v.GetType().Name)
                        {
                            case "DateTime":
                                cells.Current.SetValueFromText(Convert.ToDateTime(v).ToString(dateTimeFormat));
                                break;
                            default:
                                cells.Current.SetValue(v.ToString());
                                break;
                        }
                    }
                }

                var memory = new MemoryStream();
                workbook.SaveDocument(memory, template.EndsWith(".xlsx") ? DocumentFormat.Xlsx : DocumentFormat.Xls);
                return memory;
            }
        }

        #endregion

        #region 读取Excel

        /// <summary>
        /// 导出 DataTable
        /// </summary>
        /// <param name="url"></param>
        /// <param name="hasHeaders"></param>
        /// <returns></returns>
        public static DataTable DataTableFromUrl(string url, bool hasHeaders = true)
        {
            var dt = new DataTable();
            // 本地文件地址，或者从网上下载
            var fileName = Download_From_Url(url);
            if (!File.Exists(fileName)) return dt;
            // 读取excel
            using (var workbook = new Workbook())
            {
                workbook.LoadDocument(fileName);
                if (workbook.Worksheets.Count == 0) return dt;
                var sheet = workbook.Worksheets[0];
                var exporter = sheet.CreateDataTableExporter(sheet.GetUsedRange(), dt, hasHeaders);
                exporter.Options.ConvertEmptyCells = false;
                exporter.Options.SkipEmptyRows = true;
                exporter.Export();
            }
            return dt;
        }

        /// <summary>
        /// 导出 DataSet
        /// </summary>
        /// <param name="url"></param>
        /// <param name="hasHeaders"></param>
        /// <returns></returns>
        public static DataSet DataSetFromUrl(string url, bool hasHeaders = true)
        {
            var ds = new DataSet();
            // 本地文件地址，或者从网上下载
            var fileName = Download_From_Url(url);
            if (!File.Exists(fileName)) return ds;
            // 读取excel
            using (var workbook = new Workbook())
            {
                workbook.LoadDocument(fileName);
                foreach (var sheet in workbook.Worksheets)
                {
                    var dt = new DataTable();
                    var exporter = sheet.CreateDataTableExporter(sheet.GetUsedRange(), dt, hasHeaders);
                    exporter.Options.ConvertEmptyCells = false;
                    exporter.Options.SkipEmptyRows = true;
                    exporter.Export();
                    ds.Tables.Add(dt);
                }
            }
            return ds;
        }

        /// <summary>
        /// 遍历Excel#Sheet1每一行
        /// </summary>
        /// <param name="url"></param>
        /// <param name="rowActionNext"></param>
        /// <param name="hasHeaders"></param>
        public static void DataActionFromUrl(string url, Func<Row, bool> rowActionNext, bool hasHeaders = true)
        {
            // 本地文件地址，或者从网上下载
            var fileName = Download_From_Url(url);
            if (!File.Exists(fileName)) return;
            // 读取excel
            var workbook = new Workbook();
            workbook.LoadDocument(fileName);
            if (workbook.Worksheets.Count == 0) return;
            var sheet = workbook.Worksheets[0];
            var range = sheet.GetUsedRange();
            for (var row = hasHeaders ? 1 : 0; row < range.RowCount; row++)
            {
                var ranges = sheet.Rows[row + range.TopRowIndex];
                if (!rowActionNext(ranges)) break;
            }
        }

        /// <summary>
        /// 获取Excel#Sheet1每一行
        /// </summary>
        /// <param name="url"></param>
        /// <param name="hasHeaders"></param>
        /// <param name="checkTemplate"></param>
        /// <returns></returns>
        public static Row[] DataCellsFromUrl(string url, bool hasHeaders = true, string checkTemplate = null)
        {
            var rows = new List<Row>();
            // 本地文件地址，或者从网上下载
            var fileName = Download_From_Url(url);
            if (!File.Exists(fileName)) return rows.ToArray();
            // 读取excel
            var workbook = new Workbook();
            workbook.LoadDocument(fileName);
            if (workbook.Worksheets.Count == 0) return rows.ToArray();
            var sheet = workbook.Worksheets[0];
            var range = sheet.GetUsedRange();
            // 检查上传文件是否为指定模板文件
            if (hasHeaders && !string.IsNullOrEmpty(checkTemplate))
            {
                var columns = GetTemplateColumns(checkTemplate);
                var row = sheet.Rows[range.TopRowIndex];
                for (var i = 0; i < columns.Length; i++)
                    if (columns[i] != row.ExistingCells.ElementAt(i).DisplayText)
                        return rows.ToArray();
            }
            for (var row = hasHeaders ? 1 : 0; row < range.RowCount; row++)
            {
                rows.Add(sheet.Rows[row + range.TopRowIndex]);
            }
            return rows.ToArray();
        }

        /// <summary>
        /// 检查上传文件是否为指定模板文件
        /// </summary>
        /// <param name="url">上传文件</param>
        /// <param name="template">模板文件</param>
        /// <returns></returns>
        public static string[] GetTemplateColumns(string template)
        {
            //string k = template.Md5();
            //string v = LazyCache.App.GetCache<string>(k);
            //if (v != null) return v.Split('\t');

            Workbook workbook = null;
            try
            {
                var fileName = Download_From_Url(template);
                if (!File.Exists(fileName)) return new string[0];

                workbook = new Workbook();
                workbook.LoadDocument(fileName);
                if (workbook.Worksheets.Count == 0) return new string[0];

                var sheet = workbook.Worksheets[0];
                var range = sheet.GetUsedRange();
                var row = sheet.Rows[range.TopRowIndex];
                var columns = new string[row.ColumnCount];
                for (var i = 0; i < columns.Length; i++) columns[i] = row.ExistingCells.ElementAt(i).DisplayText;

                //v = string.Join("\t", columns);
                //LazyCache.App.SetCache(k, v, null);

                return columns;
            }
            catch
            {
                return new string[0];
            }
            finally
            {
                if (workbook != null) workbook.Dispose();
            }
        }

        /// <summary>
        /// 从网上下载
        /// </summary>
        /// <param name="url">网址</param>
        /// <returns></returns>
        public static string Download_From_Url(string url)
        {
            if (string.IsNullOrEmpty(url)) return url;
            // 是本地文件直接返回
            var isHttpReq = url.IsHttpUrl();
            if (!isHttpReq && File.Exists(url)) return url;
            // 本地文件地址
            var fileName = "";
            // 从网上下载
            if (!isHttpReq) return fileName;
            // 同域名时
            if (HttpContext.Current != null && HttpContext.Current.Request.Url.IsSameDomainUrl(url, out var uriOut))
            {
                var url1 = HttpContext.Current.Server.MapPath(uriOut.AbsolutePath);
                if (File.Exists(url1)) return url1;
            }
            // 不同域名时
            Task.Factory.StartNew(() =>
            {
                try
                {
                    // 开始下载
                    var client = new WebClient();
                    // 设置头信息
                    client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.82 Safari/537.36");
                    // 下载生成的临时文件
                    var tempFilePath = TempFile_From_Url(url);
                    if (string.IsNullOrEmpty(tempFilePath))
                        throw new Exception("下载文件失败");
                    client.DownloadFile(url, tempFilePath);
                    // 返回下载路径
                    if (!File.Exists(tempFilePath))
                        throw new Exception("下载文件失败");
                    fileName = tempFilePath;
                }
                catch (Exception e)
                {
                    throw new Exception("下载文件异常：" + e.Message);
                }
            }).Wait(TimeSpan.FromMinutes(10));
            return fileName;
        }
        /// <summary>
        /// 删除 下载生成的临时文件
        /// </summary>
        /// <param name="url"></param>
        public static void DeleteTempFile_From_Url(string url)
        {
            try
            {
                var tempFilePath = TempFile_From_Url(url);
                if (!string.IsNullOrEmpty(tempFilePath))
                    File.Delete(tempFilePath);
            }
            catch
            {
                // ignored
            }
        }
        /// <summary>
        /// 下载生成的临时文件
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string TempFile_From_Url(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url)) return "";
                // 同域名时
                if (HttpContext.Current != null && HttpContext.Current.Request.Url.IsSameDomainUrl(url, out var uriOut))
                {
                    var url1 = HttpContext.Current.Server.MapPath(uriOut.AbsolutePath);
                    if (File.Exists(url1)) return url1;
                }
                // 下载保存临时路径
                var directoryName = Environment.GetEnvironmentVariable("TEMP");
                if (string.IsNullOrEmpty(directoryName)) directoryName = Environment.GetEnvironmentVariable("TMP");
                if (string.IsNullOrEmpty(directoryName)) return "";
                if (!Directory.Exists(directoryName)) Directory.CreateDirectory(directoryName);
                // 生成的临时文件名
                var url2 = url.ToLower();
                var fileExtSep = url2.LastIndexOf('.');
                var fileExt = fileExtSep > 0 && (url2.EndsWith("xlsx") || url2.EndsWith("xls")) ? url2.Substring(fileExtSep) : ".xlsx";
                var tempFilePath = Path.Combine(directoryName, url.Md5() + fileExt);
                return tempFilePath;
            }
            catch
            {
                return "";
            }
        }

        #endregion

        #region 扩展Excel

        /// <summary>
        /// 设置单元格，指定 填充了背景色的 为正确答案
        /// </summary>
        /// <param name="xlsRange"></param>
        /// <returns></returns>
        public static bool IsRight(this Cell xlsRange)
        {
            return (!string.IsNullOrWhiteSpace(xlsRange?.DisplayText) && xlsRange.FillColor.IsEmpty == false && (xlsRange.FillColor.A + xlsRange.FillColor.R + xlsRange.FillColor.G + xlsRange.FillColor.B) != (System.Drawing.Color.White.A + System.Drawing.Color.White.R + System.Drawing.Color.White.G + System.Drawing.Color.White.B));
        }
        /// <summary>
        /// 判断单元格为空
        /// </summary>
        /// <param name="xlsRange"></param>
        /// <returns></returns>
        public static bool IsNull(this Cell xlsRange)
        {
            return string.IsNullOrWhiteSpace(xlsRange?.DisplayText);
        }

        #endregion

        #region 扩展方法
        static string Md5(this string str)
        {
            var md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            return BitConverter.ToString(s).ToUpper().Replace("-", "");
        }
        static bool IsHttpUrl(this string url)
        {
            if (string.IsNullOrEmpty(url))
                return false;
            if (url.StartsWith("http://") || url.StartsWith("https://"))
                return Uri.TryCreate(url, UriKind.Absolute, out _);
            return false;
        }
        static bool IsSameDomainUrl(this Uri uri, string url, out Uri uriOut)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out var uri2) && uri2.Authority.Equals(uri.Authority, StringComparison.OrdinalIgnoreCase))
            {
                uriOut = uri2;
                return true;
            }
            uriOut = new Uri("http://x");
            return false;
        }
        #endregion
    }
}

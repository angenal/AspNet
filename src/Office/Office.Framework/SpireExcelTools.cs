using Spire.Xls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Office.Framework
{
    /// <summary>
    /// Spire.XLS - Version 11.4.6 - Excel Tool.
    /// Cracked, No Need To Install License.
    /// </summary>
    public static class SpireExcelTools
    {

        /// <summary>
        /// 导出 Excel 文档(*.xls,*.xlsx)
        /// </summary>
        /// <param name="templateFile">Excel模板文档</param>
        /// <param name="saveFileName">导出文件路径</param>
        /// <param name="list">数据列表</param>
        /// <param name="columnHeaders">列名关系{"A1","Hashtable:Key1"}</param>
        /// <param name="copyStyles">复制数据行第一行样式</param>
        /// <param name="password">文件密码,输入密码才能打开</param>
        /// <param name="readOnlyProtect">只读保护</param>
        public static void ExportWithList(string templateFile, string saveFileName, IEnumerable<Hashtable> list, Dictionary<string, string> columnHeaders, bool copyStyles = true, string password = null, bool readOnlyProtect = false)
        {
            if (string.IsNullOrEmpty(templateFile))
                throw new ArgumentNullException(nameof(templateFile));
            if (string.IsNullOrEmpty(saveFileName))
                throw new ArgumentNullException(nameof(saveFileName));
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            if (!File.Exists(templateFile))
                throw new ArgumentException(templateFile, string.Format("{0} 文件不存在", Path.GetFileName(templateFile)));

            var doc = new Workbook();
            doc.LoadFromFile(templateFile);
            if (doc.Worksheets.Count == 0)
            {
                doc.Dispose();
                return;
            }
            // 逐行导入数据
            var sheet = doc.Worksheets[0];
            if (list.Any())
            {
                var keys = list.First().Keys.OfType<string>();
                var columns = columnHeaders.Keys.Where(key => keys.Contains(columnHeaders[key])).ToArray();
                var headers = columns.Select(column => column.Substring(0, column.Length - 1)).ToArray();
                int rowIndex = sheet.FirstRow, templateRow = rowIndex + 1, columnsLength = columns.Length;
                foreach (Hashtable item in list)
                {
                    rowIndex++;
                    if (copyStyles && rowIndex > templateRow)
                    {
                        sheet.InsertRow(rowIndex);
                        sheet.CopyRow(sheet.Rows[1], sheet, rowIndex, CopyRangeOptions.All);
                    }
                    for (int i = 0; i < columnsLength; i++)
                    {
                        sheet[headers[i] + rowIndex].Text = item[columnHeaders[columns[i]]]?.ToString();
                    }
                }
            }
            // 加密文档与只读保护
            if (!string.IsNullOrEmpty(password))
            {
                if (readOnlyProtect) doc.Protect(password, true, true);
                else doc.Protect(password);
            }
            doc.SaveToFile(saveFileName);
            doc.Dispose();
        }

        /// <summary>
        /// 导出 Excel 文档(*.xls,*.xlsx)
        /// </summary>
        /// <param name="saveFileName">导出文件路径</param>
        /// <param name="dataTable">数据列表</param>
        /// <param name="columnHeaders">包含列名</param>
        /// <param name="firstRow">第一行</param>
        /// <param name="firstColumn">第一列</param>
        /// <param name="password">文件密码,输入密码才能打开</param>
        /// <param name="readOnlyProtect">只读保护</param>
        public static void ExportWithDataTable(string saveFileName, DataTable dataTable, bool columnHeaders = true, int firstRow = 1, int firstColumn = 1, string password = null, bool readOnlyProtect = false)
        {
            if (string.IsNullOrEmpty(saveFileName))
                throw new ArgumentNullException(nameof(saveFileName));
            if (dataTable == null)
                throw new ArgumentNullException(nameof(dataTable));

            var doc = new Workbook();
            doc.Version = ExcelVersion.Version2007; // 指定版本07及以上版本最多可以插入1048576行数据
            if (dataTable.Rows.Count > 1048575) doc.Version = ExcelVersion.Version2013;
            if (dataTable.Rows.Count > 0)
            {
                var sheet = doc.Worksheets[0];
                sheet.InsertDataTable(dataTable, columnHeaders, firstRow, firstColumn);
                // 加密文档与只读保护
                if (!string.IsNullOrEmpty(password))
                {
                    if (readOnlyProtect) doc.Protect(password, true, true);
                    else doc.Protect(password);
                }
            }
            doc.SaveToFile(saveFileName, doc.Version);
            doc.Dispose();
        }

    }
}

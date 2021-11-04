using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;
using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace Office.Framework
{
    /// <summary>
    /// Excel Tools
    /// </summary>
    public class AsposeExcelTools
    {
        public static bool DataTableInsertToExcel(DataTable datatable, ArrayList colNameList, string fromfile, out string error, int beginRow = 1, int beginColumn = 0)
        {
            error = "";
            if (datatable == null)
                throw new ArgumentNullException(nameof(datatable));
            if (datatable.Rows.Count == 0)
                return false;
            if (!File.Exists(fromfile))
                throw new ArgumentException(fromfile, string.Format("{0} 文件不存在", Path.GetFileName(fromfile)));

            int num = 0;
            var workbook = new Workbook(fromfile);
            var cells = workbook.Worksheets[0].Cells;
            foreach (DataRow dataRow in datatable.Rows)
            {
                try
                {
                    num++;
                    cells.InsertRow(beginRow);
                    for (int i = 0; i < colNameList.Count; i++)
                    {
                        string a = colNameList[i].ToString();
                        for (int j = 0; j < datatable.Columns.Count; j++)
                        {
                            if (a == datatable.Columns[j].ColumnName)
                            {
                                object v = dataRow[datatable.Columns[j].ColumnName];
                                cells[beginRow, beginColumn + i].PutValue(v);
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    error = error + " " + ex.Message;
                }
            }
            workbook.Save(fromfile);
            return true;
        }

        public static bool DataTableToExcel(DataTable datatable, string filepath, out string error)
        {
            error = "";
            if (datatable == null)
                throw new ArgumentNullException(nameof(datatable));
            if (datatable.Rows.Count == 0)
                return false;
            if (!File.Exists(filepath))
                throw new ArgumentException(filepath, string.Format("{0} 文件不存在", Path.GetFileName(filepath)));

            try
            {
                var workbook = new Workbook();
                var worksheet = workbook.Worksheets[0];
                Cells cells = worksheet.Cells;
                int num = 0;
                foreach (DataRow dataRow in datatable.Rows)
                {
                    try
                    {
                        num++;
                        for (int i = 0; i < datatable.Columns.Count; i++)
                        {
                            if (dataRow[i].GetType().ToString() == "System.Drawing.Bitmap")
                            {
                                Image image = (Image)dataRow[i];
                                MemoryStream stream = new MemoryStream();
                                image.Save(stream, ImageFormat.Jpeg);
                                worksheet.Pictures.Add(num, i, stream);
                            }
                            else
                            {
                                cells[num, i].PutValue(dataRow[i]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        error = error + " " + ex.Message;
                    }
                }
                workbook.Save(filepath);
                return true;
            }
            catch (Exception ex2)
            {
                error = error + " " + ex2.Message;
                return false;
            }
        }

        public static bool DataTableToExcel2(DataTable datatable, string filepath, out string error)
        {
            error = "";
            if (datatable == null)
                throw new ArgumentNullException(nameof(datatable));
            if (datatable.Rows.Count == 0)
                return false;
            if (!File.Exists(filepath))
                throw new ArgumentException(filepath, string.Format("{0} 文件不存在", Path.GetFileName(filepath)));

            try
            {
                var workbook = new Workbook();
                var style = workbook.CreateStyle();
                style.HorizontalAlignment = TextAlignmentType.Center;
                style.ForegroundColor = Color.FromArgb(153, 204, 0);
                style.Pattern = BackgroundType.Solid;
                style.Font.IsBold = true;
                int num = 0;
                for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    DataColumn dataColumn = datatable.Columns[i];
                    string stringValue = dataColumn.Caption ?? dataColumn.ColumnName;
                    workbook.Worksheets[0].Cells[num, i].PutValue(stringValue);
                    workbook.Worksheets[0].Cells[num, i].SetStyle(style);
                }
                num++;
                foreach (object obj in datatable.Rows)
                {
                    DataRow dataRow = (DataRow)obj;
                    for (int j = 0; j < datatable.Columns.Count; j++)
                    {
                        workbook.Worksheets[0].Cells[num, j].PutValue(dataRow[j].ToString());
                    }
                    num++;
                }
                for (int k = 0; k < datatable.Columns.Count; k++)
                {
                    workbook.Worksheets[0].AutoFitColumn(k, 0, 150);
                }
                workbook.Worksheets[0].FreezePanes(1, 0, 1, datatable.Columns.Count);
                workbook.Save(filepath);
                return true;
            }
            catch (Exception ex)
            {
                error = error + " " + ex.Message;
                return false;
            }
        }

        public static bool DataSetToExcel(DataSet dataset, string filepath, out string error)
        {
            return DataTableToExcel(dataset.Tables[0], filepath, out error);
        }

        public static bool ExcelFileToDataTable(string filepath, out DataTable datatable, out string error)
        {
            return ExcelFileToDataTable(filepath, out datatable, true, out error);
        }

        public static bool ExcelFileToDataTable(string filepath, out DataTable datatable, bool exportColumnName, out string error)
        {
            error = "";
            datatable = null;
            if (!File.Exists(filepath))
                throw new ArgumentException(filepath, string.Format("{0} 文件不存在", Path.GetFileName(filepath)));

            try
            {
                var workbook = new Workbook(filepath);
                var worksheet = workbook.Worksheets[0];
                datatable = worksheet.Cells.ExportDataTableAsString(0, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, exportColumnName);
                datatable.TableName = worksheet.Name;
                PictureCollection pictures = worksheet.Pictures;
                if (pictures.Count > 0)
                {
                    if (!InsertPicturesIntoDataTable(pictures, datatable, out datatable, out string str))
                        error += " " + str;
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public static bool ExcelFileToDataTables(string filepath, out DataTable[] datatables, out string error)
        {
            return ExcelFileToDataTables(filepath, out datatables, true, out error);
        }

        public static bool ExcelFileToDataTables(string filepath, out DataTable[] datatables, bool exportColumnName, out string error)
        {
            error = "";
            datatables = null;
            if (!File.Exists(filepath))
                throw new ArgumentException(filepath, string.Format("{0} 文件不存在", Path.GetFileName(filepath)));

            try
            {
                var workbook = new Workbook(filepath);
                int num = workbook.Worksheets.Count;
                datatables = new DataTable[num];
                for (int i = 0; i < num; i++)
                {
                    Worksheet worksheet = workbook.Worksheets[i];
                    try
                    {
                        datatables[i] = worksheet.Cells.ExportDataTableAsString(0, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, exportColumnName);
                        datatables[i].TableName = worksheet.Name;
                        PictureCollection pictures = worksheet.Pictures;
                        if (pictures.Count > 0)
                        {
                            if (!InsertPicturesIntoDataTable(pictures, datatables[i], out datatables[i], out string str))
                                error += " " + str;
                        }
                    }
                    catch (Exception ex)
                    {
                        error = " " + ex.Message;
                    }
                }
                return true;
            }
            catch (Exception ex2)
            {
                error = ex2.Message;
                return false;
            }
        }

        public static bool ExcelFileToDataTable(string filepath, out DataTable datatable, int iFirstRow, int iFirstCol, int rowNum, int colNum, bool exportColumnName, out string error)
        {
            error = "";
            datatable = null;
            if (!File.Exists(filepath))
                throw new ArgumentException(filepath, string.Format("{0} 文件不存在", Path.GetFileName(filepath)));

            try
            {
                var worksheet = new Workbook(filepath).Worksheets[0];
                datatable = worksheet.Cells.ExportDataTableAsString(iFirstRow, iFirstCol, rowNum + 1, colNum + 1, exportColumnName);
                datatable.TableName = worksheet.Name;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public static bool ExcelFileToDataSet(string filepath, out DataSet dataset, out string error)
        {
            dataset = new DataSet();
            if (ExcelFileToDataTables(filepath, out DataTable[] tables, out error))
            {
                dataset.Tables.AddRange(tables);
                return true;
            }
            return false;
        }

        public static bool GetPicturesFromExcelFile(string filepath, out PictureCollection[] pictures, out string error)
        {
            error = "";
            pictures = null;
            if (!File.Exists(filepath))
                throw new ArgumentException(filepath, string.Format("{0} 文件不存在", Path.GetFileName(filepath)));

            try
            {
                var workbook = new Workbook(filepath);
                pictures = new PictureCollection[workbook.Worksheets.Count];
                for (int i = 0; i < workbook.Worksheets.Count; i++)
                {
                    pictures[i] = workbook.Worksheets[i].Pictures;
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        private static bool InsertPicturesIntoDataTable(PictureCollection pictures, DataTable fromdatatable, out DataTable datatable, out string error)
        {
            error = "";
            datatable = fromdatatable;
            DataRow[] array = datatable.Select();
            foreach (Picture picture in pictures)
            {
                try
                {
                    Console.WriteLine(picture.GetType().ToString());
                    MemoryStream memoryStream = new MemoryStream();
                    memoryStream.Write(picture.Data, 0, picture.Data.Length);
                    Image value = Image.FromStream(memoryStream);
                    array[picture.UpperLeftRow][picture.UpperLeftColumn] = value;
                }
                catch (Exception ex)
                {
                    error = error + " " + ex.Message;
                }
            }
            return true;
        }

        public static bool ExcelFileToLists(string filepath, out IList[] lists, out string error)
        {
            lists = null;
            if (ExcelFileToDataTable(filepath, out DataTable dataTable, out error) && GetPicturesFromExcelFile(filepath, out PictureCollection[] array, out error))
            {
                IList[] array2 = new ArrayList[dataTable.Rows.Count];
                lists = array2;
                int num = 0;
                foreach (object obj in dataTable.Rows)
                {
                    DataRow dataRow = (DataRow)obj;
                    lists[num] = new ArrayList(dataTable.Columns.Count);
                    for (int i = 0; i <= dataTable.Columns.Count - 1; i++)
                    {
                        lists[num].Add(dataRow[i]);
                    }
                    num++;
                }
                for (int j = 0; j < array.Length; j++)
                {
                    foreach (Picture picture in array[j])
                    {
                        try
                        {
                            if (picture.UpperLeftRow <= dataTable.Rows.Count && picture.UpperLeftColumn <= dataTable.Columns.Count)
                            {
                                lists[picture.UpperLeftRow][picture.UpperLeftColumn] = picture.Data;
                            }
                        }
                        catch (Exception ex)
                        {
                            error += " " + ex.Message;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        public static bool ListsToExcelFile(string filepath, IList[] lists, out string error)
        {
            error = "";
            int num = 0;
            var workbook = new Workbook();
            var worksheet = workbook.Worksheets[0];
            var cells = worksheet.Cells;
            worksheet.Pictures.Clear();
            cells.Clear();
            foreach (IList list in lists)
            {
                for (int j = 0; j <= list.Count - 1; j++)
                {
                    try
                    {
                        string str = j.ToString();
                        string str2 = "  ";
                        Type type = list[j].GetType();
                        Console.WriteLine(str + str2 + ((type != null) ? type.ToString() : null));
                        if (list[j].GetType().ToString() == "System.Drawing.Bitmap")
                        {
                            Image image = (Image)list[j];
                            MemoryStream stream = new MemoryStream();
                            image.Save(stream, ImageFormat.Jpeg);
                            worksheet.Pictures.Add(num, j, stream);
                        }
                        else
                        {
                            cells[num, j].PutValue(list[j]);
                        }
                    }
                    catch (Exception ex)
                    {
                        error += " " + ex.Message;
                    }
                }
                num++;
            }
            workbook.Save(filepath);
            return true;
        }

        public static void ExportWithDataSource(string templateFile, string saveFileName, Dictionary<string, object> datasource)
        {
            if (!File.Exists(templateFile))
                throw new ArgumentException(templateFile, string.Format("{0} 文件不存在，", Path.GetFileName(templateFile)));

            var workbookDesigner = new WorkbookDesigner();
            workbookDesigner.Workbook = new Workbook(templateFile);
            foreach (string text in datasource.Keys)
            {
                workbookDesigner.SetDataSource(text, datasource[text]);
            }
            workbookDesigner.Process();
            workbookDesigner.Workbook.Save(saveFileName, SaveFormat.Excel97To2003);
        }

        public static void WebExportWithDataSource(string templateFile, string saveFileName, Dictionary<string, object> datasource)
        {
            var httpContext = HttpContext.Current;
            if (httpContext == null)
                return;

            string text = httpContext.Server.MapPath(templateFile);
            if (!File.Exists(text))
                throw new ArgumentException(templateFile, string.Format("{0} 文件不存在，", templateFile));

            var workbookDesigner = new WorkbookDesigner();
            workbookDesigner.Workbook = new Workbook(text);
            foreach (string text2 in datasource.Keys)
            {
                workbookDesigner.SetDataSource(text2, datasource[text2]);
            }
            workbookDesigner.Process();
            var response = httpContext.Response;
            workbookDesigner.Workbook.Save(response.OutputStream, SaveFormat.Excel97To2003);
            response.Charset = "GB2312";
            response.ContentEncoding = Encoding.GetEncoding("GB2312");
            response.ContentType = "application/ms-excel/msword";
            response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(saveFileName));
            response.Flush();
        }

        public static void ExportWithReplace(string templateFile, string saveFileName, Dictionary<string, string> dictReplace)
        {
            if (!File.Exists(templateFile))
                throw new ArgumentException(templateFile, string.Format("{0} 文件不存在，", Path.GetFileName(templateFile)));

            var workbookDesigner = new WorkbookDesigner();
            workbookDesigner.Workbook = new Workbook(templateFile);
            var worksheet = workbookDesigner.Workbook.Worksheets[0];
            foreach (string text in dictReplace.Keys)
            {
                worksheet.Replace(text, dictReplace[text]);
            }
            workbookDesigner.Process();
            workbookDesigner.Workbook.Save(saveFileName, SaveFormat.Excel97To2003);
        }

        public static void WebExportWithReplace(string templateFile, string saveFileName, Dictionary<string, string> dictReplace)
        {
            var httpContext = HttpContext.Current;
            if (httpContext == null)
                return;

            string text = httpContext.Server.MapPath(templateFile);
            if (!File.Exists(text))
                throw new ArgumentException(templateFile, string.Format("{0} 文件不存在，", templateFile));

            var workbookDesigner = new WorkbookDesigner();
            workbookDesigner.Workbook = new Workbook(text);
            var worksheet = workbookDesigner.Workbook.Worksheets[0];
            foreach (string text2 in dictReplace.Keys)
            {
                worksheet.Replace(text2, dictReplace[text2]);
            }
            workbookDesigner.Process();
            var response = httpContext.Response;
            workbookDesigner.Workbook.Save(response.OutputStream, SaveFormat.Excel97To2003);
            response.Charset = "GB2312";
            response.ContentEncoding = Encoding.GetEncoding("GB2312");
            response.ContentType = "application/ms-excel/msword";
            response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(saveFileName));
            response.Flush();
        }
    }
}

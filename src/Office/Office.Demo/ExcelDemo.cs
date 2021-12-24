using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace Office.Demo
{
    public class ExcelDemo
    {
        static readonly string dir = Environment.CurrentDirectory;
        static string templateFile = $"{dir}\\App_Data\\template2.xlsx";
        static string saveFileName = $"{dir}\\template2{DateTime.Now.Ticks}.xlsx";
        static string password = "123456";
        static IEnumerable<Hashtable> hashTables = new List<Hashtable>
        {
           new Hashtable{{"NO","1"},{"Name","王小武"},{"Sex","男"},{"Nation","汉"},{"Phone","12345"},{"IdCard","5110128"},{"Memo","无"}},
           new Hashtable{{"NO","2"},{"Name","李小露"},{"Sex","女"},{"Nation","汉"},{"Phone","12345"},{"IdCard","5110128"},{"Memo","无"}},
        };
        static Dictionary<string, string> columnHeaders = new Dictionary<string, string>
        {
            {"A1","NO"},{"B1","Name"},{"C1","Sex"},{"D1","Nation"},{"E1","Phone"},{"F1","IdCard"},{"G1","Memo"}
        };

        public static void TestSpireExcelExportWithList()
        {
            Console.WriteLine($"{nameof(TestSpireExcelExportWithList)} started.");
            var watch = Stopwatch.StartNew();
            Framework.SpireExcelTools.ExportWithList(templateFile, saveFileName, hashTables, columnHeaders, true, password);
            watch.Stop();
            Console.WriteLine($"{nameof(TestSpireExcelExportWithList)} finished. {watch.Elapsed} elapsed.");
        }

        public static void TestSpireExcelImport()
        {
            string sourceFileName = $"{dir}\\Backup\\1.xlsx";
            DirectoryInfo inputDir = new DirectoryInfo($"{dir}\\Backup\\input"), outputDir = new DirectoryInfo($"{dir}\\Backup\\output");
            if (!inputDir.Exists) inputDir.Create();
            if (!outputDir.Exists) outputDir.Create();

            int line = 1;
            DataSet ds = Framework.SpireExcelTools.GetDataSet(sourceFileName);
            DataTable dt = ds.Tables[0];
            Console.WriteLine($"表格共计 {dt.Rows.Count} 行");
            foreach (DataRow dr in dt.Rows)
            {
                string name = dr[0].ToString().Trim(), addr = dr[1].ToString().Trim();
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(addr)) continue;

                string fileName = $"{name}_结业证书.png";
                string path = Path.Combine(inputDir.FullName, fileName);
                FileInfo inputFile = new FileInfo(path);
                if (!inputFile.Exists) continue;
                //FileInfo[] inputFiles = inputDir.GetFiles($"{name}_结业证书.png");
                //if (inputFiles.Length == 0) continue;

                path = Path.Combine(outputDir.FullName, addr);
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                string destFileName = Path.Combine(path, inputFile.Name);
                File.Copy(inputFile.FullName, destFileName, true);

                Console.WriteLine($"{line++} {addr}/{fileName}");
            }
        }
    }
}

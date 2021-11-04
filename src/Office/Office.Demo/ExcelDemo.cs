using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

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
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Office.Demo
{
    public class WordDemo
    {
        static readonly string dir = Environment.CurrentDirectory;
        static string templateFile = $"{dir}\\App_Data\\template1.docx";
        static string saveFileName = $"{dir}\\template1{DateTime.Now.Ticks}.docx";
        static string password = "123456";
        static Dictionary<string, string> dictBookMark = new Dictionary<string, string>()
        {
            { "<Year>", DateTime.Now.ToString("yyyy") },
            { "Num", DateTime.Now.ToString("yyyyMMdd") },
            { "Names", "习福星" },
            { "Phone", "13012345678" },
        };

        public static void TestAsposeWordExportWithBookMark()
        {
            Console.WriteLine($"{nameof(TestAsposeWordExportWithBookMark)} started.");
            var watch = Stopwatch.StartNew();
            Framework.AsposeWordTools.ExportWithBookMark(templateFile, saveFileName, dictBookMark, password);
            watch.Stop();
            Console.WriteLine($"{nameof(TestAsposeWordExportWithBookMark)} finished. {watch.Elapsed} elapsed.");
        }

        public static void TestAsposeWordEncryptProtect()
        {
            Console.WriteLine($"{nameof(TestAsposeWordEncryptProtect)} started.");
            var watch = Stopwatch.StartNew();
            Framework.AsposeWordTools.EncryptProtect(templateFile, password, saveFileName, true, true);
            watch.Stop();
            Console.WriteLine($"{nameof(TestAsposeWordEncryptProtect)} finished. {watch.Elapsed} elapsed.");
        }

        public static void TestSpireWordExportWithBookMark()
        {
            Console.WriteLine($"{nameof(TestSpireWordExportWithBookMark)} started.");
            var watch = Stopwatch.StartNew();
            Framework.SpireWordTools.ExportWithBookMark(templateFile, saveFileName, dictBookMark, password);
            watch.Stop();
            Console.WriteLine($"{nameof(TestSpireWordExportWithBookMark)} finished. {watch.Elapsed} elapsed.");
        }

        public static void TestSpireWordEncryptProtect()
        {
            Console.WriteLine($"{nameof(TestSpireWordEncryptProtect)} started.");
            var watch = Stopwatch.StartNew();
            Framework.SpireWordTools.EncryptProtect(templateFile, password, saveFileName, true, true);
            watch.Stop();
            Console.WriteLine($"{nameof(TestSpireWordEncryptProtect)} finished. {watch.Elapsed} elapsed.");
        }

        public static void TestSpireWordImagePreview()
        {
            Console.WriteLine($"{nameof(TestSpireWordImagePreview)} started.");
            var watch = Stopwatch.StartNew();
            var images = Framework.SpireWordTools.ImagePreview(templateFile, "temp", "https://github.com/");
            watch.Stop();
            Console.WriteLine($"{nameof(TestSpireWordImagePreview)} finished. {watch.Elapsed} elapsed.");
            Console.WriteLine(string.Join(Environment.NewLine, images));
        }

        public static void TestSpireWordPdfPreview()
        {
            Console.WriteLine($"{nameof(TestSpireWordPdfPreview)} started.");
            var watch = Stopwatch.StartNew();
            var pdf = Framework.SpireWordTools.PdfPreview(templateFile, "temp", "https://github.com/");
            watch.Stop();
            Console.WriteLine($"{nameof(TestSpireWordPdfPreview)} finished. {watch.Elapsed} elapsed.");
            Console.WriteLine(string.Join(Environment.NewLine, pdf));
        }

        public static void TestSpireWordHtmlPreview()
        {
            Console.WriteLine($"{nameof(TestSpireWordHtmlPreview)} started.");
            var watch = Stopwatch.StartNew();
            var html = Framework.SpireWordTools.HtmlPreview(templateFile, "temp", "https://github.com/");
            watch.Stop();
            Console.WriteLine($"{nameof(TestSpireWordHtmlPreview)} finished. {watch.Elapsed} elapsed.");
            Console.WriteLine(string.Join(Environment.NewLine, html));
        }

        public static void TestDevExpressWordExportWithBookMark()
        {
            Console.WriteLine($"{nameof(TestDevExpressWordExportWithBookMark)} started.");
            var watch = Stopwatch.StartNew();
            Framework.DevExpressWordTools.ExportWithBookMark(templateFile, saveFileName, dictBookMark, password);
            watch.Stop();
            Console.WriteLine($"{nameof(TestDevExpressWordExportWithBookMark)} finished. {watch.Elapsed} elapsed.");
        }

        public static void TestDevExpressWordEncryptProtect()
        {
            Console.WriteLine($"{nameof(TestDevExpressWordEncryptProtect)} started.");
            var watch = Stopwatch.StartNew();
            Framework.DevExpressWordTools.EncryptProtect(templateFile, password, saveFileName, true, true);
            watch.Stop();
            Console.WriteLine($"{nameof(TestDevExpressWordEncryptProtect)} finished. {watch.Elapsed} elapsed.");
        }
    }
}

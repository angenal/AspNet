using System;

namespace Office
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo.WordDemo.TestAsposeWordExportWithBookMark();
            //Demo.WordDemo.TestAsposeWordEncryptProtect();

            //Demo.WordDemo.TestSpireWordExportWithBookMark();
            //Demo.WordDemo.TestSpireWordEncryptProtect();
            //Demo.WordDemo.TestSpireWordImagePreview();
            //Demo.WordDemo.TestSpireWordPdfPreview();
            //Demo.WordDemo.TestSpireWordHtmlPreview();

            //Demo.WordDemo.TestDevExpressWordExportWithBookMark();
            //Demo.WordDemo.TestDevExpressWordEncryptProtect();

            //Demo.ExcelDemo.TestSpireExcelExportWithList();
            Demo.ExcelDemo.TestSpireExcelImport();

            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }
    }
}

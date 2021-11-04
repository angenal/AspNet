using System;
using System.IO;
using GroupDocs.Conversion;
using GroupDocs.Conversion.Options.Convert;

namespace Office.Conversion.QuickStart
{
    /// <summary>
    /// This example demonstrates how to convert document to PDF.
    /// </summary>
    internal static class HelloWorld
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string convertedFile = Path.Combine(outputDirectory, "converted.pdf");
            
            using (Converter converter = new Converter(Constants.SAMPLE_DOCX))
            {
                PdfConvertOptions options = new PdfConvertOptions();
                converter.Convert(convertedFile, options);
            }

            Console.WriteLine($"\nSource document converted successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

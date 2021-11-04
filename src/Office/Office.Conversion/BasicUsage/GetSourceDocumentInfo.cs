using System;
using GroupDocs.Conversion;
using GroupDocs.Conversion.Contracts;

namespace Office.Conversion.BasicUsage
{
    /// <summary>
    /// This example demonstrates how to get basic information about source document.
    /// </summary>
    internal static class GetSourceDocumentInfo
    {
        public static void Run()
        {            
            using (Converter converter = new Converter(Constants.SAMPLE_PDF))
            {
                IDocumentInfo info = converter.GetDocumentInfo();

                PdfDocumentInfo pdfInfo = (PdfDocumentInfo) info;

                Console.WriteLine("Author: {0}", pdfInfo.Author);
                Console.WriteLine("Creation date: {0}", pdfInfo.CreationDate);
                Console.WriteLine("Title: {0}", pdfInfo.Title);
                Console.WriteLine("Version: {0}", pdfInfo.Version);
                Console.WriteLine("Pages count: {0}", pdfInfo.PagesCount);
                Console.WriteLine("Width: {0}", pdfInfo.Width);
                Console.WriteLine("Height: {0}", pdfInfo.Height);
                Console.WriteLine("Is landscaped: {0}", pdfInfo.IsLandscape);
                Console.WriteLine("Is Encrypted: {0}", pdfInfo.IsEncrypted);
            }

            Console.WriteLine("\nDocument info retrieved successfully.");
        }
    }
}

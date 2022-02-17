using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace Office.View.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingPdfDocuments
{
    /// <summary>
    /// This example demonstrates how to adjust the display of outline font when rendering PDF documents.
    /// </summary>
    class EnableFontHinting
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.png");

            using (Viewer viewer = new Viewer(Constants.HIEROGLYPHS_1_PDF))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);
                options.PdfOptions.EnableFontHinting = true;

                viewer.View(options, 1);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

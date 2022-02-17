using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace Office.View.BasicUsage.RenderDocumentToPdf
{
    /// <summary>
    /// This example demonstrates how to adjust quality of JPG images of the output PDF document.
    /// </summary>
    class AdjustQualityOfJpgImages
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string filePath = Path.Combine(outputDirectory, "output.pdf");

            using (Viewer viewer = new Viewer(Constants.JPG_IMAGE_PPTX))
            {               
                PdfViewOptions options = new PdfViewOptions(filePath);
                options.JpgQuality = 10;

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

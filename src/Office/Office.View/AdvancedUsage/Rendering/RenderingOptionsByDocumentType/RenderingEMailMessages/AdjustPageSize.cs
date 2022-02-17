using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace Office.View.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingEMailMessages
{
    /// <summary>
    /// This example demonstrates how to change page size when rendering email messages.
    /// </summary>
    class AdjustPageSize
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string filePath = Path.Combine(outputDirectory, "output.pdf");

            using (Viewer viewer = new Viewer(Constants.SAMPLE_MSG))
            {
                PdfViewOptions options = new PdfViewOptions(filePath);
                options.EmailOptions.PageSize = PageSize.A4;

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

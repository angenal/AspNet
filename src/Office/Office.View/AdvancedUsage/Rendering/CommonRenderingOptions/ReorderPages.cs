using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace Office.View.AdvancedUsage.Rendering.CommonRenderingOptions
{
    /// <summary>
    /// This example demonstrates how to reorder pages in the output PDF document.
    /// </summary>
    class ReorderPages
    {
        public static void Run()
        {                       
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFilePath = Path.Combine(outputDirectory, "output.pdf");

            using (Viewer viewer = new Viewer(Constants.SAMPLE_DOCX))
            {
                PdfViewOptions options = new PdfViewOptions(outputFilePath);

                // Pass page numbers in the order you want to render them
                viewer.View(options, 2, 1);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

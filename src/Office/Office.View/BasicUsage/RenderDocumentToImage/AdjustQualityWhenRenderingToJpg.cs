using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace Office.View.BasicUsage.RenderDocumentToImage
{
    /// <summary>
    /// This example demonstrates how to adjust quality of the output JPG image.
    /// </summary>
    class AdjustQualityWhenRenderingToJpg
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.jpg");

            using (Viewer viewer = new Viewer(Constants.SAMPLE_DOCX))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);
                options.Quality = 50;

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

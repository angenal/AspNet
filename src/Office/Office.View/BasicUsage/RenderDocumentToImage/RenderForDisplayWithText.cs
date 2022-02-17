using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace Office.View.BasicUsage.RenderDocumentToImage
{
    /// <summary>
    /// This example demonstrates how to render document so extracted text may be placed as top layer over the image.
    /// </summary>
    class RenderForDisplayWithText
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.png");

            using (Viewer viewer = new Viewer(Constants.SAMPLE_DOCX))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);
                options.ExtractText = true;

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

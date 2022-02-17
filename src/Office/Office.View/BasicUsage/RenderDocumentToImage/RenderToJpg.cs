using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace Office.View.BasicUsage.RenderDocumentToImage
{
    /// <summary>
    /// This example demonstrates how to render document into JPG image.
    /// </summary>
    class RenderToJpg
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.jpg");

            using (Viewer viewer = new Viewer(Constants.SAMPLE_DOCX))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

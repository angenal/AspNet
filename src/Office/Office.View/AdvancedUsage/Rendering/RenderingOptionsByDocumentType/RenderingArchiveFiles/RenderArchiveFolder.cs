using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace Office.View.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingArchiveFiles
{
    /// <summary>
    /// This example demonstrates how to render folder of archive file.
    /// </summary>
    class RenderArchiveFolder
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            using (Viewer viewer = new Viewer(Constants.SAMPLE_ZIP_WITH_FOLDERS))
            {              
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                options.ArchiveOptions.Folder = "ThirdFolderWithItems";

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

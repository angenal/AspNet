using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace Office.View.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingSpreadsheets
{
    /// <summary>
    /// This example demonstrates how to split worksheet(s) into page(s).
    /// </summary>
    class SplitWorksheetsIntoPages
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");
            int countRowsPerPage = 45;

            using (Viewer viewer = new Viewer(Constants.SAMPLE_XLSX))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                options.SpreadsheetOptions = SpreadsheetOptions.ForSplitSheetIntoPages(countRowsPerPage);

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

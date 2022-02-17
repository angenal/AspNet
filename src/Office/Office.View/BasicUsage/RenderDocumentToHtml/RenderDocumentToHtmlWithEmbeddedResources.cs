using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace Office.View.BasicUsage.RenderDocumentToHtml
{
    /// <summary>
    /// This example demonstrates how to render document into HTML with embedded resources.
    /// </summary>
    class RenderToHtmlWithEmbeddedResources
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            using (Viewer viewer = new Viewer(Constants.SAMPLE_DOCX))
            {                
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);    
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in: {outputDirectory}");
        }
    }
}

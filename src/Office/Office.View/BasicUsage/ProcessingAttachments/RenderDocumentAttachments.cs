using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace Office.View.BasicUsage.ProcessingAttachments
{
    /// <summary>
    /// This example demonstrates how to render attachment into HTML.
    /// </summary>
    class RenderDocumentAttachments
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");
            MemoryStream attachmentStream = new MemoryStream();
            
            using (Viewer viewer = new Viewer(Constants.SAMPLE_MSG_WITH_ATTACHMENTS))
                viewer.SaveAttachment("attachment-word.doc", attachmentStream); 

            using (Viewer viewer = new Viewer(() => attachmentStream))
            {
                HtmlViewOptions options =
                    HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);
            }

            Console.WriteLine($"\nAttachment rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

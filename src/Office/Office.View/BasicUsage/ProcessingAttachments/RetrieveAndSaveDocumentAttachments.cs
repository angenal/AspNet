using GroupDocs.Viewer;
using GroupDocs.Viewer.Results;
using System;
using System.Collections.Generic;
using System.IO;

namespace Office.View.BasicUsage.ProcessingAttachments
{
    /// <summary>
    /// This example demonstrates how to retrieve and save attachments.
    /// </summary>
    class RetrieveAndSaveDocumentAttachments
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();

            using (Viewer viewer = new Viewer(Constants.SAMPLE_MSG_WITH_ATTACHMENTS))
            {
                IList<Attachment> attachments = viewer.GetAttachments();
                foreach(Attachment attachment in attachments)
                {
                    string filePath = Path.Combine(outputDirectory, attachment.FileName);  
                    viewer.SaveAttachment(attachment.Id, File.OpenWrite(filePath)); 
                }
            }

            Console.WriteLine($"\nAttachments saved successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

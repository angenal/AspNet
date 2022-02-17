using GroupDocs.Viewer;
using GroupDocs.Viewer.Results;
using System;
using System.Collections.Generic;

namespace Office.View.BasicUsage.ProcessingAttachments
{
    /// <summary>
    /// This example demonstrates how to retrieve and print all attachments.
    /// </summary>
    class RetrieveAndPrintDocumentAttachments
    {
        public static void Run()
        {
            using (Viewer viewer = new Viewer(Constants.SAMPLE_MSG_WITH_ATTACHMENTS))
            {
                IList<Attachment> attachments = viewer.GetAttachments();

                Console.WriteLine("\nAttachments:");
                foreach(Attachment attachment in attachments)
                    Console.WriteLine(attachment);
            }

            Console.WriteLine($"\nAttachments retrieved successfully.");
        }
    }
}

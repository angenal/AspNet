using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using System;

namespace Office.View.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingMsProjectDocuments
{
    /// <summary>
    /// This example demonstrates how to get view info for MS Project document.
    /// </summary>
    class GetViewInfoForProjectDocument
    {
        public static void Run()
        {
            using (Viewer viewer = new Viewer(Constants.SAMPLE_MPP))
            {
                ProjectManagementViewInfo info = viewer.GetViewInfo(
                    ViewInfoOptions.ForHtmlView()) as ProjectManagementViewInfo;

                Console.WriteLine("Document type is: " + info.FileType);
                Console.WriteLine("Pages count: " + info.Pages.Count);
                Console.WriteLine("Project start date: {0}", info.StartDate);
                Console.WriteLine("Project end date: {0}", info.EndDate);                
            }

            Console.WriteLine("\nView info retrieved successfully.");
        }
    }
}

using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using System;

namespace Office.View.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingOutlookDataFiles
{
    /// <summary>
    /// This example demonstrates how to get view info for Outlook data file.
    /// </summary>
    class GetViewInfoForOutlookDataFile
    {
        public static void Run()
        {
            using (Viewer viewer = new Viewer(Constants.SAMPLE_OST_SUBFOLDERS))
            {
                ViewInfoOptions options = ViewInfoOptions.ForHtmlView();
                OutlookViewInfo rootFolderInfo = viewer.GetViewInfo(options)
                    as OutlookViewInfo;

                Console.WriteLine("File type is: " + rootFolderInfo.FileType);
                Console.WriteLine("Pages count: " + rootFolderInfo.Pages.Count);

                foreach (string folder in rootFolderInfo.Folders)
                    Console.WriteLine(folder);
            }

            Console.WriteLine("\nView info retrieved successfully.");
        }
    }
}

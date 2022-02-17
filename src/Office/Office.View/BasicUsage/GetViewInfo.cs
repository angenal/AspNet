using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using System;

namespace Office.View.BasicUsage
{
    /// <summary>
    /// This example demonstrates how to get basic information about document and document view.
    /// </summary>
    class GetViewInfo
    {
        public static void Run()
        {            
            using (Viewer viewer = new Viewer(Constants.SAMPLE_PDF))
            {
                ViewInfo info = viewer.GetViewInfo(ViewInfoOptions.ForHtmlView());

                Console.WriteLine(info);
            }

            Console.WriteLine("\nView info retrieved successfully.");
        }
    }
}

using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using System;

namespace Office.View.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingCadDrawings
{
    /// <summary>
    /// Get list of all layouts and layers of a CAD drawing
    /// </summary>
    class GetViewInfoForCadDrawing
    {
        public static void Run()
        {
            using (Viewer viewer = new Viewer(Constants.SAMPLE_DWG_WITH_LAYOUTS_AND_LAYERS))
            {
                CadViewInfo info = viewer.GetViewInfo(
                    ViewInfoOptions.ForHtmlView()) as CadViewInfo;

                Console.WriteLine("Document type is: " + info.FileType);
                Console.WriteLine("Pages count: " + info.Pages.Count);

                foreach (Layout layout in info.Layouts)
                    Console.WriteLine(layout);

                foreach (Layer layer in info.Layers)
                    Console.WriteLine(layer);
            }

            Console.WriteLine("\nCAD info obtained successfully.");
        }
    }
}

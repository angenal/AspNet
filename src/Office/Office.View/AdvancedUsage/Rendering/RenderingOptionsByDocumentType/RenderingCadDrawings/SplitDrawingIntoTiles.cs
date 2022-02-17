using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace Office.View.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingCadDrawings
{
    /// <summary>
    /// This example demonstrates how to split drawing into tiles.
    /// </summary>
    class SplitDrawingIntoTiles
    { 
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.png");

            using (Viewer viewer = new Viewer(Constants.SAMPLE_DWG_WITH_LAYOUTS_AND_LAYERS))
            {                
                ViewInfoOptions infoOptions = ViewInfoOptions.ForPngView(false);
                var viewInfo = viewer.GetViewInfo(infoOptions);
                
                // Get width and height
                int width = viewInfo.Pages[0].Width;
                int height = viewInfo.Pages[0].Height;
                
                // Set tile width and height as a half of image total width
                int tileWidth = width / 2;
                int tileHeight = height / 2;

                int pointX = 0;
                int pointY = 0;
                
                //Create image options and add four tiles, one for each quarter
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);

                Tile tile = new Tile(pointX, pointY, tileWidth, tileHeight);
                options.CadOptions.Tiles.Add(tile);

                pointX += tileWidth;
                tile = new Tile(pointX, pointY, tileWidth, tileHeight);
                options.CadOptions.Tiles.Add(tile);

                pointX = 0;
                pointY += tileHeight;
                tile = new Tile(pointX, pointY, tileWidth, tileHeight);
                options.CadOptions.Tiles.Add(tile);

                pointX += tileWidth;
                tile = new Tile(pointX, pointY, tileWidth, tileHeight);
                options.CadOptions.Tiles.Add(tile);
                                
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

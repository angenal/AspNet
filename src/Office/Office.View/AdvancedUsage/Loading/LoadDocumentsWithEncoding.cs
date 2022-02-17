using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using System;
using System.IO;
using System.Text;

namespace Office.View.AdvancedUsage.Loading
{
    /// <summary>
    /// This example demonstrates how to specify encoding.
    /// </summary>
    class LoadDocumentsWithEncoding
    {
        public static void Run()
        {
            string filePath = Constants.SAMPLE_TXT_SHIFT_JS_ENCODED;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            GroupDocs.Viewer.Common.Func<LoadOptions> loadOptions = () => 
                new LoadOptions{ FileType = FileType.TXT, Encoding = Encoding.GetEncoding("shift_jis") };

            using (Viewer viewer = new Viewer(filePath, loadOptions))
            {
                HtmlViewOptions options = 
                    HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

using System;
using System.IO;
using GroupDocs.Conversion;
using GroupDocs.Conversion.Options.Convert;
using GroupDocs.Conversion.Options.Load;

namespace Office.Conversion.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates how to convert an email document to pdf with advanced options
    /// </summary>
    internal static class ConvertEmailWithAlteringFieldsVisibility
    {
        public static void Run()
        {
            string outputFolder = Constants.GetOutputDirectoryPath();
            string outputFile = Path.Combine(outputFolder, "converted.pdf");

            GroupDocs.Conversion.Contracts.Func<LoadOptions> getLoadOptions = () => new EmailLoadOptions
            {
                DisplayHeader = false,
                DisplayFromEmailAddress = false,
                DisplayToEmailAddress = false,
                DisplayEmailAddress = false,
                DisplayCcEmailAddress = false,
                DisplayBccEmailAddress = false
            };
            
            using (Converter converter = new Converter(Constants.SAMPLE_MSG, getLoadOptions))
            {
                PdfConvertOptions options = new PdfConvertOptions();
                converter.Convert(outputFile, options);
            }

            Console.WriteLine("\nEmail document converted successfully. \nCheck output in {0}", outputFolder);
        }
    }
}

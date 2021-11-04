using System;
using System.Diagnostics;
using System.IO;
using GroupDocs.Conversion;
using GroupDocs.Conversion.Options.Convert;
using GroupDocs.Conversion.Caching;

namespace Office.Conversion.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates how to enable cache when convert document.
    /// </summary>
    class UseCacheWhenProcessingDocuments
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string cachePath = Path.Combine(outputDirectory, "cache");
            
            FileCache cache = new FileCache(cachePath);
            GroupDocs.Conversion.Contracts.Func<ConverterSettings> settingsFactory = () => new ConverterSettings
            {
                Cache = cache
            };

            using (Converter converter = new Converter(Constants.SAMPLE_DOCX, settingsFactory))
            {
                PdfConvertOptions options = new PdfConvertOptions();

                Stopwatch stopWatch = Stopwatch.StartNew();
                converter.Convert("converted.pdf", options);
                stopWatch.Stop();

                Console.WriteLine("Time taken on first call to Convert method {0} (ms).", stopWatch.ElapsedMilliseconds);

                stopWatch.Restart();
                converter.Convert("converted-1.pdf", options);
                stopWatch.Stop();

                Console.WriteLine("Time taken on second call to Convert method {0} (ms).", stopWatch.ElapsedMilliseconds);
            }

            Console.WriteLine($"\nSource document converted successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

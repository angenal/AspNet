using Office.Conversion.QuickStart;
using System;
using System.IO;

namespace Office.Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            //SetMeteredLicense.Run();
            Licenses.Autoload();
            Console.WriteLine("Autoload product licenses.");
            if (Directory.Exists(Constants.OutputPath)) Directory.CreateDirectory(Constants.OutputPath);

            #region Quick Start

            HelloWorld.Run();

            #endregion

            #region Basic Usage

            // GetPossibleConversions.Run();
            // GetSourceDocumentInfo.Run();

            #region Convert document to HTML

            // ConvertToHtml.Run();

            #endregion

            #region Convert document to Image

            // ConvertToJpg.Run();
            // ConvertToPng.Run();
            // ConvertToPsd.Run();

            #endregion

            #region Convert document to PDF

            // ConvertToPdf.Run();

            #endregion

            #region Convert document to Presentation

            // ConvertToPresentation.Run();

            #endregion

            #region Convert document to Spreadsheet

            // ConvertToSpreadsheet.Run();

            #endregion

            #region Convert document to WordProcessing

            // ConvertToWordProcessing.Run();

            #endregion

            #endregion

            #region Advanced Usage

            #region Common rendering options


            // AddWatermark.Run();
            // ConvertSpecificPages.Run();

            #endregion

            #region Loading

            // LoadPasswordProtectedDocument.Run();

            #region Loading documents from different sources

            // LoadDocumentFromLocalDisk.Run();
            // LoadDocumentFromStream.Run();
            // LoadDocumentFromUrl.Run();
            // LoadDocumentFromFtp.Run();
            // LoadDocumentFromAmazonS3.Run();
            // LoadDocumentFromAzureBlobStorage.Run();

            #endregion

            #region Load options by document type

            #region Cad

            // ConvertCadAndSpecifyLayouts.Run();
            // ConvertCadAndSpecifyWidthAndHeight.Run();

            #endregion

            #region Csv

            // ConvertCsvByConvertingDateTimeAndNumericData.Run();
            // ConvertCsvBySpecifyingDelimiter.Run();
            // ConvertCsvBySpecifyingEncoding.Run();

            #endregion

            #region Email

            // ConvertEmailWithAlteringFieldsVisibility.Run();
            // ConvertEmailWithTimezoneOffset.Run();

            #endregion

            #region Note

            // ConvertNoteBySpecifyingFontSubstitution.Run();

            #endregion

            #region Pdf

            // ConvertPdfAndFlattenAllFields.Run();
            // ConvertPdfAndHideAnnotations.Run();
            // ConvertPdfAndRemoveEmbeddedFiles.Run();

            #endregion

            #region Presentation

            // ConvertPresentationByHiddingComments.Run();
            // ConvertPresentationBySpecifyingFontSubstitution.Run();
            // ConvertPresentationWithHiddenSlidesIncluded.Run();

            #endregion

            #region Spreadsheet

            // ConvertSpreadsheetAndHideComments.Run();
            // ConvertSpreadsheetByShowingGridLines.Run();
            // ConvertSpreadsheetBySkippingEmptyRowsAndColumns.Run();
            // ConvertSpreadsheetBySpecifyingFontsubstitution.Run();
            // ConvertSpreadsheetBySpecifyingRange.Run();
            // ConvertSpreadsheetWithHiddenSheetsIncluded.Run();

            #endregion

            #region WordProcessing

            // ConvertWordProcessingByHiddingComments.Run();
            // ConvertWordProcessingByHiddingTrackedChanges.Run();
            // ConvertWordProcessingBySpecifyingFontSubstitution.Run();

            #endregion

            #endregion

            #endregion

            // ConvertToHtmlWithAdvancedOptions.Run();
            // ConvertToImageWithAdvancedOptions.Run();
            // ConvertToPdfWithAdvancedOptions.Run();
            // ConvertToPresentationWithAdvancedOptions.Run();
            // ConvertToSpreadsheetWithAdvancedOptions.Run();
            // ConvertToWordProcessingWithAdvancedOptions.Run();

            // ListenConversionStateAndProgress.Run();

            #endregion

            Console.WriteLine();
            Console.WriteLine("All done.");
            Console.ReadKey();
        }
    }
}

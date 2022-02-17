using Office.View.QuickStart;
using System;
using System.IO;

namespace Office.View
{
    class Program
    {
        static void Main(string[] args)
        {
            Licenses.Autoload();
            Console.WriteLine("Autoload product licenses.");
            if (Directory.Exists(Constants.OutputPath)) Directory.CreateDirectory(Constants.OutputPath);

            #region Quick Start

            HelloWorld.Run();

            #endregion

            #region Basic Usage

            //GetSupportedFileFormats.Run();
            //GetViewInfo.Run();

            #region Processing attachments

            //RetrieveAndPrintDocumentAttachments.Run();
            //RetrieveAndSaveDocumentAttachments.Run();
            //RenderDocumentAttachments.Run();

            #endregion

            #region Render document to HTML

            //RenderToHtmlWithEmbeddedResources.Run();
            //RenderToHtmlWithExternalResources.Run();
            //
            //ExcludingFontsFromOutputHtml.Run();
            //MinifyHtmlDocument.Run();
            //RenderToResponsiveHtml.Run();

            #endregion

            #region Render document to Image

            //RenderToPng.Run();
            //RenderToJpg.Run();
            //
            //GetTextCoordinates.Run();
            //RenderForDisplayWithText.Run();
            //AdjustQualityWhenRenderingToJpg.Run();
            //AdjustImageSize.Run();

            #endregion

            #region Render document to PDF

            //RenderToPdf.Run();

            //AdjustQualityOfJpgImages.Run();
            //ProtectPdfDocument.Run();

            #endregion

            #endregion

            #region Advanced Usage

            #region Common rendering options

            //AddWatermark.Run();
            //RenderDocumentWithComments.Run();
            //RenderDocumentWithNotes.Run();
            //RenderHiddenPages.Run();
            //RenderNConsecutivePages.Run();
            //RenderSelectedPages.Run();
            //ReplaceMissingFont.Run();
            //ReorderPages.Run();
            //RenderWithCustomFonts.Run();

            #endregion

            #region Rendering options by document type

            #region Rendering Archive Files

            //GetViewInfoForArchiveFile.Run();
            //RenderArchiveFolder.Run();

            #endregion

            #region Rendering CAD Drawings

            //GetViewInfoForCadDrawing.Run();
            //RenderAllLayouts.Run();
            //RenderLayers.Run();
            //RenderSingleLayout.Run();
            //SplitDrawingIntoTiles.Run();
            //AdjustOutputImageSize.Run();

            #endregion

            #region Rendering E-Mail Messages

            //AdjustPageSize.Run();
            //RenameEmailFields.Run();

            #endregion

            #region Rendering Outlook Data Files

            //FilterMessages.Run();
            //GetViewInfoForOutlookDataFile.Run();
            //LimitCountOfItemsToRender.Run();
            //RenderOutlookDataFileFolder.Run();

            #endregion

            #region Rendering PDF Documents

            //DisableCharactersGrouping.Run();
            //EnableFontHinting.Run();
            //GetViewInfoForPdfDocument.Run();
            //AdjustImageQuality.Run();
            //EnableLayeredRendering.Run();

            #endregion

            #region Rendering MS Project Documents

            //AdjustTimeUnit.Run();
            //GetViewInfoForProjectDocument.Run();
            //RenderProjectTimeInterval.Run();

            #endregion

            #region Rendering Spreadsheets

            //AdjustTextOverflowInCells.Run();
            //RenderGridLines.Run();
            //RenderHiddenRowsAndColumns.Run();
            //RenderPrintAreas.Run();
            //SkipRenderingOfEmptyColumns.Run();
            //SkipRenderingOfEmptyRows.Run();
            //SplitWorksheetsIntoPages.Run();

            #endregion

            #region Rendering Word Processing Documents

            //RenderTrackedChanges.Run();

            #endregion

            #endregion

            #region Caching

            //UseCacheWhenProcessingDocuments.Run();
            //HowToUseCustomCacheImplementation.Run();

            #endregion

            #region Loading

            //LoadPasswordProtectedDocument.Run();
            //LoadDocumentsWithEncoding.Run();
            //SpecifyFileTypeWhenLoadingDocument.Run();

            #region Loading documents from different sources

            //LoadDocumentFromLocalDisk.Run();
            //LoadDocumentFromStream.Run();
            //LoadDocumentFromUrl.Run();
            //LoadDocumentFromFtp.Run();
            //LoadDocumentFromAmazonS3.Run();
            //LoadDocumentFromAzureBlobStorage.Run();

            #endregion

            #endregion

            #endregion

            Console.WriteLine();
            Console.WriteLine("All done.");
            Console.ReadKey();
        }
    }
}

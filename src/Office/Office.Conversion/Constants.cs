using System.IO;
using System.Runtime.CompilerServices;

namespace Office.Conversion
{
    internal static class Constants
    {
        public const string SamplesPath = "../Resources/SampleFiles";
        public const string FontsPath = "../Resources/Fonts";
        public const string OutputPath = "Output/";
        
        // CAD
        public static string SAMPLE_DWG_WITH_LAYOUTS_AND_LAYERS => 
            GetSampleFilePath("with_layers_and_layouts.dwg");

        // Diagrams
        public static string SAMPLE_VSDX => 
            GetSampleFilePath("sample.vsdx");
        
        // Email messages
        public static string SAMPLE_MSG => 
            GetSampleFilePath("sample.msg");
        public static string SAMPLE_MSG_WITH_ATTACHMENTS => 
            GetSampleFilePath("with_attachments.msg");
        public static string SAMPLE_OST => 
            GetSampleFilePath("sample.ost");
        public static string SAMPLE_OST_SUBFOLDERS => 
            GetSampleFilePath("with_subfolders.ost");

        // Note
        public static string SAMPLE_ONE =>
            GetSampleFilePath("sample.one");

        // PDFs
        public static string SAMPLE_PDF => 
            GetSampleFilePath("sample.pdf");
        public static string SAMPLE_PDF_WITH_PASSWORD => 
            GetSampleFilePath("sample_with_password.pdf");
        public static string HIEROGLYPHS_PDF => 
            GetSampleFilePath("hieroglyphs.pdf");
        public static string HIEROGLYPHS_1_PDF => 
            GetSampleFilePath("hieroglyphs_1.pdf");
        
        // Presentations
        public static string PPTX_WITH_NOTES => 
            GetSampleFilePath("with_notes.pptx");
        public static string SAMPLE_PPTX_HIDDEN_PAGE =>
            GetSampleFilePath("with_hidden_page.pptx");
        public static string MISSING_FONT_PPTX =>
            GetSampleFilePath("with_missing_font.pptx");
        public static string JPG_IMAGE_PPTX =>
            GetSampleFilePath("with_jpg_image.pptx");

        // Project Management documents
        public static string SAMPLE_MPP => 
            GetSampleFilePath("sample.mpp");

        // Spreadsheets
        public static string SAMPLE_XLSX => 
            GetSampleFilePath("sample.xlsx");
        public static string SAMPLE_XLSX_WITH_PRINT_AREAS => 
            GetSampleFilePath("with_four_print_areas.xlsx");        
        public static string SAMPLE_XLSX_WITH_EMPTY_COLUMN => 
            GetSampleFilePath("with_empty_column.xlsx");        
        public static string SAMPLE_XLSX_WITH_EMPTY_ROW => 
            GetSampleFilePath("with_empty_row.xlsx");
        public static string SAMPLE_XLSX_WITH_HIDDEN_ROW_AND_COLUMN => 
            GetSampleFilePath("with_hidden_row_and_column.xlsx");
        public static string SAMPLE_XLSX_WITH_TEXT_OVERFLOW =>
            GetSampleFilePath("with_overflowing_text.xlsx");
        public static string SAMPLE_XLSX_WITH_HIDDEN_SHEET =>
            GetSampleFilePath("with_hidden_sheet.xlsx");
        public static string SAMPLE_CSV =>
            GetSampleFilePath("sample.csv");

        // Email documents
        public static string SAMPLE_EML =>
            GetSampleFilePath("sample.eml");

        // Word Processing documents
        public static string SAMPLE_DOCX => 
            GetSampleFilePath("sample.docx");
        public static string SAMPLE_DOCX_WITH_COMMENT => 
            GetSampleFilePath("with_comment.docx");
        public static string SAMPLE_DOCX_WITH_PASSWORD => 
            GetSampleFilePath("password_protected.docx");
        public static string SAMPLE_DOCX_WITH_TRACKED_CHANGES => 
            GetSampleFilePath("with_tracked_changes.docx");
        public static string SAMPLE_TXT =>
            GetSampleFilePath("sample.txt");
        public static string SAMPLE_TXT_SHIFT_JS_ENCODED =>
            GetSampleFilePath("shift_jis_encoded.txt");

        // Images
        public static string MISSING_FONT_ODG =>
            GetSampleFilePath("with_missing_font.odg");

        private static string GetSampleFilePath(string filePath) =>
            Path.Combine(SamplesPath, filePath);

        public static string GetOutputDirectoryPath([CallerFilePath] string callerFilePath = null)
        {
            string outputDirectory = Path.Combine(OutputPath, Path.GetFileNameWithoutExtension(callerFilePath));

            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            return outputDirectory;
        }
    }
}

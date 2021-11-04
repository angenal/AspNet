using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using EO.Pdf;

namespace EOPDFDemo.Demos.WithExistingFiles
{
    public class Merge : Demo
    {
        public Merge(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Get the file names
            string filePath1 = args.GetString("txtFile1").Trim();
            if ((filePath1 == string.Empty) ||
                !File.Exists(filePath1))
                return "Please enter a valid PDF file path for the first file to be merged.";
            string filePath2 = args.GetString("txtFile2").Trim();
            if ((filePath1 == string.Empty) ||
                !File.Exists(filePath1))
                return "Please enter a valid PDF file path for the second file to be merged.";

            //Load the PDF files
            PdfDocument doc1 = new PdfDocument(filePath1);
            PdfDocument doc2 = new PdfDocument(filePath2);

            //Merge the files
            PdfDocument doc = PdfDocument.Merge(doc1, doc2);

            //You are also free to modify the merged document
            PdfPage page = doc.Pages.Add();
            HtmlToPdf.ConvertHtml("This is the merged version.", page);

            //Save the result
            doc.Save(result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Load the PDF files</span>
PdfDocument doc1 = <span class='kwd'>new</span> PdfDocument(filePath1);
PdfDocument doc2 = <span class='kwd'>new</span> PdfDocument(filePath2);

<span class='cmt'>//Merge the files</span>
PdfDocument doc = PdfDocument.Merge(doc1, doc2);

<span class='cmt'>//You are also free to modify the merged document</span>
PdfPage page = doc.Pages.Add();
HtmlToPdf.ConvertHtml(<span class='st'>&quot;This is the merged version.&quot;</span>, page);

<span class='cmt'>//Save the result</span>
doc.Save(result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Load the PDF files</span>
<span class='kwd'>Dim</span> doc1 <span class='kwd'>As New</span> PdfDocument(filePath1)
<span class='kwd'>Dim</span> doc2 <span class='kwd'>As New</span> PdfDocument(filePath2)

<span class='cmt'>'Merge the files</span>
<span class='kwd'>Dim</span> doc <span class='kwd'>As</span> PdfDocument = PdfDocument.Merge(doc1, doc2)

<span class='cmt'>'You are also free to modify the merged document</span>
<span class='kwd'>Dim</span> page <span class='kwd'>As</span> PdfPage = doc.Pages.Add()
HtmlToPdf.ConvertHtml(<span class='st'>&quot;This is the merged version.&quot;</span>, page)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }
    }
}

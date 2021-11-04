using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using EO.Pdf;

namespace EOPDFDemo.Demos.WithExistingFiles
{
    public class ExtractPages : Demo
    {
        public ExtractPages(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Get the file name
            string filePath = args.GetString("txtFileName").Trim();
            if (filePath == string.Empty)
                return "Please enter a valid file name.";
            if (!File.Exists(filePath))
                return "The specified PDF file does not exist.";

            //Get the from page index and page count
            int fromPage = -1;
            int pageCount = -1;
            try
            {
                fromPage = int.Parse(args.GetString("txtFrom"), CultureInfo.InvariantCulture);
                pageCount = int.Parse(args.GetString("txtCount"), CultureInfo.InvariantCulture);
            }
            catch
            {
                return "Either the from page index or the page count is invalid.";
            }

            //Load the PDF file
            PdfDocument doc = new PdfDocument(filePath);

            //Check page index range
            if ((fromPage < 0) ||
                (fromPage >= doc.Pages.Count))
                return string.Format("From page index must be between 0 and {0}.", doc.Pages.Count - 1);

            //If page count is invalid, then extract
            //till the last page
            if ((pageCount < 0) ||
                (fromPage + pageCount > doc.Pages.Count))
                pageCount = -1;

            //Create a new PdfDocument object that only
            //contains the pages to be extracted
            PdfDocument doc2 = doc.Clone(fromPage, pageCount);

            //Save the new PdfDocument. This document
            //will only contain the specified pages
            doc2.Save(result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Load the PDF file</span>
PdfDocument doc = <span class='kwd'>new</span> PdfDocument(filePath);

<span class='cmt'>//Check page index range</span>
<span class='kwd'>if</span> ((fromPage < 0) ||
    (fromPage >= doc.Pages.Count))
    <span class='kwd'>return string</span>.Format(<span class='st'>&quot;From page index must be between 0 and {0}.&quot;</span>, doc.Pages.Count - 1);

<span class='cmt'>//If page count is invalid, then extract
//till the last page</span>
<span class='kwd'>if</span> ((pageCount < 0) ||
    (fromPage + pageCount > doc.Pages.Count))
    pageCount = -1;

<span class='cmt'>//Create a new PdfDocument object that only
//contains the pages to be extracted</span>
PdfDocument doc2 = doc.Clone(fromPage, pageCount);

<span class='cmt'>//Save the new PdfDocument. This document
//will only contain the specified pages</span>
doc2.Save(result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Load the PDF file</span>
<span class='kwd'>Dim</span> doc <span class='kwd'>As New</span> PdfDocument(filePath)

<span class='cmt'>'Check page index range</span>
<span class='kwd'>If</span> (fromPage &lt; 0) <span class='kwd'>OrElse</span> (fromPage &gt;= doc.Pages.Count) <span class='kwd'>Then
    Return String</span>.Format(<span class='st'>&quot;From page index must be between 0 and {0}.&quot;</span>, doc.Pages.Count - 1)
<span class='kwd'>End If</span>

<span class='cmt'>'If page count is invalid, then extract
'till the last page</span>
<span class='kwd'>If</span> (pageCount &lt; 0) <span class='kwd'>OrElse</span> (fromPage + pageCount &gt; doc.Pages.Count) <span class='kwd'>Then</span>
    pageCount = -1
<span class='kwd'>End If</span>

<span class='cmt'>'Create a new PdfDocument object that only
'contains the pages to be extracted</span>
<span class='kwd'>Dim</span> doc2 <span class='kwd'>As</span> PdfDocument = doc.Clone(fromPage, pageCount)

<span class='cmt'>'Save the new PdfDocument. This document
'will only contain the specified pages</span>
doc2.Save(result)</pre>";

        }
    }
}

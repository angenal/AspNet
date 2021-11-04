using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.Advanced
{
    public class FilePermission : Demo
    {
        public FilePermission(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Create a PDF file
            PdfDocument doc = new PdfDocument();
            HtmlToPdf.ConvertUrl("http://www.google.com", doc);

            //Disallow printing
            doc.Security.Disallow(PdfDocumentPermissions.Printing);

            //Save it
            doc.Save(result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Create a PDF file</span>
PdfDocument doc = <span class='kwd'>new</span> PdfDocument();
HtmlToPdf.ConvertUrl(<span class='st'>&quot;http://www.google.com&quot;</span>, doc);

<span class='cmt'>//Disallow printing</span>
doc.Security.Disallow(PdfDocumentPermissions.Printing);

<span class='cmt'>//Save it</span>
doc.Save(result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Create a PDF file</span>
<span class='kwd'>Dim</span> doc <span class='kwd'>As New</span> PdfDocument()
HtmlToPdf.ConvertUrl(<span class='st'>&quot;http://www.google.com&quot;</span>, doc)

<span class='cmt'>'Disallow printing</span>
doc.Security.Disallow(PdfDocumentPermissions.Printing)

<span class='cmt'>'Save it</span>
doc.Save(result)</pre>";

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.WithExistingFiles
{
    public class Modify : Demo
    {
        public Modify(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Load the PDF file
            string filePath = GetInputFilePath("Google.pdf");
            PdfDocument doc = new PdfDocument(filePath);

            //Generate additional output on the first page
            //using HTML to PDF
            HtmlToPdf.Options.StartPosition = 5;
            HtmlToPdf.ConvertHtml(@"
<div style='font-size:20px;font-family: Verdana;'>
Sample text added to an existing PDF file with HTML 
to PDF. You can also use ACM interface to add low
level text or image objects. All the new contents
are added on top of the existing page contents.
You can even use new contents with a solid background 
color (for example, solid white) to obscure existing 
contents.
</div>
    ", doc.Pages[0]);

            //Save it to the result Stream
            doc.Save(result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Load the PDF file</span>
<span class='kwd'>string</span> filePath = GetInputFilePath(<span class='st'>&quot;Google.pdf&quot;</span>);
PdfDocument doc = <span class='kwd'>new</span> PdfDocument(filePath);

<span class='cmt'>//Generate additional output on the first page
//using HTML to PDF</span>
HtmlToPdf.Options.StartPosition = 5;
HtmlToPdf.ConvertHtml(@<span class='st'>&quot;
&lt;div style=&#39;font-size:20px;font-family: Verdana;&#39;&gt;
Sample text added to an existing PDF file with HTML 
to PDF. You can also use ACM interface to add low
level text or image objects. All the new contents
are added on top of the existing page contents.
You can even use new contents with a solid background 
color (for example, solid white) to obscure existing 
contents.
&lt;/div&gt;
    &quot;</span>, doc.Pages[0]);

<span class='cmt'>//Save it to the result Stream</span>
doc.Save(result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Load the PDF file</span>
<span class='kwd'>Dim</span> filePath <span class='kwd'>As String</span> = GetInputFilePath(<span class='st'>&quot;Google.pdf&quot;</span>)
<span class='kwd'>Dim</span> doc <span class='kwd'>As New</span> PdfDocument(filePath)

<span class='cmt'>'Generate additional output on the first page
'using HTML to PDF</span>
HtmlToPdf.Options.StartPosition = 5
HtmlToPdf.ConvertHtml(vbCr &amp; vbLf &amp; <span class='st'>&quot;&lt;div style='font-size:20px;font-family: Verdana;'&gt;&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;Sample text added to an existing PDF file with HTML &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;to PDF. You can also use ACM interface to add low&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;level text or image objects. All the new contents&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;are added on top of the existing page contents.&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;You can even use new contents with a solid background &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;color (for example, solid white) to obscure existing &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;contents.&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;&lt;/div&gt;&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;    &quot;</span>, _
     doc.Pages(0))

<span class='cmt'>'Save it to the result Stream</span>
doc.Save(result)</pre>";

        }
    }
}

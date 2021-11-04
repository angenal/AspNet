using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;
using EO.Pdf.Contents;
using EO.Pdf.Drawing;

namespace EOPDFDemo.Acm.PdfContentAPI
{
    public class Image : Demo
    {
        public Image(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Create a new document
            PdfDocument doc = new PdfDocument();

            //Add a new page
            PdfPage page = doc.Pages.Add();

            //Create a new text layer object        
            PdfImage image = new PdfImage(LoadImage("EOLogo.gif"));

            PdfImageContent content = new PdfImageContent();
            content.Image = image;

            content.GfxMatrix.Translate(100, 600);
            content.AutoScale();

            //Add the text layer to the page
            page.Contents.Add(content);

            //Save the result
            doc.Save(result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Create a new document</span>
PdfDocument doc = <span class='kwd'>new</span> PdfDocument();

<span class='cmt'>//Add a new page</span>
PdfPage page = doc.Pages.Add();

<span class='cmt'>//Create a new text layer object        </span>
PdfImage image = <span class='kwd'>new</span> PdfImage(LoadImage(<span class='st'>&quot;EOLogo.gif&quot;</span>));

PdfImageContent content = <span class='kwd'>new</span> PdfImageContent();
content.Image = image;

content.GfxMatrix.Translate(100, 600);
content.AutoScale();

<span class='cmt'>//Add the text layer to the page</span>
page.Contents.Add(content);

<span class='cmt'>//Save the result</span>
doc.Save(result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Create a new document</span>
<span class='kwd'>Dim</span> doc <span class='kwd'>As New</span> PdfDocument()

<span class='cmt'>'Add a new page</span>
<span class='kwd'>Dim</span> page <span class='kwd'>As</span> PdfPage = doc.Pages.Add()

<span class='cmt'>'Create a new text layer object</span>
<span class='kwd'>Dim</span> image <span class='kwd'>As New</span> PdfImage(LoadImage(<span class='st'>&quot;EOLogo.gif&quot;</span>))

<span class='kwd'>Dim</span> content <span class='kwd'>As New</span> PdfImageContent()
content.Image = image

content.GfxMatrix.Translate(100, 600)
content.AutoScale()

<span class='cmt'>'Add the text layer to the page</span>
page.Contents.Add(content)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }

        public override string GetInstructions()
        {
            return @"
<p>
This sample demonstrates how to use low level 
<b>PdfImageContent</b> object directly. While
ACM focus on document flows, low level content
API allows you to place output directly on the
page at arbitrary position. Low level content
API also allows you to perform complex linear 
transformations.
</p>
<p>
To use <b>PdfImageContent</b>, you must first load
the image into a <b>PdfImage</b> object, then 
create an <b>PdfImageContent</b> object using that
<b>PdfImage</b> object. Once the <b>PdfImageContent</b>
is created, you must set its transformation matrix
to position it and also scale it to the intended
size (or call its <b>AutoScale</b> to scale it to
its original size as demonstrated in this sample).
</p>
<p>
See <a href=""javascript:eo_OpenHelp('Acm/Pdf Content API/image.html')"">here</a> 
for more details on using PdfTextContent object. 
</p>
";
        }
    }
}
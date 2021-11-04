using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;

namespace EOPDFDemo.Acm.AdvancedFormatting
{
    public class Image : Demo
    {
        public Image(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Create a new PdfDocument
            PdfDocument doc = new PdfDocument();

            //Create a new AcmRender object
            AcmRender render = new AcmRender(doc);

            //Create the root paragraph
            AcmParagraph p1 = new AcmParagraph(
                new AcmText("This is our logo:"));

            //Create a new image
            AcmImage image = new AcmImage(LoadImage("EOLogo.gif"));
            image.Style.Padding.Left = 0.1f;
            image.Style.OffsetY = 0.12f;
            p1.Children.Add(image);

            //Render the text
            render.Render(p1);

            //Save the result
            doc.Save(result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Create a new PdfDocument</span>
PdfDocument doc = <span class='kwd'>new</span> PdfDocument();

<span class='cmt'>//Create a new AcmRender object</span>
AcmRender render = <span class='kwd'>new</span> AcmRender(doc);

<span class='cmt'>//Create the root paragraph</span>
AcmParagraph p1 = <span class='kwd'>new</span> AcmParagraph(
    <span class='kwd'>new</span> AcmText(<span class='st'>&quot;This is our logo:&quot;</span>));

<span class='cmt'>//Create a new image</span>
AcmImage image = <span class='kwd'>new</span> AcmImage(LoadImage(<span class='st'>&quot;EOLogo.gif&quot;</span>));
image.Style.Padding.Left = 0.1f;
image.Style.OffsetY = 0.12f;
p1.Children.Add(image);

<span class='cmt'>//Render the text</span>
render.Render(p1);

<span class='cmt'>//Save the result</span>
doc.Save(result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Create a new PdfDocument</span>
<span class='kwd'>Dim</span> doc <span class='kwd'>As New</span> PdfDocument()

<span class='cmt'>'Create a new AcmRender object</span>
<span class='kwd'>Dim</span> render <span class='kwd'>As New</span> AcmRender(doc)

<span class='cmt'>'Create the root paragraph</span>
<span class='kwd'>Dim</span> p1 <span class='kwd'>As New</span> AcmParagraph(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;This is our logo:&quot;</span>))

<span class='cmt'>'Create a new image</span>
<span class='kwd'>Dim</span> image <span class='kwd'>As New</span> AcmImage(LoadImage(<span class='st'>&quot;EOLogo.gif&quot;</span>))
image.Style.Padding.Left = 0.1F
image.Style.OffsetY = 0.12F
p1.Children.Add(image)

<span class='cmt'>'Render the text</span>
render.Render(p1)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }

        public override string GetInstructions()
        {
            return @"
<p>
This sample demonstrates how to use an <b>AcmImage</b>
object to create an image in the PDF file. An image
is an inline element so it always appears in the same
line as the text. However sometimes it is necessary
to set <b>OffsetY</b> to move the image slightly
downwards so that the image and the text appear on the
same base line.
</p>
<p>
To place an image on a new line, place the <b>AcmImage</b>
object inside a block content object.
</p>
";
        }
    }
}
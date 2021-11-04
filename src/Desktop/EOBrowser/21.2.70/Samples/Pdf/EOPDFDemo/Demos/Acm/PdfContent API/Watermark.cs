using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;
using EO.Pdf.Contents;
using EO.Pdf.Drawing;

namespace EOPDFDemo.Acm.PdfContentAPI
{
    public class Watermark : Demo
    {
        public Watermark(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            PdfDocument doc = new PdfDocument();

            //Create the render
            AcmRender render = new AcmRender(doc);

            //Handle BeforeRenderPage event
            render.BeforeRenderPage += new AcmPageEventHandler(render_BeforeRenderPage);

            AcmContent content = new AcmContent();

            AcmParagraph p1 = new AcmParagraph(
                new AcmText("A day at the beach!"));
            p1.Style.Margin.Top = 1f;
            p1.Style.FontSize = 40f;
            p1.Style.FontName = "Tahoma";

            AcmParagraph p2 = new AcmParagraph(new AcmText(
                @"Come to join us to spend a day at the beach! 
                  It won't be boring with all these fun things 
                  to do, especially for kids!"));
            p2.Style.FontSize = 15f;
            p2.Style.FontName = "Tahoma";

            //Render the contents
            render.Render(p1, p2);

            //Save the result
            doc.Save(result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'>PdfDocument doc = <span class='kwd'>new</span> PdfDocument();

<span class='cmt'>//Create the render</span>
AcmRender render = <span class='kwd'>new</span> AcmRender(doc);

<span class='cmt'>//Handle BeforeRenderPage event</span>
render.BeforeRenderPage += <span class='kwd'>new</span> AcmPageEventHandler(render_BeforeRenderPage);

AcmContent content = <span class='kwd'>new</span> AcmContent();

AcmParagraph p1 = <span class='kwd'>new</span> AcmParagraph(
    <span class='kwd'>new</span> AcmText(<span class='st'>&quot;A day at the beach!&quot;</span>));
p1.Style.Margin.Top = 1f;
p1.Style.FontSize = 40f;
p1.Style.FontName = <span class='st'>&quot;Tahoma&quot;</span>;

AcmParagraph p2 = <span class='kwd'>new</span> AcmParagraph(<span class='kwd'>new</span> AcmText(
                @<span class='st'>&quot;Come to join us to spend a day at the beach! 
                  It won&#39;t be boring with all these fun things 
                  to do, especially for kids!&quot;</span>));
p2.Style.FontSize = 15f;
p2.Style.FontName = <span class='st'>&quot;Tahoma&quot;</span>;

<span class='cmt'>//Render the contents</span>
render.Render(p1, p2);

<span class='cmt'>//Save the result</span>
doc.Save(result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='kwd'>Dim</span> doc <span class='kwd'>As New</span> PdfDocument()

<span class='cmt'>'Create the render</span>
<span class='kwd'>Dim</span> render <span class='kwd'>As New</span> AcmRender(doc)

<span class='cmt'>'Handle BeforeRenderPage event</span>
<span class='kwd'>AddHandler</span> render.BeforeRenderPage, <span class='kwd'>New</span> AcmPageEventHandler(<span class='kwd'>AddressOf</span>  render_BeforeRenderPage)

<span class='kwd'>Dim</span> content <span class='kwd'>As New</span> AcmContent()

<span class='kwd'>Dim</span> p1 <span class='kwd'>As New</span> AcmParagraph(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;A day at the beach!&quot;</span>))
p1.Style.Margin.Top = 1F
p1.Style.FontSize = 40F
p1.Style.FontName = <span class='st'>&quot;Tahoma&quot;</span>

<span class='kwd'>Dim</span> p2 <span class='kwd'>As New</span> AcmParagraph(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Come to join us to spend a day at the beach! &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  It won't be boring with all these fun things &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  to do, especially for kids!&quot;</span>))
p2.Style.FontSize = 15F
p2.Style.FontName = <span class='st'>&quot;Tahoma&quot;</span>

<span class='cmt'>'Render the contents</span>
render.Render(p1, p2)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }

        void render_BeforeRenderPage(object sender, AcmPageEventArgs e)
        {
            PdfImage image = new PdfImage(LoadImage("Watermark.jpg"));

            PdfImageContent content = new PdfImageContent();
            content.Image = image;

            content.GfxMatrix.Scale(612, 792);

            e.Page.Contents.Add(content);
        }

        public override string GetInstructions()
        {
            return @"
<p>
This sample demonstrates how to create a watermark
with low level content API.
</p>
<p>
The sample handles the <b>AcmRender</b> object's
<b>BeforePageRender</b> event and places a 
<b>PdfImageContent</b> on the page in that handler.
Any output generated inside <b>BeforePageRender</b>
event would appear below the normal page output,
thus creating the watermark effect.
</p>
<p>
Similarly, you can place a 
<a href=""javascript:eo_GoToDemo('PDF Creator/Low Level Content API/Rubber Stamp')"">rubber stamp</a>
 on top of the regular text by handling <b>AfterPageRender</b>
event.
</p>
";
        }
    }
}
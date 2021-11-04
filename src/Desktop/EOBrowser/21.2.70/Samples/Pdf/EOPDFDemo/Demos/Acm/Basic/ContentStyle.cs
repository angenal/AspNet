using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;

namespace EOPDFDemo.Acm.Basic
{
    public class ContentStyle : Demo
    {
        public ContentStyle(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Create a new PdfDocument
            PdfDocument doc = new PdfDocument();

            //Create a new render
            AcmRender render = new AcmRender(doc);

            AcmContent root = new AcmContent();

            //Use a different font name
            root.Style.FontName = "Verdana";

            //Use a bigger font size
            root.Style.FontSize = 20f;

            //Use itatic style
            root.Style.FontStyle = System.Drawing.FontStyle.Italic;

            //Create some blue text
            AcmText text1 = new AcmText("Hello, world!");
            text1.Style.ForegroundColor = System.Drawing.Color.Blue;

            //Create some red text
            AcmText text2 = new AcmText(" I am in style!");
            text2.Style.ForegroundColor = System.Drawing.Color.Red;

            root.Children.Add(text1);
            root.Children.Add(text2);

            //Render the text
            render.Render(root);

            //Save the result
            doc.Save(result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Create a new PdfDocument</span>
PdfDocument doc = <span class='kwd'>new</span> PdfDocument();

<span class='cmt'>//Create a new render</span>
AcmRender render = <span class='kwd'>new</span> AcmRender(doc);

AcmContent root = <span class='kwd'>new</span> AcmContent();

<span class='cmt'>//Use a different font name</span>
root.Style.FontName = <span class='st'>&quot;Verdana&quot;</span>;

<span class='cmt'>//Use a bigger font size</span>
root.Style.FontSize = 20f;

<span class='cmt'>//Use itatic style</span>
root.Style.FontStyle = System.Drawing.FontStyle.Italic;

<span class='cmt'>//Create some blue text</span>
AcmText text1 = <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Hello, world!&quot;</span>);
text1.Style.ForegroundColor = System.Drawing.Color.Blue;

<span class='cmt'>//Create some red text</span>
AcmText text2 = <span class='kwd'>new</span> AcmText(<span class='st'>&quot; I am in style!&quot;</span>);
text2.Style.ForegroundColor = System.Drawing.Color.Red;

root.Children.Add(text1);
root.Children.Add(text2);

<span class='cmt'>//Render the text</span>
render.Render(root);

<span class='cmt'>//Save the result</span>
doc.Save(result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Create a new PdfDocument</span>
<span class='kwd'>Dim</span> doc <span class='kwd'>As New</span> PdfDocument()

<span class='cmt'>'Create a new render</span>
<span class='kwd'>Dim</span> render <span class='kwd'>As New</span> AcmRender(doc)

<span class='kwd'>Dim</span> root <span class='kwd'>As New</span> AcmContent()

<span class='cmt'>'Use a different font name</span>
root.Style.FontName = <span class='st'>&quot;Verdana&quot;</span>

<span class='cmt'>'Use a bigger font size</span>
root.Style.FontSize = 20F

<span class='cmt'>'Use itatic style</span>
root.Style.FontStyle = System.Drawing.FontStyle.Italic

<span class='cmt'>'Create some blue text</span>
<span class='kwd'>Dim</span> text1 <span class='kwd'>As New</span> AcmText(<span class='st'>&quot;Hello, world!&quot;</span>)
text1.Style.ForegroundColor = System.Drawing.Color.Blue

<span class='cmt'>'Create some red text</span>
<span class='kwd'>Dim</span> text2 <span class='kwd'>As New</span> AcmText(<span class='st'>&quot; I am in style!&quot;</span>)
text2.Style.ForegroundColor = System.Drawing.Color.Red

root.Children.Add(text1)
root.Children.Add(text2)

<span class='cmt'>'Render the text</span>
render.Render(root)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }

        public override string GetInstructions()
        {
            return @"
<p>
This sample demonstrates how to set content styles. Each
<b>AcmContent</b> object exposes a <b>Style</b> property
through which you can set various styles such as font, color,
padding, margins, etc. Styles work in a way very similar to
CSS in HTML. 
</p>
<p>
Click <a href=""javascript:eo_OpenHelp('Acm/Getting Started/style.html');"">here</a> to see more
details about using styles.
</p>
";
        }
    }
}
using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;

namespace EOPDFDemo.Acm.Basic
{
    public class HelloWorld: Demo
    {
        public HelloWorld(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Create a new PdfDocument
            PdfDocument doc = new PdfDocument();

            //Create a new AcmRender object
            AcmRender render = new AcmRender(doc);

            //Create a new text object
            AcmText text = new AcmText("Hello, world!");

            //Render the text
            render.Render(text);

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

<span class='cmt'>//Create a new text object</span>
AcmText text = <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Hello, world!&quot;</span>);

<span class='cmt'>//Render the text</span>
render.Render(text);

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

<span class='cmt'>'Create a new text object</span>
<span class='kwd'>Dim</span> text <span class='kwd'>As New</span> AcmText(<span class='st'>&quot;Hello, world!&quot;</span>)

<span class='cmt'>'Render the text</span>
render.Render(text)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }

        public override string GetInstructions()
        {
            return @"
<p>
This sample shows how to use ACM (Abstract
Content Model) to create a PDF file with one page 
and text ""Hello, World!"" on it.
</p>
<p>
Follow these simple steps to create a PDF file using ACM:
</p>
<ol>
    <li>
    Create a new <b>PdfDocument</b> object and a new <b>AcmRender</b> object;
    </li>
    <li>
    Create a new content tree (A single AcmText object in this sample);
    </li>
    <li>
    Render the content tree into the PdfDocument by calling the
    <b>AcmRender</b> object's <b>Render</b> method;
    </li>
    <li>
    Save the PDF file by calling the <b>PdfDocument</b> object's
    <b>Save</b> method. If using inside a Web project, you can also
    save the output directly to the OutputStream to 
    <a href=""javascript:eo_OpenHelp('Web/pdf_on_demand.html')"">send the PDF file to the client on the fly</a>;
    </li>
</ol>
";
        }
    }
}
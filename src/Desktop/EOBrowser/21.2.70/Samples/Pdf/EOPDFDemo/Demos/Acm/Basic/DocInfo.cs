using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;

namespace EOPDFDemo.Acm.Basic
{
    public class DocInfo : Demo
    {
        public DocInfo(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Create a new PdfDocument
            PdfDocument doc = new PdfDocument();

            //Set the document information
            doc.Info.Title = "EO.Pdf Sample PDF file";
            doc.Info.Creator = "EO.Pdf Library";
            doc.Info.Author = "EO.Pdf";

            //Hide the toolbar
            doc.ViewerPreference.HideToolbar = true;

            //Create a new AcmRender object
            AcmRender render = new AcmRender(doc);

            //Create a new text object
            AcmText text = new AcmText(
                @"This sample updates the document's title, creator and author. It
                also hides the toolbar of the viewer. Right click and select 
                'Document Properties' to view the document information.");

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

<span class='cmt'>//Set the document information</span>
doc.Info.Title = <span class='st'>&quot;EO.Pdf Sample PDF file&quot;</span>;
doc.Info.Creator = <span class='st'>&quot;EO.Pdf Library&quot;</span>;
doc.Info.Author = <span class='st'>&quot;EO.Pdf&quot;</span>;

<span class='cmt'>//Hide the toolbar</span>
doc.ViewerPreference.HideToolbar = <span class='kwd'>true</span>;

<span class='cmt'>//Create a new AcmRender object</span>
AcmRender render = <span class='kwd'>new</span> AcmRender(doc);

<span class='cmt'>//Create a new text object</span>
AcmText text = <span class='kwd'>new</span> AcmText(
                @<span class='st'>&quot;This sample updates the document&#39;s title, creator and author. It
                also hides the toolbar of the viewer. Right click and select 
                &#39;Document Properties&#39; to view the document information.&quot;</span>);

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

<span class='cmt'>'Set the document information</span>
doc.Info.Title = <span class='st'>&quot;EO.Pdf Sample PDF file&quot;</span>
doc.Info.Creator = <span class='st'>&quot;EO.Pdf Library&quot;</span>
doc.Info.Author = <span class='st'>&quot;EO.Pdf&quot;</span>

<span class='cmt'>'Hide the toolbar</span>
doc.ViewerPreference.HideToolbar = <span class='kwd'>True</span>

<span class='cmt'>'Create a new AcmRender object</span>
<span class='kwd'>Dim</span> render <span class='kwd'>As New</span> AcmRender(doc)

<span class='cmt'>'Create a new text object</span>
<span class='kwd'>Dim</span> text <span class='kwd'>As New</span> AcmText(<span class='st'>&quot;This sample updates the document's title, creator and author. It&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                also hides the toolbar of the viewer. Right click and select &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                'Document Properties' to view the document information.&quot;</span>)

<span class='cmt'>'Render the text</span>
render.Render(text)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }

        public override string GetInstructions()
        {
            return @"
<p>
This sample demonstrates how to update document information
such as title, author and creator. 
    See <a href=""javascript:eo_OpenHelp('Acm/Getting%20Started/doc_info.html')"">here</a> 
for more details. 
</p>
";
        }
    }
}
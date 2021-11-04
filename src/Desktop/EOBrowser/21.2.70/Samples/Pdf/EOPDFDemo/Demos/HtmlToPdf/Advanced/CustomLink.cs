using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Advanced
{
    public class CustomLink : Demo
    {
        public CustomLink(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Get the HTML markup
            string html1 = args.GetString("txtHTML1");
            if (html1.Trim() == string.Empty)
                return "Please enter the first HTML snippet you wish to convert.";
            string html2 = args.GetString("txtHTML2");
            if (html2.Trim() == string.Empty)
                return "Please enter the second HTML snippet you wish to convert.";

            //Convert the HTML snippets into a PdfDocument object
            PdfDocument doc = new PdfDocument();
            HtmlToPdfResult result1 = HtmlToPdf.ConvertHtml(html1, doc);
            HtmlToPdfResult result2 = HtmlToPdf.ConvertHtml(html2, doc);

            //Link element "next_chapter" in the first snippet
            //to "header" to the second snippet
            HtmlElement linkSource = result1.HtmlDocument.GetElementById("next_chapter");
            HtmlElement linkTarget = result2.HtmlDocument.GetElementById("title");
            if ((linkSource == null) || (linkTarget == null))
                return "Unable to find link source or link target.";

            //Create the PdfLink object
            PdfLink link = linkSource.CreateLink(linkTarget);

            //Add the link into the document
            link.Render();

            doc.Save(result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Convert the HTML snippets into a PdfDocument object</span>
PdfDocument doc = <span class='kwd'>new</span> PdfDocument();
HtmlToPdfResult result1 = HtmlToPdf.ConvertHtml(html1, doc);
HtmlToPdfResult result2 = HtmlToPdf.ConvertHtml(html2, doc);

<span class='cmt'>//Link element &quot;next_chapter&quot; in the first snippet
//to &quot;header&quot; to the second snippet</span>
HtmlElement linkSource = result1.HtmlDocument.GetElementById(<span class='st'>&quot;next_chapter&quot;</span>);
HtmlElement linkTarget = result2.HtmlDocument.GetElementById(<span class='st'>&quot;title&quot;</span>);
<span class='kwd'>if</span> ((linkSource == <span class='kwd'>null</span>) || (linkTarget == <span class='kwd'>null</span>))
    <span class='kwd'>return</span> <span class='st'>&quot;Unable to find link source or link target.&quot;</span>;

<span class='cmt'>//Create the PdfLink object</span>
PdfLink link = linkSource.CreateLink(linkTarget);

<span class='cmt'>//Add the link into the document</span>
link.Render();

doc.Save(result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Convert the HTML snippets into a PdfDocument object</span>
<span class='kwd'>Dim</span> doc <span class='kwd'>As New</span> PdfDocument()
<span class='kwd'>Dim</span> result1 <span class='kwd'>As</span> HtmlToPdfResult = HtmlToPdf.ConvertHtml(html1, doc)
<span class='kwd'>Dim</span> result2 <span class='kwd'>As</span> HtmlToPdfResult = HtmlToPdf.ConvertHtml(html2, doc)

<span class='cmt'>'Link element &quot;next_chapter&quot; in the first snippet
'to &quot;header&quot; to the second snippet</span>
<span class='kwd'>Dim</span> linkSource <span class='kwd'>As</span> HtmlElement = result1.HtmlDocument.GetElementById(<span class='st'>&quot;next_chapter&quot;</span>)
<span class='kwd'>Dim</span> linkTarget <span class='kwd'>As</span> HtmlElement = result2.HtmlDocument.GetElementById(<span class='st'>&quot;title&quot;</span>)
<span class='kwd'>If</span> (linkSource <span class='kwd'>Is Nothing</span>) <span class='kwd'>OrElse</span> (linkTarget <span class='kwd'>Is Nothing</span>) <span class='kwd'>Then
    Return</span> <span class='st'>&quot;Unable to find link source or link target.&quot;</span>
<span class='kwd'>End If</span>

<span class='cmt'>'Create the PdfLink object</span>
<span class='kwd'>Dim</span> link <span class='kwd'>As</span> PdfLink = linkSource.CreateLink(linkTarget)

<span class='cmt'>'Add the link into the document</span>
link.Render()

doc.Save(result)</pre>";

        }
    }
}

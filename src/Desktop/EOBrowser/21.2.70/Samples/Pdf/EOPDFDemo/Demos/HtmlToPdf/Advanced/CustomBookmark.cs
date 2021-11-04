using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Advanced
{
    public class CustomBookmark : Demo
    {
        public CustomBookmark(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream resultStream, IDemoArgs args)
        {
            //Get the HTML markup
            string html = args.GetString("txtHTML");
            if (html.Trim() == string.Empty)
                return "Please enter the HTML you wish to convert.";

            //Convert the HTML into a PdfDocument object
            PdfDocument doc = new PdfDocument();
            HtmlToPdfResult result = HtmlToPdf.ConvertHtml(html, doc);

            //Now search for all elements with class name
            //set to "chapter_title"
            HtmlElement[] elements =
                result.HtmlDocument.GetElementsByClassName("chapter_title");

            //Create a bookmark for each of these elements
            foreach (HtmlElement element in elements)
            {
                //Skip invisible elements
                if (!element.IsVisible)
                    continue;

                //Create the bookmark
                PdfBookmark bookmark = element.CreateBookmark();
                doc.Bookmarks.Add(bookmark);

                //To create child bookmarks, create a new 
                //PdfBookmark object and then add it to the
                //parent bookmark's ChildNodes collection
            }

            doc.Save(resultStream);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Convert the HTML into a PdfDocument object</span>
PdfDocument doc = <span class='kwd'>new</span> PdfDocument();
HtmlToPdfResult result = HtmlToPdf.ConvertHtml(html, doc);

<span class='cmt'>//Now search for all elements with class name
//set to &quot;chapter_title&quot;</span>
HtmlElement[] elements =
    result.HtmlDocument.GetElementsByClassName(<span class='st'>&quot;chapter_title&quot;</span>);

<span class='cmt'>//Create a bookmark for each of these elements</span>
<span class='kwd'>foreach</span> (HtmlElement element <span class='kwd'>in</span> elements)
{
    <span class='cmt'>//Skip invisible elements</span>
    <span class='kwd'>if</span> (!element.IsVisible)
        <span class='kwd'>continue</span>;

    <span class='cmt'>//Create the bookmark</span>
    PdfBookmark bookmark = element.CreateBookmark();
    doc.Bookmarks.Add(bookmark);

    <span class='cmt'>//To create child bookmarks, create a new 
    //PdfBookmark object and then add it to the
    //parent bookmark's ChildNodes collection</span>
}

doc.Save(resultStream);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Convert the HTML into a PdfDocument object</span>
<span class='kwd'>Dim</span> doc <span class='kwd'>As New</span> PdfDocument()
<span class='kwd'>Dim</span> result <span class='kwd'>As</span> HtmlToPdfResult = HtmlToPdf.ConvertHtml(html, doc)

<span class='cmt'>'Now search for all elements with class name
'set to &quot;chapter_title&quot;</span>
<span class='kwd'>Dim</span> elements <span class='kwd'>As</span> HtmlElement() = result.HtmlDocument.GetElementsByClassName(<span class='st'>&quot;chapter_title&quot;</span>)

<span class='cmt'>'Create a bookmark for each of these elements</span>
<span class='kwd'>For Each</span> element <span class='kwd'>As</span> HtmlElement <span class='kwd'>In</span> elements
    <span class='cmt'>'Skip invisible elements</span>
    <span class='kwd'>If Not</span> element.IsVisible <span class='kwd'>Then</span>
        Continue <span class='kwd'>For
    End If</span>

    <span class='cmt'>'Create the bookmark</span>
    <span class='kwd'>Dim</span> bookmark <span class='kwd'>As</span> PdfBookmark = element.CreateBookmark()

        <span class='cmt'>'To create child bookmarks, create a new
        'PdfBookmark object and then add it to the
        'parent bookmark's ChildNodes collection</span>
    doc.Bookmarks.Add(bookmark)
<span class='kwd'>Next</span>

doc.Save(resultStream)</pre>";

        }
    }
}

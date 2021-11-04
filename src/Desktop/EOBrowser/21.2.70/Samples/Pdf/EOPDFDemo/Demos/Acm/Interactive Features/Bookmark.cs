using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;

namespace EOPDFDemo.Acm.Interactive
{
    public class Bookmark : Demo
    {
        public Bookmark(string path)
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
            AcmText text1 = new AcmText("Page 1 - Top");

            AcmBlock block = new AcmBlock();
            block.Style.Height = 3f;

            AcmText text2 = new AcmText("Page 1 - Middle");

            AcmText text3 = new AcmText("Page 2 - Top");

            //Render the text
            render.Render(text1, 
                block, text2, new AcmPageBreak(), text3);

            PdfBookmark bookmark1 = new PdfBookmark("Page 1");
            bookmark1.Destination = text1.CreateDestination();

            PdfBookmark bookmark2 = new PdfBookmark("Middle of the page");
            bookmark2.Destination = text2.CreateDestination();
            bookmark1.ChildNodes.Add(bookmark2);

            PdfBookmark bookmark3 = new PdfBookmark("Page 2");
            bookmark3.Destination = text3.CreateDestination();

            doc.Bookmarks.Add(bookmark1);
            doc.Bookmarks.Add(bookmark3);

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
AcmText text1 = <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Page 1 - Top&quot;</span>);

AcmBlock block = <span class='kwd'>new</span> AcmBlock();
block.Style.Height = 3f;

AcmText text2 = <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Page 1 - Middle&quot;</span>);

AcmText text3 = <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Page 2 - Top&quot;</span>);

<span class='cmt'>//Render the text</span>
render.Render(text1, 
    block, text2, <span class='kwd'>new</span> AcmPageBreak(), text3);

PdfBookmark bookmark1 = <span class='kwd'>new</span> PdfBookmark(<span class='st'>&quot;Page 1&quot;</span>);
bookmark1.Destination = text1.CreateDestination();

PdfBookmark bookmark2 = <span class='kwd'>new</span> PdfBookmark(<span class='st'>&quot;Middle of the page&quot;</span>);
bookmark2.Destination = text2.CreateDestination();
bookmark1.ChildNodes.Add(bookmark2);

PdfBookmark bookmark3 = <span class='kwd'>new</span> PdfBookmark(<span class='st'>&quot;Page 2&quot;</span>);
bookmark3.Destination = text3.CreateDestination();

doc.Bookmarks.Add(bookmark1);
doc.Bookmarks.Add(bookmark3);

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
<span class='kwd'>Dim</span> text1 <span class='kwd'>As New</span> AcmText(<span class='st'>&quot;Page 1 - Top&quot;</span>)

<span class='kwd'>Dim</span> block <span class='kwd'>As New</span> AcmBlock()
block.Style.Height = 3F

<span class='kwd'>Dim</span> text2 <span class='kwd'>As New</span> AcmText(<span class='st'>&quot;Page 1 - Middle&quot;</span>)

<span class='kwd'>Dim</span> text3 <span class='kwd'>As New</span> AcmText(<span class='st'>&quot;Page 2 - Top&quot;</span>)

<span class='cmt'>'Render the text</span>
render.Render(text1, _
     block, text2, <span class='kwd'>New</span> AcmPageBreak(), text3)

<span class='kwd'>Dim</span> bookmark1 <span class='kwd'>As New</span> PdfBookmark(<span class='st'>&quot;Page 1&quot;</span>)
bookmark1.Destination = text1.CreateDestination()

<span class='kwd'>Dim</span> bookmark2 <span class='kwd'>As New</span> PdfBookmark(<span class='st'>&quot;Middle of the page&quot;</span>)
bookmark2.Destination = text2.CreateDestination()
bookmark1.ChildNodes.Add(bookmark2)

<span class='kwd'>Dim</span> bookmark3 <span class='kwd'>As New</span> PdfBookmark(<span class='st'>&quot;Page 2&quot;</span>)
bookmark3.Destination = text3.CreateDestination()

doc.Bookmarks.Add(bookmark1)
doc.Bookmarks.Add(bookmark3)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }

        public override string GetInstructions()
        {
            return @"
<p>
This sample demonstrates how to create bookmarks. 
Bookmarks are organized as a tree. Each bookmark 
is represented by a <b>PdfBookmark</b> object. 
To create top level bookmarks, initializes a
<b>PdfBookmark</b> object and then add it into
the <b>PdfDocument</b>'s <b>Bookmarks</b> collection.
To create a child bookmark, initializes a 
<b>PdfBookmark</b> object add then add it into
the parent <b>PdfBookmark</b>'s <b>ChildNodes</b>
collection.
</p>
<p>
Each <b>PdfBookmark</b>'s <b>Destination</b> must
be set to a <b>PdfDestination</b> which represents
the destination when the bookmark is clicked. The
easiest way to create a <b>PdfDestination</b> is
to call an <b>AcmContent</b>'s <b>CreateDestination</b>
method.
</p>
";
        }
    }
}
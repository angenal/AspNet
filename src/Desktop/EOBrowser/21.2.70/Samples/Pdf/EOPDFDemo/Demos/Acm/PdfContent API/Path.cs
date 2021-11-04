using System;
using System.IO;
using System.Drawing;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;
using EO.Pdf.Contents;
using EO.Pdf.Drawing;

namespace EOPDFDemo.Acm.PdfContentAPI
{
    public class Path : Demo
    {
        public Path(string path)
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
            PdfPathContent content = new PdfPathContent();
            content.StrokingColor = Color.Red;
            content.NonStrokingColor = Color.Gray;

            PdfSubPath subPath = new PdfSubPath();
            subPath.From = new PdfPoint(100, 600);
            subPath.Segments.Add(new PdfPathLineSegment(new PdfPoint(300, 600)));
            subPath.Segments.Add(new PdfPathCurveSegment(
                new PdfPoint(300, 650), new PdfPoint(200, 600), new PdfPoint(200, 700)));
            subPath.Closed = true;
            content.Path.SubPaths.Add(subPath);
            content.Action = PdfPathPaintAction.Fill | PdfPathPaintAction.Stroke;


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
PdfPathContent content = <span class='kwd'>new</span> PdfPathContent();
content.StrokingColor = Color.Red;
content.NonStrokingColor = Color.Gray;

PdfSubPath subPath = <span class='kwd'>new</span> PdfSubPath();
subPath.From = <span class='kwd'>new</span> PdfPoint(100, 600);
subPath.Segments.Add(<span class='kwd'>new</span> PdfPathLineSegment(<span class='kwd'>new</span> PdfPoint(300, 600)));
subPath.Segments.Add(<span class='kwd'>new</span> PdfPathCurveSegment(
    <span class='kwd'>new</span> PdfPoint(300, 650), <span class='kwd'>new</span> PdfPoint(200, 600), <span class='kwd'>new</span> PdfPoint(200, 700)));
subPath.Closed = <span class='kwd'>true</span>;
content.Path.SubPaths.Add(subPath);
content.Action = PdfPathPaintAction.Fill | PdfPathPaintAction.Stroke;


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
<span class='kwd'>Dim</span> content <span class='kwd'>As New</span> PdfPathContent()
content.StrokingColor = Color.Red
content.NonStrokingColor = Color.Gray

<span class='kwd'>Dim</span> subPath <span class='kwd'>As New</span> PdfSubPath()
subPath.From = <span class='kwd'>New</span> PdfPoint(100, 600)
subPath.Segments.Add(<span class='kwd'>New</span> PdfPathLineSegment(<span class='kwd'>New</span> PdfPoint(300, 600)))
subPath.Segments.Add(<span class='kwd'>New</span> PdfPathCurveSegment(<span class='kwd'>New</span> PdfPoint(300, 650), <span class='kwd'>New</span> PdfPoint(200, 600), <span class='kwd'>New</span> PdfPoint(200, 700)))
subPath.Closed = <span class='kwd'>True</span>
content.Path.SubPaths.Add(subPath)
content.Action = PdfPathPaintAction.Fill <span class='kwd'>Or</span> PdfPathPaintAction.Stroke


<span class='cmt'>'Add the text layer to the page</span>
page.Contents.Add(content)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }

        public override string GetInstructions()
        {
            return @"
<p>
This sample demonstrates how to use <b>PdfPathContent</b>
object to create lines and shapes.
</p>
<p>
To use <b>PdfPathContent</b>, you must create one more
more <b>PdfSubPath</b> object first, then add the sub path
objects into PdfPathContent.Path's <b>SubPath</b> collection.
Each sub path in turn contains one or more <b>PdfPathSegment</b>,
which can be line, curve or rectangle.
</p>
<p>
See <a href=""javascript:eo_OpenHelp('Acm/Pdf Content API/path.html')"">here</a> 
for more details on using PdfTextContent object. 
</p>
";
        }
    }
}
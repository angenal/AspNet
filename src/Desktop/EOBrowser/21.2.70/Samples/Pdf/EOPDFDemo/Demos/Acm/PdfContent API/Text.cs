using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;
using EO.Pdf.Contents;
using EO.Pdf.Drawing;

namespace EOPDFDemo.Acm.PdfContentAPI
{
    public class Text : Demo
    {
        public Text(string path)
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
            PdfTextLayer textLayer = new PdfTextLayer();
            textLayer.NonStrokingColor = System.Drawing.Color.Red;
            textLayer.GfxMatrix.Scale(3, 3);
            textLayer.GfxMatrix.Rotate(30);

            //Create the first text snippet
            PdfTextContent content1 = new PdfTextContent("Hello!");
            content1.PositionMode = PdfTextPositionMode.Offset;
            content1.Offset = new PdfPoint(120, 150);

            //Create the second text snippet
            PdfTextContent content2 = new PdfTextContent("Hello Again!");
            content2.PositionMode = PdfTextPositionMode.Offset;
            content2.Offset = new PdfPoint(0, -10);

            //Add PdfTextContent objects into PdfTextLayer object
            textLayer.Contents.Add(content1);
            textLayer.Contents.Add(content2);

            //Add the text layer to the page
            page.Contents.Add(textLayer);

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
PdfTextLayer textLayer = <span class='kwd'>new</span> PdfTextLayer();
textLayer.NonStrokingColor = System.Drawing.Color.Red;
textLayer.GfxMatrix.Scale(3, 3);
textLayer.GfxMatrix.Rotate(30);

<span class='cmt'>//Create the first text snippet</span>
PdfTextContent content1 = <span class='kwd'>new</span> PdfTextContent(<span class='st'>&quot;Hello!&quot;</span>);
content1.PositionMode = PdfTextPositionMode.Offset;
content1.Offset = <span class='kwd'>new</span> PdfPoint(120, 150);

<span class='cmt'>//Create the second text snippet</span>
PdfTextContent content2 = <span class='kwd'>new</span> PdfTextContent(<span class='st'>&quot;Hello Again!&quot;</span>);
content2.PositionMode = PdfTextPositionMode.Offset;
content2.Offset = <span class='kwd'>new</span> PdfPoint(0, -10);

<span class='cmt'>//Add PdfTextContent objects into PdfTextLayer object</span>
textLayer.Contents.Add(content1);
textLayer.Contents.Add(content2);

<span class='cmt'>//Add the text layer to the page</span>
page.Contents.Add(textLayer);

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
<span class='kwd'>Dim</span> textLayer <span class='kwd'>As New</span> PdfTextLayer()
textLayer.NonStrokingColor = System.Drawing.Color.Red
textLayer.GfxMatrix.Scale(3, 3)
textLayer.GfxMatrix.Rotate(30)

<span class='cmt'>'Create the first text snippet</span>
<span class='kwd'>Dim</span> content1 <span class='kwd'>As New</span> PdfTextContent(<span class='st'>&quot;Hello!&quot;</span>)
content1.PositionMode = PdfTextPositionMode.Offset
content1.Offset = <span class='kwd'>New</span> PdfPoint(120, 150)

<span class='cmt'>'Create the second text snippet</span>
<span class='kwd'>Dim</span> content2 <span class='kwd'>As New</span> PdfTextContent(<span class='st'>&quot;Hello Again!&quot;</span>)
content2.PositionMode = PdfTextPositionMode.Offset
content2.Offset = <span class='kwd'>New</span> PdfPoint(0, -10)

<span class='cmt'>'Add PdfTextContent objects into PdfTextLayer object</span>
textLayer.Contents.Add(content1)
textLayer.Contents.Add(content2)

<span class='cmt'>'Add the text layer to the page</span>
page.Contents.Add(textLayer)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }

        public override string GetInstructions()
        {
            return @"
<p>
This sample demonstrates how to use low level 
<b>PdfTextContent</b> object directly. While
ACM focus on document flows, low level content
API allows you to place output directly on the
page at arbitrary position. Low level content
API also allows you to perform complex linear 
transformations.
</p>
<p>
To use <b>PdfTextContent</b>, you must create
a new <b>PdfTextLayer</b> object first. All
graphic parameters such as color, font and
transformation should be set on the 
<b>PdfTextLayer</b> object. This sample sets
color to red and set the transformation matrix
to scale and rotate the text.
</p>
<p>
See <a href=""javascript:eo_OpenHelp('Acm/Pdf Content API/text.html')"">here</a> 
for more details on using PdfTextContent object. 
</p>
";
        }
    }
}
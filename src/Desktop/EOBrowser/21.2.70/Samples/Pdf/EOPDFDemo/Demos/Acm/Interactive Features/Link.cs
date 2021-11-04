using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;

namespace EOPDFDemo.Acm.Interactive
{
    public class Link : Demo
    {
        public Link(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Create a new PdfDocument
            PdfDocument doc = new PdfDocument();

            //Create a new AcmRender object
            AcmRender render = new AcmRender(doc);

            AcmContent root = new AcmContent();

            //Create a new text object
            AcmText text1 = new AcmText("Click here to go to the second page");
            AcmLink link = new AcmLink(text1);

            AcmPageBreak pageBreak = new AcmPageBreak();

            AcmText text2 = new AcmText("Text on the second page");

            link.TargetContent = text2;

            root.Children.Add(link);
            root.Children.Add(pageBreak);
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

<span class='cmt'>//Create a new AcmRender object</span>
AcmRender render = <span class='kwd'>new</span> AcmRender(doc);

AcmContent root = <span class='kwd'>new</span> AcmContent();

<span class='cmt'>//Create a new text object</span>
AcmText text1 = <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Click here to go to the second page&quot;</span>);
AcmLink link = <span class='kwd'>new</span> AcmLink(text1);

AcmPageBreak pageBreak = <span class='kwd'>new</span> AcmPageBreak();

AcmText text2 = <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Text on the second page&quot;</span>);

link.TargetContent = text2;

root.Children.Add(link);
root.Children.Add(pageBreak);
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

<span class='cmt'>'Create a new AcmRender object</span>
<span class='kwd'>Dim</span> render <span class='kwd'>As New</span> AcmRender(doc)

<span class='kwd'>Dim</span> root <span class='kwd'>As New</span> AcmContent()

<span class='cmt'>'Create a new text object</span>
<span class='kwd'>Dim</span> text1 <span class='kwd'>As New</span> AcmText(<span class='st'>&quot;Click here to go to the second page&quot;</span>)
<span class='kwd'>Dim</span> link <span class='kwd'>As New</span> AcmLink(text1)

<span class='kwd'>Dim</span> pageBreak <span class='kwd'>As New</span> AcmPageBreak()

<span class='kwd'>Dim</span> text2 <span class='kwd'>As New</span> AcmText(<span class='st'>&quot;Text on the second page&quot;</span>)

link.TargetContent = text2

root.Children.Add(link)
root.Children.Add(pageBreak)
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
This sample demonstrates how to create links
with <b>AcmLink</b>. Using <b>AcmLink</b> is very
easy --- Just use <b>AcmLink</b> as a
container to hold any other contents you wish
user to click, then set the <b>AcmLink</b>'s
<b>TargetContent</b> to the target content you
to which you wish to navigate when user clicks
the link. 
</p>
<p>
<b>AcmLink</b> can also be used to open a Web page
or an application. 
See <a href=""javascript:eo_OpenHelp('Acm/Interactive/link.html')"">here</a> 
for more details. 
</p>
";
        }
    }
}
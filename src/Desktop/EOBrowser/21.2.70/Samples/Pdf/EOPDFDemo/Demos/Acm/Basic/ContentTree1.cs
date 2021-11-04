using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;

namespace EOPDFDemo.Acm.Basic
{
    public class ContentTree1 : Demo
    {
        public ContentTree1(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Create a new PdfDocument
            PdfDocument doc = new PdfDocument();

            //Create a new render
            AcmRender render = new AcmRender(doc);

            //This is the root content
            AcmContent root = new AcmContent();

            //Create the first paragraph. Paragraph "p1"
            //contains "text1"
            AcmParagraph p1 = new AcmParagraph();
            p1.Style.FontSize = 15f;
            p1.Style.FontStyle = System.Drawing.FontStyle.Bold;
            AcmText text1 = new AcmText("Crocodile");
            p1.Children.Add(text1);

            //Create the second paragraph. Paragraph "p2"
            //contains "text2"
            AcmParagraph p2 = new AcmParagraph();
            p2.Style.FontSize = 10f;
            AcmText text2 = new AcmText(
                @"A crocodile is any species belonging to the family of 
                Crocodylidae (sometimes classified instead as the 
                subfamily Crocodylinae). The term can also be used more 
                loosely to include all members of the order Crocodilia: 
                i.e. the true crocodiles, the alligators and caimans 
                (family Alligatoridae) and the gharials (family 
                Gavialidae), or even the Crocodylomorpha which includes 
                prehistoric crocodile relatives and ancestors.");

            p2.Children.Add(text2);

            //Add both "p1" and "p2" into "root"
            root.Children.Add(p1);
            root.Children.Add(p2);

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

<span class='cmt'>//This is the root content</span>
AcmContent root = <span class='kwd'>new</span> AcmContent();

<span class='cmt'>//Create the first paragraph. Paragraph &quot;p1&quot;
//contains &quot;text1&quot;</span>
AcmParagraph p1 = <span class='kwd'>new</span> AcmParagraph();
p1.Style.FontSize = 15f;
p1.Style.FontStyle = System.Drawing.FontStyle.Bold;
AcmText text1 = <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Crocodile&quot;</span>);
p1.Children.Add(text1);

<span class='cmt'>//Create the second paragraph. Paragraph &quot;p2&quot;
//contains &quot;text2&quot;</span>
AcmParagraph p2 = <span class='kwd'>new</span> AcmParagraph();
p2.Style.FontSize = 10f;
AcmText text2 = <span class='kwd'>new</span> AcmText(
                @<span class='st'>&quot;A crocodile is any species belonging to the family of 
                Crocodylidae (sometimes classified instead as the 
                subfamily Crocodylinae). The term can also be used more 
                loosely to include all members of the order Crocodilia: 
                i.e. the true crocodiles, the alligators and caimans 
                (family Alligatoridae) and the gharials (family 
                Gavialidae), or even the Crocodylomorpha which includes 
                prehistoric crocodile relatives and ancestors.&quot;</span>);

p2.Children.Add(text2);

<span class='cmt'>//Add both &quot;p1&quot; and &quot;p2&quot; into &quot;root&quot;</span>
root.Children.Add(p1);
root.Children.Add(p2);

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

<span class='cmt'>'This is the root content</span>
<span class='kwd'>Dim</span> root <span class='kwd'>As New</span> AcmContent()

<span class='cmt'>'Create the first paragraph. Paragraph &quot;p1&quot;
'contains &quot;text1&quot;</span>
<span class='kwd'>Dim</span> p1 <span class='kwd'>As New</span> AcmParagraph()
p1.Style.FontSize = 15F
p1.Style.FontStyle = System.Drawing.FontStyle.Bold
<span class='kwd'>Dim</span> text1 <span class='kwd'>As New</span> AcmText(<span class='st'>&quot;Crocodile&quot;</span>)
p1.Children.Add(text1)

<span class='cmt'>'Create the second paragraph. Paragraph &quot;p2&quot;
'contains &quot;text2&quot;</span>
<span class='kwd'>Dim</span> p2 <span class='kwd'>As New</span> AcmParagraph()
p2.Style.FontSize = 10F
<span class='kwd'>Dim</span> text2 <span class='kwd'>As New</span> AcmText(<span class='st'>&quot;A crocodile is any species belonging to the family of &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                Crocodylidae (sometimes classified instead as the &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                subfamily Crocodylinae). The term can also be used more &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                loosely to include all members of the order Crocodilia: &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                i.e. the true crocodiles, the alligators and caimans &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                (family Alligatoridae) and the gharials (family &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                Gavialidae), or even the Crocodylomorpha which includes &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                prehistoric crocodile relatives and ancestors.&quot;</span>)

p2.Children.Add(text2)

<span class='cmt'>'Add both &quot;p1&quot; and &quot;p2&quot; into &quot;root&quot;</span>
root.Children.Add(p1)
root.Children.Add(p2)

<span class='cmt'>'Render the text</span>
render.Render(root)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }

        public override string GetInstructions()
        {
            return @"
<p>
Creating a PDF file with ACM is all about creating a 
hierarchy of <b>AcmContent</b> objects, or the content
tree.
</p>
<p>
EO.Pdf provides a set of <b>AcmContent</b> classes for
different content types such as text, image, table, etc.
Just creating instances of these types and add child
contents to the parent content's <b>Children</b> 
collection. Once a content object is added into another
content object's <b>Children</b> collection, it is rendered
inside that content. See 
<a href=""javascript:eo_OpenHelp('Acm/Getting%20Started/contents.html')"">here</a> 
for more information about content tree. 
</p>
<p>
This sample uses a list of statements to create each
content object, setting object properties and adding
one to another's <b>Children</b> collection. EO.Pdf
also provides a more convenient way to construct a
content tree through a serial of ""expression"" so that
you can create a whole tree with a single statement. See
<a href=""javascript:eo_GoToDemo('PDF Creator/Basic/Content Tree 2')"">here</a> 
for another sample that demonstrates this technique.
</p>
";
        }
    }
}
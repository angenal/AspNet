using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;

namespace EOPDFDemo.Acm.AdvancedFormatting
{
    public class FixedPosByFloat : Demo
    {
        public FixedPosByFloat(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Create a new PdfDocument
            PdfDocument doc = new PdfDocument();

            //Create a new AcmRender object
            AcmRender render = new AcmRender(doc);

            //The root content. This content must be a block
            //content in order to have floating child blocks
            AcmBlock root = new AcmBlock();

            //This block contains all floating blocks (header
            //and footer). Because all child contents are
            //floating, this block does not occupy any layout
            //space
            AcmBlock container = new AcmBlock();

            //Position header 0.9 inch above the top of the 
            //page (which is 1 inch below the page's top border
            //because of page margin)
            AcmBlock header = new AcmBlock(new AcmText("Header"));
            header.Style.Top = -0.9f;
            container.Children.Add(header);

            //Add the container that contains header and footer
            root.Children.Add(container);

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

            //Add both "p1", "p2" into "root"
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

<span class='cmt'>//Create a new AcmRender object</span>
AcmRender render = <span class='kwd'>new</span> AcmRender(doc);

<span class='cmt'>//The root content. This content must be a block
//content in order to have floating child blocks</span>
AcmBlock root = <span class='kwd'>new</span> AcmBlock();

<span class='cmt'>//This block contains all floating blocks (header
//and footer). Because all child contents are
//floating, this block does not occupy any layout
//space</span>
AcmBlock container = <span class='kwd'>new</span> AcmBlock();

<span class='cmt'>//Position header 0.9 inch above the top of the 
//page (which is 1 inch below the page's top border
//because of page margin)</span>
AcmBlock header = <span class='kwd'>new</span> AcmBlock(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Header&quot;</span>));
header.Style.Top = -0.9f;
container.Children.Add(header);

<span class='cmt'>//Add the container that contains header and footer</span>
root.Children.Add(container);

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

<span class='cmt'>//Add both &quot;p1&quot;, &quot;p2&quot; into &quot;root&quot;</span>
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

<span class='cmt'>'Create a new AcmRender object</span>
<span class='kwd'>Dim</span> render <span class='kwd'>As New</span> AcmRender(doc)

<span class='cmt'>'The root content. This content must be a block
'content in order to have floating child blocks</span>
<span class='kwd'>Dim</span> root <span class='kwd'>As New</span> AcmBlock()

<span class='cmt'>'This block contains all floating blocks (header
'and footer). Because all child contents are
'floating, this block does not occupy any layout
'space</span>
<span class='kwd'>Dim</span> container <span class='kwd'>As New</span> AcmBlock()

<span class='cmt'>'Position header 0.9 inch above the top of the
'page (which is 1 inch below the page's top border
'because of page margin)</span>
<span class='kwd'>Dim</span> header <span class='kwd'>As New</span> AcmBlock(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Header&quot;</span>))
header.Style.Top = -0.9F
container.Children.Add(header)

<span class='cmt'>'Add the container that contains header and footer</span>
root.Children.Add(container)

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
 <span class='st'>&quot;                  Crocodylidae (sometimes classified instead as the &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  subfamily Crocodylinae). The term can also be used more &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  loosely to include all members of the order Crocodilia: &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  i.e. the true crocodiles, the alligators and caimans &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  (family Alligatoridae) and the gharials (family &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  Gavialidae), or even the Crocodylomorpha which includes &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  prehistoric crocodile relatives and ancestors.&quot;</span>)
p2.Children.Add(text2)

<span class='cmt'>'Add both &quot;p1&quot;, &quot;p2&quot; into &quot;root&quot;</span>
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
This sample demonstrates one of the several techniques to create
""out of flow"" contents. The key for this technique is to use
a parent block to host child blocks that are all floated. Once
all child contents of a block are floated, the parent block is
considered ""layout empty"" and does not take up any layout
space.
</p>
<p>
See <a href=""javascript:eo_OpenHelp('Acm/Advanced Formatting/fixed_position.html#float')"">here</a> 
for more information about creating ""out of flow"" content.
</p>
";
        }
    }
}
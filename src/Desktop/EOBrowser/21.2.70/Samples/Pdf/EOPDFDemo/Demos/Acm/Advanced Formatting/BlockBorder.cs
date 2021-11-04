using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;

namespace EOPDFDemo.Acm.AdvancedFormatting
{
    public class BlockBorder : Demo
    {
        public BlockBorder(string path)
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
            AcmBlock block1 = new AcmBlock();
            block1.Style.Border = new AcmBorder(
                null, new AcmLineInfo(0.01f),
                null, new AcmLineInfo(0.01f));
            block1.Style.FontSize = 15f;
            block1.Style.FontStyle = System.Drawing.FontStyle.Bold;
            block1.Style.Margin.Bottom = 0.2f;
            block1.Style.Padding.Top = 0.2f;
            block1.Style.Padding.Bottom = 0.2f;
            AcmText text1 = new AcmText("Crocodile");
            block1.Children.Add(text1);

            AcmBlock block2 = new AcmBlock();
            block2.Style.FontSize = 10f;
            AcmText text2 = new AcmText(
                @"A crocodile is any species belonging to the family of 
                Crocodylidae (sometimes classified instead as the 
                subfamily Crocodylinae). The term can also be used more 
                loosely to include all members of the order Crocodilia: 
                i.e. the true crocodiles, the alligators and caimans 
                (family Alligatoridae) and the gharials (family 
                Gavialidae), or even the Crocodylomorpha which includes 
                prehistoric crocodile relatives and ancestors.");
            block2.Children.Add(text2);

            //Render the text
            render.Render(block1, block2);

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
AcmBlock block1 = <span class='kwd'>new</span> AcmBlock();
block1.Style.Border = <span class='kwd'>new</span> AcmBorder(
    <span class='kwd'>null</span>, <span class='kwd'>new</span> AcmLineInfo(0.01f),
    <span class='kwd'>null</span>, <span class='kwd'>new</span> AcmLineInfo(0.01f));
block1.Style.FontSize = 15f;
block1.Style.FontStyle = System.Drawing.FontStyle.Bold;
block1.Style.Margin.Bottom = 0.2f;
block1.Style.Padding.Top = 0.2f;
block1.Style.Padding.Bottom = 0.2f;
AcmText text1 = <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Crocodile&quot;</span>);
block1.Children.Add(text1);

AcmBlock block2 = <span class='kwd'>new</span> AcmBlock();
block2.Style.FontSize = 10f;
AcmText text2 = <span class='kwd'>new</span> AcmText(
                @<span class='st'>&quot;A crocodile is any species belonging to the family of 
                Crocodylidae (sometimes classified instead as the 
                subfamily Crocodylinae). The term can also be used more 
                loosely to include all members of the order Crocodilia: 
                i.e. the true crocodiles, the alligators and caimans 
                (family Alligatoridae) and the gharials (family 
                Gavialidae), or even the Crocodylomorpha which includes 
                prehistoric crocodile relatives and ancestors.&quot;</span>);
block2.Children.Add(text2);

<span class='cmt'>//Render the text</span>
render.Render(block1, block2);

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
<span class='kwd'>Dim</span> block1 <span class='kwd'>As New</span> AcmBlock()
block1.Style.Border = <span class='kwd'>New</span> AcmBorder(<span class='kwd'>Nothing</span>, <span class='kwd'>New</span> AcmLineInfo(0.01F), _
     <span class='kwd'>Nothing</span>, <span class='kwd'>New</span> AcmLineInfo(0.01F))
block1.Style.FontSize = 15F
block1.Style.FontStyle = System.Drawing.FontStyle.Bold
block1.Style.Margin.Bottom = 0.2F
block1.Style.Padding.Top = 0.2F
block1.Style.Padding.Bottom = 0.2F
<span class='kwd'>Dim</span> text1 <span class='kwd'>As New</span> AcmText(<span class='st'>&quot;Crocodile&quot;</span>)
block1.Children.Add(text1)

<span class='kwd'>Dim</span> block2 <span class='kwd'>As New</span> AcmBlock()
block2.Style.FontSize = 10F
<span class='kwd'>Dim</span> text2 <span class='kwd'>As New</span> AcmText(<span class='st'>&quot;A crocodile is any species belonging to the family of &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                Crocodylidae (sometimes classified instead as the &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                subfamily Crocodylinae). The term can also be used more &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                loosely to include all members of the order Crocodilia: &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                i.e. the true crocodiles, the alligators and caimans &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                (family Alligatoridae) and the gharials (family &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                Gavialidae), or even the Crocodylomorpha which includes &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                prehistoric crocodile relatives and ancestors.&quot;</span>)
block2.Children.Add(text2)

<span class='cmt'>'Render the text</span>
render.Render(block1, block2)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }

        public override string GetInstructions()
        {
            return @"
<p>
EO.Pdf uses a block model that is very similar to Web pages.
This sample demonstrates how to use a block's border, padding
and margin. Both paragraphs are <b>AcmBlock</b> objects. The
code set the first paragraph's Border to create a thin line both
for the top and bottom border. It also set the padding to add
some space within the border and margin bottom to add some
space below the first paragraph.
</p>
<p>
See <a href=""javascript:eo_OpenHelp('Pdf/Acm/Advanced Formatting/block_model.html')"">here</a> 
for more information about EO.Pdf block model.
</p>
";
        }
    }
}
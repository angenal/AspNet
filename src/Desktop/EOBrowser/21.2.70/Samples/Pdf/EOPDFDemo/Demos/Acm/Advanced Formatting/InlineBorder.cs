using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;

namespace EOPDFDemo.Acm.AdvancedFormatting
{
    public class InlineBorder : Demo
    {
        public InlineBorder(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Create a new PdfDocument
            PdfDocument doc = new PdfDocument();

            //Create a new AcmRender object
            AcmRender render = new AcmRender(doc);

            //Create the root object
            AcmBlock block = new AcmBlock();
            block.Style.FontSize = 12f;

            //Create the first text segment
            AcmText text1 = new AcmText(
                @"A crocodile is any species belonging to the family of 
                  Crocodylidae (sometimes classified instead as the 
                  subfamily Crocodylinae).");

            //Create the second text segment
            AcmText text2 = new AcmText(
                @" The term can also be used more loosely to include 
                  all members of the order Crocodilia: ");

            //Create a border and background for this text
            //segment to highlight it
            text2.Style.Border = new AcmBorder(0.01f);
            text2.Style.BackgroundColor = System.Drawing.Color.LightBlue;

            //Create a third text segment
            AcmText text3 = new AcmText(
                @"i.e. the true crocodiles, the alligators and caimans 
                  (family Alligatoridae) and the gharials (family 
                  Gavialidae), or even the Crocodylomorpha which includes 
                  prehistoric crocodile relatives and ancestors.");

            //Add all text segments to the root object
            block.Children.Add(text1);
            block.Children.Add(text2);
            block.Children.Add(text3);

            //Render the text
            render.Render(block);

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

<span class='cmt'>//Create the root object</span>
AcmBlock block = <span class='kwd'>new</span> AcmBlock();
block.Style.FontSize = 12f;

<span class='cmt'>//Create the first text segment</span>
AcmText text1 = <span class='kwd'>new</span> AcmText(
                @<span class='st'>&quot;A crocodile is any species belonging to the family of 
                  Crocodylidae (sometimes classified instead as the 
                  subfamily Crocodylinae).&quot;</span>);

<span class='cmt'>//Create the second text segment</span>
AcmText text2 = <span class='kwd'>new</span> AcmText(
                @<span class='st'>&quot; The term can also be used more loosely to include 
                  all members of the order Crocodilia: &quot;</span>);

<span class='cmt'>//Create a border and background for this text
//segment to highlight it</span>
text2.Style.Border = <span class='kwd'>new</span> AcmBorder(0.01f);
text2.Style.BackgroundColor = System.Drawing.Color.LightBlue;

<span class='cmt'>//Create a third text segment</span>
AcmText text3 = <span class='kwd'>new</span> AcmText(
                @<span class='st'>&quot;i.e. the true crocodiles, the alligators and caimans 
                  (family Alligatoridae) and the gharials (family 
                  Gavialidae), or even the Crocodylomorpha which includes 
                  prehistoric crocodile relatives and ancestors.&quot;</span>);

<span class='cmt'>//Add all text segments to the root object</span>
block.Children.Add(text1);
block.Children.Add(text2);
block.Children.Add(text3);

<span class='cmt'>//Render the text</span>
render.Render(block);

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

<span class='cmt'>'Create the root object</span>
<span class='kwd'>Dim</span> block <span class='kwd'>As New</span> AcmBlock()
block.Style.FontSize = 12F

<span class='cmt'>'Create the first text segment</span>
<span class='kwd'>Dim</span> text1 <span class='kwd'>As New</span> AcmText(<span class='st'>&quot;A crocodile is any species belonging to the family of &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  Crocodylidae (sometimes classified instead as the &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  subfamily Crocodylinae).&quot;</span>)

<span class='cmt'>'Create the second text segment</span>
<span class='kwd'>Dim</span> text2 <span class='kwd'>As New</span> AcmText(<span class='st'>&quot; The term can also be used more loosely to include &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  all members of the order Crocodilia: &quot;</span>)

<span class='cmt'>'Create a border and background for this text
'segment to highlight it</span>
text2.Style.Border = <span class='kwd'>New</span> AcmBorder(0.01F)
text2.Style.BackgroundColor = System.Drawing.Color.LightBlue

<span class='cmt'>'Create a third text segment</span>
<span class='kwd'>Dim</span> text3 <span class='kwd'>As New</span> AcmText(<span class='st'>&quot;i.e. the true crocodiles, the alligators and caimans &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  (family Alligatoridae) and the gharials (family &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  Gavialidae), or even the Crocodylomorpha which includes &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  prehistoric crocodile relatives and ancestors.&quot;</span>)

<span class='cmt'>'Add all text segments to the root object</span>
block.Children.Add(text1)
block.Children.Add(text2)
block.Children.Add(text3)

<span class='cmt'>'Render the text</span>
render.Render(block)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }

        public override string GetInstructions()
        {
            return @"
<p>
This sample demonstrates border and background color on
an inline content. Because an inline content flows from
line to line, while setting border on an inline content
is the same way as setting it on a block content, the
final result is slightly different because the border can
start and end at the middle of the line.
</p>
<p>
See <a href=""javascript:eo_OpenHelp('Pdf/Acm/Advanced Formatting/block_model.html')"">here</a> 
for more information about EO.Pdf block model.
</p>
";
        }
    }
}
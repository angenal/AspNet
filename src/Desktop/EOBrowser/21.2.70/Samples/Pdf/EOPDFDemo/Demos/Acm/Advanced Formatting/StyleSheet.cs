using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;

namespace EOPDFDemo.Acm.AdvancedFormatting
{
    public class StyleSheet : Demo
    {
        public StyleSheet(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Create a new PdfDocument
            PdfDocument doc = new PdfDocument();

            //Create a style sheet
            AcmStyleSheet styleSheet = new AcmStyleSheet();

            //Create the header style
            AcmStyle styleHeader = new AcmStyle();
            styleHeader.Name = "header";
            styleHeader.FontSize = 15f;
            styleHeader.FontStyle = System.Drawing.FontStyle.Bold;

            //Create the body style
            AcmStyle styleBody = new AcmStyle();
            styleBody.Name = "body";
            styleBody.FontSize = 10f;

            //Add the styles into stylesheet
            styleSheet.Add(styleHeader);
            styleSheet.Add(styleBody);

            //Create a new render
            AcmRender render = new AcmRender(doc);

            //This is the root content
            AcmContent root = new AcmContent();
            root.StyleSheet = styleSheet;

            //Create the first paragraph. Paragraph "p1"
            //contains "text1"
            AcmParagraph p1 = new AcmParagraph(new AcmText("Crocodile"));
            p1.StyleName = "header";

            //Create the second paragraph. Paragraph "p2"
            //contains "text2"
            AcmParagraph p2 = new AcmParagraph(new AcmText(
                @"A crocodile is any species belonging to the family of 
                  Crocodylidae (sometimes classified instead as the 
                  subfamily Crocodylinae). The term can also be used more 
                  loosely to include all members of the order Crocodilia: 
                  i.e. the true crocodiles, the alligators and caimans 
                  (family Alligatoridae) and the gharials (family 
                  Gavialidae), or even the Crocodylomorpha which includes 
                  prehistoric crocodile relatives and ancestors."));
            p2.StyleName = "body";

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

<span class='cmt'>//Create a style sheet</span>
AcmStyleSheet styleSheet = <span class='kwd'>new</span> AcmStyleSheet();

<span class='cmt'>//Create the header style</span>
AcmStyle styleHeader = <span class='kwd'>new</span> AcmStyle();
styleHeader.Name = <span class='st'>&quot;header&quot;</span>;
styleHeader.FontSize = 15f;
styleHeader.FontStyle = System.Drawing.FontStyle.Bold;

<span class='cmt'>//Create the body style</span>
AcmStyle styleBody = <span class='kwd'>new</span> AcmStyle();
styleBody.Name = <span class='st'>&quot;body&quot;</span>;
styleBody.FontSize = 10f;

<span class='cmt'>//Add the styles into stylesheet</span>
styleSheet.Add(styleHeader);
styleSheet.Add(styleBody);

<span class='cmt'>//Create a new render</span>
AcmRender render = <span class='kwd'>new</span> AcmRender(doc);

<span class='cmt'>//This is the root content</span>
AcmContent root = <span class='kwd'>new</span> AcmContent();
root.StyleSheet = styleSheet;

<span class='cmt'>//Create the first paragraph. Paragraph &quot;p1&quot;
//contains &quot;text1&quot;</span>
AcmParagraph p1 = <span class='kwd'>new</span> AcmParagraph(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Crocodile&quot;</span>));
p1.StyleName = <span class='st'>&quot;header&quot;</span>;

<span class='cmt'>//Create the second paragraph. Paragraph &quot;p2&quot;
//contains &quot;text2&quot;</span>
AcmParagraph p2 = <span class='kwd'>new</span> AcmParagraph(<span class='kwd'>new</span> AcmText(
                @<span class='st'>&quot;A crocodile is any species belonging to the family of 
                  Crocodylidae (sometimes classified instead as the 
                  subfamily Crocodylinae). The term can also be used more 
                  loosely to include all members of the order Crocodilia: 
                  i.e. the true crocodiles, the alligators and caimans 
                  (family Alligatoridae) and the gharials (family 
                  Gavialidae), or even the Crocodylomorpha which includes 
                  prehistoric crocodile relatives and ancestors.&quot;</span>));
p2.StyleName = <span class='st'>&quot;body&quot;</span>;

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

<span class='cmt'>'Create a style sheet</span>
<span class='kwd'>Dim</span> styleSheet <span class='kwd'>As New</span> AcmStyleSheet()

<span class='cmt'>'Create the header style</span>
<span class='kwd'>Dim</span> styleHeader <span class='kwd'>As New</span> AcmStyle()
styleHeader.Name = <span class='st'>&quot;header&quot;</span>
styleHeader.FontSize = 15F
styleHeader.FontStyle = System.Drawing.FontStyle.Bold

<span class='cmt'>'Create the body style</span>
<span class='kwd'>Dim</span> styleBody <span class='kwd'>As New</span> AcmStyle()
styleBody.Name = <span class='st'>&quot;body&quot;</span>
styleBody.FontSize = 10F

<span class='cmt'>'Add the styles into stylesheet</span>
styleSheet.Add(styleHeader)
styleSheet.Add(styleBody)

<span class='cmt'>'Create a new render</span>
<span class='kwd'>Dim</span> render <span class='kwd'>As New</span> AcmRender(doc)

<span class='cmt'>'This is the root content</span>
<span class='kwd'>Dim</span> root <span class='kwd'>As New</span> AcmContent()
root.StyleSheet = styleSheet

<span class='cmt'>'Create the first paragraph. Paragraph &quot;p1&quot;
'contains &quot;text1&quot;</span>
<span class='kwd'>Dim</span> p1 <span class='kwd'>As New</span> AcmParagraph(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Crocodile&quot;</span>))
p1.StyleName = <span class='st'>&quot;header&quot;</span>

<span class='cmt'>'Create the second paragraph. Paragraph &quot;p2&quot;
'contains &quot;text2&quot;</span>
<span class='kwd'>Dim</span> p2 <span class='kwd'>As New</span> AcmParagraph(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;A crocodile is any species belonging to the family of &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  Crocodylidae (sometimes classified instead as the &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  subfamily Crocodylinae). The term can also be used more &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  loosely to include all members of the order Crocodilia: &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  i.e. the true crocodiles, the alligators and caimans &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  (family Alligatoridae) and the gharials (family &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  Gavialidae), or even the Crocodylomorpha which includes &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                  prehistoric crocodile relatives and ancestors.&quot;</span>))
p2.StyleName = <span class='st'>&quot;body&quot;</span>

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
This sample demonstrates how to use style sheet. EO.Pdf
style sheet works very similar to CSS in Web pages.
A style sheet is especially useful when the same style
needs to be applied to multiple contents.
</p>
<p>
Follow these steps to use style sheet:
</p>
<ol>
    <li>Create an <b>AcmStyleSheet</b> object;</li>
    <li>Create one or more <b>AcmStyle</b> objects and add them
    into the <b>AcmStyleSheet</b> object. Note that you must
    set each <b>AcmStyle</b> object's <b>Name</b> property before
    you can add it into a style sheet;</li>
    <li>Assign the <b>AcmStyleSheet</b> object to the root content's
    <b>StyleSheet</b> property;
    </li>
    <li>Set each <b>AcmContent</b>'s <b>StyleName</b> to reference
    a style in the style sheet;
    </li>
</ol>
<p>
See <a href=""javascript:eo_OpenHelp('Acm/Advanced Formatting/advance_style.html')"">here</a> 
for more information about style sheet. 
</p>
";
        }
    }
}
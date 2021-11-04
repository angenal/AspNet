using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;

namespace EOPDFDemo.Acm.Basic
{
    public class ContentTree2 : Demo
    {
        public ContentTree2(string path)
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
            AcmContent root = new AcmContent(
                new AcmParagraph(new AcmText("Crocodile"))
                    .SetProperty("Style.FontSize", 15f)
                    .SetProperty("Style.FontStyle", System.Drawing.FontStyle.Bold),
                new AcmParagraph(new AcmText(
                    @"A crocodile is any species belonging to the family of 
                      Crocodylidae (sometimes classified instead as the 
                      subfamily Crocodylinae). The term can also be used more 
                      loosely to include all members of the order Crocodilia: 
                      i.e. the true crocodiles, the alligators and caimans 
                      (family Alligatoridae) and the gharials (family 
                      Gavialidae), or even the Crocodylomorpha which includes 
                      prehistoric crocodile relatives and ancestors."))
                    .SetProperty("Style.FontSize", 10f));

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
AcmContent root = <span class='kwd'>new</span> AcmContent(
    <span class='kwd'>new</span> AcmParagraph(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Crocodile&quot;</span>))
        .SetProperty(<span class='st'>&quot;Style.FontSize&quot;</span>, 15f)
        .SetProperty(<span class='st'>&quot;Style.FontStyle&quot;</span>, System.Drawing.FontStyle.Bold),
    <span class='kwd'>new</span> AcmParagraph(<span class='kwd'>new</span> AcmText(
                    @<span class='st'>&quot;A crocodile is any species belonging to the family of 
                      Crocodylidae (sometimes classified instead as the 
                      subfamily Crocodylinae). The term can also be used more 
                      loosely to include all members of the order Crocodilia: 
                      i.e. the true crocodiles, the alligators and caimans 
                      (family Alligatoridae) and the gharials (family 
                      Gavialidae), or even the Crocodylomorpha which includes 
                      prehistoric crocodile relatives and ancestors.&quot;</span>))
        .SetProperty(<span class='st'>&quot;Style.FontSize&quot;</span>, 10f));

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
<span class='kwd'>Dim</span> root <span class='kwd'>As New</span> AcmContent(<span class='kwd'>New</span> AcmParagraph(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Crocodile&quot;</span>)) _
         .SetProperty(<span class='st'>&quot;Style.FontSize&quot;</span>, 15F) _
         .SetProperty(<span class='st'>&quot;Style.FontStyle&quot;</span>, System.Drawing.FontStyle.Bold), _
                     <span class='kwd'>New</span> AcmParagraph(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;A crocodile is any species belonging to the family of &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      Crocodylidae (sometimes classified instead as the &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      subfamily Crocodylinae). The term can also be used more &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      loosely to include all members of the order Crocodilia: &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      i.e. the true crocodiles, the alligators and caimans &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      (family Alligatoridae) and the gharials (family &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      Gavialidae), or even the Crocodylomorpha which includes &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      prehistoric crocodile relatives and ancestors.&quot;</span>)) _
         .SetProperty(<span class='st'>&quot;Style.FontSize&quot;</span>, 10F))

<span class='cmt'>'Render the text</span>
render.Render(root)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }

        public override string GetInstructions()
        {
            return @"
<p>
This sample demonstrates how to create complex content tree
through a single statements. The keys to create content tree
this way are:
<p>
<ul>
    <li>Child contents are directly passed to a parent content
    through the parent content's constructor;</li>
    <li>
    Properties are not set with a separate statement, rather
    they are set by calling <b>SetProperty</b> function. Because
    this function returns the content itself, it is possible
    to call this function multiple times in the same statement
    to set different properties.
    </li>   
</ul>
<p>
    See <a href=""javascript:eo_OpenHelp('Acm/Getting%20Started/contents.html#single_statement')"">here</a> 
for more details about this technique. 
</p>
";
        }
    }
}
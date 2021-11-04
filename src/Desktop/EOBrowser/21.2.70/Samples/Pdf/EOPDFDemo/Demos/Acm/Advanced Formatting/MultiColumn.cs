using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;

namespace EOPDFDemo.Acm.AdvancedFormatting
{
    public class MultiColumn : Demo
    {
        public MultiColumn(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Create a new PdfDocument
            PdfDocument doc = new PdfDocument();

            //Create a new render
            AcmRender render = new AcmRender(doc, 
                new AcmPageLayout(new AcmPadding(1),
                    new AcmColumn(1, 3), new AcmColumn(4.5f, 3)),
                new AcmPageLayout(new AcmPadding(1)));

            //Create a style sheet
            AcmStyleSheet styleSheet = new AcmStyleSheet();

            AcmStyle header = new AcmStyle();
            header.Name = "header";
            header.FontSize = 15f;
            header.FontStyle = System.Drawing.FontStyle.Bold;

            styleSheet.Add(header);

            //This is the root content
            AcmContent root = new AcmContent(
                new AcmParagraph(
                    new AcmText("Crocodile"))
                    .SetProperty("StyleName", "header"),
                new AcmBlock(
                    new AcmImage(LoadImage("Crocodile.jpg"))
                        .SetProperty("Style.Width", 2.6f))
                    .SetProperty("Style.Padding.Bottom", 0.2f),
                new AcmParagraph(new AcmText(
                    @"Crocodiles are among the more biologically complex 
                     reptiles despite their prehistoric look. Unlike other 
                     reptiles, they have a cerebral cortex; a four-chambered 
                     heart; and the functional equivalent of a diaphragm, 
                     by incorporating muscles used for aquatic locomotion 
                     into respiration (e.g. M. diaphragmaticus); Their 
                     external morphology on the other hand is a sign of 
                     their aquatic and predatory lifestyle. A crocodile’s 
                     physical traits allow it to be a successful predator.
                     They have a streamlined body that enables them to swim
                     swiftly. Crocodiles also tuck their feet to their sides
                     while swimming, which makes them faster by decreasing 
                     water resistance. They have webbed feet which, although
                     not used to propel the animal through the water, allow 
                     it to make fast turns and sudden moves in the water or 
                     initiate swimming. Webbed feet are an advantage in 
                     shallower water where the animals sometimes move around
                     by walking.")),
                new AcmParagraph(new AcmText(
                    @"Crocodiles have a palatal flap, a rigid tissue 
                      at the back of the mouth that blocks the entry 
                      of water. The palate has a special path from 
                      the nostril to the glottis that bypasses the 
                      mouth. The nostrils are closed during 
                      submergence. Like other archosaurs, crocodilians 
                      are diapsid, although their post-temporal 
                      fenestrae are reduced. The walls of the 
                      braincase are bony but they lack supratemporal 
                      and postfrontal bones. Their tongues are not 
                      free but held in place by a membrane which 
                      limits movement; as a result, crocodiles are 
                      unable to stick out their tongues.")),
                new AcmParagraph(
                    new AcmText("Biology and behaviour"))
                    .SetProperty("StyleName", "header"),
                new AcmParagraph(new AcmText(
                    @"Crocodiles are ambush hunters, waiting for fish 
                      or land animals to come close, then rushing out 
                      to attack. As cold-blooded predators, they have 
                      a very slow metabolism, and thus can survive long 
                      periods without food. Despite their appearance of 
                      being slow, crocodiles are top predators in their 
                      environment, and various species have been 
                      observed attacking and killing sharks. A famous 
                      exception is the Egyptian Plover which is said 
                      to enjoy a symbiotic relationship with the 
                      crocodile. According to unauthenticated reports, 
                      the plover feeds on parasites that infest the 
                      crocodile's mouth and the crocodile will open 
                      its jaws and let the bird enter to clean parasites 
                      and bits out of the mouth.")),
                new AcmParagraph(new AcmText(
                    @"The land speed record for a crocodile is 17 km/h 
                     (11 mph) measured in a galloping Australian 
                     freshwater crocodile. Maximum speed varies from 
                     species to species. Certain types of crocodiles 
                     can indeed gallop, including Cuban crocodiles, New 
                     Guinea crocodiles, African dwarf crocodiles, and 
                     even small Nile crocodiles. The fastest means by 
                     which most species can move is a kind of ""belly 
                     run"", where the body moves in a snake-like 
                     fashion, limbs splayed out to either side paddling 
                     away frantically while the tail whips to and fro. 
                     Crocodiles can reach speeds of 10 or 11 km/h (
                     around 7 mph) when they ""belly run"", and often 
                     faster if they're slipping down muddy riverbanks. 
                     Another form of locomotion is the ""high walk"" 
                     where the body is raised clear off the ground.")));

            root.Style.FontSize = 10f;
            root.StyleSheet = styleSheet;

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
AcmRender render = <span class='kwd'>new</span> AcmRender(doc, 
    <span class='kwd'>new</span> AcmPageLayout(<span class='kwd'>new</span> AcmPadding(1),
        <span class='kwd'>new</span> AcmColumn(1, 3), <span class='kwd'>new</span> AcmColumn(4.5f, 3)),
    <span class='kwd'>new</span> AcmPageLayout(<span class='kwd'>new</span> AcmPadding(1)));

<span class='cmt'>//Create a style sheet</span>
AcmStyleSheet styleSheet = <span class='kwd'>new</span> AcmStyleSheet();

AcmStyle header = <span class='kwd'>new</span> AcmStyle();
header.Name = <span class='st'>&quot;header&quot;</span>;
header.FontSize = 15f;
header.FontStyle = System.Drawing.FontStyle.Bold;

styleSheet.Add(header);

<span class='cmt'>//This is the root content</span>
AcmContent root = <span class='kwd'>new</span> AcmContent(
    <span class='kwd'>new</span> AcmParagraph(
        <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Crocodile&quot;</span>))
        .SetProperty(<span class='st'>&quot;StyleName&quot;</span>, <span class='st'>&quot;header&quot;</span>),
    <span class='kwd'>new</span> AcmBlock(
        <span class='kwd'>new</span> AcmImage(LoadImage(<span class='st'>&quot;Crocodile.jpg&quot;</span>))
            .SetProperty(<span class='st'>&quot;Style.Width&quot;</span>, 2.6f))
        .SetProperty(<span class='st'>&quot;Style.Padding.Bottom&quot;</span>, 0.2f),
    <span class='kwd'>new</span> AcmParagraph(<span class='kwd'>new</span> AcmText(
                    @<span class='st'>&quot;Crocodiles are among the more biologically complex 
                     reptiles despite their prehistoric look. Unlike other 
                     reptiles, they have a cerebral cortex; a four-chambered 
                     heart; and the functional equivalent of a diaphragm, 
                     by incorporating muscles used for aquatic locomotion 
                     into respiration (e.g. M. diaphragmaticus); Their 
                     external morphology on the other hand is a sign of 
                     their aquatic and predatory lifestyle. A crocodile’s 
                     physical traits allow it to be a successful predator.
                     They have a streamlined body that enables them to swim
                     swiftly. Crocodiles also tuck their feet to their sides
                     while swimming, which makes them faster by decreasing 
                     water resistance. They have webbed feet which, although
                     not used to propel the animal through the water, allow 
                     it to make fast turns and sudden moves in the water or 
                     initiate swimming. Webbed feet are an advantage in 
                     shallower water where the animals sometimes move around
                     by walking.&quot;</span>)),
    <span class='kwd'>new</span> AcmParagraph(<span class='kwd'>new</span> AcmText(
                    @<span class='st'>&quot;Crocodiles have a palatal flap, a rigid tissue 
                      at the back of the mouth that blocks the entry 
                      of water. The palate has a special path from 
                      the nostril to the glottis that bypasses the 
                      mouth. The nostrils are closed during 
                      submergence. Like other archosaurs, crocodilians 
                      are diapsid, although their post-temporal 
                      fenestrae are reduced. The walls of the 
                      braincase are bony but they lack supratemporal 
                      and postfrontal bones. Their tongues are not 
                      free but held in place by a membrane which 
                      limits movement; as a result, crocodiles are 
                      unable to stick out their tongues.&quot;</span>)),
    <span class='kwd'>new</span> AcmParagraph(
        <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Biology and behaviour&quot;</span>))
        .SetProperty(<span class='st'>&quot;StyleName&quot;</span>, <span class='st'>&quot;header&quot;</span>),
    <span class='kwd'>new</span> AcmParagraph(<span class='kwd'>new</span> AcmText(
                    @<span class='st'>&quot;Crocodiles are ambush hunters, waiting for fish 
                      or land animals to come close, then rushing out 
                      to attack. As cold-blooded predators, they have 
                      a very slow metabolism, and thus can survive long 
                      periods without food. Despite their appearance of 
                      being slow, crocodiles are top predators in their 
                      environment, and various species have been 
                      observed attacking and killing sharks. A famous 
                      exception is the Egyptian Plover which is said 
                      to enjoy a symbiotic relationship with the 
                      crocodile. According to unauthenticated reports, 
                      the plover feeds on parasites that infest the 
                      crocodile&#39;s mouth and the crocodile will open 
                      its jaws and let the bird enter to clean parasites 
                      and bits out of the mouth.&quot;</span>)),
    <span class='kwd'>new</span> AcmParagraph(<span class='kwd'>new</span> AcmText(
                    @<span class='st'>&quot;The land speed record for a crocodile is 17 km/h 
                     (11 mph) measured in a galloping Australian 
                     freshwater crocodile. Maximum speed varies from 
                     species to species. Certain types of crocodiles 
                     can indeed gallop, including Cuban crocodiles, New 
                     Guinea crocodiles, African dwarf crocodiles, and 
                     even small Nile crocodiles. The fastest means by 
                     which most species can move is a kind of &quot;&quot;belly 
                     run&quot;&quot;, where the body moves in a snake-like 
                     fashion, limbs splayed out to either side paddling 
                     away frantically while the tail whips to and fro. 
                     Crocodiles can reach speeds of 10 or 11 km/h (
                     around 7 mph) when they &quot;&quot;belly run&quot;&quot;, and often 
                     faster if they&#39;re slipping down muddy riverbanks. 
                     Another form of locomotion is the &quot;&quot;high walk&quot;&quot; 
                     where the body is raised clear off the ground.&quot;</span>)));

root.Style.FontSize = 10f;
root.StyleSheet = styleSheet;

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
<span class='kwd'>Dim</span> render <span class='kwd'>As New</span> AcmRender(doc, _
     <span class='kwd'>New</span> AcmPageLayout(<span class='kwd'>New</span> AcmPadding(1), _
         <span class='kwd'>New</span> AcmColumn(1, 3), <span class='kwd'>New</span> AcmColumn(4.5F, 3)), _
     <span class='kwd'>New</span> AcmPageLayout(<span class='kwd'>New</span> AcmPadding(1)))

<span class='cmt'>'Create a style sheet</span>
<span class='kwd'>Dim</span> styleSheet <span class='kwd'>As New</span> AcmStyleSheet()

<span class='kwd'>Dim</span> header <span class='kwd'>As New</span> AcmStyle()
header.Name = <span class='st'>&quot;header&quot;</span>
header.FontSize = 15F
header.FontStyle = System.Drawing.FontStyle.Bold

styleSheet.Add(header)

<span class='cmt'>'This is the root content</span>
<span class='kwd'>Dim</span> root <span class='kwd'>As New</span> AcmContent(<span class='kwd'>New</span> AcmParagraph(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Crocodile&quot;</span>)) _
         .SetProperty(<span class='st'>&quot;StyleName&quot;</span>, <span class='st'>&quot;header&quot;</span>), _
                     <span class='kwd'>New</span> AcmBlock(<span class='kwd'>New</span> AcmImage(LoadImage(<span class='st'>&quot;Crocodile.jpg&quot;</span>)) _
             .SetProperty(<span class='st'>&quot;Style.Width&quot;</span>, 2.6F)) _
         .SetProperty(<span class='st'>&quot;Style.Padding.Bottom&quot;</span>, 0.2F), _
     <span class='kwd'>New</span> AcmParagraph(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Crocodiles are among the more biologically complex &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     reptiles despite their prehistoric look. Unlike other &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     reptiles, they have a cerebral cortex; a four-chambered &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     heart; and the functional equivalent of a diaphragm, &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     by incorporating muscles used for aquatic locomotion &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     into respiration (e.g. M. diaphragmaticus); Their &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     external morphology on the other hand is a sign of &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     their aquatic and predatory lifestyle. A crocodile’s &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     physical traits allow it to be a successful predator.&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     They have a streamlined body that enables them to swim&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     swiftly. Crocodiles also tuck their feet to their sides&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     while swimming, which makes them faster by decreasing &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     water resistance. They have webbed feet which, although&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     not used to propel the animal through the water, allow &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     it to make fast turns and sudden moves in the water or &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     initiate swimming. Webbed feet are an advantage in &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     shallower water where the animals sometimes move around&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     by walking.&quot;</span>)), _
     <span class='kwd'>New</span> AcmParagraph(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Crocodiles have a palatal flap, a rigid tissue &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      at the back of the mouth that blocks the entry &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      of water. The palate has a special path from &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      the nostril to the glottis that bypasses the &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      mouth. The nostrils are closed during &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      submergence. Like other archosaurs, crocodilians &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      are diapsid, although their post-temporal &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      fenestrae are reduced. The walls of the &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      braincase are bony but they lack supratemporal &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      and postfrontal bones. Their tongues are not &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      free but held in place by a membrane which &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      limits movement; as a result, crocodiles are &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      unable to stick out their tongues.&quot;</span>)), _
                     <span class='kwd'>New</span> AcmParagraph(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Biology and behaviour&quot;</span>)) _
         .SetProperty(<span class='st'>&quot;StyleName&quot;</span>, <span class='st'>&quot;header&quot;</span>), _
     <span class='kwd'>New</span> AcmParagraph(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Crocodiles are ambush hunters, waiting for fish &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      or land animals to come close, then rushing out &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      to attack. As cold-blooded predators, they have &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      a very slow metabolism, and thus can survive long &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      periods without food. Despite their appearance of &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      being slow, crocodiles are top predators in their &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      environment, and various species have been &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      observed attacking and killing sharks. A famous &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      exception is the Egyptian Plover which is said &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      to enjoy a symbiotic relationship with the &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      crocodile. According to unauthenticated reports, &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      the plover feeds on parasites that infest the &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      crocodile's mouth and the crocodile will open &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      its jaws and let the bird enter to clean parasites &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                      and bits out of the mouth.&quot;</span>)), _
     <span class='kwd'>New</span> AcmParagraph(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;The land speed record for a crocodile is 17 km/h &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     (11 mph) measured in a galloping Australian &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     freshwater crocodile. Maximum speed varies from &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     species to species. Certain types of crocodiles &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     can indeed gallop, including Cuban crocodiles, New &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     Guinea crocodiles, African dwarf crocodiles, and &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     even small Nile crocodiles. The fastest means by &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     which most species can move is a kind of &quot;&quot;belly &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     run&quot;&quot;, where the body moves in a snake-like &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     fashion, limbs splayed out to either side paddling &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     away frantically while the tail whips to and fro. &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     Crocodiles can reach speeds of 10 or 11 km/h (&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     around 7 mph) when they &quot;&quot;belly run&quot;&quot;, and often &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     faster if they're slipping down muddy riverbanks. &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     Another form of locomotion is the &quot;&quot;high walk&quot;&quot; &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;                     where the body is raised clear off the ground.&quot;</span>)))

root.Style.FontSize = 10F
root.StyleSheet = styleSheet

<span class='cmt'>'Render the text</span>
render.Render(root)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }

        public override string GetInstructions()
        {
            return @"
<p>
This sample demonstrates how to create multiple columns
on a page. This sample created two columns on the first
page but only one column for the following pages.
</p>
<p>
To customize columns on a page, pass one or more
<b>AcmPageLayout</b> objects to <b>AcmRender</b>'s
constructor. Each <b>AcmPageLayout</b> can have a
different column setting. The first <b>AcmPageLayout</b>
object will be used for the first page, the second
for the second page, and the last object used for all
remaining pages.
</p>
";
        }
    }
}
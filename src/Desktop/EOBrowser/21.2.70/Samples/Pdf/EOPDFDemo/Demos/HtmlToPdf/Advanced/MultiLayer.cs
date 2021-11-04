using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Advanced
{
    public class MultiLayer : Demo
    {
        public MultiLayer(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            PdfDocument doc = new PdfDocument();

            //Render the lower layer
            HtmlToPdf.ConvertHtml("<p style='font-size:100px;color:#d0d0d0;text-align:center'>SAMPLE</p>", doc);

            //Render the top layer
            HtmlToPdf.Options.StartPageIndex = 0;
            HtmlToPdf.Options.StartPosition = 0;
            HtmlToPdf.ConvertHtml(@"
<h2>Multi-Layer Output</h2>
<p>
    This sample demonstrates how you can render multi-layers of
    output on the same page. The bottom layer (""SAMPLE"") is
    created by one conversion and the top layer (this text) is
    created by a second conversion. However because EO.Pdf 
    HTML to PDF converter renders output with a transparent 
    background, the lower layer is shown through.
</p>
", 
                doc);

            doc.Save(result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'>PdfDocument doc = <span class='kwd'>new</span> PdfDocument();

<span class='cmt'>//Render the lower layer</span>
HtmlToPdf.ConvertHtml(<span class='st'>&quot;&lt;p style=&#39;font-size:100px;color:#d0d0d0;text-align:center&#39;&gt;SAMPLE&lt;/p&gt;&quot;</span>, doc);

<span class='cmt'>//Render the top layer</span>
HtmlToPdf.Options.StartPageIndex = 0;
HtmlToPdf.Options.StartPosition = 0;
HtmlToPdf.ConvertHtml(@<span class='st'>&quot;
&lt;h2&gt;Multi-Layer Output&lt;/h2&gt;
&lt;p&gt;
    This sample demonstrates how you can render multi-layers of
    output on the same page. The bottom layer (&quot;&quot;SAMPLE&quot;&quot;) is
    created by one conversion and the top layer (this text) is
    created by a second conversion. However because EO.Pdf 
    HTML to PDF converter renders output with a transparent 
    background, the lower layer is shown through.
&lt;/p&gt;
&quot;</span>, 
    doc);

doc.Save(result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='kwd'>Dim</span> doc <span class='kwd'>As New</span> PdfDocument()

<span class='cmt'>'Render the lower layer</span>
HtmlToPdf.ConvertHtml(<span class='st'>&quot;&lt;p style='font-size:100px;color:#d0d0d0;text-align:center'&gt;SAMPLE&lt;/p&gt;&quot;</span>, doc)

<span class='cmt'>'Render the top layer</span>
HtmlToPdf.Options.StartPageIndex = 0
HtmlToPdf.Options.StartPosition = 0
HtmlToPdf.ConvertHtml(vbCr &amp; vbLf &amp; <span class='st'>&quot;&lt;h2&gt;Multi-Layer Output&lt;/h2&gt;&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;&lt;p&gt;&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;    This sample demonstrates how you can render multi-layers of&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;    output on the same page. The bottom layer (&quot;&quot;SAMPLE&quot;&quot;) is&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;    created by one conversion and the top layer (this text) is&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;    created by a second conversion. However because EO.Pdf &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;    HTML to PDF converter renders output with a transparent &quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;    background, the lower layer is shown through.&quot;</span> &amp; vbCr &amp; vbLf &amp; _
 <span class='st'>&quot;&lt;/p&gt;&quot;</span> &amp; vbCr &amp; vbLf, _
     doc)

doc.Save(result)</pre>";

        }
    }
}

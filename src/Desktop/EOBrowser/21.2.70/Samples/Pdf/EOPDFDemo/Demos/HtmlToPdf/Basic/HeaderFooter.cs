using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Basic
{
    public class HeaderFooter : Demo
    {
        public HeaderFooter(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            string url = args.GetString("txtUrl");
            if (url.Trim() == string.Empty)
                return "Please enter a valid Url.";

            //Setting header and footer format
            HtmlToPdf.Options.HeaderHtmlFormat = args.GetString("txtHeaderFormat");
            HtmlToPdf.Options.FooterHtmlFormat = args.GetString("txtFooterFormat");

            //Convert the Url
            HtmlToPdf.ConvertUrl(url, result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Setting header and footer format</span>
HtmlToPdf.Options.HeaderHtmlFormat = args.GetString(<span class='st'>&quot;txtHeaderFormat&quot;</span>);
HtmlToPdf.Options.FooterHtmlFormat = args.GetString(<span class='st'>&quot;txtFooterFormat&quot;</span>);

<span class='cmt'>//Convert the Url</span>
HtmlToPdf.ConvertUrl(url, result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Setting header and footer format</span>
HtmlToPdf.Options.HeaderHtmlFormat = args.GetString(<span class='st'>&quot;txtHeaderFormat&quot;</span>)
HtmlToPdf.Options.FooterHtmlFormat = args.GetString(<span class='st'>&quot;txtFooterFormat&quot;</span>)

<span class='cmt'>'Convert the Url</span>
HtmlToPdf.ConvertUrl(url, result)</pre>";

        }
    }
}

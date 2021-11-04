using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Basic
{
    public class Link : Demo
    {
        public Link(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            string url = args.GetString("txtUrl");
            if (url.Trim() == string.Empty)
                return "Please enter a valid Url.";

            //Setting NoLink to false if you do not wish
            //to convert links
            HtmlToPdf.Options.NoLink = args.GetString("cbNoLinks") == "1";

            //Convert to PDF
            HtmlToPdf.ConvertUrl(url, result);

            //Restore the default value
            HtmlToPdf.Options.NoLink = false;


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Setting NoLink to false if you do not wish
//to convert links</span>
HtmlToPdf.Options.NoLink = args.GetString(<span class='st'>&quot;cbNoLinks&quot;</span>) == <span class='st'>&quot;1&quot;</span>;

<span class='cmt'>//Convert to PDF</span>
HtmlToPdf.ConvertUrl(url, result);

<span class='cmt'>//Restore the default value</span>
HtmlToPdf.Options.NoLink = <span class='kwd'>false</span>;</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Setting NoLink to false if you do not wish
'to convert links</span>
HtmlToPdf.Options.NoLink = args.GetString(<span class='st'>&quot;cbNoLinks&quot;</span>) = <span class='st'>&quot;1&quot;</span>

<span class='cmt'>'Convert to PDF</span>
HtmlToPdf.ConvertUrl(url, result)

<span class='cmt'>'Restore the default value</span>
HtmlToPdf.Options.NoLink = <span class='kwd'>False</span></pre>";

        }
    }
}

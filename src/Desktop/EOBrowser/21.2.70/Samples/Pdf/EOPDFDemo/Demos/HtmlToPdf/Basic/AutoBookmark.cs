using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Basic
{
    public class AutoBookmark : Demo
    {
        public AutoBookmark(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Get the argument
            string url = args.GetString("txtUrl");
            if (url.Trim() == string.Empty)
                return "Please enter a valid Url.";

            //Set AutoBookmark to true to automatically generates
            //bookmarks
            HtmlToPdf.Options.AutoBookmark = true;

            //Convert the Url. The converter automatically
            //pages the output
            HtmlToPdf.ConvertUrl(url, result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Convert the Url. The converter automatically
//pages the output</span>
HtmlToPdf.ConvertUrl(url, result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Convert the Url. The converter automatically
'pages the output</span>
HtmlToPdf.ConvertUrl(url, result)</pre>";

        }
    }
}

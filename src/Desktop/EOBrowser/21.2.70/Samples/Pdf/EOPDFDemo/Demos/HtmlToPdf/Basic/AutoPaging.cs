using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Basic
{
    public class AutoPaging : Demo
    {
        public AutoPaging(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Get the argument
            string url = args.GetString("txtUrl");
            if (url.Trim() == string.Empty)
                return "Please enter a valid Url.";

            //Zoom out slightly to fit more contents on one page
            HtmlToPdf.Options.ZoomLevel = 0.8f;

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

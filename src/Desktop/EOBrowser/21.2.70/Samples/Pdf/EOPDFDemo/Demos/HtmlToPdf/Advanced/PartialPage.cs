using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Advanced
{
    public class PartialPage : Demo
    {
        public PartialPage(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Get the Url
            string url = args.GetString("txtUrl");
            if (url.Trim() == string.Empty)
                return "Please enter a valid Url.";

            //Get the visible element id list
            string visibleIds = args.GetString("txtVisibleIds");
            if (visibleIds.Trim() == string.Empty)
                return "Please enter one or more visible element Id.";

            //Set VisibleElementIds
            HtmlToPdf.Options.VisibleElementIds = visibleIds;

            //Convert the Url to PDF
            HtmlToPdf.ConvertUrl(url, result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Set VisibleElementIds</span>
HtmlToPdf.Options.VisibleElementIds = visibleIds;

<span class='cmt'>//Convert the Url to PDF</span>
HtmlToPdf.ConvertUrl(url, result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Set VisibleElementIds</span>
HtmlToPdf.Options.VisibleElementIds = visibleIds

<span class='cmt'>'Convert the Url to PDF</span>
HtmlToPdf.ConvertUrl(url, result)</pre>";

        }
    }
}

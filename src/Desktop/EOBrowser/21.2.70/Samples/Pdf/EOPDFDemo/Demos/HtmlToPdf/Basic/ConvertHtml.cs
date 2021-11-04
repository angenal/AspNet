using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Basic
{
    class ConvertHtml : Demo
    {
        public ConvertHtml(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Get the HTML markup
            string html = args.GetString("txtHTML");
            if (html.Trim() == string.Empty)
                return "Please enter the HTML you wish to convert.";

            //Convert the HTML to PDF
            HtmlToPdf.ConvertHtml(html, result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Convert the HTML to PDF</span>
HtmlToPdf.ConvertHtml(html, result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Convert the HTML to PDF</span>
HtmlToPdf.ConvertHtml(html, result)</pre>";

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;
using EO.Pdf.Acm;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Advanced
{
    public class ManualTrigger : Demo
    {
        public ManualTrigger(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Get the HTML markup
            string html = args.GetString("txtHTML");
            if (html.Trim() == string.Empty)
                return "Please enter the HTML you wish to convert.";

            HtmlToPdfOptions options = new HtmlToPdfOptions();
            options.TriggerMode = HtmlToPdfTriggerMode.Dual;

            HtmlToPdf.ConvertHtml(html, result, options);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'>HtmlToPdfOptions options = <span class='kwd'>new</span> HtmlToPdfOptions();
options.TriggerMode = HtmlToPdfTriggerMode.Dual;

HtmlToPdf.ConvertHtml(html, result, options);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='kwd'>Dim</span> options <span class='kwd'>As New</span> HtmlToPdfOptions()
options.TriggerMode = HtmlToPdfTriggerMode.Dual

HtmlToPdf.ConvertHtml(html, result, options)</pre>";

        }
    }
}

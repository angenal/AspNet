using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Advanced
{
    public class ManualPaging : Demo
    {
        public ManualPaging(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            string html = args.GetString("txtHTML");
            if (html.Trim() == string.Empty)
                return "Please enter the HTML you wish to convert.";

            //Applying the following manual paging CSS attributes
            //in your HTML markup before passing it to the HTML
            //to PDF converter:
            //page-break-before: always
            //page-break-after: always
            //page-break-insde: avoid

            //Convert HTML to PDF
            HtmlToPdf.ConvertHtml(html, result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Applying the following manual paging CSS attributes
//in your HTML markup before passing it to the HTML
//to PDF converter:
//page-break-before: always
//page-break-after: always
//page-break-insde: avoid

//Convert HTML to PDF</span>
HtmlToPdf.ConvertHtml(html, result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Applying the following manual paging CSS attributes
'in your HTML markup before passing it to the HTML
'to PDF converter:
'page-break-before: always
'page-break-after: always
'page-break-insde: avoid

'Convert HTML to PDF</span>
HtmlToPdf.ConvertHtml(html, result)</pre>";

        }
    }
}

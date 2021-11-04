using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Basic
{
    public class WebAuth : Demo
    {
        public WebAuth(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            string url = args.GetString("txtUrl");
            if (url.Trim() == string.Empty)
                return "Please enter a valid Url.";

            //Set the user name and password
            HtmlToPdf.Options.UserName = args.GetString("txtUserName");
            HtmlToPdf.Options.Password = args.GetString("txtPassword");

            //Using the above user name and password to
            //login to the Url and convert it into PDF
            HtmlToPdf.ConvertUrl(url, result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Set the user name and password</span>
HtmlToPdf.Options.UserName = args.GetString(<span class='st'>&quot;txtUserName&quot;</span>);
HtmlToPdf.Options.Password = args.GetString(<span class='st'>&quot;txtPassword&quot;</span>);

<span class='cmt'>//Using the above user name and password to
//login to the Url and convert it into PDF</span>
HtmlToPdf.ConvertUrl(url, result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Set the user name and password</span>
HtmlToPdf.Options.UserName = args.GetString(<span class='st'>&quot;txtUserName&quot;</span>)
HtmlToPdf.Options.Password = args.GetString(<span class='st'>&quot;txtPassword&quot;</span>)

<span class='cmt'>'Using the above user name and password to
'login to the Url and convert it into PDF</span>
HtmlToPdf.ConvertUrl(url, result)</pre>";

        }
    }
}

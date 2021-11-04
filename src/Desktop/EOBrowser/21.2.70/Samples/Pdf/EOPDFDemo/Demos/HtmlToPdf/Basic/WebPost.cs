using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Basic
{
    public class WebPost : Demo
    {
        public WebPost(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            string url = args.GetString("txtUrl");
            if (url.Trim() == string.Empty)
                return "Please enter a valid Url.";

            //Adding form data
            HtmlToPdf.Options.AddPostData("cmd", "AddressLabel");
            HtmlToPdf.Options.AddPostData("name", args.GetString("txtName"));
            HtmlToPdf.Options.AddPostData("addr1", args.GetString("txtAddr1"));
            HtmlToPdf.Options.AddPostData("addr2", args.GetString("txtAddr2"));
            HtmlToPdf.Options.AddPostData("city", args.GetString("txtCity"));
            HtmlToPdf.Options.AddPostData("state", args.GetString("txtState"));
            HtmlToPdf.Options.AddPostData("zip", args.GetString("txtZip"));

            //Post the form to the Url and convert the
            //result to a PDF file
            HtmlToPdf.ConvertUrl(url, result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Adding form data</span>
HtmlToPdf.Options.AddPostData(<span class='st'>&quot;cmd&quot;</span>, <span class='st'>&quot;AddressLabel&quot;</span>);
HtmlToPdf.Options.AddPostData(<span class='st'>&quot;name&quot;</span>, args.GetString(<span class='st'>&quot;txtName&quot;</span>));
HtmlToPdf.Options.AddPostData(<span class='st'>&quot;addr1&quot;</span>, args.GetString(<span class='st'>&quot;txtAddr1&quot;</span>));
HtmlToPdf.Options.AddPostData(<span class='st'>&quot;addr2&quot;</span>, args.GetString(<span class='st'>&quot;txtAddr2&quot;</span>));
HtmlToPdf.Options.AddPostData(<span class='st'>&quot;city&quot;</span>, args.GetString(<span class='st'>&quot;txtCity&quot;</span>));
HtmlToPdf.Options.AddPostData(<span class='st'>&quot;state&quot;</span>, args.GetString(<span class='st'>&quot;txtState&quot;</span>));
HtmlToPdf.Options.AddPostData(<span class='st'>&quot;zip&quot;</span>, args.GetString(<span class='st'>&quot;txtZip&quot;</span>));

<span class='cmt'>//Post the form to the Url and convert the
//result to a PDF file</span>
HtmlToPdf.ConvertUrl(url, result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Adding form data</span>
HtmlToPdf.Options.AddPostData(<span class='st'>&quot;cmd&quot;</span>, <span class='st'>&quot;AddressLabel&quot;</span>)
HtmlToPdf.Options.AddPostData(<span class='st'>&quot;name&quot;</span>, args.GetString(<span class='st'>&quot;txtName&quot;</span>))
HtmlToPdf.Options.AddPostData(<span class='st'>&quot;addr1&quot;</span>, args.GetString(<span class='st'>&quot;txtAddr1&quot;</span>))
HtmlToPdf.Options.AddPostData(<span class='st'>&quot;addr2&quot;</span>, args.GetString(<span class='st'>&quot;txtAddr2&quot;</span>))
HtmlToPdf.Options.AddPostData(<span class='st'>&quot;city&quot;</span>, args.GetString(<span class='st'>&quot;txtCity&quot;</span>))
HtmlToPdf.Options.AddPostData(<span class='st'>&quot;state&quot;</span>, args.GetString(<span class='st'>&quot;txtState&quot;</span>))
HtmlToPdf.Options.AddPostData(<span class='st'>&quot;zip&quot;</span>, args.GetString(<span class='st'>&quot;txtZip&quot;</span>))

<span class='cmt'>'Post the form to the Url and convert the
'result to a PDF file</span>
HtmlToPdf.ConvertUrl(url, result)</pre>";

        }
    }
}

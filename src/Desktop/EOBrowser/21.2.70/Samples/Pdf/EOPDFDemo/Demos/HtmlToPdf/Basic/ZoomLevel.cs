using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Basic
{
    public class ZoomLevel : Demo
    {
        public ZoomLevel(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            string url = args.GetString("txtUrl");
            if (url.Trim() == string.Empty)
                return "Please enter a valid Url.";

            //Set zoom level
            HtmlToPdf.Options.ZoomLevel = float.Parse(
                args.GetString("cbZoomLevel"), CultureInfo.InvariantCulture);

            //Convert to PDF
            HtmlToPdf.ConvertUrl(url, result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Set zoom level</span>
HtmlToPdf.Options.ZoomLevel = <span class='kwd'>float</span>.Parse(
    args.GetString(<span class='st'>&quot;cbZoomLevel&quot;</span>), CultureInfo.InvariantCulture);

<span class='cmt'>//Convert to PDF</span>
HtmlToPdf.ConvertUrl(url, result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Set zoom level</span>
HtmlToPdf.Options.ZoomLevel = <span class='kwd'>Single</span>.Parse(args.GetString(<span class='st'>&quot;cbZoomLevel&quot;</span>), CultureInfo.InvariantCulture)

<span class='cmt'>'Convert to PDF</span>
HtmlToPdf.ConvertUrl(url, result)</pre>";

        }
    }
}

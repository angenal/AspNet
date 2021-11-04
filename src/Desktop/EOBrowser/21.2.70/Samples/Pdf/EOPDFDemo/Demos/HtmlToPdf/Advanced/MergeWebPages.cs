using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Advanced
{
    public class MergeWebPages : Demo
    {
        public MergeWebPages(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Get the first Url
            string url1 = args.GetString("txtUrl1");
            if (url1.Trim() == string.Empty)
                return "Please enter a valid Url1.";

            //Get the second Url
            string url2 = args.GetString("txtUrl2");
            if (url2.Trim() == string.Empty)
                return "Please enter a valid Url2.";

            //Create a PdfDocument object
            PdfDocument doc = new PdfDocument();

            //Create a title for the first Url
            HtmlToPdf.Options.Follow(HtmlToPdf.ConvertHtml(
                string.Format("<p>The first Url - {0}</p>", 
                System.Web.HttpUtility.HtmlEncode(url1)), doc));

            //Convert the first Url into the PdfDocument object
            HtmlToPdf.Options.Follow(HtmlToPdf.ConvertUrl(url1, doc));

            //Create a title for the second Url
            HtmlToPdf.Options.Follow(HtmlToPdf.ConvertHtml(
                string.Format("<p>The second Url - {0}</p>",
                System.Web.HttpUtility.HtmlEncode(url2)), doc));

            //Convert the second Url into the PdfDocument object
            HtmlToPdf.ConvertUrl(url2, doc);

            //Save the result
            doc.Save(result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Get the first Url</span>
<span class='kwd'>string</span> url1 = args.GetString(<span class='st'>&quot;txtUrl1&quot;</span>);
<span class='kwd'>if</span> (url1.Trim() == <span class='kwd'>string</span>.Empty)
    <span class='kwd'>return</span> <span class='st'>&quot;Please enter a valid Url1.&quot;</span>;

<span class='cmt'>//Get the second Url</span>
<span class='kwd'>string</span> url2 = args.GetString(<span class='st'>&quot;txtUrl2&quot;</span>);
<span class='kwd'>if</span> (url2.Trim() == <span class='kwd'>string</span>.Empty)
    <span class='kwd'>return</span> <span class='st'>&quot;Please enter a valid Url2.&quot;</span>;

<span class='cmt'>//Create a PdfDocument object</span>
PdfDocument doc = <span class='kwd'>new</span> PdfDocument();

<span class='cmt'>//Create a title for the first Url</span>
HtmlToPdf.Options.Follow(HtmlToPdf.ConvertHtml(
    <span class='kwd'>string</span>.Format(<span class='st'>&quot;&lt;p&gt;The first Url - {0}&lt;/p&gt;&quot;</span>, 
    System.Web.HttpUtility.HtmlEncode(url1)), doc));

<span class='cmt'>//Convert the first Url into the PdfDocument object</span>
HtmlToPdf.Options.Follow(HtmlToPdf.ConvertUrl(url1, doc));

<span class='cmt'>//Create a title for the second Url</span>
HtmlToPdf.Options.Follow(HtmlToPdf.ConvertHtml(
    <span class='kwd'>string</span>.Format(<span class='st'>&quot;&lt;p&gt;The second Url - {0}&lt;/p&gt;&quot;</span>,
    System.Web.HttpUtility.HtmlEncode(url2)), doc));

<span class='cmt'>//Convert the second Url into the PdfDocument object</span>
HtmlToPdf.ConvertUrl(url2, doc);

<span class='cmt'>//Save the result</span>
doc.Save(result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Get the first Url</span>
<span class='kwd'>Dim</span> url1 <span class='kwd'>As String</span> = args.GetString(<span class='st'>&quot;txtUrl1&quot;</span>)
<span class='kwd'>If</span> url1.Trim() = <span class='kwd'>String</span>.Empty <span class='kwd'>Then
    Return</span> <span class='st'>&quot;Please enter a valid Url1.&quot;</span>
<span class='kwd'>End If</span>

<span class='cmt'>'Get the second Url</span>
<span class='kwd'>Dim</span> url2 <span class='kwd'>As String</span> = args.GetString(<span class='st'>&quot;txtUrl2&quot;</span>)
<span class='kwd'>If</span> url2.Trim() = <span class='kwd'>String</span>.Empty <span class='kwd'>Then
    Return</span> <span class='st'>&quot;Please enter a valid Url2.&quot;</span>
<span class='kwd'>End If</span>

<span class='cmt'>'Create a PdfDocument object</span>
<span class='kwd'>Dim</span> doc <span class='kwd'>As New</span> PdfDocument()

<span class='cmt'>'Create a title for the first Url</span>
HtmlToPdf.Options.Follow(HtmlToPdf.ConvertHtml(<span class='kwd'>String</span>.Format(<span class='st'>&quot;&lt;p&gt;The first Url - {0}&lt;/p&gt;&quot;</span>, _
                                      System.Web.HttpUtility.HtmlEncode(url1)), _
                                               doc))

<span class='cmt'>'Convert the first Url into the PdfDocument object</span>
HtmlToPdf.Options.Follow(HtmlToPdf.ConvertUrl(url1, doc))

<span class='cmt'>'Create a title for the second Url</span>
HtmlToPdf.Options.Follow(HtmlToPdf.ConvertHtml(<span class='kwd'>String</span>.Format(<span class='st'>&quot;&lt;p&gt;The second Url - {0}&lt;/p&gt;&quot;</span>, _
                                      System.Web.HttpUtility.HtmlEncode(url2)), _
                                               doc))

<span class='cmt'>'Convert the second Url into the PdfDocument object</span>
HtmlToPdf.ConvertUrl(url2, doc)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }
    }
}

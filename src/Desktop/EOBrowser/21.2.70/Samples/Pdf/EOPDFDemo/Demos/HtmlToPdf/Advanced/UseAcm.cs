using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;
using EO.Pdf.Acm;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Advanced
{
    public class UseAcm : Demo
    {
        public UseAcm(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            string url = args.GetString("txtUrl");
            if (url.Trim() == string.Empty)
                return "Please enter a valid Url.";

            //Set custom AfterRenderPage handler. This
            //handler is called after the convert finishes
            //converting each page
            HtmlToPdf.Options.AfterRenderPage = new PdfPageEventHandler(OnAfterRenderPage);

            //Convert the Url to PDF
            HtmlToPdf.ConvertUrl(url, result);


            return null;
        }

        private void OnAfterRenderPage(object sender, PdfPageEventArgs e)
        {
            //Use ACM to output a page header on the
            //page. See ACM documentation for more
            //information on how to use ACM
            AcmRender render = new AcmRender(
                e.Page, 0f, new AcmPageLayout(new AcmPadding(1, 0.5f, 1, 0.5f)));

            AcmText text = new AcmText(string.Format("Page {0}", e.Page.Index + 1));

            render.Render(text);
        }


        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='kwd'>string</span> url = args.GetString(<span class='st'>&quot;txtUrl&quot;</span>);
    <span class='kwd'>if</span> (url.Trim() == <span class='kwd'>string</span>.Empty)
        <span class='kwd'>return</span> <span class='st'>&quot;Please enter a valid Url.&quot;</span>;

    <span class='cmt'>//Set custom AfterRenderPage handler. This
    //handler is called after the convert finishes
    //converting each page</span>
    HtmlToPdf.Options.AfterRenderPage = <span class='kwd'>new</span> PdfPageEventHandler(OnAfterRenderPage);

    <span class='cmt'>//Convert the Url to PDF</span>
    HtmlToPdf.ConvertUrl(url, result);


<span class='kwd'>private void</span> OnAfterRenderPage(<span class='kwd'>object</span> sender, PdfPageEventArgs e)
{
    <span class='cmt'>//Use ACM to output a page header on the
    //page. See ACM documentation for more
    //information on how to use ACM</span>
    AcmRender render = <span class='kwd'>new</span> AcmRender(
        e.Page, 0f, <span class='kwd'>new</span> AcmPageLayout(<span class='kwd'>new</span> AcmPadding(1, 0.5f, 1, 0.5f)));

    AcmText text = <span class='kwd'>new</span> AcmText(<span class='kwd'>string</span>.Format(<span class='st'>&quot;Page {0}&quot;</span>, e.Page.Index + 1));

    render.Render(text);
}</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='kwd'>Dim</span> url <span class='kwd'>As String</span> = args.GetString(<span class='st'>&quot;txtUrl&quot;</span>)
    <span class='kwd'>If</span> url.Trim() = <span class='kwd'>String</span>.Empty <span class='kwd'>Then
        Return</span> <span class='st'>&quot;Please enter a valid Url.&quot;</span>
    <span class='kwd'>End If</span>

    <span class='cmt'>'Set custom AfterRenderPage handler. This
    'handler is called after the convert finishes
    'converting each page</span>
    HtmlToPdf.Options.AfterRenderPage = <span class='kwd'>New</span> PdfPageEventHandler(<span class='kwd'>AddressOf</span> OnAfterRenderPage)

    <span class='cmt'>'Convert the Url to PDF</span>
    HtmlToPdf.ConvertUrl(url, result)


<span class='kwd'>Private Sub</span> OnAfterRenderPage(sender <span class='kwd'>As Object</span>, e <span class='kwd'>As</span> PdfPageEventArgs)
    <span class='cmt'>'Use ACM to output a page header on the
    'page. See ACM documentation for more
    'information on how to use ACM</span>
    <span class='kwd'>Dim</span> render <span class='kwd'>As New</span> AcmRender(e.Page, 0F, <span class='kwd'>New</span> AcmPageLayout(<span class='kwd'>New</span> AcmPadding(1, 0.5F, 1, 0.5F)))

    <span class='kwd'>Dim</span> text <span class='kwd'>As New</span> AcmText(<span class='kwd'>String</span>.Format(<span class='st'>&quot;Page {0}&quot;</span>, e.Page.Index + 1))

    render.Render(text)
<span class='kwd'>End Sub</span></pre>";

        }
    }
}

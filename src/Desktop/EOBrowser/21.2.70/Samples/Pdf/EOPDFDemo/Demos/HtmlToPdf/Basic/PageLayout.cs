using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Basic
{
    public class PageLayout : Demo
    {
        public PageLayout(string path)
            : base(path)
        {
        }

        private float GetMargin(
            IDemoArgs args, string varName, string marginName)
        {
            string margin = args.GetString(varName);
            try
            {
                return float.Parse(margin);
            }
            catch
            {
                throw new Exception("Please enter a valid '" + marginName + "' value.");
            }
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Get the Url
            string url = args.GetString("txtUrl");
            if (url.Trim() == string.Empty)
                return "Please enter a valid Url.";

            try
            {
                //Get Page layout arguments
                string pageSizeName = args.GetString("cbPageSize");
                SizeF pageSize = PdfPageSizes.FromName(pageSizeName);
                float marginLeft = GetMargin(args, "txtMarginLeft", "Margin Left");
                float marginTop = GetMargin(args, "txtMarginTop", "Margin Top");
                float marginRight = GetMargin(args, "txtMarginRight", "Margin Right");
                float marginBottom = GetMargin(args, "txtMarginBottom", "Margin Bottom");
                bool autoFitWidth = args.GetString("cbAutoFitWidth") == "1";

                //Set page layout arguments
                HtmlToPdf.Options.PageSize = pageSize;
                HtmlToPdf.Options.OutputArea = new RectangleF(
                    marginLeft, marginTop,
                    pageSize.Width - marginLeft - marginRight,
                    pageSize.Height - marginTop - marginBottom);
                if (autoFitWidth)
                    HtmlToPdf.Options.AutoFitX = HtmlToPdfAutoFitMode.ShrinkToFit;
                else
                    HtmlToPdf.Options.AutoFitX = HtmlToPdfAutoFitMode.None;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            //Convert the Url
            HtmlToPdf.ConvertUrl(url, result);

            return null;
        }


        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='kwd'>private float</span> GetMargin(
    IDemoArgs args, <span class='kwd'>string</span> varName, <span class='kwd'>string</span> marginName)
{
    <span class='kwd'>string</span> margin = args.GetString(varName);
    <span class='kwd'>try</span>
    {
        <span class='kwd'>return float</span>.Parse(margin);
    }
    <span class='kwd'>catch</span>
    {
        <span class='kwd'>throw new</span> Exception(<span class='st'>&quot;Please enter a valid &#39;&quot;</span> + marginName + <span class='st'>&quot;&#39; value.&quot;</span>);
    }
}

<span class='kwd'>public override string</span> RunDemo(Stream result, IDemoArgs args)
{
    <span class='cmt'>//Get the Url</span>
    <span class='kwd'>string</span> url = args.GetString(<span class='st'>&quot;txtUrl&quot;</span>);
    <span class='kwd'>if</span> (url.Trim() == <span class='kwd'>string</span>.Empty)
        <span class='kwd'>return</span> <span class='st'>&quot;Please enter a valid Url.&quot;</span>;

    <span class='kwd'>try</span>
    {
        <span class='cmt'>//Get Page layout arguments</span>
        <span class='kwd'>string</span> pageSizeName = args.GetString(<span class='st'>&quot;cbPageSize&quot;</span>);
        SizeF pageSize = PdfPageSizes.FromName(pageSizeName);
        <span class='kwd'>float</span> marginLeft = GetMargin(args, <span class='st'>&quot;txtMarginLeft&quot;</span>, <span class='st'>&quot;Margin Left&quot;</span>);
        <span class='kwd'>float</span> marginTop = GetMargin(args, <span class='st'>&quot;txtMarginTop&quot;</span>, <span class='st'>&quot;Margin Top&quot;</span>);
        <span class='kwd'>float</span> marginRight = GetMargin(args, <span class='st'>&quot;txtMarginRight&quot;</span>, <span class='st'>&quot;Margin Right&quot;</span>);
        <span class='kwd'>float</span> marginBottom = GetMargin(args, <span class='st'>&quot;txtMarginBottom&quot;</span>, <span class='st'>&quot;Margin Bottom&quot;</span>);
        <span class='kwd'>bool</span> autoFitWidth = args.GetString(<span class='st'>&quot;cbAutoFitWidth&quot;</span>) == <span class='st'>&quot;1&quot;</span>;

        <span class='cmt'>//Set page layout arguments</span>
        HtmlToPdf.Options.PageSize = pageSize;
        HtmlToPdf.Options.OutputArea = <span class='kwd'>new</span> RectangleF(
            marginLeft, marginTop,
            pageSize.Width - marginLeft - marginRight,
            pageSize.Height - marginTop - marginBottom);
        <span class='kwd'>if</span> (autoFitWidth)
            HtmlToPdf.Options.AutoFitX = HtmlToPdfAutoFitMode.ShrinkToFit;
        <span class='kwd'>else</span>
            HtmlToPdf.Options.AutoFitX = HtmlToPdfAutoFitMode.None;
    }
    <span class='kwd'>catch</span> (Exception ex)
    {
        <span class='kwd'>return</span> ex.Message;
    }

    <span class='cmt'>//Convert the Url</span>
    HtmlToPdf.ConvertUrl(url, result);

    <span class='kwd'>return null</span>;
}</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='kwd'>Private Function</span> GetMargin(args <span class='kwd'>As</span> IDemoArgs, varName <span class='kwd'>As String</span>, marginName <span class='kwd'>As String</span>) <span class='kwd'>As Single
    Dim</span> margin <span class='kwd'>As String</span> = args.GetString(varName)
    <span class='kwd'>Try
        Return Single</span>.Parse(margin)
    <span class='kwd'>Catch
        Throw New</span> Exception(<span class='st'>&quot;Please enter a valid '&quot;</span> &amp; marginName &amp; <span class='st'>&quot;' value.&quot;</span>)
    <span class='kwd'>End Try
End Function

Public Overrides Function</span> RunDemo(result <span class='kwd'>As</span> Stream, args <span class='kwd'>As</span> IDemoArgs) <span class='kwd'>As String</span>
    <span class='cmt'>'Get the Url</span>
    <span class='kwd'>Dim</span> url <span class='kwd'>As String</span> = args.GetString(<span class='st'>&quot;txtUrl&quot;</span>)
    <span class='kwd'>If</span> url.Trim() = <span class='kwd'>String</span>.Empty <span class='kwd'>Then
        Return</span> <span class='st'>&quot;Please enter a valid Url.&quot;</span>
    <span class='kwd'>End If

    Try</span>
        <span class='cmt'>'Get Page layout arguments</span>
        <span class='kwd'>Dim</span> pageSizeName <span class='kwd'>As String</span> = args.GetString(<span class='st'>&quot;cbPageSize&quot;</span>)
        <span class='kwd'>Dim</span> pageSize <span class='kwd'>As</span> SizeF = PdfPageSizes.FromName(pageSizeName)
        <span class='kwd'>Dim</span> marginLeft <span class='kwd'>As Single</span> = GetMargin(args, <span class='st'>&quot;txtMarginLeft&quot;</span>, <span class='st'>&quot;Margin Left&quot;</span>)
        <span class='kwd'>Dim</span> marginTop <span class='kwd'>As Single</span> = GetMargin(args, <span class='st'>&quot;txtMarginTop&quot;</span>, <span class='st'>&quot;Margin Top&quot;</span>)
        <span class='kwd'>Dim</span> marginRight <span class='kwd'>As Single</span> = GetMargin(args, <span class='st'>&quot;txtMarginRight&quot;</span>, <span class='st'>&quot;Margin Right&quot;</span>)
        <span class='kwd'>Dim</span> marginBottom <span class='kwd'>As Single</span> = GetMargin(args, <span class='st'>&quot;txtMarginBottom&quot;</span>, <span class='st'>&quot;Margin Bottom&quot;</span>)
        <span class='kwd'>Dim</span> autoFitWidth <span class='kwd'>As Boolean</span> = args.GetString(<span class='st'>&quot;cbAutoFitWidth&quot;</span>) = <span class='st'>&quot;1&quot;</span>

        <span class='cmt'>'Set page layout arguments</span>
        HtmlToPdf.Options.PageSize = pageSize
        HtmlToPdf.Options.OutputArea = <span class='kwd'>New</span> RectangleF(marginLeft, marginTop, _
                            pageSize.Width - marginLeft - marginRight, _
                             pageSize.Height - marginTop - marginBottom)
        <span class='kwd'>If</span> autoFitWidth <span class='kwd'>Then</span>
            HtmlToPdf.Options.AutoFitX = HtmlToPdfAutoFitMode.ShrinkToFit
        <span class='kwd'>Else</span>
            HtmlToPdf.Options.AutoFitX = HtmlToPdfAutoFitMode.None
        <span class='kwd'>End If
    Catch</span> ex <span class='kwd'>As</span> Exception
        <span class='kwd'>Return</span> ex.Message
    <span class='kwd'>End Try</span>

    <span class='cmt'>'Convert the Url</span>
    HtmlToPdf.ConvertUrl(url, result)

    <span class='kwd'>Return Nothing
End Function</span></pre>";

        }
    }
}

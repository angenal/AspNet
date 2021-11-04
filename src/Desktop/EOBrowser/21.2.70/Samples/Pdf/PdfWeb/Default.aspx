<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EO.Pdf Web Demo</title>
    <link rel="Stylesheet" href="Demo.css" />
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        EO.Pdf Samples</h1>
    <p>
        Samples for EO.Pdf are provided in two different projects:
    </p>
    <a name="demo"></a>
    <h4>
        EO.Pdf Demo Application</h4>
    <div style="padding-left: 10px">
        <p>
            <b>Note: This application contains most samples. Check this application first regardless
                whether you use EO.Pdf in a Web application or not. </b>
        </p>
        <p>
            This application contains all the samples about creating PDF files, including:
        </p>
        <ul>
            <li>Converting HTML page or text into PDF file;</li>
            <li>Generating PDF file using PDF Creator (low level ACM objects);</li>
            <li>Working with existing PDF files;</li>
            <li>Advanced Features such as PDF encryptions;</li>
        </ul>
        <p>
            You can run this demo application by selecting <i>All Programs -> EO.Pdf xxxx
            -> Samples -> EO.Pdf Demo</i> from your Windows start menu. 
            Full C# and VB source code for the sample application are available in 
            "Samples -> EOPdfDemo" sub directory under the installation folder.
        </p>
    </div>
    <a name="web_demo"></a>
    <h4>
        EO.Pdf Web Demo Application</h4>
    <div style="padding-left: 10px">
        <p>
            This application contains several samples that demonstrate a few useful techniques
            that are unique in a Web application:
        </p>
        <p>
            <a href="ASPXToPDF.aspx">Simple ASPX To PDF Sample</a>. This sample
            demonstrates how to use <b>EO.Web.ASPXToPDF</b> server control to render <b>the
            current ASP.NET</b> page as PDF.
        </p>
        <p>
            <a href="HtmlToPdf1.aspx">Simple HTML to PDF Sample</a>. This sample
            demonstrates how to convert <b>any HTML</b> to PDF on the fly and sends the
            output to the client in an ASP.NET application.
        </p>
        <p>
            <a href="HtmlToPdf2.aspx">HTML to PDF Sample with Downloader</a>. This
            sample is similar to the previous sample but uses <b>EO.Web.Downloader</b>
            control to send the output to the client.
        </p>
        <p>
            <a href="HtmlToPdf3.aspx">HTML to PDF Sample with Downloader using Temporary File</a>.
            This sample is similar to the previous sample but also uses a temporary
            file.
        </p>
        <p>
             The main purpose of the EO.Pdf Web Demo application is to demonstrate 
             techniques and typical scenarios that are unique for an ASP.NET 
             application. Such as how to send the file to the client "on the fly" 
             in a Web application. For general tasks such as loading
             existing PDF file or various ways to generate PDF files,             
             Please refer to <a href="#demo">EO.Pdf 
             Demo Application</a>.
        </p>
        <p>
            Full C# and .ASPX source code are available in "Samples -> Web"
            sub directory under the installation folder. This application also
            includes two server side test page for "Web Authentication" and
            "Web Post Back" sample in the EO.Pdf Demo Application for your
            reference.
        </p>
    </div>
    </form>
</body>
</html>

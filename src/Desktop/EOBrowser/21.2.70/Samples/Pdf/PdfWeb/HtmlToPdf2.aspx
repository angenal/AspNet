<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HtmlToPdf2.aspx.cs" Inherits="HtmlToPdf2" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HTML to PDF Demo with Downloader</title>
    <link rel="Stylesheet" href="Demo.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <h4>
            HTML to PDF Demo with Downloader</h4>
        
        <p>
        This sample is based on the basic <a href="HtmlToPdf1.aspx">HTML to PDF Demo</a>.
        Unlike that sample that opens the PDF file directly in the browser,
        this sample uses <a target="_blank" href="http://www.essentialobjects.com/Products/EOWeb/Downloader.aspx">EO.Web Downloader control</a>
        to force a "Save As" dialog so that user can save the PDF file. You
        can also set the save as file name with the downloader control.
        </p>
        <p>
            <b>Note:</b> The <b>Downloader</b> control is a part of
            EO.Web Controls library, which requires a different license.
        </p>
        <div runat="server" id="divInput">
            <p>
                Please enter a Url to convert:
            </p>
            <asp:TextBox runat="server" ID="txtUrl" Width="350px" Text="http://www.google.com"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUrl"
                ErrorMessage="Url is required."></asp:RequiredFieldValidator>
            <p>
                <asp:Button runat="server" ID="btnConvert" Text="Convert" />
            </p>
        </div>
        <eo:Downloader runat="server" ID="Downloader1" DownloadButtonID="btnConvert" 
             DirectLinkLabelID="lblDownloadLink" CausesValidation="true"
             DirectLinkLabelFormat="If the download did not start automatically, click <a href='{0}'>here</a>."
            DynamicContent="true" OnDownload="Downloader1_Download"></eo:Downloader>
        <asp:Label runat="server" ID="lblDownloadLink"></asp:Label>
    </div>
    </form>
</body>
</html>

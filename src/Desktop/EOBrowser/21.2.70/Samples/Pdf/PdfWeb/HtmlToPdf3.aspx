<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HtmlToPdf3.aspx.cs" Inherits="HtmlToPdf3" %>

<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HTML to PDF Demo with Temporary File</title>
    <link rel="Stylesheet" href="Demo.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h4>
            HTML to PDF Demo with Temporary File</h4>
        <p>
            This sample demonstrates how to create a temporary PDF file and then send the file
            to the client. This technique is useful when you need to convert a long HTML file
            that may take a few seconds or even longer.
        </p>
        <p>
            <b>Note:</b> This sample uses <b>Downloader</b> and <b>CallbackPanel</b> control.
            Both controls are a part of EO.Web Controls library, which requires a different
            license.
        </p>
        <eo:CallbackPanel runat="server" ID="CallbackPanel1" Width="400px" Height="150px"
            LoadingHTML="&lt;img src=&quot;loading.gif&quot; /&gt;
&lt;div style='padding-top:10px;'&gt;Please wait while the PDF file is being generated....&lt;/div&gt;" Triggers="{ControlID:btnConvert;Parameter:}">
            <div runat="server" id="divInput">
                <p>
                    Please enter a Url to convert:
                </p>
                <asp:TextBox runat="server" ID="txtUrl" Width="350px" Text="http://en.wikipedia.org/wiki/HTML"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUrl"
                    ErrorMessage="Url is required."></asp:RequiredFieldValidator>
                <p>
                    <asp:Button runat="server" ID="btnConvert" Text="Convert" OnClick="btnConvert_Click" />
                </p>
            </div>
            <div runat="server" id="divResult" visible="false">
                Your file is ready. Click
                <asp:LinkButton runat="server" ID="lblDownload" Text="here"></asp:LinkButton>
                to download.
                <eo:Downloader runat="server" ID="Downloader1" DownloadButtonID="lblDownload" 
                 AutoHideDownloadButton="false" SaveAsFileName="HtmlToPdf_Demo.pdf">
                </eo:Downloader>
            </div>
        </eo:CallbackPanel>
    </div>
    </form>
</body>
</html>

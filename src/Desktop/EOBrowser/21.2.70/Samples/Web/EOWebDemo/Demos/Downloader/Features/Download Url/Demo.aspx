<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Downloader_Features_Download_Url_Demo" Title="Untitled Page" %>
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web Downloader can also help you to download files from other servers. To 
    use this feature, set the Downloader control's <b>Url</b> property instead of <b>FilePath</b>
    property.
</p>
<p>
    The following sample demonstrates this feature by setting the downloader's Url 
    property to a test file on our server(http://www.essentialobjects.com/DownloadTest.zip).
</p>
<p>
    <eo:Downloader runat="server" id="Downloader1" DownloadButtonID="Button1" DirectLinkLabelID="Label1"
        Url="http://www.essentialobjects.com/DownloadTest.zip"></eo:Downloader>
</p>
<asp:Button Runat="server" ID="Button1" Text="Download Test File"></asp:Button>
<asp:Label Runat="server" ID="Label1"></asp:Label>
</asp:Content>


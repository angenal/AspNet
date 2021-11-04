<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Downloader_Features_Dynamic_Contents_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web Downloader can generate dynamic download content on the fly. The 
    following sample demonstrates this feature. You can enter a line count number 
    and the downloader will dynamically generates a text file with that number of 
    lines for download.
</p>
<p>
    See remarks section for more details about how to use this feature.
</p>
Enter Line Count:
<asp:TextBox Runat="server" ID="TextBox1"></asp:TextBox>
<p>
    <eo:Downloader runat="server" id="Downloader1" DownloadButtonID="Button1" DirectLinkLabelID="Label1"
        DynamicContent="True" OnDownload="Downloader1_Download"></eo:Downloader>
    <asp:Label Runat="server" ID="Label1"></asp:Label>
</p>
<asp:Button Runat="server" ID="Button1" Text="Generate File &amp; Download"></asp:Button>
</asp:Content>


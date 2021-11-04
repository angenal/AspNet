<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Downloader_Features_Basic_Features_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    Simply set the Downloader control's <b>FilePath</b> and <b>DownloadButtonID</b> 
    property and you are ready to go. You can also optionally set the Downloader's <b>DirectLinkLabelID</b>
    property so that it displays a direct download link.
</p>
<p>
    <eo:Downloader runat="server" id="Downloader1" DownloadButtonID="Button1" DirectLinkLabelID="Label1"></eo:Downloader>
</p>
<asp:Button Runat="server" ID="Button1" Text="Download Demo DB"></asp:Button>
<asp:Label Runat="server" ID="Label1"></asp:Label>
</asp:Content>


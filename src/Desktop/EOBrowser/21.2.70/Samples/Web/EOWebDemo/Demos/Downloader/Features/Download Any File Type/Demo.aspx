<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Downloader_Features_Download_Any_File_Type_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web Downloader can be used to download any type of files. The following 
    samples demonstrate downloading an .ascx file and a .jpg file.
</p>
<div style="HEIGHT:100px">
    <p>Download .aspx file:</p>
    <p>
        <eo:Downloader runat="server" id="Downloader1" DirectLinkLabelID="Label1" DownloadButtonID="Button1"></eo:Downloader>
        <asp:Button Runat="server" ID="Button1" Text="Download"></asp:Button>
        <asp:Label Runat="server" ID="Label1"></asp:Label>
    </p>
</div>
<div style="HEIGHT:100px">
    <p>Download .jpg file:</p>
    <p>
        <eo:Downloader runat="server" id="Downloader2" DirectLinkLabelID="Label2" DownloadButtonID="Button2"></eo:Downloader>
        <asp:Button Runat="server" ID="Button2" Text="Download"></asp:Button>
        <asp:Label Runat="server" ID="Label2"></asp:Label>
    </p>
</div>
</asp:Content>


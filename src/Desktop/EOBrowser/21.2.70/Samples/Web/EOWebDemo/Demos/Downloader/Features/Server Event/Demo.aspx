<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Downloader_Features_Server_Event_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web Downloader can raise a server side event every time user downloads. You 
    can use this event to record download activities.
</p>
<p>
    <eo:Downloader runat="server" id="Downloader1" DownloadButtonID="Button1" DirectLinkLabelID="Label1"></eo:Downloader>
</p>
<asp:Button Runat="server" ID="Button1" Text="Download Demo DB"></asp:Button>
<asp:Label Runat="server" ID="Label1"></asp:Label>
<p>
    <asp:Label Runat="server" ID="Label2"></asp:Label>
</p>
</asp:Content>


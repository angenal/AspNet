<%@ Page Title="ASPX To PDF Basic Feature" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ASPX_To_PDF_Basic_Feature_Demo" %>
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
This sample demonstrates how to use ASPXToPDF in
a Web page. Click the following button to export
the current page as PDF. See "VB.NET" or "C#" tab for 
related source code.
</p>
<eo:ASPXToPDF runat="server" ID="ASPXToPDF1"></eo:ASPXToPDF>
<asp:Button runat="server" ID="Button1" Text="Export to PDF" 
        onclick="Button1_Click" />
</asp:Content>


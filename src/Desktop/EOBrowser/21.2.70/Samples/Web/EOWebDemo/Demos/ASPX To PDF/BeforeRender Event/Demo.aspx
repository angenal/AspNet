<%@ Page Title="ASPX To PDF PreRender Event" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ASPX_To_PDF_BeforeRender_Event_Demo" %>
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
    You can handle the control's <b>BeforeRender</b> event to
    setup additional HTML to PDF options. The following
    example sets the page size as A5 (The default page size is A4).
    See <a href="http://doc.essentialobjects.com/library/4/overview.aspx" target="_blank">EO.Pdf Documentation</a>
    for more details about all available options.
    </p>
    <eo:ASPXToPDF runat="server" ID="ASPXToPDF1" 
        onbeforerender="ASPXToPDF1_BeforeRender"></eo:ASPXToPDF>
    <asp:Button runat="server" ID="Button1" Text="Export to PDF" 
            onclick="Button1_Click" />
</asp:Content>


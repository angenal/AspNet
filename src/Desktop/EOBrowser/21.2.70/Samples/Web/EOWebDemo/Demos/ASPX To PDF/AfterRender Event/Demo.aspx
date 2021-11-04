<%@ Page Title="ASPX To PDF AfterRender Event" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ASPX_To_PDF_AfterRender_Event_Demo" %>
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
You can handle the control's <b>AfterRender</b> event to
perform additional "post processing" tasks on the converted
PDF document. For example, you can modify the document to include
additional information, or save it into a file.
</p>
<p>
This sample handles <b>AfterRender</b> event to add a 
"time stamp" message on each page.
</p>
<eo:ASPXToPDF runat="server" ID="ASPXToPDF1" onafterrender="ASPXToPDF1_AfterRender"></eo:ASPXToPDF>
<asp:Button runat="server" ID="Button1" Text="Export to PDF" 
        onclick="Button1_Click" />
</asp:Content>


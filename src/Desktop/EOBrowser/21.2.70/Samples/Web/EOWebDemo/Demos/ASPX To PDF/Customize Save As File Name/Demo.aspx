<%@ Page Title="ASPX To PDF Customize Save As File Name" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ASPX_To_PDF_Customize_Save_As_File_Name_Demo" %>
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
    "Save As" file name is the file name your browser
    suggests when it prompt you to save the file. 
    By default, ASPXToPDF uses the current page name as the
    "Save As" file name. This sample demonstrates how to
    customize this name to include date information.
    </p>
    <p>
    Click the button below to export the current page
    as PDF. Notice the suggested file name is different.
    </p>
<eo:ASPXToPDF runat="server" ID="ASPXToPDF1"></eo:ASPXToPDF>
<asp:Button runat="server" ID="Button1" Text="Export to PDF" 
        onclick="Button1_Click" />
</asp:Content>


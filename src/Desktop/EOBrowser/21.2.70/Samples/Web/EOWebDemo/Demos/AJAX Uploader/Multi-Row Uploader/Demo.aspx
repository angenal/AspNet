<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_AJAX_Uploader_Multi_Row_Uploader_Demo"
    Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        EO.Web AJAXUploader can easily upload multiple files at the same time --- just set
        its <b>Rows</b> property to a number great than 1. The following sample has its
        <b>Rows</b> property set to 3.
    </p>
    <eo:AJAXUploader runat="server" ID="AJAXUploader1" Width="400px" TempFileLocation="~/eo_upload"
        MaxDataSize="30000" Rows="3">
    </eo:AJAXUploader>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_AJAX_Uploader_Auto_Upload_Demo" Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        EO.Web AJAXUploader can automatically starts upload as soon as the user has selected
        a file. To enable this feature, set the uploader's <b>AutoUpload</b> to <b>True</b>.
    </p>
    <p>
        The following sample has <b>AutoUpload</b> set to <b>True</b>.
    </p>
    <eo:AJAXUploader ID="AJAXUploader1" runat="server" AutoUpload="True" MaxDataSize="30000"
        TempFileLocation="~/eo_upload" Width="400px">
    </eo:AJAXUploader>
</asp:Content>

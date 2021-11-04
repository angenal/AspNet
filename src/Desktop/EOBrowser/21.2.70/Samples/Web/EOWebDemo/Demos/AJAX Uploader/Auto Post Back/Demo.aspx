<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_AJAX_Uploader_Auto_Post_Back_Demo" Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        EO.Web AJAXUploader also supports <b>AutoPostBack</b>. When the property is set
        to true, EO.Web AJAXUploader automatically posts the page back to the server when
        it finishes uploading, thus triggering <b>FileUploaded</b> event on the server side.
    </p>
    <p>
        The following sample has <b>AutoPostBack</b> set to <b>True</b>.
    </p>
    <eo:CallbackPanel runat="server" ID="CallbackPanel1" Triggers="{ControlID:AJAXUploader1;Parameter:}">
        <eo:AJAXUploader ID="AJAXUploader1" runat="server" Width="400px" TempFileLocation="~/eo_upload"
            MaxDataSize="30000" OnFileUploaded="AJAXUploader1_FileUploaded" Rows="2" AutoPostBack="True">
        </eo:AJAXUploader>
        <asp:Label ID="lblResult" runat="server"></asp:Label>
    </eo:CallbackPanel>
</asp:Content>

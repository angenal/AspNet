<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_AJAX_Uploader_Server_Side_Event_Demo"
    Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        EO.Web AJAXUploader fires <b>FileUploaded</b> when the page is submitted after one
        or more files have been uploaded. To get information about the uploaded files, use
        the AJAXUploader's <b>PostedFiles</b> property.
    </p>
    <p>
        The following sample demonstrated how to handle <b>FileUploaded</b> event and access
        the posted files. The sample simply displays the temporary file names for all the
        posted files. See "C#" or "VB.NET" for related source code.
    </p>
    <eo:CallbackPanel runat="server" ID="CallbackPanel1" Triggers="{ControlID:AJAXUploader1;Parameter:}">
        <eo:AJAXUploader ID="AJAXUploader1" runat="server" Width="400px" TempFileLocation="~/eo_upload"
            MaxDataSize="30000" AutoPostBack="True" OnFileUploaded="AJAXUploader1_FileUploaded">
        </eo:AJAXUploader>
        <p>
            <asp:Label ID="lblFiles" runat="server"></asp:Label></p>
    </eo:CallbackPanel>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_AJAX_Uploader_Standard_UI_Customizations_Demo"
    Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <style>.uploader_button_style {
    BORDER-RIGHT: #336699 1px solid; BORDER-TOP: #336699 1px solid; BORDER-LEFT: #336699 1px solid; WIDTH: 80px; BORDER-BOTTOM: #336699 1px solid; HEIGHT: 22px; BACKGROUND-COLOR: #e9f2f8
}
.uploader_delete_button_style {
    BORDER-RIGHT: #336699 1px solid; BORDER-TOP: #336699 1px solid; BORDER-LEFT: #336699 1px solid; WIDTH: 160px; BORDER-BOTTOM: #336699 1px solid; HEIGHT: 22px; BACKGROUND-COLOR: #e9f2f8
}
</style>
    <p>
        Various UI elements of EO.Web AJAXUploader can be easily customized. The following
        sample uses <b>BrowseButtonStyle</b>, <b>UploadButtonStyle</b>, <b>CancelButtonStyle</b>
        and <b>DeleteButtonStyle</b> to change the styles for these buttons.
    </p>
    <eo:AJAXUploader runat="server" ID="AJAXUploader1" Width="400px" TempFileLocation="~/eo_upload"
        MaxDataSize="30000">
        <BrowseButtonStyle CssClass="uploader_button_style "></BrowseButtonStyle>
        <DeleteButtonStyle CssClass="uploader_delete_button_style"></DeleteButtonStyle>
        <UploadButtonStyle CssClass="uploader_button_style "></UploadButtonStyle>
        <CancelButtonStyle CssClass="uploader_button_style "></CancelButtonStyle>
    </eo:AJAXUploader>
</asp:Content>

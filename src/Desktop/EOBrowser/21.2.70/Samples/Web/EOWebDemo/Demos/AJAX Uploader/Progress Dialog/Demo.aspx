<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_AJAX_Uploader_Progress_Dialog_Demo" Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        EO.Web AJAXUploader can display a progress dialog while uploading. To use this feature,
        simply drop an <b>AJAXUploaderProgressDialog</b> control into the form and set the
        uploader's <b>ProgressDialog</b> to the ID of the progress dialog. Usually when
        using a progress dialog, you would also want to use the AJAXUploader's <strong>LayoutTemplate</strong>
        to remove the built-in progress bar and progress text because it's not necessary
        to have progress information appears at two places.
    </p>
    <p>
        The contents and layout of the progress dialog is fully customizable through the
        <b>AJAXUploaderProgressDialog</b> control.
    </p>
    <p>
        Note: <b>AJAXUploaderProgressDialog</b> control is a dialog. So it requires a license
        for the <b>Dialog</b> control.
    </p>
    <eo:AJAXUploader runat="server" ID="AJAXUploader1" Width="400px" TempFileLocation="~/eo_upload"
        MaxDataSize="40000" ProgressDialogID="AJAXUploaderProgressDialog1" Rows="3">
        <LayoutTemplate>
            <table cellspacing="0" cellpadding="2" width="400" border="0">
                <tr>
                    <td>
                        <asp:PlaceHolder ID="InputPlaceHolder" runat="server">Input Box Place Holder</asp:PlaceHolder>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="UploadButton" runat="server" Text="Upload"></asp:Button></td>
                </tr>
                <tr>
                    <td>
                        <asp:PlaceHolder ID="PostedFilesPlaceHolder" runat="server">Posted Files Place Holder
                        </asp:PlaceHolder>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="DeleteButton" runat="server" Text="Delete Selected Files"></asp:Button></td>
                </tr>
            </table>
        </LayoutTemplate>
    </eo:AJAXUploader>
    <eo:AJAXUploaderProgressDialog runat="server" ID="AJAXUploaderProgressDialog1" Width="300px"
        HeaderHtml="Uploading..." BorderWidth="1px" BorderStyle="Solid" RestoreButtonUrl="00070103"
        ResizeImageUrl="00020014" BorderColor="#335C88" ControlSkinID="None" AllowResize="True"
        CloseButtonUrl="00070101" ShadowColor="LightGray" MinimizeButtonUrl="00070102"
        ShadowDepth="3" Height="300px" ProgressTextFormat="<p>&#13;&#10;Uploading...{transferred} bytes of {total} bytes ({percentage}%) done. &#13;&#10;</p>&#13;&#10;<p>&#13;&#10;Current file: {current_file_name} ({transferred_file_count} of {total_file_count} done)&#13;&#10;</p>&#13;&#10;<p>&#13;&#10;Time elapsed: {elapsed_seconds} second(s)&#13;&#10;</p>&#13;&#10;<p>&#13;&#10;Time Remaining: {estimated_remaining_seconds} second(s)&#13;&#10;</p&#13;&#10;">
        <FooterStyleActive CssText="background-color: #e5f1fd; padding-bottom: 8px;"></FooterStyleActive>
        <HeaderStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; background-image: url(00070104); padding-bottom: 3px; padding-top: 3px; font-family: tahoma">
        </HeaderStyleActive>
        <FooterTemplate>
            <p style="text-align: center">
                <asp:Button ID="CancelButton" runat="server" Text="Cancel"></asp:Button></p>
        </FooterTemplate>
        <ContentStyleActive CssText="border-top: #335c88 1px solid; background-color: #e5f1fd">
        </ContentStyleActive>
        <ContentTemplate>
            <p>
                &nbsp;</p>
            <div style="margin:5px;">
                <eo:ProgressBar ID="ProgressBar" runat="server" ControlSkinID="Windows_XP" Width="100%">
                </eo:ProgressBar>
            </div>
            <p>
                &nbsp;
            </p>
            <p>
                <asp:PlaceHolder ID="ProgressTextPlaceHolder" runat="server">Progress Text Place Holder
                </asp:PlaceHolder>
            </p>
            <p>
                &nbsp;
            </p>
        </ContentTemplate>
    </eo:AJAXUploaderProgressDialog>
</asp:Content>

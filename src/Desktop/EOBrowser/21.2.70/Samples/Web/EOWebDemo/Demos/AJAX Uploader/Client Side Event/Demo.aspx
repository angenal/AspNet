<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_AJAX_Uploader_Client_Side_Event_Demo"
    Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">

    <script type="text/javascript">
function CustomErrorHandler(uploader, error, message)
{
    window.alert("This is a custom error message for error '" + error + "'.");
}

function CustomProgressHandler(uploader, total, received)
{
    var msg;
    var percentage = uploader.getPercentage();
    if (percentage < 10)
        msg = "Just started...";
    else if (percentage < 50)
        msg = "Hang on...";
    else if (percentage < 70)
        msg = "Half done...";
    else if (percentage < 100)
        msg = "Almost...";
    else
        msg = "Done.";
    
    var progressText = document.getElementById("uploader_progress");
    progressText.innerHTML = msg;
}
    </script>

    <p>
        EO.Web AJAXUploader supports two client side events: <b>ClientSideOnError</b> and
        <b>ClientSideOnProgress</b>.
    </p>
    <p>
        It is recommended to use <b>ClientSideOnError</b> to displays custom or localized
        error message. The following sample uses this property to display a custom "In Progress"
        error message if user clicks outside of the progress dialog while uploading is in
        progress.
    </p>
    <p>
        This sample also uses <b>ClientSideOnProgress</b> to display custom progress information.
    </p>
    <eo:AJAXUploader runat="server" ID="AJAXUploader1" Width="400px" TempFileLocation="~/eo_upload"
        MaxDataSize="30000" ClientSideOnError="CustomErrorHandler" ClientSideOnProgress="CustomProgressHandler"
        ProgressDialogID="AJAXUploaderProgressDialog1">
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
            </table>
        </LayoutTemplate>
    </eo:AJAXUploader>
    <eo:AJAXUploaderProgressDialog runat="server" ID="AJAXUploaderProgressDialog1" Width="168px"
        HeaderHtml="Uploading..." BorderWidth="1px" BorderStyle="Solid" ControlSkinID="None"
        Height="120px" BorderColor="#728EB8" BackColor="White">
        <HeaderStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; background-image: url(00070202); padding-bottom: 2px; padding-top: 2px; font-family: arial">
        </HeaderStyleActive>
        <ContentStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; padding-bottom: 4px; padding-top: 4px; font-family: verdana; background-color: #f8fafd">
        </ContentStyleActive>
        <FooterStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; padding-bottom: 4px; padding-top: 4px; font-family: verdana; background-color: #f8fafd">
        </FooterStyleActive>
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
            <p id="uploader_progress">
            </p>
            <p>
                &nbsp;
            </p>
            <div style="text-align: center">
                <asp:Button ID="CancelButton" runat="server" Text="Cancel"></asp:Button></div>
        </ContentTemplate>
    </eo:AJAXUploaderProgressDialog>
</asp:Content>

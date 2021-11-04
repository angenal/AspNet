<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_AJAX_Uploader_Advanced_UI_Customizations_Demo"
    Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        EO.Web AJAXUploader also supports <b>LayoutTemplate</b>, which gives you complete
        freedom to customize the layout of the uploader. The following sample demonstrates
        how to use <b>LayoutTemplate</b> to:
        <ul>
            <li>Move the "posted files" section on top of the upload section;</li>
            <li>Use a custom progress bar;</li>
            <li>Place the progress bar on the right side of the file input element, instead of below
                it;</li>
            <li>Move the "Upload" button next to the "Browse" button;</li>
            <li>Leave out "Cancel" button and progress text;</li>
        </ul>
        <p>
        </p>
        <eo:AJAXUploader runat="server" ID="AJAXUploader1" Width="520px" TempFileLocation="~/eo_upload"
            MaxDataSize="30000">
            <LayoutTemplate>
                <table cellspacing="0" cellpadding="2" width="520" border="0">
                    <tr>
                        <td colspan="3">
                            <asp:PlaceHolder ID="PostedFilesPlaceHolder" runat="server">Posted Files Place Holder
                            </asp:PlaceHolder>
                            <asp:Button ID="DeleteButton" runat="server" Text="Delete Selected Files"></asp:Button>
                            <p>
                                &nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td width="99%">
                            <asp:PlaceHolder ID="InputPlaceHolder" runat="server">Input Box Place Holder</asp:PlaceHolder>
                        </td>
                        <td>
                            <asp:Button ID="UploadButton" runat="server" Text="Upload"></asp:Button>
                        </td>
                        <td>
                            <eo:ProgressBar ID="ProgressBar" runat="server" ControlSkinID="None" Height="18px"
                                Width="150px" BorderColor="#336699" BorderStyle="Solid" BorderWidth="1px" IndicatorColor="151, 198, 232">
                            </eo:ProgressBar>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </eo:AJAXUploader>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_AJAX_Uploader_File_List_Demo" Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">

    <script type="text/javascript">
function uploader_changed()
{
    var uploader = eo_GetObject("AJAXUploader1");
    var enableSubmitButton = uploader.getPostedFiles().length > 0;
    var submitButton = document.getElementById("<%=Button1.ClientID%>");
    submitButton.disabled = !enableSubmitButton;
}
    </script>

    <p>
        The AJAXUploader allows user to upload multiple files and automatically maintain
        the temporary file list. It also provides a separate <b>AJAXPostedFileList</b> control
        to maintain the final file list.
    </p>
    <p>
        Please upload one or more files and then click Submit button to submit the temporary
        file list. For more details, see Remarks section.
    </p>
    <eo:CallbackPanel runat="server" ID="CallbackPanel1" Triggers="{ControlID:Button1;Parameter:},{ControlID:DataGrid1;Parameter:}">
        <p>
            <eo:AJAXUploader ID="AJAXUploader1" runat="server" Width="350px" TempFileLocation="~/eo_upload"
                FinalFileList="AJAXPostedFileList1" FinalFileLocation="~/eo_upload" ClientSideOnChange="uploader_changed"
                OnFileUploaded="AJAXUploader1_FileUploaded">
            </eo:AJAXUploader>
        </p>
        <p>
            <asp:Button ID="Button1" Enabled="False" runat="server" Text="Submit"></asp:Button></p>
        <eo:AJAXPostedFileList ID="AJAXPostedFileList1" runat="server">
        </eo:AJAXPostedFileList>
        <p>
            <asp:DataGrid ID="DataGrid1" Width="350px" runat="server" BorderColor="gainsboro"
                BorderWidth="1" CellPadding="2" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound"
                OnDeleteCommand="DataGrid1_DeleteCommand">
                <HeaderStyle CssClass="grid_header"></HeaderStyle>
                <Columns>
                    <asp:TemplateColumn HeaderText="File Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblFileName"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Size">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblFileSize"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:ButtonColumn Text="Delete" HeaderText="Delete" CommandName="Delete"></asp:ButtonColumn>
                </Columns>
            </asp:DataGrid></p>
    </eo:CallbackPanel>
</asp:Content>

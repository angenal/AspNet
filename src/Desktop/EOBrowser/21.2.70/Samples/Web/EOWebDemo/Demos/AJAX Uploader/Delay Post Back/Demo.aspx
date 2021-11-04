<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_AJAX_Uploader_Delay_Post_Back_Demo" Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        By default, EO.Web AJAXUploader does not automatically postback to the server when
        it finishes uploading. This allows you to work on other part of the page while the
        uploading is in process and submit the page only when you are ready.
    </p>
    <p>
        The following sample simulates a Web Mail interface. You can start file uploading
        first, then write the email text when the AJAXUploader is transferring files. Once
        you are done with the email text, you can click "Send" to submit the page if the
        AJAXUploader has also finished uploading.
    </p>
    <eo:CallbackPanel runat="server" ID="CallbackPanel1" Triggers="{ControlID:btnSend;Parameter:}">
        <asp:Panel ID="panInput" runat="server">
            <table style="width: 520px">
                <tr>
                    <td>
                        Step 1: Start Uploading Attachment</td>
                    <td>
                        Step 2: Writing Email Text</td>
                </tr>
                <tr>
                    <td valign="top">
                        <eo:AJAXUploader ID="AJAXUploader1" runat="server" Width="250px" TempFileLocation="~/eo_upload"
                            MaxDataSize="30000" Height="168px" Rows="2">
                        </eo:AJAXUploader>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtEmail" runat="server" Width="260px" Height="160px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
            </table>
            <p>
            </p>
            <table style="width: 520px">
                <tr>
                    <td colspan="3">
                        Step 3: Send The Email (No email is actually being sent in this demo).</td>
                </tr>
                <tr>
                    <td>
                        To:</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="400"></asp:TextBox></td>
                    <td align="right">
                        <asp:Button ID="btnSend" runat="server" Width="80" OnClick="btnSend_Click" Text="Send"></asp:Button></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Label ID="lblResult" runat="server"></asp:Label>
    </eo:CallbackPanel>
</asp:Content>

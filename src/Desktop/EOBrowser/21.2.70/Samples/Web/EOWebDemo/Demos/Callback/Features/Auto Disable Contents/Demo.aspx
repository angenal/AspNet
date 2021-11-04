<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Callback_Features_Auto_Disable_Contents_Demo"
    Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        EO.Web CallbackPanel can automatically disable its contents during callback. Enter
        something and click "Submit" to see it in action.
    </p>
    <eo:CallbackPanel ID="CallbackPanel1" runat="server" LoadingHTML="Processing data, this may take a while..."
        Height="160px" Triggers="{ControlID:btnSubmit;Parameter:},{ControlID:btnReset;Parameter:}"
        LoadingPanelID="Panel1" AutoDisableContents="True">
        <asp:Panel ID="panResult" runat="server" Visible="False">
            <p>
                <asp:Label ID="lblResult" runat="server"></asp:Label></p>
            <asp:Button ID="btnReset" Text="Try Again" runat="server" OnClick="btnReset_Click"></asp:Button>
        </asp:Panel>
        <asp:Panel ID="panForm" runat="server">
            <table style="border-collapse: collapse" bordercolor="gainsboro" cellpadding="2"
                width="400" border="1">
                <tr>
                    <td colspan="2">
                        An Important Form - Can Not Be Submitted Twice</td>
                </tr>
                <tr>
                    <td>
                        Important Text:</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" MaxLength="100" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        Important Choice:</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="Choice 1">Important Choice 1</asp:ListItem>
                            <asp:ListItem Value="Choice 2">Important Choice 2</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-top: 10px" colspan="2">
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click"></asp:Button></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
    </eo:CallbackPanel>
</asp:Content>

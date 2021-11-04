<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Callback_Features_Callback_Group_Demo"
    Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        You can associate multiple Callback/CallbackPanel controls with each other as a
        group. All Callback/CallbackPanel will update their contents when any one in the
        group has triggered a callback.
    </p>
    <p>
        The following sample uses two CallbackPanel controls, one for the system tick count
        and one for the system time. The "Update" button is set as a trigger for the system
        tick count CallbackPanel. However, since both CallbackPanel's have their <span class="highlight">
            GroupName</span> set to the same value, when one CallbackPanel triggers a callback,
        the other CallbackPanel will also update.
    </p>
    <p>
        &nbsp;</p>
    <table style="border-collapse: collapse" bordercolor="gainsboro" cellpadding="2"
        width="400" border="1">
        <tr>
            <td style="width: 180px">
                System Tick Count:</td>
            <td>
                <eo:CallbackPanel runat="server" ID="cpTickCount" GroupName="demo" Triggers="{ControlID:btnUpdate;Parameter:}">
                    <asp:Label ID="lblTickCount" runat="server"></asp:Label>
                </eo:CallbackPanel>
            </td>
        </tr>
        <tr>
            <td>
                System Time:</td>
            <td>
                <eo:CallbackPanel runat="server" ID="cpTime" GroupName="demo">
                    <asp:Label ID="lblTime" runat="server"></asp:Label>
                </eo:CallbackPanel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button runat="server" ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>

<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ToolTip_Animation_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
    Use the ToolTip's <b>Animation</b> and <b>AnimationDuration</b> property
    to customize the ToolTip animation.
    </p>
    <table>
        <tr>
            <td>Animation Type:</td>
            <td>
                <asp:DropDownList runat="server" ID="cbAnimationType">
                    <asp:ListItem Text="None"></asp:ListItem>
                    <asp:ListItem Text="Fade"></asp:ListItem>
                    <asp:ListItem Text="GlideTopToBottom"></asp:ListItem>
                    <asp:ListItem Text="GlideBottomToTop"></asp:ListItem>
                    <asp:ListItem Text="GlideLeftToRight"></asp:ListItem>
                    <asp:ListItem Text="GlideRightToLeft"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Animation Duration (ms):</td>
            <td>
                <asp:TextBox runat="server" ID="txtDuration" Text="300"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Result</td>
            <td>
                <p id="panTrigger">Move mouse over this text to test the tooltip.</p>
                <eo:ToolTip runat="server" ID="ToolTip1" For="panTrigger">
                </eo:ToolTip>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button runat="server" ID="btnUpdate" Text="Update" />
            </td>
        </tr>
    </table>
</asp:Content>


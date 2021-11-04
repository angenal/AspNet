<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Flyout_Dynamic_Flyout_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
    This sample demonstrates how to dynamically create Flyout
    control. It also demonstrates how to maintain state information
    for dynamically loaded controls in general.
    </p>
    <input type="hidden" runat="server" ID="txtMsgList" />
    <asp:Button runat="server" ID="Button1" Text="Add New Flyout" 
        onclick="Button1_Click" />
    <asp:Panel runat="server" ID="Panel1">
    </asp:Panel>
</asp:Content>


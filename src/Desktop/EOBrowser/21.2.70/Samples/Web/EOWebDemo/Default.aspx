<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="EO.Web Demos" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <asp:Label ID="lblNoDemo" runat="server">Please select a demo from the left pane.</asp:Label>
    <asp:Label ID="lblSelectFromCategory" runat="server" Visible="False"></asp:Label>
</asp:Content>


<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ToolTip_Basic_Feature_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        Move the mouse over the button below to see the tooltip.
    </p>
    <asp:Button runat="server" ID="Button1" Text="Test" />
    <eo:ToolTip runat="server" ID="ToolTip1" For="Button1" 
        HeaderHtml="Hello!" BodyHtml="Clicking this button does nothing.">
    </eo:ToolTip>
</asp:Content>


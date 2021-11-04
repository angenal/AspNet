<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ToolTip_ToolTip_Location_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        By default, the ToolTip's location is automatically determined based
        on the current mouse position. You can set the ToolTip's <b>ExpandDirection</b>,
        <b>OffsetX</b> and <b>OffsetY</b> to explicitly specify the ToolTip's
        location relative to the triggering control. The following ToolTip's
        <b>ExpandDirection</b> is set to <b>Bottom</b>. Position mouse over the
        button below to see the ToolTip.
    </p>
    <asp:Button runat="server" ID="Button1" Text="Test Button" />
    <eo:ToolTip runat="server" ID="ToolTip1" For="Button1" 
     ExpandDirection="Bottom" BodyHtml="This tooltip should appear directly below the button."></eo:ToolTip>
</asp:Content>


<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Splitter_Features_Show_and_Hide_Pane_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    A splitter pane can be completely hidden by setting its <strong>State</strong> property 
    to <strong>Hidden</strong> on the server side, or calling <strong>setState</strong>
    client side JavaScript function with the correct state parameter on the client 
    side.
</p>
<p>
    The following sample demonstrates this feature. Note only the collapsible pane 
    can be hidden. Please see <strong>SplitterPane.State</strong> property for more 
    details.
</p>
<p>
    <a href="javascript:eo_GetObject('Splitter1').getLeftPane().setState(2);">Hide Left Pane</a>
</p>
<p>
    <a href="javascript:eo_GetObject('Splitter1').getLeftPane().setState(0);">Show Left Pane</a>
</p>
<eo:Splitter runat="server" Width="300px" Height="200px" id="Splitter1" BorderStyle="Solid" DividerSize="8"
    BorderWidth="1px" BorderColor="#A0A0A0" ControlSkinID="None" DividerImage="00080101" CollapseButtonImage="00080102"
    ExpandButtonHoverImage="00080105" ExpandButtonImage="00080104" CollapseButtonHoverImage="00080103">
    <eo:SplitterPane id="SplitterPane1" Width="100px" runat="server">
        <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">Left 
            Pane Contents</DIV>
    </eo:SplitterPane>
    <eo:SplitterPane id="SplitterPane2" runat="server">
        <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">Right 
            Pane Contents</DIV>
    </eo:SplitterPane>
</eo:Splitter>
</asp:Content>


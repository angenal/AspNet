<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Splitter_Features_Collapse_to_the_Right_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web Splitter can collapse both to the left or to the right. To collapse to 
    the right, follow all instructs for <a href="javascript:GoToDemo('collapse_splitter');">
        collapsing to the left</a>, then set the right pane's <strong>InitialSize</strong>
    property.
</p>
<eo:Splitter runat="server" Width="300px" Height="200px" id="Splitter1" BorderStyle="Solid" DividerSize="8"
    BorderWidth="1px" BorderColor="#A0A0A0" ControlSkinID="None" DividerImage="00080101" CollapseButtonImage="00080104"
    ExpandButtonHoverImage="00080103" ExpandButtonImage="00080102" CollapseButtonHoverImage="00080105">
    <eo:SplitterPane id="SplitterPane1" Width="100px" runat="server">
        <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">Left 
            Pane Contents</DIV>
    </eo:SplitterPane>
    <eo:SplitterPane id="SplitterPane2" runat="server" InitialSize="120">
        <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">Right 
            Pane Contents</DIV>
    </eo:SplitterPane>
</eo:Splitter>
</asp:Content>


<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Splitter_Features_Expand_and_Collapse_Buttons_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web Splitter can display Expand/Collapse button on the splitter divider. Use <b>ExpandButtonImage</b>,
    <b>ExpandButtonHoverImage</b>, <b>CollapseButtonImage</b> and <b>CollapseButtonHoverImage</b>
    to set the button images.
</p>
<p>
    The following sample demonstrates this feature. Click the collapse button to 
    completely collapse the left pane, the click the same region again to expand 
    it.
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


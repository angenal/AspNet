<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Tool_Bar_Designs_Style_3_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    This sample uses <b>BorderStyle</b>, <b>BorderWidth</b> and <b>BorderColor</b> to 
    create the toolbar background. It uses <b>NormalStyle</b>, <b>HoverStyle</b> and
    <b>DownStyle</b> to create the hovering and down effect. <b>Margin</b> is used 
    on these styles to create the space between the toolbar border and the toolbar 
    items.
</p>
<p>
&nbsp;
</p>
<eo:ToolBar runat="server" id="ToolBar1" BorderStyle="Solid" TextAlign="Underneath" BorderWidth="1px"
    Width="400px" BorderColor="LightGray">
    <DownStyle CssText="background-color:#e0e0e0;border-bottom-color:gray;border-bottom-style:solid;border-bottom-width:1px;border-left-color:gray;border-left-style:solid;border-left-width:1px;border-right-color:gray;border-right-style:solid;border-right-width:1px;border-top-color:gray;border-top-style:solid;border-top-width:1px;cursor:hand;font-family:Tahoma;font-size:12px;margin-bottom:3px;margin-left:4px;margin-right:4px;margin-top:3px;padding-bottom:3px;padding-left:6px;padding-right:6px;padding-top:3px;"></DownStyle>
    <HoverStyle CssText="BORDER-RIGHT: gray 1px solid; PADDING-RIGHT: 6px; BORDER-TOP: gray 1px solid; PADDING-LEFT: 6px; FONT-SIZE: 12px; PADDING-BOTTOM: 3px; MARGIN: 3px 4px; BORDER-LEFT: gray 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: gray 1px solid; FONT-FAMILY: Tahoma"></HoverStyle>
    <NormalStyle CssText="PADDING-RIGHT: 7px; PADDING-LEFT: 7px; FONT-SIZE: 12px; PADDING-BOTTOM: 4px; MARGIN: 3px 4px; CURSOR: hand; PADDING-TOP: 4px; FONT-FAMILY: Tahoma"></NormalStyle>
    <Items>
        <eo:ToolBarItem Text="New" ToolTip="New" ImageUrl="00101001" CommandName="New"></eo:ToolBarItem>
        <eo:ToolBarItem Text="Open" ToolTip="Open" ImageUrl="00101002" CommandName="Open"></eo:ToolBarItem>
        <eo:ToolBarItem Text="Save" ToolTip="Save" ImageUrl="00101003" CommandName="Save"></eo:ToolBarItem>
        <eo:ToolBarItem Text="Save All" ToolTip="Save All" ImageUrl="00101004" CommandName="SaveAll"></eo:ToolBarItem>
    </Items>
</eo:ToolBar>
</asp:Content>


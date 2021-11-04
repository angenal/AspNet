<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Tool_Bar_Designs_Style_2_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    This sample uses the same set of properties as other samples, but also uses 
    background images on <b>HoverStyle</b> and <b>DownStyle</b> to 
create the desired hover 
    and down effect.
</p>
<p>
&nbsp;
</p>
<eo:ToolBar runat="server" id="ToolBar1" BackgroundImageRight="00100402" Width="400px" BackgroundImage="00100403"
    SeparatorImage="00100404" BackgroundImageLeft="00100401">
    <DownStyle CssText="background-image:url('00100406');cursor:hand;font-family:Tahoma;font-size:12px;padding-bottom:4px;padding-left:7px;padding-right:7px;padding-top:4px;"></DownStyle>
    <HoverStyle CssText="background-image:url('00100405');cursor:hand;font-family:Tahoma;font-size:12px;padding-bottom:4px;padding-left:7px;padding-right:7px;padding-top:4px;"></HoverStyle>
    <NormalStyle CssText="PADDING-RIGHT: 7px; PADDING-LEFT: 7px; FONT-SIZE: 12px; PADDING-BOTTOM: 4px; CURSOR: hand; PADDING-TOP: 4px; FONT-FAMILY: Tahoma"></NormalStyle>
    <Items>
        <eo:ToolBarItem ToolTip="New" ImageUrl="00101001" CommandName="New"></eo:ToolBarItem>
        <eo:ToolBarItem ToolTip="Open" ImageUrl="00101002" CommandName="Open"></eo:ToolBarItem>
        <eo:ToolBarItem ToolTip="Save" ImageUrl="00101003" CommandName="Save"></eo:ToolBarItem>
        <eo:ToolBarItem ToolTip="Save All" ImageUrl="00101004" CommandName="SaveAll"></eo:ToolBarItem>
        <eo:ToolBarItem Type="Separator"></eo:ToolBarItem>
        <eo:ToolBarItem ToolTip="Print" ImageUrl="00101005" CommandName="Print"></eo:ToolBarItem>
        <eo:ToolBarItem ToolTip="Print Preview" ImageUrl="00101006" CommandName="PrintPreview"></eo:ToolBarItem>
        <eo:ToolBarItem Type="Separator"></eo:ToolBarItem>
        <eo:ToolBarItem ToolTip="Copy" ImageUrl="00101007" CommandName="Copy"></eo:ToolBarItem>
        <eo:ToolBarItem ToolTip="Cut" ImageUrl="00101008" CommandName="Cut"></eo:ToolBarItem>
        <eo:ToolBarItem ToolTip="Paste" ImageUrl="00101009" CommandName="Paste"></eo:ToolBarItem>
    </Items>
</eo:ToolBar>
</asp:Content>


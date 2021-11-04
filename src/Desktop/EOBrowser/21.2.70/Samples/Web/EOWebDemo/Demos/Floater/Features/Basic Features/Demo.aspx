<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Floater_Features_Basic_Features_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
EO.Web Floater "pins" a portion of the page at a fixed position
regardless of the page scroll offset. Try to scroll the browser
window and see the toolbar's position stay fixed.
</p>
<p>
<b>Note</b>: You may need to reduce the size of your browser window in order to
test scrolling.
</p>
<div id="anchor">
</div>
<eo:Floater runat="server" id="Floater1" LeftAnchorID="anchor" TopAnchorID="anchor">
    <eo:ToolBar id="ToolBar1" runat="server" BackgroundImageRight="00100402" Width="200px" BackgroundImage="00100403"
        BackgroundImageLeft="00100401" SeparatorImage="00100404">
        <DownStyle CssText="background-image:url('00100406');cursor:hand;font-family:Tahoma;font-size:12px;padding-bottom:4px;padding-left:7px;padding-right:7px;padding-top:4px;"></DownStyle>
        <HoverStyle CssText="background-image:url('00100405');cursor:hand;font-family:Tahoma;font-size:12px;padding-bottom:4px;padding-left:7px;padding-right:7px;padding-top:4px;"></HoverStyle>
        <NormalStyle CssText="PADDING-RIGHT: 7px; PADDING-LEFT: 7px; FONT-SIZE: 12px; PADDING-BOTTOM: 4px; CURSOR: hand; PADDING-TOP: 4px; FONT-FAMILY: Tahoma"></NormalStyle>
        <ItemTemplates>
            <eo:ToolBarItem Type="Custom">
                <HoverStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;background-image:url('Blank');"></HoverStyle>
                <DownStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;background-image:url('Blank');"></DownStyle>
                <NormalStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;background-image:url('Blank');"></NormalStyle>
            </eo:ToolBarItem>
            <eo:ToolBarItem Type="DropDownMenu">
                <HoverStyle CssText="background-image:url('00100407');cursor:hand;font-family:Tahoma;font-size:12px;padding-bottom:4px;padding-left:7px;padding-right:7px;padding-top:4px;"></HoverStyle>
                <DownStyle CssText="background-image:url('00100408');cursor:hand;font-family:Tahoma;font-size:12px;padding-bottom:4px;padding-left:7px;padding-right:7px;padding-top:4px;"></DownStyle>
                <NormalStyle CssText="background-image:url('00100409');PADDING-RIGHT: 7px; PADDING-LEFT: 7px; FONT-SIZE: 12px; PADDING-BOTTOM: 4px; CURSOR: hand; PADDING-TOP: 4px; FONT-FAMILY: Tahoma"></NormalStyle>
            </eo:ToolBarItem>
        </ItemTemplates>
        <Items>
            <eo:ToolBarItem ToolTip="New" ImageUrl="00101001" CommandName="New"></eo:ToolBarItem>
            <eo:ToolBarItem ToolTip="Open" ImageUrl="00101002" CommandName="Open"></eo:ToolBarItem>
            <eo:ToolBarItem ToolTip="Save" ImageUrl="00101003" CommandName="Save"></eo:ToolBarItem>
            <eo:ToolBarItem ToolTip="Save All" ImageUrl="00101004" CommandName="SaveAll"></eo:ToolBarItem>
            <eo:ToolBarItem Type="Separator"></eo:ToolBarItem>
            <eo:ToolBarItem ToolTip="Print" ImageUrl="00101005" CommandName="Print"></eo:ToolBarItem>
            <eo:ToolBarItem ToolTip="Print Preview" ImageUrl="00101006" CommandName="PrintPreview"></eo:ToolBarItem>
        </Items>
    </eo:ToolBar>
</eo:Floater>
</asp:Content>


<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Tool_Bar_Features_Auto_Check_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web ToolBar can automatically check an item when it is clicked. To use this 
    feature, set the item's <b>AutoCheck</b> to true. You can also set multiple 
    items' <b>GroupName</b> to the same value to group multiple item into a group. 
    When multiple items are grouped together, checking one item will uncheck all 
    other items.
</p>
<p>
    The following toolbar has two groups: "Align" and "Zoom", with each group only
    having one item in pushed state.
</p>
<p>
<eo:ToolBar runat="server" id="ToolBar1" BackgroundImageRight="00100102" Width="400px" BackgroundImage="00100103"
    BackgroundImageLeft="00100101" SeparatorImage="00100104">
    <DownStyle CssText="border-right: #335ea8 1px solid; padding-right: 2px; border-top: #335ea8 1px solid; padding-left: 4px; padding-bottom: 1px; border-left: #335ea8 1px solid; padding-top: 3px; border-bottom: #335ea8 1px solid; background-color: #99afd4; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></DownStyle>
    <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 3px; border-top: #335ea8 1px solid; padding-left: 3px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; background-color: #c2cfe5; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></HoverStyle>
    <NormalStyle CssText="padding-right: 4px; padding-left: 4px; padding-bottom: 3px; border-top-style: none; padding-top: 3px; border-right-style: none; border-left-style: none; border-bottom-style: none; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></NormalStyle>
    <ItemTemplates>
        <eo:ToolBarItem Type="Custom">
            <HoverStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></HoverStyle>
            <DownStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></DownStyle>
            <NormalStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></NormalStyle>
        </eo:ToolBarItem>
        <eo:ToolBarItem Type="DropDownMenu">
            <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 3px; border-top: #335ea8 1px solid; padding-left: 3px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; background-color: #c2cfe5; cursor:hand; background-image: url(00100106); background-position-x: right;"></HoverStyle>
            <DownStyle CssText="border-right: #335ea8 1px solid; padding-right: 2px; border-top: #335ea8 1px solid; padding-left: 4px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 3px; border-bottom: none; background-color:transparent; cursor:hand; background-image: url(00100105); background-position-x: right;"></DownStyle>
            <NormalStyle CssText="padding-right: 4px; padding-left: 4px; padding-bottom: 3px; border-top-style: none; padding-top: 3px; border-right-style: none; border-left-style: none; border-bottom-style: none; cursor:hand; background-image: url(00100105); background-position-x: right;"></NormalStyle>
        </eo:ToolBarItem>
    </ItemTemplates>
    <Items>
        <eo:ToolBarItem Pushed="True" GroupName="align" Text="Align Left" AutoCheck="True" ImageUrl="00101014"></eo:ToolBarItem>
        <eo:ToolBarItem GroupName="align" Text="Align Center" AutoCheck="True" ImageUrl="00101015"></eo:ToolBarItem>
        <eo:ToolBarItem GroupName="align" Text="Align Right" AutoCheck="True" ImageUrl="00101016"></eo:ToolBarItem>
        <eo:ToolBarItem Type="Separator"></eo:ToolBarItem>
        <eo:ToolBarItem Pushed="True" GroupName="zoom" Text="Zoom In" AutoCheck="True" ImageUrl="00101067"></eo:ToolBarItem>
        <eo:ToolBarItem GroupName="zoom" Text="Zoom Out" AutoCheck="True" ImageUrl="00101068"></eo:ToolBarItem>
    </Items>
</eo:ToolBar>
</p>
<p>
    <asp:Button Runat="server" ID="Button1" Text="Post Back!" OnClick="Button1_Click"></asp:Button>
</p>
<p>
    <asp:Label Runat="server" ID="Label1"></asp:Label>
</p>
</asp:Content>


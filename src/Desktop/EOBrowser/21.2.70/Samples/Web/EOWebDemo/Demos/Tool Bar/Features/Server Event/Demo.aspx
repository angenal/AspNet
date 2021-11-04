<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Tool_Bar_Features_Server_Event_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web ToolBar does not raise server event by default. To raise server event, 
    set <b>AutoPostBack</b> to <b>True</b>.
</p>
<p>
&nbsp;
</p>
<eo:CallbackPanel runat="server" id="CallbackPanel1" Triggers="{ControlID:ToolBar1;Parameter:}">
    <eo:ToolBar id="ToolBar1" runat="server" BackgroundImageRight="00100102" Width="400px" BackgroundImage="00100103"
        SeparatorImage="00100104" BackgroundImageLeft="00100101" AutoPostBack="True" OnItemClick="ToolBar1_ItemClick">
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
    <P>
        <asp:Label id="Label1" Runat="server"></asp:Label></P>
</eo:CallbackPanel>
</asp:Content>


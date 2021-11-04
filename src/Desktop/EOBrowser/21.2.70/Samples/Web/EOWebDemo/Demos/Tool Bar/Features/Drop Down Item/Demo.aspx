<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Tool_Bar_Features_Drop_Down_Item_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web ToolBar supports drop down toolbar item. To use this feature:
</p>
<ol>
    <li>
        Set the toolbar item's Type property to <b>DropDownMenu</b>;
    <li>
        Point toolbar item's DropDownMenuID to the sub menu you would like to display 
        when the toolbar's drop down button is clicked. Please refer to the help file 
        for more details about this property;</li>
</ol>
<p>
    Note: The sub menu is provided by an EO.Web Menu or ContextMenu control, it is 
    not part of the ToolBar control.
</p>
<p>
&nbsp;
</p>
<eo:ToolBar runat="server" id="ToolBar1" BackgroundImageRight="00100202" Width="400px" BackgroundImage="00100203"
    SeparatorImage="00100204" BackgroundImageLeft="00100201">
    <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac"></DownStyle>
    <HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac"></HoverStyle>
    <NormalStyle CssText="PADDING-RIGHT: 4px; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 3px; CURSOR: hand; BORDER-TOP-STYLE: none; PADDING-TOP: 3px; FONT-FAMILY: Tahoma; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"></NormalStyle>
    <ItemTemplates>
        <eo:ToolBarItem Type="Custom">
            <HoverStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></HoverStyle>
            <DownStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></DownStyle>
            <NormalStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></NormalStyle>
        </eo:ToolBarItem>
        <eo:ToolBarItem Type="DropDownMenu">
            <HoverStyle CssText="background-color:#ffe1ac;background-image:url('00100206');background-position-x:right;border-bottom-color:#335ea8;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#335ea8;border-left-style:solid;border-left-width:1px;border-right-color:#335ea8;border-right-style:solid;border-right-width:1px;border-top-color:#335ea8;border-top-style:solid;border-top-width:1px;cursor:hand;padding-bottom:2px;padding-left:3px;padding-right:3px;padding-top:2px;"></HoverStyle>
            <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; BACKGROUND-POSITION-X: right; BACKGROUND-IMAGE: url(00100206); PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; BACKGROUND-COLOR: #ffe1ac"></DownStyle>
            <NormalStyle CssText="background-image:url('00100205');background-position-x:right;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;cursor:hand;padding-bottom:3px;padding-left:4px;padding-right:4px;padding-top:3px;"></NormalStyle>
        </eo:ToolBarItem>
    </ItemTemplates>
    <Items>
        <eo:ToolBarItem Text="New" ToolTip="New" ImageUrl="00101001" CommandName="New" Type="DropDownMenu"
            DropDownMenuID="Menu1:new"></eo:ToolBarItem>
        <eo:ToolBarItem Text="Open" ToolTip="Open" ImageUrl="00101002" CommandName="Open"></eo:ToolBarItem>
        <eo:ToolBarItem Text="Save" ToolTip="Save" ImageUrl="00101003" CommandName="Save"></eo:ToolBarItem>
        <eo:ToolBarItem Text="Save All" ToolTip="Save All" ImageUrl="00101004" CommandName="SaveAll"></eo:ToolBarItem>
    </Items>
</eo:ToolBar>
<eo:ContextMenu id="Menu1" runat="server" Width="200px" ControlSkinID="None" CheckIconUrl="OfficeCheckIcon2">
    <TopGroup Style-CssText="background-color:#abc7f6;">
        <Items>
            <eo:MenuItem ItemID="new" Text-Html="New">
                <SubMenu>
                    <Items>
                        <eo:MenuItem LeftIcon-Url="00101001" Text-Html="Document"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00030405" Text-Html="Folder"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00030402" Text-Html="Contact"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:1px;color:gray"
            Height="24" HoverStyle-CssText="background-color:#C0D6F4;border-bottom-color:#000080;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#000080;border-left-style:solid;border-left-width:1px;border-right-color:#000080;border-right-style:solid;border-right-width:1px;border-top-color:#000080;border-top-style:solid;border-top-width:1px;padding-left:4px;padding-right:4px;padding-top:0px;padding-bottom:0px;"
            ItemID="_TopLevelItem" NormalStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:1px;"
            SelectedStyle-CssText="background-color:white;border-bottom-color:#000080;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#000080;border-left-style:solid;border-left-width:1px;border-right-color:#000080;border-right-style:solid;border-right-width:1px;border-top-color:#000080;border-top-style:solid;border-top-width:1px;padding-left:4px;padding-right:4px;padding-top:0px;padding-bottom:0px;">
            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="background-color:#F6F6F6;border-bottom-color:#002D96;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#002D96;border-left-style:solid;border-left-width:1px;border-right-color:#002D96;border-right-style:solid;border-right-width:1px;border-top-color:#002D96;border-top-style:solid;border-top-width:1px;color:black;cursor:hand;font-family:Tahoma;font-size:8pt;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
                CollapseEffect-Type="GlideTopToBottom" SideImage="Office2003SideBar2" LeftIconCellWidth="25"
                ItemSpacing="3"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="background-color:#6a8ccb;height:1px;margin-left:30px;width:1px;"></eo:MenuItem>
        <eo:MenuItem DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:5px;padding-top:1px;color:gray"
            Height="24" HoverStyle-CssText="background-color:#FFEEC2;border-bottom-color:#000080;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#000080;border-left-style:solid;border-left-width:1px;border-right-color:#000080;border-right-style:solid;border-right-width:1px;border-top-color:#000080;border-top-style:solid;border-top-width:1px;padding-left:1px;padding-right:4px;padding-top:0px;"
            ItemID="_Default" NormalStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:5px;padding-top:1px;"
            SelectedStyle-CssText="background-color:white;border-bottom-color:#000080;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#000080;border-left-style:solid;border-left-width:1px;border-right-color:#000080;border-right-style:solid;border-right-width:1px;border-top-color:#000080;border-top-style:solid;border-top-width:1px;padding-left:1px;padding-right:4px;padding-top:0px;"
            Text-Padding-Right="30">
            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="background-color:#F6F6F6;border-bottom-color:#002D96;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#002D96;border-left-style:solid;border-left-width:1px;border-right-color:#002D96;border-right-style:solid;border-right-width:1px;border-top-color:#002D96;border-top-style:solid;border-top-width:1px;color:black;cursor:hand;font-family:Tahoma;font-size:8pt;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
                CollapseEffect-Type="GlideTopToBottom" SideImage="Office2003SideBar2" LeftIconCellWidth="25"
                ItemSpacing="3"></SubMenu>
        </eo:MenuItem>
    </LookItems>
</eo:ContextMenu>
</asp:Content>


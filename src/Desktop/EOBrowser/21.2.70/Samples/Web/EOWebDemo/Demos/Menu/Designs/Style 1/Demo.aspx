<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Designs_Style_1_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:Menu runat="server" id="Menu1" ControlSkinID="None" SubMenuIconUrl="Blank" Width="120px">
    <TopGroup Orientation="Vertical">
        <Items>
            <eo:MenuItem Text-Html="My Account"></eo:MenuItem>
            <eo:MenuItem Text-Html="Our Products">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="Product 1"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Product 2"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Product 3"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem Text-Html="Contact Us"></eo:MenuItem>
            <eo:MenuItem Text-Html="Frequently Asked&lt;br /&gt;Questions"></eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem HoverStyle-CssText="BORDER-RIGHT: #9c9a9c 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #9c9a9c 1px solid; PADDING-LEFT: 5px; PADDING-BOTTOM: 2px; BORDER-LEFT: #9c9a9c 1px solid; COLOR: #9c6500; PADDING-TOP: 2px; BORDER-BOTTOM: #9c9a9c 1px solid; BACKGROUND-COLOR: #efefef"
            ItemID="_Default" NormalStyle-CssText="BORDER-RIGHT: #9c9a9c 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #9c9a9c 1px solid; PADDING-LEFT: 5px; PADDING-BOTTOM: 2px; BORDER-LEFT: #9c9a9c 1px solid; COLOR: #003000; PADDING-TOP: 2px; BORDER-BOTTOM: #9c9a9c 1px solid; BACKGROUND-COLOR: #efefef"
            SelectedStyle-CssText="BORDER-RIGHT: #003000 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #003000 1px solid; PADDING-LEFT: 5px; PADDING-BOTTOM: 2px; BORDER-LEFT: #003000 1px solid; COLOR: white; PADDING-TOP: 2px; BORDER-BOTTOM: #003000 1px solid; BACKGROUND-COLOR: #316531"
            LeftIcon-Url="Blank" LeftIcon-SelectedUrl="Blank" LeftIcon-HoverUrl="Triangle1">
            <SubMenu Style-CssText="PADDING-RIGHT: 2px; PADDING-LEFT: 2px; FONT-SIZE: 8pt; PADDING-BOTTOM: 2px; CURSOR: hand; COLOR: #003000; BORDER-TOP-STYLE: none; PADDING-TOP: 2px; FONT-FAMILY: Verdana; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none"
                LeftIconCellWidth="7" ShadowDepth="0" ItemSpacing="1"></SubMenu>
        </eo:MenuItem>
    </LookItems>
</eo:Menu>
</asp:Content>


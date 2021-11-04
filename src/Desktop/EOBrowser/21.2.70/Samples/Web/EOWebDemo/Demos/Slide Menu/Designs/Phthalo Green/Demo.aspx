<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Slide_Menu_Designs_Phthalo_Green_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:SlideMenu runat="server" ID="Slidemenu1" SlidePaneHeight="120" ControlSkinID="None" Width="120px">
    <TopGroup>
        <Items>
            <eo:MenuItem Text-Html="Home">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="Bedding"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Kitchen"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Patio"></eo:MenuItem>
                        <eo:MenuItem Text-Html="See All"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem Text-Html="Furniture">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="Bed Room"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Living Room"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Home Office"></eo:MenuItem>
                        <eo:MenuItem Text-Html="See All"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem Text-Html="Electronics">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="Digital Cameras"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Audio"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Televisions"></eo:MenuItem>
                        <eo:MenuItem Text-Html="See All"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem ItemID="_TopGroup">
            <SubMenu Style-CssText="FONT-SIZE: 8pt; CURSOR: hand; COLOR: #003000; BORDER-TOP-STYLE: none; FONT-FAMILY: Verdana; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
                ItemSpacing="1"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem HoverStyle-CssText="BORDER-RIGHT: #9c9a9c 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #9c9a9c 1px solid; PADDING-LEFT: 3px; PADDING-BOTTOM: 2px; BORDER-LEFT: #9c9a9c 1px solid; COLOR: #9c6500; PADDING-TOP: 2px; BORDER-BOTTOM: #9c9a9c 1px solid; BACKGROUND-COLOR: #efefef"
            ItemID="_TopLevelItem" NormalStyle-CssText="BORDER-RIGHT: #9c9a9c 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #9c9a9c 1px solid; PADDING-LEFT: 3px; PADDING-BOTTOM: 2px; BORDER-LEFT: #9c9a9c 1px solid; COLOR: #003000; PADDING-TOP: 2px; BORDER-BOTTOM: #9c9a9c 1px solid; BACKGROUND-COLOR: #efefef"
            SelectedStyle-CssText="background-color:#316531;border-bottom-color:#003000;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#003000;border-left-style:solid;border-left-width:1px;border-right-color:#003000;border-right-style:solid;border-right-width:1px;border-top-color:#003000;border-top-style:solid;border-top-width:1px;color:white;padding-bottom:2px;padding-left:3px;padding-right:5px;padding-top:2px;">
            <SubMenu Style-CssText="background-color:transparent;border-bottom-color:#9C9A9C;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#9C9A9C;border-left-style:solid;border-left-width:1px;border-right-color:#9C9A9C;border-right-style:solid;border-right-width:1px;border-top-color:#9C9A9C;border-top-style:solid;border-top-width:1px;color:#003000;cursor:hand;font-family:Verdana;font-size:8pt;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;"
                LeftIconCellWidth="2" ItemSpacing="1"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem DisabledStyle-CssText="color:lightgrey" Height="15" HoverStyle-CssText="color:#9C6500;"
            ItemID="_Default" NormalStyle-CssText="color:#003000;" SelectedStyle-CssText="background-color:Silver;">
            <SubMenu Style-CssText="BORDER-RIGHT: #9c9a9c 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #9c9a9c 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 8pt; PADDING-BOTTOM: 2px; BORDER-LEFT: #9c9a9c 1px solid; CURSOR: hand; COLOR: #003000; PADDING-TOP: 2px; BORDER-BOTTOM: #9c9a9c 1px solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: transparent"
                OffsetX="2" ShadowDepth="0" ItemSpacing="1"></SubMenu>
        </eo:MenuItem>
    </LookItems>
</eo:SlideMenu>
</asp:Content>


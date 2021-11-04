<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Designs_Round_Corners_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:Menu runat="server" id="Menu1" SubMenuPositionConfine="None" ControlSkinID="None" Width="400px">
    <TopGroup Style-CssText="border-left-width: 1px; font-size: 12px; border-left-color: #e0e0e0; background-image: url(00000300); padding-bottom: 0px; cursor: hand; color: #555555; padding-top: 0px; font-family: arial"
        ItemSpacing="1">
        <Items>
            <eo:MenuItem LookID="None" Image-Url="00000301" Text-Html="("></eo:MenuItem>
            <eo:MenuItem LookID="None" Text-Padding-Right="6" Text-Html="HOME"></eo:MenuItem>
            <eo:MenuItem LookID="None" Image-Url="00000303" Text-Html="|"></eo:MenuItem>
            <eo:MenuItem Text-Html="SOLUTIONS">
                <SubMenu>
                    <Items>
                        <eo:MenuItem LookID="submenu_top" ItemID="top_border" Text-Html=""></eo:MenuItem>
                        <eo:MenuItem Text-Html="Education"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Financial Services"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Government"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Manufacturing"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Telecommunications"></eo:MenuItem>
                        <eo:MenuItem LookID="separator" ItemID="separator" Text-Html=""></eo:MenuItem>
                        <eo:MenuItem Text-Html="Training and eLearning"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Video and Audio"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Web Conferencing"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Web Publishing"></eo:MenuItem>
                        <eo:MenuItem LookID="submenu_bottom" ItemID="bottom_border" Text-Html=""></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem LookID="None" Image-Url="00000303" Text-Html="|"></eo:MenuItem>
            <eo:MenuItem Text-Html="DOWNLOADS">
                <SubMenu>
                    <Items>
                        <eo:MenuItem LookID="submenu_top" ItemID="top_border" Text-Html=""></eo:MenuItem>
                        <eo:MenuItem Text-Html="Download Home"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Trial Downloads"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Upgrades"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Platinum Package"></eo:MenuItem>
                        <eo:MenuItem LookID="submenu_bottom" ItemID="bottom_border" Text-Html=""></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem LookID="None" Image-Url="00000303" Text-Html="|"></eo:MenuItem>
            <eo:MenuItem Text-Html="SUPPORT">
                <SubMenu>
                    <Items>
                        <eo:MenuItem LookID="submenu_top" ItemID="top_border" Text-Html=""></eo:MenuItem>
                        <eo:MenuItem Text-Html="Support Home"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Customer Service"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Documentations"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Training"></eo:MenuItem>
                        <eo:MenuItem LookID="submenu_bottom" ItemID="bottom_border" Text-Html=""></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem LookID="None" Image-Url="00000303" Text-Html="|"></eo:MenuItem>
            <eo:MenuItem Text-Html="COMPANY">
                <SubMenu>
                    <Items>
                        <eo:MenuItem LookID="submenu_top" ItemID="top_border" Text-Html=""></eo:MenuItem>
                        <eo:MenuItem Text-Html="Support Home"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Training"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Documentation"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Forums"></eo:MenuItem>
                        <eo:MenuItem LookID="submenu_bottom" ItemID="bottom_border" Text-Html=""></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem LookID="None" Width="50" Image-Url="Blank" Text-Html="-"></eo:MenuItem>
            <eo:MenuItem LookID="None" Image-Url="00000302" Text-Html=")"></eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem ItemID="_TopLevelItem" RightIcon-Url="00000300" RightIcon-HoverUrl="00000305" LeftIcon-Url="00000300"
            LeftIcon-HoverUrl="00000304" Image-Url="00000300" Image-HoverUrl="00000306" Image-Mode="TextBackground">
            <SubMenu Style-CssText="font-size: 12px; cursor: hand; font-family: arial; background-color: #f7f7f7;"
                OffsetX="0" ShadowDepth="0" OffsetY="-6"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem Height="23" HoverStyle-CssText="background-color:#dddddd;border-left-color:#dfdfdf;border-left-style:solid;border-left-width:1px;border-right-color:#dfdfdf;border-right-style:solid;border-right-width:1px;color:#C00000;"
            ItemID="_Default" NormalStyle-CssText="border-right: #dfdfdf 1px solid; border-left: #dfdfdf 1px solid; color: #333333"
            Text-Padding-Left="7" Text-Padding-Right="20"></eo:MenuItem>
        <eo:MenuItem ItemID="separator" RightIcon-Url="00000315" LeftIcon-Url="00000313" Image-Url="00000314"
            Image-Mode="TextBackground"></eo:MenuItem>
        <eo:MenuItem ItemID="submenu_bottom" RightIcon-Url="00000311" LeftIcon-Url="00000310" Image-Url="00000312"
            Image-Mode="TextBackground"></eo:MenuItem>
        <eo:MenuItem ItemID="submenu_top" RightIcon-Url="00000309" LeftIcon-Url="00000308" Image-Url="00000307"
            Image-Mode="TextBackground"></eo:MenuItem>
    </LookItems>
</eo:Menu>
</asp:Content>


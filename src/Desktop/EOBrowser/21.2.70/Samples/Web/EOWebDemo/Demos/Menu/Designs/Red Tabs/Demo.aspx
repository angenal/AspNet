<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Designs_Red_Tabs_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
Note: An enhanced version of this sample can be found <a href="javascript:GoToDemo('red_tabs2');">here</a>.
Unlike this menu hiding all sub menus, including the menu bars when it is
inactive, the enhanced version keeps the menu bar visible all the time.
</p>
<eo:Menu runat="server" id="Menu1" SubMenuPositionConfine="None" ControlSkinID="None" Width="300px">
    <TopGroup Style-CssText="font-weight: bold; font-size: 12px; cursor: hand; color: white; font-family: arial; background-color: white"
        ItemSpacing="2">
        <Items>
            <eo:MenuItem Expanded="True" Width="82" Text-Html="Consumer">
                <SubMenu Width="500" Orientation="Horizontal">
                    <Items>
                        <eo:MenuItem LookID="second_level" Text-Html="Computers &amp; Peripherals">
                            <SubMenu>
                                <Items>
                                    <eo:MenuItem Text-Html="Desktop Systems"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Notebooks and Tablet PCs"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Monitors"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Printers"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Projectors"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Networking"></eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                        <eo:MenuItem LookID="second_level" Text-Html="Upgrades">
                            <SubMenu>
                                <Items>
                                    <eo:MenuItem Text-Html="Memory"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Motherboards"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Processors"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Sound Cards"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Video Cards"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Hard Drives"></eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                        <eo:MenuItem LookID="second_level" Text-Html="Software">
                            <SubMenu>
                                <Items>
                                    <eo:MenuItem Text-Html="AntiVirus/Internet Security"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Word Processors"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Programming"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Accounting"></eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                        <eo:MenuItem LookID="second_level" Text-Html="Accessories">
                            <SubMenu>
                                <Items>
                                    <eo:MenuItem Text-Html="Batteries"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Cables"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Media Storage"></eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem Width="76" Text-Html="Business">
                <SubMenu Width="500" Orientation="Horizontal" OffsetX="-84">
                    <Items>
                        <eo:MenuItem LookID="second_level" Text-Html="Electronics"></eo:MenuItem>
                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                        <eo:MenuItem LookID="second_level" Text-Html="Office Supplies"></eo:MenuItem>
                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                        <eo:MenuItem LookID="second_level" Text-Html="Other"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem Width="74" Text-Html="Services">
                <SubMenu Width="500" Orientation="Horizontal" OffsetX="-162">
                    <Items>
                        <eo:MenuItem LookID="second_level" Text-Html="Services Plans"></eo:MenuItem>
                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                        <eo:MenuItem LookID="second_level" Text-Html="Training"></eo:MenuItem>
                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                        <eo:MenuItem LookID="second_level" Text-Html="Customer Service"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem HoverStyle-CssText="background-color:#313131;" ItemID="_TopLevelItem" RightIcon-Url="00000401"
            RightIcon-HoverUrl="00000403" NormalStyle-CssText="background-color:#CC0000;" LeftIcon-Url="00000400"
            LeftIcon-HoverUrl="00000402">
            <SubMenu Style-CssText="padding-right: 6px; padding-left: 6px; font-size: 12px; padding-bottom: 6px; cursor: hand; color: white; padding-top: 6px; font-family: arial; background-color: #313131"
                ShadowDepth="0" ItemSpacing="6"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="margin-top: 3px; margin-bottom: 3px; width: 1px; height: 1px; background-color: white"></eo:MenuItem>
        <eo:MenuItem Height="22" HoverStyle-CssText="border-top: #313131 1px solid; color: #ffff00; background-color: #727272"
            ItemID="_Default" NormalStyle-CssText="border-top: #727272 1px solid; color: white; text-decoration: none"
            Text-Padding-Left="10" Text-Padding-Right="20"></eo:MenuItem>
        <eo:MenuItem IsSeparator="True" HoverStyle-CssText="color: #ffff00; text-decoration: underline"
            ItemID="second_level" NormalStyle-CssText="color: white; text-decoration: none">
            <SubMenu Style-CssText="font-size: 12px; cursor: hand; color: white; font-family: arial; background-color: #313131"
                ShadowDepth="0" OffsetY="5" ItemSpacing="0"></SubMenu>
        </eo:MenuItem>
    </LookItems>
</eo:Menu>
</asp:Content>


<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Features_Cool_Effects_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>EO.Web Menu supports 60+ expanding/collapsing effects. All glide and reveal effects
are supported by all browsers. The others are supported by IE only.
</p>
<eo:Menu id="Menu1" ControlSkinID="None" runat="server" Width="300px">
    <TopGroup Style-CssText="background-image:url(00020005);border-left-color:#e0e0e0;border-left-style:solid;border-left-width:1px;border-right-color:#e0e0e0;border-right-style:solid;border-right-width:1px;border-top-color:#e0e0e0;border-top-style:solid;border-top-width:1px;cursor:hand;font-family:Verdana;font-size:11px;padding-bottom:3px;padding-left:10px;padding-right:10px;padding-top:3px;">
        <Items>
            <eo:MenuItem ItemID="item1" Text-Html="Glide">
                <SubMenu>
                    <Items>
                        <eo:MenuItem ItemID="item13" Text-Html="Top to bottom">
                            <SubMenu ExpandEffect-Type="GlideTopToBottom" ExpandEffect-Duration="500" CollapseEffect-Type="GlideTopToBottom"
                                CollapseEffect-Duration="500">
                                <Items>
                                    <eo:MenuItem Text-Html="Menu item 1"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 2"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 3"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 4"></eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem ItemID="item14" Text-Html="Bottom to top">
                            <SubMenu ExpandEffect-Type="GlideBottomToTop" ExpandEffect-Duration="500" CollapseEffect-Type="GlideBottomToTop"
                                CollapseEffect-Duration="500">
                                <Items>
                                    <eo:MenuItem Text-Html="Menu item 1"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 2"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 3"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 4"></eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem ItemID="item15" Text-Html="Left to right">
                            <SubMenu ExpandEffect-Type="GlideLeftToRight" ExpandEffect-Duration="500" CollapseEffect-Type="GlideLeftToRight"
                                CollapseEffect-Duration="500">
                                <Items>
                                    <eo:MenuItem Text-Html="Menu item 1"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 2"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 3"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 4"></eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem ItemID="item16" Text-Html="Right to left">
                            <SubMenu ExpandEffect-Type="GlideRightToLeft" ExpandEffect-Duration="500" CollapseEffect-Type="GlideRightToLeft"
                                CollapseEffect-Duration="500">
                                <Items>
                                    <eo:MenuItem Text-Html="Menu item 1"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 2"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 3"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 4"></eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem ItemID="item2" Text-Html="Reveal">
                <SubMenu>
                    <Items>
                        <eo:MenuItem ItemID="item59" Text-Html="Top to bottom">
                            <SubMenu ExpandEffect-Type="RevealTopToBottom" ExpandEffect-Duration="600">
                                <Items>
                                    <eo:MenuItem Text-Html="Menu item 1"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 2"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 3"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 4"></eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem ItemID="item64" Text-Html="Bottom to top">
                            <SubMenu ExpandEffect-Type="RevealBottomToTop" ExpandEffect-Duration="600">
                                <Items>
                                    <eo:MenuItem Text-Html="Menu item 1"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 2"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 3"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 4"></eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem ItemID="item69" Text-Html="Left to right">
                            <SubMenu ExpandEffect-Type="RevealLeftToRight" ExpandEffect-Duration="600">
                                <Items>
                                    <eo:MenuItem Text-Html="Menu item 1"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 2"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 3"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 4"></eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem ItemID="item74" Text-Html="Right to left">
                            <SubMenu ExpandEffect-Type="RevealRightToLeft" ExpandEffect-Duration="600">
                                <Items>
                                    <eo:MenuItem Text-Html="Menu item 1"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 2"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 3"></eo:MenuItem>
                                    <eo:MenuItem Text-Html="Menu Item 4"></eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem ItemID="item9" Text-Html="IE Effects">
                <SubMenu>
                    <Items>
                        <eo:MenuItem ItemID="item3" Text-Html="Barn">
                            <SubMenu>
                                <Items>
                                    <eo:MenuItem ItemID="item17" Text-Html="Barn out vertical">
                                        <SubMenu ExpandEffect-Type="BarnOutVertical" ExpandEffect-Duration="500">
                                            <Items>
                                                <eo:MenuItem Text-Html="Item 1"></eo:MenuItem>
                                                <eo:MenuItem Text-Html="Item 2"></eo:MenuItem>
                                            </Items>
                                        </SubMenu>
                                    </eo:MenuItem>
                                    <eo:MenuItem ItemID="item18" Text-Html="Barn in horizontal">
                                        <SubMenu ExpandEffect-Type="BarnInHorizontal" ExpandEffect-Duration="500">
                                            <Items>
                                                <eo:MenuItem Text-Html="Item 1"></eo:MenuItem>
                                                <eo:MenuItem Text-Html="Item 2"></eo:MenuItem>
                                            </Items>
                                        </SubMenu>
                                    </eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem ItemID="item4" Text-Html="Blinds">
                            <SubMenu>
                                <Items>
                                    <eo:MenuItem ItemID="item19" Text-Html="Blinds up">
                                        <SubMenu ExpandEffect-Type="BlindsUp" ExpandEffect-Duration="500">
                                            <Items>
                                                <eo:MenuItem Text-Html="Item 1"></eo:MenuItem>
                                                <eo:MenuItem Text-Html="Item 2"></eo:MenuItem>
                                            </Items>
                                        </SubMenu>
                                    </eo:MenuItem>
                                    <eo:MenuItem ItemID="item23" Text-Html="Blinds left">
                                        <SubMenu ExpandEffect-Type="BlindsLeft" ExpandEffect-Duration="500">
                                            <Items>
                                                <eo:MenuItem Text-Html="Item 1"></eo:MenuItem>
                                                <eo:MenuItem Text-Html="Item 2"></eo:MenuItem>
                                            </Items>
                                        </SubMenu>
                                    </eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem ItemID="item5" Text-Html="Checkerboard">
                            <SubMenu>
                                <Items>
                                    <eo:MenuItem ItemID="item32" Text-Html="Checkerboard down">
                                        <SubMenu ExpandEffect-Type="CheckerBoardDown" ExpandEffect-Duration="500">
                                            <Items>
                                                <eo:MenuItem Text-Html="Item 1"></eo:MenuItem>
                                                <eo:MenuItem Text-Html="Item 2"></eo:MenuItem>
                                            </Items>
                                        </SubMenu>
                                    </eo:MenuItem>
                                    <eo:MenuItem ItemID="item35" Text-Html="Checkerboard right">
                                        <SubMenu ExpandEffect-Type="CheckerBoardRight" ExpandEffect-Duration="500">
                                            <Items>
                                                <eo:MenuItem Text-Html="Item 1"></eo:MenuItem>
                                                <eo:MenuItem Text-Html="Item 2"></eo:MenuItem>
                                            </Items>
                                        </SubMenu>
                                    </eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem ItemID="item6" Text-Html="Gradient">
                            <SubMenu>
                                <Items>
                                    <eo:MenuItem ItemID="item43" Text-Html="Gradient wipe up">
                                        <SubMenu ExpandEffect-Type="GradientWipeUp" ExpandEffect-Duration="500">
                                            <Items>
                                                <eo:MenuItem Text-Html="Item 1"></eo:MenuItem>
                                                <eo:MenuItem Text-Html="Item 2"></eo:MenuItem>
                                            </Items>
                                        </SubMenu>
                                    </eo:MenuItem>
                                    <eo:MenuItem ItemID="item44" Text-Html="Gradient wipe left">
                                        <SubMenu ExpandEffect-Type="GradientWipeLeft" ExpandEffect-Duration="500">
                                            <Items>
                                                <eo:MenuItem Text-Html="Item 1"></eo:MenuItem>
                                                <eo:MenuItem Text-Html="Item 2"></eo:MenuItem>
                                            </Items>
                                        </SubMenu>
                                    </eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem ItemID="item12" Text-Html="Others">
                            <SubMenu>
                                <Items>
                                    <eo:MenuItem ItemID="item7" Text-Html="Random dissolve">
                                        <SubMenu ExpandEffect-Type="RandomDissolve" ExpandEffect-Duration="500">
                                            <Items>
                                                <eo:MenuItem Text-Html="Item 1"></eo:MenuItem>
                                                <eo:MenuItem Text-Html="Item 2"></eo:MenuItem>
                                            </Items>
                                        </SubMenu>
                                    </eo:MenuItem>
                                    <eo:MenuItem ItemID="item8" Text-Html="Iris diamond in">
                                        <SubMenu ExpandEffect-Type="IrisDiamondIn" ExpandEffect-Duration="500">
                                            <Items>
                                                <eo:MenuItem Text-Html="Item 1"></eo:MenuItem>
                                                <eo:MenuItem Text-Html="Item 2"></eo:MenuItem>
                                            </Items>
                                        </SubMenu>
                                    </eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_TopLevelItem"
            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
            <SubMenu Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                OffsetX="-3" ShadowDepth="0" OffsetY="3" ItemSpacing="5"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="background-color:#E0E0E0;height:1px;width:1px;"></eo:MenuItem>
        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_Default"
            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
            <SubMenu Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                OffsetX="3" ShadowDepth="0" OffsetY="-4" ItemSpacing="5"></SubMenu>
        </eo:MenuItem>
    </LookItems>
</eo:Menu>
</asp:Content>


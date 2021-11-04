<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Features_Accessibility_Features_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>EO.Web Menu supports various accessibility features that were designed to make 
    the menu easier to use for the end users. These features include:
</p>
<eo:tabstrip id="TabStrip1" ControlSkinID="None" runat="server" MultiPageID="MultiPage1">
    <TopGroup>
        <Items>
            <eo:TabItem Text-Html="Keyboard Navigation"></eo:TabItem>
            <eo:TabItem Text-Html="Expand/Collapse Delay"></eo:TabItem>
            <eo:TabItem Text-Html="Click To Expand"></eo:TabItem>
            <eo:TabItem Text-Html="And More"></eo:TabItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:TabItem Height="20" ItemID="_Default" RightIcon-Url="" NormalStyle-CssText="background-image:url('00020005');background-repeat:repeat-x;border-bottom-color:#B0B0B0;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#B0B0B0;border-left-style:solid;border-left-width:1px;border-right-color:#B0B0B0;border-right-style:solid;border-right-width:1px;border-top-color:#B0B0B0;border-top-style:solid;border-top-width:1px;color:Gray;font-weight:normal;padding-left:5px;padding-right:5px;"
            SelectedStyle-CssText="background-image:url('00020005');background-repeat:repeat-x;border-bottom-color:#b0b0b0;border-bottom-style:none;border-bottom-width:1px;border-left-color:#b0b0b0;border-left-style:solid;border-left-width:1px;border-right-color:#b0b0b0;border-right-style:solid;border-right-width:1px;border-top-color:#b0b0b0;border-top-style:solid;border-top-width:1px;color:Black;padding-left:5px;padding-right:5px;"
            LeftIcon-Url="" Text-Padding-Top="1" Text-Padding-Bottom="2">
            <SubGroup Style-CssText="background-image:url(00010601);background-position-y:bottom;background-repeat:repeat-x;color:black;cursor:hand;font-family:Verdana;font-size:11px;"
                ItemSpacing="1"></SubGroup>
        </eo:TabItem>
    </LookItems>
</eo:tabstrip>
<div style="PADDING-RIGHT: 3px; PADDING-LEFT: 3px; PADDING-TOP: 5px"><eo:multipage id="MultiPage1" runat="server">
        <eo:PageView id="PageView1" runat="server">
            <H4>Keyboard Navigation</H4>
            <P>The following menu has <SPAN class="highlight">EnableKeyboardNavigation</SPAN> set 
                to true and <SPAN class="highlight">Shortcut</SPAN> set to Ctrl+Shift+F, which 
                can be used to activate the menu. You can use arrow keys to navigate the menu 
                once it is activated.
            </P>
            <P>
                <eo:Menu id="Menu1" runat="server" ControlSkinID="None" Shortcut="Ctrl+Shift+F" EnableKeyboardNavigation="True"
                    Width="300px">
                    <TopGroup Style-CssText="background-image:url(00020005);border-left-color:#e0e0e0;border-left-style:solid;border-left-width:1px;border-right-color:#e0e0e0;border-right-style:solid;border-right-width:1px;border-top-color:#e0e0e0;border-top-style:solid;border-top-width:1px;cursor:hand;font-family:Verdana;font-size:11px;padding-bottom:3px;padding-left:10px;padding-right:10px;padding-top:3px;">
                        <Items>
                            <eo:MenuItem ItemID="item1" Text-Html="Format">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem Text-Html="Styles..."></eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Foreground Color..."></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Background Color..."></eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Font">
                                            <SubMenu>
                                                <Items>
                                                    <eo:MenuItem ItemID="item1" Text-Html="Bold"></eo:MenuItem>
                                                    <eo:MenuItem Text-Html="Italic"></eo:MenuItem>
                                                    <eo:MenuItem Text-Html="Underline"></eo:MenuItem>
                                                </Items>
                                            </SubMenu>
                                        </eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Horizontal Spacing"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Vertical Spacing"></eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Order"></eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                            <eo:MenuItem Text-Html="Layout">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem Text-Html="More Items"></eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                        </Items>
                    </TopGroup>
                    <LookItems>
                        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_TopLevelItem"
                            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
                            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                                CollapseEffect-Type="GlideTopToBottom" OffsetX="-3" ShadowDepth="0" OffsetY="3" ItemSpacing="5"></SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="background-color:#E0E0E0;height:1px;width:1px;"></eo:MenuItem>
                        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_Default"
                            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
                            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                                CollapseEffect-Type="GlideTopToBottom" OffsetX="3" ShadowDepth="0" OffsetY="-4" ItemSpacing="5"></SubMenu>
                        </eo:MenuItem>
                    </LookItems>
                </eo:Menu></P>
        </eo:PageView>
        <eo:PageView id="PageView2" runat="server">
            <H4>Expand/Collapse Delay</H4>
            <P>You can set the <SPAN class="highlight">ExpandDelay</SPAN> and <SPAN class="highlight">
                    CollapseDelay</SPAN> so that the menu won't be too sensitive to mouse 
                movement. This is especially helpful when you have a deep menu and want to 
                avoid mouse "slip over". <U>For demonstration purpose</U>, the following menu 
                has both value set to 1000ms, which is a much larger than normal value.
            </P>
            <P>
                <eo:Menu id="Menu2" runat="server" ControlSkinID="None" Shortcut="Ctrl+Shift+F" Width="300px"
                    CollapseDelay="1000" ExpandDelay="1000">
                    <TopGroup Style-CssText="background-image:url(00020005);border-left-color:#e0e0e0;border-left-style:solid;border-left-width:1px;border-right-color:#e0e0e0;border-right-style:solid;border-right-width:1px;border-top-color:#e0e0e0;border-top-style:solid;border-top-width:1px;cursor:hand;font-family:Verdana;font-size:11px;padding-bottom:3px;padding-left:10px;padding-right:10px;padding-top:3px;">
                        <Items>
                            <eo:MenuItem ItemID="item1" Text-Html="Format">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem Text-Html="Styles..."></eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Foreground Color..."></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Background Color..."></eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Font">
                                            <SubMenu>
                                                <Items>
                                                    <eo:MenuItem ItemID="item1" Text-Html="Bold"></eo:MenuItem>
                                                    <eo:MenuItem Text-Html="Italic"></eo:MenuItem>
                                                    <eo:MenuItem Text-Html="Underline"></eo:MenuItem>
                                                </Items>
                                            </SubMenu>
                                        </eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Horizontal Spacing"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Vertical Spacing"></eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Order"></eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                            <eo:MenuItem Text-Html="Layout">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem Text-Html="More Items"></eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                        </Items>
                    </TopGroup>
                    <LookItems>
                        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_TopLevelItem"
                            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
                            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                                CollapseEffect-Type="GlideTopToBottom" OffsetX="-3" ShadowDepth="0" OffsetY="3" ItemSpacing="5"></SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="background-color:#E0E0E0;height:1px;width:1px;"></eo:MenuItem>
                        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_Default"
                            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
                            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                                CollapseEffect-Type="GlideTopToBottom" OffsetX="3" ShadowDepth="0" OffsetY="-4" ItemSpacing="5"></SubMenu>
                        </eo:MenuItem>
                    </LookItems>
                </eo:Menu></P>
        </eo:PageView>
        <eo:PageView id="PageView3" runat="server">
            <H4>Click To Expand</H4>
            <P>By default, a sub menu expands on mouse over event. You can set it to expand 
                only on mouse click event. The following menu has <SPAN class="highlight">ExpandOnClick</SPAN>
                set to <SPAN class="highlight">EnabledForTopLevelOnly</SPAN>.
            </P>
            <P>
                <eo:Menu id="Menu3" runat="server" ControlSkinID="None" Width="300px" ExpandOnClick="EnabledForTopLevelOnly">
                    <TopGroup Style-CssText="background-image:url(00020005);border-left-color:#e0e0e0;border-left-style:solid;border-left-width:1px;border-right-color:#e0e0e0;border-right-style:solid;border-right-width:1px;border-top-color:#e0e0e0;border-top-style:solid;border-top-width:1px;cursor:hand;font-family:Verdana;font-size:11px;padding-bottom:3px;padding-left:10px;padding-right:10px;padding-top:3px;">
                        <Items>
                            <eo:MenuItem ItemID="item1" Text-Html="Format">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem Text-Html="Styles..."></eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Foreground Color..."></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Background Color..."></eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Font">
                                            <SubMenu>
                                                <Items>
                                                    <eo:MenuItem ItemID="item1" Text-Html="Bold"></eo:MenuItem>
                                                    <eo:MenuItem Text-Html="Italic"></eo:MenuItem>
                                                    <eo:MenuItem Text-Html="Underline"></eo:MenuItem>
                                                </Items>
                                            </SubMenu>
                                        </eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Horizontal Spacing"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Vertical Spacing"></eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Order"></eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                            <eo:MenuItem Text-Html="Layout">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem Text-Html="More Items"></eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                        </Items>
                    </TopGroup>
                    <LookItems>
                        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_TopLevelItem"
                            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
                            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                                CollapseEffect-Type="GlideTopToBottom" OffsetX="-3" ShadowDepth="0" OffsetY="3" ItemSpacing="5"></SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="background-color:#E0E0E0;height:1px;width:1px;"></eo:MenuItem>
                        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_Default"
                            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
                            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                                CollapseEffect-Type="GlideTopToBottom" OffsetX="3" ShadowDepth="0" OffsetY="-4" ItemSpacing="5"></SubMenu>
                        </eo:MenuItem>
                    </LookItems>
                </eo:Menu></P>
        </eo:PageView>
        <eo:PageView id="PageView4" runat="server">
            <H4>Keep Sub Menu Expanded</H4>
            <P>By default, sub menu closes when you click a menu item. <SPAN class="highlight">KeepSubMenuExpanded</SPAN>
                enables the menu to remain open after an item is clicked. To close the sub 
                menu, move mouse out of the sub menu.</P>
            <P>
                <eo:Menu id="Menu4" runat="server" ControlSkinID="None" Width="300px" KeepExpandedOnClick="True">
                    <TopGroup Style-CssText="background-image:url(00020005);border-left-color:#e0e0e0;border-left-style:solid;border-left-width:1px;border-right-color:#e0e0e0;border-right-style:solid;border-right-width:1px;border-top-color:#e0e0e0;border-top-style:solid;border-top-width:1px;cursor:hand;font-family:Verdana;font-size:11px;padding-bottom:3px;padding-left:10px;padding-right:10px;padding-top:3px;">
                        <Items>
                            <eo:MenuItem ItemID="item1" Text-Html="Format">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem Text-Html="Styles..."></eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Foreground Color..."></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Background Color..."></eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Font">
                                            <SubMenu>
                                                <Items>
                                                    <eo:MenuItem ItemID="item1" Text-Html="Bold"></eo:MenuItem>
                                                    <eo:MenuItem Text-Html="Italic"></eo:MenuItem>
                                                    <eo:MenuItem Text-Html="Underline"></eo:MenuItem>
                                                </Items>
                                            </SubMenu>
                                        </eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Horizontal Spacing"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Vertical Spacing"></eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Order"></eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                            <eo:MenuItem Text-Html="Layout">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem Text-Html="More Items"></eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                        </Items>
                    </TopGroup>
                    <LookItems>
                        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_TopLevelItem"
                            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
                            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                                CollapseEffect-Type="GlideTopToBottom" OffsetX="-3" ShadowDepth="0" OffsetY="3" ItemSpacing="5"></SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="background-color:#E0E0E0;height:1px;width:1px;"></eo:MenuItem>
                        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_Default"
                            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
                            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                                CollapseEffect-Type="GlideTopToBottom" OffsetX="3" ShadowDepth="0" OffsetY="-4" ItemSpacing="5"></SubMenu>
                        </eo:MenuItem>
                    </LookItems>
                </eo:Menu></P>
            <H4>ToolTip &amp; Status Text</H4>
            <P>You can optionally provide a tooltip and/or a window status text to each menu 
                item. The following menu has each item's <SPAN class="highlight">ToolTip</SPAN> 
                and <SPAN class="highlight">Status</SPAN> property set to the same as the menu 
                item text by code.</P>
            <P>
                <eo:Menu id="MenuForToolTip" runat="server" ControlSkinID="None" Width="300px">
                    <TopGroup Style-CssText="background-image:url(00020005);border-left-color:#e0e0e0;border-left-style:solid;border-left-width:1px;border-right-color:#e0e0e0;border-right-style:solid;border-right-width:1px;border-top-color:#e0e0e0;border-top-style:solid;border-top-width:1px;cursor:hand;font-family:Verdana;font-size:11px;padding-bottom:3px;padding-left:10px;padding-right:10px;padding-top:3px;">
                        <Items>
                            <eo:MenuItem ItemID="item1" Text-Html="Format">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem Text-Html="Styles..."></eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Foreground Color..."></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Background Color..."></eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Font">
                                            <SubMenu>
                                                <Items>
                                                    <eo:MenuItem ItemID="item1" Text-Html="Bold"></eo:MenuItem>
                                                    <eo:MenuItem Text-Html="Italic"></eo:MenuItem>
                                                    <eo:MenuItem Text-Html="Underline"></eo:MenuItem>
                                                </Items>
                                            </SubMenu>
                                        </eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Horizontal Spacing"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Vertical Spacing"></eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                                        <eo:MenuItem Text-Html="Order"></eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                            <eo:MenuItem Text-Html="Layout">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem Text-Html="More Items"></eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                        </Items>
                    </TopGroup>
                    <LookItems>
                        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_TopLevelItem"
                            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
                            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                                CollapseEffect-Type="GlideTopToBottom" OffsetX="-3" ShadowDepth="0" OffsetY="3" ItemSpacing="5"></SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="background-color:#E0E0E0;height:1px;width:1px;"></eo:MenuItem>
                        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_Default"
                            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
                            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                                CollapseEffect-Type="GlideTopToBottom" OffsetX="3" ShadowDepth="0" OffsetY="-4" ItemSpacing="5"></SubMenu>
                        </eo:MenuItem>
                    </LookItems>
                </eo:Menu></P>
        </eo:PageView>
    </eo:multipage>
    <P></P>
</div>
</asp:Content>


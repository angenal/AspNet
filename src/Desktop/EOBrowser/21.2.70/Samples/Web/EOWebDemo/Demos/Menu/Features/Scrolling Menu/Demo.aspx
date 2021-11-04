<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Features_Scrolling_Menu_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web Menu supports scrolling. To enable scrolling:
</p>
<ol>
    <li>
        Set the menu group's <span class="highlight">Height</span>
    to a value that's smaller than the full height;
    <li>
        Set the menu's <span class="highlight">EnableScrolling</span> to true;</li>
</ol>
<p>
    You can optionally customize the scrolling by:
</p>
<ol>
    <li>
        using <span class="highlight">ScrollUpLookID</span> and <span class="highlight">ScrollDownLookID</span>
    to customize the scrolling item's look;
    <li>
        Using <span class="highlight">ScrollSpeed</span> to customize the scrolling 
        speed;</li>
</ol>
<p>
<p>
    <eo:Menu ControlSkinID="None" runat="server" Width="300px" id="Menu1" EnableScrolling="True"
        ScrollDownLookID="scroll_down" ScrollUpLookID="scroll_up">
        <TopGroup Style-CssText="background-image:url(00020005);border-left-color:#e0e0e0;border-left-style:solid;border-left-width:1px;border-right-color:#e0e0e0;border-right-style:solid;border-right-width:1px;border-top-color:#e0e0e0;border-top-style:solid;border-top-width:1px;cursor:hand;font-family:Verdana;font-size:11px;padding-bottom:3px;padding-left:10px;padding-right:10px;padding-top:3px;">
            <Items>
                <eo:MenuItem ItemID="item1" Text-Html="Format">
                    <SubMenu Height="150">
                        <Items>
                            <eo:MenuItem Text-Html="Styles..."></eo:MenuItem>
                            <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                            <eo:MenuItem Text-Html="Foreground Color..."></eo:MenuItem>
                            <eo:MenuItem Text-Html="Background Color..."></eo:MenuItem>
                            <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                            <eo:MenuItem Text-Html="Font - Bold"></eo:MenuItem>
                            <eo:MenuItem Text-Html="Font - Underline"></eo:MenuItem>
                            <eo:MenuItem Text-Html="Font - Italic"></eo:MenuItem>
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
            <eo:MenuItem Height="14" ItemID="scroll_down" NormalStyle-CssText="background-image:url('00020005');border-bottom-color:#E0E0E0;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#E0E0E0;border-left-style:solid;border-left-width:1px;border-right-color:#E0E0E0;border-right-style:solid;border-right-width:1px;border-top-color:#E0E0E0;border-top-style:solid;border-top-width:1px;"
                Image-Url="00020001"></eo:MenuItem>
            <eo:MenuItem Height="14" ItemID="scroll_up" NormalStyle-CssText="background-image:url('00020005');border-bottom-color:#E0E0E0;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#E0E0E0;border-left-style:solid;border-left-width:1px;border-right-color:#E0E0E0;border-right-style:solid;border-right-width:1px;border-top-color:#E0E0E0;border-top-style:solid;border-top-width:1px;"
                Image-Url="00020000"></eo:MenuItem>
        </LookItems>
    </eo:Menu></p>
</asp:Content>


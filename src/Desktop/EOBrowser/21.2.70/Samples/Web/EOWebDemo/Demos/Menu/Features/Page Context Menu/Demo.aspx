<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Features_Page_Context_Menu_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>EO.Web Menu offers a <span class="highlight">PageContextMenu</span> that you can 
    simply drop into the page and provide a context menu for the whole page.
</p>
<p>
    You can also use the <span class="highlight">ContextMenu</span> to provide context
    menu for a specific element. See <a href="javascript:GoToDemo('element_context_menu')">here</a> for 
    demo on element bound context menu.
</p>
<p>
    Right click anywhere to see the context menu.
</p>
<p>
    <eo:PageContextMenu ControlSkinID="None" runat="server" Width="144px" id="Menu1">
        <TopGroup Style-CssText="cursor:hand;font-family:Verdana;font-size:11px;">
            <Items>
                <eo:MenuItem Text-Html="Back"></eo:MenuItem>
                <eo:MenuItem Text-Html="Forward"></eo:MenuItem>
                <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                <eo:MenuItem Text-Html="Encoding">
                    <SubMenu>
                        <Items>
                            <eo:MenuItem Text-Html="Unicode"></eo:MenuItem>
                            <eo:MenuItem Text-Html="Western Europe (ISO)"></eo:MenuItem>
                        </Items>
                    </SubMenu>
                </eo:MenuItem>
                <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                <eo:MenuItem Text-Html="Refresh"></eo:MenuItem>
            </Items>
        </TopGroup>
        <LookItems>
            <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="background-color:#E0E0E0;height:1px;width:1px;"></eo:MenuItem>
            <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_Default"
                NormalStyle-CssText="padding-left:5px;padding-right:5px;">
                <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                    CollapseEffect-Type="GlideTopToBottom" OffsetX="3" ShadowDepth="0" OffsetY="-4" ItemSpacing="5"></SubMenu>
            </eo:MenuItem>
        </LookItems>
    </eo:PageContextMenu>
</p>
</asp:Content>


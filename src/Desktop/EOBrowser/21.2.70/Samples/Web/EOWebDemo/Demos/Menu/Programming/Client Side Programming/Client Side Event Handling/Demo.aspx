<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Programming_Client_Side_Programming_Client_Side_Event_Handling_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
function MenuItemClickHandler(e, info)
{
    window.alert("Menu item '" + 
        info.getItem().getText() + "' clicked.");
}
//<!--JS_SAMPLE_END-->
</script>
<p>
    EO.Web Menu offers a complete set of client side JavaScript interface. You can 
    use this interface to handle events on the client side.
</p>
<p>
    The following sample uses <span class="highlight">ClientSideOnItemClick</span> to 
    handle item click event on the client side. Many other events are available; 
    please refer the product documentations for more details.
</p>
<p>
    Another example demonstrating how to programmatically modify the menu on the 
    client side is available <a href="javascript:GoToDemo('js_modify_menu');">here</a>.
</p>
<eo:Menu id="Menu1" Width="300px" runat="server" ControlSkinID="None" ClientSideOnItemClick="MenuItemClickHandler">
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
</eo:Menu>
</asp:Content>


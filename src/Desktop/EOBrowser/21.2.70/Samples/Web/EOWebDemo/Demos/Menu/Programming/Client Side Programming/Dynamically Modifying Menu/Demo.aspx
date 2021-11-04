<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Programming_Client_Side_Programming_Dynamically_Modifying_Menu_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
function MenuItemClickHandler(e, info)
{
    var group = info.getItem().getParentGroup();
    switch (info.getItem().getValue())
    {
    case "disable":
        info.getItem().setDisabled(true);
        break;
    case "enable_all":
        for (var i = 0; i < group.getItemCount(); i++)
            group.getItemByIndex(i).setDisabled(false);
        break;
    case "hide":
        info.getItem().setVisible(false);
        break;
    case "show_all":
        for (var i = 0; i < group.getItemCount(); i++)
            group.getItemByIndex(i).setVisible(true);
        break;
    }
}
//<!--JS_SAMPLE_END-->
</script>
<p>
    This sample demonstrates how to show/hide/enable/disable a menu item using the client
    side JavaScript interface.
</p>
<p>
    Another sample demonstrating how to dynamically modifying menu item text using client
    side JavaScript interface is available <a href="javascript:GoToDemo('grid_context_menu')">here</a>.
</p>
<eo:Menu id="Menu1" Width="300px" runat="server" ControlSkinID="None" ClientSideOnItemClick="MenuItemClickHandler">
    <TopGroup Style-CssText="background-image:url(00020005);border-left-color:#e0e0e0;border-left-style:solid;border-left-width:1px;border-right-color:#e0e0e0;border-right-style:solid;border-right-width:1px;border-top-color:#e0e0e0;border-top-style:solid;border-top-width:1px;cursor:hand;font-family:Verdana;font-size:11px;padding-bottom:3px;padding-left:10px;padding-right:10px;padding-top:3px;">
        <Items>
            <eo:MenuItem Text-Html="Enable/Disable">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Value="disable" Text-Html="Disable Me"></eo:MenuItem>
                        <eo:MenuItem Value="disable" Text-Html="Disable Me Too"></eo:MenuItem>
                        <eo:MenuItem Value="enable_all" Text-Html="Enable All"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem Text-Html="Hide/Show">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Value="hide" Text-Html="Hide Me"></eo:MenuItem>
                        <eo:MenuItem Value="hide" Text-Html="Hide Me Too"></eo:MenuItem>
                        <eo:MenuItem Value="show_all" Text-Html="Show All"></eo:MenuItem>
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
        <eo:MenuItem DisabledStyle-CssText="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; COLOR: gainsboro"
            HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_Default"
            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                CollapseEffect-Type="GlideTopToBottom" OffsetX="3" ShadowDepth="0" OffsetY="-4" ItemSpacing="5"></SubMenu>
        </eo:MenuItem>
    </LookItems>
</eo:Menu>
</asp:Content>


<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Programming_Client_Side_Programming_Tab_Menu_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
//The current selected top level item
var g_curSelectedItem = null;

function on_menu_hover(e, info)
{
    var item = info.getItem();
    if (g_curSelectedItem == item)
        return;
    
    if (g_curSelectedItem)
    {
        //Unselect current selected item
        g_curSelectedItem.setSelected(false);
        
        //Hide child menu
        document.getElementById(g_curSelectedItem.getValue()).style.display = "none";
    }
    else
        document.getElementById("divConsumer").style.display = "none";
    if (item)
    {
        //Select the new item
        item.setSelected(true);
        
        //Show new child emnu
        document.getElementById(item.getValue()).style.display = "block";
    }
    
    g_curSelectedItem = item;
}
</script>
<p>
This sample enhances the built-in <a href="javascript:GoToDemo('red_tabs');">Red Tab</a> template.
The built-in <b>Red Tab</b> template hides all sub menus, including
the horizontal menu bars when the menu becomes inactive. This sample
implements a solution that keeps the menu bar visible all the time. 
The solution uses a top menu with no sub menus and three lower menus,
with each lower menu contains menu items that were sub menu items of
the original top menu item. The code then handles the top menu's
<b>ClientSideOnItemMouseOver</b> to dynamically show/hide only one
of the lower menu.
</p>
<eo:Menu runat="server" id="Menu1" SubMenuPositionConfine="None" ControlSkinID="None" Width="300px"
    ClientSideOnItemMouseOver="on_menu_hover">
    <TopGroup Style-CssText="font-weight: bold; font-size: 12px; cursor: hand; color: white; font-family: arial; background-color: white"
        ItemSpacing="2">
        <Items>
            <eo:MenuItem Selected="True" Expanded="True" Width="82" Value="divConsumer" Text-Html="Consumer"></eo:MenuItem>
            <eo:MenuItem Width="76" Value="divBusiness" Text-Html="Business"></eo:MenuItem>
            <eo:MenuItem Width="74" Value="divServices" Text-Html="Services"></eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem ItemID="_TopLevelItem" RightIcon-Url="00000401" RightIcon-SelectedUrl="00000403"
            NormalStyle-CssText="background-color:#CC0000;" SelectedStyle-CssText="background-color:#313131;"
            LeftIcon-Url="00000400" LeftIcon-SelectedUrl="00000402"></eo:MenuItem>
        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="margin-top: 3px; margin-bottom: 3px; width: 1px; height: 1px; background-color: white"></eo:MenuItem>
    </LookItems>
</eo:Menu>
<div id="divConsumer">
    <eo:Menu runat="server" id="mnuConsumer" SubMenuPositionConfine="None" ControlSkinID="None"
        Width="500px">
        <TopGroup>
            <Items>
                <eo:MenuItem Text-Html="Computers &amp; Peripherals">
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
                <eo:MenuItem Text-Html="Upgrades">
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
                <eo:MenuItem Text-Html="Software">
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
                <eo:MenuItem Text-Html="Accessories">
                    <SubMenu>
                        <Items>
                            <eo:MenuItem Text-Html="Batteries"></eo:MenuItem>
                            <eo:MenuItem Text-Html="Cables"></eo:MenuItem>
                            <eo:MenuItem Text-Html="Media Storage"></eo:MenuItem>
                        </Items>
                    </SubMenu>
                </eo:MenuItem>
            </Items>
        </TopGroup>
        <LookItems>
            <eo:MenuItem ItemID="_TopGroup">
                <SubMenu Style-CssText="padding-right: 6px; padding-left: 6px; font-size: 12px; padding-bottom: 6px; cursor: hand; color: white; padding-top: 6px; font-family: arial; background-color: #313131"
                    ItemSpacing="6"></SubMenu>
            </eo:MenuItem>
            <eo:MenuItem IsSeparator="True" HoverStyle-CssText="color: #ffff00; text-decoration: underline"
                ItemID="_TopLevelItem" NormalStyle-CssText="color: white; text-decoration: none">
                <SubMenu Style-CssText="font-size: 12px; cursor: hand; color: white; font-family: arial; background-color: #313131"
                    ShadowDepth="0" OffsetY="5" ItemSpacing="0"></SubMenu>
            </eo:MenuItem>
            <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="margin-top: 3px; margin-bottom: 3px; width: 1px; height: 1px; background-color: white"></eo:MenuItem>
            <eo:MenuItem Height="22" HoverStyle-CssText="border-top: #313131 1px solid; color: #ffff00; background-color: #727272"
                ItemID="_Default" NormalStyle-CssText="border-top: #727272 1px solid; color: white; text-decoration: none"
                Text-Padding-Left="10" Text-Padding-Right="20"></eo:MenuItem>
        </LookItems>
    </eo:Menu>
</div>
<div id="divBusiness" style="DISPLAY:none">
    <eo:Menu runat="server" id="mnuBusiness" SubMenuPositionConfine="None" ControlSkinID="None"
        Width="500px">
        <TopGroup>
            <Items>
                <eo:MenuItem Text-Html="Electronics"></eo:MenuItem>
                <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                <eo:MenuItem Text-Html="Office Supplies"></eo:MenuItem>
                <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                <eo:MenuItem Text-Html="Other"></eo:MenuItem>
            </Items>
        </TopGroup>
        <LookItems>
            <eo:MenuItem ItemID="_TopGroup">
                <SubMenu Style-CssText="padding-right: 6px; padding-left: 6px; font-size: 12px; padding-bottom: 6px; cursor: hand; color: white; padding-top: 6px; font-family: arial; background-color: #313131"
                    ItemSpacing="6"></SubMenu>
            </eo:MenuItem>
            <eo:MenuItem IsSeparator="True" HoverStyle-CssText="color: #ffff00; text-decoration: underline"
                ItemID="_TopLevelItem" NormalStyle-CssText="color: white; text-decoration: none">
                <SubMenu Style-CssText="font-size: 12px; cursor: hand; color: white; font-family: arial; background-color: #313131"
                    ShadowDepth="0" OffsetY="5" ItemSpacing="0"></SubMenu>
            </eo:MenuItem>
            <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="margin-top: 3px; margin-bottom: 3px; width: 1px; height: 1px; background-color: white"></eo:MenuItem>
            <eo:MenuItem Height="22" HoverStyle-CssText="border-top: #313131 1px solid; color: #ffff00; background-color: #727272"
                ItemID="_Default" NormalStyle-CssText="border-top: #727272 1px solid; color: white; text-decoration: none"
                Text-Padding-Left="10" Text-Padding-Right="20"></eo:MenuItem>
        </LookItems>
    </eo:Menu>
</div>
<div id="divServices" style="DISPLAY:none">
    <eo:Menu runat="server" id="mnuServices" SubMenuPositionConfine="None" ControlSkinID="None"
        Width="500px">
        <TopGroup>
            <Items>
                <eo:MenuItem Text-Html="Services Plans"></eo:MenuItem>
                <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                <eo:MenuItem Text-Html="Training"></eo:MenuItem>
                <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                <eo:MenuItem Text-Html="Customer Service"></eo:MenuItem>
            </Items>
        </TopGroup>
        <LookItems>
            <eo:MenuItem ItemID="_TopGroup">
                <SubMenu Style-CssText="padding-right: 6px; padding-left: 6px; font-size: 12px; padding-bottom: 6px; cursor: hand; color: white; padding-top: 6px; font-family: arial; background-color: #313131"
                    ItemSpacing="6"></SubMenu>
            </eo:MenuItem>
            <eo:MenuItem IsSeparator="True" HoverStyle-CssText="color: #ffff00; text-decoration: underline"
                ItemID="_TopLevelItem" NormalStyle-CssText="color: white; text-decoration: none">
                <SubMenu Style-CssText="font-size: 12px; cursor: hand; color: white; font-family: arial; background-color: #313131"
                    ShadowDepth="0" OffsetY="5" ItemSpacing="0"></SubMenu>
            </eo:MenuItem>
            <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="margin-top: 3px; margin-bottom: 3px; width: 1px; height: 1px; background-color: white"></eo:MenuItem>
            <eo:MenuItem Height="22" HoverStyle-CssText="border-top: #313131 1px solid; color: #ffff00; background-color: #727272"
                ItemID="_Default" NormalStyle-CssText="border-top: #727272 1px solid; color: white; text-decoration: none"
                Text-Padding-Left="10" Text-Padding-Right="20"></eo:MenuItem>
        </LookItems>
    </eo:Menu>
</div>
</asp:Content>


<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TreeView_Features_Context_Menu_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
function ShowContextMenu(e, treeView, node)
{
    //Get the context menu object
    var menu = eo_GetObject("<%=Menu1.ClientID%>");
    
    //Modify the context menu
    menu.getTopGroup().getItemByIndex(0).setText("Open '" + node.getText() + "'");
    menu.getTopGroup().getItemByIndex(1).setText("Delete '" + node.getText() + "'");
    
    //Display the context menu. See documentation
    //for the Menu control for details about how
    //to handle menu item click event
    eo_ShowContextMenu(e, "<%=Menu1.ClientID%>");
    
    //Returns true to indicate that we have
    //displayed a context menu
    return true;
}
//<!--JS_SAMPLE_END-->
</script>
<p>
    EO.Web TreeView provides <b>ClientSideOnContextMenu</b> event handler for you 
    to display a context menu. Note the <b>TreeView</b> only provides such interfaces,
    the context menu itself is not part of the <b>TreeView</b> control, so the license
    for the TreeView does not cover the license for the menu. This sample uses an 
    EO.Web <b>ContextMenu</b> control to provide the context menu.
</p>
<eo:TreeView runat="server" id="TreeView1" Width="200px" ControlSkinID="None" Height="250px"
    ClientSideOnContextMenu="ShowContextMenu">
    <TopGroup Style-CssText="border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:black;cursor:hand;font-family:Tahoma;font-size:8pt;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;">
        <Nodes>
            <eo:TreeNode Text="Documents and Settings">
                <SubGroup>
                    <Nodes>
                        <eo:TreeNode Text="Administrator"></eo:TreeNode>
                        <eo:TreeNode Text="All Users"></eo:TreeNode>
                        <eo:TreeNode Text="Default User"></eo:TreeNode>
                    </Nodes>
                </SubGroup>
            </eo:TreeNode>
            <eo:TreeNode Text="Program Files">
                <SubGroup>
                    <Nodes>
                        <eo:TreeNode Text="Common Files"></eo:TreeNode>
                        <eo:TreeNode Text="ComPlus Applications"></eo:TreeNode>
                        <eo:TreeNode Text="Internet Explorer"></eo:TreeNode>
                        <eo:TreeNode Text="MSDN"></eo:TreeNode>
                    </Nodes>
                </SubGroup>
            </eo:TreeNode>
            <eo:TreeNode Text="Windows">
                <SubGroup>
                    <Nodes>
                        <eo:TreeNode Text="Fonts"></eo:TreeNode>
                        <eo:TreeNode Text="Help"></eo:TreeNode>
                        <eo:TreeNode Text="System32"></eo:TreeNode>
                    </Nodes>
                </SubGroup>
            </eo:TreeNode>
        </Nodes>
    </TopGroup>
    <LookNodes>
        <eo:TreeNode ImageUrl="00030301" DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;color:Gray;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
            CollapsedImageUrl="00030301" ItemID="_Default" NormalStyle-CssText="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; COLOR: black; BORDER-TOP-STYLE: none; PADDING-TOP: 1px; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none"
            ExpandedImageUrl="00030302" SelectedStyle-CssText="background-color:#316ac5;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:White;padding-bottom:0px;padding-left:0px;padding-right:0px;padding-top:0px;"></eo:TreeNode>
    </LookNodes>
</eo:TreeView>
<eo:ContextMenu id="Menu1" Width="144px" runat="server" ControlSkinID="None">
    <TopGroup Style-CssText="cursor:hand;font-family:Verdana;font-size:11px;">
        <Items>
            <eo:MenuItem Text-Html="Open"></eo:MenuItem>
            <eo:MenuItem Text-Html="Delete"></eo:MenuItem>
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
</eo:ContextMenu>
</asp:Content>


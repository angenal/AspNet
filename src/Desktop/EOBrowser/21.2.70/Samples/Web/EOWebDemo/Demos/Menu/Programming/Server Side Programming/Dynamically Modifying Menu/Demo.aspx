<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Programming_Server_Side_Programming_Dynamically_Modifying_Menu_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    The following sample demonstrates how to modify the menu programmatically on 
    the server side. This sample also uses a <span class="highlight">CallbackPanel</span>
    to update the menu through a callback so that the whole page won't reload.
</p>
<P>
    <eo:CallbackPanel runat="server" id="CallbackPanel1" Triggers="{ControlID:btnAddTopItem;Parameter:},{ControlID:btnAddSubItem;Parameter:},{ControlID:btnReset;Parameter:}">
        <eo:Menu id="Menu1" runat="server" Width="520px" ControlSkinID="None">
            <TopGroup Style-CssText="background-image:url(00020005);border-left-color:#e0e0e0;border-left-style:solid;border-left-width:1px;border-right-color:#e0e0e0;border-right-style:solid;border-right-width:1px;border-top-color:#e0e0e0;border-top-style:solid;border-top-width:1px;cursor:hand;font-family:Verdana;font-size:11px;padding-bottom:3px;padding-left:10px;padding-right:10px;padding-top:3px;"></TopGroup>
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
        <P style="MARGIN-TOP: 100px">
            <asp:TextBox id="txtNewItemText" Runat="server"></asp:TextBox>&nbsp;
            <asp:Button id="btnAddTopItem" Runat="server" Text="Add Top Item" OnClick="btnAddTopItem_Click"></asp:Button>&nbsp;
            <asp:Button id="btnAddSubItem" Runat="server" Text="Add Sub Item" OnClick="btnAddSubItem_Click"></asp:Button>&nbsp;
            <asp:Button id="btnReset" Runat="server" Text="Reset" OnClick="btnReset_Click" CausesValidation="False"></asp:Button></P>
    </eo:CallbackPanel></P>
<P>
    <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter the text for the new menu item."
        ControlToValidate="txtNewItemText"></asp:RequiredFieldValidator></P>
</asp:Content>


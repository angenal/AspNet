<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TreeView_Programming_Hierarchical_DB_Update_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    This sample demonstrates how to use <strong>ItemMoved</strong> event to save 
    changes made by user through drag &amp; drop back to the data source. Try to 
    drag &amp; drop to move a node, and then click "Post Back" button and "Rebind" 
    button to see it in action.
</p>
<eo:callbackpanel id="CallbackPanel1" runat="server" Triggers="{ControlID:Button1;Parameter:},{ControlID:Button2;Parameter:}">
    <eo:TreeView id="TreeView1" runat="server" AllowDragDrop="True" AllowDragReordering="True" ControlSkinID="None"
        Width="200px" Height="200px" OnItemMoved="TreeView1_ItemMoved">
        <LookNodes>
            <eo:TreeNode ImageUrl="00030301" DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;color:Gray;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
                CollapsedImageUrl="00030301" ItemID="_Default" NormalStyle-CssText="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; COLOR: black; BORDER-TOP-STYLE: none; PADDING-TOP: 1px; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none"
                ExpandedImageUrl="00030302" SelectedStyle-CssText="background-color:#316ac5;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:White;padding-bottom:0px;padding-left:0px;padding-right:0px;padding-top:0px;"></eo:TreeNode>
        </LookNodes>
        <TopGroup Style-CssText="border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:black;cursor:hand;font-family:Tahoma;font-size:8pt;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;">
            <Bindings>
                <eo:DataBinding Property="Text" DataField="FolderName"></eo:DataBinding>
                <eo:DataBinding Property="Value" DataField="NodeData"></eo:DataBinding>
            </Bindings>
        </TopGroup>
    </eo:TreeView>
    <P>The data source is not updated until the page posts back and triggers <STRONG>ItemMoved</STRONG>
        event.
    </P>
    <P>
        <asp:Button id="Button1" runat="server" Text="Post Back" OnClick="Button1_Click"></asp:Button>&nbsp;
        <asp:Label id="Label1" Runat="server"></asp:Label></P>
    <P>Click this button to repopulate the TreeView from data source to verify that the 
        data source has been updated.
    </P>
    <P>
        <asp:Button id="Button2" runat="server" Text="Rebind" OnClick="Button2_Click"></asp:Button>&nbsp;
        <asp:Label id="Label2" Runat="server"></asp:Label></P>
</eo:callbackpanel>
</asp:Content>


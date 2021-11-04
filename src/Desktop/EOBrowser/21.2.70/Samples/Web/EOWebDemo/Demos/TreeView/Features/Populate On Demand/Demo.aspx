<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TreeView_Features_Populate_On_Demand_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web TreeView supports populate on demand. Populate on demand is useful when 
    the full content of the TreeView is too large to be all loaded up front.
</p>
<p>
    To enable populate on demand, set the TreeNode's <span class="highlight">PopulateOnDemand</span>
    to true and handles the TreeView's <span class="highlight">ItemPopulate</span> event.
</p>
<p>
    The following TreeView use this feature to populate sub nodes when a parent 
    node is clicked.
</p>
<eo:TreeView runat="server" id="TreeView1" AutoSelect="ItemClick" ControlSkinID="None" Width="250px"
    Height="280px" OnItemPopulate="TreeView1_ItemPopulate">
    <TopGroup Style-CssText="border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:black;cursor:hand;font-family:Tahoma;font-size:8pt;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;">
        <Nodes>
            <eo:TreeNode PopulateOnDemand="True" Text="Demo Files"></eo:TreeNode>
        </Nodes>
    </TopGroup>
    <LookNodes>
        <eo:TreeNode ImageUrl="00030203" DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;color:Gray;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
            CollapsedImageUrl="00030301" ItemID="_Default" NormalStyle-CssText="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; COLOR: black; BORDER-TOP-STYLE: none; PADDING-TOP: 1px; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none"
            ExpandedImageUrl="00030302" SelectedStyle-CssText="background-color:#316ac5;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:White;padding-bottom:0px;padding-left:0px;padding-right:0px;padding-top:0px;"></eo:TreeNode>
    </LookNodes>
</eo:TreeView>
</asp:Content>


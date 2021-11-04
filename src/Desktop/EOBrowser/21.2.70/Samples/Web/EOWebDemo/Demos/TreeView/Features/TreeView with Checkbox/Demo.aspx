<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TreeView_Features_TreeView_with_Checkbox_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web TreeView supports checkboxes. To enable checkboxes, set the TreeView's <span class="highlight">
        Checkboxes.Visible</span> to true. You can also use other sub properties on 
    the Checkboxes property to customize the checkbox.
</p>
<p>
    On the client side, use <span class="highlight">TreeNode.getCheckState</span> to 
    get the check state of the tree node. When the page is posted back to the 
    server, the value is available in <span class="highlight">TreeNode.CheckState</span>
    property. <span class="highlight">TreeView.GetCheckedNodes</span> can also be 
    used to retrieve a list of all checked nodes.
</p>
<p>
    This sample also demonstrates three-state check box support.
</p>
<p>
</p>
<eo:TreeView runat="server" id="TreeView1" AutoSelect="ItemClick" ControlSkinID="None" Width="200px"
    Height="250px" AutoCheckParent="True">
    <LookNodes>
        <eo:TreeNode ImageUrl="00030301" DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;color:Gray;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
            CollapsedImageUrl="00030301" ItemID="_Default" NormalStyle-CssText="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; COLOR: black; BORDER-TOP-STYLE: none; PADDING-TOP: 1px; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none"
            ExpandedImageUrl="00030302" SelectedStyle-CssText="background-color:#316ac5;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:White;padding-bottom:0px;padding-left:0px;padding-right:0px;padding-top:0px;"></eo:TreeNode>
    </LookNodes>
    <TopGroup Style-CssText="border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:black;cursor:hand;font-family:Tahoma;font-size:8pt;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;">
        <Nodes>
            <eo:TreeNode ImageUrl="00030303" Text="Desktop">
                <SubGroup>
                    <Nodes>
                        <eo:TreeNode ImageUrl="00030304" Text="My Documents"></eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030305" Text="My Computer">
                            <SubGroup>
                                <Nodes>
                                    <eo:TreeNode ImageUrl="00030308" Text="Local Disk (C:)">
                                        <SubGroup>
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
                                        </SubGroup>
                                    </eo:TreeNode>
                                    <eo:TreeNode ImageUrl="00030309" Text="CD Drive (D:)"></eo:TreeNode>
                                    <eo:TreeNode ImageUrl="00030310" Text="Control Panel"></eo:TreeNode>
                                </Nodes>
                            </SubGroup>
                        </eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030306" Text="My Network Places"></eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030307" Text="Recycle Bin"></eo:TreeNode>
                    </Nodes>
                </SubGroup>
            </eo:TreeNode>
        </Nodes>
    </TopGroup>
    <CheckBoxImages Visible="True" Margin="3"></CheckBoxImages>
</eo:TreeView>
</asp:Content>


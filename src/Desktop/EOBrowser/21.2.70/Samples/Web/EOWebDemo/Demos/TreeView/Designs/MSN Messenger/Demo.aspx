<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TreeView_Designs_MSN_Messenger_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:TreeView runat="server" id="TreeView1" AutoSelect="ItemClick" ControlSkinID="None" Width="230px"
    Height="260px">
    <LineImages Visible="False"></LineImages>
    <TopGroup Style-CssText="cursor:hand;font-family:Tahoma;font-size:9pt;">
        <Nodes>
            <eo:TreeNode Text="&lt;b&gt;Online (3)&lt;/b&gt;">
                <SubGroup>
                    <Nodes>
                        <eo:TreeNode ImageUrl="00030503" Text="Contact 1"></eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030503" Text="Contact 2"></eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030503" Text="Contact 3"></eo:TreeNode>
                    </Nodes>
                </SubGroup>
            </eo:TreeNode>
            <eo:TreeNode Text="&lt;b&gt;Mobile (2)&lt;/b&gt;">
                <SubGroup>
                    <Nodes>
                        <eo:TreeNode ImageUrl="00030504" Text="Contact 4"></eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030504" Text="Contact 5"></eo:TreeNode>
                    </Nodes>
                </SubGroup>
            </eo:TreeNode>
            <eo:TreeNode Text="&lt;b&gt;Offline (4)&lt;/b&gt;">
                <SubGroup>
                    <Nodes>
                        <eo:TreeNode ImageUrl="00030505" Text="Contact 6"></eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030505" Text="Contact 7"></eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030505" Text="Contact 8"></eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030505" Text="Contact 9"></eo:TreeNode>
                    </Nodes>
                </SubGroup>
            </eo:TreeNode>
        </Nodes>
    </TopGroup>
    <LookNodes>
        <eo:TreeNode ImageUrl="00030503" CollapsedImageUrl="00030501" ItemID="_Default" NormalStyle-CssText="padding-right: 3px; padding-left: 3px; padding-bottom: 1px; padding-top: 1px"
            ExpandedImageUrl="00030502" SelectedStyle-CssText="border-right: #8396c3 1px solid; padding-right: 2px; border-top: #8396c3 1px solid; padding-left: 2px; padding-bottom: 0px; border-left: #8396c3 1px solid; padding-top: 0px; border-bottom: #8396c3 1px solid; background-color: #f2f5fb">
            <SubGroup ItemSpacing="4"></SubGroup>
        </eo:TreeNode>
    </LookNodes>
</eo:TreeView>
</asp:Content>


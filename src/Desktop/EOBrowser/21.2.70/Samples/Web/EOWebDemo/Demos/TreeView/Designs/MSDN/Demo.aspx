<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TreeView_Designs_MSDN_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:TreeView runat="server" id="TreeView1" ControlSkinID="None" Width="200px" Height="250px">
    <LineImages PlusMinusOnly="True"></LineImages>
    <TopGroup Style-CssText="font-size: 9pt; font-family: Verdana; color: black; cursor: hand; background-color: #f1f1f1; border-right: #999999 1px solid; border-top: #999999 1px solid; border-left: #999999 1px solid; border-bottom: #999999 1px solid; padding-right: 2px; padding-left: 2px; padding-bottom: 2px; padding-top: 2px">
        <Nodes>
            <eo:TreeNode Text="Welcome to MSDN Library">
                <SubGroup>
                    <Nodes>
                        <eo:TreeNode Text="How to Use the MSDN Library Table of Contents"></eo:TreeNode>
                    </Nodes>
                </SubGroup>
            </eo:TreeNode>
            <eo:TreeNode Text="Development Tools and Languages">
                <SubGroup>
                    <Nodes>
                        <eo:TreeNode Text="Visual Studio 2005"></eo:TreeNode>
                        <eo:TreeNode Text="Visual Studio.NET"></eo:TreeNode>
                        <eo:TreeNode Text=".NET Framework SDK"></eo:TreeNode>
                    </Nodes>
                </SubGroup>
            </eo:TreeNode>
            <eo:TreeNode Text=".NET Development">
                <SubGroup>
                    <Nodes>
                        <eo:TreeNode Text=".NET Framework Class Library"></eo:TreeNode>
                        <eo:TreeNode Text=".NET Framework SDK"></eo:TreeNode>
                        <eo:TreeNode Text="Articles and Overviews"></eo:TreeNode>
                    </Nodes>
                </SubGroup>
            </eo:TreeNode>
            <eo:TreeNode Text="Web Development"></eo:TreeNode>
            <eo:TreeNode Text="Win32 and COM Development"></eo:TreeNode>
            <eo:TreeNode Text="MSDN Library Archive"></eo:TreeNode>
        </Nodes>
    </TopGroup>
    <LookNodes>
        <eo:TreeNode DisabledStyle-CssText="background-color: transparent; border-right-style: none; padding-right: 2px; padding-left: 2px; padding-bottom: 2px; padding-top: 2px; border-top-style: none; border-left-style: none; border-bottom-style: none; color: gray"
            HoverStyle-CssText="background-color: #cccccc; border-right: #999999 1px solid; padding-right: 1px; border-top: #999999 1px solid; padding-top: 1px; border-left: #999999 1px solid; padding-left: 1px; border-bottom: #999999 1px solid; padding-bottom: 1px;"
            ItemID="_Default" NormalStyle-CssText="background-color: transparent; border-right-style: none; padding-right: 2px; padding-left: 2px; padding-bottom: 2px; padding-top: 2px; border-top-style: none; border-left-style: none; border-bottom-style: none; color: black"
            SelectedStyle-CssText="border-right: #999999 1px solid; padding-right: 1px; border-top: #999999 1px solid; padding-left: 1px; padding-bottom: 1px; border-left: #999999 1px solid; padding-top: 1px; border-bottom: #999999 1px solid; background-color: white;"
            TextMargin="0">
            <SubGroup ItemSpacing="2"></SubGroup>
        </eo:TreeNode>
    </LookNodes>
</eo:TreeView>
</asp:Content>


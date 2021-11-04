<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TreeView_Designs_MS_Help_2_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:TreeView runat="server" id="TreeView1" AutoSelect="ItemClick" ControlSkinID="None" Width="200px"
    Height="250px">
    <TopGroup Style-CssText="border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:black;cursor:hand;font-family:Tahoma;font-size:8pt;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;">
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
        <eo:TreeNode DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;color:Gray;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
            ItemID="_Default" NormalStyle-CssText="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; COLOR: black; BORDER-TOP-STYLE: none; PADDING-TOP: 1px; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none"
            SelectedStyle-CssText="background-color:#316ac5;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:White;padding-bottom:0px;padding-left:0px;padding-right:0px;padding-top:0px;"></eo:TreeNode>
    </LookNodes>
</eo:TreeView>
</asp:Content>


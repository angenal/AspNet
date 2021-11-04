<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TreeView_Features_Auto_Wrap_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
    EO.Web TreeView can automatically wrap tree node text into multiple
    lines (instead of adding horizontal scrollbar). Setting <b>AutoWrap</b>
    to true to enable this feature.
    </p>
    <eo:TreeView runat="server" id="TreeView1" AutoSelectSource="ItemClick" 
        AutoWrap="True" ControlSkinID="None" Height="200px" Width="200px">
        <LineImages PlusMinusOnly="True" />
        <LookNodes>
            <eo:TreeNode CollapsedImageUrl="00030201" 
                DisabledStyle-CssText="padding: 2px; background-color:transparent; border-bottom-style:none; border-left-style:none; border-right-style:none; border-top-style:none; color:Gray;" 
                ExpandedImageUrl="00030202" ImageUrl="00030203" ItemID="_Default" 
                NormalStyle-CssText="padding: 2px; COLOR: black; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none" 
                SelectedStyle-CssText="padding: 1px; background-color:#316ac5; border-bottom-color:#999999; border-bottom-style:solid; border-bottom-width:1px; border-left-color:#999999; border-left-style:solid; border-left-width:1px; border-right-color:#999999; border-right-style:solid; border-right-width:1px; border-top-color:#999999; border-top-style:solid; border-top-width:1px; color:White;">
            </eo:TreeNode>
        </LookNodes>
        <TopGroup Style-CssText="border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:black;cursor:hand;font-family:Tahoma;font-size:8pt;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;">
            <Nodes>
                <eo:TreeNode Text="Windows Presentation Foundation">
                    <SubGroup>
                        <Nodes>
                            <eo:TreeNode Text="Introduction to Windows Presentation Foundation">
                            </eo:TreeNode>
                            <eo:TreeNode Text="Getting Started with Windows Presentation Foundation">
                            </eo:TreeNode>
                            <eo:TreeNode Text="Windows Presentation Foundation Community Feedback">
                            </eo:TreeNode>
                        </Nodes>
                    </SubGroup>
                </eo:TreeNode>
                <eo:TreeNode Text="Windows Communication Foundation ">
                </eo:TreeNode>
                <eo:TreeNode Text="Windows Workflow Foundation ">
                </eo:TreeNode>
                <eo:TreeNode Text="Windows CardSpace">
                </eo:TreeNode>
            </Nodes>
        </TopGroup>
    </eo:TreeView>
</asp:Content>


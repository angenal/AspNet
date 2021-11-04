<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TreeView_Designs_Outlook_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:TreeView runat="server" id="TreeView1" AutoSelect="ItemClick" ControlSkinID="None" Width="230px"
    Height="260px">
    <TopGroup Style-CssText="background-image:url('00030417');background-repeat:repeat-y;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:black;cursor:hand;font-family:Tahoma;font-size:11px;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;">
        <Nodes>
            <eo:TreeNode ImageUrl="00030406" Text="Personal Folders">
                <SubGroup>
                    <Nodes>
                        <eo:TreeNode ImageUrl="00030401" Text="Calendar"></eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030402" Text="Contacts"></eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030403" MarginImageUrl="00030411" Text="&lt;b&gt;Deleted Items&lt;/b&gt;&amp;nbsp;&lt;font color=&quot;blue&quot;&gt;(25)&lt;/font&gt;">
                            <SubGroup>
                                <Nodes>
                                    <eo:TreeNode Text="Today"></eo:TreeNode>
                                    <eo:TreeNode Text="Yesterday"></eo:TreeNode>
                                    <eo:TreeNode Text="Last Week"></eo:TreeNode>
                                </Nodes>
                            </SubGroup>
                        </eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030404" Text="&lt;b&gt;Drafts&lt;/b&gt;&amp;nbsp;&lt;font color=&quot;green&quot;&gt;(1)&lt;/font&gt;"></eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030408" MarginImageUrl="00030412" Text="&lt;b&gt;Inbox&lt;/b&gt;&amp;nbsp;&lt;font color=&quot;blue&quot;&gt;(3)&lt;/font&gt;">
                            <SubGroup>
                                <Nodes>
                                    <eo:TreeNode Text="Important"></eo:TreeNode>
                                    <eo:TreeNode Text="Personal"></eo:TreeNode>
                                    <eo:TreeNode Text="Support"></eo:TreeNode>
                                </Nodes>
                            </SubGroup>
                        </eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030409" Text="Journal"></eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030410" Text="Junk E-Mail"></eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030414" MarginImageUrl="00030413" Text="Notes"></eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030415" Text="Outbox"></eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030416" Text="Sent Items"></eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030418" Text="Tasks"></eo:TreeNode>
                    </Nodes>
                </SubGroup>
            </eo:TreeNode>
            <eo:TreeNode ImageUrl="00030407" Text="Archive Folders">
                <SubGroup>
                    <Nodes>
                        <eo:TreeNode ImageUrl="00030408" Text="Inbox"></eo:TreeNode>
                    </Nodes>
                </SubGroup>
            </eo:TreeNode>
        </Nodes>
    </TopGroup>
    <LookNodes>
        <eo:TreeNode ImageUrl="00030407" DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;color:Gray;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
            ItemID="_Default" NormalStyle-CssText="padding-right: 1px; padding-left: 1px; padding-bottom: 1px; color: black; border-top-style: none; padding-top: 1px; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none"
            SelectedStyle-CssText="background-color:Silver;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:white;padding-bottom:0px;padding-left:0px;padding-right:0px;padding-top:0px;"></eo:TreeNode>
    </LookNodes>
    <Margin BackgroundImageUrl="00030417" Width="24" Visible="True"></Margin>
</eo:TreeView>
</asp:Content>


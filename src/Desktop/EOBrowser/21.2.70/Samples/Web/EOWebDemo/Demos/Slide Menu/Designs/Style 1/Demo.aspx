<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Slide_Menu_Designs_Style_1_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:SlideMenu runat="server" ID="Slidemenu1" NAME="Slidemenu1" SingleExpand="False" ControlSkinID="None"
    Width="160px">
    <TopGroup Style-CssText="font-weight: bold; font-size: 12px; cursor: hand; color: #cccccc; font-family: verdana"
        ItemSpacing="1">
        <Items>
            <eo:MenuItem Text-Html="Category 1">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="Child Item 1"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Child Item 2"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Child Item 3"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem Text-Html="Category 2">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="Child Item 1"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Child Item 2"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Child Item 3"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem Text-Html="Category 3">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="Child Item 1"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Child Item 2"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Child Item 3"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem Height="22" HoverStyle-CssText="padding-left: 5px; color: white; background-color: #0066ff"
            ItemID="_TopLevelItem" NormalStyle-CssText="background-color:#3b3b3b;color:Lavender;padding-left:5px;"
            LeftIcon-Url="00020009" LeftIcon-ExpandedUrl="00020008">
            <SubMenu Style-CssText="font-family:Arial;font-size:12px;font-weight:bold;" ItemSpacing="1"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem Height="22" HoverStyle-CssText="padding-left: 15px; color: #0066ff; background-color: #cccccc"
            ItemID="_Default" NormalStyle-CssText="padding-left: 15px; color: white; background-color: #bbbbbb"></eo:MenuItem>
    </LookItems>
</eo:SlideMenu>
</asp:Content>


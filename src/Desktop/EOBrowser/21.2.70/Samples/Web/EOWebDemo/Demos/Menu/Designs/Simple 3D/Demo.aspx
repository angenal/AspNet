<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Designs_Simple_3D_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:Menu runat="server" id="Menu1" ControlSkinID="None" Width="500px">
    <TopGroup>
        <Items>
            <eo:MenuItem Text-Html="MSDN Home"></eo:MenuItem>
            <eo:MenuItem IsSeparator="True"></eo:MenuItem>
            <eo:MenuItem Text-Html="Library"></eo:MenuItem>
            <eo:MenuItem IsSeparator="True"></eo:MenuItem>
            <eo:MenuItem Text-Html="Download">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="Developer Download"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Subscriber Downloads"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Microsoft Download Center"></eo:MenuItem>
                        <eo:MenuItem LookID="h_separator" IsSeparator="True"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Security Updates"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem IsSeparator="True"></eo:MenuItem>
            <eo:MenuItem Text-Html="My MSDN"></eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="border-right: #6e7d8d 1px solid; border-top: #abc3dc 1px solid; margin: 2px; border-left: #abc3dc 1px solid; width: 1px; border-bottom: #6e7d8d 1px solid; height: 1px"></eo:MenuItem>
        <eo:MenuItem HoverStyle-CssText="border-right: #000f28 1px solid; padding-right: 4px; border-top: #587ea6 1px solid; padding-left: 4px; padding-bottom: 1px; border-left: #587ea6 1px solid; padding-top: 1px; border-bottom: #000f28 1px solid; background-color: #4f6276"
            ItemID="_Default" NormalStyle-CssText="padding-right: 5px; padding-left: 5px; padding-bottom: 2px; color: white; border-top-style: none; padding-top: 2px; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none"
            LeftIcon-Url="00020004">
            <SubMenu Style-CssText="background-color:#899cb0;border-bottom-color:#6e7d8d;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#abc3dc;border-left-style:solid;border-left-width:1px;border-right-color:#6e7d8d;border-right-style:solid;border-right-width:1px;border-top-color:#abc3dc;border-top-style:solid;border-top-width:1px;color:White;cursor:hand;font-family:Arial;font-size:9pt;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;"
                ItemSpacing="3"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem IsSeparator="True" ItemID="h_separator" NormalStyle-CssText="border-top: #6e7d8d 1px solid; border-bottom: #abc3dc 1px; background-color: #abc3dc"></eo:MenuItem>
    </LookItems>
</eo:Menu>
</asp:Content>


<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Designs_Style_3_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:Menu runat="server" id="Menu1" ControlSkinID="None" Width="300px">
    <TopGroup Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 10px; border-top: #cb3e00 2px solid; padding-left: 10px; font-size: 12px; background-image: url(00020005); padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #5f7786; padding-top: 3px; font-family: arial">
        <Items>
            <eo:MenuItem Text-Html="Home"></eo:MenuItem>
            <eo:MenuItem IsSeparator="True"></eo:MenuItem>
            <eo:MenuItem Text-Html="Services">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="Website Design"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Logo Design"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Stationary Design"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem IsSeparator="True"></eo:MenuItem>
            <eo:MenuItem Text-Html="Packages">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="Bronze Package"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Silver Package"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Gold Package"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Platinum Package"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem IsSeparator="True"></eo:MenuItem>
            <eo:MenuItem Text-Html="Company"></eo:MenuItem>
            <eo:MenuItem IsSeparator="True"></eo:MenuItem>
            <eo:MenuItem Text-Html="Support"></eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="width: 1px; height: 1px; background-color: #cb3e00"></eo:MenuItem>
        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_Default"
            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
            <SubMenu Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #5f7786; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                OffsetX="-3" ShadowDepth="0" OffsetY="3" ItemSpacing="5"></SubMenu>
        </eo:MenuItem>
    </LookItems>
</eo:Menu>
</asp:Content>


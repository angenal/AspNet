<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Designs_MSDN_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:Menu runat="server" id="Menu1" ControlSkinID="None" Width="360px">
    <TopGroup>
        <Items>
            <eo:MenuItem Text-Html="MSDN Home"></eo:MenuItem>
            <eo:MenuItem Text-Html="Library"></eo:MenuItem>
            <eo:MenuItem Text-Html="Download">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="Developer Downloads"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Subscriber Downloads"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Microsoft Download Center"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem Text-Html="My MSDN"></eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="width: 1px; height: 1px; background-color: gray; margin: 2px"></eo:MenuItem>
        <eo:MenuItem DisabledStyle-CssText="background-color: transparent; border-right-style: none; padding-right: 5px; padding-left: 5px; padding-bottom: 2px; padding-top: 2px; border-top-style: none; border-left-style: none; border-bottom-style: none; color: gray"
            HoverStyle-CssText="background-color: #cccccc; border-right: #999999 1px solid; padding-right: 4px; border-top: #999999 1px solid; padding-top: 1px; border-left: #999999 1px solid; padding-left: 4px; border-bottom: #999999 1px solid; padding-bottom: 1px; "
            ItemID="_Default" NormalStyle-CssText="background-color: transparent; border-right-style: none; padding-right: 5px; padding-left: 5px; padding-bottom: 2px; padding-top: 2px; border-top-style: none; border-left-style: none; border-bottom-style: none; color: black"
            SelectedStyle-CssText="BORDER-RIGHT: #999999 1px solid; PADDING-RIGHT: 4px; BORDER-TOP: #999999 1px solid; PADDING-LEFT: 4px; PADDING-BOTTOM: 1px; BORDER-LEFT: #999999 1px solid; PADDING-TOP: 1px; BORDER-BOTTOM: #999999 1px solid; BACKGROUND-COLOR: white; ">
            <SubMenu Style-CssText="font-size: 9pt; font-family: Verdana; color: black; cursor: hand; background-color: #f1f1f1; border-right: #999999 1px solid; border-top: #999999 1px solid; border-left: #999999 1px solid; border-bottom: #999999 1px solid; padding-right: 2px; padding-left: 2px; padding-bottom: 2px; padding-top: 2px"
                LeftIconCellWidth="12" ItemSpacing="3"></SubMenu>
        </eo:MenuItem>
    </LookItems>
</eo:Menu>
</asp:Content>


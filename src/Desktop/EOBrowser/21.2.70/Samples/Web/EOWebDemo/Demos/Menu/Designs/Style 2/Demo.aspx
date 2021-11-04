<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Designs_Style_2_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:Menu runat="server" id="Menu1" ControlSkinID="None" Width="150px">
    <TopGroup Style-CssText="cursor: hand; border-bottom: black 1px solid;font-weight: bold; font-size: 11px; font-family: verdana;"
        Orientation="Vertical">
        <Items>
            <eo:MenuItem Text-Html="FOR RESIDENTS">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="Community Services"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Education"></eo:MenuItem>
                        <eo:MenuItem Text-Html="History"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Points of Interest"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Special Events"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Demographics"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem Text-Html="FOR BUSINESS"></eo:MenuItem>
            <eo:MenuItem Text-Html="SPECIAL EVENTS"></eo:MenuItem>
            <eo:MenuItem Text-Html="RESOURCES"></eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem HoverStyle-CssText="border-right: black 1px solid; padding-right: 3px; border-top: black 1px solid; padding-left: 3px; padding-bottom: 3px; border-left: black 1px solid; color: black; padding-top: 3px; border-bottom: #758b5c 1px; background-color: #967d67"
            ItemID="_TopLevelItem" NormalStyle-CssText="border-right: black 1px solid; padding-right: 3px; border-top: black 1px solid; padding-left: 3px; padding-bottom: 3px; border-left: black 1px solid; color: white; padding-top: 3px; border-bottom: #758b5c 1px; background-color: #758b5c"
            LeftIcon-Url="00020004">
            <SubMenu Style-CssText="cursor: hand; border-bottom: black 1px solid;font-weight: bold; font-size: 11px; font-family: verdana;"
                OffsetX="-1"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem HoverStyle-CssText="border-right: black 1px solid; padding-right: 3px; border-top: black 1px solid; padding-left: 3px; padding-bottom: 3px; border-left: black 1px solid; color: black; padding-top: 3px; border-bottom: #758b5c 1px; background-color: #967d67"
            ItemID="_Default" NormalStyle-CssText="border-right: black 1px solid; padding-right: 3px; border-top: black 1px solid; padding-left: 3px; padding-bottom: 3px; border-left: black 1px solid; color: white; padding-top: 3px; border-bottom: #758b5c 1px; background-color: #758b5c"
            LeftIcon-Url="00020004">
            <SubMenu Style-CssText="cursor: hand; border-bottom: black 1px solid;font-weight: bold; font-size: 11px; font-family: verdana;"
                OffsetX="-1"></SubMenu>
        </eo:MenuItem>
    </LookItems>
</eo:Menu>
</asp:Content>


<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TabStrip_and_MultiPage_Designs_Style_2_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:TabStrip runat="server" id="TabStrip1" ControlSkinID="None" Width="400px">
    <TopGroup>
        <Items>
            <eo:TabItem Text-Html="Themes">
                <SubGroup>
                    <Items>
                        <eo:TabItem Text-Html="Winows XP"></eo:TabItem>
                        <eo:TabItem Text-Html="Windows Classic"></eo:TabItem>
                    </Items>
                </SubGroup>
            </eo:TabItem>
            <eo:TabItem Text-Html="Desktop">
                <SubGroup>
                    <Items>
                        <eo:TabItem Text-Html="Background"></eo:TabItem>
                        <eo:TabItem Text-Html="Customize"></eo:TabItem>
                    </Items>
                </SubGroup>
            </eo:TabItem>
            <eo:TabItem Text-Html="Screen Saver">
                <SubGroup>
                    <Items>
                        <eo:TabItem Text-Html="None"></eo:TabItem>
                        <eo:TabItem Text-Html="3D Text"></eo:TabItem>
                    </Items>
                </SubGroup>
            </eo:TabItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:TabItem ItemID="_TopGroup">
            <SubGroup Style-CssText="background-image:url(00010220);background-repeat:repeat-x;cursor:hand;font-family:tahoma;font-size:8pt;"
                OverlapDepth="8"></SubGroup>
        </eo:TabItem>
        <eo:TabItem ItemID="_TopLevelItem" RightIcon-Url="00010223" RightIcon-SelectedUrl="00010226"
            NormalStyle-CssText="color: #606060" SelectedStyle-CssText="color:#2f4761;font-weight:bold;"
            LeftIcon-Url="00010221" LeftIcon-SelectedUrl="00010224" Image-Url="00010222" Image-SelectedUrl="00010225"
            Image-Mode="TextBackground" Image-BackgroundRepeat="RepeatX">
            <SubGroup Style-CssText="background-image:url(00010220);background-position-y:bottom;background-repeat:repeat-x;cursor:hand;font-family:tahoma;font-size:8pt;padding-bottom:4px;padding-left:5px;padding-right:5px;padding-top:4px;"
                ItemSpacing="5"></SubGroup>
        </eo:TabItem>
        <eo:TabItem HoverStyle-CssText="color:#2f4761;text-decoration:underline;" ItemID="_Default"
            NormalStyle-CssText="color: #606060; text-decoration: none" SelectedStyle-CssText="color:#2f4761;font-weight:bold;">
            <SubGroup Style-CssText="background-image:url(00010220);background-position-y:bottom;background-repeat:repeat-x;cursor:hand;font-family:tahoma;font-size:8pt;padding-bottom:4px;padding-left:5px;padding-right:5px;padding-top:4px;"
                ItemSpacing="5"></SubGroup>
        </eo:TabItem>
    </LookItems>
</eo:TabStrip>
</asp:Content>


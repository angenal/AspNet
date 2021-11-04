<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TabStrip_and_MultiPage_Designs_Visual_Studio_2005_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:TabStrip runat="server" id="TabStrip1" ControlSkinID="None" Width="400px" MultiPageID="MultiPage1">
    <DesignOptions BackColor="239, 235, 222"></DesignOptions>
    <TopGroup>
        <Items>
            <eo:TabItem Text-Html="Themes"></eo:TabItem>
            <eo:TabItem Text-Html="Desktop"></eo:TabItem>
            <eo:TabItem Text-Html="Screen Saver"></eo:TabItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:TabItem ItemID="_Default" RightIcon-Url="00010203" RightIcon-SelectedUrl="00010206" LeftIcon-Url="00010201"
            LeftIcon-SelectedUrl="00010204" Image-Url="00010202" Image-SelectedUrl="00010205" Image-Mode="TextBackground"
            Image-BackgroundRepeat="RepeatX">
            <SubGroup Style-CssText="font-family: tahoma; font-size: 8pt; background-image: url(00010200); background-repeat: repeat-x; cursor: hand;"
                OverlapDepth="8"></SubGroup>
        </eo:TabItem>
    </LookItems>
</eo:TabStrip>
<div style="BORDER-RIGHT: #7f9db9 1px solid; BORDER-LEFT: #7f9db9 1px solid; WIDTH: 388px; BORDER-BOTTOM: #7f9db9 1px solid; HEIGHT: 300px; padding: 5px; 5px; 5px; 5px;">
    <eo:MultiPage runat="server" id="MultiPage1">
        <eo:PageView id="PageView1" runat="server">Page 1 
        </eo:PageView>
        <eo:PageView id="Pageview2" runat="server">Page 2 
        </eo:PageView>
        <eo:PageView id="Pageview3" runat="server">Page 3 
        </eo:PageView>
    </eo:MultiPage>
</div>
</asp:Content>


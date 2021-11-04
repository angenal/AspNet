<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TabStrip_and_MultiPage_Designs_Style_1_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:TabStrip runat="server" id="TabStrip1" ControlSkinID="None" Width="400px">
    <TopGroup>
        <Items>
            <eo:TabItem Text-Html="Themes"></eo:TabItem>
            <eo:TabItem Text-Html="Desktop"></eo:TabItem>
            <eo:TabItem Text-Html="Screen Saver"></eo:TabItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:TabItem ItemID="_Default" RightIcon-Url="00010223" RightIcon-SelectedUrl="00010226" NormalStyle-CssText="color: #606060"
            SelectedStyle-CssText="color: #2f4761; font-weight: bold;" LeftIcon-Url="00010221" LeftIcon-SelectedUrl="00010224"
            Image-Url="00010222" Image-SelectedUrl="00010225" Image-Mode="TextBackground" Image-BackgroundRepeat="RepeatX">
            <SubGroup Style-CssText="font-family: tahoma; font-size: 8pt; background-image: url(00010220); background-repeat: repeat-x; cursor: hand;"
                OverlapDepth="8"></SubGroup>
        </eo:TabItem>
    </LookItems>
</eo:TabStrip>
<div style="BORDER-RIGHT: #c9c9c9 1px solid; PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; BORDER-LEFT: #c9c9c9 1px solid; WIDTH: 388px; PADDING-TOP: 5px; BORDER-BOTTOM: #c9c9c9 1px solid; HEIGHT: 300px; 5px: ">
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


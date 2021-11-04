<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TabStrip_and_MultiPage_Designs_Windows_2000_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:TabStrip runat="server" id="TabStrip1" ControlSkinID="None" Width="400px" MultiPageID="MultiPage1">
    <DesignOptions BackColor="212, 208, 200"></DesignOptions>
    <TopGroup>
        <Items>
            <eo:TabItem Text-Html="Themes"></eo:TabItem>
            <eo:TabItem Text-Html="Desktop"></eo:TabItem>
            <eo:TabItem Text-Html="Screen Saver"></eo:TabItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:TabItem Height="21" ItemID="_Default" RightIcon-Url="00010303" RightIcon-SelectedUrl="00010306"
            NormalStyle-CssText="position: relative; top: 2px;" SelectedStyle-CssText="position: relative; top: 0px"
            LeftIcon-Url="00010301" LeftIcon-SelectedUrl="00010304" Image-Url="00010302" Image-SelectedUrl="00010305"
            Image-Mode="TextBackground" Image-BackgroundRepeat="RepeatX" Text-Padding-Top="3">
            <SubGroup Style-CssText="font-family: tahoma; font-size: 8pt; background-image: url(00010300); background-repeat: repeat-x; cursor: hand;"></SubGroup>
        </eo:TabItem>
    </LookItems>
</eo:TabStrip>
<div style="BORDER-RIGHT: white 1px solid; PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; BORDER-LEFT: white 1px solid; WIDTH: 388px; PADDING-TOP: 5px; BORDER-BOTTOM: #808080 1px solid; HEIGHT: 300px; BACKGROUND-COLOR: #d4d0c8; 5px: ">
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


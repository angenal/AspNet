<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TabStrip_and_MultiPage_Designs_Style_3_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:TabStrip runat="server" id="TabStrip1" ControlSkinID="None" Width="400px" MultiPageID="MultiPage1">
    <TopGroup>
        <Items>
            <eo:TabItem Text-Html="Themes"></eo:TabItem>
            <eo:TabItem Text-Html="Desktop"></eo:TabItem>
            <eo:TabItem Text-Html="Screen Saver"></eo:TabItem>
            <eo:TabItem Text-Html="Appearance"></eo:TabItem>
            <eo:TabItem Text-Html="Settings"></eo:TabItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:TabItem Height="21" ItemID="_Default" RightIcon-Url="00010606" RightIcon-SelectedUrl="00010607"
            NormalStyle-CssText="background-image: url(00010602); background-repeat: repeat-x; font-weight: normal; color: black;"
            SelectedStyle-CssText="background-image: url(00010603); background-repeat: repeat-x; font-weight: bold; color: #ff7e00;"
            LeftIcon-Url="00010604" LeftIcon-SelectedUrl="00010605" Text-Padding-Top="1" Text-Padding-Bottom="2">
            <SubGroup Style-CssText="background-image:url(00010601);background-position-y:bottom;background-repeat:repeat-x;color:black;cursor:hand;font-family:Verdana;font-size:12px;"
                ItemSpacing="1"></SubGroup>
        </eo:TabItem>
    </LookItems>
</eo:TabStrip>
<div style="BORDER-RIGHT: #b0b0b0 1px solid; PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; BORDER-LEFT: #b0b0b0 1px solid; WIDTH: 388px; PADDING-TOP: 5px; BORDER-BOTTOM: #b0b0b0 1px solid; HEIGHT: 300px; 5px: ">
    <eo:MultiPage runat="server" id="MultiPage1">
        <eo:PageView id="PageView1" runat="server">Page 1 
</eo:PageView>
        <eo:PageView id="Pageview2" runat="server">Page 2 
</eo:PageView>
        <eo:PageView id="Pageview3" runat="server">Page 3 
</eo:PageView>
        <eo:PageView id="Pageview4" runat="server">Page 4 
</eo:PageView>
        <eo:PageView id="Pageview5" runat="server">Page 5 
</eo:PageView>
    </eo:MultiPage>
</div>
</asp:Content>


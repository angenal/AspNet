<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TabStrip_and_MultiPage_Designs_Windows_XP_Multi_Row_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:TabStrip runat="server" id="TabStrip1" RowSpacing="-3" ControlSkinID="None" Width="400px"
    MultiRow="True" MultiPageID="MultiPage1">
    <TopGroup>
        <Items>
            <eo:TabItem Width="120" Text-Html="General"></eo:TabItem>
            <eo:TabItem Width="153" Text-Html="Computer Name"></eo:TabItem>
            <eo:TabItem Width="124" Text-Html="Hardware"></eo:TabItem>
            <eo:TabItem Width="124" Text-Html="Advanced"></eo:TabItem>
            <eo:TabItem Width="163" Text-Html="Automatic Updates"></eo:TabItem>
            <eo:TabItem Width="110" Text-Html="Remote"></eo:TabItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:TabItem Height="21" HoverStyle-CssText="position: relative; top: 2px; background-image: url(00010002); background-repeat: repeat-x"
            ItemID="_Default" RightIcon-Url="00010005" RightIcon-SelectedUrl="00010009" RightIcon-HoverUrl="00010007"
            NormalStyle-CssText="position: relative; top: 2px; background-image: url(00010001); background-repeat: repeat-x"
            SelectedStyle-CssText="background-image: url(00010003); background-repeat: repeat-x" LeftIcon-Url="00010004"
            LeftIcon-SelectedUrl="00010008" LeftIcon-HoverUrl="00010006" Text-Padding-Top="1" Text-Padding-Bottom="2">
            <SubGroup Style-CssText="background-image:url(00010000);background-position-y:bottom;background-repeat:repeat-x;color:black;cursor:hand;font-family:'Microsoft Sans Serif', Verdana;font-size:8.25pt;"
                ItemSpacing="1"></SubGroup>
        </eo:TabItem>
    </LookItems>
</eo:TabStrip>
<div style="BORDER-RIGHT: #949a9c 1px solid; PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; BORDER-LEFT: #949a9c 1px solid; WIDTH: 388px; PADDING-TOP: 5px; BORDER-BOTTOM: #949a9c 1px solid; HEIGHT: 300px; 5px: ">
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
        <eo:PageView id="Pageview6" runat="server">Page 6 
</eo:PageView>
    </eo:MultiPage>
</div>
</asp:Content>


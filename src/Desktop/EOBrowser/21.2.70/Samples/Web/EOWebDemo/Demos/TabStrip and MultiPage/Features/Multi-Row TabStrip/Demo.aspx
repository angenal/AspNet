<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TabStrip_and_MultiPage_Features_Multi_Row_TabStrip_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web TabStrip can automatically wrap into multi-rows. To do so, simply set 
    the TabStrip's <span class="highlight">MultiRow</span> property to true and 
    give the TabStrip a fixed with.
</p>
<p>
    The following sample demonstrates a multi-row TabStrip.
</p>
<p>
</p>
<eo:TabStrip runat="server" id="TabStrip1" ControlSkinID="None" Width="400px" RowSpacing="-3"
    MultiRow="True">
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
        <eo:TabItem Height="21" HoverStyle-CssText="position: relative; top: 2px; background-image: url(00010402); background-repeat: repeat-x"
            ItemID="_Default" RightIcon-Url="00010405" RightIcon-SelectedUrl="00010409" RightIcon-HoverUrl="00010407"
            NormalStyle-CssText="position: relative; top: 2px; background-image: url(00010401); background-repeat: repeat-x"
            SelectedStyle-CssText="background-image: url(00010403); background-repeat: repeat-x" LeftIcon-Url="00010404"
            LeftIcon-SelectedUrl="00010408" LeftIcon-HoverUrl="00010406" Text-Padding-Top="1" Text-Padding-Bottom="2">
            <SubGroup Style-CssText="background-image:url(00010410);background-position-y:bottom;background-repeat:repeat-x;color:black;cursor:hand;font-family:'Microsoft Sans Serif',Verdana;font-size:8.25pt;"
                ItemSpacing="1"></SubGroup>
        </eo:TabItem>
    </LookItems>
</eo:TabStrip>
</asp:Content>


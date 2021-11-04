<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TabStrip_and_MultiPage_Features_Scrolling_TabStrip_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web TabStrip supports automatic scrolling. To enable scrolling, simply set 
    the TabStrip's <span class="highlight">EnableScrolling</span> to true and give 
    the TabStrip a fixed width.
</p>
<p>
    You can optionally customize the scrolling by:
</p>
<ol>
    <li>
        using <span class="highlight">ScrollUpLookID</span> and <span class="highlight">ScrollDownLookID</span>
    to customize the scrolling item's look;
    <li>
        Using <span class="highlight">ScrollSpeed</span> to customize the scrolling 
        speed;</li>
</ol>
<eo:TabStrip runat="server" id="TabStrip1" ControlSkinID="None" EnableScrolling="True" Width="400px"
    ScrollDownLookID="scroll_down" ScrollUpLookID="scroll_up">
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
            NormalStyle-CssText="background-image:url(00010602);background-repeat:repeat-x;color:black;font-weight:normal;"
            SelectedStyle-CssText="background-image:url(00010603);background-repeat:repeat-x;color:#ff7e00;font-weight:bold;"
            LeftIcon-Url="00010604" LeftIcon-SelectedUrl="00010605" Text-Padding-Left="15" Text-Padding-Top="1"
            Text-Padding-Right="15" Text-Padding-Bottom="2">
            <SubGroup Style-CssText="background-image:url(00010601);background-position-y:bottom;background-repeat:repeat-x;color:black;cursor:hand;font-family:Verdana;font-size:12px;"
                ItemSpacing="1"></SubGroup>
        </eo:TabItem>
        <eo:TabItem Height="16" ItemID="scroll_down" RightIcon-Url="" NormalStyle-CssText="background-color:#F4F4FE;border-bottom-color:Gray;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Gray;border-left-style:solid;border-left-width:1px;border-right-color:Gray;border-right-style:solid;border-right-width:1px;border-top-color:Gray;border-top-style:solid;border-top-width:1px;"
            Width="16" SelectedStyle-CssText="" LeftIcon-Url="" Image-Url="00020003" Text-Padding-Left="15"
            Text-Padding-Top="1" Text-Padding-Right="15" Text-Padding-Bottom="2">
            <SubGroup Style-CssText="background-image:url(00010601);background-position-y:bottom;background-repeat:repeat-x;color:black;cursor:hand;font-family:Verdana;font-size:12px;"
                ItemSpacing="1"></SubGroup>
        </eo:TabItem>
        <eo:TabItem Height="16" ItemID="scroll_up" RightIcon-Url="" NormalStyle-CssText="background-color:#F4F4FE;border-bottom-color:gray;border-bottom-style:solid;border-bottom-width:1px;border-left-color:gray;border-left-style:solid;border-left-width:1px;border-right-color:gray;border-right-style:solid;border-right-width:1px;border-top-color:gray;border-top-style:solid;border-top-width:1px;"
            Width="16" SelectedStyle-CssText="" LeftIcon-Url="" Image-Url="00020002" Text-Padding-Left="15"
            Text-Padding-Top="1" Text-Padding-Right="15" Text-Padding-Bottom="2">
            <SubGroup Style-CssText="background-image:url(00010601);background-position-y:bottom;background-repeat:repeat-x;color:black;cursor:hand;font-family:Verdana;font-size:12px;"
                ItemSpacing="1"></SubGroup>
        </eo:TabItem>
    </LookItems>
</eo:TabStrip>
</asp:Content>


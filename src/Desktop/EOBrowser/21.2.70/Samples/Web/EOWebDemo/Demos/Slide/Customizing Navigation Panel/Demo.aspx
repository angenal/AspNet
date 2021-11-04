<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Slide_Customizing_Navigation_Panel_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <style type="text/css">
        .slide_big_item_panel
        {
            background-color:#f6f7f6;
            border-left: solid 1px #d7d4d4;
            border-right: solid 1px #d7d4d4;
            border-bottom: solid 1px #d7d4d4;
            padding: 10px;            
        }
        .slide_nav_panel
        {
            background-image: url('<%=ResolveUrl("../images/nav_bg1.gif")%>');
            background-repeat:no-repeat;
            padding: 10px;            
            height: 10px;            
        }
        
        .slide_item_number
        {
            font-size:14px;
            line-height:22px;
        }
    </style>
    <p>
    This sample uses custom <b>NavPanelStyle</b>, <b>ScrollLeftImageUrl</b>
    and <b>ScrollRightImageUrl</b> to create a custom look navigation panel. 
    It also sets <b>NavPanelOnTop</b> to true to position the navigation panel
    at the top. By default, the navigation panel is at the bottom of the slide.
    </p>
    <eo:Slide runat="server" ID="Slide1" 
        NavPanelOnTop="true"
        NavPanelStyle="slide_nav_panel" ItemNumberStyle="slide_item_number"
        BigItemWidth="200" BigItemHeight="200" 
        BigItemPanelStyle="slide_big_item_panel"
        ScrollLeftImageUrl="~/Demos/Slide/Images/left.gif"
        ScrollRightImageUrl="~/Demos/Slide/Images/right.gif"
        ItemNumberFormat="Dollar Menu">
        <BigItemTemplate>
            <div class="slide_img_panel">
                <img src="<%#ResolveUrl(Container.DataItem.ToString())%>" />
            </div>
        </BigItemTemplate>
    </eo:Slide>
</asp:Content>


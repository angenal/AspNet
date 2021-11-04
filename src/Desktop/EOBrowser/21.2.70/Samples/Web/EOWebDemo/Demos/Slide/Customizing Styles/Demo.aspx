<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Slide_Customizing_Styles_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <style type="text/css">
        .slide_big_item_panel
        {
            background-color:#f6f7f6;
            border-top: solid 1px #d7d4d4;
            border-left: solid 1px #d7d4d4;
            border-right: solid 1px #d7d4d4;
            padding: 10px;            
        }
        .slide_nav_panel
        {
            background-color:#f6f7f6;
            border-bottom: solid 1px #d7d4d4;
            border-left: solid 1px #d7d4d4;
            border-right: solid 1px #d7d4d4;
            padding: 10px;            
            height: 15px;
        }
        .slide_item_number
        {
            font-family: Arial;
            font-size: 12px;
            color: #6c717a;
        }
    </style>
    <p>
        The style of the Slide control is fully customizable. Uses
        these properties to customize the style of the Slide control:
    </p>
    <ul>
        <li>
            <b>BigItemWidth</b>, <b>BigItemHeight</b> and <b>BigItemPanelStyle</b>
            for big item section;
        </li>
        <li>
            <b>SmallItemWidth</b>, <b>SmallItemHeight</b>, <b>SmallItemPanelStyle</b>,
            <b>SmallItemStyle</b> and <b>SmallItemHoverStyle</b> for small item section
            and small items;
        </li>
        <li>
            <b>NavPanelStyle</b>, <b>ItemNumberStyle</b>, <b>ScrollLeftImageUrl</b> and
            <b>ScrollRightImageUrl</b> for navigation panel;
        </li>
    </ul>
    <eo:Slide runat="server" ID="Slide1" 
        NavPanelStyle="slide_nav_panel" ItemNumberStyle="slide_item_number"
        BigItemWidth="200" BigItemHeight="200" 
        BigItemPanelStyle="slide_big_item_panel"
        ScrollLeftImageUrl="~/Demos/Slide/Images/left.gif"
        ScrollRightImageUrl="~/Demos/Slide/Images/right.gif"
        ItemNumberFormat="">
        <BigItemTemplate>
            <div class="slide_img_panel">
                <img src="<%#ResolveUrl(Container.DataItem.ToString())%>" />
            </div>
        </BigItemTemplate>
    </eo:Slide>
</asp:Content>


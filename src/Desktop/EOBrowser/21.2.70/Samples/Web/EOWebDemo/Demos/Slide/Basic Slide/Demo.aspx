<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Slide_Basic_Slide_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <style type="text/css">
        .slide_big_item_panel
        {
            border-top: solid 1px #dbe1e6;
            border-left: solid 1px #dbe1e6;
            border-right: solid 1px #dbe1e6;
            padding: 2px;
        }
        .slide_nav_panel
        {
            background-color: #f9fafa;
            padding: 3px 5px 3px 5px;
            border: solid 1px #dbe1e6;
        }
        .slide_item_number
        {
            font-family: Arial;
            font-size: 12px;
            color: #6c717a;
        }
    </style>
    <p>
        A Slide is divided into three sections:
    </p>
    <ul>
        <li>An optional <b>big item</b> section on the top; </li>
        <li>An optional <b>small items</b> section below the big item; </li>
        <li>A <b>navigation panel</b> section at the bottom; </li>
    </ul>
    <p>
        This sample demonstrates a simple slide that contains the <b>big item</b> section
        and <b>navigation panel</b>. In this sample, the <b>big item</b> section contains
        a single image only.
    </p>
    <p>
        Note: <b>BigItemWidth</b> and <b>BigItemHeight</b> must be correctly set
        in order for the big item section to scroll correctly.
    </p>
    <p>
        Click the next/previous button to see it action.
    </p>
    <eo:Slide runat="server" ID="Slide1" 
        NavPanelStyle="slide_nav_panel" ItemNumberStyle="slide_item_number"
        BigItemWidth="500" BigItemHeight="250" 
        BigItemPanelStyle="slide_big_item_panel">
        <BigItemTemplate>
            <div class="slide_img_panel">
                <img src="<%#ResolveUrl(Container.DataItem.ToString())%>" />
            </div>
        </BigItemTemplate>
    </eo:Slide>
</asp:Content>

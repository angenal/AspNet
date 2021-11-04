<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Slide_Thumbnails_Only_Demo" %>
<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <style type="text/css">
        .slide_big_item_panel
        {
            border-top: solid 1px #dbe1e6;
            border-left: solid 1px #dbe1e6;
            border-right: solid 1px #dbe1e6;
            padding: 2px;
        }
        .slide_small_item_panel
        {
            background-image: url('../images/small_item_bg2.gif');
            background-repeat: repeat-x;
            border-left: solid 1px #dbe1e6;
            border-right: solid 1px #dbe1e6;
            cursor: pointer;
            cursor: hand;
        }
        .slide_nav_panel
        {
            background-color: #f9fafa;
            padding: 3px 5px 3px 5px;
            border: solid 1px #dbe1e6;
        }
        .slide_small_item a
        {
            color: #16387c;
            text-decoration:none;
        }
        .slide_small_item_hover
        {
            background-image: url('../images/small_item_bgh2.gif');
            color: White;
        }
        .slide_small_item_hover a
        {
            color: White;
            text-decoration:underline;
        }
        .slide_item_number
        {
            font-family: Arial;
            font-size: 12px;
            color: #6c717a;
        }
    </style>
    <p>
        This sample uses <b>SmallItemTemplate</b> only to display a list of
        small items. Note that this sample uses different background image
        in <b>SmallItemStyle</b> and <b>SmallItemHoverStyle</b> so that
        highlighted item does not have the tip on top.
    </p>
    <eo:Slide runat="server" ID="Slide1" NavPanelStyle="slide_nav_panel" ItemNumberStyle="slide_item_number"        
        SmallItemHeight="125" SmallItemWidth="132" SmallItemPanelStyle="slide_small_item_panel"
        SmallItemStyle="slide_small_item" SmallItemHoverStyle="slide_small_item_hover">
        <SmallItemTemplate>
            <div style="padding: 15px 3px 3px 3px; text-align: center">
                <div style="border: solid 1px #c5ced7; padding: 2px; background-color:White; width:120px;">
                    <img src='<%#ResolveUrl(Eval("thumbnail").ToString())%>' />
                </div>
                <p>
                    <a href="http://www.essentialobjects.com"><%#Eval("link_text")%></a>                    
                </p>
            </div>
        </SmallItemTemplate>
    </eo:Slide>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Slide_Slide_with_Thumbnails_Demo" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
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
            background-image: url('../images/small_item_bg.gif');
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
            background-image: url('../images/small_item_bgh.gif');
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
        This sample is based on the <a href="javascript:GoToDemo('templated_slide')">templated slide</a>
        sample. 
    </p>
    <p>
        <b>SmallItemTemplate</b> is used to define contents of each thumbnail item.
        In addition, <b>SmallItemHeight</b>, <b>SmallItemWidth</b>,
        <b>SmallItemStyle</b> and <b>SmallItemHoverStyle</b> are used to define
        the size and style for the small items.
    </p>
    <eo:Slide runat="server" ID="Slide1" NavPanelStyle="slide_nav_panel" ItemNumberStyle="slide_item_number"
        BigItemWidth="500" BigItemHeight="330" BigItemPanelStyle="slide_big_item_panel"
        SmallItemHeight="130" SmallItemWidth="132" SmallItemPanelStyle="slide_small_item_panel"
        SmallItemStyle="slide_small_item" SmallItemHoverStyle="slide_small_item_hover">
        <BigItemTemplate>
            <div>
                <img src='<%#ResolveUrl(Eval("image").ToString())%>' />
            </div>
            <div style="padding: 5px 5px 0px 5px;">
                <p style="font-family: Arial; font-size: 17px; color: #16387c; font-weight: bold">
                    <%#Eval("title")%>
                </p>
                <p style="font-family: Arial; font-size: 13px; color: #333">
                    <%#Eval("summary")%>
                </p>
            </div>
        </BigItemTemplate>
        <SmallItemTemplate>
            <div style="padding: 15px 3px 3px 3px; text-align: center">
                <div style="border: solid 1px #c5ced7; padding: 2px; background-color:White; width:120px">
                    <img src='<%#ResolveUrl(Eval("thumbnail").ToString())%>' />
                </div>
                <p>
                    <a href="http://www.essentialobjects.com"><%#Eval("link_text")%></a>                    
                </p>
            </div>
        </SmallItemTemplate>
    </eo:Slide>
</asp:Content>

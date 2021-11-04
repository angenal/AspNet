<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Slide_Client_Side_Event_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
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
    <script type="text/javascript">
        function done_scroll()
        {
            var slide = eo_GetObject("<%=Slide1.ClientID%>");
            var span = document.getElementById("spanCurIndex");
            span.innerHTML = "First Item Index: " + slide.getFirstItemIndex();
        }
    </script>
    <p>
    This sample handles the Slide's <b>ClientSideOnScroll</b> event to display
    the current first item index with JavaScript.
    </p>
    <eo:Slide runat="server" ID="Slide1" 
        NavPanelStyle="slide_nav_panel" ItemNumberStyle="slide_item_number"
        BigItemWidth="500" BigItemHeight="250" 
        BigItemPanelStyle="slide_big_item_panel" 
        ClientSideOnScroll="done_scroll">
        <BigItemTemplate>
            <div class="slide_img_panel">
                <img src="<%#ResolveUrl(Container.DataItem.ToString())%>" />
            </div>
        </BigItemTemplate>
    </eo:Slide>
    <p>
        <span id="spanCurIndex"></span>
    </p>
</asp:Content>


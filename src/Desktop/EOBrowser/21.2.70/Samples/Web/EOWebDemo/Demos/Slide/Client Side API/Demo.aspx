<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Slide_Client_Side_API_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <style type="text/css">
        .slide_nav_panel
        {
            display: none;
        }
    </style>

    <script type="text/javascript">
        function slideTo(index)
        {
            var slide = eo_GetObject("<%=Slide1.ClientID%>");
            slide.slideTo(index);
        }

        function slideLeft()
        {
            var slide = eo_GetObject("<%=Slide1.ClientID%>");
            slide.slide(false);
        }

        function slideRight()
        {
            var slide = eo_GetObject("<%=Slide1.ClientID%>");
            slide.slide(true);
        }

        function done_scroll()
        {
            var slide = eo_GetObject("<%=Slide1.ClientID%>");
            var span = document.getElementById("spanCurItem");
            span.innerHTML = (slide.getFirstItemIndex() + 1).toString() + " Of " + slide.getItemCount();
        }
    </script>

    <p>
        This sample uses the Slide control's client side JavaScript API to scroll
        the slide. Please refer to the documentation for all available functions.
    </p>
    <div style="border: solid 1px #dbe1e6; width:500px; padding: 2px">
        <div>
            <div style="float:right">
                <a href="javascript:slideLeft();"><img style="border:none" src="../images/left2.gif" /></a>
                <a href="javascript:slideRight();"><img style="border:none" src="../images/right2.gif" /></a>
            </div>
            <a href="javascript:slideTo(0);"><img style="border:none" src="../images/1.gif" /></a>
            <a href="javascript:slideTo(1);"><img style="border:none" src="../images/2.gif" /></a>
            <a href="javascript:slideTo(2);"><img style="border:none" src="../images/3.gif" /></a>
            <a href="javascript:slideTo(3);"><img style="border:none" src="../images/4.gif" /></a>
        </div>
        <eo:Slide runat="server" ID="Slide1" NavPanelStyle="slide_nav_panel" BigItemWidth="500"
            BigItemHeight="250" BigItemPanelStyle="slide_big_item_panel" ClientSideOnScroll="done_scroll">
            <BigItemTemplate>
                <div class="slide_img_panel">
                    <img src="<%#ResolveUrl(Container.DataItem.ToString())%>" />
                </div>
            </BigItemTemplate>
        </eo:Slide>
        <p>
            &nbsp;<span id="spanCurItem">1 Of 4</span>
        </p>
    </div>
</asp:Content>

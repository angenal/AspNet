<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Slide_Templated_Slide_Demo" %>

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
        This sample is based on the <a href="javascript:GoToDemo('basic_slide')">basic slide</a>
        sample. Please make sure you go over that sample first.
    </p>
    <p>
        Content in the "big item" is supplied through <b>BigItemTemplate</b> in a way similar
        to the <b>ItemTemplate</b> of the standard ASP.NET Repeater control. The following
        sample displays a title and summary text along with each picture.
    </p>
    <eo:Slide runat="server" ID="Slide1" NavPanelStyle="slide_nav_panel" ItemNumberStyle="slide_item_number"
        BigItemWidth="500" BigItemHeight="350" BigItemPanelStyle="slide_big_item_panel">
        <BigItemTemplate>
            <div>
                <img src='<%#ResolveUrl(Eval("image").ToString())%>' />
            </div>
            <div style="padding: 5px">
                <p style="font-family: Arial; font-size: 17px; color: #16387c; font-weight: bold">
                    <%#Eval("title")%>
                </p>
                <p style="font-family: Arial; font-size: 13px; color: #333">
                    <%#Eval("summary")%>&nbsp;<a href="http://www.essentialobjects.com">More...</a>
                </p>
            </div>
        </BigItemTemplate>
    </eo:Slide>
</asp:Content>

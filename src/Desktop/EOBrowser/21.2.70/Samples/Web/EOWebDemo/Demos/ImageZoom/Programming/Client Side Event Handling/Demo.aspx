<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ImageZoom_Programming_Client_Side_Event_Handling_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
function UpdateStatus(status)
{
    document.getElementById("status").innerHTML = status;
}

function before_zoomin()
{
    UpdateStatus("zooming in....");
}

function after_zoomin()
{
    UpdateStatus("zoomed in.");
}

function before_zoomout()
{
    UpdateStatus("zooming out...");
}

function after_zoomout()
{
    UpdateStatus("zoomed out.");
}
//<!--JS_SAMPLE_END-->
</script>
<p>
    EO.Web ImageZoom offers four client side events: <b>ClientSideBeforeZoomIn</b>, <b>ClientSideAfterZoomIn</b>,
    <b>ClientSideBeforeZoomOut</b>, <b>ClientSideAfterZoomOut</b>. The following 
    sample demonstrates how to handle these events.
</p>
<p>
    Click the image below and see the status changes.
</p>
<p>
    Current status:
    <span id="status"></span>
<P></P>
<p>
    <eo:ImageZoom runat="server" id="ImageZoom1" SmallImageUrl="../../Images/palm_tree_small.jpg"
        BigImageUrl="../../Images/palm_tree.jpg" Description="Palm Tree on the Beach" BackShadeColor="Blue"
        BackShadeOpacity="5" ClientSideAfterZoomIn="after_zoomin" ClientSideAfterZoomOut="after_zoomout"
        ClientSideBeforeZoomIn="before_zoomin" ClientSideBeforeZoomOut="before_zoomout"
        PositionX="Relative" PositionY="Relative" LoadingPanelID="loading">
        <ZoomPanelStyle CssText="background-color:#ffffff;border:solid #d0d0d0 1px;padding:5px;"></ZoomPanelStyle>
    </eo:ImageZoom>
    <div id="loading" style="display:none; border: solid 1px black; background-color:White; padding: 6px 20px 6px 20px">Loading...</div>
</p>
</asp:Content>


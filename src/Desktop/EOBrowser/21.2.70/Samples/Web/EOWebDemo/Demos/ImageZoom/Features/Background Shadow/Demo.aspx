<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ImageZoom_Features_Background_Shadow_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web ImageZoom can optionally displays a background shadow when zooming out. 
    Simply set the ImageZoom's <b>BackShadowColor</b> and <b>BackShadowOpacity</b> to 
    use this feature.
</p>
<p>
Click the following image to see it in action.
</p>
<p>
    <eo:ImageZoom runat="server" id="ImageZoom1" SmallImageUrl="../../Images/palm_tree_small.jpg"
        BigImageUrl="../../Images/palm_tree.jpg" Description="Palm Tree on the Beach" BackShadeColor="Blue"
        BackShadeOpacity="5" LoadingPanelID="loading">
        <ZoomPanelStyle CssText="background-color:#ffffff;border:solid #d0d0d0 1px;padding:5px;"></ZoomPanelStyle>
    </eo:ImageZoom>
    <div id="loading" style="display:none; border: solid 1px black; background-color:White; padding: 6px 20px 6px 20px">Loading...</div>
</p>
</asp:Content>


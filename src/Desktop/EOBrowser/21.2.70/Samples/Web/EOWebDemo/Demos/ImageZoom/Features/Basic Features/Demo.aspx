<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ImageZoom_Features_Basic_Features_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
To use EO.Web ImageZoom control, simply set the ImageZoom's 
<b>SmallImageUrl</b> and <b>BigImageUrl</b> property. You can
also optionally set the <b>Description</b> property.
</p>
<p>
Click the following image to see it in action.
</p>
<p>
    <eo:ImageZoom runat="server" id="ImageZoom1" SmallImageUrl="../../Images/palm_tree_small.jpg"
        BigImageUrl="../../Images/palm_tree.jpg" Description="Palm Tree on the Beach" LoadingPanelID="loading">
        <ZoomPanelStyle CssText="background-color:#ffffff;border:solid #d0d0d0 1px;padding:5px;"></ZoomPanelStyle>
    </eo:ImageZoom>
    <div id="loading" style="display:none; border: solid 1px black; background-color:White; padding: 6px 20px 6px 20px">Loading...</div>
</p>
</asp:Content>


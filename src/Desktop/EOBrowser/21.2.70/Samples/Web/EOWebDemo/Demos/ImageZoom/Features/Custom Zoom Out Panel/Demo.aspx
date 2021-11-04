<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ImageZoom_Features_Custom_Zoom_Out_Panel_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<p>
    The layout of the zoomed out panel can be customized through the ImageZoom 
    control's <b>ZoomPanelTemplate</b> property. The following sample uses this 
    property to display the description and additional information (date taken)
    on the top of the zoomed out image.
</p>
<p>
    <eo:ImageZoom runat="server" id="ImageZoom1" SmallImageUrl="../../Images/palm_tree_small.jpg"
        BigImageUrl="../../Images/palm_tree.jpg" Description="Palm Tree on the Beach" LoadingPanelID="loading">
        <ZoomPanelTemplate>
            <table>
                <tr>
                    <td>Image:</td>
                    <td>{var:description}</td>
                </tr>
                <tr>
                    <td>Date Taken:</td>
                    <td>09/10/2008</td>
                </tr>
                <tr>
                    <td colspan="2">{var:big_image}</td>
                </tr>
            </table>
        </ZoomPanelTemplate>
        <ZoomPanelStyle CssText="background-color:#ffffff;border:solid #d0d0d0 1px;padding:5px;"></ZoomPanelStyle>
    </eo:ImageZoom>
    <div id="loading" style="display:none; border: solid 1px black; background-color:White; padding: 6px 20px 6px 20px">Loading...</div>
</p>
</asp:Content>


<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Designs_Style_1_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    Another simple dialog with a close button.
</p>
<eo:Dialog runat="server" id="Dialog1" ControlSkinID="None" Width="320px" Height="216px" HeaderHtml="Dialog Title"
    CloseButtonUrl="00020312" BackColor="White">
    <FooterStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 8pt; padding-bottom: 4px; padding-top: 4px; font-family: tahoma"></FooterStyleActive>
    <HeaderStyleActive CssText="background-image:url('00020311');color:black;font-family:'trebuchet ms';font-size:10pt;font-weight:bold;padding-bottom:5px;padding-left:8px;padding-right:3px;padding-top:0px;height:18px;"></HeaderStyleActive>
    <ContentStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 8pt; padding-bottom: 4px; padding-top: 4px; font-family: tahoma"></ContentStyleActive>
    <BorderImages BottomBorder="00020305" RightBorder="00020307" TopRightCornerBottom="00020308" TopRightCorner="00020309"
        LeftBorder="00020303" TopLeftCorner="00020301" BottomRightCorner="00020306" TopLeftCornerBottom="00020302"
        BottomLeftCorner="00020304" TopBorder="00020310"></BorderImages>
</eo:Dialog>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show(false);">Show Modeless</a>
</p>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show(true);">Show Modal</a>
</p>
</asp:Content>


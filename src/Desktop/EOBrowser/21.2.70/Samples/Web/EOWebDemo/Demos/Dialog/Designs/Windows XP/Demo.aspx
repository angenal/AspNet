<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Designs_Windows_XP_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    This dialog uses <b>BorderImages</b> and various style property together to 
    create Windows XP style look and feel.
</p>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show(false);">Show Modeless</a>
</p>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show(true);">Show Modal</a>
</p>
<eo:Dialog runat="server" id="Dialog1" ControlSkinID="None" Width="320px" HeaderHtml="Dialog Title"
    Height="216px" BackColor="#ECE9D8" CloseButtonUrl="00070301" ContentHtml="Press ESC to close this dialog.">
    <FooterStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 8pt; padding-bottom: 4px; padding-top: 4px; font-family: tahoma"></FooterStyleActive>
    <HeaderStyleActive CssText="padding-right: 3px; padding-left: 8px; font-weight: bold; font-size: 10pt; background-image: url(00020113); padding-bottom: 3px; color: white; padding-top: 0px; font-family: 'trebuchet ms';height:20px;"></HeaderStyleActive>
    <ContentStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 8pt; padding-bottom: 4px; padding-top: 4px; font-family: tahoma"></ContentStyleActive>
    <BorderImages BottomBorder="00020112" RightBorder="00020111" TopRightCornerBottom="00020106" TopLeftCornerRight="00020102"
        TopRightCorner="00020104" LeftBorder="00020110" TopLeftCorner="00020101" BottomRightCorner="00020108"
        TopLeftCornerBottom="00020103" BottomLeftCorner="00020107" TopRightCornerLeft="00020105" TopBorder="00020109"></BorderImages>
</eo:Dialog>
</asp:Content>


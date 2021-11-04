<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Features_Multiple_Modeless_Dialogs_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    You can use multiple modeless dialogs in a way similar to overlapping windows. 
    The following example demonstrates three different dialogs overlaps with each 
    other.
</p>
<p>
    Similar to overlapping windows, clicking a dialog will bring the dialog to the 
    top. The dialog on the top would be in "active" state and other dialogs would 
    be "inactive" state. You can use <b>HeaderStyleInactive</b>, <b>ContentStyleInactive</b>
    and <b>FooterStyleInactive</b> to specify the styles to be used when the dialog 
    is in "inactive" state. This sample uses <B>HeaderStyleInactive</B> to display 
    an inactive header when the dialog is not on top.
</p>
<p>
    <a id="show_dialog_1" href="javascript:eo_GetObject('Dialog1').show(false);">Show Dialog 
        #1</a>
</p>
<p>
    <a id="show_dialog_2" href="javascript:eo_GetObject('Dialog2').show(false);">Show Dialog 
        #2</a>
</p>
<p>
    <a id="show_dialog_3" href="javascript:eo_GetObject('Dialog3').show(false);">Show Dialog 
        #2</a>
</p>
<eo:Dialog runat="server" id="Dialog1" BorderStyle="Solid" CloseButtonUrl="00070101" MinimizeButtonUrl="00070102"
    AllowResize="True" ControlSkinID="None" Width="300px" BorderWidth="1px" Height="200px"
    ShadowColor="LightGray" BorderColor="#335C88" RestoreButtonUrl="00070103" ShadowDepth="3"
    HeaderHtml="Dialog Header" ResizeImageUrl="00020014" AnchorElementID="show_dialog_1" OffsetX="100">
    <HeaderStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; background-image: url(00070104); padding-bottom: 3px; padding-top: 3px; font-family: tahoma"></HeaderStyleActive>
    <HeaderStyleInactive CssText="PADDING-RIGHT: 4px; PADDING-LEFT: 4px; FONT-SIZE: 11px; PADDING-BOTTOM: 3px; PADDING-TOP: 3px; FONT-FAMILY: tahoma; BACKGROUND-COLOR: gainsboro"></HeaderStyleInactive>
    <ContentStyleActive CssText="border-top: #335c88 1px solid; background-color: #e5f1fd"></ContentStyleActive>
</eo:Dialog>
<eo:Dialog runat="server" id="Dialog2" BorderStyle="Solid" CloseButtonUrl="00070101" MinimizeButtonUrl="00070102"
    AllowResize="True" ControlSkinID="None" Width="300px" BorderWidth="1px" Height="200px"
    ShadowColor="LightGray" BorderColor="#335C88" RestoreButtonUrl="00070103" ShadowDepth="3"
    HeaderHtml="Dialog Header" ResizeImageUrl="00020014" AnchorElementID="show_dialog_2" OffsetX="200">
    <HeaderStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; background-image: url(00070104); padding-bottom: 3px; padding-top: 3px; font-family: tahoma"></HeaderStyleActive>
    <HeaderStyleInactive CssText="PADDING-RIGHT: 4px; PADDING-LEFT: 4px; FONT-SIZE: 11px; PADDING-BOTTOM: 3px; PADDING-TOP: 3px; FONT-FAMILY: tahoma; BACKGROUND-COLOR: gainsboro"></HeaderStyleInactive>
    <ContentStyleActive CssText="border-top: #335c88 1px solid; background-color: #e5f1fd"></ContentStyleActive>
</eo:Dialog>
<eo:Dialog runat="server" id="Dialog3" BorderStyle="Solid" CloseButtonUrl="00070101" MinimizeButtonUrl="00070102"
    AllowResize="True" ControlSkinID="None" Width="300px" BorderWidth="1px" Height="200px"
    ShadowColor="LightGray" BorderColor="#335C88" RestoreButtonUrl="00070103" ShadowDepth="3"
    HeaderHtml="Dialog Header" ResizeImageUrl="00020014" AnchorElementID="show_dialog_3" OffsetX="300">
    <HeaderStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; background-image: url(00070104); padding-bottom: 3px; padding-top: 3px; font-family: tahoma"></HeaderStyleActive>
    <HeaderStyleInactive CssText="PADDING-RIGHT: 4px; PADDING-LEFT: 4px; FONT-SIZE: 11px; PADDING-BOTTOM: 3px; PADDING-TOP: 3px; FONT-FAMILY: tahoma; BACKGROUND-COLOR: gainsboro"></HeaderStyleInactive>
    <ContentStyleActive CssText="border-top: #335c88 1px solid; background-color: #e5f1fd"></ContentStyleActive>
</eo:Dialog>
</asp:Content>


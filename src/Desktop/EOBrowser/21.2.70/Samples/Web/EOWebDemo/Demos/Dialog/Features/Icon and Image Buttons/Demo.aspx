<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Features_Icon_and_Image_Buttons_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web Dialog provides <b>MinimizeButtonUrl</b>, <b>RestoreButtonUrl</b>, <b>CloseButtonUrl</b>
    and <b>IconUrl</b> for you to customize minimize/restore/close button and the 
    dialog icon.
</p>
<p>
    The following sample uses these properties to display a minimize/restore 
    button, a close button and dialog icon. It also has <b>ResizeImageUrl</b>
    set to provide a resizing grip.
</p>
<eo:Dialog runat="server" id="Dialog1" ControlSkinID="None" Width="300px" Height="200px" HeaderHtml="Dialog Header"
    BorderStyle="Solid" CloseButtonUrl="00070101" MinimizeButtonUrl="00070102" AllowResize="True"
    BorderWidth="1px" ShadowColor="LightGray" BorderColor="#335C88" RestoreButtonUrl="00070103"
    ShadowDepth="3" ResizeImageUrl="00020014" IconUrl="00070203">
    <HeaderStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; background-image: url(00070104); padding-bottom: 3px; padding-top: 3px; font-family: tahoma"></HeaderStyleActive>
    <ContentStyleActive CssText="border-top: #335c88 1px solid; background-color: #e5f1fd"></ContentStyleActive>
</eo:Dialog>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show(false);">Show Modeless</a>
</p>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show(true);">Show Modal</a>
</p>
</asp:Content>


<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Features_Back_Shade_for_Modal_Dialog_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web Dialog can display a "back shade" when a modal dialog is active. The 
    "back shade" places a half-transparent shade on top of the background. The 
    shade visually indicates the existence of a modal dialog.
</p>
<eo:Dialog runat="server" id="Dialog1" BorderStyle="Solid" CloseButtonUrl="00070101" MinimizeButtonUrl="00070102"
    AllowResize="True" ControlSkinID="None" Width="300px" BorderWidth="1px" Height="200px"
    ShadowColor="LightGray" BorderColor="#335C88" RestoreButtonUrl="00070103" ShadowDepth="3"
    HeaderHtml="Dialog Header" ResizeImageUrl="00020014" BackShadeColor="Blue">
    <HeaderStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; background-image: url(00070104); padding-bottom: 3px; padding-top: 3px; font-family: tahoma"></HeaderStyleActive>
    <ContentStyleActive CssText="border-top: #335c88 1px solid; background-color: #e5f1fd"></ContentStyleActive>
</eo:Dialog>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show(true);">Show Modal</a>
</p>
</asp:Content>


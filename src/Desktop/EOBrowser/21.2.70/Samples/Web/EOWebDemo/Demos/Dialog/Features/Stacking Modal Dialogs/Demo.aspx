<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Features_Stacking_Modal_Dialogs_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
EO.Web can "stack" multiple modal dialogs with one on top of another. The following
sample demonstrates displaying a second modal dialog from the first modal dialog.
</p>
<eo:Dialog runat="server" id="Dialog1" BorderStyle="Solid" CloseButtonUrl="00070101" MinimizeButtonUrl="00070102"
    AllowResize="True" ControlSkinID="None" Width="300px" BorderWidth="1px" Height="200px"
    ShadowColor="LightGray" BorderColor="#335C88" RestoreButtonUrl="00070103" ShadowDepth="3"
    HeaderHtml="Modal Dialog 1" ResizeImageUrl="00020014" HorizontalAlign="Center" VerticalAlign="Middle">
    <HeaderStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; background-image: url(00070104); padding-bottom: 3px; padding-top: 3px; font-family: tahoma"></HeaderStyleActive>
    <ContentStyleActive CssText="border-top: #335c88 1px solid; background-color: #e5f1fd"></ContentStyleActive>
    <ContentTemplate>
        <a href="javascript:eo_GetObject('Dialog2').show(true);">Show Modal Dialog 2</a>
    </ContentTemplate>
</eo:Dialog>
<p>
    <a id="show_dialog_1" href="javascript:eo_GetObject('Dialog1').show(true);">Show 
        Modal Dialog 1</a>
</p>
<eo:Dialog runat="server" id="Dialog2" ResizeImageUrl="00020014" HeaderHtml="Modal Dialog 2"
    ShadowDepth="3" RestoreButtonUrl="00070103" BorderColor="#335C88" ShadowColor="LightGray"
    Height="125px" BorderWidth="1px" Width="192px" ControlSkinID="None" AllowResize="True"
    MinimizeButtonUrl="00070102" CloseButtonUrl="00070101" BorderStyle="Solid" ContentHtml="Another modal dialog. Press ESC to close.">
    <HeaderStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; background-image: url(00070104); padding-bottom: 3px; padding-top: 3px; font-family: tahoma"></HeaderStyleActive>
    <ContentStyleActive CssText="border-top: #335c88 1px solid; background-color: #e5f1fd"></ContentStyleActive>
</eo:Dialog>
</asp:Content>


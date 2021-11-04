<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Features_Min_and_Max_Size_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<p>
    While you can set <STRONG>AllowResize</STRONG> to true so that the dialog is 
    resizable, you can also specify a minimize size and maximum size through <STRONG>MinWidth</STRONG>,
    <STRONG>MaxWidth</STRONG>, <STRONG>MinHeight</STRONG> and <STRONG>MaxHeight</STRONG>
    property.
</p>
<p>
    The following sample has a minimal size of 100 by 100 and 
a 
    maximum size of 300 by 300.
</p>
<eo:Dialog runat="server" id="Dialog1" BorderStyle="Solid" CloseButtonUrl="00070101" MinimizeButtonUrl="00070102"
    AllowResize="True" ControlSkinID="None" Width="300px" BorderWidth="1px" Height="200px"
    ShadowColor="LightGray" BorderColor="#335C88" RestoreButtonUrl="00070103" ShadowDepth="3"
    HeaderHtml="Dialog Header" ResizeImageUrl="00020014" MaxHeight="300" MaxWidth="300" MinHeight="100"
    MinWidth="100">
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


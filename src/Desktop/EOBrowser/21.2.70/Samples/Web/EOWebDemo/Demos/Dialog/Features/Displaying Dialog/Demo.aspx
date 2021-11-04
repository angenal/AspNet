<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Features_Displaying_Dialog_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    While EO.Web Dialog provides complete client side Javascript interface that 
    gives you many options on how the dialog should be displayed, the easiest way 
    to display a dialog is to set the dialog's <b>ShowButton</b> property.
</p>
<asp:LinkButton Runat="server" ID="btnShowDialog">Show Modal Dialog</asp:LinkButton>
<eo:Dialog runat="server" id="Dialog1" ControlSkinID="None" Height="100px" Width="168px" HeaderHtml="Dialog Title"
    FooterHtml="Dialog Footer" BackColor="#47729F" ContentHtml="Press ESC to close dialog" ShowButton="btnShowDialog">
    <HeaderStyleActive CssText="border-right: #22456a 1px solid; padding-right: 4px; border-top: #ffbf00 3px solid; padding-left: 4px; font-weight: bold; font-size: 11px; padding-bottom: 2px; color: white; padding-top: 2px; border-bottom: #22456a 1px solid; font-family: verdana"></HeaderStyleActive>
    <ContentStyleActive CssText="border-right: #22456a 1px solid; padding-right: 4px; border-top: #7d97b6 1px solid; padding-left: 4px; border-left-width: 1px; font-size: 11px; border-left-color: #728eb8; padding-bottom: 4px; color: white; padding-top: 4px; border-bottom: #22456a 1px solid; font-family: verdana"></ContentStyleActive>
    <FooterStyleActive CssText="border-right: #22456a 1px solid; padding-right: 4px; border-top: #7d97b6 1px solid; padding-left: 4px; border-left-width: 1px; font-size: 11px; border-left-color: #728eb8; padding-bottom: 4px; color: white; padding-top: 4px; border-bottom: #22456a 1px solid; font-family: verdana"></FooterStyleActive>
</eo:Dialog>
</asp:Content>


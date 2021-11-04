<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Features_Show_and_Close_Effect_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web Dialog supports various effects when display and close a dialog. The 
    following samples demonstrated this feature.
</p>
<p>
    Use <b>ShowEffect</b> or <b>CloseEffect</b> to specify the effect to be used 
    when displaying or closing a dialog.
</p>
<eo:Dialog runat="server" id="Dialog1" HeaderHtml="MSN Messenger" BorderWidth="1px" BorderStyle="Solid"
    BorderColor="#728EB8" IconUrl="00070203" ControlSkinID="None" CloseButtonUrl="00070201"
    Width="168px" BackColor="White" Height="120px">
    <ShowEffect Type="GlideTopToBottom"></ShowEffect>
    <HeaderStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; background-image: url(00070202); padding-bottom: 2px; padding-top: 2px; font-family: arial"></HeaderStyleActive>
    <ContentStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; padding-bottom: 4px; padding-top: 4px; font-family: verdana; background-color: #f8fafd"></ContentStyleActive>
    <FooterStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; padding-bottom: 4px; padding-top: 4px; font-family: verdana; background-color: #f8fafd"></FooterStyleActive>
    <CloseEffect Type="GlideTopToBottom"></CloseEffect>
</eo:Dialog>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show();">Show Dialog</a>
</p>
</asp:Content>


<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Designs_MSN_Messenger_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    This dialog mimics MSN messenger style dialog boxes. The gradient header is 
    created by setting a background image on <b>HeaderStyleActive</b>.
</p>
<eo:Dialog runat="server" id="Dialog1" ControlSkinID="None" Width="168px" Height="110px" HeaderHtml="MSN Messenger"
    BorderStyle="Solid" CloseButtonUrl="00070201" BorderWidth="1px" BorderColor="#728EB8" BackColor="White"
    IconUrl="00070203" ContentHtml="Hello!">
    <HeaderStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; background-image: url(00070202); padding-bottom: 2px; padding-top: 2px; font-family: arial"></HeaderStyleActive>
    <ContentStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; padding-bottom: 4px; padding-top: 4px; font-family: verdana; background-color: #f8fafd"></ContentStyleActive>
    <FooterTemplate>
        <div align="center">
            <a href="javascript:eo_GetObject('Dialog1').end();" style="color:#07519a">OK</a>
        </div>
    </FooterTemplate>
    <FooterStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; padding-bottom: 4px; padding-top: 4px; font-family: verdana; background-color: #f8fafd"></FooterStyleActive>
</eo:Dialog>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show(false);">Show Modeless</a>
</p>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show(true);">Show Modal</a>
</p>
</asp:Content>


<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Features_Moving_and_Resizing_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    Use <b>AllowMove</b> and <b>AllowResize</b> to specify whether the dialog can 
    be moved or resized.
</p>
<eo:CallbackPanel runat="server" id="CallbackPanel1" Triggers="{ControlID:cbMove;Parameter:},{ControlID:cbResize;Parameter:}">
    <asp:CheckBox id="cbMove" Text="Allow Move" Runat="server" Checked="True" OnCheckedChanged="cbMove_CheckedChanged"></asp:CheckBox>
    <asp:CheckBox id="cbResize" Text="Allow Resize" Runat="server" Checked="True" OnCheckedChanged="cbResize_CheckedChanged"></asp:CheckBox>
    <eo:Dialog id="Dialog1" runat="server" BorderStyle="Solid" BackColor="White" CloseButtonUrl="00070201"
        ControlSkinID="None" Width="168px" BorderWidth="1px" Height="120px" BorderColor="#728EB8"
        IconUrl="00070203" HeaderHtml="MSN Messenger" ResizeImageUrl="00020014" AllowResize="True">
        <HeaderStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; background-image: url(00070202); padding-bottom: 2px; padding-top: 2px; font-family: arial"></HeaderStyleActive>
        <ContentStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; padding-bottom: 4px; padding-top: 4px; font-family: verdana; background-color: #f8fafd"></ContentStyleActive>
    </eo:Dialog>
</eo:CallbackPanel>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show(false);">Show Modeless</a>
</p>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show(true);">Show Modal</a>
</p>
</asp:Content>


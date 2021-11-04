<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ListBox_Designs_Visual_Studio_2008_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <eo:ListBox runat="server" ID="ListBox1" ControlSkinID="None" Height="150px" 
        Width="232px">
        <FooterStyle CssText="background-image:url(00106006);background-position:left bottom;background-repeat:no-repeat;" />
        <BodyStyle CssText="background-image:url(00106005); background-repeat: repeat; padding-left: 12px; padding-right:10px; padding-top: 5px; padding-bottom: 5px; " />
        <DisabledItemStyle CssText="background-color:white; color: #c0c0c0; padding: 2px;" />
        <ItemStyle CssText="background-color:white; padding: 2px; color: black;" />
        <ListBoxStyle CssText="font-family:Tahoma; font-size:11px;" />
        <FooterTemplate>
            <div style="height:10px;width:1px;">
            </div>
        </FooterTemplate>
        <MoreItemsMessageStyle CssText="padding:2px;" />
        <HeaderStyle CssText="background-image:url(00106004);color:white;font-weight:bold;padding-bottom:3px;padding-left:13px;padding-top:3px;" />
        <HeaderTemplate>
            Header
        </HeaderTemplate>
        <SelectedItemStyle CssText="padding: 2px; background-color:#d4d0c8; color:black;" />
        <Items>
            <eo:ListBoxItem Text="Item 1" />
            <eo:ListBoxItem Text="Item 2" />
            <eo:ListBoxItem Text="Item 3" />
            <eo:ListBoxItem Text="Item 4" />
            <eo:ListBoxItem Text="Item 5" />
            <eo:ListBoxItem Text="Item 6" />
            <eo:ListBoxItem Text="Item 7" />
            <eo:ListBoxItem Text="Item 8" />
            <eo:ListBoxItem Text="Item 9" />
            <eo:ListBoxItem Text="Item 10" />
        </Items>
    </eo:ListBox>
</asp:Content>


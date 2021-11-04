<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ListBox_Designs_Style_1_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <eo:ListBox runat="server" ID="ListBox1" ControlSkinID="None" Height="150px" 
        Width="200px">
        <FooterStyle CssText="background-image:url('00020013'); background-position: left top; background-repeat: repeat; height:16px;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;width:196px;" />
        <DisabledItemStyle CssText="background-color: white; color: #c0c0c0; padding:2px;" />
        <ItemStyle CssText="background-color: white;padding:2px;" />
        <ListBoxStyle CssText="font-size: 9pt; font-family: Verdana; color: black; cursor: hand; border-right: #999999 1px solid; border-top: #999999 1px solid; border-left: #999999 1px solid; border-bottom: #999999 1px solid;background-color:white;" />
        <FooterTemplate>
            Footer
        </FooterTemplate>
        <HeaderStyle CssText="background-image:url('00020013'); background-position: left top; background-repeat: repeat; height:16px;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;" />
        <HeaderTemplate>
            Header
        </HeaderTemplate>
        <SelectedItemStyle CssText="background-color: #08246b; color:white; padding:2px;" />
        <ItemHoverStyle CssText="background-color: #f1f1f1;padding:2px;" />
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


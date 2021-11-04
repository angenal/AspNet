<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ListBox_Designs_Style_3_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <eo:ListBox runat="server" ID="ListBox1" ControlSkinID="None" Height="200px" 
        Width="300px">
        <FooterStyle CssText="background-image:url('00106002'); background-position: left top; background-repeat: repeat; height:16px;padding-bottom:2px;padding-left:7px;padding-right:2px;padding-top:2px; margin-top:3px; height: 18px;" />
        <BodyStyle CssText="border: solid 1px #dedede;" />
        <ItemListStyle CssText="padding: 4px;" />
        <DisabledItemStyle CssText="border-bottom: solid 1px #dedede; color: #c0c0c0; padding: 2px; padding-left:2px; padding-top:4px;padding-right:2px;padding-bottom:4px;" />
        <ItemStyle CssText="border-bottom: solid 1px #dedede; padding-left: 2px; padding-right:2px; padding-top:4px; padding-bottom: 3px; background-color:white;" />
        <ListBoxStyle CssText="font-family: Tahoma; font-size:12px;background-color:white;" />
        <FooterTemplate>
            Footer
        </FooterTemplate>
        <MoreItemsMessageStyle CssText="padding:2px;" />
        <HeaderStyle CssText="background-image:url('00106001');background-position-x:left;background-position-y:top;background-repeat:repeat;height:16px;padding-bottom:2px;padding-left:7px;padding-right:2px;padding-top:6px;height:19px;margin-bottom:3px;" />
        <HeaderTemplate>
            Header
        </HeaderTemplate>
        <SelectedItemStyle CssText="background-color: #08246b; color:white; padding-left:2px; padding-top:4px;padding-right:2px;padding-bottom:4px;" />
        <ItemHoverStyle CssText="border-bottom: solid 1px #dedede; padding-left: 2px; padding-right:2px; padding-top:4px; padding-bottom: 3px; background-color:#f3f7fc;" />
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


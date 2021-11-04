<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ListBox_Designs_Office_2003_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <eo:ListBox runat="server" ID="ListBox1" ControlSkinID="None" Height="100px" 
        Width="200px">
        <BodyStyle CssText="border: solid 1px #666666;" />
        <ItemListStyle CssText="padding: 1px;" />
        <DisabledItemStyle CssText="background-color:white; color: #c0c0c0; padding: 1px;" />
        <ItemStyle CssText="padding: 1px; background-color:white; color: black;" />
        <ListBoxStyle CssText="font-family:Tahoma; font-size:11px;background-color:white;" />
        <MoreItemsMessageStyle CssText="padding:2px;" />
        <SelectedItemStyle CssText="padding: 1px; background-color:#0a246a; color:white;" />
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


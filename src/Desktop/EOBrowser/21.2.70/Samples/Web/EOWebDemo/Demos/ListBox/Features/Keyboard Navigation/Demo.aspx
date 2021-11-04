<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ListBox_Features_Keyboard_Navigation_Demo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
    EO.Web ListBox supports keyboard navigation. Set <b>EnableKeyboardNavigation</b>
    to true to enable this feature.
    </p>
    <eo:ListBox runat="server" ID="ListBox1" ControlSkinID="None" Height="150px" 
        Width="200px" EnableKeyboardNavigation="true">
        <BodyStyle CssText="border: solid 1px #868686;" />
        <ItemListStyle CssText="padding: 1px;" />
        <DisabledItemStyle CssText="color:#c0c0c0;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
        <ItemStyle CssText="color:black;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
        <ListBoxStyle CssText="font-family:Tahoma; font-size:13px;" />
        <MoreItemsMessageStyle CssText="padding:2px;" />
        <SelectedItemStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
        <ItemHoverStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
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


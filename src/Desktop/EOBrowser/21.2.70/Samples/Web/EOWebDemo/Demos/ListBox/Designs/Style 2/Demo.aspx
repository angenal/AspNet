<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ListBox_Designs_Style_2_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <eo:ListBox runat="server" ID="ListBox1" ControlSkinID="None" Height="150px" 
        Width="200px">
        <ItemListStyle CssText="border-bottom-color:#828790;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#828790;border-left-style:solid;border-left-width:1px;border-right-color:#828790;border-right-style:solid;border-right-width:1px;border-top-color:#828790;border-top-style:solid;border-top-width:1px;padding-bottom:0px;padding-left:0px;padding-right:0px;padding-top:0px;" />
        <DisabledItemStyle CssText="padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;height:16px;color:#c0c0c0;" />
        <ItemStyle CssText="padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;height:16px;" />
        <ListBoxStyle CssText="font-family:Verdana;font-size:12px;color:#3c3c3c;background-color:white;" />
        <SelectedItemStyle CssText="background-image:url(00106007); background-repeat:repeat; border-bottom-color:#7da2ce;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7da2ce;border-left-style:solid;border-left-width:1px;border-right-color:#7da2ce;border-right-style:solid;border-right-width:1px;border-top-color:#7da2ce;border-top-style:solid;border-top-width:1px;padding:1px;height:16px;" />
        <ItemHoverStyle CssText="background-image:url(00106007); background-repeat:repeat; border-bottom-color:#7da2ce;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7da2ce;border-left-style:solid;border-left-width:1px;border-right-color:#7da2ce;border-right-style:solid;border-right-width:1px;border-top-color:#7da2ce;border-top-style:solid;border-top-width:1px;padding:1px;height:16px;" />
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


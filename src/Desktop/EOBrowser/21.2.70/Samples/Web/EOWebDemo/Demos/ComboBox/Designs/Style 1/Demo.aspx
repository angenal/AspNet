<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ComboBox_Designs_Style_1_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <eo:ComboBox runat="server" ID="ComboBox1" ControlSkinID="None" 
        DefaultIcon="00101070" HintText="Type here" Width="150px">
        <IconStyle CssText="width:16px;height:16px;" />
        <IconAreaStyle CssText="font-family: tahoma; font-size: 12px; border-left: solid 1px #a8b1c6; border-top: solid 1px #a8b1c6; border-bottom: solid 1px #a8b1c6; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <IconAreaHoverStyle CssText="font-family: tahoma; font-size: 12px; border-left: solid 1px #0a246a; border-top: solid 1px #0a246a; border-bottom: solid 1px #0a246a; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <DropDownTemplate>
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
        </DropDownTemplate>
        <ButtonStyle CssText="width:14px;height:18px;background-color:#dee1e7; background-image:url(00020012); background-position: center center; background-repeat: no-repeat;" />
        <ButtonAreaStyle CssText="border: solid 1px #a8b1c6; vertical-align:middle;" />
        <ButtonAreaHoverStyle CssText="border: solid 1px #0a246a; vertical-align:middle;" />
        <TextAreaStyle CssText="font-family: tahoma; font-size: 12px; border-top: solid 1px #a8b1c6; border-bottom: solid 1px #a8b1c6; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <HintTextStyle CssText="font-style:italic;background-color:#c0c0c0;color:white;line-height:15px;" />
        <ButtonHoverStyle CssText="width:14px;height:18px;background-color:#b6bdd2; background-image:url(00020012); background-position: center center; background-repeat: no-repeat;" />
        <TextAreaHoverStyle CssText="font-family: tahoma; font-size: 12px; border-top: solid 1px #0a246a; border-bottom: solid 1px #0a246a; vertical-align:middle;padding-left:2px; padding-right:2px;" />
    </eo:ComboBox>
</asp:Content>


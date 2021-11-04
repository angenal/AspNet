<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ComboBox_Designs_Office_2007_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <eo:ComboBox runat="server" ID="ComboBox1" ControlSkinID="None" 
        DefaultIcon="00101070" HintText="Type here" Width="150px">
        <TextStyle CssText="font-family: tahoma; font-size: 12px;" />
        <IconStyle CssText="width:16px;height:16px;" />
        <IconAreaStyle CssText="font-family: tahoma; font-size: 12px; border-left: solid 1px #abc1de; border-top: solid 1px #abc1de; border-bottom: solid 1px #abc1de; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <IconAreaHoverStyle CssText="font-family: tahoma; font-size: 12px; border-left: solid 1px #b3c7e1; border-top: solid 1px #b3c7e1; border-bottom: solid 1px #b3c7e1; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <DropDownTemplate>
            <eo:ListBox runat="server" ID="ListBox1" ControlSkinID="None" Height="150px" 
                Width="200px">
                <BodyStyle CssText="border: solid 1px #868686;" />
                <ItemListStyle CssText="padding: 1px;" />
                <DisabledItemStyle CssText="color:#c0c0c0;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                <ItemStyle CssText="color:black;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                <ListBoxStyle CssText="font-family:Tahoma; font-size:13px;background-color:white;" />
                <MoreItemsMessageStyle CssText="padding:2px;" />
                <SelectedItemStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
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
                <ItemHoverStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
            </eo:ListBox>
        </DropDownTemplate>
        <ButtonStyle CssText="width:14px;height:22px;background-image:url(00107003); background-position: center center; background-repeat: no-repeat;" />
        <TextAreaStyle CssText="font-family: tahoma; font-size: 12px; border-top: solid 1px #abc1de; border-bottom: solid 1px #abc1de; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <HintTextStyle CssText="font-style:italic;background-color:#c0c0c0;color:white;line-height:16px;" />
        <ButtonHoverStyle CssText="width:14px;height:22px;background-image:url(00107004); background-position: center center; background-repeat: no-repeat;" />
        <TextAreaHoverStyle CssText="font-family: tahoma; font-size: 12px; border-top: solid 1px #b3c7e1; border-bottom: solid 1px #b3c7e1; vertical-align:middle;padding-left:2px; padding-right:2px;" />
    </eo:ComboBox>
</asp:Content>


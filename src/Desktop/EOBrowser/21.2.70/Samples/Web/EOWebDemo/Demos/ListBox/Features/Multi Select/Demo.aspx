<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ListBox_Features_Multi_Select_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
    EO.Web ListBox supports multi-select. User can hold down one of the 
    "modifier" key while clicking the item to multi-select an item. To
    enable this feature, <b>AllowMultiSelect</b> must be set to true.
    </p>
    <p>
    Property <b>MultiSelectModifier</b> controls which "modifier" key 
    (Shift, Alt or Control key) can be used to perform multi-select. 
    The following sample allows you to set the modifier to use. Select
    a modifier and then hold down that modifier key to multi-select
    items in the ListBox.
    </p>
    <p>
        <eo:ComboBox runat="server" ID="cbModifier" ControlSkinID="None" 
            DefaultIcon="00101070" HintText="Click to select" 
            LabelHtml="Select a Modifier:" Width="220px" AllowCustomText="False" 
            AutoPostBack="True" ontextchanged="cbModifier_TextChanged">
            <ButtonHoverStyle CssText="width:14px;height:22px;background-image:url(00107004); background-position: center center; background-repeat: no-repeat;" />
            <IconAreaHoverStyle CssText="font-family: tahoma; font-size: 12px; border-left: solid 1px #b3c7e1; border-top: solid 1px #b3c7e1; border-bottom: solid 1px #b3c7e1; vertical-align:middle;padding-left:2px; padding-right:2px;" />
            <IconAreaStyle CssText="font-family: tahoma; font-size: 12px; border-left: solid 1px #abc1de; border-top: solid 1px #abc1de; border-bottom: solid 1px #abc1de; vertical-align:middle;padding-left:2px; padding-right:2px;" />
            <DropDownTemplate>
                <eo:ListBox runat="server" ID="lbModifier" ControlSkinID="None"
                    Width="120px">
                    <BodyStyle CssText="border: solid 1px #868686;" />
                    <ItemListStyle CssText="padding: 1px;" />
                    <DisabledItemStyle CssText="color:#c0c0c0;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                    <ItemStyle CssText="color:black;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                    <ListBoxStyle CssText="font-family:Tahoma; font-size:13px;background-color:white;" />
                    <MoreItemsMessageStyle CssText="padding:2px;" />
                    <SelectedItemStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                    <ItemHoverStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                    <Items>
                        <eo:ListBoxItem Text="Shift Key" />
                        <eo:ListBoxItem Text="Control Key" />
                        <eo:ListBoxItem Text="Alt Key" />
                    </Items>
                </eo:ListBox>
            </DropDownTemplate>
            <TextStyle CssText="font-family: tahoma; font-size: 12px;" />
            <TextAreaHoverStyle CssText="font-family: tahoma; font-size: 12px; border-top: solid 1px #b3c7e1; border-bottom: solid 1px #b3c7e1; vertical-align:middle;padding-left:2px; padding-right:2px;" />
            <TextAreaStyle CssText="font-family: tahoma; font-size: 12px; border-top: solid 1px #abc1de; border-bottom: solid 1px #abc1de; vertical-align:middle;padding-left:2px; padding-right:2px;" />
            <ButtonStyle CssText="width:14px;height:22px;background-image:url(00107003); background-position: center center; background-repeat: no-repeat;" />
            <IconStyle CssText="display:none;" />
            <HintTextStyle CssText="font-style:italic;background-color:#c0c0c0;color:white;margin-top:1px;" />
        </eo:ComboBox>
    </p>
    <eo:ListBox runat="server" ID="ListBox1" 
        ControlSkinID="None" Height="150px" Width="200px" AllowMultiSelect="true">
        <BodyStyle CssText="border: solid 1px #868686;" />
        <ItemListStyle CssText="padding: 1px;" />
        <DisabledItemStyle CssText="color:#c0c0c0;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
        <ItemStyle CssText="color:black;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
        <ListBoxStyle CssText="font-family:Tahoma; font-size:13px;background-color:white;" />
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


<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_ComboBox_Features_Server_Side_Interface_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        This sample demonstrates how to access ComboBox data from server side code:
    </p>
    <ul>
        <li>Use the <b>ComboBox</b>'s <b>Text</b> property to access the ComboBox text;</li>
        <li>Use the <b>ListBox</b>'s <b>SelectedItemIndex</b> property to access the selected
            item index. Note this property is on the ListBox control, not on the ComboBox control;
        </li>
        <li>Sets <b>AutoPostBack</b> to true, which causes the page to posts back when focus
            leaves the control or when user selects an item from the list. </li>
    </ul>
    <p>
        This sample also handles the ComboBox's <b>TextChanged</b> event.
    </p>
    <eo:ComboBox runat="server" ID="ComboBox1" ControlSkinID="None" DefaultIcon="00101070"
        HintText="Type here" Width="150px" OnTextChanged="ComboBox1_TextChanged" AutoPostBack="true">
        <TextStyle CssText="font-family: tahoma; font-size: 11px;" />
        <IconStyle CssText="width:16px;height:16px;" />
        <IconAreaStyle CssText="font-family: tahoma; font-size: 11px; background-image:url(00107007); background-position: left left; background-repeat:no-repeat; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <DropDownTemplate>
            <eo:ListBox runat="server" ID="ListBox1" ControlSkinID="None" Height="150px" Width="200px">
                <BodyStyle CssText="border: solid 1px #868686;" />
                <ItemListStyle CssText="padding: 1px;" />
                <DisabledItemStyle CssText="color:#c0c0c0;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                <ItemStyle CssText="color:black;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                <ListBoxStyle CssText="font-family:Tahoma; font-size:13px;background-color:white;" />
                <MoreItemsMessageStyle CssText="padding:2px;" />
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
                <SelectedItemStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                <ItemHoverStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
            </eo:ListBox>
        </DropDownTemplate>
        <ButtonStyle CssText="width:17px;height:23px;" />
        <ButtonAreaStyle CssText="background-image:url(00107005);" />
        <ButtonAreaHoverStyle CssText="background-image:url(00107006);" />
        <TextAreaStyle CssText="font-family: tahoma; font-size: 11px; border-top: solid 1px #3d7bad; border-bottom: solid 1px #b7d9ed; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <HintTextStyle CssText="font-style:italic;background-color:#c0c0c0;color:white;line-height:16px;" />
    </eo:ComboBox>
    <p>
        <asp:Label runat="server" ID="lblResult"></asp:Label>
    </p>
</asp:Content>

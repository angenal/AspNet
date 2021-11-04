<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ComboBox_Features_Item_Icon_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
    EO.Web ComboBox can optionally display an icon. The following sample
    displays a list of flags. Once a country is selected, the ComboBox's
    icon is also updated to the flag of the selected country. The ComboBox
    also automatically updates the flag if user types in a country name
    that matches an item in the list.
    </p>
    <p>
    See <a href="http://doc.essentialobjects.com/library/1/CombBox/icon.html" target="_blank">Using Icons</a>
    for more information about how to use item icons with a ComboBox.
    </p>
    <eo:ComboBox runat="server" ID="ComboBox1" ControlSkinID="None" 
        HintText="Type here" Width="200px" LabelHtml="Country:" EnableKeyboardNavigation="true"
        DefaultIcon="../../../../images/question_mark.gif">
        <TextStyle CssText="font-family: tahoma; font-size: 11px;" />
        <IconStyle CssText="width:16px;height:11px;margin-left:2px;margin-right:2px;" />
        <IconAreaStyle CssText="font-family: tahoma; font-size: 11px; background-image:url(00107007); background-position: left left; background-repeat:no-repeat; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <DropDownTemplate>
            <eo:ListBox runat="server" ID="ListBox1" ControlSkinID="None" Height="150px" 
                Width="200px" EnableKeyboardNavigation="true">                
                <BodyStyle CssText="border: solid 1px #868686;" />
                <ItemListStyle CssText="padding: 1px;" />
                <DisabledItemStyle CssText="color:#c0c0c0;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                <ItemStyle CssText="color:black;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                <ListBoxStyle CssText="font-family:Tahoma; font-size:13px;background-color:white;" />
                <MoreItemsMessageStyle CssText="padding:2px;" />
                <SelectedItemStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                <ItemHoverStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                <ItemTemplate>
                    <table border="0" cellpadding="1">
                        <tr>
                            <td>
                                <img src="<%#Container.Item.Icon%>" alt="flag" />
                            </td>
                            <td>
                                <%#Container.Item.Text%>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <Items>
                    <eo:ListBoxItem Text="United States" Icon="../../../../images/Flags/us.gif" />
                    <eo:ListBoxItem Text="United Kingdom" Icon="../../../../images/Flags/gb.gif" />
                    <eo:ListBoxItem Text="Canada" Icon="../../../../images/Flags/ca.gif" />
                    <eo:ListBoxItem Text="Australia" Icon="../../../../images/Flags/au.gif" />
                    <eo:ListBoxItem Text="Germany" Icon="../../../../images/Flags/de.gif" />
                    <eo:ListBoxItem Text="France" Icon="../../../../images/Flags/fr.gif" />
                </Items>
            </eo:ListBox>
        </DropDownTemplate>
        <ButtonStyle CssText="width:17px;height:23px;" />
        <ButtonAreaStyle CssText="background-image:url(00107005);" />
        <ButtonAreaHoverStyle CssText="background-image:url(00107006);" />
        <TextAreaStyle CssText="font-family: tahoma; font-size: 11px; border-top: solid 1px #3d7bad; border-bottom: solid 1px #b7d9ed; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <HintTextStyle CssText="font-style:italic;background-color:#c0c0c0;color:white;line-height:16px;" />
    </eo:ComboBox>
</asp:Content>


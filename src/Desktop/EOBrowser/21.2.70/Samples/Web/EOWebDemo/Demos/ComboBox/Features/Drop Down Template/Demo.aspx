<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ComboBox_Features_Drop_Down_Template_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
    EO.Web <b>ComboBox</b> does not provide the drop down itself --- you must
    provide a drop down through its <b>DropDownTemplate</b> property.
    Usually you would simply place an EO.Web <b>ListBox</b> control inside
    the <b>ComboBox</b>'s DropDownTemplate. However you can place any controls
    inside <b>DropDownTemplate</b>. This sample uses three <b>ListBox</b> 
    controls inside <b>DropDownTemplate</b>.
    </p>
    <eo:ComboBox runat="server" ID="CombBox1" ControlSkinID="None" 
        DefaultIcon="phone.gif" HintText="Select a phone" Width="150px">
        <TextStyle CssText="font-family: tahoma; font-size: 11px;" />
        <IconStyle CssText="width:16px;height:16px;" />
        <IconAreaStyle CssText="font-family: tahoma; font-size: 11px; background-image:url(00107007); background-position: left left; background-repeat:no-repeat; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <DropDownTemplate>
            <div style="border: solid 1px #c0c0c0; background-color:White;padding:3px;" class="normal">
                <table border="0">
                    <tr>
                        <td>Andriod Phones</td>
                        <td>Refurbished Devices</td>
                        <td>Free Phones</td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <eo:ListBox runat="server" ID="ListBox1" ControlSkinID="None" Height="200px" 
                                Width="200px">
                                <FooterStyle CssText="background-image:url('00106002'); background-position: left top; background-repeat: repeat; height:16px;padding-bottom:2px;padding-left:7px;padding-right:2px;padding-top:2px; margin-top:3px; height: 18px;" />
                                <BodyStyle CssText="border: solid 1px #dedede;" />
                                <ItemListStyle CssText="padding: 4px;" />
                                <DisabledItemStyle CssText="border-bottom: solid 1px #dedede; color: #c0c0c0; padding: 2px; padding-left:2px; padding-top:4px;padding-right:2px;padding-bottom:4px;" />
                                <ItemStyle CssText="border-bottom: solid 1px #dedede; padding-left: 2px; padding-right:2px; padding-top:4px; padding-bottom: 3px; background-color:white;" />
                                <ListBoxStyle CssText="font-family: Tahoma; font-size:12px;background-color:white;" />
                                <SelectedItemStyle CssText="background-color: #08246b; color:white; padding-left:2px; padding-top:4px;padding-right:2px;padding-bottom:4px;" />
                                <MoreItemsMessageStyle CssText="padding:2px;" />
                                <HeaderStyle CssText="background-image:url('00106001');background-position-x:left;background-position-y:top;background-repeat:repeat;height:16px;padding-bottom:2px;padding-left:7px;padding-right:2px;padding-top:6px;height:19px;margin-bottom:3px;" />
                                <Items>
                                    <eo:ListBoxItem Text="Motorola CLIQ 2" />
                                    <eo:ListBoxItem Text="Samsung Dart" />
                                    <eo:ListBoxItem Text="LG Optimus T" />
                                    <eo:ListBoxItem Text="T-Mobile Comet" />
                                    <eo:ListBoxItem Text="Samsung Gravity Smart" />
                                    <eo:ListBoxItem Text="Motorola DEFY" />
                                    <eo:ListBoxItem Text="T-Mobile myTouch" />
                                </Items>
                                <ItemHoverStyle CssText="border-bottom: solid 1px #dedede; padding-left: 2px; padding-right:2px; padding-top:4px; padding-bottom: 3px; background-color:#f3f7fc;" />
                            </eo:ListBox>
                        </td>
                        <td valign="top">
                            <eo:ListBox runat="server" ID="ListBox4" ControlSkinID="None" Height="200px" 
                                Width="200px">
                                <FooterStyle CssText="background-image:url('00106002'); background-position: left top; background-repeat: repeat; height:16px;padding-bottom:2px;padding-left:7px;padding-right:2px;padding-top:2px; margin-top:3px; height: 18px;" />
                                <BodyStyle CssText="border: solid 1px #dedede;" />
                                <ItemListStyle CssText="padding: 4px;" />
                                <DisabledItemStyle CssText="border-bottom: solid 1px #dedede; color: #c0c0c0; padding: 2px; padding-left:2px; padding-top:4px;padding-right:2px;padding-bottom:4px;" />
                                <ItemStyle CssText="border-bottom: solid 1px #dedede; padding-left: 2px; padding-right:2px; padding-top:4px; padding-bottom: 3px; background-color:white;" />
                                <ListBoxStyle CssText="font-family: Tahoma; font-size:12px;background-color:white;" />
                                <SelectedItemStyle CssText="background-color: #08246b; color:white; padding-left:2px; padding-top:4px;padding-right:2px;padding-bottom:4px;" />
                                <MoreItemsMessageStyle CssText="padding:2px;" />
                                <HeaderStyle CssText="background-image:url('00106001');background-position-x:left;background-position-y:top;background-repeat:repeat;height:16px;padding-bottom:2px;padding-left:7px;padding-right:2px;padding-top:6px;height:19px;margin-bottom:3px;" />
                                <Items>
                                    <eo:ListBoxItem Text="LG Optimus T with Google - Burgundy - Refurbished" />
                                    <eo:ListBoxItem Text="T-Mobile Rocket 2.0 Data Stick - Refurbished" />
                                    <eo:ListBoxItem Text="HTC HD7 - Refurbished" />
                                </Items>
                                <ItemHoverStyle CssText="border-bottom: solid 1px #dedede; padding-left: 2px; padding-right:2px; padding-top:4px; padding-bottom: 3px; background-color:#f3f7fc;" />
                            </eo:ListBox>
                        </td>
                        <td valign="top">
                            <eo:ListBox runat="server" ID="ListBox3" ControlSkinID="None" Height="200px" 
                                Width="200px">
                                <FooterStyle CssText="background-image:url('00106002'); background-position: left top; background-repeat: repeat; height:16px;padding-bottom:2px;padding-left:7px;padding-right:2px;padding-top:2px; margin-top:3px; height: 18px;" />
                                <BodyStyle CssText="border: solid 1px #dedede;" />
                                <ItemListStyle CssText="padding: 4px;" />
                                <DisabledItemStyle CssText="border-bottom: solid 1px #dedede; color: #c0c0c0; padding: 2px; padding-left:2px; padding-top:4px;padding-right:2px;padding-bottom:4px;" />
                                <ItemStyle CssText="border-bottom: solid 1px #dedede; padding-left: 2px; padding-right:2px; padding-top:4px; padding-bottom: 3px; background-color:white;" />
                                <ListBoxStyle CssText="font-family: Tahoma; font-size:12px;background-color:white;" />
                                <SelectedItemStyle CssText="background-color: #08246b; color:white; padding-left:2px; padding-top:4px;padding-right:2px;padding-bottom:4px;" />
                                <MoreItemsMessageStyle CssText="padding:2px;" />
                                <HeaderStyle CssText="background-image:url('00106001');background-position-x:left;background-position-y:top;background-repeat:repeat;height:16px;padding-bottom:2px;padding-left:7px;padding-right:2px;padding-top:6px;height:19px;margin-bottom:3px;" />
                                <Items>
                                    <eo:ListBoxItem Text="Motorola CLIQ 2" />
                                    <eo:ListBoxItem Text="Samsung Dart" />
                                </Items>
                                <ItemHoverStyle CssText="border-bottom: solid 1px #dedede; padding-left: 2px; padding-right:2px; padding-top:4px; padding-bottom: 3px; background-color:#f3f7fc;" />
                            </eo:ListBox>
                        </td>
                    </tr>
                </table>
            </div>
        </DropDownTemplate>
        <ButtonStyle CssText="width:17px;height:23px;" />
        <ButtonAreaStyle CssText="background-image:url(00107005);" />
        <ButtonAreaHoverStyle CssText="background-image:url(00107006);" />
        <TextAreaStyle CssText="font-family: tahoma; font-size: 11px; border-top: solid 1px #3d7bad; border-bottom: solid 1px #b7d9ed; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <HintTextStyle CssText="font-style:italic;background-color:#c0c0c0;color:white;line-height:16px;" />
    </eo:ComboBox>
</asp:Content>


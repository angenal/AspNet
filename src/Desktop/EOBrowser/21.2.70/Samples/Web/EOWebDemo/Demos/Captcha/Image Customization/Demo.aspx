<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Captcha_Image_Customization_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        EO.Web Captcha provides a number of options for you to customize the Capthca image.
    </p>
    <table border="0">
        <tr>
            <td>
                <b>Options</b>
            </td>
            <td>
            </td>
            <td>
                <b>Result</b>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table border="0">
                    <tr>
                        <td>
                            Image Noise Level:
                        </td>
                        <td>
                            <eo:ComboBox runat="server" ID="cbImageNoiseLevel" ControlSkinID="None" Width="100px"
                                Text="Medium" AllowCustomText="false">
                                <IconAreaStyle CssText="font-family: tahoma; font-size: 11px; background-image:url(00107007); background-position: left left; background-repeat:no-repeat; vertical-align:middle;padding-left:2px; padding-right:2px;" />
                                <DropDownTemplate>
                                    <eo:ListBox runat="server" ID="lbImageNoiseLevel" ControlSkinID="None" Width="100px">
                                        <BodyStyle CssText="border: solid 1px #868686;" />
                                        <ItemListStyle CssText="padding: 1px;" />
                                        <DisabledItemStyle CssText="color:#c0c0c0;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                                        <ItemStyle CssText="color:black;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                                        <ListBoxStyle CssText="font-family:Tahoma; font-size:13px;background-color:white;" />
                                        <MoreItemsMessageStyle CssText="padding:2px;" />
                                        <SelectedItemStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                                        <ItemHoverStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                                        <Items>
                                            <eo:ListBoxItem Text="None" />
                                            <eo:ListBoxItem Text="Low" />
                                            <eo:ListBoxItem Text="Medium" />
                                            <eo:ListBoxItem Text="High" />
                                        </Items>
                                    </eo:ListBox>
                                </DropDownTemplate>
                                <TextStyle CssText="font-family: tahoma; font-size: 11px;" />
                                <TextAreaStyle CssText="font-family: tahoma; font-size: 11px; border-top: solid 1px #3d7bad; border-bottom: solid 1px #b7d9ed; vertical-align:middle;padding-left:2px; padding-right:2px;" />
                                <ButtonStyle CssText="width:17px;height:23px;" />
                                <ButtonAreaStyle CssText="background-image:url(00107005);" />
                                <IconStyle CssText="display:none;" />
                                <ButtonAreaHoverStyle CssText="background-image:url(00107006);" />
                                <HintTextStyle CssText="font-style:italic;background-color:#c0c0c0;color:white;line-height:16px;" />
                            </eo:ComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Image Back Color:
                        </td>
                        <td>
                            <eo:ComboBox runat="server" ID="cbImageBackColor" ControlSkinID="None" Width="100px"
                                Text="White" AllowCustomText="false">
                                <IconAreaStyle CssText="font-family: tahoma; font-size: 11px; background-image:url(00107007); background-position: left left; background-repeat:no-repeat; vertical-align:middle;padding-left:2px; padding-right:2px;" />
                                <DropDownTemplate>
                                    <eo:ListBox runat="server" ID="lbImageBackColor" ControlSkinID="None" Width="100px">
                                        <BodyStyle CssText="border: solid 1px #868686;" />
                                        <ItemListStyle CssText="padding: 1px;" />
                                        <DisabledItemStyle CssText="color:#c0c0c0;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                                        <ItemStyle CssText="color:black;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                                        <ListBoxStyle CssText="font-family:Tahoma; font-size:13px;background-color:white;" />
                                        <MoreItemsMessageStyle CssText="padding:2px;" />
                                        <SelectedItemStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                                        <ItemHoverStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                                        <Items>
                                            <eo:ListBoxItem Text="White" />
                                            <eo:ListBoxItem Text="LightGray" />
                                            <eo:ListBoxItem Text="DarkGray" />
                                            <eo:ListBoxItem Text="LightBlue" />
                                        </Items>
                                    </eo:ListBox>
                                </DropDownTemplate>
                                <TextStyle CssText="font-family: tahoma; font-size: 11px;" />
                                <TextAreaStyle CssText="font-family: tahoma; font-size: 11px; border-top: solid 1px #3d7bad; border-bottom: solid 1px #b7d9ed; vertical-align:middle;padding-left:2px; padding-right:2px;" />
                                <ButtonStyle CssText="width:17px;height:23px;" />
                                <ButtonAreaStyle CssText="background-image:url(00107005);" />
                                <IconStyle CssText="display:none;" />
                                <ButtonAreaHoverStyle CssText="background-image:url(00107006);" />
                                <HintTextStyle CssText="font-style:italic;background-color:#c0c0c0;color:white;line-height:16px;" />
                            </eo:ComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Text Font Family:
                        </td>
                        <td>
                            <eo:ComboBox runat="server" ID="cbTextFont" ControlSkinID="None" Width="100px"
                                Text="Tahoma" AllowCustomText="false">
                                <IconAreaStyle CssText="font-family: tahoma; font-size: 11px; background-image:url(00107007); background-position: left left; background-repeat:no-repeat; vertical-align:middle;padding-left:2px; padding-right:2px;" />
                                <DropDownTemplate>
                                    <eo:ListBox runat="server" ID="lbTextFont" ControlSkinID="None" Width="100px">
                                        <BodyStyle CssText="border: solid 1px #868686;" />
                                        <ItemListStyle CssText="padding: 1px;" />
                                        <DisabledItemStyle CssText="color:#c0c0c0;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                                        <ItemStyle CssText="color:black;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                                        <ListBoxStyle CssText="font-family:Tahoma; font-size:13px;background-color:white;" />
                                        <MoreItemsMessageStyle CssText="padding:2px;" />
                                        <SelectedItemStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                                        <ItemHoverStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                                        <Items>
                                            <eo:ListBoxItem Text="Tahoma" />
                                            <eo:ListBoxItem Text="Arial" />
                                            <eo:ListBoxItem Text="Courier New" />
                                            <eo:ListBoxItem Text="Verdana" />
                                        </Items>
                                    </eo:ListBox>
                                </DropDownTemplate>
                                <TextStyle CssText="font-family: tahoma; font-size: 11px;" />
                                <TextAreaStyle CssText="font-family: tahoma; font-size: 11px; border-top: solid 1px #3d7bad; border-bottom: solid 1px #b7d9ed; vertical-align:middle;padding-left:2px; padding-right:2px;" />
                                <ButtonStyle CssText="width:17px;height:23px;" />
                                <ButtonAreaStyle CssText="background-image:url(00107005);" />
                                <IconStyle CssText="display:none;" />
                                <ButtonAreaHoverStyle CssText="background-image:url(00107006);" />
                                <HintTextStyle CssText="font-style:italic;background-color:#c0c0c0;color:white;line-height:16px;" />
                            </eo:ComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Text Noise Level:
                        </td>
                        <td>
                            <eo:ComboBox runat="server" ID="cbTextNoiseLevel" ControlSkinID="None" Width="100px"
                                Text="Medium" AllowCustomText="false">
                                <IconAreaStyle CssText="font-family: tahoma; font-size: 11px; background-image:url(00107007); background-position: left left; background-repeat:no-repeat; vertical-align:middle;padding-left:2px; padding-right:2px;" />
                                <DropDownTemplate>
                                    <eo:ListBox runat="server" ID="lbTextNoiseLevel" ControlSkinID="None" Width="100px">
                                        <BodyStyle CssText="border: solid 1px #868686;" />
                                        <ItemListStyle CssText="padding: 1px;" />
                                        <DisabledItemStyle CssText="color:#c0c0c0;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                                        <ItemStyle CssText="color:black;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                                        <ListBoxStyle CssText="font-family:Tahoma; font-size:13px;background-color:white;" />
                                        <MoreItemsMessageStyle CssText="padding:2px;" />
                                        <SelectedItemStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                                        <ItemHoverStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                                        <Items>
                                            <eo:ListBoxItem Text="None" />
                                            <eo:ListBoxItem Text="Low" />
                                            <eo:ListBoxItem Text="Medium" />
                                            <eo:ListBoxItem Text="High" />
                                        </Items>
                                    </eo:ListBox>
                                </DropDownTemplate>
                                <TextStyle CssText="font-family: tahoma; font-size: 11px;" />
                                <TextAreaStyle CssText="font-family: tahoma; font-size: 11px; border-top: solid 1px #3d7bad; border-bottom: solid 1px #b7d9ed; vertical-align:middle;padding-left:2px; padding-right:2px;" />
                                <ButtonStyle CssText="width:17px;height:23px;" />
                                <ButtonAreaStyle CssText="background-image:url(00107005);" />
                                <IconStyle CssText="display:none;" />
                                <ButtonAreaHoverStyle CssText="background-image:url(00107006);" />
                                <HintTextStyle CssText="font-style:italic;background-color:#c0c0c0;color:white;line-height:16px;" />
                            </eo:ComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Text Color:
                        </td>
                        <td>
                            <eo:ComboBox runat="server" ID="cbTextColor" ControlSkinID="None" Width="100px"
                                Text="Black" AllowCustomText="false">
                                <IconAreaStyle CssText="font-family: tahoma; font-size: 11px; background-image:url(00107007); background-position: left left; background-repeat:no-repeat; vertical-align:middle;padding-left:2px; padding-right:2px;" />
                                <DropDownTemplate>
                                    <eo:ListBox runat="server" ID="lbTextColor" ControlSkinID="None" Width="100px">
                                        <BodyStyle CssText="border: solid 1px #868686;" />
                                        <ItemListStyle CssText="padding: 1px;" />
                                        <DisabledItemStyle CssText="color:#c0c0c0;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                                        <ItemStyle CssText="color:black;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                                        <ListBoxStyle CssText="font-family:Tahoma; font-size:13px;background-color:white;" />
                                        <MoreItemsMessageStyle CssText="padding:2px;" />
                                        <SelectedItemStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                                        <ItemHoverStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                                        <Items>
                                            <eo:ListBoxItem Text="Black" />
                                            <eo:ListBoxItem Text="Red" />
                                            <eo:ListBoxItem Text="Green" />
                                            <eo:ListBoxItem Text="Yellow" />
                                        </Items>
                                    </eo:ListBox>
                                </DropDownTemplate>
                                <TextStyle CssText="font-family: tahoma; font-size: 11px;" />
                                <TextAreaStyle CssText="font-family: tahoma; font-size: 11px; border-top: solid 1px #3d7bad; border-bottom: solid 1px #b7d9ed; vertical-align:middle;padding-left:2px; padding-right:2px;" />
                                <ButtonStyle CssText="width:17px;height:23px;" />
                                <ButtonAreaStyle CssText="background-image:url(00107005);" />
                                <IconStyle CssText="display:none;" />
                                <ButtonAreaHoverStyle CssText="background-image:url(00107006);" />
                                <HintTextStyle CssText="font-style:italic;background-color:#c0c0c0;color:white;line-height:16px;" />
                            </eo:ComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Line Noise Level:
                        </td>
                        <td>
                            <eo:ComboBox runat="server" ID="cbLineNoiseLevel" ControlSkinID="None" Width="100px"
                                Text="Medium" AllowCustomText="false">
                                <IconAreaStyle CssText="font-family: tahoma; font-size: 11px; background-image:url(00107007); background-position: left left; background-repeat:no-repeat; vertical-align:middle;padding-left:2px; padding-right:2px;" />
                                <DropDownTemplate>
                                    <eo:ListBox runat="server" ID="lbLineNoiseLevel" ControlSkinID="None" Width="100px">
                                        <BodyStyle CssText="border: solid 1px #868686;" />
                                        <ItemListStyle CssText="padding: 1px;" />
                                        <DisabledItemStyle CssText="color:#c0c0c0;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                                        <ItemStyle CssText="color:black;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                                        <ListBoxStyle CssText="font-family:Tahoma; font-size:13px;background-color:white;" />
                                        <MoreItemsMessageStyle CssText="padding:2px;" />
                                        <SelectedItemStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                                        <ItemHoverStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                                        <Items>
                                            <eo:ListBoxItem Text="None" />
                                            <eo:ListBoxItem Text="Low" />
                                            <eo:ListBoxItem Text="Medium" />
                                            <eo:ListBoxItem Text="High" />
                                        </Items>
                                    </eo:ListBox>
                                </DropDownTemplate>
                                <TextStyle CssText="font-family: tahoma; font-size: 11px;" />
                                <TextAreaStyle CssText="font-family: tahoma; font-size: 11px; border-top: solid 1px #3d7bad; border-bottom: solid 1px #b7d9ed; vertical-align:middle;padding-left:2px; padding-right:2px;" />
                                <ButtonStyle CssText="width:17px;height:23px;" />
                                <ButtonAreaStyle CssText="background-image:url(00107005);" />
                                <IconStyle CssText="display:none;" />
                                <ButtonAreaHoverStyle CssText="background-image:url(00107006);" />
                                <HintTextStyle CssText="font-style:italic;background-color:#c0c0c0;color:white;line-height:16px;" />
                            </eo:ComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Line Color:
                        </td>
                        <td>
                            <eo:ComboBox runat="server" ID="cbLineColor" ControlSkinID="None" Width="100px"
                                Text="Black" AllowCustomText="false">
                                <IconAreaStyle CssText="font-family: tahoma; font-size: 11px; background-image:url(00107007); background-position: left left; background-repeat:no-repeat; vertical-align:middle;padding-left:2px; padding-right:2px;" />
                                <DropDownTemplate>
                                    <eo:ListBox runat="server" ID="lbLineColor" ControlSkinID="None" Width="100px">
                                        <BodyStyle CssText="border: solid 1px #868686;" />
                                        <ItemListStyle CssText="padding: 1px;" />
                                        <DisabledItemStyle CssText="color:#c0c0c0;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                                        <ItemStyle CssText="color:black;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                                        <ListBoxStyle CssText="font-family:Tahoma; font-size:13px;background-color:white;" />
                                        <MoreItemsMessageStyle CssText="padding:2px;" />
                                        <SelectedItemStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                                        <ItemHoverStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                                        <Items>
                                            <eo:ListBoxItem Text="Black" />
                                            <eo:ListBoxItem Text="Red" />
                                            <eo:ListBoxItem Text="Green" />
                                            <eo:ListBoxItem Text="Yellow" />
                                        </Items>
                                    </eo:ListBox>
                                </DropDownTemplate>
                                <TextStyle CssText="font-family: tahoma; font-size: 11px;" />
                                <TextAreaStyle CssText="font-family: tahoma; font-size: 11px; border-top: solid 1px #3d7bad; border-bottom: solid 1px #b7d9ed; vertical-align:middle;padding-left:2px; padding-right:2px;" />
                                <ButtonStyle CssText="width:17px;height:23px;" />
                                <ButtonAreaStyle CssText="background-image:url(00107005);" />
                                <IconStyle CssText="display:none;" />
                                <ButtonAreaHoverStyle CssText="background-image:url(00107006);" />
                                <HintTextStyle CssText="font-style:italic;background-color:#c0c0c0;color:white;line-height:16px;" />
                            </eo:ComboBox>
                        </td>
                    </tr>
                </table>
                <p>
                    <asp:Button runat="server" ID="btnApply" Text="Apply Options" 
                        onclick="btnApply_Click" />
                </p>
                
            </td>
            <td valign="top">
                <div style="width:20px;"></div>
            </td>
            <td valign="top" style="padding-top:5px;">
                <eo:Captcha runat="server" ID="Captcha1" PromptHtml="" ValidationGroup="captcha">
                    <ImageStyle CssText="border: solid 1px #c0c0c0; float: left;margin-right:5px;" />
                    <TextBoxStyle CssText="border: solid 1px #b7d9ed;margin-top:3px;padding-left:2px;padding-right:2px;padding-top:1px;padding-bottom:1px;width:146px;" />
                    <RefreshLinkStyle CssText="margin-left:5px;" />
                    <AudioLinkStyle CssText="margin-left:5px;margin-bottom:20px;" />
                </eo:Captcha>
                <p>
                    <asp:Button runat="server" ID="Button1" Text="Submit"  ValidationGroup="captcha" />
                </p>
                <p>
                    <asp:Label runat="server" ID="lblResult"></asp:Label>
                </p>
            </td>
        </tr>
    </table>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Color_Picker_Features_Target_Control_Demo"
    Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        ColorPicker can be associated with a TextBox, Label or Panel control and automatically
        updates the associated control's background color or text.
    </p>
    <p>
        <b>UpdateTargetColor</b> and <b>UpdateTargetText</b> can be used to specify whether
        to update background color or text.
    </p>
    <p>
        Using with TextBox control:
        <table border="0">
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="TextBox1" Width="80"></asp:TextBox>
                </td>
                <td>
                    <eo:ColorPicker runat="server" ID="ColorPicker1" ControlSkinID="None" TargetControl="TextBox1"
                        UpdateTargetColor="True">
                        <TextBoxStyle CssText="border-right: #7f9db9 1px solid; border-top: #7f9db9 1px solid; border-left: #7f9db9 1px solid; border-bottom: #7f9db9 1px solid">
                        </TextBoxStyle>
                        <PopupStyle CssText="border-right: #999999 1px solid; border-top: #999999 1px solid; font-size: 10pt; border-left: #999999 1px solid; color: #0751b8; border-bottom: #999999 1px solid; font-family: arial; background-color: white">
                        </PopupStyle>
                    </eo:ColorPicker>
                </td>
            </tr>
        </table>
    </p>
    <p>
        Using with Panel control:
        <table border="0">
            <tr>
                <td>
                    <asp:Panel runat="server" ID="Panel1" Height="20" Width="80" BorderStyle="Ridge">
                    </asp:Panel>
                </td>
                <td>
                    <eo:ColorPicker runat="server" ID="Colorpicker2" ControlSkinID="None" TargetControl="Panel1"
                        UpdateTargetColor="True">
                        <TextBoxStyle CssText="border-right: #7f9db9 1px solid; border-top: #7f9db9 1px solid; border-left: #7f9db9 1px solid; border-bottom: #7f9db9 1px solid">
                        </TextBoxStyle>
                        <PopupStyle CssText="border-right: #999999 1px solid; border-top: #999999 1px solid; font-size: 10pt; border-left: #999999 1px solid; color: #0751b8; border-bottom: #999999 1px solid; font-family: arial; background-color: white">
                        </PopupStyle>
                    </eo:ColorPicker>
                </td>
            </tr>
        </table>
    </p>
</asp:Content>

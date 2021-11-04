<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Color_Picker_Designs_Style_1_Demo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        These two color pickers use the default layout template but have <b>ColorModel</b>
        set to RGB and HSB respectively. <b>ColorModel</b> determines which set of textboxes
        (RGB or HSB) are displayed when using the default layout template.
    </p>
    <p>
        Color Picker using RGB Color Model:
        <eo:ColorPicker runat="server" ID="ColorPicker1" ControlSkinID="None">
            <TextBoxStyle CssText="border-right: #7f9db9 1px solid; border-top: #7f9db9 1px solid; border-left: #7f9db9 1px solid; border-bottom: #7f9db9 1px solid">
            </TextBoxStyle>
            <PopupStyle CssText="border-right: #999999 1px solid; border-top: #999999 1px solid; font-size: 10pt; border-left: #999999 1px solid; color: #0751b8; border-bottom: #999999 1px solid; font-family: arial; background-color: white">
            </PopupStyle>
        </eo:ColorPicker>
    </p>
    <p>
        Color Picker using HSB Color Model:
        <eo:ColorPicker runat="server" ID="Colorpicker2" ControlSkinID="None" ColorModel="HSB">
            <TextBoxStyle CssText="border-right: #7f9db9 1px solid; border-top: #7f9db9 1px solid; border-left: #7f9db9 1px solid; border-bottom: #7f9db9 1px solid">
            </TextBoxStyle>
            <PopupStyle CssText="border-right: #999999 1px solid; border-top: #999999 1px solid; font-size: 10pt; border-left: #999999 1px solid; color: #0751b8; border-bottom: #999999 1px solid; font-family: arial; background-color: white">
            </PopupStyle>
        </eo:ColorPicker>
    </p>
    <p>
        Color Picker using CMYK Color Model:
        <eo:ColorPicker runat="server" ID="Colorpicker3" ControlSkinID="None" ColorModel="CMYK">
            <TextBoxStyle CssText="border-right: #7f9db9 1px solid; border-top: #7f9db9 1px solid; border-left: #7f9db9 1px solid; border-bottom: #7f9db9 1px solid">
            </TextBoxStyle>
            <PopupStyle CssText="border-right: #999999 1px solid; border-top: #999999 1px solid; font-size: 10pt; border-left: #999999 1px solid; color: #0751b8; border-bottom: #999999 1px solid; font-family: arial; background-color: white">
            </PopupStyle>
        </eo:ColorPicker>
    </p>
</asp:Content>

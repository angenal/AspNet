<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Color_Picker_Features_Custom_Layout_Demo" Title="Untitled Page" %>
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    The layout of the color picker popup can be fully customized through <b>PopupLayoutTemplate</b>
    property. The following sample uses this property to provide a custom layout 
    template with only the color field and color slider.
</p>
<eo:ColorPicker runat="server" id="ColorPicker1" ControlSkinID="None">
    <TextBoxStyle CssText="border-right: #7f9db9 1px solid; border-top: #7f9db9 1px solid; border-left: #7f9db9 1px solid; border-bottom: #7f9db9 1px solid"></TextBoxStyle>
    <PopupStyle CssText="background-color:white;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;font-family:Verdana;font-size:10pt;padding-bottom:10px;padding-left:10px;padding-right:10px;padding-top:10px;"></PopupStyle>
    <PopupLayoutTemplate>
        <TABLE cellSpacing="2" cellPadding="0">
            <tr>
                <td>
                    <asp:PlaceHolder runat="server" ID="ColorField"></asp:PlaceHolder>
                </td>
                <td>
                    <asp:PlaceHolder runat="server" ID="SpectrumSlider"></asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:LinkButton runat="server" ID="OKButton">OK</asp:LinkButton>
                </td>
            </tr>
        </TABLE>
    </PopupLayoutTemplate>
</eo:ColorPicker>
</asp:Content>


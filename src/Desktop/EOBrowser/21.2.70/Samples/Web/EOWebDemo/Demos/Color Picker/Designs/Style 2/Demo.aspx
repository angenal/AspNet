<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Color_Picker_Designs_Style_2_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
These two color pickers use custom layout template through
<b>PopupLayoutTemplate</b> property. The custom layout itself,
rather than <b>ColorModel</b> defines which component textbox
to appear.
</p>
<p>
    Color Picker using RGB Color Model:
    <eo:ColorPicker runat="server" id="ColorPicker1" ControlSkinID="None">
        <TextBoxStyle CssText="border-right: #7f9db9 1px solid; border-top: #7f9db9 1px solid; border-left: #7f9db9 1px solid; border-bottom: #7f9db9 1px solid"></TextBoxStyle>
        <PopupStyle CssText="background-color:white;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;font-family:Verdana;font-size:10pt;padding-bottom:10px;padding-left:10px;padding-right:10px;padding-top:10px;"></PopupStyle>
        <PopupLayoutTemplate>
            <TABLE cellSpacing="2" cellPadding="0">
                <tr>
                    <td colspan="2">
                        <TABLE cellSpacing="2" cellPadding="0">
                            <tr>
                                <td width="100">
                                    <asp:Label runat="server" ID="TitleText">Select color:</asp:Label>
                                </td>
                                <td style="border: 1px solid lightgrey;" width="40">&nbsp;
                                    <asp:PlaceHolder runat="server" ID="AdjustedColor"></asp:PlaceHolder>
                                </td>
                            </tr>
                        </TABLE>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:PlaceHolder runat="server" ID="ColorField"></asp:PlaceHolder>
                    </td>
                    <td>
                        <asp:PlaceHolder runat="server" ID="SpectrumSlider"></asp:PlaceHolder>
                    </td>
                </tr>
            </TABLE>
            <TABLE cellSpacing="1" cellPadding="0">
                <TR>
                    <TD width="20">&nbsp;R:</TD>
                    <TD>
                        <asp:TextBox runat="server" ID="RTextBox" style="width:48px;"></asp:TextBox>
                    </TD>
                    <TD width="20">&nbsp;G:</TD>
                    <TD>
                        <asp:TextBox runat="server" ID="GTextBox" style="width:48px;"></asp:TextBox>
                    </TD>
                </TR>
                <TR>
                </TR>
                <TR>
                    <TD width="20">&nbsp;B:</TD>
                    <TD>
                        <asp:TextBox runat="server" ID="BTextBox" style="width:48px;"></asp:TextBox>
                    </TD>
                    <TD width="20">&nbsp;#</TD>
                    <TD>
                        <asp:TextBox runat="server" ID="WebColorTextBox" style="width:48px;"></asp:TextBox>
                    </TD>
                </TR>
                <tr>
                    <td colspan="4" align="center">
                        <asp:LinkButton runat="server" ID="OKButton">OK</asp:LinkButton>
                    </td>
                </tr>
            </TABLE>
        </PopupLayoutTemplate>
    </eo:ColorPicker>
</p>
<p>
    Color Picker using HSB Color Model:
    <eo:ColorPicker runat="server" id="Colorpicker2" ControlSkinID="None" ColorModel="HSB">
        <TextBoxStyle CssText="border-right: #7f9db9 1px solid; border-top: #7f9db9 1px solid; border-left: #7f9db9 1px solid; border-bottom: #7f9db9 1px solid"></TextBoxStyle>
        <PopupStyle CssText="background-color:white;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;font-family:Verdana;font-size:10pt;padding-bottom:10px;padding-left:10px;padding-right:10px;padding-top:10px;"></PopupStyle>
        <PopupLayoutTemplate>
            <TABLE cellSpacing="2" cellPadding="0">
                <tr>
                    <td colspan="2">
                        <TABLE cellSpacing="2" cellPadding="0">
                            <tr>
                                <td width="100">
                                    <asp:Label runat="server" ID="TitleText">Select color:</asp:Label>
                                </td>
                                <td style="border: 1px solid lightgrey;" width="40">&nbsp;
                                    <asp:PlaceHolder runat="server" ID="AdjustedColor"></asp:PlaceHolder>
                                </td>
                            </tr>
                        </TABLE>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:PlaceHolder runat="server" ID="ColorField"></asp:PlaceHolder>
                    </td>
                    <td>
                        <asp:PlaceHolder runat="server" ID="SpectrumSlider"></asp:PlaceHolder>
                    </td>
                </tr>
            </TABLE>
            <TABLE cellSpacing="1" cellPadding="0">
                <TR>
                    <TD width="20">&nbsp;H:</TD>
                    <TD>
                        <asp:TextBox runat="server" ID="HueTextBox" style="width:48px;"></asp:TextBox>
                    </TD>
                    <TD width="20">&nbsp;S:</TD>
                    <TD>
                        <asp:TextBox runat="server" ID="SatTextBox" style="width:48px;"></asp:TextBox>
                    </TD>
                </TR>
                <TR>
                </TR>
                <TR>
                    <TD width="20">&nbsp;B:</TD>
                    <TD>
                        <asp:TextBox runat="server" ID="BrtTextBox" style="width:48px;"></asp:TextBox>
                    </TD>
                    <TD width="20">&nbsp;#</TD>
                    <TD>
                        <asp:TextBox runat="server" ID="WebColorTextBox" style="width:48px;"></asp:TextBox>
                    </TD>
                </TR>
                <tr>
                    <td colspan="4" align="center">
                        <asp:LinkButton runat="server" ID="OKButton">OK</asp:LinkButton>
                    </td>
                </tr>
            </TABLE>
        </PopupLayoutTemplate>
    </eo:ColorPicker>
</p>
<p>
    Color Picker using CMYK Color Model:
    <eo:ColorPicker runat="server" id="Colorpicker3" ControlSkinID="None" ColorModel="CMYK">
        <TextBoxStyle CssText="border-right: #7f9db9 1px solid; border-top: #7f9db9 1px solid; border-left: #7f9db9 1px solid; border-bottom: #7f9db9 1px solid"></TextBoxStyle>
        <PopupStyle CssText="background-color:white;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;font-family:Verdana;font-size:10pt;padding-bottom:10px;padding-left:10px;padding-right:10px;padding-top:10px;"></PopupStyle>
        <PopupLayoutTemplate>
            <TABLE cellSpacing="2" cellPadding="0">
                <tr>
                    <td colspan="2">
                        <TABLE cellSpacing="2" cellPadding="0">
                            <tr>
                                <td width="100">
                                    <asp:Label runat="server" ID="TitleText">Select color:</asp:Label>
                                </td>
                                <td style="border: 1px solid lightgrey;" width="40">&nbsp;
                                    <asp:PlaceHolder runat="server" ID="AdjustedColor"></asp:PlaceHolder>
                                </td>
                            </tr>
                        </TABLE>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:PlaceHolder runat="server" ID="ColorField"></asp:PlaceHolder>
                    </td>
                    <td>
                        <asp:PlaceHolder runat="server" ID="SpectrumSlider"></asp:PlaceHolder>
                    </td>
                </tr>
            </TABLE>
            <TABLE cellSpacing="1" cellPadding="0">
                <TR>
                    <TD width="20">&nbsp;C:</TD>
                    <TD>
                        <asp:TextBox runat="server" ID="CTextBox" style="width:48px;"></asp:TextBox>
                    </TD>
                    <TD width="20">&nbsp;M:</TD>
                    <TD>
                        <asp:TextBox runat="server" ID="MTextBox" style="width:48px;"></asp:TextBox>
                    </TD>
                </TR>
                <TR>
                </TR>
                <TR>
                    <TD width="20">&nbsp;Y:</TD>
                    <TD>
                        <asp:TextBox runat="server" ID="YTextBox" style="width:48px;"></asp:TextBox>
                    </TD>
                    <TD width="20">&nbsp;K:</TD>
                    <TD>
                        <asp:TextBox runat="server" ID="KTextBox" style="width:48px;"></asp:TextBox>
                    </TD>
                </TR>
                <tr>
                    <td colspan="4" align="center">
                        <asp:LinkButton runat="server" ID="OKButton">OK</asp:LinkButton>
                    </td>
                </tr>
            </TABLE>
        </PopupLayoutTemplate>
    </eo:ColorPicker>
</p>
</asp:Content>


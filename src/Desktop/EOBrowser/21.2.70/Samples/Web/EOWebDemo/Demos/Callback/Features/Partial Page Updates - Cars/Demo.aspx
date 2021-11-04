<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Callback_Features_Partial_Page_Updates___Cars_Demo"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tr>
                <td valign="top" align="left">
                    Select a car:</td>
                <td valign="top" align="left">
                    Details:</td>
            </tr>
            <tr>
                <td width="200" valign="top" align="left">
                    <asp:RadioButton ID="rbBMW" runat="server" Text="BMW 325" GroupName="car"></asp:RadioButton><br>
                    <asp:RadioButton ID="rbMercedes" runat="server" Text="Mercedes-Bens CLK" GroupName="car"
                        AutoPostBack="True"></asp:RadioButton><br>
                    <asp:RadioButton ID="rbLexus" runat="server" Text="Lexus GS 430" GroupName="car"></asp:RadioButton></td>
                <td valign="top" align="left">
                    <eo:CallbackPanel ID="cbCars" runat="server" Triggers="{ControlID:rbBMW;Parameter:BMW},{ControlID:rbMercedes;Parameter:Mercedes-Bens},{ControlID:rbLexus;Parameter:Lexus}"
                        LoadingHTML="Loading..." Height="120px" Width="400px" OnExecute="cbCars_Execute">
                        <table>
                            <tr valign="top" align="left">
                                <td width="70">
                                    Maker:</td>
                                <td width="200">
                                    <asp:Label ID="lCarMake" runat="server" CssClass="Normal"></asp:Label></td>
                                <td width="200" rowspan="4">
                                    <asp:Image ID="imgCar" runat="server" Visible="False"></asp:Image></td>
                            </tr>
                            <tr valign="top" align="left">
                                <td>
                                    Model:</td>
                                <td>
                                    <asp:Label ID="lCarModel" runat="server" CssClass="Normal"></asp:Label></td>
                            </tr>
                            <tr valign="top" align="left">
                                <td>
                                    Body Style:</td>
                                <td>
                                    <asp:Label ID="lCarStyle" runat="server" CssClass="Normal"></asp:Label></td>
                            </tr>
                            <tr valign="top" align="left">
                                <td>
                                    Description:</td>
                                <td>
                                    <asp:Label ID="lCarDescription" runat="server" CssClass="Normal"></asp:Label></td>
                            </tr>
                        </table>
                    </eo:CallbackPanel>
                </td>
            </tr>
        </table>
    </p>
</asp:Content>

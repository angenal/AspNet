<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Captcha_Validation_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
    Using EO.Web Captcha is very similar to using standard ASP.NET
    validation controls. The following code demonstrates how to use
    standard ASP.NET validation controls and EO.Web Captcha together
    in the same validation group. The code:       
    </p>
    <ul>
        <li>Uses standard 
        <b>RequiredFieldValidator</b> for "Full Name" and "Email Filed";</li>
        <li>Set <b>ValidationGroup</b> to the same value for all standard validation controls,
            the EO.Web.Captcha control, and the "Submit" button; </li>
        <li>Leave the "Result" button's <b>ValidationGroup</b> empty (the default value);</li>
    </ul>
    <asp:Panel runat="server" ID="panInput">
        <h4>
            Sign Up</h4>
        <table border="0">
            <tr>
                <td>
                    Full Name:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ErrorMessage="Please enter your full name."
                        ValidationGroup="account" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Email Address:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ErrorMessage="Please enter your email address."
                        ValidationGroup="account" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Password:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPassword"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ErrorMessage="Please enter a password."
                        ValidationGroup="account" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <eo:Captcha runat="server" ID="Captcha1" PromptHtml="" ValidationGroup="account">
                        <ImageStyle CssText="border: solid 1px #c0c0c0; float: left;margin-right:5px;" />
                        <TextBoxStyle CssText="border: solid 1px #b7d9ed;margin-top:3px;padding-left:2px;padding-right:2px;padding-top:1px;padding-bottom:1px;width:146px;" />
                        <RefreshLinkStyle CssText="margin-left:5px;" />
                        <AudioLinkStyle CssText="margin-left:5px;margin-bottom:20px;" />
                    </eo:Captcha>
                    <p>
                        <asp:Button runat="server" ID="Button1" Text="Create Account" ValidationGroup="account" OnClick="Button1_Click" />&nbsp;&nbsp;
                        <asp:Button runat="server" ID="Button2" Text="Reset" OnClick="Button2_Click" />
                    </p>
                    <p>
                        <asp:Label runat="server" ID="lblResult"></asp:Label>
                    </p>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="panResult" Visible="false">
        <p>
            Account created.
        </p>
        <asp:Button runat="server" ID="Button3" Text="Try Again" OnClick="Button3_Click" />
    </asp:Panel>
</asp:Content>

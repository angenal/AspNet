<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="Stylesheet" href="Demo.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
        This page together with FormAuth.aspx demonstrates how to use EO.Pdf HTML
        to PDF converter to convert an ASP.NET Web page that requires forms 
        authentication. Please see "Using HTML to PDF -> Web Page Authentication
        -> Form Authentication" in the help file for more details.
        </p>
        <p>Please use user name "eopdf" and password "eopdf" to login:</p>
        <table>
            <tr>
                <td>
                    User Name: 
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUserName" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Password:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPassword" Width="150px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <p>
            <asp:Button runat="server" ID="btnLogin" Text="Login" 
                onclick="btnLogin_Click" />        
        </p>
        <asp:Label runat="server" ID="lblError" ForeColor="Red" Visible=false>Invalid user name and password.</asp:Label>
    </div>
    </form>
</body>
</html>

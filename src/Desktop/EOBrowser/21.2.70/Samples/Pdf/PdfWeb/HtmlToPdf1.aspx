<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HtmlToPdf1.aspx.cs" Inherits="HtmlToPdf1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HTML to PDF Demo</title>
    <link rel="Stylesheet" href="Demo.css" />
</head>
<body>
    <form id="form1" runat="server" onsubmit="before_convert()">
    <div>

        <script type="text/javascript">
            function before_convert()
            {
                document.getElementById("divInput").style.display = "none";
                document.getElementById("divWait").style.display = "";
            }     
        </script>

        <h4>
            HTML to PDF Demo</h4>
        <div id="divInput">
            <p>
                This sample demonstrates how to convert a Url to PDF and send
                it to the client on the fly without actually creating a 
                physical file.
            </p>
            <p>
                Please enter a Url to convert:
            </p>
            <asp:TextBox runat="server" ID="txtUrl" Width="350px" Text="http://www.google.com"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUrl"
                ErrorMessage="Url is required."></asp:RequiredFieldValidator>
            <p>
                <asp:Button runat="server" ID="btnConvert" Text="Convert" 
                    OnClick="btnConvert_Click" />
            </p>
        </div>
        <div id="divWait" style="display:none">
            <p>
            Please wait.....
            </p>
        </div>
    </div>
    </form>
</body>
</html>

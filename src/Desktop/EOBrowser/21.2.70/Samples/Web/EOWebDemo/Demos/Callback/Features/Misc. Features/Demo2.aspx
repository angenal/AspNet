<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Demo2.aspx.cs" Inherits="Demos_Callback_Features_Misc_Features_Demo2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../../../../EOWebDemo.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="normal">
            <h1>
                Debug Support &amp; Server Redirect</h1>
            <p>
                Check the following checkbox and click "Execute Callback" to see how EO.Web CallbackPanel
                handles server side code error.
            </p>
            <eo:CallbackPanel runat="server" ID="CallbackPanel1" Width="450px" Height="60px"
                Triggers="{ControlID:Button1;Parameter:}">
                <p>
                    <asp:CheckBox ID="cbError" runat="server" Text="Generate a server side error"></asp:CheckBox></p>
                <p>
                    <asp:CheckBox ID="cbRedirect" runat="server" Text="Perform a server side redirect"></asp:CheckBox></p>
                <p>
                    <asp:Label ID="lblOK" runat="server" Visible="False"></asp:Label></p>
                <asp:Button ID="Button1" runat="server" Text="Execute Callback" OnClick="Button1_Click">
                </asp:Button>
            </eo:CallbackPanel>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebAuth.aspx.cs" Inherits="WebAuth" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="Demo.css" />
</head>
<body class="normal">
    <form id="form1" runat="server">
    <div>
        <p>
            This is a server side test page for the <b>Web Authentication</b>
            demo found in <b>EOPdfDemo</b> application. To access this page,
            you must use user name "eopdf" and password "eopdf". In order for
            EO.Pdf HTML to PDF converter to access this page, you must set
            <b>HtmlToPdf.Options.UserName</b> and <b>HtmlToPdf.Options.Password</b>
            to the proper user name and password.
        </p>
    </div>
    </form>
</body>
</html>

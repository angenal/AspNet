<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Content3.aspx.cs" Inherits="Demos_Menu_Features_Cross_Frame_Content3" %>
    <link href="/EOWebDemo/EO.css" type="text/css" rel="stylesheet">

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link runat="server" href="~/EOWebDemo.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <p class="normal">
            Non-HTML files, such as Adobe .pdf, should be enclosed with an IFRAME or EMBED tag
            so that the content page is still a valid HTML file.
        </p>
        <iframe src="Sample.pdf" width="700px" height="600px"></iframe>
    </form>
</body>
</html>

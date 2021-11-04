<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebPost.aspx.cs" Inherits="WebPost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="Demo.css" />
</head>
<body class="normal">
    <form id="form1" runat="server">
    <div>
        <asp:Panel runat="server" id="panInfo">
            <p>
            This is a server side test page for the <b>Web Post</b>
            demo found in <b>EOPdfDemo</b> application. This page
            accepts several form variables and creates a list of 
            "address labels" based on these variables. To run the 
            demo, please follow these steps:
            </p>
            <ol>
                <li>start <i>EOPdfDemo</i> demo application;</li>
                <li>Select <i>All Demos -> HTML to PDF -> Web Post Back</i> from the tree view;</li>
                <li>Copy the Url of this page into the <i>Url</i> field if the demo application
                did not automatically detect and fill the Url;</li>
                <li>Fill in the address form;</li>
                <li>Click <i>Run Demo</i> to run the demo;</li>
            </ol>            
        </asp:Panel>
        <asp:Panel runat="server" ID="panResult" Visible="false">
            <p>
            Thanks for filling in the form. Here are your 
            address labels! This page is automatically generated
            by ASP.NET based on the information you posted to
            the page.
            </p>
            <table cellpadding="10">
                <asp:Repeater runat="server" id="rptAddrList">
                    <ItemTemplate>
                        <tr>
                            <td style="border: dashed 1px #c0c0c0; width:200px;">
                                <%#Name%><br />
                                <%#Addr1%><br />
                                <%#Addr2%><br />
                                <%#City%>, <%#State%>, <%#Zip%>
                            </td>                            
                            <td style="border: dashed 1px #c0c0c0; width:200px;">
                                <%#Name%><br />
                                <%#Addr1%><br />
                                <%#Addr2%><br />
                                <%#City%>, <%#State%>, <%#Zip%>
                            </td>
                            <td style="border: dashed 1px #c0c0c0; width:200px;">
                                <%#Name%><br />
                                <%#Addr1%><br />
                                <%#Addr2%><br />
                                <%#City%>, <%#State%>, <%#Zip%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>

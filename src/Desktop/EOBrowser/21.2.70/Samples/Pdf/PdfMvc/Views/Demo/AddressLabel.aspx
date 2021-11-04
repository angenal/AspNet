<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MvcDemo.Models.AddressModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>AddressLabel</title>
</head>
<body style="font-family:Verdana; font-size:12px;">
    <table>
        <% for (int i = 0; i < 10; i++)
           { %>
                <tr>
                    <% for (int j = 0; j < 3; j++)
                       { %>
                            <td>
                                <%=Model.Name%> <br />
                                <%=Model.AddressLine1%> <br />
                                <%=Model.AddressLine2%> <br />
                                <%=Model.AddressLine3%> <br />
                            </td>
                    <% } %>
                </tr>
        <% } %>
    </table>
</body>
</html>

<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MvcDemo.Models.AddressModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Input</title>
</head>
<body style="font-family:Verdana; font-size:12px;">
    <p>
        This sample demonstrates how to use EO.Pdf MVCToPDF to render a MVC page to PDF. This sample
        contains two pages: an Input page (this page) for user to enter an address, and an AddressLabel
        page that repeats the same address to create an address label page. 
    </p>
    <div>
        <% using (Html.BeginForm()) { %>
            <table>
                <tr>
                    <td><%= Html.LabelFor(m => m.Name) %></td>
                    <td><%= Html.TextBoxFor(m => m.Name, new { @Value = "Name"}) %></td>
                </tr>
                <tr>
                    <td><%= Html.LabelFor(m => m.AddressLine1)%></td>
                    <td><%= Html.TextBoxFor(m => m.AddressLine1, new { @Value = "Address Line 1"}) %></td>
                </tr>
                <tr>
                    <td><%= Html.LabelFor(m => m.AddressLine2)%></td>
                    <td><%= Html.TextBoxFor(m => m.AddressLine2, new { @Value = "Address Line 2"}) %></td>
                </tr>
                <tr>
                    <td><%= Html.LabelFor(m => m.AddressLine3)%></td>
                    <td><%= Html.TextBoxFor(m => m.AddressLine3, new { @Value = "Address Line 3"}) %></td>
                </tr>
            </table>
            <%=Html.CheckBoxFor(m => m.ExportToPDF, new { @checked = "checked" })%>
            <%=Html.LabelFor(m => m.ExportToPDF) %>
            <p>
                Check the "Export to PDF" checkbox if you wish to render the result
                as PDF. If you do not check this checkbox, the result will be rendered as HTML
                directly in your browser.
            </p>
            <%=Html.CheckBoxFor(m => m.SaveAsFile)%>
            <%=Html.LabelFor(m => m.SaveAsFile)%>      
            <p>
                Check the "Save As File" checkbox if you do not wish the conversion result
                to be sent back to the client browser. In this case you must provide
                a post conversion callback when calling RenderAsPDF, then use MVCToPDF.Result to
                access the conversion result. The source of this sample demonstrates how
                this is done but does not actually save the result to a physical file.
            </p>
            <p>
                <input type="submit" value="Create Address Labels" />
            </p>
            <p>
                Click the above button to invoke the "AddressLabel" view with the address
                you entered. 
            </p>
        <% } %>      
    </div>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ASPXToPDF.aspx.cs" Inherits="ASPXToPDF" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASPX To PDF Demo</title>
    <link rel="Stylesheet" href="Demo.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <eo:ASPXToPDF runat="server" ID="ASPXToPDF1"></eo:ASPXToPDF>
        <p>
            This page demonstrates how to use EO.Web.ASPXToPDF control to render an ASP.NET
            page to PDF. It stores a list of "Notes" in session variable, then lists all
            the notes when outputs to PDF file. Please use the "Add" button to add a few
            notes to the note list, then click "Render as PDF" to render the page as PDF.</p>
        <h4>Note List</h4>
        <asp:Panel runat="server" ID="panListEmpty">
            Note list is empty. Please enter something in the text box
            below, then click "Add" to add it to the note list.          
        </asp:Panel>
        <asp:Repeater runat="server" ID="rptNotes">
            <ItemTemplate>
                <p>
                    Note #<%#Container.ItemIndex + 1%>:
                </p>
                <p>
                    <%#Server.HtmlEncode(Container.DataItem.ToString())%>
                </p>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Panel runat="server" ID="panAdd">
            <h4>Add Note</h4>
            <p>
                Please enter a note, then click "Add" to add it to the list.
            </p>
            <asp:TextBox runat="server" ID="txtNote" Width="400" Height="100" TextMode="MultiLine">
            </asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredValidator"
             ControlToValidate="txtNote" ErrorMessage="Please enter a note.">
            </asp:RequiredFieldValidator>
            <p>
                <asp:Button runat="server" ID="btnAdd" Text="Add Note" OnClick="btnAdd_Click" />
            </p>
        </asp:Panel>
        <asp:Panel runat="server" ID="panToPDF">
            <h4>Render as PDF</h4>
            <p>
                Once you've added a few notes, click "Render as PDF" to render the current page
                as PDF.
            </p>
            <p>
                <asp:Button runat="server" ID="btnToPDF" Text="Render as PDF" OnClick="btnToPDF_Click" />
            </p>
        </asp:Panel>
    </div>
    </form>
</body>
</html>

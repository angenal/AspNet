<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Callback_Features_Partial_Page_Updates___DataGrid_Demo"
    Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        Click field title to sort by the field. The sorting is executed on the server side.
    </p>
    <eo:CallbackPanel runat="server" ID="CallbackPanel1" Triggers="{ControlID:DataGrid1;Parameter:}">
        <asp:DataGrid ID="DataGrid1" runat="server" Width="500px" CellPadding="2" AutoGenerateColumns="True"
            AllowSorting="True" BorderWidth="1px" BorderColor="Gainsboro" OnSortCommand="DataGrid1_SortCommand">
        </asp:DataGrid>
    </eo:CallbackPanel>
</asp:Content>

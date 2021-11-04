<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Callback_Features_Partial_Page_Updates___DataGrid_Advanced_Demo" Title="Untitled Page" %>
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>Click <span class="highlight">Edit</span> to edit each row. Each combobox is 
    filled dynamically by calling server side code.
</p>
<eo:callbackpanel id="CallbackPanel1" Height="300px" Triggers="{ControlID:DataGrid1;Parameter:}" runat="server"
     OnExecute="CallbackPanel1_Execute">
    <asp:DataGrid id="DataGrid1" runat="server" BorderColor="Gainsboro" BorderWidth="1px" AutoGenerateColumns="False"
        CellPadding="2" Width="500px" OnItemCommand="DataGrid1_ItemCommand"
          OnItemDataBound="DataGrid1_ItemDataBound">
        <Columns>
            <asp:ButtonColumn Text="Edit" HeaderText="Edit" CommandName="Select"></asp:ButtonColumn>
            <asp:TemplateColumn HeaderText="Maker">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Maker") %>'>
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList Runat="server" ID="cbMaker" style="width:100px" AutoPostBack="True"></asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Model" ItemStyle-Width="80px">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Model") %>'>
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList Runat="server" ID="cbModel" style="width:80px" AutoPostBack="True"></asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Style" ItemStyle-Width="80px">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Style") %>'>
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList Runat="server" ID="cbStyle" style="width:80px" AutoPostBack="True"></asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Description">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label Runat="server" ID="lblDesc"></asp:Label>
                </EditItemTemplate>
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
</eo:callbackpanel>
</asp:Content>


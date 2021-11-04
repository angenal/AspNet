<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ImageZoom_Programming_ImageZoom_with_DataGrid_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    This sample demonstrates how to use ImageZoom control with a standard ASP.NET 
    Repeater control.
</p>
<asp:DataGrid id="DataGrid1" BorderColor="Gainsboro" BorderWidth="1px" Runat="server" Width="450px"
    CellPadding="2" AutoGenerateColumns="False">
    <HeaderStyle CssClass="grid_header"></HeaderStyle>
    <Columns>
        <asp:BoundColumn DataField="Desc" HeaderText="Description"></asp:BoundColumn>
        <asp:TemplateColumn HeaderText="Image">
            <ItemTemplate>
                <eo:ImageZoom runat="server" id="ImageZoom1" SmallImageUrl='<%#DataBinder.Eval(Container.DataItem, "SmallImage")%>' BigImageUrl='<%#DataBinder.Eval(Container.DataItem, "BigImage")%>' Description='<%#DataBinder.Eval(Container.DataItem, "Desc")%>' LoadingPanelID="loading">
                    <ZoomPanelStyle CssText="background-color:#ffffff;border:solid #d0d0d0 1px;padding:5px;"></ZoomPanelStyle>
                </eo:ImageZoom>
            </ItemTemplate>
        </asp:TemplateColumn>
    </Columns>
</asp:DataGrid>
<div id="loading" style="display:none; border: solid 1px black; background-color:White; padding: 6px 20px 6px 20px">Loading...</div>
</asp:Content>


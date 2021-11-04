<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Grid_Features_Fixed_Columns_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web Grid supports fixed columns. Fixed columns stay on the left side of the 
    grid and do not scroll when the grid scrolls. To enable fixed columns, set the 
    grid's <b>FixedColumnCount</b> to a number greater than 0. Styles for fixed
    columns are specified by <b>FixedColumnCellStyle</b>.
</p>
<eo:CallbackPanel runat="server" id="CallbackPanel1" Height="260px" Width="480px" LoadingHTML="Loading..."
    Triggers="{ControlID:DropDownList1;Parameter:}">
    <P>Choose Number of Fixed Columns:
        <asp:DropDownList id="DropDownList1" Width="64px" Runat="server"
             OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="0">0</asp:ListItem>
            <asp:ListItem Value="1">1</asp:ListItem>
            <asp:ListItem Value="2">2</asp:ListItem>
            <asp:ListItem Value="3">3</asp:ListItem>
        </asp:DropDownList></P>
    <eo:Grid id="Grid1" runat="server" BorderWidth="1px" Font-Size="8.75pt" Font-Names="Tahoma"
        ColumnHeaderDividerImage="00050103" GridLineColor="220, 223, 228" BorderColor="#7F9DB9"
        GridLines="Both" GoToBoxVisible="True" ColumnHeaderAscImage="00050104" ColumnHeaderDescImage="00050105"
        Height="200px" Width="450px" AllowColumnReorder="True">
        <FooterStyle CssText="padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px;"></FooterStyle>
        <ItemStyles>
            <eo:GridItemStyleSet>
                <CellStyle CssText="padding-left:8px;padding-top:2px;"></CellStyle>
                <FixedColumnCellStyle CssText="border-right: #d6d2c2 1px solid; padding-right: 10px; border-top: #faf9f4 1px solid; border-left: #faf9f4 1px solid; border-bottom: #d6d2c2 1px solid; background-color: #ebeadb; text-align: right"></FixedColumnCellStyle>
            </eo:GridItemStyleSet>
        </ItemStyles>
        <GoToBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; BORDER-TOP: #7f9db9 1px solid; BORDER-LEFT: #7f9db9 1px solid; WIDTH: 40px; BORDER-BOTTOM: #7f9db9 1px solid"></GoToBoxStyle>
        <ContentPaneStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;"></ContentPaneStyle>
        <Columns>
            <eo:RowNumberColumn Width="40"></eo:RowNumberColumn>
            <eo:StaticColumn HeaderText="Posted At" DataField="PostedAt"></eo:StaticColumn>
            <eo:StaticColumn HeaderText="Posted By" DataField="PostedBy"></eo:StaticColumn>
            <eo:StaticColumn Width="300" HeaderText="Topic" DataField="Topic"></eo:StaticColumn>
        </Columns>
        <ColumnHeaderStyle CssText="background-image:url('00050101');padding-left:8px;padding-top:3px;"></ColumnHeaderStyle>
    </eo:Grid>
</eo:CallbackPanel>
</asp:Content>


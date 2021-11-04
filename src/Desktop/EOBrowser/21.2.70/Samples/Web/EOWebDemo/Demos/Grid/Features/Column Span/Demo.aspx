<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Grid_Features_Column_Span_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    Note: This sample is based on the <a href="javascript:GoToDemo('grid_fixed_items')">
        Fixed Items</a> sample, make sure you review that sample first.
</p>
<p>
    EO.Web Grid supports <b>ColSpan</b> on grid cells. In the following Grid, the <b>ColSpan</b>
    property for the "Accessories", "Discount" and "Total" cell are set to 2.
</p>
<p>
    <eo:Grid id="Grid1" Width="450px" Height="200px" runat="server" BorderWidth="1px" Font-Size="8.75pt"
        Font-Names="Tahoma" ColumnHeaderDividerImage="00050103" GridLineColor="220, 223, 228"
        BorderColor="#7F9DB9" GridLines="Both" GoToBoxVisible="True" ColumnHeaderAscImage="00050104"
        ColumnHeaderDescImage="00050105" FixedTopItemCount="3" FixedBottomItemCount="2">
        <ContentPaneStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;"></ContentPaneStyle>
        <FixedBottomItemStyle CssText="background-color:#f0f0f0;"></FixedBottomItemStyle>
        <Columns>
            <eo:StaticColumn Width="200" StyleField="ItemStyle" HeaderText="Item" DataField="ItemName"></eo:StaticColumn>
            <eo:StaticColumn Width="50" HeaderText="Qty" DataField="Qty"></eo:StaticColumn>
            <eo:StaticColumn StyleField="AmountStyle" HeaderText="Amount" DataField="Amount"></eo:StaticColumn>
        </Columns>
        <GoToBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; BORDER-TOP: #7f9db9 1px solid; BORDER-LEFT: #7f9db9 1px solid; WIDTH: 40px; BORDER-BOTTOM: #7f9db9 1px solid"></GoToBoxStyle>
        <ColumnHeaderStyle CssText="background-image:url('00050101');padding-left:8px;padding-top:3px;"></ColumnHeaderStyle>
        <FooterStyle CssText="padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px;"></FooterStyle>
        <ItemStyles>
            <eo:GridItemStyleSet>
                <CellStyle CssText="padding-left:8px;padding-top:2px;"></CellStyle>
                <FixedColumnCellStyle CssText="border-right: #d6d2c2 1px solid; padding-right: 10px; border-top: #faf9f4 1px solid; border-left: #faf9f4 1px solid; border-bottom: #d6d2c2 1px solid; background-color: #ebeadb; text-align: right"></FixedColumnCellStyle>
            </eo:GridItemStyleSet>
        </ItemStyles>
        <FixedTopItemStyle CssText="background-color:#f0f0f0;"></FixedTopItemStyle>
    </eo:Grid>
</p>
</asp:Content>


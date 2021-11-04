<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Grid_Features_Column_Reordering_Demo"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        Set <b>AllowColumnReorder</b> to <b>true</b> to enable column reordering. Try drag
        and drop a column in the grid below to reorder columns.
    </p>
    <eo:CallbackPanel runat="server" ID="CallbackPanel1" Width="480px" Height="230px"
        LoadingHTML="Loading..." Triggers="{ControlID:Button1;Parameter:}">
        <eo:Grid ID="Grid1" AllowColumnReorder="True" Width="450px" Height="200px" ColumnHeaderDescImage="00050105"
            ColumnHeaderAscImage="00050104" FixedColumnCount="1" GoToBoxVisible="True" GridLines="Both"
            BorderColor="#7F9DB9" GridLineColor="220, 223, 228" ColumnHeaderDividerImage="00050103"
            Font-Names="Tahoma" Font-Size="8.75pt" BorderWidth="1px" runat="server" OnColumnReorder="Grid1_ColumnReorder">
            <FooterStyle CssText="padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px;">
            </FooterStyle>
            <ItemStyles>
                <eo:GridItemStyleSet>
                    <CellStyle CssText="padding-left:8px;padding-top:2px;"></CellStyle>
                    <FixedColumnCellStyle CssText="border-right: #d6d2c2 1px solid; padding-right: 10px; border-top: #faf9f4 1px solid; border-left: #faf9f4 1px solid; border-bottom: #d6d2c2 1px solid; background-color: #ebeadb; text-align: right">
                    </FixedColumnCellStyle>
                </eo:GridItemStyleSet>
            </ItemStyles>
            <GoToBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; BORDER-TOP: #7f9db9 1px solid; BORDER-LEFT: #7f9db9 1px solid; WIDTH: 40px; BORDER-BOTTOM: #7f9db9 1px solid">
            </GoToBoxStyle>
            <ContentPaneStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;">
            </ContentPaneStyle>
            <Columns>
                <eo:RowNumberColumn Width="40">
                </eo:RowNumberColumn>
                <eo:StaticColumn HeaderText="Posted At" DataField="PostedAt">
                </eo:StaticColumn>
                <eo:StaticColumn HeaderText="Posted By" DataField="PostedBy">
                </eo:StaticColumn>
                <eo:StaticColumn Width="300" HeaderText="Topic" DataField="Topic">
                </eo:StaticColumn>
            </Columns>
            <ColumnHeaderStyle CssText="background-image:url('00050101');padding-left:8px;padding-top:3px;">
            </ColumnHeaderStyle>
        </eo:Grid>
    </eo:CallbackPanel>
    <p>
        Column order changes are persisted when page post backs. Click the "Post Back" button
        to see it in action.
    </p>
    <asp:Button runat="server" ID="Button1" Text="Post Back!"></asp:Button>
</asp:Content>

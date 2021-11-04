<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Grid_Features_Client_Running_Mode_Demo"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        In client running mode, EO.Web Grid download all item data to the client side. Sorting
        and paging are also done on the client side.
    </p>
    <eo:CallbackPanel runat="server" ID="CallbackPanel1" Triggers="{ControlID:btnPaging;Parameter:},{ControlID:btnSorting;Parameter:},{ControlID:btnScroll;Parameter:}"
        Height="300px" Width="450px" LoadingHTML="Loading..." SafeGuardUpdate="False">
        <p>
            <asp:CheckBox ID="btnPaging" Text="Enable Paging" runat="server" OnCheckedChanged="btnPaging_CheckedChanged">
            </asp:CheckBox>&nbsp;
            <asp:CheckBox ID="btnSorting" Text="Enable Sorting" runat="server" OnCheckedChanged="btnSorting_CheckedChanged">
            </asp:CheckBox>&nbsp;
            <asp:CheckBox ID="btnScroll" Text="Enable Scroll Bars" runat="server" Checked="True"
                Enabled="False" OnCheckedChanged="btnScroll_CheckedChanged"></asp:CheckBox></p>
        <p>
            <eo:Grid ID="Grid1" Width="450px" Height="200px" runat="server" BorderWidth="1px"
                Font-Size="8.75pt" Font-Names="Tahoma" ColumnHeaderDividerImage="00050103" GridLineColor="220, 223, 228"
                BorderColor="#7F9DB9" GridLines="Both" GoToBoxVisible="True" FixedColumnCount="1"
                ColumnHeaderAscImage="00050104" ColumnHeaderDescImage="00050105">
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
        </p>
    </eo:CallbackPanel>
</asp:Content>

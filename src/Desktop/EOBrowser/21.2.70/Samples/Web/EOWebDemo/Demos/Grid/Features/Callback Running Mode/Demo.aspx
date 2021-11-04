<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Grid_Features_Callback_Running_Mode_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    Callback running mode is almost identical to server running mode, except that 
    sorting and paging are performed through an AJAX callback rather than a page 
    postback.
</p>
<P>
    As demonstrated in the <a href="javascript:GoToDemo('grid_server_mode');">Server 
        Running Mode</a>, using an EO.Web CallbackPanel and a grid running in 
    server mode can achieve similar result. With Callback running mode, you no 
    longer need a separate CallbackPanel control.
</P>
<p>
    <eo:Grid id="Grid1" runat="server" BorderWidth="1px" Font-Size="8.75pt" Font-Names="Tahoma"
        ColumnHeaderDescImage="00050105" FixedColumnCount="1" Width="450px" ColumnHeaderDividerImage="00050103"
        GridLineColor="220, 223, 228" BorderColor="#7F9DB9" GridLines="Both" GoToBoxVisible="True"
        Height="200px" ColumnHeaderAscImage="00050104" AllowPaging="True" RunningMode="Callback"
        OnPageIndexChanged="Grid1_PageIndexChanged" OnColumnSort="Grid1_ColumnSort">
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
            <eo:StaticColumn SortOrder="Descending" DataField="PostedAt" AllowSort="True" HeaderText="Posted At"></eo:StaticColumn>
            <eo:StaticColumn DataField="PostedBy" AllowSort="True" HeaderText="Posted By"></eo:StaticColumn>
            <eo:StaticColumn DataField="Topic" AllowSort="True" HeaderText="Topic" Width="300"></eo:StaticColumn>
        </Columns>
        <ColumnHeaderStyle CssText="background-image:url('00050101');padding-left:8px;padding-top:3px;"></ColumnHeaderStyle>
    </eo:Grid>
</p>
</asp:Content>


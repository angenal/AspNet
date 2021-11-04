<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Grid_Features_Server_Running_Mode_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    Server mode is designed to handle large data set. Even in server mode, EO.Web 
    still performs most work (such as editing and deleting) on the client side with 
    the following two distinctive exceptions:
</p>
<ul>
    <li>
    Performs sorting and paging on the server side;</li>
    <li>
        Only renders data for the current page to the client;</li>
</ul>
<p>
    The following Grid has <b>RunningMode</b> set to <b>Server</b> and also has 
    sorting and paging enabled. Try to page or sort the grid to observe it reloads 
    from the server.
</p>
<eo:CallbackPanel id="CallbackPanel1" runat="server" Width="450px" Height="230px" Triggers="{ControlID:Grid1;Parameter:}"
    LoadingHTML="Loading...">
    <eo:Grid id="Grid1" Height="200px" Width="450px" runat="server" RunningMode="Server" AllowPaging="True"
        FixedColumnCount="1" BorderColor="#7F9DB9" BorderWidth="1px" ColumnHeaderDescImage="00050105"
        ColumnHeaderAscImage="00050104" GoToBoxVisible="True" GridLineColor="220, 223, 228" GridLines="Both"
        ColumnHeaderDividerImage="00050103" Font-Size="8.75pt" Font-Names="Tahoma"
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
            <eo:StaticColumn SortOrder="Ascending" DataField="PostedAt" AllowSort="True" HeaderText="Posted At"></eo:StaticColumn>
            <eo:StaticColumn DataField="PostedBy" AllowSort="True" HeaderText="Posted By"></eo:StaticColumn>
            <eo:StaticColumn DataField="Topic" AllowSort="True" HeaderText="Topic" Width="300"></eo:StaticColumn>
        </Columns>
        <ColumnHeaderStyle CssText="background-image:url('00050101');padding-left:8px;padding-top:3px;"></ColumnHeaderStyle>
    </eo:Grid>
</eo:CallbackPanel>
</asp:Content>


<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Grid_Features_Conditional_Formatting___Cell_Based_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<style>
    .negative_balance 
    { 
        background-color:Red;
        padding-left: 4px;
    }
</style>
<p>
    EO.Web Grid supports cell based conditional formatting --- that is, applying 
    different styles based on conditions on the cell level. The following sample 
    displays an account list and their balances, with balance below zero 
    highlighted as red.
</p>
<P>
    <eo:Grid id="Grid1" runat="server" FixedColumnCount="1" BorderColor="#7F9DB9" BorderWidth="1px"
        ColumnHeaderDescImage="00050105" ColumnHeaderAscImage="00050104" GoToBoxVisible="True"
        GridLineColor="220, 223, 228" GridLines="Both" ColumnHeaderDividerImage="00050103" Font-Size="8.75pt"
        Font-Names="Tahoma" Width="380px" Height="200px" IsCallbackByMe="False" StyleIDField="StyleSet">
        <ColumnHeaderStyle CssText="background-image:url('00050101');padding-left:8px;padding-top:3px;"></ColumnHeaderStyle>
        <ColumnTemplates>
            <eo:TextBoxColumn>
                <TextBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 8.75pt; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; FONT-FAMILY: Tahoma"></TextBoxStyle>
            </eo:TextBoxColumn>
            <eo:DateTimeColumn>
                <DatePicker SelectedDates="" OtherMonthDayVisible="True" DisabledDates="" DayHeaderFormat="FirstLetter"
                    DayCellWidth="19" TitleRightArrowImageUrl="DefaultSubMenuIcon" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
                    DayCellHeight="16" ControlSkinID="None">
                    <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma"></CalendarStyle>
                    <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
                    <PickerStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;font-family:Courier New;font-size:8pt;margin-bottom:0px;margin-left:0px;margin-right:0px;margin-top:0px;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></PickerStyle>
                    <SelectedDayStyle CssText="font-family: tahoma; font-size: 12px; background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></SelectedDayStyle>
                    <TodayStyle CssText="font-family: tahoma; font-size: 12px; border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid"></TodayStyle>
                    <MonthStyle CssText="font-family: tahoma; font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px"></MonthStyle>
                    <DayHoverStyle CssText="font-family: tahoma; font-size: 12px; border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid"></DayHoverStyle>
                    <DisabledDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></DisabledDayStyle>
                    <DayHeaderStyle CssText="font-family: tahoma; font-size: 12px; border-bottom: #aca899 1px solid"></DayHeaderStyle>
                    <OtherMonthDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></OtherMonthDayStyle>
                    <DayStyle CssText="font-family: tahoma; font-size: 12px; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></DayStyle>
                    <TitleStyle CssText="background-color:#9ebef5;font-family:Tahoma;font-size:12px;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;"></TitleStyle>
                </DatePicker>
            </eo:DateTimeColumn>
            <eo:MaskedEditColumn>
                <MaskedEdit ControlSkinID="None" TextBoxStyle-CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; font-family:Courier New;font-size:8pt;"></MaskedEdit>
            </eo:MaskedEditColumn>
        </ColumnTemplates>
        <FooterStyle CssText="padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px;"></FooterStyle>
        <ContentPaneStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;"></ContentPaneStyle>
        <GoToBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; BORDER-TOP: #7f9db9 1px solid; BORDER-LEFT: #7f9db9 1px solid; WIDTH: 40px; BORDER-BOTTOM: #7f9db9 1px solid"></GoToBoxStyle>
        <ItemStyles>
            <eo:GridItemStyleSet>
                <ItemHoverStyle CssText="background-color: whitesmoke"></ItemHoverStyle>
                <SelectedStyle CssText="background-color:#316ac5;color:white;"></SelectedStyle>
                <CellStyle CssText="padding-left:8px;padding-top:2px;"></CellStyle>
                <ItemStyle CssText="background-color: white"></ItemStyle>
                <FixedColumnCellStyle CssText="border-right: #d6d2c2 1px solid; padding-right: 10px; border-top: #faf9f4 1px solid; border-left: #faf9f4 1px solid; border-bottom: #d6d2c2 1px solid; background-color: #ebeadb; text-align: right; color: black;"></FixedColumnCellStyle>
            </eo:GridItemStyleSet>
        </ItemStyles>
        <Columns>
            <eo:RowNumberColumn Width="40"></eo:RowNumberColumn>
            <eo:StaticColumn Width="120" SortOrder="Ascending" HeaderText="Account #" AllowSort="True" DataField="AccountNo"></eo:StaticColumn>
            <eo:StaticColumn Width="150" StyleField="BalanceStyle" DataFormat="{0:N2}" HeaderText="Account Balance"
                AllowSort="True" DataField="Balance"></eo:StaticColumn>
        </Columns>
    </eo:Grid></P>
</asp:Content>


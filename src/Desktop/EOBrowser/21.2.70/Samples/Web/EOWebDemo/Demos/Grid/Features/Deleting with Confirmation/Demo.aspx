<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Grid_Features_Deleting_with_Confirmation_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
function OnItemDelete(grid, itemIndex, colIndex, commandName)
{
    //Ask user to confirm the delete
    if (window.confirm("Are you sure you want to delete this row?"))
        grid.deleteItem(itemIndex);
}
//<!--JS_SAMPLE_END-->
</script>
<p>
This sample uses a <b>ButtonColumn</b> instead of a <b>DeleteCommandColumn</b>
to delete item. When clicked, the ButtonColumn generates <b>ClientSideOnItemCommand</b>
event, which is handled by this sample. The handler displays a message box
to ask for user's confirmation. Once confirmed, it calls client side method
<b>deleteItem</b> to delete the item.
</p>
<eo:Grid id="Grid1" AllowColumnReorder="True" ColumnHeaderDescImage="00050105" ColumnHeaderAscImage="00050104"
    FixedColumnCount="1" GoToBoxVisible="True" GridLines="Both" BorderColor="#7F9DB9" GridLineColor="220, 223, 228"
    ColumnHeaderDividerImage="00050103" Font-Names="Tahoma" Font-Size="8.75pt" BorderWidth="1px"
    IsCallbackByMe="False" KeyField="TopicID" runat="server" Height="180px" Width="400px"
    ClientSideOnItemCommand="OnItemDelete">
    <FooterStyle CssText="padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px;"></FooterStyle>
    <ItemStyles>
        <eo:GridItemStyleSet>
            <CellStyle CssText="padding-left:8px;padding-top:2px;"></CellStyle>
            <FixedColumnCellStyle CssText="border-right: #d6d2c2 1px solid; padding-right: 10px; border-top: #faf9f4 1px solid; border-left: #faf9f4 1px solid; border-bottom: #d6d2c2 1px solid; background-color: #ebeadb; text-align: right"></FixedColumnCellStyle>
        </eo:GridItemStyleSet>
    </ItemStyles>
    <GoToBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; BORDER-TOP: #7f9db9 1px solid; BORDER-LEFT: #7f9db9 1px solid; WIDTH: 40px; BORDER-BOTTOM: #7f9db9 1px solid"></GoToBoxStyle>
    <ContentPaneStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;"></ContentPaneStyle>
    <ColumnTemplates>
        <eo:TextBoxColumn>
            <TextBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 8.75pt; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; FONT-FAMILY: Tahoma"></TextBoxStyle>
        </eo:TextBoxColumn>
        <eo:DateTimeColumn>
            <DatePicker DayHeaderFormat="FirstLetter" DayCellHeight="16" DisabledDates="" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
                OtherMonthDayVisible="True" DayCellWidth="19" TitleRightArrowImageUrl="DefaultSubMenuIcon"
                ControlSkinID="None" SelectedDates="">
                <DayHoverStyle CssText="font-family: tahoma; font-size: 12px; border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid"></DayHoverStyle>
                <TitleStyle CssText="background-color:#9ebef5;font-family:Tahoma;font-size:12px;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;"></TitleStyle>
                <DayHeaderStyle CssText="font-family: tahoma; font-size: 12px; border-bottom: #aca899 1px solid"></DayHeaderStyle>
                <DayStyle CssText="font-family: tahoma; font-size: 12px; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></DayStyle>
                <SelectedDayStyle CssText="font-family: tahoma; font-size: 12px; background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></SelectedDayStyle>
                <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
                <TodayStyle CssText="font-family: tahoma; font-size: 12px; border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid"></TodayStyle>
                <PickerStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;font-family:Courier New;font-size:8pt;margin-bottom:0px;margin-left:0px;margin-right:0px;margin-top:0px;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></PickerStyle>
                <OtherMonthDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></OtherMonthDayStyle>
                <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma"></CalendarStyle>
                <DisabledDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></DisabledDayStyle>
                <MonthStyle CssText="font-family: tahoma; font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px"></MonthStyle>
            </DatePicker>
        </eo:DateTimeColumn>
    </ColumnTemplates>
    <Columns>
        <eo:RowNumberColumn Width="40"></eo:RowNumberColumn>
        <eo:ButtonColumn ButtonText="Delete" CommandName="Delete"></eo:ButtonColumn>
        <eo:DateTimeColumn HeaderText="Posted At" DataField="PostedAt"></eo:DateTimeColumn>
        <eo:TextBoxColumn HeaderText="Posted By" DataField="PostedBy"></eo:TextBoxColumn>
        <eo:TextBoxColumn Width="300" HeaderText="Topic" DataField="Topic"></eo:TextBoxColumn>
    </Columns>
    <ColumnHeaderStyle CssText="background-image:url('00050101');padding-left:8px;padding-top:3px;"></ColumnHeaderStyle>
</eo:Grid>
</asp:Content>


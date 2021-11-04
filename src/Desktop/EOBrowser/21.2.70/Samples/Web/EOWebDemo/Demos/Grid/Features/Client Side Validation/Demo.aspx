<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Grid_Features_Client_Side_Validation_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
function endedit_handler(cell, newValue)
{
    //Get the quantity entered by the user
    var quantity = parseInt(newValue);
    
    //Accept the quantity if it is within the allowed
    //range. Otherwise automatically correct it
    if ((quantity >= 1) && (quantity <= 10))
        return newValue.toString();    
    else if (quantity > 10)
        return "10";
    else
        return "1";
}
//<!--JS_SAMPLE_END-->
</script>
<p>
    This sample demonstrates how to perform client side validation on an EO.Web 
    Grid. The sample handles the grid column's <b>ClientSideAfterEdit</b> client 
    side event and checks whether user has entered a value between 1 and 10 in the <b>Item 
        Quantity</b> column. Click an empty cell to add new items.
</p>
<eo:Grid runat="server" id="Grid1" BorderColor="#828790" BorderWidth="1px" Font-Size="8.75pt"
    Font-Names="Tahoma" GridLines="Both" ColumnHeaderDescImage="00050205" GridLineColor="240, 240, 240"
    Width="380px" ItemHeight="19" ColumnHeaderAscImage="00050204" ColumnHeaderHeight="24"
    Height="200px" ColumnHeaderDividerImage="00050203" AllowNewItem="True" FullRowMode="False">
    <ColumnTemplates>
        <eo:TextBoxColumn>
            <TextBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 8.75pt; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; FONT-FAMILY: Tahoma"></TextBoxStyle>
        </eo:TextBoxColumn>
        <eo:DateTimeColumn>
            <DatePicker DayCellHeight="16" OtherMonthDayVisible="True" SelectedDates="" TitleRightArrowImageUrl="DefaultSubMenuIcon"
                DisabledDates="" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" DayHeaderFormat="FirstLetter"
                ControlSkinID="None" DayCellWidth="19">
                <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma"></CalendarStyle>
                <SelectedDayStyle CssText="font-family: tahoma; font-size: 12px; background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></SelectedDayStyle>
                <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
                <PickerStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;font-family:Courier New;font-size:8pt;margin-bottom:0px;margin-left:0px;margin-right:0px;margin-top:0px;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></PickerStyle>
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
            <MaskedEdit TextBoxStyle-CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; font-family:Courier New;font-size:8pt;"
                ControlSkinID="None"></MaskedEdit>
        </eo:MaskedEditColumn>
    </ColumnTemplates>
    <ItemStyles>
        <eo:GridItemStyleSet>
            <ItemHoverStyle CssText="background-image: url(00050206); background-repeat: repeat-x"></ItemHoverStyle>
            <SelectedStyle CssText="background-image: url(00050207); background-repeat: repeat-x"></SelectedStyle>
            <CellStyle CssText="padding-left:8px;padding-top:2px;white-space:nowrap;"></CellStyle>
            <ItemStyle CssText="background-color: white"></ItemStyle>
        </eo:GridItemStyleSet>
    </ItemStyles>
    <ColumnHeaderHoverStyle CssText="background-image:url('00050202');padding-left:8px;padding-top:4px;"></ColumnHeaderHoverStyle>
    <ColumnHeaderStyle CssText="background-image:url('00050201');padding-left:8px;padding-top:4px;"></ColumnHeaderStyle>
    <FooterStyle CssText="padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px;"></FooterStyle>
    <Columns>
        <eo:TextBoxColumn Width="200" HeaderText="Item Name"></eo:TextBoxColumn>
        <eo:TextBoxColumn ClientSideEndEdit="endedit_handler" HeaderText="Item Quantity"></eo:TextBoxColumn>
    </Columns>
</eo:Grid>
</asp:Content>


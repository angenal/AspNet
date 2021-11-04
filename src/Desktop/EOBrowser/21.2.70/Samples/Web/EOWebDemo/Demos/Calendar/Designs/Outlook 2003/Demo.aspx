<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Designs_Outlook_2003_Demo" Title="Untitled Page" %>
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<table border="0">
    <tr>
        <td>Calendar:</td>
        <td width="30"></td>
        <td>DatePicker:</td>
    </tr>
    <tr>
        <td valign="top">
            <eo:Calendar runat="server" id="Calendar1" DayCellWidth="19" OtherMonthDayVisible="True" 
                DayHeaderFormat="FirstLetter" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" TitleRightArrowImageUrl="DefaultSubMenuIcon"
                DayCellHeight="16">
                <DayStyle CssText="border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></DayStyle>
                <SelectedDayStyle CssText="background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></SelectedDayStyle>
                <OtherMonthDayStyle CssText="color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></OtherMonthDayStyle>
                <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
                <TitleStyle CssText="background-color:#9ebef5;font-family:Tahoma;font-size:12px;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;"></TitleStyle>
                <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma"></CalendarStyle>
                <DayHoverStyle CssText="border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid"></DayHoverStyle>
                <MonthStyle CssText="font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px; font-family: tahoma"></MonthStyle>
                <TodayStyle CssText="border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid"></TodayStyle>
                <DayHeaderStyle CssText="border-bottom: #aca899 1px solid"></DayHeaderStyle>
            </eo:Calendar>
        </td>
        <td>
        </td>
        <td valign="top">
            <eo:DatePicker runat="server" id="DatePicker1" TitleRightArrowImageUrl="DefaultSubMenuIcon" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
                DayHeaderFormat="FirstLetter" OtherMonthDayVisible="True" DayCellWidth="19"
                DayCellHeight="16" Width="120px">
                <SelectedDayStyle CssText="background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></SelectedDayStyle>
                <OtherMonthDayStyle CssText="color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></OtherMonthDayStyle>
                <TodayStyle CssText="border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid"></TodayStyle>
                <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
                <TitleStyle CssText="background-color:#9ebef5;font-family:Tahoma;font-size:12px;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;"></TitleStyle>
                <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma"></CalendarStyle>
                <DayHoverStyle CssText="border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid"></DayHoverStyle>
                <MonthStyle CssText="font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px; font-family: tahoma"></MonthStyle>
                <PickerStyle CssText="font-family:Courier New; padding-left:5px; padding-right: 5px;"></PickerStyle>
                <DayStyle CssText="border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></DayStyle>
                <DayHeaderStyle CssText="border-bottom: #aca899 1px solid"></DayHeaderStyle>
            </eo:DatePicker>
        </td>
    </tr>
</table>
</asp:Content>


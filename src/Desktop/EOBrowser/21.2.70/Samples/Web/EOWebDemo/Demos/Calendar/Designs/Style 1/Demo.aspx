<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Designs_Style_1_Demo" Title="Untitled Page" %>
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
            <eo:Calendar runat="server" id="Calendar1" DayCellWidth="24"  TitleLeftArrowImageUrl="00040204"
                TitleRightArrowImageUrl="00040206" DayCellHeight="16" TitleLeftArrowHoverImageUrl="00040205"
                DisableWeekendDays="True" TitleRightArrowHoverImageUrl="00040207">
                <SelectedDayStyle CssText="background-image: url(00040208)"></SelectedDayStyle>
                <DisabledDayStyle CssText="color:Gray;"></DisabledDayStyle>
                <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; font-size: 8pt; padding-bottom: 3px; color: black; padding-top: 3px; font-family: tahoma; background-color: transparent"></TitleStyle>
                <CalendarStyle CssText="background-color:#EBE9ED;border-bottom-color:black;border-bottom-style:solid;border-bottom-width:1px;border-left-color:black;border-left-style:solid;border-left-width:1px;border-right-color:black;border-right-style:solid;border-right-width:1px;border-top-color:black;border-top-style:solid;border-top-width:1px;"></CalendarStyle>
                <DayHoverStyle CssText="background-image:url('00040208');"></DayHoverStyle>
                <MonthStyle CssText="font-size: 8pt; cursor: hand; font-family: verdana"></MonthStyle>
                <DayHeaderStyle CssText="font-weight: bold; font-size: 11px; color: black; border-bottom: black 1px solid; font-family: verdana"></DayHeaderStyle>
            </eo:Calendar>
        </td>
        <td>
        </td>
        <td valign="top">
            <eo:DatePicker runat="server" id="DatePicker1" TitleRightArrowImageUrl="00040206" TitleLeftArrowImageUrl="00040204"
                DayCellWidth="24" DayCellHeight="16" TitleLeftArrowHoverImageUrl="00040205"
                DisableWeekendDays="True" TitleRightArrowHoverImageUrl="00040207" PopupImageUrl="00040201"
                PopupHoverImageUrl="00040203" PopupDownImageUrl="00040202"  Width="100px">
                <SelectedDayStyle CssText="background-image: url(00040208)"></SelectedDayStyle>
                <DisabledDayStyle CssText="color:Gray;"></DisabledDayStyle>
                <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; font-size: 8pt; padding-bottom: 3px; color: black; padding-top: 3px; font-family: tahoma; background-color: transparent"></TitleStyle>
                <CalendarStyle CssText="background-color:#EBE9ED;border-bottom-color:black;border-bottom-style:solid;border-bottom-width:1px;border-left-color:black;border-left-style:solid;border-left-width:1px;border-right-color:black;border-right-style:solid;border-right-width:1px;border-top-color:black;border-top-style:solid;border-top-width:1px;"></CalendarStyle>
                <DayHoverStyle CssText="background-image:url('00040208');"></DayHoverStyle>
                <MonthStyle CssText="font-size: 8pt; cursor: hand; font-family: verdana"></MonthStyle>
                <PickerStyle CssText="border-right: black 1px solid; border-top: black 1px solid; font-size: 8pt; border-left: black 1px solid; border-bottom: black 1px solid; font-family: courier new"></PickerStyle>
                <DayHeaderStyle CssText="font-weight: bold; font-size: 11px; color: black; border-bottom: black 1px solid; font-family: verdana"></DayHeaderStyle>
            </eo:DatePicker>
        </td>
    </tr>
</table>
</asp:Content>


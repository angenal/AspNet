<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Designs_Windows_Demo" Title="Untitled Page" %>
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
            <eo:Calendar runat="server" id="Calendar1" DayCellWidth="22" DayHeaderFormat="Short"
                TitleLeftArrowImageUrl="00040101" TitleRightArrowImageUrl="00040102" DayCellHeight="16" MonthSelectorVisible="True"
                WeekSelectorVisible="True" TitleLeftArrowDownImageUrl="00040103" TitleRightArrowDownImageUrl="00040104">
                <DayStyle CssText="text-decoration:none"></DayStyle>
                <SelectedDayStyle CssText="background-image:url('00040105');color:white;"></SelectedDayStyle>
                <DisabledDayStyle CssText="COLOR: gray"></DisabledDayStyle>
                <TitleStyle CssText="PADDING-RIGHT: 3px; PADDING-LEFT: 3px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; PADDING-BOTTOM: 3px; COLOR: white; PADDING-TOP: 3px; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #0054e3"></TitleStyle>
                <CalendarStyle CssText="border-bottom-color:Black;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Black;border-left-style:solid;border-left-width:1px;border-right-color:Black;border-right-style:solid;border-right-width:1px;border-top-color:Black;border-top-style:solid;border-top-width:1px;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;background-color:white"></CalendarStyle>
                <DayHoverStyle CssText="text-decoration:underline"></DayHoverStyle>
                <MonthStyle CssText="FONT-SIZE: 8pt; MARGIN: 0px 4px; FONT-FAMILY: Tahoma; cursor:hand"></MonthStyle>
                <FooterTemplate>
                    <div style="FONT-WEIGHT: bold; FONT-SIZE: 11px; FONT-FAMILY: Tahoma&quot;">
                        <img src="{img:00040106}"> Today: {var:today:MM/dd/yyyy}
                    </div>
                </FooterTemplate>
                <TodayStyle CssText="background-image:url('00040106');"></TodayStyle>
                <DayHeaderStyle CssText="FONT-SIZE: 11px; COLOR: #0054e3; BORDER-BOTTOM: black 1px solid; FONT-FAMILY: Tahoma"></DayHeaderStyle>
            </eo:Calendar>
        </td>
        <td>
        </td>
        <td valign="top">
            <eo:DatePicker runat="server" id="DatePicker1" TitleRightArrowImageUrl="00040102" TitleLeftArrowImageUrl="00040101"
                DayHeaderFormat="Short" DayCellWidth="22" DayCellHeight="16"
                MonthSelectorVisible="True" WeekSelectorVisible="True" TitleLeftArrowDownImageUrl="00040103"
                TitleRightArrowDownImageUrl="00040104"  Width="120px">
                <SelectedDayStyle CssText="background-image:url('00040105');color:white;"></SelectedDayStyle>
                <TodayStyle CssText="background-image:url('00040106');"></TodayStyle>
                <DisabledDayStyle CssText="COLOR: gray"></DisabledDayStyle>
                <TitleStyle CssText="PADDING-RIGHT: 3px; PADDING-LEFT: 3px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; PADDING-BOTTOM: 3px; COLOR: white; PADDING-TOP: 3px; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #0054e3"></TitleStyle>
                <CalendarStyle CssText="border-bottom-color:Black;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Black;border-left-style:solid;border-left-width:1px;border-right-color:Black;border-right-style:solid;border-right-width:1px;border-top-color:Black;border-top-style:solid;border-top-width:1px;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;background-color:white"></CalendarStyle>
                <DayHoverStyle CssText="text-decoration:underline"></DayHoverStyle>
                <MonthStyle CssText="FONT-SIZE: 8pt; MARGIN: 0px 4px; FONT-FAMILY: Tahoma; cursor:hand"></MonthStyle>
                <FooterTemplate>
                    <div style="FONT-WEIGHT: bold; FONT-SIZE: 11px; FONT-FAMILY: Tahoma&quot;">
                        <img src="{img:00040106}"> Today: {var:today:MM/dd/yyyy}
                    </div>
                </FooterTemplate>
                <DayStyle CssText="text-decoration:none"></DayStyle>
                <DayHeaderStyle CssText="FONT-SIZE: 11px; COLOR: #0054e3; BORDER-BOTTOM: black 1px solid; FONT-FAMILY: Tahoma"></DayHeaderStyle>
            </eo:DatePicker>
        </td>
    </tr>
</table>
</asp:Content>


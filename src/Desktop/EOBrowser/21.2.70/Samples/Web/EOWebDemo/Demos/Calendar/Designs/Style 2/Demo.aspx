<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Designs_Style_2_Demo" Title="Untitled Page" %>
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
            <eo:Calendar runat="server" id="Calendar1" DayCellWidth="22"  DayCellHeight="14"
                CssBlock='&#13;&#10;<style  type="text/css">&#13;&#10;   a.eo_calendar_style1_title_button &#13;&#10;   { &#13;&#10;        width: 21px;&#13;&#10;        height: 17px;&#13;&#10;        border-right: #f3f3f3 1px solid; &#13;&#10;        border-top: #f3f3f3 1px solid; &#13;&#10;        border-left: #f3f3f3 1px solid; &#13;&#10;        border-bottom: #f3f3f3 1px solid; &#13;&#10;        background-color: transparent; &#13;&#10;   }   &#13;&#10;   &#13;&#10;   a.eo_calendar_style1_title_button:hover &#13;&#10;   { &#13;&#10;        width: 21px;&#13;&#10;        height: 17px;&#13;&#10;        border-right: #0044ff 1px solid; &#13;&#10;        border-top: #0044ff 1px solid; &#13;&#10;        border-left: #0044ff 1px solid; &#13;&#10;        border-bottom: #0044ff 1px solid; &#13;&#10;        background-color: #aaaaff   &#13;&#10;   }   &#13;&#10;</style>&#13;&#10;'
                DisableWeekendDays="True">
                <DayStyle CssText="border-bottom-color:#CFD9C0;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#CFD9C0;border-left-style:solid;border-left-width:1px;border-right-color:#CFD9C0;border-right-style:solid;border-right-width:1px;border-top-color:#CFD9C0;border-top-style:solid;border-top-width:1px;"></DayStyle>
                <TitleTemplate>
                    <div>
                        <table width="100%" border="0" style="background-color:#f3f3f3;font-size: 11px; font-family: verdana; border-collapse:collapse;">
                            <tr>
                                <!-- Previous Year -->
                                <td>
                                    <a href="javascript: void {var:this}.goTo(-12);" class="eo_calendar_style1_title_button"><img src="{img:00040302}" border="0" /></a>
                                </td>
                                <!-- Previous Month -->
                                <td>
                                    <a href="javascript: void {var:this}.goTo(-1);" class="eo_calendar_style1_title_button"><img src="{img:00040301}" border="0" /></a>
                                </td>
                                <!-- Current Month -->
                                <td width="99%" align="center">
                                    {var:visible_date:MMM - yy}
                                </td>
                                <!-- Next Month -->
                                <td>
                                    <a href="javascript: void {var:this}.goTo(1);" class="eo_calendar_style1_title_button"><img src="{img:00040303}" border="0" /></a>
                                </td>
                                <!-- Next Year -->
                                <td>
                                    <a href="javascript: void {var:this}.goTo(12);" class="eo_calendar_style1_title_button"><img src="{img:00040304}" border="0" /></a>
                                </td>
                            </tr>
                        </table>
                    </div>
                </TitleTemplate>
                <SelectedDayStyle CssText="background-color:White;border-bottom-color:Black;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Black;border-left-style:solid;border-left-width:1px;border-right-color:Black;border-right-style:solid;border-right-width:1px;border-top-color:Black;border-top-style:solid;border-top-width:1px;"></SelectedDayStyle>
                <DisabledDayStyle CssText="border-bottom-color:#CFD9C0;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#CFD9C0;border-left-style:solid;border-left-width:1px;border-right-color:#CFD9C0;border-right-style:solid;border-right-width:1px;border-top-color:#CFD9C0;border-top-style:solid;border-top-width:1px;color:gray;"></DisabledDayStyle>
                <CalendarStyle CssText="border-right: #555566 1px solid; border-top: #555566 1px solid; border-left: #555566 1px solid; border-bottom: #555566 1px solid; background-color: #ebe9ed"></CalendarStyle>
                <DayHoverStyle CssText="border-right: #bbbbbb 1px solid; border-top: #bbbbbb 1px solid; border-left: #bbbbbb 1px solid; border-bottom: #bbbbbb 1px solid; background-color: #ddeeff"></DayHoverStyle>
                <MonthStyle CssText="font-size: 8pt; cursor: hand; font-family: verdana; background-color: #cfd9c0"></MonthStyle>
                <DayHeaderStyle CssText="font-weight: bold; font-size: 11px; color: black; border-bottom: #555566 1px solid; font-family: verdana; background-color: #ae9c86"></DayHeaderStyle>
            </eo:Calendar>
        </td>
        <td>
        </td>
        <td valign="top">
            <eo:DatePicker runat="server" id="DatePicker1" DayCellWidth="22" DayCellHeight="14"
                CssBlock='&#13;&#10;<style  type="text/css">&#13;&#10;   a.eo_calendar_style1_title_button &#13;&#10;   { &#13;&#10;        width: 21px;&#13;&#10;        height: 17px;&#13;&#10;        border-right: #f3f3f3 1px solid; &#13;&#10;        border-top: #f3f3f3 1px solid; &#13;&#10;        border-left: #f3f3f3 1px solid; &#13;&#10;        border-bottom: #f3f3f3 1px solid; &#13;&#10;        background-color: transparent; &#13;&#10;   }   &#13;&#10;   &#13;&#10;   a.eo_calendar_style1_title_button:hover &#13;&#10;   { &#13;&#10;        width: 21px;&#13;&#10;        height: 17px;&#13;&#10;        border-right: #0044ff 1px solid; &#13;&#10;        border-top: #0044ff 1px solid; &#13;&#10;        border-left: #0044ff 1px solid; &#13;&#10;        border-bottom: #0044ff 1px solid; &#13;&#10;        background-color: #aaaaff   &#13;&#10;   }   &#13;&#10;</style>&#13;&#10;'
                DisableWeekendDays="True"  Width="120px">
                <TitleTemplate>
                    <table width="100%" border="0" cellSpacing="0" cellPadding="0" style="background-color:#f3f3f3;font-size: 11px; font-family: verdana; ">
                        <tr>
                            <!-- Previous Year -->
                            <td>
                                <a href="javascript: void {var:this}.goTo(-12);" class="eo_calendar_style1_title_button">
                                    <img src="{img:00040302}" border="0" /> </a>
                            </td>
                            <!-- Previous Month -->
                            <td>
                                <a href="javascript: void {var:this}.goTo(-1);" class="eo_calendar_style1_title_button">
                                    <img src="{img:00040301}" border="0" /> </a>
                            </td>
                            <!-- Current Month -->
                            <td width="99%" align="center">
                                {var:visible_date:MMM - yy}
                            </td>
                            <!-- Next Month -->
                            <td>
                                <a href="javascript: void {var:this}.goTo(1);" class="eo_calendar_style1_title_button">
                                    <img src="{img:00040303}" border="0" /> </a>
                            </td>
                            <!-- Next Year -->
                            <td>
                                <a href="javascript: void {var:this}.goTo(12);" class="eo_calendar_style1_title_button">
                                    <img src="{img:00040304}" border="0" /> </a>
                            </td>
                        </tr>
                    </table>
                </TitleTemplate>
                <SelectedDayStyle CssText="background-color:White;border-bottom-color:Black;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Black;border-left-style:solid;border-left-width:1px;border-right-color:Black;border-right-style:solid;border-right-width:1px;border-top-color:Black;border-top-style:solid;border-top-width:1px;"></SelectedDayStyle>
                <DisabledDayStyle CssText="border-bottom-color:#CFD9C0;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#CFD9C0;border-left-style:solid;border-left-width:1px;border-right-color:#CFD9C0;border-right-style:solid;border-right-width:1px;border-top-color:#CFD9C0;border-top-style:solid;border-top-width:1px;color:gray;"></DisabledDayStyle>
                <CalendarStyle CssText="border-right: #555566 1px solid; border-top: #555566 1px solid; border-left: #555566 1px solid; border-bottom: #555566 1px solid; background-color: #ebe9ed"></CalendarStyle>
                <DayHoverStyle CssText="border-right: #bbbbbb 1px solid; border-top: #bbbbbb 1px solid; border-left: #bbbbbb 1px solid; border-bottom: #bbbbbb 1px solid; background-color: #ddeeff"></DayHoverStyle>
                <MonthStyle CssText="font-size: 8pt; cursor: hand; font-family: verdana; background-color: #cfd9c0"></MonthStyle>
                <DayStyle CssText="border-bottom-color:#CFD9C0;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#CFD9C0;border-left-style:solid;border-left-width:1px;border-right-color:#CFD9C0;border-right-style:solid;border-right-width:1px;border-top-color:#CFD9C0;border-top-style:solid;border-top-width:1px;"></DayStyle>
                <DayHeaderStyle CssText="font-weight: bold; font-size: 11px; color: black; border-bottom: #555566 1px solid; font-family: verdana; background-color: #ae9c86"></DayHeaderStyle>
            </eo:DatePicker>
        </td>
    </tr>
</table>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Designs_Style_3_Demo" Title="Untitled Page" %>
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
            <eo:Calendar runat="server" id="Calendar1" DayCellWidth="21" DayHeaderFormat="FirstLetter"
                DayCellHeight="16" GridLineFrameVisible="False" TitleLeftArrowHtml="&amp;lt;" TitleFormat="MMM yyyy"
                TitleRightArrowHtml="&amp;gt;" GridLineColor="207, 217, 227" GridLineVisible="True">
                <DayStyle CssText="border-right: #eaeaea 1px solid; border-top: #eaeaea 1px solid; border-left: #eaeaea 1px solid; border-bottom: #eaeaea 1px solid; background-color: #eaeaea"></DayStyle>
                <SelectedDayStyle CssText="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: white"></SelectedDayStyle>
                <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; padding-bottom: 3px; color: white; padding-top: 3px; border-bottom: #cfd9e3 1px solid; background-color: #006699; font-size: 11px; font-family: verdana;"></TitleStyle>
                <CalendarStyle CssText="border-right: #cfd9e3 1px solid; border-top: #cfd9e3 1px solid; font-size: 11px; border-left: #cfd9e3 1px solid; cursor: hand; border-bottom: #cfd9e3 1px solid; font-family: verdana; background-color: #eaeaea"></CalendarStyle>
                <DayHoverStyle CssText="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: white"></DayHoverStyle>
                <MonthStyle CssText="font-size: 11px; font-family: verdana;"></MonthStyle>
                <DayHeaderStyle CssText="height: 17px"></DayHeaderStyle>
            </eo:Calendar>
        </td>
        <td>
        </td>
        <td valign="top">
            <eo:DatePicker runat="server" id="DatePicker1" DayHeaderFormat="FirstLetter"  Width="120px"
                DayCellWidth="21" DayCellHeight="16" GridLineFrameVisible="False" TitleLeftArrowHtml="&amp;lt;"
                TitleFormat="MMM yyyy" TitleRightArrowHtml="&amp;gt;" GridLineColor="207, 217, 227" GridLineVisible="True">
                <SelectedDayStyle CssText="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: white"></SelectedDayStyle>
                <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; padding-bottom: 3px; color: white; padding-top: 3px; border-bottom: #cfd9e3 1px solid; background-color: #006699; font-size: 11px; font-family: verdana;"></TitleStyle>
                <CalendarStyle CssText="border-right: #cfd9e3 1px solid; border-top: #cfd9e3 1px solid; font-size: 11px; border-left: #cfd9e3 1px solid; cursor: hand; border-bottom: #cfd9e3 1px solid; font-family: verdana; background-color: #eaeaea"></CalendarStyle>
                <DayHoverStyle CssText="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: white"></DayHoverStyle>
                <MonthStyle CssText="font-size: 11px; font-family: verdana;"></MonthStyle>
                <DayStyle CssText="border-right: #eaeaea 1px solid; border-top: #eaeaea 1px solid; border-left: #eaeaea 1px solid; border-bottom: #eaeaea 1px solid; background-color: #eaeaea"></DayStyle>
                <DayHeaderStyle CssText="height: 17px"></DayHeaderStyle>
            </eo:DatePicker>
        </td>
    </tr>
</table>
</asp:Content>


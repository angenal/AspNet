<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Features_Calendar_Demo" Title="Untitled Page" %>
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    This sample demonstrates a basic Calendar control. Use 
    property <span class="highlight">SelecteDate</span> to get the
    selected date on the server side, or use <span class="highlight">getSelectedDate</span>
    to get the selected date on the client side.
</p>
<eo:Calendar runat="server" id="Calendar1" TitleRightArrowDownImageUrl="00040104" MonthSelectorVisible="True"
    DayCellHeight="16" DayCellWidth="22" WeekSelectorVisible="True" TitleLeftArrowDownImageUrl="00040103"
    DayHeaderFormat="Short" TitleLeftArrowImageUrl="00040101" TitleRightArrowImageUrl="00040102">
    <DayStyle CssText="text-decoration:none"></DayStyle>
    <DayHoverStyle CssText="text-decoration:underline"></DayHoverStyle>
    <FooterTemplate>
        <div style="FONT-WEIGHT: bold; FONT-SIZE: 11px; FONT-FAMILY: Tahoma&quot;">
            <img src="{img:00040106}"> Today: {var:today:MM/dd/yyyy}
        </div>
    </FooterTemplate>
    <DisabledDayStyle CssText="COLOR: gray"></DisabledDayStyle>
    <DayHeaderStyle CssText="FONT-SIZE: 11px; COLOR: #0054e3; BORDER-BOTTOM: black 1px solid; FONT-FAMILY: Tahoma"></DayHeaderStyle>
    <SelectedDayStyle CssText="background-image:url('00040105');color:white;"></SelectedDayStyle>
    <MonthStyle CssText="FONT-SIZE: 8pt; MARGIN: 0px 4px; FONT-FAMILY: Tahoma; cursor:hand"></MonthStyle>
    <TitleStyle CssText="PADDING-RIGHT: 3px; PADDING-LEFT: 3px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; PADDING-BOTTOM: 3px; COLOR: white; PADDING-TOP: 3px; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #0054e3"></TitleStyle>
    <CalendarStyle CssText="border-bottom-color:Black;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Black;border-left-style:solid;border-left-width:1px;border-right-color:Black;border-right-style:solid;border-right-width:1px;border-top-color:Black;border-top-style:solid;border-top-width:1px;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;background-color:white"></CalendarStyle>
    <TodayStyle CssText="background-image:url('00040106');"></TodayStyle>
</eo:Calendar>
</asp:Content>


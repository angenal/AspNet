<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Features_Date_Picker_Demo" Title="Untitled Page" %>
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web Calendar Controls include <span class="highlight">DataPicker</span> control 
    which is used as a date input box.
</p>
DatePicker can be customized to use different formats via its <span class="highlight">
    PickerFormat</span> property. The following two DatePickers have their 
PickerFormat set to <span class="highlight">MM/dd/yyyy</span> and <span class="highlight">
    dd/MM/yyyy</span>
<p>
</p>
<p>
    Format: MM/dd/yyyy
</p>
<eo:DatePicker runat="server" id="DataPicker1" TitleLeftArrowHoverImageUrl="00040205" PopupImageUrl="00040209"
    DisableWeekendDays="True" TitleLeftArrowImageUrl="00040204" DayCellHeight="16" PopupHoverImageUrl="00040211"
    PopupDownImageUrl="00040210" DayCellWidth="24" TitleRightArrowImageUrl="00040206" TitleRightArrowHoverImageUrl="00040207"
    PickerHint="mm/dd/yyyy" Width="100px">
    <SelectedDayStyle CssText="background-image: url(00040208)"></SelectedDayStyle>
    <DisabledDayStyle CssText="color:Gray;"></DisabledDayStyle>
    <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; font-size: 8pt; padding-bottom: 3px; color: black; padding-top: 3px; font-family: tahoma; background-color: transparent"></TitleStyle>
    <CalendarStyle CssText="background-color:White;border-bottom-color:black;border-bottom-style:solid;border-bottom-width:1px;border-left-color:black;border-left-style:solid;border-left-width:1px;border-right-color:black;border-right-style:solid;border-right-width:1px;border-top-color:black;border-top-style:solid;border-top-width:1px;"></CalendarStyle>
    <DayHoverStyle CssText="background-image:url('00040208');"></DayHoverStyle>
    <MonthStyle CssText="font-size: 8pt; cursor: hand; font-family: verdana"></MonthStyle>
    <PickerStyle CssText="border-bottom-color:Gainsboro;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Gainsboro;border-left-style:solid;border-left-width:1px;border-right-color:Gainsboro;border-right-style:solid;border-right-width:1px;border-top-color:Gainsboro;border-top-style:solid;border-top-width:1px;color:#606060;font-family:courier new;font-size:8pt;"></PickerStyle>
    <DayHeaderStyle CssText="font-weight: bold; font-size: 11px; color: black; border-bottom: black 1px solid; font-family: verdana"></DayHeaderStyle>
</eo:DatePicker>
<p>
    Format: dd/MM/yyyy
</p>
<eo:DatePicker runat="server" id="DatePicker1" TitleLeftArrowHoverImageUrl="00040205" PopupImageUrl="00040209"
    DisableWeekendDays="True" TitleLeftArrowImageUrl="00040204" DayCellHeight="16" PopupHoverImageUrl="00040210"
    PopupDownImageUrl="00040211" DayCellWidth="24" TitleRightArrowImageUrl="00040206" TitleRightArrowHoverImageUrl="00040207"
    PickerHint="dd/mm/yyyy" PickerFormat="dd/MM/yyyy" Width="100px">
    <SelectedDayStyle CssText="background-image: url(00040208)"></SelectedDayStyle>
    <DisabledDayStyle CssText="color:Gray;"></DisabledDayStyle>
    <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; font-size: 8pt; padding-bottom: 3px; color: black; padding-top: 3px; font-family: tahoma; background-color: transparent"></TitleStyle>
    <CalendarStyle CssText="background-color:White;border-bottom-color:black;border-bottom-style:solid;border-bottom-width:1px;border-left-color:black;border-left-style:solid;border-left-width:1px;border-right-color:black;border-right-style:solid;border-right-width:1px;border-top-color:black;border-top-style:solid;border-top-width:1px;"></CalendarStyle>
    <DayHoverStyle CssText="background-image:url('00040208');"></DayHoverStyle>
    <MonthStyle CssText="font-size: 8pt; cursor: hand; font-family: verdana"></MonthStyle>
    <PickerStyle CssText="BORDER-RIGHT: gainsboro 1px solid; BORDER-TOP: gainsboro 1px solid; FONT-SIZE: 8pt; BORDER-LEFT: gainsboro 1px solid; COLOR: #606060; BORDER-BOTTOM: gainsboro 1px solid; FONT-FAMILY: courier new"></PickerStyle>
    <DayHeaderStyle CssText="font-weight: bold; font-size: 11px; color: black; border-bottom: black 1px solid; font-family: verdana"></DayHeaderStyle>
</eo:DatePicker>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Features_Disabled_Dates_Demo" Title="Untitled Page" %>
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    You can programmatically or declaratively disable a list of random dates as well as dates in 
    certain range.
</p>
<p>
    To disable a list of dates, use <span class="highlight">DisabledDates</span> property. 
    Use <span class="highlight">MinValidDate</span> and <span class="highlight">MaxValidDate</span>
    to filter out dates outside of certain range. To disable weekends, set <span class="highlight">
        DisableWeekendDays</span> to true.
</p>
<p>
    The following sample mimics a doctor's appointment schedule. The 
    calendar&nbsp;has MinValidDate set as today and MaxValidDate set as two weeks 
    after today. Weekends are disabled as well. In addition, every Thursday is 
    also disabled because the doctor is not available.
</p>
<eo:Calendar runat="server" id="Calendar1" DayCellHeight="15" DayCellWidth="31" OtherMonthDayVisible="True"
    DayHeaderFormat="Short" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
    TitleRightArrowImageUrl="DefaultSubMenuIcon" TitleFormat="MMMM, yyyy">
    <DayHoverStyle CssText="background-image:url('00040402');color:#1c7cdc;"></DayHoverStyle>
    <FooterTemplate>
        <table style="font-size: 11px; font-family: Verdana" border="0" cellSpacing="5" cellPadding="0">
            <tr>
                <td width="30"></td>
                <td valign="center"><img src="{img:00040401}"></td>
                <td valign="center">Today: {var:today:MM/dd/yyyy}</td>
            </tr>
        </table>
    </FooterTemplate>
    <DisabledDayStyle CssText="color: gray"></DisabledDayStyle>
    <DayHeaderStyle CssText="border-bottom: #f5f5f5 1px solid"></DayHeaderStyle>
    <SelectedDayStyle CssText="background-image:url('00040403');color:Brown;"></SelectedDayStyle>
    <MonthStyle CssText="cursor:hand;font-family:Verdana;font-size:8pt;margin-bottom:0px;margin-left:4px;margin-right:4px;margin-top:0px;"></MonthStyle>
    <TitleStyle CssText="font-family:Verdana;font-size:8.75pt;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;"></TitleStyle>
    <TitleArrowStyle CssText="cursor: hand"></TitleArrowStyle>
    <CalendarStyle CssText="background-color:white;border-bottom-color:Silver;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Silver;border-left-style:solid;border-left-width:1px;border-right-color:Silver;border-right-style:solid;border-right-width:1px;border-top-color:Silver;border-top-style:solid;border-top-width:1px;color:#2C0B1E;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;"></CalendarStyle>
    <TodayStyle CssText="background-image:url('00040401');color:#1176db;"></TodayStyle>
</eo:Calendar>
</asp:Content>


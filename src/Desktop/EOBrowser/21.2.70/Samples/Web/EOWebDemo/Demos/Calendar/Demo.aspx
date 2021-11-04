<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
EO.Calendar offers a Calendar, a popup DatePicker control and a PopupCalendar control. Key features include:
</p>
<table height="300">
    <tr>
        <td valign="top">
            <p>Calendar:</p>
            <eo:Calendar runat="server" id="Calendar1" DayHeaderFormat="Short" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
                DayCellHeight="15" DayCellWidth="31" TitleRightArrowImageUrl="DefaultSubMenuIcon" 
                TitleFormat="MMMM, yyyy" OtherMonthDayVisible="True">
                <SelectedDayStyle CssText="background-image:url('00040403');color:Brown;"></SelectedDayStyle>
                <DisabledDayStyle CssText="color: gray"></DisabledDayStyle>
                <TitleArrowStyle CssText="cursor: hand"></TitleArrowStyle>
                <TitleStyle CssText="font-family:Verdana;font-size:8.75pt;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;"></TitleStyle>
                <CalendarStyle CssText="background-color:white;border-bottom-color:Silver;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Silver;border-left-style:solid;border-left-width:1px;border-right-color:Silver;border-right-style:solid;border-right-width:1px;border-top-color:Silver;border-top-style:solid;border-top-width:1px;color:#2C0B1E;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;"></CalendarStyle>
                <DayHoverStyle CssText="background-image:url('00040402');color:#1c7cdc;"></DayHoverStyle>
                <MonthStyle CssText="cursor:hand;font-family:Verdana;font-size:8pt;margin-bottom:0px;margin-left:4px;margin-right:4px;margin-top:0px;"></MonthStyle>
                <FooterTemplate>
                    <table style="font-size: 11px; font-family: Verdana" border="0" cellSpacing="5" cellPadding="0">
                        <tr>
                            <td width="30"></td>
                            <td valign="center"><img src="{img:00040401}"></td>
                            <td valign="center">Today: {var:today:MM/dd/yyyy}</td>
                        </tr>
                    </table>
                </FooterTemplate>
                <TodayStyle CssText="background-image:url('00040401');color:#1176db;"></TodayStyle>
                <DayHeaderStyle CssText="border-bottom: #f5f5f5 1px solid"></DayHeaderStyle>
            </eo:Calendar>
            <p>Date Picker:</p>
            <eo:DatePicker runat="server" id="Calendar2" DayHeaderFormat="Short" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
                DayCellHeight="15" DayCellWidth="31" TitleRightArrowImageUrl="DefaultSubMenuIcon" 
                TitleFormat="MMMM, yyyy" OtherMonthDayVisible="True" Width="120px">
                <SelectedDayStyle CssText="background-image:url('00040403');color:Brown;"></SelectedDayStyle>
                <TodayStyle CssText="background-image:url('00040401');color:#1176db;"></TodayStyle>
                <TitleArrowStyle CssText="cursor: hand"></TitleArrowStyle>
                <DisabledDayStyle CssText="color: gray"></DisabledDayStyle>
                <TitleStyle CssText="font-family:Verdana;font-size:8.75pt;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;"></TitleStyle>
                <CalendarStyle CssText="background-color:white;border-bottom-color:Silver;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Silver;border-left-style:solid;border-left-width:1px;border-right-color:Silver;border-right-style:solid;border-right-width:1px;border-top-color:Silver;border-top-style:solid;border-top-width:1px;color:#2C0B1E;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;"></CalendarStyle>
                <DayHoverStyle CssText="background-image:url('00040402');color:#1c7cdc;"></DayHoverStyle>
                <MonthStyle CssText="cursor:hand;font-family:Verdana;font-size:8pt;margin-bottom:0px;margin-left:4px;margin-right:4px;margin-top:0px;"></MonthStyle>
                <FooterTemplate>
                    <table style="font-size: 11px; font-family: Verdana" border="0" cellSpacing="5" cellPadding="0">
                        <tr>
                            <td width="30"></td>
                            <td valign="center"><img src="{img:00040401}"></td>
                            <td valign="center">Today: {var:today:MM/dd/yyyy}</td>
                        </tr>
                    </table>
                </FooterTemplate>
                <DayHeaderStyle CssText="border-bottom: #f5f5f5 1px solid"></DayHeaderStyle>
            </eo:DatePicker>
        </td>
        <td width="30"></td>
        <td valign="top">
            <ul>
                <li>
                Offers Calendar, Popup Calendar, Date Picker in one package;
                <li>
                Calendar can be easily used to implement scheduler;
                <li>
                Complete client side and server side programming interface;
                <li>
                Extensive CSS style and image support;
                <li>
                Large set of pre-built design templates and ready to use samples;
                <li>
                Multi-month calendar support;
                <li>
                Customizable title and footer support;
                <li>
                Cross browser support;
                <li>
                    Powerful Calendar Builder with preview;</li>
            </ul>
        </td>
    </tr>
</table>
There are many other demos available. Please use the tree on the left side to 
navigate the demos.
</asp:Content>


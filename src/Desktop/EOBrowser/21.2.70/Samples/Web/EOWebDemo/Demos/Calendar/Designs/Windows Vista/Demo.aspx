<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Designs_Windows_Vista_Demo" Title="Untitled Page" %>
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
            <eo:Calendar runat="server" id="Calendar1" DayCellWidth="31" OtherMonthDayVisible="True" 
                DayHeaderFormat="Short" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" TitleRightArrowImageUrl="DefaultSubMenuIcon"
                DayCellHeight="15" TitleFormat="MMMM, yyyy">
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
        </td>
        <td>
        </td>
        <td valign="top">
            <eo:DatePicker runat="server" id="DatePicker1" TitleRightArrowImageUrl="DefaultSubMenuIcon" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
                DayHeaderFormat="Short" OtherMonthDayVisible="True" DayCellWidth="31"
                DayCellHeight="15" TitleFormat="MMMM, yyyy"  Width="120px">
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
    </tr>
</table>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Features_Month_and_Week_Selector_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<p>
    EO.Web Calendar supports month and week selector. Month selector can be used to 
    select the whole month. Week selector can be used to select all days within the 
    specific week. The following calendar has both month and week selector turned 
    on.
</p>
<p>
    Hover mouse over the month selector ('=') to highlight the whole month. Hover 
    mouse over the week selector ('&gt;') to highlight the whole week. Click them 
    to select the whole month or week respectively. Both month selector and week 
    selector can be any HTML or image.
</p>
<p>
&nbsp;
</p>
<eo:Calendar runat="server" id="Calendar1" DayHeaderFormat="Short" MonthSelectorVisible="True"
    TitleFormat="MMMM, yyyy" WeekSelectorVisible="True" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
    DayCellHeight="15" OtherMonthDayVisible="True" DayCellWidth="31" TitleRightArrowImageUrl="DefaultSubMenuIcon"
    MonthSelectorHtml="=&amp;nbsp;" WeekSelectorHtml=">&amp;nbsp;">
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
    <DayHeaderStyle CssText="BORDER-BOTTOM: #f5f5f5 1px solid"></DayHeaderStyle>
</eo:Calendar>
</asp:Content>


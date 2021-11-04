<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Features_Scheduler_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
See Remarks tab for details.
</p>
<eo:Calendar id="Calendar1" runat="server" TitleTemplateScope="TextOnly" GridLineColor="207, 217, 227"
    TitleFormat="MMMM, yyyy" TitleLeftArrowHtml="&amp;lt;" DayHeaderFormat="Full" 
    TitleRightArrowHtml="&amp;gt;" GridLineVisible="True" DayCellWidth="72" DayCellHeight="45"
    GridLineFrameVisible="False" OnDayRender="Calendar1_DayRender">
    <DayStyle CssText="BORDER-RIGHT: #eaeaea 1px solid; BORDER-TOP: #eaeaea 1px solid; FONT-SIZE: 9px; BORDER-LEFT: #eaeaea 1px solid; BORDER-BOTTOM: #eaeaea 1px solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: #eaeaea; TEXT-ALIGN: right"></DayStyle>
    <TitleTemplate>
        <span>Holidays - {var:visible_date:MMMM, yyyy} </span>
    </TitleTemplate>
    <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; padding-bottom: 3px; color: white; padding-top: 3px; border-bottom: #cfd9e3 1px solid; background-color: #006699; font-size: 11px; font-family: verdana;"></TitleStyle>
    <CalendarStyle CssText="border-right: #cfd9e3 1px solid; border-top: #cfd9e3 1px solid; font-size: 11px; border-left: #cfd9e3 1px solid; cursor: hand; border-bottom: #cfd9e3 1px solid; font-family: verdana; background-color: #eaeaea"></CalendarStyle>
    <DayHoverStyle CssText="BORDER-RIGHT: #dadada 1px solid; BORDER-TOP: #dadada 1px solid; FONT-SIZE: 9px; BORDER-LEFT: #dadada 1px solid; BORDER-BOTTOM: #dadada 1px solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: #dadada; TEXT-ALIGN: right"></DayHoverStyle>
    <MonthStyle CssText="font-size: 11px; font-family: verdana;"></MonthStyle>
    <DayHeaderStyle CssText="height: 17px"></DayHeaderStyle>
</eo:Calendar>
</asp:Content>


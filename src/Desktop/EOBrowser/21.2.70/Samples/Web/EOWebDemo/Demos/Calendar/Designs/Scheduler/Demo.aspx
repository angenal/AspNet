<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Designs_Scheduler_Demo" Title="Untitled Page" %>
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:Calendar runat="server" id="Calendar1" GridLineFrameVisible="False" DayHeaderFormat="Full"
    TitleLeftArrowHtml="&amp;lt;" TitleFormat="MMMM, yyyy" DayCellHeight="50" TitleRightArrowHtml="&amp;gt;"
    GridLineColor="207, 217, 227" DayCellWidth="70" GridLineVisible="True">
    <DayStyle CssText="border-right: #eaeaea 1px solid; border-top: #eaeaea 1px solid; border-left: #eaeaea 1px solid; border-bottom: #eaeaea 1px solid; background-color: #eaeaea; text-align: right;"></DayStyle>
    <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; padding-bottom: 3px; color: white; padding-top: 3px; border-bottom: #cfd9e3 1px solid; background-color: #006699; font-size: 11px; font-family: verdana;"></TitleStyle>
    <CalendarStyle CssText="border-right: #cfd9e3 1px solid; border-top: #cfd9e3 1px solid; font-size: 11px; border-left: #cfd9e3 1px solid; cursor: hand; border-bottom: #cfd9e3 1px solid; font-family: verdana; background-color: #eaeaea"></CalendarStyle>
    <DayHoverStyle CssText="background-color:#DADADA;border-bottom-color:#DADADA;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#DADADA;border-left-style:solid;border-left-width:1px;border-right-color:#DADADA;border-right-style:solid;border-right-width:1px;border-top-color:#DADADA;border-top-style:solid;border-top-width:1px;text-align:right;"></DayHoverStyle>
    <MonthStyle CssText="font-size: 11px; font-family: verdana;"></MonthStyle>
    <DayHeaderStyle CssText="height: 17px"></DayHeaderStyle>
</eo:Calendar>
</asp:Content>


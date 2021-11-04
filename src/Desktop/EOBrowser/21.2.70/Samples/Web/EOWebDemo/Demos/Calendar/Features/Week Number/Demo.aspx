<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Features_Week_Number_Demo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        EO.Web Calendar/DatePicker can display a week number in front of every week. To
        enable this feature, set <b>WeekNumberBase</b> to the desired value. This sample
        also uses <b>MonthSelectorStyle</b> and <b>WeekSelectorStyle</b> to customize week
        number and week number header styles.
    </p>
    <p>
        Week numbers can be "month based" or "year based". When week number is month based,
        the first week of the month has a week number "1", the second week of the month
        has a week number "2", and so on. When week number is year based, the first week
        of the year has a week number "1", the second week of the year has a week number
        "2", and so on.
    </p>
    <eo:CallbackPanel runat="server" ID="CallbackPanel1" Triggers="{ControlID:WeekNumberMonth;Parameter:},{ControlID:WeekNumberYear;Parameter:}">
        <asp:RadioButton ID="WeekNumberMonth" runat="server" Text="Month Based" Checked="True"
            GroupName="weekNumberBase" OnCheckedChanged="WeekNumberBase_CheckedChanged"></asp:RadioButton>&nbsp;&nbsp;
        <asp:RadioButton ID="WeekNumberYear" runat="server" Text="Year Based" GroupName="weekNumberBase"
            OnCheckedChanged="WeekNumberBase_CheckedChanged"></asp:RadioButton>
        <table border="0">
            <tr>
                <td valign="top">
                    <p>
                        Calendar:
                    </p>
                    <eo:Calendar ID="Calendar1" ControlSkinID="None" VisibleDate="2008-04-01" TitleRightArrowDownImageUrl="00040104"
                        TitleRightArrowImageUrl="00040102" DayCellWidth="22" TitleLeftArrowImageUrl="00040101"
                        TitleLeftArrowDownImageUrl="00040103" DayCellHeight="16" DayHeaderFormat="Short"
                        runat="server" WeekNumberBase="Month">
                        <DayStyle CssText="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; text-decoration:none"></DayStyle>
                        <SelectedDayStyle CssText="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; background-image:url('00040105');color:white;">
                        </SelectedDayStyle>
                        <DisabledDayStyle CssText="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; COLOR: gray"></DisabledDayStyle>
                        <TitleStyle CssText="PADDING-RIGHT: 3px; PADDING-LEFT: 3px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; PADDING-BOTTOM: 3px; COLOR: white; PADDING-TOP: 3px; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #0054e3">
                        </TitleStyle>
                        <CalendarStyle CssText="border-bottom-color:Black;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Black;border-left-style:solid;border-left-width:1px;border-right-color:Black;border-right-style:solid;border-right-width:1px;border-top-color:Black;border-top-style:solid;border-top-width:1px;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;background-color:white">
                        </CalendarStyle>
                        <DayHoverStyle CssText="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; text-decoration:underline">
                        </DayHoverStyle>
                        <MonthStyle CssText="MARGIN: 0px 4px; cursor:hand"></MonthStyle>
                        <FooterTemplate>
                        <div style="FONT-WEIGHT: bold; FONT-SIZE: 11px; FONT-FAMILY: Tahoma&quot;">
                            <img src="{img:00040106}"> Today: {var:today:MM/dd/yyyy}
                        </div>
                        </FooterTemplate>
                        <WeekSelectorStyle CssText="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: silver">
                        </WeekSelectorStyle>
                        <TodayStyle CssText="background-image:url('00040106');"></TodayStyle>
                        <MonthSelectorStyle CssText="BACKGROUND-IMAGE: url(Images/week.gif); BORDER-BOTTOM: black 1px solid; BACKGROUND-COLOR: silver">
                        </MonthSelectorStyle>
                        <DayHeaderStyle CssText="FONT-SIZE: 11px; COLOR: #0054e3; BORDER-BOTTOM: black 1px solid; FONT-FAMILY: Tahoma">
                        </DayHeaderStyle>
                    </eo:Calendar>
                </td>
                <td width="30">
                </td>
                <td valign="top">
                    <p>
                        DatePicker:
                    </p>
                    <eo:DatePicker ID="DatePicker1" ControlSkinID="None" VisibleDate="2008-04-01" TitleRightArrowDownImageUrl="00040104"
                        TitleRightArrowImageUrl="00040102" DayCellWidth="22" TitleLeftArrowImageUrl="00040101"
                        TitleLeftArrowDownImageUrl="00040103" DayCellHeight="16" DayHeaderFormat="Short"
                        runat="server" WeekNumberBase="Month">
                        <CalendarStyle CssText="border-bottom-color:Black;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Black;border-left-style:solid;border-left-width:1px;border-right-color:Black;border-right-style:solid;border-right-width:1px;border-top-color:Black;border-top-style:solid;border-top-width:1px;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;background-color:white">
                        </CalendarStyle>
                        <SelectedDayStyle CssText="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; background-image:url('00040105');color:white;">
                        </SelectedDayStyle>
                        <TodayStyle CssText="background-image:url('00040106');"></TodayStyle>
                        <MonthStyle CssText="MARGIN: 0px 4px; cursor:hand"></MonthStyle>
                        <DayHoverStyle CssText="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; text-decoration:underline">
                        </DayHoverStyle>
                        <WeekSelectorStyle CssText="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: silver">
                        </WeekSelectorStyle>
                        <DisabledDayStyle CssText="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; COLOR: gray"></DisabledDayStyle>
                        <DayHeaderStyle CssText="FONT-SIZE: 11px; COLOR: #0054e3; BORDER-BOTTOM: black 1px solid; FONT-FAMILY: Tahoma">
                        </DayHeaderStyle>
                        <DayStyle CssText="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; text-decoration:none"></DayStyle>
                        <FooterTemplate>
                        <div style="FONT-WEIGHT: bold; FONT-SIZE: 11px; FONT-FAMILY: Tahoma&quot;">
                            <img src="{img:00040106}"> Today: {var:today:MM/dd/yyyy}
                        </div>
                        </FooterTemplate>
                        <MonthSelectorStyle CssText="BACKGROUND-IMAGE: url(Images/week.gif); BORDER-BOTTOM: black 1px solid; BACKGROUND-COLOR: silver">
                        </MonthSelectorStyle>
                        <TitleStyle CssText="PADDING-RIGHT: 3px; PADDING-LEFT: 3px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; PADDING-BOTTOM: 3px; COLOR: white; PADDING-TOP: 3px; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #0054e3">
                        </TitleStyle>
                    </eo:DatePicker>
                </td>
            </tr>
        </table>
    </eo:CallbackPanel>
</asp:Content>

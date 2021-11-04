<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Features_Title_and_Footer_Template_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
var g_curCalendar = null;

function ShowMonthPopup(calendar, refLink)
{
    g_curCalendar = calendar;
    var monthPicker = document.getElementById(refLink);
    eo_GetObject(g_curCalendar).showContextMenu(monthPicker, "mnuMonth");
}

function MonthMenuClicked(e, info)
{
    var month = info.getItem().getIndex();
    var calendar = eo_GetObject(g_curCalendar);
    
    //Get the current month
    var curMonth = calendar.getVisibleDate();
    
    //Change the month
    curMonth.setMonth(month);
    
    //Set the new current month
    calendar.goTo(curMonth);
}

function ShowYearPopup(calendar, refLink)
{
    g_curCalendar = calendar;
    var yearPicker = document.getElementById(refLink);
    eo_GetObject(g_curCalendar).showContextMenu(yearPicker, "mnuYear");
}

function YearMenuClicked(e, info)
{
    var year = info.getItem().getIndex();
    var calendar = eo_GetObject(g_curCalendar);
    
    //Get the current month
    var curMonth = calendar.getVisibleDate();
    
    //Set the new year
    curMonth.setFullYear(year + 1980);
    
    //Set the new current month
    calendar.goTo(curMonth);
}
</script>
<p>
    EO.Web Calendar supports customized title and footer. Use <span class="highlight">TitleTemplate</span>
    and <span class="highlight">FooterTemplate</span> to provide a customized 
    version of the title and footer templates. Inside the templates you can use <span class="highlight">
        Variables</span> that will be evaluated at runtime every time the Calendar 
    refreshes.
</p>
<p>
    The following sample uses a customized header to displays a month popup menu 
    and a year popup menu, and a customized footer to displays today's date. Click 
    the black arrow next to the month or year to display the popup menus. Note the
    custom header uses <strong>ContextMenu</strong> control, which is not part
    of the Calendar control. so the license for the Calendar does not cover the 
    license for the menu.
</p>
<p>
</p>
<table border="0">
    <tr>
        <td>Calendar:</td>
        <td width="30px"></td>
        <td>DatePicker:</td>
    </tr>
    <tr>
        <td valign="top">
            <eo:Calendar runat="server" id="Calendar1" DayHeaderFormat="Short" TitleFormat="MMMM, yyyy" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
                DayCellHeight="15" OtherMonthDayVisible="True" DayCellWidth="31" TitleRightArrowImageUrl="DefaultSubMenuIcon"
                TitleTemplateScope="TextOnly">
                <TitleTemplate>
                    {var:visible_date:MMMM}
                    <a id="{var:clientId}_month" href="javascript:ShowMonthPopup('{var:clientId}', '{var:clientId}_month')"><img src="{img:00020012}" border="0" /></a>
                    {var:visible_date:yyyy}
                    <a id="{var:clientId}_year" href="javascript:ShowYearPopup('{var:clientId}', '{var:clientId}_year')"><img src="{img:00020012}" border="0" /></a>
                </TitleTemplate>
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
                                <td valign="center"><a href="javascript:eo_GetObject('{var:clientId}').setSelectedDate(new Date());"><img border="0" src="{img:00040401}"></a></td>
                                <td valign="center">Today: {var:today:MM/dd/yyyy}</td>
                            </tr>
                        </table>
                    </FooterTemplate>
                <TodayStyle CssText="background-image:url('00040401');color:#1176db;"></TodayStyle>
                <DayHeaderStyle CssText="border-bottom: #f5f5f5 1px solid"></DayHeaderStyle>
            </eo:Calendar>
        </td>
        <td></td>
        <td valign="top">
            <eo:DatePicker runat="server" id="DatePicker1" DayHeaderFormat="Short" TitleFormat="MMMM, yyyy"
                TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" DayCellHeight="15" OtherMonthDayVisible="True"
                DayCellWidth="31" TitleRightArrowImageUrl="DefaultSubMenuIcon" TitleTemplateScope="TextOnly">
                <TitleTemplate>
                    {var:visible_date:MMMM}
                    <a id="{var:clientId}_month" href="javascript:ShowMonthPopup('{var:clientId}', '{var:clientId}_month')"><img src="{img:00020012}" border="0" /></a>
                    {var:visible_date:yyyy}
                    <a id="{var:clientId}_year" href="javascript:ShowYearPopup('{var:clientId}', '{var:clientId}_year')"><img src="{img:00020012}" border="0" /></a>
                </TitleTemplate>
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
            </eo:DatePicker>
        </td>
    </tr>
</table>
<eo:ContextMenu runat="server" id="mnuMonth" ControlSkinID="None" Width="80px" ClientSideOnItemClick="MonthMenuClicked">
    <TopGroup Style-CssText="border-left-color:#e0e0e0;border-left-style:solid;border-left-width:1px;border-right-color:#e0e0e0;border-right-style:solid;border-right-width:1px;border-top-color:#e0e0e0;border-top-style:solid;border-top-width:1px;cursor:hand;font-family:arial;font-size:12px;padding-bottom:3px;padding-left:10px;padding-right:10px;padding-top:3px;"
        OffsetX="0" OffsetY="-100">
        <Items>
            <eo:MenuItem Text-Html="January"></eo:MenuItem>
            <eo:MenuItem Text-Html="February"></eo:MenuItem>
            <eo:MenuItem Text-Html="March"></eo:MenuItem>
            <eo:MenuItem Text-Html="April"></eo:MenuItem>
            <eo:MenuItem Text-Html="May"></eo:MenuItem>
            <eo:MenuItem Text-Html="June"></eo:MenuItem>
            <eo:MenuItem Text-Html="July"></eo:MenuItem>
            <eo:MenuItem Text-Html="August"></eo:MenuItem>
            <eo:MenuItem Text-Html="September"></eo:MenuItem>
            <eo:MenuItem Text-Html="October"></eo:MenuItem>
            <eo:MenuItem Text-Html="November"></eo:MenuItem>
            <eo:MenuItem Text-Html="December"></eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem HoverStyle-CssText="color:#1C7CDC;padding-left:5px;padding-right:5px;" ItemID="_Default"
            NormalStyle-CssText="color:#2C0B1E;padding-left:5px;padding-right:5px;">
            <SubMenu Style-CssText="background-color:White;border-bottom-color:#e0e0e0;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#e0e0e0;border-left-style:solid;border-left-width:1px;border-right-color:#e0e0e0;border-right-style:solid;border-right-width:1px;border-top-color:#e0e0e0;border-top-style:solid;border-top-width:1px;color:#606060;cursor:hand;font-family:arial;font-size:12px;padding-bottom:3px;padding-left:3px;padding-right:3px;padding-top:3px;"
                ShadowDepth="0" ItemSpacing="5"></SubMenu>
        </eo:MenuItem>
    </LookItems>
</eo:ContextMenu>
<eo:ContextMenu runat="server" id="mnuYear" ControlSkinID="None" Width="80px" ClientSideOnItemClick="YearMenuClicked"
    EnableScrolling="True" ScrollUpLookID="scroll_up" ScrollDownLookID="scroll_down">
    <TopGroup Style-CssText="border-left-color:#e0e0e0;border-left-style:solid;border-left-width:1px;border-right-color:#e0e0e0;border-right-style:solid;border-right-width:1px;border-top-color:#e0e0e0;border-top-style:solid;border-top-width:1px;cursor:hand;font-family:arial;font-size:12px;padding-bottom:3px;padding-left:10px;padding-right:10px;padding-top:3px;"
        OffsetX="0" Height="150" OffsetY="-50">
        <Items>
            <eo:MenuItem Text-Html="1980"></eo:MenuItem>
            <eo:MenuItem Text-Html="1981"></eo:MenuItem>
            <eo:MenuItem Text-Html="1982"></eo:MenuItem>
            <eo:MenuItem Text-Html="1983"></eo:MenuItem>
            <eo:MenuItem Text-Html="1984"></eo:MenuItem>
            <eo:MenuItem Text-Html="1985"></eo:MenuItem>
            <eo:MenuItem Text-Html="1986"></eo:MenuItem>
            <eo:MenuItem Text-Html="1987"></eo:MenuItem>
            <eo:MenuItem Text-Html="1988"></eo:MenuItem>
            <eo:MenuItem Text-Html="1989"></eo:MenuItem>
            <eo:MenuItem Text-Html="1990"></eo:MenuItem>
            <eo:MenuItem Text-Html="1991"></eo:MenuItem>
            <eo:MenuItem Text-Html="1992"></eo:MenuItem>
            <eo:MenuItem Text-Html="1993"></eo:MenuItem>
            <eo:MenuItem Text-Html="1994"></eo:MenuItem>
            <eo:MenuItem Text-Html="1995"></eo:MenuItem>
            <eo:MenuItem Text-Html="1996"></eo:MenuItem>
            <eo:MenuItem Text-Html="1997"></eo:MenuItem>
            <eo:MenuItem Text-Html="1998"></eo:MenuItem>
            <eo:MenuItem Text-Html="1999"></eo:MenuItem>
            <eo:MenuItem Text-Html="2000"></eo:MenuItem>
            <eo:MenuItem Text-Html="2001"></eo:MenuItem>
            <eo:MenuItem Text-Html="2002"></eo:MenuItem>
            <eo:MenuItem Text-Html="2003"></eo:MenuItem>
            <eo:MenuItem Text-Html="2004"></eo:MenuItem>
            <eo:MenuItem Text-Html="2005"></eo:MenuItem>
            <eo:MenuItem Text-Html="2006"></eo:MenuItem>
            <eo:MenuItem Text-Html="2007"></eo:MenuItem>
            <eo:MenuItem Text-Html="2008"></eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem HoverStyle-CssText="color:#1C7CDC;padding-left:5px;padding-right:5px;" ItemID="_Default"
            NormalStyle-CssText="color:#2C0B1E;padding-left:5px;padding-right:5px;">
            <SubMenu Style-CssText="background-color:White;border-bottom-color:#e0e0e0;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#e0e0e0;border-left-style:solid;border-left-width:1px;border-right-color:#e0e0e0;border-right-style:solid;border-right-width:1px;border-top-color:#e0e0e0;border-top-style:solid;border-top-width:1px;color:#606060;cursor:hand;font-family:arial;font-size:12px;padding-bottom:3px;padding-left:3px;padding-right:3px;padding-top:3px;"
                ShadowDepth="0" ItemSpacing="5"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem Height="14" ItemID="scroll_down" NormalStyle-CssText="background-image:url('00020005');border-bottom-color:#E0E0E0;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#E0E0E0;border-left-style:solid;border-left-width:1px;border-right-color:#E0E0E0;border-right-style:solid;border-right-width:1px;border-top-color:#E0E0E0;border-top-style:solid;border-top-width:1px;"
            Image-Url="00020001"></eo:MenuItem>
        <eo:MenuItem Height="14" ItemID="scroll_up" NormalStyle-CssText="background-image:url('00020005');border-bottom-color:#E0E0E0;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#E0E0E0;border-left-style:solid;border-left-width:1px;border-right-color:#E0E0E0;border-right-style:solid;border-right-width:1px;border-top-color:#E0E0E0;border-top-style:solid;border-top-width:1px;"
            Image-Url="00020000"></eo:MenuItem>
    </LookItems>
</eo:ContextMenu>
</asp:Content>


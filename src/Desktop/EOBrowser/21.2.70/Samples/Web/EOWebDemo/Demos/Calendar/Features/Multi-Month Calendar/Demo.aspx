<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Features_Multi_Month_Calendar_Demo"
    Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        EO.Web Calendar supports multi-month view. Simply set <span class="highlight">MonthRows</span>
        and <span class="highlight">MonthColumns</span> to a number greater than 1 to enable
        multi-month mode.
    </p>
    <p>
        Click the link below to switch number of months. The sample uses a <span class="highlight">
            CallbackPanel</span> to avoid full page reload.
    </p>
    <eo:CallbackPanel runat="server" ID="CallbackPanel1" Triggers="{ControlID:LinkButton1;Parameter:}">
        <p>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Switch To 2 Months</asp:LinkButton></p>
        <eo:Calendar ID="Calendar1" runat="server" TitleFormat="MMMM, yyyy" TitleRightArrowImageUrl="DefaultSubMenuIcon"
            TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" DayHeaderFormat="Short" OtherMonthDayVisible="True"
            DayCellWidth="31" DayCellHeight="15">
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
            <MonthStyle CssText="cursor:hand;font-family:Verdana;font-size:8pt;margin-bottom:0px;margin-left:4px;margin-right:4px;margin-top:0px;">
            </MonthStyle>
            <TitleStyle CssText="font-family:Verdana;font-size:8.75pt;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;">
            </TitleStyle>
            <TitleArrowStyle CssText="cursor: hand"></TitleArrowStyle>
            <CalendarStyle CssText="background-color:white;border-bottom-color:Silver;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Silver;border-left-style:solid;border-left-width:1px;border-right-color:Silver;border-right-style:solid;border-right-width:1px;border-top-color:Silver;border-top-style:solid;border-top-width:1px;color:#2C0B1E;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;">
            </CalendarStyle>
            <TodayStyle CssText="background-image:url('00040401');color:#1176db;"></TodayStyle>
        </eo:Calendar>
    </eo:CallbackPanel>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Features_Date_and_Time_Picker_Demo"
    Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        EO.Web DatePicker can also be used to enter both date and time. To enable this feature,
        simply uses one or more supported time related specifiers in <strong>PickerFormat</strong>.
        The following DatePicker has its <strong>PickerFormat</strong> set to <span class="highlight">
            MM/dd/yyyy hh:mm:ss tt</span>. Input must contains both date and time value
        to be valid.
    </p>
    <eo:CallbackPanel runat="server" ID="CallbackPanel1" Triggers="{ControlID:btnSubmit;Parameter:}">
        <eo:DatePicker ID="DatePicker1" runat="server" DayHeaderFormat="FirstLetter" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
            DayCellHeight="16" OtherMonthDayVisible="True" DayCellWidth="19" TitleRightArrowImageUrl="DefaultSubMenuIcon"
            VisibleDate="2007-07-01" ControlSkinID="None" PickerFormat="MM/dd/yyyy hh:mm:ss tt">
            <DayHoverStyle CssText="border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid">
            </DayHoverStyle>
            <TitleStyle CssText="background-color:#9ebef5;font-family:Tahoma;font-size:12px;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;">
            </TitleStyle>
            <DayHeaderStyle CssText="border-bottom: #aca899 1px solid"></DayHeaderStyle>
            <DayStyle CssText="border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            </DayStyle>
            <SelectedDayStyle CssText="background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            </SelectedDayStyle>
            <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
            <TodayStyle CssText="border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid">
            </TodayStyle>
            <PickerStyle CssText="font-family:Courier New; padding-left:5px; padding-right: 5px;">
            </PickerStyle>
            <OtherMonthDayStyle CssText="color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            </OtherMonthDayStyle>
            <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma">
            </CalendarStyle>
            <DisabledDayStyle CssText="color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            </DisabledDayStyle>
            <MonthStyle CssText="font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px; font-family: tahoma">
            </MonthStyle>
        </eo:DatePicker>
        <p>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"></asp:Button></p>
        <p>
            <asp:Label ID="lblResult" runat="server"></asp:Label></p>
    </eo:CallbackPanel>
</asp:Content>

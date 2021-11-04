<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Programming_Client_Side_Validation_Demo"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

    <script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
function ValidateDates()
{
    //Clear the message first
    var errorDiv = document.getElementById("error_div");
    errorDiv.innerHTML = "";
    
    //Get both dates
    var startDate = eo_GetObject("StartDatePicker").getSelectedDate();
    var endDate = eo_GetObject("EndDatePicker").getSelectedDate();
    
    //Check if both dates are provided
    if ((startDate == null) || (endDate == null))
    {
        errorDiv.innerHTML = "Please enter both dates.";
        return false;        
    }
    
    //Check if the start date is before the end date
    if (startDate.valueOf() > endDate.valueOf())
    {
        errorDiv.innerHTML = "The start date must be before the end date."; 
        return false;
    }
}

function CallbackBeforeExecute(callback)
{
    return ValidateDates();
}
//<!--JS_SAMPLE_END-->
    </script>

    <p>
        The sample demonstrates validating two dates against each other on the client side.
    </p>
    <p>
    </p>
    <eo:CallbackPanel runat="server" ID="CallbackPanel1" Triggers="{ControlID:btnSubmit;Parameter:}"
        ClientSideBeforeExecute="CallbackBeforeExecute">
        <asp:Panel ID="panInput" runat="server">
            <table border="0">
                <tr>
                    <td>
                        Start Date:</td>
                    <td>
                    </td>
                    <td>
                        End Date:</td>
                </tr>
                <tr>
                    <td>
                        <eo:DatePicker ID="StartDatePicker" runat="server" DayHeaderFormat="FirstLetter"
                            TitleRightArrowImageUrl="DefaultSubMenuIcon" DayCellWidth="19" OtherMonthDayVisible="True"
                            DayCellHeight="16" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" Width="120px">
                            <SelectedDayStyle CssText="background-color: #fbe694"></SelectedDayStyle>
                            <OtherMonthDayStyle CssText="color: gray"></OtherMonthDayStyle>
                            <TodayStyle CssText="border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid">
                            </TodayStyle>
                            <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
                            <TitleStyle CssText="background-color:#9ebef5;font-family:Tahoma;font-size:12px;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;">
                            </TitleStyle>
                            <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma">
                            </CalendarStyle>
                            <DayHoverStyle CssText="border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid">
                            </DayHoverStyle>
                            <MonthStyle CssText="font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px; font-family: tahoma">
                            </MonthStyle>
                            <PickerStyle CssText="font-family:Courier New; padding-left:5px; padding-right: 5px;">
                            </PickerStyle>
                            <DayStyle CssText="border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
                            </DayStyle>
                            <DayHeaderStyle CssText="border-bottom: #aca899 1px solid"></DayHeaderStyle>
                        </eo:DatePicker>
                    </td>
                    <td width="30">
                    </td>
                    <td>
                        <eo:DatePicker ID="EndDatePicker" runat="server" DayHeaderFormat="FirstLetter" TitleRightArrowImageUrl="DefaultSubMenuIcon"
                            DayCellWidth="19" OtherMonthDayVisible="True" DayCellHeight="16" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
                            Width="120px">
                            <SelectedDayStyle CssText="background-color: #fbe694"></SelectedDayStyle>
                            <OtherMonthDayStyle CssText="color: gray"></OtherMonthDayStyle>
                            <TodayStyle CssText="border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid">
                            </TodayStyle>
                            <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
                            <TitleStyle CssText="background-color:#9ebef5;font-family:Tahoma;font-size:12px;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;">
                            </TitleStyle>
                            <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma">
                            </CalendarStyle>
                            <DayHoverStyle CssText="border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid">
                            </DayHoverStyle>
                            <MonthStyle CssText="font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px; font-family: tahoma">
                            </MonthStyle>
                            <PickerStyle CssText="font-family:Courier New; padding-left:5px; padding-right: 5px;">
                            </PickerStyle>
                            <DayStyle CssText="border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
                            </DayStyle>
                            <DayHeaderStyle CssText="border-bottom: #aca899 1px solid"></DayHeaderStyle>
                        </eo:DatePicker>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" height="20">
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnSubmit" runat="server" Width="80px" Text="Submit" OnClick="btnSubmit_Click">
                        </asp:Button></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <font color="red">
                            <div id="error_div">
                            </div>
                        </font>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Label ID="lblResult" runat="server" Visible="False"></asp:Label>
    </eo:CallbackPanel>
    <p>
        EO.Web Calendar/DatePicker also supports standard ASP.NET validation controls. Please
        see the documentation for more detail.
    </p>
</asp:Content>

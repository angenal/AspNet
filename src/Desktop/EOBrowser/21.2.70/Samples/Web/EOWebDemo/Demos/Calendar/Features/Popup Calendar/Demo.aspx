<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Features_Popup_Calendar_Demo"
    Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">

    <script type="text/javascript">

var callbackParamPrefix;

function ChangeDate(taskId, beginDate)
{
    //Format the callback date prefix
    callbackParamPrefix = taskId + "," + (beginDate ? "Y" : "");

    //We start by finding the marker
    var marker = document.getElementById("marker_" + taskId);
    
    //Get the row that contains the marker
    var row = marker;
    while (row && (row.nodeType == 1) && (row.tagName.toLowerCase() != "tr"))
        row = row.parentNode;
        
    //Get the cell that was clicked
    var cell = beginDate ? row.cells[2] : row.cells[3];
    
    //Show the popup calendar
    eo_ShowPopupCalendar("PopupCalendar1", cell);
}

function OnCalendarSelect(calendar)
{
    var callbackParam = 
        callbackParamPrefix + "," + eo_DateToString(calendar.getSelectedDate());

    eo_Callback('<%=CallbackPanel1.ClientID%>', callbackParam);
}
    </script>

    <p>
        EO.Web offers a <span class="highlight">PopupCalendar</span> class for you to programmatically
        displays a drop down calendar anywhere you'd like in your code.
    </p>
    <p>
        The following sample demonstrates how to displays a popup calendar in a DataGrid.
        It also uses a CallbackPanel to update the DataGrid.
    </p>
    <eo:CallbackPanel ID="CallbackPanel1" runat="server" OnExecute="CallbackPanel1_Execute">
        <asp:DataGrid ID="DataGrid1" runat="server" Width="500px" CellPadding="2" AutoGenerateColumns="False"
            BorderWidth="1px" BorderColor="Gainsboro">
            <Columns>
                <asp:TemplateColumn HeaderText="Task ID">
                    <ItemTemplate>
                        <span id='marker_<%#DataBinder.Eval(Container, "DataItem.TaskID")%>'></span>
                        <asp:Label runat="server" ID="taskId" Text='<%# DataBinder.Eval(Container, "DataItem.TaskID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="TaskName" HeaderText="Task Name"></asp:BoundColumn>
                <asp:TemplateColumn HeaderText="Start Date">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="startDate" Text='<%# DataBinder.Eval(Container, "DataItem.StartDate", "{0:d}") %>'>
                        </asp:Label><br />
                        <a runat="server" id="startDateChangeLink">Click To Change</a>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="End Date">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="endDate" Text='<%# DataBinder.Eval(Container, "DataItem.EndDate", "{0:d}") %>'>
                        </asp:Label><br />
                        <a runat="server" id="endDateChangeLink">Click To Change</a>
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
        </asp:DataGrid>
    </eo:CallbackPanel>
    <eo:PopupCalendar ID="PopupCalendar1" runat="server" TitleRightArrowHoverImageUrl="00040207"
        TitleRightArrowImageUrl="00040206" DayCellWidth="24" DayCellHeight="16" TitleLeftArrowImageUrl="00040204"
        DisableWeekendDays="True" TitleLeftArrowHoverImageUrl="00040205" ClientSideOnSelect="OnCalendarSelect">
        <SelectedDayStyle CssText="background-image: url(00040208)"></SelectedDayStyle>
        <DisabledDayStyle CssText="color:Gray;"></DisabledDayStyle>
        <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; font-size: 8pt; padding-bottom: 3px; color: black; padding-top: 3px; font-family: tahoma; background-color: transparent">
        </TitleStyle>
        <CalendarStyle CssText="background-color:White;border-bottom-color:Black;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Black;border-left-style:solid;border-left-width:1px;border-right-color:Black;border-right-style:solid;border-right-width:1px;border-top-color:Black;border-top-style:solid;border-top-width:1px;">
        </CalendarStyle>
        <MonthStyle CssText="font-size: 8pt; cursor: hand; font-family: verdana"></MonthStyle>
        <DayHoverStyle CssText="background-image:url('00040208');"></DayHoverStyle>
        <DayHeaderStyle CssText="font-weight: bold; font-size: 11px; color: black; border-bottom: black 1px solid; font-family: verdana">
        </DayHeaderStyle>
    </eo:PopupCalendar>
</asp:Content>

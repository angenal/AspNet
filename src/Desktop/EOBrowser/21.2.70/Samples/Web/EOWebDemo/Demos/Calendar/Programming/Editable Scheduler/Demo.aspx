<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Programming_Editable_Scheduler_Demo"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

    <script type="text/javascript">
var curDate = null;

function EditNote(dayId)
{
    //Get the cell in which the edit to take place
    var dayTable = document.getElementById(dayId);
    
    //Get the date associated with the cell
    curDate = eo_StringToDate(dayId.substr(6).replace(/_/g, '-'));
    
    //Prepare the edit pad
    var calendar = eo_GetObject('<%=Calendar1.ClientID%>');
    var editPad = document.getElementById("editPad");
    var editPadTable = document.getElementById("editPadTable");
    editPadTable.rows[0].cells[0].innerHTML = calendar.formatDate(curDate, "MM/dd/yyyy");
    var txtNote = document.getElementById("txtNote");
    txtNote.value = dayTable.rows[1].cells[0].innerHTML.trim();
    
    //Display the edit pad
    eo_ShowPopup(editPad, dayTable);
    
    //Show the edit pad
    editPad.style.display = "block";
    txtNote.focus();
}

function CancelNote()
{
    //Hide the popup
    eo_HideAllPopups();
}

function SaveNote()
{
    //Hide the popup
    eo_HideAllPopups();

    //Validate the input
    var txtNote = document.getElementById("txtNote");
    var s = txtNote.value;
    if ((s == null) || (s == ""))
    {
        window.alert("Please enter something.");
        return;
    }
    if ((s.indexOf('<') >= 0) || (s.indexOf('>') >= 0))
    {
        window.alert("HTML code is not allowed.");
        return;
    }
    
    //Save the note
    s = eo_DateToString(curDate) + s;
    eo_Callback('<%=CallbackPanel1.ClientID%>', s);
}
    </script>

    <p>
        The following sample implements an editable calendar. Click any date to add or edit
        note on the calendar.
    </p>
    <eo:CallbackPanel ID="CallbackPanel1" Triggers="{ControlID:Calendar1;Parameter:}"
        runat="server" OnExecute="CallbackPanel1_Execute">
        <eo:Calendar ID="Calendar1" runat="server" TitleTemplateScope="TextOnly" GridLineColor="207, 217, 227"
            TitleFormat="MMMM, yyyy" TitleLeftArrowHtml="&amp;lt;" DayHeaderFormat="Full"
            TitleRightArrowHtml="&amp;gt;" GridLineVisible="True" DayCellWidth="72" DayCellHeight="45"
            GridLineFrameVisible="False" OnDayRender="Calendar1_DayRender">
            <DayStyle CssText="BORDER-RIGHT: #eaeaea 1px solid; BORDER-TOP: #eaeaea 1px solid; FONT-SIZE: 9px; BORDER-LEFT: #eaeaea 1px solid; BORDER-BOTTOM: #eaeaea 1px solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: #eaeaea; TEXT-ALIGN: right">
            </DayStyle>
            <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; padding-bottom: 3px; color: white; padding-top: 3px; border-bottom: #cfd9e3 1px solid; background-color: #006699; font-size: 11px; font-family: verdana;">
            </TitleStyle>
            <CalendarStyle CssText="border-right: #cfd9e3 1px solid; border-top: #cfd9e3 1px solid; font-size: 11px; border-left: #cfd9e3 1px solid; cursor: hand; border-bottom: #cfd9e3 1px solid; font-family: verdana; background-color: #eaeaea">
            </CalendarStyle>
            <DayHoverStyle CssText="BORDER-RIGHT: #dadada 1px solid; BORDER-TOP: #dadada 1px solid; FONT-SIZE: 9px; BORDER-LEFT: #dadada 1px solid; BORDER-BOTTOM: #dadada 1px solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: #dadada; TEXT-ALIGN: right">
            </DayHoverStyle>
            <MonthStyle CssText="font-size: 11px; font-family: verdana;"></MonthStyle>
            <DayHeaderStyle CssText="height: 17px"></DayHeaderStyle>
        </eo:Calendar>
    </eo:CallbackPanel>
    <div id="editPad" style="display: none; z-index: 100; position: absolute; overflow: auto;">
        <table id="editPadTable" style="border-collapse: collapse; background-color: lemonchiffon"
            bordercolor="#cfd9d9" cellspacing="0" cellpadding="2" border="1">
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <textarea id="txtNote" rows="3">            </textarea>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <a href="javascript:SaveNote();">Save</a>&nbsp; <a href="javascript:CancelNote();">Cancel</a>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Grid_Features_Custom_Column___Advanced_3_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        This sample enables "Avaiable On" column only when "Back Ordered"
        is checked.
    </p>
    <script type="text/javascript">
    var g_DatePicker = null;
    
    function datepicker_loaded(obj)
    {
        g_DatePicker = obj;
    }
    
    //Check whether "Back Ordered" column is checked
    function is_back_ordered(item)
    {
        return item.getCell(1).getValue() == "1";
    }
    
    //This function is called when user checks/unchecks
    //"back ordered" column
    function end_edit_back_ordered(cell, newValue)
    {
        //Get the GridItem object
        var item = cell.getItem();
        
        //Force update the "Available On" cell. Note
        //the code must be delayed with a timer so that
        //the value of the "Back Ordered" cell is first
        //updated
        setTimeout(function()
        {
            var availOnCell = item.getCell(2);
            availOnCell.refresh();
        }, 10);
        
        //Accept the new value
        return newValue;
    }
    
    //This function is called for "Available On" column
    //to translate a cell value to the final HTML to be
    //displayed in the cell. You can put any HTML inside
    //the grid cell even though this function only returns
    //simple text. For example, instead of returning
    //"N/A", you can return something like this:
    // <input type="text" disabled="disabled" style="width:100px" />
    //This would render a disabled textbox inside the Grid cell
    //when no value should be entered for "available On"
    //column. Note that the textbox rendered by this 
    //function, regardless disabled or not, are never
    //used by the user because the actual editing UI is
    //specified by the column's EditorTemplate, which is
    //a DatePicker control for this sample
    function get_avail_on_text(column, item, cellValue)
    {
        if (!is_back_ordered(item))
            return "N/A";
        else
        {
            if (!cellValue)
                return "Click to edit";
            else
                return g_DatePicker.formatDate(cellValue, "MM/dd/yyyy");
        }
    }
    
    //This function is called when user clicks any cell in 
    //the "Available On" column. 
    function begin_edit_avail_on_date(cell)
    {
        //Get the item object
        var item = cell.getItem();
        
        //Do not enter edit mode unless "back ordered" is checked
        if (!is_back_ordered(item))
            return false;
        
        //Load cell value into the DatePicker control
        var v = cell.getValue();        
        g_DatePicker.setSelectedDate(v);
    }
    
    //This function is called when user leaves edit mode
    //from an "Available On" cell. It returns the DatePicker
    //value to the Grid
    function end_edit_avail_on_date(cell)
    {
        return g_DatePicker.getSelectedDate();
    }
    </script>
    <eo:Grid runat="server" ID="Grid1" BorderColor="#828790" BorderWidth="1px" ColumnHeaderAscImage="00050204" ColumnHeaderDescImage="00050205" ColumnHeaderDividerImage="00050203" ColumnHeaderHeight="24" FixedColumnCount="1" Font-Bold="False" Font-Italic="False" Font-Names="Tahoma" Font-Overline="False" Font-Size="8.75pt" Font-Strikeout="False" Font-Underline="False" GridLineColor="240, 240, 240" GridLines="Both" Height="200px" ItemHeight="19" Width="500px" FullRowMode="false" EnableKeyboardNavigation="true">
        <FooterStyle CssText="padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px;" />
        <ItemStyles>
            <eo:GridItemStyleSet>
                <ItemStyle CssText="background-color: white" />
                <ItemHoverStyle CssText="background-image: url(00050206); background-repeat: repeat-x" />
                <SelectedStyle CssText="background-image: url(00050207); background-repeat: repeat-x" />
                <CellStyle CssText="padding-left:8px;padding-top:2px;white-space:nowrap;" />
            </eo:GridItemStyleSet>
        </ItemStyles>
        <ColumnTemplates>
            <eo:TextBoxColumn>
                <TextBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 8.75pt; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; FONT-FAMILY: Tahoma" />
            </eo:TextBoxColumn>
            <eo:DateTimeColumn>
                <DatePicker ControlSkinID="None" DayCellHeight="16" DayCellWidth="19" DayHeaderFormat="FirstLetter"
                    DisabledDates="" OtherMonthDayVisible="True" SelectedDates="" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
                    TitleRightArrowImageUrl="DefaultSubMenuIcon">
                    <TodayStyle CssText="font-family: tahoma; font-size: 12px; border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid" />
                    <SelectedDayStyle CssText="font-family: tahoma; font-size: 12px; background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid" />
                    <DisabledDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid" />
                    <PickerStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;font-family:Courier New;font-size:8pt;margin-bottom:0px;margin-left:0px;margin-right:0px;margin-top:0px;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;" />
                    <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma" />
                    <TitleArrowStyle CssText="cursor:hand" />
                    <DayHoverStyle CssText="font-family: tahoma; font-size: 12px; border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid" />
                    <MonthStyle CssText="font-family: tahoma; font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px" />
                    <TitleStyle CssText="background-color:#9ebef5;font-family:Tahoma;font-size:12px;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;" />
                    <OtherMonthDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid" />
                    <DayHeaderStyle CssText="font-family: tahoma; font-size: 12px; border-bottom: #aca899 1px solid" />
                    <DayStyle CssText="font-family: tahoma; font-size: 12px; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid" />
                </DatePicker>
            </eo:DateTimeColumn>
            <eo:MaskedEditColumn>
                <MaskedEdit ControlSkinID="None" TextBoxStyle-CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; font-family:Courier New;font-size:8pt;">
                </MaskedEdit>
            </eo:MaskedEditColumn>
        </ColumnTemplates>
        <ColumnHeaderHoverStyle CssText="background-image:url('00050202');padding-left:8px;padding-top:4px;" />
        <Columns>
            <eo:StaticColumn HeaderText="Item" DataField="ItemName" Width="250">
            </eo:StaticColumn>
            <eo:CheckBoxColumn HeaderText="Back Ordered" DataField="BackOrdered" Width="100" ClientSideEndEdit="end_edit_back_ordered">
            </eo:CheckBoxColumn>
            <eo:CustomColumn HeaderText="Available On" DataField="AvailableOn" Width="140"
              ClientSideGetText="get_avail_on_text"
              ClientSideBeginEdit="begin_edit_avail_on_date"
              ClientSideEndEdit ="end_edit_avail_on_date">
                <EditorTemplate>
                    <eo:DatePicker runat="server" ID="dpAvailOn" ControlSkinID="None" DayCellHeight="16" DayCellWidth="19" DayHeaderFormat="FirstLetter" DisabledDates="" OtherMonthDayVisible="True" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" TitleRightArrowImageUrl="DefaultSubMenuIcon" ClientSideOnLoad="datepicker_loaded">
                        <TodayStyle CssText="font-family: tahoma; font-size: 12px; border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid" />
                        <SelectedDayStyle CssText="font-family: tahoma; font-size: 12px; background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid" />
                        <DisabledDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid" />
                        <PickerStyle CssText="font-family:Courier New; padding-left:5px; padding-right: 5px;" />
                        <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma" />
                        <TitleArrowStyle CssText="cursor:hand" />
                        <DayHoverStyle CssText="font-family: tahoma; font-size: 12px; border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid" />
                        <MonthStyle CssText="font-family: tahoma; font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px" />
                        <TitleStyle CssText="background-color:#9ebef5;font-family:Tahoma;font-size:12px;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;" />
                        <OtherMonthDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid" />
                        <DayHeaderStyle CssText="font-family: tahoma; font-size: 12px; border-bottom: #aca899 1px solid" />
                        <DayStyle CssText="font-family: tahoma; font-size: 12px; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid" />
                    </eo:DatePicker>
                </EditorTemplate>
            </eo:CustomColumn>
        </Columns>
        <ColumnHeaderStyle CssText="background-image:url('00050201');padding-left:8px;padding-top:4px;" />
    </eo:Grid>
</asp:Content>


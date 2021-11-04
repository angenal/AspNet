<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Grid_Features_Custom_Column_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
function on_column_gettext(column, item, cellValue)
{
    if (cellValue == 5)
        return "Excellent";
    else if (cellValue == 4)
        return "Good";
    else if (cellValue == 3)
        return "Fair";
    else if (cellValue == 2)
        return "Poor";
    else if (cellValue == 1)
        return "Horrible";
    else
        return "&lt;Click to edit&gt;";
}

function on_begin_edit(cell)
{
    //Get the current cell value
    var v = cell.getValue();
    
    //Use index 0 if there is no value
    if (v == null)
        v = 0;
    
    //Load the value into our drop down box
    var dropDownBox = document.getElementById("grade_dropdown");
    dropDownBox.selectedIndex = v;
}

function on_end_edit(cell)
{
    //Get the new value from the drop down box
    var dropDownBox = document.getElementById("grade_dropdown");
    var v = dropDownBox.selectedIndex;
    
    //Use null value if user has not selected a
    //value or selected "-Please Select-"
    if (v == 0)    
        v = null;
    
    //Return the new value to the grid    
    return v;
}
//<!--JS_SAMPLE_END-->
</script>
<p>
    CustomColumn allows you to customize the display and editing of the cell data. 
    The following sample demonstrated a CustomColumn used that displays and edit 
    the grade information. The grade information is stored as an integer in the 
    data source, but the CustomColumn displays it as friendly text and uses a drop 
    down list box to edit it.
</p>
<p>
    The following sample demonstrates a simple survey with 5 questions that can 
    have a grade from "Poor" to "Excellent".
</p>
<eo:Grid runat="server" id="Grid1" BorderColor="#7F9DB9" BorderWidth="1px" GridLines="Both"
    ColumnHeaderDescImage="00050105" GridLineColor="220, 223, 228" Width="380px" IsCallbackByMe="False"
    ColumnHeaderAscImage="00050104" Height="200px" GoToBoxVisible="True" Font-Size="8.75pt"
    Font-Names="Tahoma" ColumnHeaderDividerImage="00050103" FullRowMode="False">
    <FooterStyle CssText="padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px;"></FooterStyle>
    <ItemStyles>
        <eo:GridItemStyleSet>
            <ItemHoverStyle CssText="background-color: whitesmoke"></ItemHoverStyle>
            <CellStyle CssText="padding-left:8px;padding-top:2px;"></CellStyle>
            <ItemStyle CssText="background-color: white"></ItemStyle>
            <FixedColumnCellStyle CssText="border-right: #d6d2c2 1px solid; padding-right: 10px; border-top: #faf9f4 1px solid; border-left: #faf9f4 1px solid; border-bottom: #d6d2c2 1px solid; background-color: #ebeadb; text-align: right; color: black;"></FixedColumnCellStyle>
        </eo:GridItemStyleSet>
    </ItemStyles>
    <GoToBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; BORDER-TOP: #7f9db9 1px solid; BORDER-LEFT: #7f9db9 1px solid; WIDTH: 40px; BORDER-BOTTOM: #7f9db9 1px solid"></GoToBoxStyle>
    <ContentPaneStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;"></ContentPaneStyle>
    <ColumnTemplates>
        <eo:TextBoxColumn>
            <TextBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 8.75pt; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; FONT-FAMILY: Tahoma"></TextBoxStyle>
        </eo:TextBoxColumn>
        <eo:DateTimeColumn>
            <DatePicker DayHeaderFormat="FirstLetter" DayCellHeight="16" DisabledDates="" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
                OtherMonthDayVisible="True" DayCellWidth="19" TitleRightArrowImageUrl="DefaultSubMenuIcon"
                ControlSkinID="None" SelectedDates="">
                <DayHoverStyle CssText="font-family: tahoma; font-size: 12px; border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid"></DayHoverStyle>
                <TitleStyle CssText="background-color:#9ebef5;font-family:Tahoma;font-size:12px;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;"></TitleStyle>
                <DayHeaderStyle CssText="font-family: tahoma; font-size: 12px; border-bottom: #aca899 1px solid"></DayHeaderStyle>
                <DayStyle CssText="font-family: tahoma; font-size: 12px; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></DayStyle>
                <SelectedDayStyle CssText="font-family: tahoma; font-size: 12px; background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></SelectedDayStyle>
                <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
                <TodayStyle CssText="font-family: tahoma; font-size: 12px; border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid"></TodayStyle>
                <PickerStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;font-family:Courier New;font-size:8pt;margin-bottom:0px;margin-left:0px;margin-right:0px;margin-top:0px;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></PickerStyle>
                <OtherMonthDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></OtherMonthDayStyle>
                <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma"></CalendarStyle>
                <DisabledDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></DisabledDayStyle>
                <MonthStyle CssText="font-family: tahoma; font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px"></MonthStyle>
            </DatePicker>
        </eo:DateTimeColumn>
        <eo:MaskedEditColumn>
            <MaskedEdit ControlSkinID="None" TextBoxStyle-CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; font-family:Courier New;font-size:8pt;"></MaskedEdit>
        </eo:MaskedEditColumn>
    </ColumnTemplates>
    <Columns>
        <eo:StaticColumn Width="200" Text="" HeaderText="Question"></eo:StaticColumn>
        <eo:CustomColumn Width="120" ClientSideEndEdit="on_end_edit" ClientSideGetText="on_column_gettext"
            ClientSideBeginEdit="on_begin_edit" HeaderText="Grade">
            <EditorTemplate>
                <select id="grade_dropdown">
                    <option>-Please Select-</option>
                    <option>Horrible</option>
                    <option>Poor</option>
                    <option>Fair</option>
                    <option>Good</option>
                    <option>Excellent</option>
                </select>
            </EditorTemplate>
        </eo:CustomColumn>
    </Columns>
    <ColumnHeaderStyle CssText="background-image:url('00050101');padding-left:8px;padding-top:3px;"></ColumnHeaderStyle>
</eo:Grid>
</asp:Content>


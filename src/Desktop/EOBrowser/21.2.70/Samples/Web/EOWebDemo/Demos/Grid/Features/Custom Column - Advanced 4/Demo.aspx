<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Grid_Features_Custom_Column___Advanced_4_Demo"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        This sample demonstrates how to place two different buttons inside a single cell
        using a <strong>CustomColumn</strong>. The code renders two HTML links inside the
        cell and calls the Grid's client side JavaScript APIs to complete the corresponding
        tasks when the link buttons are clicked.
    </p>

    <script type="text/javascript">
    //By default a custom column supports edit. Since
    //we don't need to edit this column, so we handle
    //ClientSideBeginEdit and always return false to
    //prevent the cell enters edit mode
    function begin_edit()
    {
        return false;
    }
    
    //A custom column allows you to dynamically creates
    //cell text. Here we creates HTML links inside the
    //cell.
    function get_text(column, item, cellValue)
    {
        var html = "";
        
        //Get the grid object
        var grid = eo_GetObject("<%=Grid1.ClientID%>");
        if (grid.getEditItem() != item)
        {
            //Create edit button if the current item
            //is not in edit mode        
            html += "<a href='javascript:edit_row(" + item.getIndex() + ")'>";
            
            //Change "Edit" to an image tag if you wish to
            //use an image button. For example
            //html += "<img src='edit.gif' border='0' />"; 
            html += "Edit";
            
            html += "</a>";
        }
        else
        {
            //Otherwise create update button
            html += "<a href='javascript:edit_row(-1)'>";
            
            //You can use image here. See comment for "Edit" button
            html += "Update";
            
            html += "</a>";
        }
        
        //Create delete button
        html += "&nbsp;<a href='javascript:delete_row(" + item.getIndex() + ")'>";
        //You can use image here. See comment for "Edit" button
        html += "Delete";
        html += "</a>";
        
        return html;
    }
    
    function edit_row(rowIndex)
    {
        //Get the grid object
        var grid = eo_GetObject("<%=Grid1.ClientID%>");
        
        var item = rowIndex >= 0 ? grid.getItem(rowIndex) : grid.getEditItem();
        
        //Place the item in or out the edit mode. If rowIndex
        //is -1, then this function places the current edit
        //item out of edit mode (this is the case for "Update"
        //button), otherwise it places the item into edit mode
        //(this is the case for "Edit" button
        grid.editItem(rowIndex);
        
        //The item mode has changed, refresh the cell
        var cell = item.getCell(0);
        
        //We don't care about the value for this cell because
        //it is only used for command buttons. Call setValue
        //force the cell to update
        cell.setValue(null);
    }
    
    function delete_row(rowIndex)
    {
        //Get the grid object
        var grid = eo_GetObject("<%=Grid1.ClientID%>");
        
        //Put the grid into edit mode
        grid.deleteItem(rowIndex);
    }
    
    function after_edit_item(item)
    {
        setTimeout(function()
        {
            //Get the first cell
            var cell = item.getCell(0);
            
            //Update the cell
            cell.refresh();
        }, 10);
    }
    </script>

    <eo:Grid ID="Grid1" runat="server" Height="180px" Width="500px" AllowColumnReorder="True"
        ColumnHeaderDescImage="00050105" ColumnHeaderAscImage="00050104" FixedColumnCount="0"
        GoToBoxVisible="True" GridLines="Both" BorderColor="#7F9DB9" GridLineColor="220, 223, 228"
        ColumnHeaderDividerImage="00050103" Font-Names="Tahoma" Font-Size="8.75pt" BorderWidth="1px"
        KeyField="TopicID" ClientSideAfterEditItem="after_edit_item">
        <FooterStyle CssText="padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px;">
        </FooterStyle>
        <ItemStyles>
            <eo:GridItemStyleSet>
                <CellStyle CssText="padding-left:8px;padding-top:2px;"></CellStyle>
                <FixedColumnCellStyle CssText="border-right: #d6d2c2 1px solid; padding-right: 10px; border-top: #faf9f4 1px solid; border-left: #faf9f4 1px solid; border-bottom: #d6d2c2 1px solid; background-color: #ebeadb; text-align: right">
                </FixedColumnCellStyle>
            </eo:GridItemStyleSet>
        </ItemStyles>
        <GoToBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; BORDER-TOP: #7f9db9 1px solid; BORDER-LEFT: #7f9db9 1px solid; WIDTH: 40px; BORDER-BOTTOM: #7f9db9 1px solid">
        </GoToBoxStyle>
        <ContentPaneStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;">
        </ContentPaneStyle>
        <ColumnTemplates>
            <eo:TextBoxColumn>
                <TextBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 8.75pt; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; FONT-FAMILY: Tahoma">
                </TextBoxStyle>
            </eo:TextBoxColumn>
            <eo:DateTimeColumn>
                <DatePicker DayHeaderFormat="FirstLetter" DayCellHeight="16" DisabledDates="" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
                    OtherMonthDayVisible="True" DayCellWidth="19" TitleRightArrowImageUrl="DefaultSubMenuIcon"
                    ControlSkinID="None" SelectedDates="">
                    <DayHoverStyle CssText="font-family: tahoma; font-size: 12px; border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid">
                    </DayHoverStyle>
                    <TitleStyle CssText="background-color:#9ebef5;font-family:Tahoma;font-size:12px;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;">
                    </TitleStyle>
                    <DayHeaderStyle CssText="font-family: tahoma; font-size: 12px; border-bottom: #aca899 1px solid">
                    </DayHeaderStyle>
                    <DayStyle CssText="font-family: tahoma; font-size: 12px; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
                    </DayStyle>
                    <SelectedDayStyle CssText="font-family: tahoma; font-size: 12px; background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
                    </SelectedDayStyle>
                    <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
                    <TodayStyle CssText="font-family: tahoma; font-size: 12px; border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid">
                    </TodayStyle>
                    <PickerStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;font-family:Courier New;font-size:8pt;margin-bottom:0px;margin-left:0px;margin-right:0px;margin-top:0px;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;">
                    </PickerStyle>
                    <OtherMonthDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
                    </OtherMonthDayStyle>
                    <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma">
                    </CalendarStyle>
                    <DisabledDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
                    </DisabledDayStyle>
                    <MonthStyle CssText="font-family: tahoma; font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px">
                    </MonthStyle>
                </DatePicker>
            </eo:DateTimeColumn>
        </ColumnTemplates>
        <Columns>
            <eo:CustomColumn Width="100" ClientSideBeginEdit="begin_edit" ClientSideGetText="get_text">
            </eo:CustomColumn>
            <eo:DateTimeColumn HeaderText="Posted At" DataField="PostedAt">
            </eo:DateTimeColumn>
            <eo:TextBoxColumn HeaderText="Posted By" DataField="PostedBy">
            </eo:TextBoxColumn>
            <eo:TextBoxColumn Width="300" HeaderText="Topic" DataField="Topic">
            </eo:TextBoxColumn>
        </Columns>
        <ColumnHeaderStyle CssText="background-image:url('00050101');padding-left:8px;padding-top:3px;">
        </ColumnHeaderStyle>
    </eo:Grid>
</asp:Content>

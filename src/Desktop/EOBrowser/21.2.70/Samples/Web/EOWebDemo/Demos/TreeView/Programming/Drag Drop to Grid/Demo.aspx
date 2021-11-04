<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TreeView_Programming_Drag_Drop_to_Grid_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<style>
.red_cell { PADDING-BOTTOM: 2px; BACKGROUND-COLOR: red; PADDING-LEFT: 10px; PADDING-RIGHT: 2px; PADDING-TOP: 2px }
.blue_cell { PADDING-BOTTOM: 2px; BACKGROUND-COLOR: blue; PADDING-LEFT: 10px; PADDING-RIGHT: 2px; PADDING-TOP: 2px }
.green_cell { PADDING-BOTTOM: 2px; BACKGROUND-COLOR: green; PADDING-LEFT: 10px; PADDING-RIGHT: 2px; PADDING-TOP: 2px }
</style>
<script type="text/javascript">

function resetCellStyle(cell)
{
    var value = cell.getValue();
    if (value)
        cell.overrideStyle(value.toLowerCase() + "_cell");
    else
        cell.overrideStyle(null);
}

function GridDragTarget(grid)
{
    this.m_grid = grid;
}

//This method is being called to determine whether
//this drag target accepts the data being dragged
GridDragTarget.prototype.canDrop = function(mode, type, data)
{
    return (type == "eo_TreeNode") &&    //Must be a tree node
      (data.getLevel() == 1);            //Must be second level tree node
}

//This method is being called to determine the DHTML
//element associated with the drag target. 
GridDragTarget.prototype.get_dropTargetElement = function()
{
    return this.m_grid.getRootElement();
}

//This method is being called when mouse is over
//the drag target
GridDragTarget.prototype.onDragInTarget = function(mode, type, data, x, y)
{
    //Check whether we are dragging a color item
    //over the "Style" column. If so highlight
    //the cell with the color
    
    var curCell = null;
    
    //Only check if we are dragging a color item
    if (data.getParentItem().getText() == "Styles")
    {
        //Find the grid cell below the cursor
        curCell = this.m_grid.findCell(x, y);
    
        if (curCell)
        {
            var itemIndex = curCell.getItemIndex();
            var columnIndex = curCell.getColumn().getIndex();
            
            //Valid item count excludes the last item ("Total" item)
            var itemCount = this.m_grid.getItemCount() - 1;
                        
            if ((columnIndex != 1) ||        //It must be over the "Style" column
                (itemIndex >= itemCount))    //Not on the last item
                curCell = null;
        }
    }
    
    //Check whether the hovering cell has changed
    if (!this.m_grid.compareCells(curCell, this.m_curCell))
    {
        //Clear previously highlighted cell
        if (this.m_curCell)
            resetCellStyle(this.m_curCell);
            
        this.m_curCell = curCell;
        
        //Highlight the new cell. The new CSS
        //class names were stored in each 
        //TreeNode's Value property
        if (curCell)
            curCell.overrideStyle(data.getValue());
    }
}

//This method is being called when mouse leaves
//the drag target
GridDragTarget.prototype.onDragLeaveTarget = function(mode, type, data)
{
    //Clear any highlighted cell
    if (this.m_curCell)
    {
        resetCellStyle(this.m_curCell);
        this.m_curCell = null;
    }
}

//This method is being called when the item is
//being dropped on the target
GridDragTarget.prototype.drop = function(mode, type, data)
{
    if (this.m_curCell)
    {
        this.m_curCell.setValue(data.getText());
        this.m_curCell = null;
    }
    else if (data.getParentItem().getText() == "Items")
    {
        //Add a new item
        var newItem = this.m_grid.addItem();
        
        //Set the item name
        newItem.getCell(0).setValue(data.getText());
        
        //Set the item price. Item price was stored
        //in each TreeNode's Value property
        newItem.getCell(2).setValue(data.getValue());
        
        //Update total
        var total = 0;
        var itemCount = this.m_grid.getItemCount() - 1;
        for (var i = 0; i < itemCount; i++)
        {
            total += parseInt(this.m_grid.getItem(i).getCell(2).getValue());
        }
        this.m_grid.getItem(itemCount).getCell(2).setValue(total);        
    }
}

//The drag target object
var g_GridDragTarget;

//Create the drag target object when the Grid is loaded
function grid_onload(sender)
{
    g_GridDragTarget = new GridDragTarget(sender);
    eo_RegisterDragTarget(g_GridDragTarget);
}

//Remove the drag target object when the Grid is unloaded
function grid_onunload()
{
    eo_UnregisterDragTarget(g_GridDragTarget);
}

</script>
<p>
    This sample demonstrates how to drag drop from a TreeView to other targets. In 
    order to accept drag and drop from the TreeView, you must set the TreeView's <b>DragDropScope</b>
    to <b>Global</b> and also implement a JavaScript drag target object.
</p>
<p>
    This sample implements a drag target object that calls the Grid's client side 
    JavaScript interface to add Grid items and change cell colors. Drag a tree node 
    under "Items" into the Grid to add an item to the Grid. Drag a tree node under 
    "Styles" into the Grid's "Style" column to change the cell color. This sample 
    also set the Grid's <b>FixedBottomItemCount</b> to 1 to keep a fixed "Total" 
    item at the bottom of the Grid.
</p>
<p>
    Please see the demo source code and comment for more details on how to 
    implement a JavaScript drag target object.
</p>
<eo:CallbackPanel runat="server" id="CallbackPanel1" Triggers="{ControlID:btnSubmit;Parameter:}">
    <asp:Panel id="panInput" Runat="server">
        <TABLE>
            <TR>
                <TD vAlign="top">
                    <eo:TreeView id="TreeView1" runat="server" AllowDragDrop="True" DragDropScope="Global" ControlSkinID="None"
                        AutoSelectSource="ItemClick" Width="150px" Height="180px">
                        <LookNodes>
                            <eo:TreeNode DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;color:Gray;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
                                ItemID="_Default" NormalStyle-CssText="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; COLOR: black; BORDER-TOP-STYLE: none; PADDING-TOP: 1px; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none"
                                SelectedStyle-CssText="background-color:#316ac5;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:White;padding-bottom:0px;padding-left:0px;padding-right:0px;padding-top:0px;"></eo:TreeNode>
                        </LookNodes>
                        <TopGroup Style-CssText="border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:black;cursor:hand;font-family:Tahoma;font-size:8pt;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;">
                            <Nodes>
                                <eo:TreeNode Text="Items">
                                    <SubGroup>
                                        <Nodes>
                                            <eo:TreeNode Text="Shirt" Value="10"></eo:TreeNode>
                                            <eo:TreeNode Text="Pants" Value="15"></eo:TreeNode>
                                            <eo:TreeNode Text="Shoes" Value="12"></eo:TreeNode>
                                        </Nodes>
                                    </SubGroup>
                                </eo:TreeNode>
                                <eo:TreeNode Text="Styles">
                                    <SubGroup>
                                        <Nodes>
                                            <eo:TreeNode Text="Red" Value="red_cell"></eo:TreeNode>
                                            <eo:TreeNode Text="Blue" Value="blue_cell"></eo:TreeNode>
                                            <eo:TreeNode Text="Green" Value="green_cell"></eo:TreeNode>
                                        </Nodes>
                                    </SubGroup>
                                </eo:TreeNode>
                            </Nodes>
                        </TopGroup>
                    </eo:TreeView></TD>
                <TD vAlign="top">
                    <eo:Grid id="Grid1" runat="server" Width="340px" Height="184px" ClientSideOnUnload="grid_onunload"
                        ClientSideOnLoad="grid_onload" BorderColor="#999999" GridLineColor="220, 223, 228" GridLines="Both"
                        Font-Names="Tahoma" Font-Size="8.75pt" ColumnHeaderDividerImage="00050103" GoToBoxVisible="True"
                        ColumnHeaderAscImage="00050104" BorderWidth="1px" ColumnHeaderDescImage="00050105" FixedBottomItemCount="1">
                        <ColumnTemplates>
                            <eo:TextBoxColumn>
                                <TextBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 8.75pt; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; FONT-FAMILY: Tahoma"></TextBoxStyle>
                            </eo:TextBoxColumn>
                            <eo:DateTimeColumn>
                                <DatePicker DayCellHeight="16" OtherMonthDayVisible="True" SelectedDates="" TitleRightArrowImageUrl="DefaultSubMenuIcon"
                                    DisabledDates="" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" DayHeaderFormat="FirstLetter"
                                    ControlSkinID="None" DayCellWidth="19">
                                    <SelectedDayStyle CssText="font-family: tahoma; font-size: 12px; background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></SelectedDayStyle>
                                    <DayHoverStyle CssText="font-family: tahoma; font-size: 12px; border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid"></DayHoverStyle>
                                    <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
                                    <PickerStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;font-family:Courier New;font-size:8pt;margin-bottom:0px;margin-left:0px;margin-right:0px;margin-top:0px;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></PickerStyle>
                                    <TodayStyle CssText="font-family: tahoma; font-size: 12px; border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid"></TodayStyle>
                                    <MonthStyle CssText="font-family: tahoma; font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px"></MonthStyle>
                                    <DisabledDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></DisabledDayStyle>
                                    <DayHeaderStyle CssText="font-family: tahoma; font-size: 12px; border-bottom: #aca899 1px solid"></DayHeaderStyle>
                                    <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma"></CalendarStyle>
                                    <OtherMonthDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></OtherMonthDayStyle>
                                    <DayStyle CssText="font-family: tahoma; font-size: 12px; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></DayStyle>
                                    <TitleStyle CssText="background-color:#9ebef5;font-family:Tahoma;font-size:12px;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;"></TitleStyle>
                                </DatePicker>
                            </eo:DateTimeColumn>
                            <eo:MaskedEditColumn>
                                <MaskedEdit TextBoxStyle-CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; font-family:Courier New;font-size:8pt;"
                                    ControlSkinID="None"></MaskedEdit>
                            </eo:MaskedEditColumn>
                        </ColumnTemplates>
                        <Columns>
                            <eo:StaticColumn HeaderText="Item"></eo:StaticColumn>
                            <eo:StaticColumn HeaderText="Style"></eo:StaticColumn>
                            <eo:StaticColumn HeaderText="Price"></eo:StaticColumn>
                        </Columns>
                        <GoToBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; BORDER-TOP: #7f9db9 1px solid; BORDER-LEFT: #7f9db9 1px solid; WIDTH: 40px; BORDER-BOTTOM: #7f9db9 1px solid"></GoToBoxStyle>
                        <ItemStyles>
                            <eo:GridItemStyleSet>
                                <ItemHoverStyle CssText="background-color: whitesmoke"></ItemHoverStyle>
                                <SelectedStyle CssText="background-color: #316ac5; color: white"></SelectedStyle>
                                <CellStyle CssText="padding-left:8px;padding-top:2px;white-space:nowrap;"></CellStyle>
                                <ItemStyle CssText="background-color: white"></ItemStyle>
                                <FixedColumnCellStyle CssText="border-right: #d6d2c2 1px solid; padding-right: 10px; border-top: #faf9f4 1px solid; border-left: #faf9f4 1px solid; border-bottom: #d6d2c2 1px solid; background-color: #ebeadb; text-align: right; color: black;"></FixedColumnCellStyle>
                            </eo:GridItemStyleSet>
                        </ItemStyles>
                        <ColumnHeaderStyle CssText="background-image:url('00050101');padding-left:8px;padding-top:3px;"></ColumnHeaderStyle>
                        <FooterStyle CssText="padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px;"></FooterStyle>
                    </eo:Grid></TD>
            </TR>
        </TABLE>
    </asp:Panel>
    <asp:Panel id="panResult" Runat="server">
        <asp:Label id="lblResult" Runat="server"></asp:Label>
    </asp:Panel>
    <asp:Button id="btnSubmit" Runat="server" Text="Post Back" OnClick="btnSubmit_Click"></asp:Button>
</eo:CallbackPanel>
</asp:Content>


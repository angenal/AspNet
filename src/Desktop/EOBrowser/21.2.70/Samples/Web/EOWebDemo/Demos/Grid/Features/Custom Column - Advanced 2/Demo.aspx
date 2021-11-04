<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Grid_Features_Custom_Column___Advanced_2_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
var g_curItemIndex = -1;

function on_begin_edit(cell)
{
    //Store the current item index so that we can use
    //it later in on_product_change
    g_curItemIndex = cell.getItemIndex();

    //Get the current cell value. Unlike the previous
    //sample, this sample displays "Product_Name", but
    //actually stores "Product_No".
    var v = cell.getValue();
    
    //Set the drop down box's selectedIndex based on the
    //current value. Each drop down item's "value" property
    //contains the "Product_No".
    var dropDownBox = document.getElementById("product_dropdown");
    for (var i = 0; i < dropDownBox.options.length; i++)
    {
        if (dropDownBox.options[i].value == v)
        {
            dropDownBox.selectedIndex = i;
            return;
        }
    }
    
    //No match has been found, display the "Please Select" item
    dropDownBox.selectedIndex = 0;
}

function on_end_edit(cell)
{
    //Get the new value from the drop down box
    var dropDownBox = document.getElementById("product_dropdown");
    var selectedIndex = dropDownBox.selectedIndex;
    if (selectedIndex > 0)
        return dropDownBox.options[selectedIndex].value;
        
    return null;
}

function on_product_change()
{
    if (g_curItemIndex >= 0)
    {
        var grid = eo_GetObject("Grid1");
        
        //Raises the server side ItemCommand event. The second
        //parameter is not used in this sample. If you have
        //multiple columns that call this function, you can use 
        //this second parameter to distinguish the columns. It
        //can also be used to distinguish multiple actions
        //from the same column 
        grid.raiseItemCommandEvent(g_curItemIndex, "SelectProduct");
    }
}

function update_total()
{
    var total = 0;
    var grid = eo_GetObject("Grid1");
    for (var i = 0; i < grid.getItemCount(); i++)
    {
        //Get the Grid item object
        var item = grid.getItem(i);        
        
        //Get the item price. The price is set on the
        //server side as a decimal value, not as a text,
        //so no conversion is needed at here
        var price = item.getCell(2).getValue();
        
        //Get the item quantity. Note the quantity is
        //entered through a textbox, which by default
        //contains text value, so we need to call
        //parseInt to convert it to an integer value
        var quantity = item.getCell(3).getValue();
        quantity = parseInt(quantity);
        
        //Ignore this row if quantity is not a valid number
        if (isNaN(quantity))
            continue;
        
        total += price * quantity;
    }
    
    //Display the total
    var totalText = document.getElementById("total_text");
    if (totalText)
        totalText.innerHTML = total.toString();
}
//<!--JS_SAMPLE_END-->
</script>
<p>
    This sample is an enhanced version of 
    <a href="javascript:GoToDemo('grid_custom_column_adv');">this 
        previous sample</a>. It is recommended that you go over
        that sample first.
</p>
<P>
    This sample simulates a cart/invoice screen where user can enter multiple items 
    as well as the quantity for each item. It demonstrates how to:
</P>
<ul>
    <li>
    Create a drop down list and populate the list from database;
    <li>
    Trigger a server side event when user selects an item from the list;
    <li>
    Update key information about the selected item (in this case, the unit price) 
    in the Grid when the server side event is triggered;
    <li>
        Automatically displays the total when the quantity changes;
    </li>
</ul>
<p>
This sample also uses a CallbackPanel so that the server event does
not cause a full page reload. 
</p>
<P>
    <eo:CallbackPanel runat="server" id="CallbackPanel1" Triggers="{ControlID:Grid1;Parameter:}">
        <eo:Grid id="Grid1" ClientSideOnCellSelected="update_total" AllowNewItem="True" FullRowMode="False"
            ColumnHeaderDividerImage="00050103" Font-Names="Tahoma" Font-Size="8.75pt" GoToBoxVisible="True"
            Height="150px" ColumnHeaderAscImage="00050104" IsCallbackByMe="False" Width="488px" GridLineColor="220, 223, 228"
            ColumnHeaderDescImage="00050105" GridLines="Both" BorderWidth="1px" BorderColor="#7F9DB9"
            runat="server" OnItemCommand="Grid1_ItemCommand">
            <ColumnHeaderStyle CssText="background-image:url('00050101');padding-left:8px;padding-top:3px;"></ColumnHeaderStyle>
            <ColumnTemplates>
                <eo:TextBoxColumn>
                    <TextBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 8.75pt; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; FONT-FAMILY: Tahoma"></TextBoxStyle>
                </eo:TextBoxColumn>
                <eo:DateTimeColumn>
                    <DatePicker DayCellHeight="16" OtherMonthDayVisible="True" SelectedDates="" TitleRightArrowImageUrl="DefaultSubMenuIcon"
                        DisabledDates="" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" DayHeaderFormat="FirstLetter"
                        ControlSkinID="None" DayCellWidth="19">
                        <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma"></CalendarStyle>
                        <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
                        <PickerStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;font-family:Courier New;font-size:8pt;margin-bottom:0px;margin-left:0px;margin-right:0px;margin-top:0px;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></PickerStyle>
                        <SelectedDayStyle CssText="font-family: tahoma; font-size: 12px; background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></SelectedDayStyle>
                        <TodayStyle CssText="font-family: tahoma; font-size: 12px; border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid"></TodayStyle>
                        <MonthStyle CssText="font-family: tahoma; font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px"></MonthStyle>
                        <DayHoverStyle CssText="font-family: tahoma; font-size: 12px; border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid"></DayHoverStyle>
                        <DisabledDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></DisabledDayStyle>
                        <DayHeaderStyle CssText="font-family: tahoma; font-size: 12px; border-bottom: #aca899 1px solid"></DayHeaderStyle>
                        <OtherMonthDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></OtherMonthDayStyle>
                        <DayStyle CssText="font-family: tahoma; font-size: 12px; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></DayStyle>
                        <TitleStyle CssText="background-color:#9ebef5;font-family:Tahoma;font-size:12px;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;"></TitleStyle>
                    </DatePicker>
                </eo:DateTimeColumn>
                <eo:MaskedEditColumn>
                    <MaskedEdit ControlSkinID="None" TextBoxStyle-CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; font-family:Courier New;font-size:8pt;"></MaskedEdit>
                </eo:MaskedEditColumn>
            </ColumnTemplates>
            <FooterStyle CssText="padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px;"></FooterStyle>
            <ContentPaneStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;"></ContentPaneStyle>
            <GoToBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; BORDER-TOP: #7f9db9 1px solid; BORDER-LEFT: #7f9db9 1px solid; WIDTH: 40px; BORDER-BOTTOM: #7f9db9 1px solid"></GoToBoxStyle>
            <ItemStyles>
                <eo:GridItemStyleSet>
                    <ItemHoverStyle CssText="background-color: whitesmoke"></ItemHoverStyle>
                    <CellStyle CssText="padding-left:8px;padding-top:2px;"></CellStyle>
                    <ItemStyle CssText="background-color: white"></ItemStyle>
                    <FixedColumnCellStyle CssText="border-right: #d6d2c2 1px solid; padding-right: 10px; border-top: #faf9f4 1px solid; border-left: #faf9f4 1px solid; border-bottom: #d6d2c2 1px solid; background-color: #ebeadb; text-align: right; color: black;"></FixedColumnCellStyle>
                </eo:GridItemStyleSet>
            </ItemStyles>
            <Columns>
                <eo:RowNumberColumn Width="40"></eo:RowNumberColumn>
                <eo:CustomColumn Width="200" ClientSideEndEdit="on_end_edit" ClientSideBeginEdit="on_begin_edit"
                    HeaderText="Product">
                    <EditorTemplate>
                        <select id="product_dropdown" style="width:200px" onchange="on_product_change()">
                            <option>-Please Select-</option>
                            <asp:Repeater Runat="server" ID="Products">
                                <ItemTemplate>
                                    <option value='<%#DataBinder.Eval(Container.DataItem, "Product_No")%>'>
                                        <%#DataBinder.Eval(Container.DataItem, "Product_Name")%>
                                    </option>
                                </ItemTemplate>
                            </asp:Repeater>
                        </select>
                    </EditorTemplate>
                </eo:CustomColumn>
                <eo:StaticColumn HeaderText="Unit Price"></eo:StaticColumn>
                <eo:TextBoxColumn Width="80" HeaderText="Quantity"></eo:TextBoxColumn>
            </Columns>
        </eo:Grid>
    <script type="text/javascript">
    update_total();
    </script>
    </eo:CallbackPanel>
</P>
<p>
    Total: <span id="total_text"></span>
</p>
</asp:Content>


<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Grid_Features_Custom_Column___Advanced_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
function on_begin_edit(cell)
{
    //Get the current cell value. While the Grid displays
    //the "Product_Name" field, the underlying value stored 
    //by the Grid can be different. However, to simplify 
    //the sample code, this sample also stores the product 
    //name in the Grid. The next sample "Custom Column - 
    //Advanced 2" stores "Product_No" in the Grid, while 
    //displays "Product_Name".
    var v = cell.getValue();
    
    //Set the drop downbox's selectedIndex based on the
    //current value
    var dropDownBox = document.getElementById("product_dropdown");
    for (var i = 0; i < dropDownBox.options.length; i++)
    {
        if (dropDownBox.options[i].text == v)
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
        return dropDownBox.options[selectedIndex].text;
        
    return null;
}
//<!--JS_SAMPLE_END-->
</script>
<p>
    This sample demonstrates how to create a drop down list using a <STRONG>CustomColumn</STRONG>
    and also populate the drop down list from the database. The sample simulates a 
    simplified version of a "cart/invoice" screen that contains a list of product 
    and the respective quantities for each product. Click an empty cell to edit the 
    cell data.
</p>
<P>The drop down is populated in <STRONG>Page_Load</STRONG> through a standard <STRONG>Repeater</STRONG>. 
    Like <a href="javascript: GoToDemo('grid_custom_column');">the basic CustomColumn 
        sample</a>, it also requires two JavaScript functions to correctly set the 
    initial value when the cell enters edit mode and get the changed value when the 
    cell leaves edit mode.
</P>
<P>A more advanced sample that also updates contents of other columns when user 
    select an item from the drop down list is available <a href="javascript: GoToDemo('grid_custom_column_adv2');">here</a>.</P>
<P>
    <eo:Grid runat="server" id="Grid1" BorderColor="#7F9DB9" BorderWidth="1px" GridLines="Both"
        ColumnHeaderDescImage="00050105" GridLineColor="220, 223, 228" Width="376px" IsCallbackByMe="False"
        ColumnHeaderAscImage="00050104" Height="150px" GoToBoxVisible="True" Font-Size="8.75pt"
        Font-Names="Tahoma" ColumnHeaderDividerImage="00050103" FullRowMode="False" AllowNewItem="True">
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
                    <select id="product_dropdown" style="width:200px">
                        <option>-Please Select-</option>
                        <asp:Repeater Runat="server" ID="Products">
                            <ItemTemplate>
                                <option><%#DataBinder.Eval(Container.DataItem, "Product_Name")%></option>
                            </ItemTemplate>
                        </asp:Repeater>
                    </select>
                </EditorTemplate>
            </eo:CustomColumn>
            <eo:TextBoxColumn Width="80" HeaderText="Quantity"></eo:TextBoxColumn>
        </Columns>
    </eo:Grid></P>
<P>
    <asp:Button id="Button1" Width="80px" runat="server" Text="Save" OnClick="Button1_Click"></asp:Button></P>
<P>
    <asp:Label id="Label1" runat="server" Visible="False">This sample does not actually save the data. However sample code skeleton is provided inside Button1_Click event handler, please view the sample source code for details.</asp:Label></P>
</asp:Content>


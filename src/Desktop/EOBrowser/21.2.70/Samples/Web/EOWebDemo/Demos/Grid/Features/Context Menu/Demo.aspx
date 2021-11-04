<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Grid_Features_Context_Menu_Demo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">

    <script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->

var g_itemIndex = -1;
var g_cellIndex = -1;

function ShowContextMenu(e, grid, item, cell)
{
    //Save the target cell index
    g_itemIndex = item.getIndex();
    g_cellIndex = cell.getColIndex();

    //Show the context menu
    var menu = eo_GetObject("<%=Menu1.ClientID%>");
    eo_ShowContextMenu(e, "<%=Menu1.ClientID%>");
    
    //Return true to indicate that we have
    //displayed a context menu
    return true;
}

function OnContextMenuItemClicked(e, eventInfo)
{
    var grid = eo_GetObject("<%=Grid1.ClientID%>");

    var item = eventInfo.getItem();
    switch (item.getText())
    {
        case "Detail":
            //Show the item details
            var gridItem = grid.getItem(g_itemIndex);
            alert(
                "Details about this grid item:\r\n" + 
                "Posted At: " + gridItem.getCell(1).getValue() + "\r\n" +
                "Posted By: " + gridItem.getCell(2).getValue() + "\r\n" +
                "Topic: " + gridItem.getCell(3).getValue());
            break;
            
        case "Delete":
            //Stop editing
            grid.editCell(-1);
        
            //Delete the item
            grid.deleteItem(g_itemIndex);
            break;
            
        case "Add New":
            //This Grid's AllowNewItem is set to true. In this case
            //the Grid displays a temporary new item as the last item
            //The following code does not actually add a new item,
            //but rather put the temporary new item into edit mode
            var itemIndex = grid.getItemCount();
            
            //Put the item into edit mode
            grid.editCell(itemIndex, 1);
            
            //Scroll the item into view
            grid.getItem(itemIndex).ensureVisible();
            break;
            
        case "Save":
            //Save menu item's RaisesServerEvent is set to true,
            //so the event is handled on the server side
    }
}

//<!--JS_SAMPLE_END-->
    </script>

    <p>
        EO.Web Grid provides <b>ClientSideOnContextMenu</b> event handler for you to display
        a context menu.
    </p>
    <eo:CallbackPanel ID="CallbackPanel1" runat="server" Height="230px" Width="480px"
        Triggers="{ControlID:Menu1;Parameter:}" AutoDisableContents="True" SafeGuardUpdate="False">
        <p>
            <eo:Grid ID="Grid1" Width="380px" Height="200px" runat="server" ClientSideOnContextMenu="ShowContextMenu"
                ColumnHeaderHeight="24" ItemHeight="19" ColumnHeaderDescImage="00050205" ColumnHeaderAscImage="00050204"
                FixedColumnCount="1" GridLines="Both" BorderColor="#828790" GridLineColor="240, 240, 240"
                ColumnHeaderDividerImage="00050203" Font-Names="Tahoma" Font-Size="8.75pt" BorderWidth="1px"
                IsCallbackByMe="False" FullRowMode="False" AllowNewItem="True">
                <ColumnTemplates>
                    <eo:TextBoxColumn>
                        <TextBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 8.75pt; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; FONT-FAMILY: Tahoma">
                        </TextBoxStyle>
                    </eo:TextBoxColumn>
                    <eo:DateTimeColumn>
                        <DatePicker DayCellHeight="16" OtherMonthDayVisible="True" SelectedDates="" TitleRightArrowImageUrl="DefaultSubMenuIcon"
                            DisabledDates="" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" DayHeaderFormat="FirstLetter"
                            ControlSkinID="None" DayCellWidth="19">
                            <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma">
                            </CalendarStyle>
                            <PickerStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;font-family:Courier New;font-size:8pt;margin-bottom:0px;margin-left:0px;margin-right:0px;margin-top:0px;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;">
                            </PickerStyle>
                            <SelectedDayStyle CssText="font-family: tahoma; font-size: 12px; background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
                            </SelectedDayStyle>
                            <TodayStyle CssText="font-family: tahoma; font-size: 12px; border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid">
                            </TodayStyle>
                            <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
                            <MonthStyle CssText="font-family: tahoma; font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px">
                            </MonthStyle>
                            <DayHoverStyle CssText="font-family: tahoma; font-size: 12px; border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid">
                            </DayHoverStyle>
                            <DisabledDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
                            </DisabledDayStyle>
                            <DayHeaderStyle CssText="font-family: tahoma; font-size: 12px; border-bottom: #aca899 1px solid">
                            </DayHeaderStyle>
                            <OtherMonthDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
                            </OtherMonthDayStyle>
                            <DayStyle CssText="font-family: tahoma; font-size: 12px; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
                            </DayStyle>
                            <TitleStyle CssText="background-color:#9ebef5;font-family:Tahoma;font-size:12px;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;">
                            </TitleStyle>
                        </DatePicker>
                    </eo:DateTimeColumn>
                    <eo:MaskedEditColumn>
                        <MaskedEdit ControlSkinID="None" TextBoxStyle-CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; font-family:Courier New;font-size:8pt;">
                        </MaskedEdit>
                    </eo:MaskedEditColumn>
                </ColumnTemplates>
                <ItemStyles>
                    <eo:GridItemStyleSet>
                        <ItemHoverStyle CssText="background-image: url(00050206); background-repeat: repeat-x">
                        </ItemHoverStyle>
                        <SelectedStyle CssText="background-image: url(00050207); background-repeat: repeat-x">
                        </SelectedStyle>
                        <CellStyle CssText="padding-left:8px;padding-top:2px;"></CellStyle>
                        <ItemStyle CssText="background-color: white"></ItemStyle>
                    </eo:GridItemStyleSet>
                </ItemStyles>
                <ColumnHeaderHoverStyle CssText="background-image:url('00050202');padding-left:8px;padding-top:4px;">
                </ColumnHeaderHoverStyle>
                <ColumnHeaderStyle CssText="background-image:url('00050201');padding-left:8px;padding-top:4px;">
                </ColumnHeaderStyle>
                <FooterStyle CssText="padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px;">
                </FooterStyle>
                <Columns>
                    <eo:RowNumberColumn Width="40">
                    </eo:RowNumberColumn>
                    <eo:DateTimeColumn HeaderText="Posted At" DataField="PostedAt">
                        <DatePicker DayCellHeight="16" OtherMonthDayVisible="True" SelectedDates="" TitleRightArrowImageUrl="DefaultSubMenuIcon"
                            DisabledDates="" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" DayHeaderFormat="FirstLetter"
                            ControlSkinID="None" DayCellWidth="19">
                            <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma">
                            </CalendarStyle>
                            <PickerStyle CssText="font-family:Courier New; padding-left:5px; padding-right: 5px;">
                            </PickerStyle>
                            <SelectedDayStyle CssText="font-family: tahoma; font-size: 12px; background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
                            </SelectedDayStyle>
                            <TodayStyle CssText="font-family: tahoma; font-size: 12px; border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid">
                            </TodayStyle>
                            <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
                            <MonthStyle CssText="font-family: tahoma; font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px">
                            </MonthStyle>
                            <DayHoverStyle CssText="font-family: tahoma; font-size: 12px; border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid">
                            </DayHoverStyle>
                            <DisabledDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
                            </DisabledDayStyle>
                            <DayHeaderStyle CssText="font-family: tahoma; font-size: 12px; border-bottom: #aca899 1px solid">
                            </DayHeaderStyle>
                            <OtherMonthDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
                            </OtherMonthDayStyle>
                            <DayStyle CssText="font-family: tahoma; font-size: 12px; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
                            </DayStyle>
                            <TitleStyle CssText="background-color:#9ebef5;font-family:Tahoma;font-size:12px;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;">
                            </TitleStyle>
                        </DatePicker>
                    </eo:DateTimeColumn>
                    <eo:TextBoxColumn HeaderText="Posted By" DataField="PostedBy">
                    </eo:TextBoxColumn>
                    <eo:TextBoxColumn Width="300" HeaderText="Topic" DataField="Topic">
                    </eo:TextBoxColumn>
                </Columns>
            </eo:Grid>
        </p>
        <p>
            &nbsp;</p>
    </eo:CallbackPanel>
    <eo:ContextMenu ID="Menu1" Width="144px" runat="server" ControlSkinID="None" ClientSideOnItemClick="OnContextMenuItemClicked"
        OnItemClick="Menu1_ItemClick">
        <TopGroup Style-CssText="cursor:hand;font-family:Verdana;font-size:11px;">
            <Items>
                <eo:MenuItem Text-Html="Detail">
                </eo:MenuItem>
                <eo:MenuItem Text-Html="Delete">
                </eo:MenuItem>
                <eo:MenuItem Text-Html="Add New">
                </eo:MenuItem>
                <eo:MenuItem IsSeparator="True">
                </eo:MenuItem>
                <eo:MenuItem RaisesServerEvent="True" Text-Html="Save">
                </eo:MenuItem>
            </Items>
        </TopGroup>
        <LookItems>
            <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="background-color:#E0E0E0;height:1px;width:1px;">
            </eo:MenuItem>
            <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;"
                ItemID="_Default" NormalStyle-CssText="padding-left:5px;padding-right:5px;">
                <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                    CollapseEffect-Type="GlideTopToBottom" OffsetX="3" ShadowDepth="0" OffsetY="-4"
                    ItemSpacing="5">
                </SubMenu>
            </eo:MenuItem>
        </LookItems>
    </eo:ContextMenu>
</asp:Content>

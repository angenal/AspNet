<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ComboBox_Features_Drop_Down_Template___Advanced_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <script type="text/javascript">
        function select_item(grid)
        {
            var selectedItem = grid.getSelectedItem();
            var title = selectedItem.getCell(0).getValue();
            eo_SetComboBoxValue(grid, title);
        }
    </script>
    <p>
    You can put any control inside the CombBox's <b>DropDownTemplate</b>.
    The following sample uses an EO.Web Grid control inside the DropDownTemplate.    
    </p>
    <eo:ComboBox runat="server" ID="ComboBox1" ControlSkinID="None" 
        DefaultIcon="music.gif" HintText="Select a title" Width="150px">
        <TextStyle CssText="font-family: tahoma; font-size: 11px;" />
        <IconStyle CssText="width:16px;height:16px;" />
        <IconAreaStyle CssText="font-family: tahoma; font-size: 11px; background-image:url(00107007); background-position: left left; background-repeat:no-repeat; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <DropDownTemplate>
            <eo:Grid runat="server" ID="Grid1" BorderColor="#828790" BorderWidth="1px" 
                ColumnHeaderAscImage="00050204" ColumnHeaderDescImage="00050205" 
                ColumnHeaderDividerImage="00050203" ColumnHeaderHeight="24" 
                FixedColumnCount="1" Font-Bold="False" Font-Italic="False" Font-Names="Tahoma" 
                Font-Overline="False" Font-Size="8.75pt" Font-Strikeout="False" 
                Font-Underline="False" GridLineColor="240, 240, 240" GridLines="Both" 
                Height="200px" ItemHeight="19" Width="380px"
                ClientSideOnItemSelected="select_item">
                <FooterStyle CssText="padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px;" />
                <ColumnTemplates>
                    <eo:TextBoxColumn>
                        <TextBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 8.75pt; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; FONT-FAMILY: Tahoma" />
                    </eo:TextBoxColumn>
                    <eo:DateTimeColumn>
                        <DatePicker ControlSkinID="None" DayCellHeight="16" DayCellWidth="19" 
                            DayHeaderFormat="FirstLetter" DisabledDates="" OtherMonthDayVisible="True" 
                            SelectedDates="" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" 
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
                        <MaskedEdit ControlSkinID="None" 
                            TextBoxStyle-CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; font-family:Courier New;font-size:8pt;">
                        </MaskedEdit>
                    </eo:MaskedEditColumn>
                </ColumnTemplates>
                <ColumnHeaderStyle CssText="background-image:url('00050201');padding-left:8px;padding-top:4px;" />
                <ItemStyles>
                    <eo:GridItemStyleSet>
                        <ItemStyle CssText="background-color: white" />
                        <ItemHoverStyle CssText="background-image: url(00050206); background-repeat: repeat-x" />
                        <SelectedStyle CssText="background-image: url(00050207); background-repeat: repeat-x" />
                        <CellStyle CssText="padding-left:8px;padding-top:2px;white-space:nowrap;" />
                    </eo:GridItemStyleSet>
                </ItemStyles>
                <ColumnHeaderHoverStyle CssText="background-image:url('00050202');padding-left:8px;padding-top:4px;" />
                <Columns>
                    <eo:StaticColumn DataField="Title" HeaderText="Title" Width="180">
                    </eo:StaticColumn>
                    <eo:StaticColumn DataField="Artist" HeaderText="Artist" Width="80">
                    </eo:StaticColumn>
                    <eo:StaticColumn DataField="Price" DataFormat="{0:C}" HeaderText="Price" Width="80">
                    </eo:StaticColumn>
                </Columns>
            </eo:Grid>
        </DropDownTemplate>
        <ButtonStyle CssText="width:17px;height:23px;" />
        <ButtonAreaStyle CssText="background-image:url(00107005);" />
        <ButtonAreaHoverStyle CssText="background-image:url(00107006);" />
        <TextAreaStyle CssText="font-family: tahoma; font-size: 11px; border-top: solid 1px #3d7bad; border-bottom: solid 1px #b7d9ed; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <HintTextStyle CssText="font-style:italic;background-color:#c0c0c0;color:white;line-height:16px;" />
    </eo:ComboBox>
</asp:Content>


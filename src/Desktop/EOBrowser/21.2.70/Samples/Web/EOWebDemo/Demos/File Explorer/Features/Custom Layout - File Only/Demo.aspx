<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_File_Explorer_Features_Custom_Layout___File_Only_Demo"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

    <script type="text/javascript">
function upload_begin()
{
    //Display the uploader progress bar and progress text
    document.getElementById("uploader_div").style.display = "block";
}

function upload_done()
{
    //Hide the uploader progress bar and progress text
    document.getElementById("uploader_div").style.display = "none";
}
    </script>

    <p>
        This sample uses <strong>LayoutTemplate</strong> property to customize the UI to
        only include the file panel.
    </p>
    <eo:FileExplorer ID="FileExplorer1" runat="server" RootFolder="~/Demos/File Explorer/Files"
        AllowCreateFolder="True" AllowDeleteFolder="True" AllowRenameFile="True" AllowRenameFolder="True"
        AllowUpload="True" AllowDeleteFile="True" EnableKeyboardNavigation="True" MaxUploadFileSize="10000"
        DemoMode="True">
        <LayoutTemplate>
            <eo:Grid ID="FileGrid" runat="server" BackColor="White" ColumnHeaderDividerImage="00050203"
                ColumnHeaderHeight="24" ColumnHeaderAscImage="00050204" ItemHeight="19" GridLineColor="240, 240, 240"
                ColumnHeaderDescImage="00050205" FixedColumnCount="0" GridLines="None" Font-Names="Tahoma"
                Font-Size="8.75pt" Width="318px" Height="250px" BorderColor="#828790" BorderWidth="1px"
                BorderStyle="Solid">
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
                    <eo:CheckBoxColumn>
                        <CellStyle CssText="padding-left:8px;padding-top:1px;"></CellStyle>
                    </eo:CheckBoxColumn>
                </ColumnTemplates>
                <ItemStyles>
                    <eo:GridItemStyleSet>
                        <ItemHoverStyle CssText="background-image: url(00050206); background-repeat: repeat-x">
                        </ItemHoverStyle>
                        <AlternatingItemStyle CssText="background-color: #f4f4f4"></AlternatingItemStyle>
                        <SelectedStyle CssText="background-image: url(00050207); background-repeat: repeat-x">
                        </SelectedStyle>
                        <CellStyle CssText="padding-left:8px;padding-top:2px;cursor:default;white-space:nowrap;">
                        </CellStyle>
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
                    <eo:CheckBoxColumn Width="30" Name="Delete">
                    </eo:CheckBoxColumn>
                    <eo:StaticColumn Width="24" Name="Icon">
                    </eo:StaticColumn>
                    <eo:TextBoxColumn Width="-1" Name="FileName" HeaderText="File Name" MinWidth="150">
                    </eo:TextBoxColumn>
                    <eo:EditCommandColumn Width="48" Name="Rename">
                    </eo:EditCommandColumn>
                    <eo:StaticColumn Width="80" Name="FileSize" HeaderText="File Size">
                    </eo:StaticColumn>
                </Columns>
            </eo:Grid>
            <eo:ToolBar ID="Toolbar2" runat="server" Width="320px" SeparatorImage="00100104"
                BackgroundImageLeft="00100101" BackgroundImage="00100103" BackgroundImageRight="00100102">
                <DownStyle CssText="border-right: #335ea8 1px solid; padding-right: 2px; border-top: #335ea8 1px solid; padding-left: 4px; padding-bottom: 1px; border-left: #335ea8 1px solid; padding-top: 3px; border-bottom: #335ea8 1px solid; background-color: #99afd4; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;">
                </DownStyle>
                <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 3px; border-top: #335ea8 1px solid; padding-left: 3px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; background-color: #c2cfe5; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;">
                </HoverStyle>
                <NormalStyle CssText="padding-right: 4px; padding-left: 4px; padding-bottom: 3px; border-top-style: none; padding-top: 3px; border-right-style: none; border-left-style: none; border-bottom-style: none; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;">
                </NormalStyle>
                <ItemTemplates>
                    <eo:ToolBarItem Type="Custom">
                        <HoverStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;">
                        </HoverStyle>
                        <DownStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;">
                        </DownStyle>
                        <NormalStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;">
                        </NormalStyle>
                    </eo:ToolBarItem>
                    <eo:ToolBarItem Type="DropDownMenu">
                        <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 3px; border-top: #335ea8 1px solid; padding-left: 3px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; background-color: #c2cfe5; cursor:hand; background-image: url(00100106); background-position-x: right;">
                        </HoverStyle>
                        <DownStyle CssText="border-right: #335ea8 1px solid; padding-right: 2px; border-top: #335ea8 1px solid; padding-left: 4px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 3px; border-bottom: none; background-color:transparent; cursor:hand; background-image: url(00100105); background-position-x: right;">
                        </DownStyle>
                        <NormalStyle CssText="padding-right: 4px; padding-left: 4px; padding-bottom: 3px; border-top-style: none; padding-top: 3px; border-right-style: none; border-left-style: none; border-bottom-style: none; cursor:hand; background-image: url(00100105); background-position-x: right;">
                        </NormalStyle>
                    </eo:ToolBarItem>
                </ItemTemplates>
                <Items>
                    <eo:ToolBarItem ImageUrl="00101057" Text="Thumbnail View" CommandName="ThumbnailView">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem ImageUrl="00101058" Text="Grid View" CommandName="GridView">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem ImageUrl="00101056" Text="Upload File" CommandName="Upload">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem ImageUrl="00101056" Text="Cancel Upload" CommandName="CancelUpload">
                    </eo:ToolBarItem>
                </Items>
            </eo:ToolBar>
            <div id="uploader_div" style="display: none; height: 55px">
                <eo:AJAXUploader ID="FileUploader" runat="server" Width="320px" ClientSideOnCancel="upload_done"
                    ClientSideOnDone="upload_done" ClientSideOnStart="upload_begin" TempFileLocation="~/eo_upload"
                    HideDisabledToolBarButton="True" AutoUpload="True" AllowedExtension=".gif|.bmp|.png|.jpg|.jpeg|.tif">
                    <LayoutTemplate>
                        <table cellspacing="0" cellpadding="2" width="320px" border="0">
                            <tr>
                                <td style="padding-top: 5px">
                                    <eo:ProgressBar ID="ProgressBar" runat="server" ControlSkinID="Windows_XP">
                                    </eo:ProgressBar>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:PlaceHolder ID="ProgressTextPlaceHolder" runat="server">Progress Text Place Holder
                                    </asp:PlaceHolder>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                </eo:AJAXUploader>
            </div>
        </LayoutTemplate>
    </eo:FileExplorer>
</asp:Content>

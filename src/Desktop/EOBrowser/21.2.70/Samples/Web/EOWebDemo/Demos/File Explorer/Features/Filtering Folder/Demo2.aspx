<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Demo2.aspx.cs" Inherits="Demos_File_Explorer_Features_Filtering_Folder_Demo2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
        <link href="../../../../EOWebDemo.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <script type="text/javascript">
        function leftsplitter_resize_handler(splitter)
        {
            var w = splitter.getLeftPane().getWidth();
            var h = splitter.getLeftPane().getHeight();
            
            //Resize the TreeView
            var treeView = eo_GetObject("FolderTree");
            if (treeView)
                treeView.setSize(w - 10, h - 36);
        }

        function rightsplitter_resize_handler(splitter)
        {
            AdjustFilePaneLayout();
            
            var w = splitter.getRightPane().getWidth();
            var h = splitter.getRightPane().getHeight();
            h -= 26;
            
            //Resize the Preview Panel
            if ((w > 0) && (h > 0))
                eo_GetObject("FileExplorer1").setPreviewRegionSize(w, h);
        }

        function AdjustFilePaneLayout()
        {
            var splitter = eo_GetObject("RightSplitter");
            var uploader = eo_GetObject("FileUploader");

            var w = splitter.getLeftPane().getWidth();
            var h = splitter.getLeftPane().getHeight();
            
            h -= 26;
            if (uploader && uploader.isRunning())
                h -= 55;
            
            //Resize the Grid
            var grid = eo_GetObject("FileGrid");
            if (grid)
                grid.setSize(w, h);
            
            //Resize the uploader
            if (uploader)
                uploader.setWidth(w);
        }

        function upload_begin()
        {
            //Display the uploader progress bar and progress text
            document.getElementById("uploader_div").style.display = "block";
            AdjustFilePaneLayout();
        }

        function upload_done()
        {
            //Hide the uploader progress bar and progress text
            document.getElementById("uploader_div").style.display = "none";
            AdjustFilePaneLayout();
        }
            </script>
            <p>
                EO.Web FileExplorer can filter folders using a regular expression. For example, 
                you may wish the FileExplorer to only display folders that matches certain 
                date/time stamp in the folder name. To use this features, set the FileExplorer 
                control's <strong>FolderNameFilter</strong> property to a regular expression.
            </p>
            <p>
                <asp:LinkButton Runat="server" ID="LinkButton1" OnClick="LinkButton1_Click">Set FolderNameFilter to show folders whose name starts with "2008"</asp:LinkButton>. 
                Note the filter is only applied to folders names, not file names.
            </p>
            <p>
                <asp:LinkButton Runat="server" ID="LinkButton2" OnClick="LinkButton2_Click">Clear FolderNameFilter to show all folders</asp:LinkButton>
            </p>
            <eo:FileExplorer id="FileExplorer1" runat="server" RootFolder="~/Demos/File Explorer/Files" AllowCreateFolder="True"
                AllowDeleteFolder="True" AllowRenameFile="True" AllowRenameFolder="True" AllowUpload="True" AllowDeleteFile="True"
                EnableKeyboardNavigation="True" TargetControl="TextBox1" MaxUploadFileSize="10000" DemoMode="True">
                <LayoutTemplate>
                    <eo:splitter id="LeftSplitter" runat="server" Height="320px" Width="700px" ControlSkinID="None"
                        BorderStyle="Solid" BorderWidth="1px" BorderColor="#A0A0A0" DividerImage="00080411" DividerSize="10"
                        DividerCenterImage="00080412" ClientSideOnResized="leftsplitter_resize_handler">
                        <eo:SplitterPane id="SplitterPane1" runat="server" Height="200px" Width="180px" ScrollBars="None">
                            <eo:ToolBar id="Toolbar1" runat="server" Width="100%" BackgroundImageRight="00100102" BackgroundImage="00100103"
                                BackgroundImageLeft="00100101" SeparatorImage="00100104">
                                <DownStyle CssText="border-right: #335ea8 1px solid; padding-right: 2px; border-top: #335ea8 1px solid; padding-left: 4px; padding-bottom: 1px; border-left: #335ea8 1px solid; padding-top: 3px; border-bottom: #335ea8 1px solid; background-color: #99afd4; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></DownStyle>
                                <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 3px; border-top: #335ea8 1px solid; padding-left: 3px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; background-color: #c2cfe5; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></HoverStyle>
                                <NormalStyle CssText="padding-right: 4px; padding-left: 4px; padding-bottom: 3px; border-top-style: none; padding-top: 3px; border-right-style: none; border-left-style: none; border-bottom-style: none; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></NormalStyle>
                                <ItemTemplates>
                                    <eo:ToolBarItem Type="Custom">
                                        <HoverStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></HoverStyle>
                                        <DownStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></DownStyle>
                                        <NormalStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></NormalStyle>
                                    </eo:ToolBarItem>
                                    <eo:ToolBarItem Type="DropDownMenu">
                                        <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 3px; border-top: #335ea8 1px solid; padding-left: 3px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; background-color: #c2cfe5; cursor:hand; background-image: url(00100106); background-position-x: right;"></HoverStyle>
                                        <DownStyle CssText="border-right: #335ea8 1px solid; padding-right: 2px; border-top: #335ea8 1px solid; padding-left: 4px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 3px; border-bottom: none; background-color:transparent; cursor:hand; background-image: url(00100105); background-position-x: right;"></DownStyle>
                                        <NormalStyle CssText="padding-right: 4px; padding-left: 4px; padding-bottom: 3px; border-top-style: none; padding-top: 3px; border-right-style: none; border-left-style: none; border-bottom-style: none; cursor:hand; background-image: url(00100105); background-position-x: right;"></NormalStyle>
                                    </eo:ToolBarItem>
                                </ItemTemplates>
                                <Items>
                                    <eo:ToolBarItem Type="Custom">
                                        <CustomItem>
                                        &nbsp;Folders:&nbsp;&nbsp;
                                    </CustomItem>
                                    </eo:ToolBarItem>
                                    <eo:ToolBarItem ImageUrl="00101055" CommandName="NewFolder" ToolTip="New Folder"></eo:ToolBarItem>
                                    <eo:ToolBarItem ImageUrl="00101054" CommandName="RenameFolder" ToolTip="Rename Folder"></eo:ToolBarItem>
                                    <eo:ToolBarItem ImageUrl="00101061" CommandName="DeleteFolder" ToolTip="Delete Folder"></eo:ToolBarItem>
                                    <eo:ToolBarItem ImageUrl="00101069" CommandName="Refresh" ToolTip="Refresh"></eo:ToolBarItem>
                                </Items>
                            </eo:ToolBar>
                            <eo:TreeView id="FolderTree" style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px"
                                runat="server" Height="100px" Width="100px" ControlSkinID="None">
                                <LookNodes>
                                    <eo:TreeNode ImageUrl="00030301" DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;color:Gray;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
                                        CollapsedImageUrl="00030301" ItemID="_Default" NormalStyle-CssText="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; COLOR: black; BORDER-TOP-STYLE: none; PADDING-TOP: 1px; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none"
                                        ExpandedImageUrl="00030302" SelectedStyle-CssText="background-color:#316ac5;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:White;padding-bottom:0px;padding-left:0px;padding-right:0px;padding-top:0px;"></eo:TreeNode>
                                </LookNodes>
                                <TopGroup Style-CssText="background-color:white;color:black;cursor:hand;font-family:Tahoma;font-size:8pt;">
                                    <Nodes></Nodes>
                                </TopGroup>
                            </eo:TreeView>
                        </eo:SplitterPane>
                        <eo:SplitterPane id="SplitterPane2" runat="server" Width="400px" ScrollBars="None">
                            <eo:Splitter id="RightSplitter" runat="server" Height="100%" Width="100%" ControlSkinID="None"
                                DividerImage="00080411" DividerSize="10" DividerCenterImage="00080412" ClientSideOnResized="rightsplitter_resize_handler">
                                <eo:SplitterPane id="SplitterPane3" runat="server" ScrollBars="None">
                                    <eo:Grid runat="server" id="FileGrid" Height="294px" Width="320px" Font-Size="8.75pt" Font-Names="Tahoma"
                                        GridLines="None" FixedColumnCount="0" ColumnHeaderDescImage="00050205" GridLineColor="240, 240, 240"
                                        ItemHeight="19" ColumnHeaderAscImage="00050204" ColumnHeaderHeight="24" ColumnHeaderDividerImage="00050203"
                                        BackColor="White">
                                        <ColumnTemplates>
                                            <eo:TextBoxColumn>
                                                <TextBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 8.75pt; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; FONT-FAMILY: Tahoma"></TextBoxStyle>
                                            </eo:TextBoxColumn>
                                            <eo:DateTimeColumn>
                                                <DatePicker DayCellHeight="16" OtherMonthDayVisible="True" SelectedDates="" TitleRightArrowImageUrl="DefaultSubMenuIcon"
                                                    DisabledDates="" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" DayHeaderFormat="FirstLetter"
                                                    ControlSkinID="None" DayCellWidth="19">
                                                    <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma"></CalendarStyle>
                                                    <PickerStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;font-family:Courier New;font-size:8pt;margin-bottom:0px;margin-left:0px;margin-right:0px;margin-top:0px;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></PickerStyle>
                                                    <SelectedDayStyle CssText="font-family: tahoma; font-size: 12px; background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></SelectedDayStyle>
                                                    <TodayStyle CssText="font-family: tahoma; font-size: 12px; border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid"></TodayStyle>
                                                    <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
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
                                            <eo:CheckBoxColumn>
                                                <CellStyle CssText="padding-left:8px;padding-top:1px;"></CellStyle>
                                            </eo:CheckBoxColumn>
                                        </ColumnTemplates>
                                        <ItemStyles>
                                            <eo:GridItemStyleSet>
                                                <ItemHoverStyle CssText="background-image: url(00050206); background-repeat: repeat-x"></ItemHoverStyle>
                                                <SelectedStyle CssText="background-image: url(00050207); background-repeat: repeat-x"></SelectedStyle>
                                                <CellStyle CssText="padding-left:8px;padding-top:2px;cursor:default;white-space:nowrap;"></CellStyle>
                                                <ItemStyle CssText="background-color: white"></ItemStyle>
                                                <AlternatingItemStyle CssText="background-color: #f4f4f4"></AlternatingItemStyle>
                                            </eo:GridItemStyleSet>
                                        </ItemStyles>
                                        <ColumnHeaderHoverStyle CssText="background-image:url('00050202');padding-left:8px;padding-top:4px;"></ColumnHeaderHoverStyle>
                                        <ColumnHeaderStyle CssText="background-image:url('00050201');padding-left:8px;padding-top:4px;"></ColumnHeaderStyle>
                                        <FooterStyle CssText="padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px;"></FooterStyle>
                                        <Columns>
                                            <eo:CheckBoxColumn Name="Delete" Width="30"></eo:CheckBoxColumn>
                                            <eo:StaticColumn Name="Icon" Width="24"></eo:StaticColumn>
                                            <eo:TextBoxColumn Name="FileName" HeaderText="File Name" Width="-1" MinWidth="150"></eo:TextBoxColumn>
                                            <eo:EditCommandColumn Name="Rename" Width="48"></eo:EditCommandColumn>
                                            <eo:StaticColumn Name="FileSize" HeaderText="File Size" Width="80"></eo:StaticColumn>
                                        </Columns>
                                    </eo:Grid>
                                    <div id="uploader_div" style="display:none; height:55px">
                                        <eo:AJAXUploader id="FileUploader" Width="250px" runat="server" AutoUpload="True" HideDisabledToolBarButton="True"
                                            TempFileLocation="~/eo_upload" ClientSideOnStart="upload_begin" ClientSideOnDone="upload_done"
                                            ClientSideOnCancel="upload_done" AllowedExtension=".gif|.bmp|.png|.jpg|.jpeg|.tif">
                                            <LayoutTemplate>
                                                <TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
                                                    <TR>
                                                        <TD style="padding-top:5px">
                                                            <eo:ProgressBar id="ProgressBar" runat="server" ControlSkinID="Windows_XP"></eo:ProgressBar></TD>
                                                    </TR>
                                                    <TR>
                                                        <TD>
                                                            <asp:PlaceHolder id="ProgressTextPlaceHolder" runat="server">Progress Text Place Holder </asp:PlaceHolder></TD>
                                                    </TR>
                                                </TABLE>
                                            </LayoutTemplate>
                                        </eo:AJAXUploader>
                                    </div>
                                    <eo:ToolBar id="Toolbar2" runat="server" Width="100%" BackgroundImageRight="00100102" BackgroundImage="00100103"
                                        BackgroundImageLeft="00100101" SeparatorImage="00100104">
                                        <DownStyle CssText="border-right: #335ea8 1px solid; padding-right: 2px; border-top: #335ea8 1px solid; padding-left: 4px; padding-bottom: 1px; border-left: #335ea8 1px solid; padding-top: 3px; border-bottom: #335ea8 1px solid; background-color: #99afd4; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></DownStyle>
                                        <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 3px; border-top: #335ea8 1px solid; padding-left: 3px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; background-color: #c2cfe5; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></HoverStyle>
                                        <NormalStyle CssText="padding-right: 4px; padding-left: 4px; padding-bottom: 3px; border-top-style: none; padding-top: 3px; border-right-style: none; border-left-style: none; border-bottom-style: none; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></NormalStyle>
                                        <ItemTemplates>
                                            <eo:ToolBarItem Type="Custom">
                                                <HoverStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></HoverStyle>
                                                <DownStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></DownStyle>
                                                <NormalStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></NormalStyle>
                                            </eo:ToolBarItem>
                                            <eo:ToolBarItem Type="DropDownMenu">
                                                <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 3px; border-top: #335ea8 1px solid; padding-left: 3px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; background-color: #c2cfe5; cursor:hand; background-image: url(00100106); background-position-x: right;"></HoverStyle>
                                                <DownStyle CssText="border-right: #335ea8 1px solid; padding-right: 2px; border-top: #335ea8 1px solid; padding-left: 4px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 3px; border-bottom: none; background-color:transparent; cursor:hand; background-image: url(00100105); background-position-x: right;"></DownStyle>
                                                <NormalStyle CssText="padding-right: 4px; padding-left: 4px; padding-bottom: 3px; border-top-style: none; padding-top: 3px; border-right-style: none; border-left-style: none; border-bottom-style: none; cursor:hand; background-image: url(00100105); background-position-x: right;"></NormalStyle>
                                            </eo:ToolBarItem>
                                        </ItemTemplates>
                                        <Items>
                                            <eo:ToolBarItem ImageUrl="00101057" Text="Thumbnail View" CommandName="ThumbnailView"></eo:ToolBarItem>
                                            <eo:ToolBarItem ImageUrl="00101058" Text="Grid View" CommandName="GridView"></eo:ToolBarItem>
                                            <eo:ToolBarItem ImageUrl="00101056" Text="Upload File" CommandName="Upload"></eo:ToolBarItem>
                                            <eo:ToolBarItem ImageUrl="00101056" Text="Cancel Upload" CommandName="CancelUpload"></eo:ToolBarItem>
                                        </Items>
                                    </eo:ToolBar>
                                </eo:SplitterPane>
                                <eo:SplitterPane id="SplitterPane4" runat="server" InitialSize="220" ScrollBars="None">
                                    <eo:ToolBar id="Toolbar3" runat="server" Width="100%" BackgroundImageRight="00100102" BackgroundImage="00100103"
                                        BackgroundImageLeft="00100101" SeparatorImage="00100104">
                                        <DownStyle CssText="border-right: #335ea8 1px solid; padding-right: 2px; border-top: #335ea8 1px solid; padding-left: 4px; padding-bottom: 1px; border-left: #335ea8 1px solid; padding-top: 3px; border-bottom: #335ea8 1px solid; background-color: #99afd4; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></DownStyle>
                                        <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 3px; border-top: #335ea8 1px solid; padding-left: 3px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; background-color: #c2cfe5; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></HoverStyle>
                                        <NormalStyle CssText="padding-right: 4px; padding-left: 4px; padding-bottom: 3px; border-top-style: none; padding-top: 3px; border-right-style: none; border-left-style: none; border-bottom-style: none; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></NormalStyle>
                                        <ItemTemplates>
                                            <eo:ToolBarItem Type="Custom">
                                                <HoverStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></HoverStyle>
                                                <DownStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></DownStyle>
                                                <NormalStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></NormalStyle>
                                            </eo:ToolBarItem>
                                            <eo:ToolBarItem Type="DropDownMenu">
                                                <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 3px; border-top: #335ea8 1px solid; padding-left: 3px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; background-color: #c2cfe5; cursor:hand; background-image: url(00100106); background-position-x: right;"></HoverStyle>
                                                <DownStyle CssText="border-right: #335ea8 1px solid; padding-right: 2px; border-top: #335ea8 1px solid; padding-left: 4px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 3px; border-bottom: none; background-color:transparent; cursor:hand; background-image: url(00100105); background-position-x: right;"></DownStyle>
                                                <NormalStyle CssText="padding-right: 4px; padding-left: 4px; padding-bottom: 3px; border-top-style: none; padding-top: 3px; border-right-style: none; border-left-style: none; border-bottom-style: none; cursor:hand; background-image: url(00100105); background-position-x: right;"></NormalStyle>
                                            </eo:ToolBarItem>
                                        </ItemTemplates>
                                        <Items>
                                            <eo:ToolBarItem ImageUrl="00101065" ToolTip="Best Fit" CommandName="BestFit"></eo:ToolBarItem>
                                            <eo:ToolBarItem ImageUrl="00101065" ToolTip="Actual Size" CommandName="ActualSize"></eo:ToolBarItem>
                                            <eo:ToolBarItem ImageUrl="00101067" ToolTip="Zoom In" CommandName="ZoomIn"></eo:ToolBarItem>
                                            <eo:ToolBarItem ImageUrl="00101068" ToolTip="Zoom Out" CommandName="ZoomOut"></eo:ToolBarItem>
                                        </Items>
                                    </eo:ToolBar>
                                    <asp:PlaceHolder Runat="server" ID="PreviewPanel"></asp:PlaceHolder>
                                </eo:SplitterPane>
                            </eo:Splitter>
                        </eo:SplitterPane>
                    </eo:splitter>
                </LayoutTemplate>
            </eo:FileExplorer>
            <p>
                Selected File:
                <asp:TextBox Runat="server" ID="TextBox1" Width="600"></asp:TextBox>
            </p>
    
    </div>
    </form>
</body>
</html>

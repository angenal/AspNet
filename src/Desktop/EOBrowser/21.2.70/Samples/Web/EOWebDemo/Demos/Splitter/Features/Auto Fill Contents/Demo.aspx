<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Splitter_Features_Auto_Fill_Contents_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
function UpdateGrid(e, info)
{
    eo_Callback('<%=CallbackPanel1.ClientID%>', info.getItem().getPath());
}
</script>
<p>
    It is often desired to have the contents of a splitter pane to automatically 
    fill the whole pane. This can usually be achieved by setting the content's 
    Width or Height to "100%". However the same challenge for "100%" that exists to 
    everywhere else applies here too --- That W3C width and height measures the 
    content box, which excludes border and padding. Thus special consideration 
    needs to be taken when applying "100%" to splitter pane content.
</p>
<p>
    Below is a working sample for this scenario. Please see remark section for 
    steps taken by this sample to ensure the contents fill the entire pane.
</p>
<eo:Splitter runat="server" id="Splitter1" Height="240px" Width="512px" BorderStyle="Solid" DividerSize="10"
    BorderWidth="1px" ControlSkinID="None" DividerImage="00080411" BorderColor="#B5B5B5" DividerCenterImage="00080412">
    <eo:SplitterPane id="LeftPane" Width="184px" Height="160px" runat="server" style="padding:2px 2px 2px 2px">
        <eo:TreeView id="TreeView1" ControlSkinID="None" Width="100%" Height="100%" runat="server" ClientSideOnItemClick="UpdateGrid"
            AutoScroll="False">
            <LookNodes>
                <eo:TreeNode ImageUrl="00030301" DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;color:Gray;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
                    CollapsedImageUrl="00030301" ItemID="_Default" NormalStyle-CssText="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; COLOR: black; BORDER-TOP-STYLE: none; PADDING-TOP: 1px; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none"
                    ExpandedImageUrl="00030302" SelectedStyle-CssText="background-color:#316ac5;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:White;padding-bottom:0px;padding-left:0px;padding-right:0px;padding-top:0px;"></eo:TreeNode>
            </LookNodes>
            <TopGroup Style-CssText="color:black;cursor:hand;font-family:Tahoma;font-size:8pt;">
                <Nodes>
                    <eo:TreeNode Text="Documents and Settings">
                        <SubGroup>
                            <Nodes>
                                <eo:TreeNode Text="Administrator">
                                    <SubGroup>
                                        <Nodes>
                                            <eo:TreeNode Text="Desktop"></eo:TreeNode>
                                            <eo:TreeNode Text="Local Settings"></eo:TreeNode>
                                            <eo:TreeNode Text="My Documents"></eo:TreeNode>
                                            <eo:TreeNode Text="SendTo"></eo:TreeNode>
                                            <eo:TreeNode Text="Start Menu"></eo:TreeNode>
                                        </Nodes>
                                    </SubGroup>
                                </eo:TreeNode>
                                <eo:TreeNode Text="All Users">
                                    <SubGroup>
                                        <Nodes>
                                            <eo:TreeNode Text="Desktop"></eo:TreeNode>
                                            <eo:TreeNode Text="Local Settings"></eo:TreeNode>
                                            <eo:TreeNode Text="My Documents"></eo:TreeNode>
                                        </Nodes>
                                    </SubGroup>
                                </eo:TreeNode>
                                <eo:TreeNode Text="Default User">
                                    <SubGroup>
                                        <Nodes>
                                            <eo:TreeNode Text="Desktop"></eo:TreeNode>
                                            <eo:TreeNode Text="Local Settings"></eo:TreeNode>
                                            <eo:TreeNode Text="Start Menu"></eo:TreeNode>
                                        </Nodes>
                                    </SubGroup>
                                </eo:TreeNode>
                            </Nodes>
                        </SubGroup>
                    </eo:TreeNode>
                    <eo:TreeNode Text="Program Files">
                        <SubGroup>
                            <Nodes>
                                <eo:TreeNode Text="Common Files"></eo:TreeNode>
                                <eo:TreeNode Text="ComPlus Applications"></eo:TreeNode>
                                <eo:TreeNode Text="Internet Explorer"></eo:TreeNode>
                                <eo:TreeNode Text="MSDN"></eo:TreeNode>
                            </Nodes>
                        </SubGroup>
                    </eo:TreeNode>
                    <eo:TreeNode Text="Windows">
                        <SubGroup>
                            <Nodes>
                                <eo:TreeNode Text="Fonts"></eo:TreeNode>
                                <eo:TreeNode Text="Help"></eo:TreeNode>
                                <eo:TreeNode Text="System32">
                                    <SubGroup>
                                        <Nodes>
                                            <eo:TreeNode Text="Drivers"></eo:TreeNode>
                                        </Nodes>
                                    </SubGroup>
                                </eo:TreeNode>
                            </Nodes>
                        </SubGroup>
                    </eo:TreeNode>
                </Nodes>
            </TopGroup>
        </eo:TreeView>
    </eo:SplitterPane>
    <eo:SplitterPane id="RightPane" runat="server" ScrollBars="None">
        <eo:CallbackPanel id="CallbackPanel1" Width="100%" Height="240px" runat="server" LoadingHTML="Please wait..." OnExecute="CallbackPanel1_Execute">
            <eo:Grid id="Grid1" Width="100%" Height="240px" runat="server" ColumnHeaderDividerImage="00050203"
                ColumnHeaderHeight="24" ColumnHeaderAscImage="00050204" ItemHeight="19" GridLineColor="240, 240, 240"
                ColumnHeaderDescImage="00050205" FixedColumnCount="1" GridLines="Both" Font-Names="Tahoma"
                Font-Size="8.75pt">
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
                </ColumnTemplates>
                <ItemStyles>
                    <eo:GridItemStyleSet>
                        <ItemHoverStyle CssText="background-image: url(00050206); background-repeat: repeat-x"></ItemHoverStyle>
                        <SelectedStyle CssText="background-image: url(00050207); background-repeat: repeat-x"></SelectedStyle>
                        <CellStyle CssText="padding-left:8px;padding-top:2px;"></CellStyle>
                        <ItemStyle CssText="background-color: white"></ItemStyle>
                    </eo:GridItemStyleSet>
                </ItemStyles>
                <ColumnHeaderHoverStyle CssText="background-image:url('00050202');padding-left:8px;padding-top:4px;"></ColumnHeaderHoverStyle>
                <ColumnHeaderStyle CssText="background-image:url('00050201');padding-left:8px;padding-top:4px;"></ColumnHeaderStyle>
                <FooterStyle CssText="padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px;"></FooterStyle>
                <Columns>
                    <eo:RowNumberColumn Width="50"></eo:RowNumberColumn>
                    <eo:StaticColumn Width="200" Text="" HeaderText="Folder Name"></eo:StaticColumn>
                    <eo:StaticColumn Text="" HeaderText="Child Items"></eo:StaticColumn>
                </Columns>
            </eo:Grid>
        </eo:CallbackPanel>
    </eo:SplitterPane>
</eo:Splitter>
</asp:Content>


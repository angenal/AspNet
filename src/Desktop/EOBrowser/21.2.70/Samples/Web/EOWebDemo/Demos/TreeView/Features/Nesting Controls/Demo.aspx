<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TreeView_Features_Nesting_Controls_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web TreeNode can nest other ASP.NET controls. To nest another ASP.NET 
    control, simply drop a <span class="highlight">CustomItem</span> into the form, 
    place other controls into the CustomItem, then set the TreeNode's CustomItemID 
    to the ID of the CustomItem object.
</p>
<p>
    The following TreeView nests an EO.Web Calendar control.
</p>
<eo:TreeView runat="server" id="TreeView1" AutoSelect="ItemClick" ControlSkinID="None" Width="240px"
    Height="280px">
    <LineImages PlusMinusOnly="True"></LineImages>
    <TopGroup Style-CssText="border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:black;cursor:hand;font-family:Tahoma;font-size:8pt;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;">
        <Nodes>
            <eo:TreeNode ImageUrl="00030303" Text="Desktop">
                <SubGroup>
                    <Nodes>
                        <eo:TreeNode ImageUrl="00030304" Text="My Documents"></eo:TreeNode>
                        <eo:TreeNode Expanded="True" Text="My Calendar">
                            <SubGroup>
                                <Nodes>
                                    <eo:TreeNode LookID="None" LineImageUrl="Blank" Text="calendar_holder" CustomItemID="CustomItem1"></eo:TreeNode>
                                </Nodes>
                            </SubGroup>
                        </eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030305" Text="My Computer">
                            <SubGroup>
                                <Nodes>
                                    <eo:TreeNode ImageUrl="00030308" Text="Local Disk (C:)">
                                        <SubGroup>
                                            <Nodes>
                                                <eo:TreeNode Text="Documents and Settings">
                                                    <SubGroup>
                                                        <Nodes>
                                                            <eo:TreeNode Text="Administrator"></eo:TreeNode>
                                                            <eo:TreeNode Text="All Users"></eo:TreeNode>
                                                            <eo:TreeNode Text="Default User"></eo:TreeNode>
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
                                                            <eo:TreeNode Text="System32"></eo:TreeNode>
                                                        </Nodes>
                                                    </SubGroup>
                                                </eo:TreeNode>
                                            </Nodes>
                                        </SubGroup>
                                    </eo:TreeNode>
                                    <eo:TreeNode ImageUrl="00030309" Text="CD Drive (D:)"></eo:TreeNode>
                                    <eo:TreeNode ImageUrl="00030310" Text="Control Panel"></eo:TreeNode>
                                </Nodes>
                            </SubGroup>
                        </eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030306" Text="My Network Places"></eo:TreeNode>
                        <eo:TreeNode ImageUrl="00030307" Text="Recycle Bin"></eo:TreeNode>
                    </Nodes>
                </SubGroup>
            </eo:TreeNode>
        </Nodes>
    </TopGroup>
    <LookNodes>
        <eo:TreeNode ImageUrl="00030301" DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;color:Gray;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
            CollapsedImageUrl="00030301" Height="17" ItemID="_Default" NormalStyle-CssText="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; COLOR: black; BORDER-TOP-STYLE: none; PADDING-TOP: 1px; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none"
            ExpandedImageUrl="00030302" SelectedStyle-CssText="background-color:#316ac5;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:White;padding-bottom:0px;padding-left:0px;padding-right:0px;padding-top:0px;"></eo:TreeNode>
    </LookNodes>
</eo:TreeView>
<eo:CustomItem runat="server" id="CustomItem1">
    <eo:Calendar id="Calendar1" runat="server" TitleRightArrowHoverImageUrl="00040207" TitleLeftArrowHoverImageUrl="00040205"
        DisableWeekendDays="True" DayCellHeight="16" DayCellWidth="24" TitleLeftArrowImageUrl="00040204"
        TitleRightArrowImageUrl="00040206" VisibleDate="2006-11-01">
        <DayHoverStyle CssText="background-image:url('00040208');"></DayHoverStyle>
        <DisabledDayStyle CssText="color:Gray;"></DisabledDayStyle>
        <DayHeaderStyle CssText="font-weight: bold; font-size: 11px; color: black; border-bottom: black 1px solid; font-family: verdana"></DayHeaderStyle>
        <SelectedDayStyle CssText="background-image: url(00040208)"></SelectedDayStyle>
        <MonthStyle CssText="font-size: 8pt; cursor: hand; font-family: verdana"></MonthStyle>
        <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; font-size: 8pt; padding-bottom: 3px; color: black; padding-top: 3px; font-family: tahoma; background-color: transparent"></TitleStyle>
        <CalendarStyle CssText=""></CalendarStyle>
    </eo:Calendar>
</eo:CustomItem>
</asp:Content>


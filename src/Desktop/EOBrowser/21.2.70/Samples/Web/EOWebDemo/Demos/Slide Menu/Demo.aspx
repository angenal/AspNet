<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Slide_Menu_Demo" Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <table height="360">
        <tr>
            <td valign="top">
                <eo:SlideMenu runat="server" ID="SlideMenu1" SlidePaneHeight="170" ControlSkinID="None"
                    Width="200px">
                    <TopGroup>
                        <Items>
                            <eo:MenuItem LeftIcon-Url="00000506" Text-Html="Mail">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem LeftIcon-Url="00030404" Text-Html="Drafts">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00030408" Text-Html="Inbox">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00030409" Text-Html="Journal">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00030410" Text-Html="Junk E-mail">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00030414" Text-Html="Notes">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00030415" Text-Html="Outbox">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00030416" Text-Html="Sent Items">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00030418" Text-Html="Tasks">
                                        </eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                            <eo:MenuItem LeftIcon-Url="00000503" Text-Html="Calendar">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem LookID="None" Text-Html="calendar_holder" CustomItemID="CalendarItem">
                                        </eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                            <eo:MenuItem LeftIcon-Url="00000504" Text-Html="Contacts">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem LeftIcon-Url="00030402" Text-Html="Address Cards">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00030402" Text-Html="Detailed Address Cards">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00030402" Text-Html="Phone List">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00030402" Text-Html="By Category">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00030402" Text-Html="By Company">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00030402" Text-Html="By Location">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00030402" Text-Html="By Follow-up Flag">
                                        </eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                            <eo:MenuItem LeftIcon-Url="00000508" Text-Html="Tasks">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem LeftIcon-Url="00030418" Text-Html="Simple List">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00030418" Text-Html="Detailed List">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00030418" Text-Html="Active Tasks">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00030418" Text-Html="Next Seven Days">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00030418" Text-Html="Overdue Tasks">
                                        </eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                            <eo:MenuItem LeftIcon-Url="00000505" Text-Html="Folders">
                                <SubMenu Style-CssText="padding-bottom:0px;padding-left:5px;padding-right:0px;padding-top:0px;">
                                    <Items>
                                        <eo:MenuItem LookID="None" Text-Html="treeview_holder" CustomItemID="TreeItem">
                                        </eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                        </Items>
                    </TopGroup>
                    <LookItems>
                        <eo:MenuItem ItemID="_TopGroup">
                            <SubMenu Style-CssText="border-right: #002d96 1px solid; border-top: #002d96 1px solid; font-weight: bold; font-size: 11px; border-left: #002d96 1px solid; cursor: hand; font-family: tahoma">
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem Height="31" HoverStyle-CssText="border-bottom: #002d96 1px solid" ItemID="_TopLevelItem"
                            NormalStyle-CssText="border-bottom: #002d96 1px solid" LeftIcon-Padding-Left="6"
                            Image-Url="00000500" Image-ExpandedUrl="00000502" Image-HoverUrl="00000501" Image-Mode="ItemBackground">
                            <SubMenu Style-CssText="padding-right: 10px; padding-left: 10px; font-size: 11px; padding-bottom: 2px; padding-top: 2px; border-bottom: #002d96 1px solid; font-family: tahoma">
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem Height="20" HoverStyle-CssText="font-weight: normal; text-decoration: underline"
                            ItemID="_Default" NormalStyle-CssText="font-weight: normal; text-decoration: none"
                            LeftIcon-Padding-Right="5">
                        </eo:MenuItem>
                        <eo:MenuItem Height="20" ItemID="plain_text" NormalStyle-CssText="font-weight: normal;"
                            LeftIcon-Padding-Right="5" Text-NoWrap="False">
                        </eo:MenuItem>
                    </LookItems>
                </eo:SlideMenu>
                <eo:CustomItem runat="server" ID="CalendarItem">
                    <div style="padding-left: 5px; line-height: normal">
                        <eo:Calendar ID="Calendar1" runat="server" TitleRightArrowHoverImageUrl="00040207"
                            TitleLeftArrowHoverImageUrl="00040205" DisableWeekendDays="True" DayCellHeight="16"
                            DayCellWidth="24" TitleLeftArrowImageUrl="00040204" TitleRightArrowImageUrl="00040206"
                            VisibleDate="2006-11-01">
                            <DayHoverStyle CssText="background-image:url('00040208');"></DayHoverStyle>
                            <DisabledDayStyle CssText="color:Gray;"></DisabledDayStyle>
                            <DayHeaderStyle CssText="font-weight: bold; font-size: 11px; color: black; border-bottom: black 1px solid; font-family: verdana">
                            </DayHeaderStyle>
                            <SelectedDayStyle CssText="background-image: url(00040208)"></SelectedDayStyle>
                            <MonthStyle CssText="font-size: 8pt; cursor: hand; font-family: verdana"></MonthStyle>
                            <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; font-size: 8pt; padding-bottom: 3px; color: black; padding-top: 3px; font-family: tahoma; background-color: transparent">
                            </TitleStyle>
                            <CalendarStyle CssText=""></CalendarStyle>
                        </eo:Calendar>
                    </div>
                </eo:CustomItem>
                <eo:CustomItem runat="server" ID="TreeItem">
                    <eo:TreeView ID="TreeView1" Width="188px" ControlSkinID="None" runat="server" AutoSelect="ItemClick"
                        Height="170px">
                        <TopGroup Style-CssText="background-repeat:repeat-y;border-bottom-color:#999999;border-bottom-style:none;border-bottom-width:1px;border-left-color:#999999;border-left-style:none;border-left-width:1px;border-right-color:#999999;border-right-style:none;border-right-width:1px;border-top-color:#999999;border-top-style:none;border-top-width:1px;color:black;cursor:hand;font-family:Tahoma;font-size:11px;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;">
                            <Nodes>
                                <eo:TreeNode ImageUrl="00030406" Text="Personal Folders">
                                    <SubGroup>
                                        <Nodes>
                                            <eo:TreeNode ImageUrl="00030401" Text="Calendar">
                                            </eo:TreeNode>
                                            <eo:TreeNode ImageUrl="00030402" Text="Contacts">
                                            </eo:TreeNode>
                                            <eo:TreeNode ImageUrl="00030403" MarginImageUrl="00030411" Text="&lt;b&gt;Deleted Items&lt;/b&gt;&amp;nbsp;&lt;font color=&quot;blue&quot;&gt;(25)&lt;/font&gt;">
                                                <SubGroup>
                                                    <Nodes>
                                                        <eo:TreeNode Text="Today">
                                                        </eo:TreeNode>
                                                        <eo:TreeNode Text="Yesterday">
                                                        </eo:TreeNode>
                                                        <eo:TreeNode Text="Last Week">
                                                        </eo:TreeNode>
                                                    </Nodes>
                                                </SubGroup>
                                            </eo:TreeNode>
                                            <eo:TreeNode ImageUrl="00030404" Text="&lt;b&gt;Drafts&lt;/b&gt;&amp;nbsp;&lt;font color=&quot;green&quot;&gt;(1)&lt;/font&gt;">
                                            </eo:TreeNode>
                                            <eo:TreeNode ImageUrl="00030408" MarginImageUrl="00030412" Text="&lt;b&gt;Inbox&lt;/b&gt;&amp;nbsp;&lt;font color=&quot;blue&quot;&gt;(3)&lt;/font&gt;">
                                                <SubGroup>
                                                    <Nodes>
                                                        <eo:TreeNode Text="Important">
                                                        </eo:TreeNode>
                                                        <eo:TreeNode Text="Personal">
                                                        </eo:TreeNode>
                                                        <eo:TreeNode Text="Support">
                                                        </eo:TreeNode>
                                                    </Nodes>
                                                </SubGroup>
                                            </eo:TreeNode>
                                            <eo:TreeNode ImageUrl="00030409" Text="Journal">
                                            </eo:TreeNode>
                                            <eo:TreeNode ImageUrl="00030410" Text="Junk E-Mail">
                                            </eo:TreeNode>
                                            <eo:TreeNode ImageUrl="00030414" MarginImageUrl="00030413" Text="Notes">
                                            </eo:TreeNode>
                                            <eo:TreeNode ImageUrl="00030415" Text="Outbox">
                                            </eo:TreeNode>
                                            <eo:TreeNode ImageUrl="00030416" Text="Sent Items">
                                            </eo:TreeNode>
                                            <eo:TreeNode ImageUrl="00030418" Text="Tasks">
                                            </eo:TreeNode>
                                        </Nodes>
                                    </SubGroup>
                                </eo:TreeNode>
                                <eo:TreeNode ImageUrl="00030407" Text="Archive Folders">
                                    <SubGroup>
                                        <Nodes>
                                            <eo:TreeNode ImageUrl="00030408" Text="Inbox">
                                            </eo:TreeNode>
                                        </Nodes>
                                    </SubGroup>
                                </eo:TreeNode>
                            </Nodes>
                        </TopGroup>
                        <LookNodes>
                            <eo:TreeNode ImageUrl="00030407" DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;color:Gray;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
                                ItemID="_Default" NormalStyle-CssText="padding-right: 1px; padding-left: 1px; padding-bottom: 1px; color: black; border-top-style: none; padding-top: 1px; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none"
                                SelectedStyle-CssText="background-color:Silver;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:white;padding-bottom:0px;padding-left:0px;padding-right:0px;padding-top:0px;">
                            </eo:TreeNode>
                        </LookNodes>
                        <Margin Width="24"></Margin>
                    </eo:TreeView>
                </eo:CustomItem>
            </td>
            <td width="30">
            </td>
            <td valign="top">
                <p>
                    EO.Web Slide Menu share many features with EO.Web Menu:</p>
                <ul>
                    <li>Cross browser support;</li>
                    <li>Powerful Menu Builder with preview;</li>
                    <li>Support look, skin &amp; theme. Various pre-built design to choose from;</li>
                    <li>Extensive CSS style and image support;</li>
                    <li>Data binding support;</li>
                    <li>Transparent cross frame support;</li>
                    <li>Complete client side JavaScript interface;</li>
                </ul>
                <p>
                    It also offers the following unique features:</p>
                <ul>
                    <li>Nesting other controls in sliding pane;</li>
                    <li>Each pane can expand/collapse independently or exclusively;</li>
                </ul>
            </td>
        </tr>
    </table>
</asp:Content>

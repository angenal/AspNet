<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Slide_Menu_Features_Nesting_Controls_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    Slide Menu can nest other ASP.NET controls. The following example nests a 
    Calendar.
</p>
<eo:SlideMenu runat="server" ID="SlideMenu1" ControlSkinID="None" SlidePaneHeight="180" Width="200px"
    ScrollUpLookID="scroll_up" ScrollDownLookID="scroll_down" ScrollSpeed="3">
    <TopGroup>
        <Items>
            <eo:MenuItem LeftIcon-Url="00000506" Text-Html="Mail">
                <SubMenu>
                    <Items>
                        <eo:MenuItem LeftIcon-Url="00030404" Text-Html="Drafts"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00030408" Text-Html="Inbox"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00030409" Text-Html="Journal"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00030410" Text-Html="Junk E-mail"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00030414" Text-Html="Notes"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00030415" Text-Html="Outbox"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00030416" Text-Html="Sent Items"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00030418" Text-Html="Tasks"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem LeftIcon-Url="00000503" Text-Html="Calendar">
                <SubMenu>
                    <Items>
                        <eo:MenuItem LookID="plain_text" Text-Html="Place an EO.Web Calendar at here. See the full demo at &lt;a href=&quot;http://www.essentialobjects.com/Demo/Home.aspx?id=SlideMenu_Outlook2003&quot; target=&quot;_blank&quot;&gt;here&lt;/a&gt;."
                            CustomItemID="CalendarItem"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem LeftIcon-Url="00000504" Text-Html="Contacts">
                <SubMenu>
                    <Items>
                        <eo:MenuItem LeftIcon-Url="00030402" Text-Html="Address Cards"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00030402" Text-Html="Detailed Address Cards"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00030402" Text-Html="Phone List"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00030402" Text-Html="By Category"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00030402" Text-Html="By Company"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00030402" Text-Html="By Location"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00030402" Text-Html="By Follow-up Flag"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem ItemID="_TopGroup">
            <SubMenu Style-CssText="border-right: #002d96 1px solid; border-top: #002d96 1px solid; font-weight: bold; font-size: 11px; border-left: #002d96 1px solid; cursor: hand; font-family: tahoma"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem Height="31" HoverStyle-CssText="border-bottom: #002d96 1px solid" ItemID="_TopLevelItem"
            NormalStyle-CssText="border-bottom: #002d96 1px solid" LeftIcon-Padding-Left="6" Image-Url="00000500"
            Image-ExpandedUrl="00000502" Image-HoverUrl="00000501" Image-Mode="ItemBackground">
            <SubMenu Style-CssText="padding-right: 10px; padding-left: 10px; font-size: 11px; padding-bottom: 2px; padding-top: 2px; border-bottom: #002d96 1px solid; font-family: tahoma"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem Height="20" HoverStyle-CssText="FONT-WEIGHT: normal; TEXT-DECORATION: underline"
            ItemID="_Default" NormalStyle-CssText="FONT-WEIGHT: normal; TEXT-DECORATION: none" LeftIcon-Padding-Right="5"></eo:MenuItem>
        <eo:MenuItem Height="20" HoverStyle-CssText="FONT-WEIGHT: normal" ItemID="plain_text" NormalStyle-CssText="FONT-WEIGHT: normal"
            LeftIcon-Padding-Right="5" Text-NoWrap="False"></eo:MenuItem>
        <eo:MenuItem Height="20" HoverStyle-CssText="" ItemID="scroll_down" NormalStyle-CssText="" LeftIcon-Url=""
            LeftIcon-Padding-Left="100" LeftIcon-Padding-Right="5" Image-Url="00020001" Image-Padding-Left="130"></eo:MenuItem>
        <eo:MenuItem Height="20" HoverStyle-CssText="" ItemID="scroll_up" NormalStyle-CssText="" LeftIcon-Url=""
            LeftIcon-Padding-Left="100" LeftIcon-Padding-Right="5" Image-Url="00020000" Image-Padding-Left="130"></eo:MenuItem>
    </LookItems>
</eo:SlideMenu>
<eo:CustomItem runat="server" ID="CalendarItem">
    <DIV style="PADDING-LEFT: 5px; LINE-HEIGHT: normal">
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
        </eo:Calendar></DIV>
</eo:CustomItem>
</asp:Content>


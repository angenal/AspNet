<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Features_Nesting_Controls_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
function OnCalendarSelect(e, info)
{
    //Close all popups when a date is selected
    //eo_HideAllPopups();
}
</script>
<p>You can nest other ASP.NET controls inside a menu item. To do so simply drop a <span class="highlight">
        CustomItem</span> into the page, put other controls into the CustomItem, 
    then set the menu item's <span class="highlight">CustomItemID</span> to the ID 
    of the CustomItem control.</p>
<p>
    The following menu nests a Calendar control.
</p>
<eo:Menu id="Menu1" ControlSkinID="None" runat="server" Width="300px">
    <TopGroup Style-CssText="background-image:url(00020005);border-left-color:#e0e0e0;border-left-style:solid;border-left-width:1px;border-right-color:#e0e0e0;border-right-style:solid;border-right-width:1px;border-top-color:#e0e0e0;border-top-style:solid;border-top-width:1px;cursor:hand;font-family:Verdana;font-size:11px;padding-bottom:3px;padding-left:10px;padding-right:10px;padding-top:3px;">
        <Items>
            <eo:MenuItem Text-Html="Calendar">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="New Appointment"></eo:MenuItem>
                        <eo:MenuItem Text-Html="New Task"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Goto Date">
                            <SubMenu>
                                <Items>
                                    <eo:MenuItem LookID="None" Text-Html="calendar_holder" CustomItemID="CustomItem1">
                                        <SubMenu Style-CssText="padding-bottom:0px;padding-left:0px;padding-right:0px;padding-top:0px;"></SubMenu>
                                    </eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem Text-Html="New Meeting"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Properties"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_TopLevelItem"
            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                CollapseEffect-Type="GlideTopToBottom" OffsetX="-3" ShadowDepth="0" OffsetY="3" ItemSpacing="5"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="background-color:#E0E0E0;height:1px;width:1px;"></eo:MenuItem>
        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_Default"
            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                CollapseEffect-Type="GlideTopToBottom" OffsetX="3" ShadowDepth="0" OffsetY="-4" ItemSpacing="5"></SubMenu>
        </eo:MenuItem>
    </LookItems>
</eo:Menu>
<eo:CustomItem runat="server" id="CustomItem1" CancelBubble="False">
    <eo:Calendar id="Calendar1" runat="server" TitleRightArrowHoverImageUrl="00040207" TitleLeftArrowHoverImageUrl="00040205"
        DisableWeekendDays="True" DayCellHeight="16" DayCellWidth="24" VisibleDate="2006-11-01" TitleLeftArrowImageUrl="00040204"
        TitleRightArrowImageUrl="00040206" ClientSideOnSelect="OnCalendarSelect">
        <SelectedDayStyle CssText="background-image: url(00040208)"></SelectedDayStyle>
        <DisabledDayStyle CssText="color:Gray;"></DisabledDayStyle>
        <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; font-size: 8pt; padding-bottom: 3px; color: black; padding-top: 3px; font-family: tahoma; background-color: transparent"></TitleStyle>
        <CalendarStyle CssText=""></CalendarStyle>
        <DayHoverStyle CssText="background-image:url('00040208');"></DayHoverStyle>
        <MonthStyle CssText="font-size: 8pt; cursor: hand; font-family: verdana"></MonthStyle>
        <DayHeaderStyle CssText="font-weight: bold; font-size: 11px; color: black; border-bottom: black 1px solid; font-family: verdana"></DayHeaderStyle>
    </eo:Calendar>
</eo:CustomItem>
</asp:Content>


<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TabStrip_and_MultiPage_Programming_Switch_Page_or_Tab__Client_Side_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
function GoToNextTab()
{
    //Get the TabStrip object
    var tabStrip = eo_GetObject('<%=TabStrip1.ClientID%>');
    
    //Get the selected index
    var selectedIndex = tabStrip.getSelectedIndex();
    
    //Advance the selected index
    var totalTabs = tabStrip.getTopGroup().getItemCount();
    if (++selectedIndex >= totalTabs)
        selectedIndex = 0;
    
    //Set the new selected index
    tabStrip.setSelectedIndex(selectedIndex);
}
//<!--JS_SAMPLE_END-->
</script>
<p>
    EO.Web TabStrip offers complete client side JavaScript interface. The following 
    example uses JavaScript to switch tabs. The associated MultiPage also switches 
    when the TabStrip switches.
</p>
<p>
</p>
<a href="javascript:GoToNextTab()">Next Tab</a>
<p>&nbsp;</p>
<p>
    <eo:tabstrip id="TabStrip1" runat="server" ControlSkinID="None" MultiPageID="MultiPage1" Width="450px">
        <TopGroup>
            <Items>
                <eo:TabItem Text-Html="Tab Item 1"></eo:TabItem>
                <eo:TabItem Text-Html="Tab Item 2"></eo:TabItem>
                <eo:TabItem Text-Html="Tab Item 3"></eo:TabItem>
                <eo:TabItem Text-Html="Tab Item 4"></eo:TabItem>
                <eo:TabItem Text-Html="Tab Item 5"></eo:TabItem>
            </Items>
        </TopGroup>
        <LookItems>
            <eo:TabItem Height="20" ItemID="_Default" RightIcon-Url="" NormalStyle-CssText="background-image:url('00020005');background-repeat:repeat-x;border-bottom-color:#B0B0B0;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#B0B0B0;border-left-style:solid;border-left-width:1px;border-right-color:#B0B0B0;border-right-style:solid;border-right-width:1px;border-top-color:#B0B0B0;border-top-style:solid;border-top-width:1px;color:Gray;font-weight:normal;padding-left:5px;padding-right:5px;"
                SelectedStyle-CssText="background-image:url('00020005');background-repeat:repeat-x;border-bottom-color:#b0b0b0;border-bottom-style:none;border-bottom-width:1px;border-left-color:#b0b0b0;border-left-style:solid;border-left-width:1px;border-right-color:#b0b0b0;border-right-style:solid;border-right-width:1px;border-top-color:#b0b0b0;border-top-style:solid;border-top-width:1px;color:Black;padding-left:5px;padding-right:5px;"
                LeftIcon-Url="" Text-Padding-Top="1" Text-Padding-Bottom="2">
                <SubGroup Style-CssText="background-image:url(00010601);background-position-y:bottom;background-repeat:repeat-x;color:black;cursor:hand;font-family:Verdana;font-size:11px;"
                    ItemSpacing="1"></SubGroup>
            </eo:TabItem>
        </LookItems>
    </eo:tabstrip>
    <div style="BORDER-RIGHT:#b0b0b0 1px solid; BORDER-LEFT:#b0b0b0 1px solid; BORDER-BOTTOM:#b0b0b0 1px solid; padding: 5px 5px 5px 5px; width:438px;">
        <eo:MultiPage runat="server" id="MultiPage1" Width="438" Height="200">
            <eo:PageView id="Pageview1" runat="server">Page 1 </eo:PageView>
            <eo:PageView id="Pageview2" runat="server">Page 2 </eo:PageView>
            <eo:PageView id="Pageview3" runat="server">Page 3 </eo:PageView>
            <eo:PageView id="Pageview4" runat="server">Page 4 </eo:PageView>
            <eo:PageView id="Pageview5" runat="server">Page 5 </eo:PageView>
        </eo:MultiPage>
    </div>
</p>
</asp:Content>


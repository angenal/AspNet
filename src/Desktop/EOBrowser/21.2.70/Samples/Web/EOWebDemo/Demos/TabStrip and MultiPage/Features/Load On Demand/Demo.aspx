<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TabStrip_and_MultiPage_Features_Load_On_Demand_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
function SwitchTab(e, info)
{
    eo_Callback('<%=CallbackPanel1.ClientID%>', info.getItem().getIndex().toString());
}
</script>
<p>
    When there are too many tab pages, it is not pratically to load all pages at 
    once. The following sample demonstrates how to load page on demand using a 
    EO.Web <span class="highlight">CallbackPanel</span> control.
</p>
<eo:TabStrip runat="server" id="TabStrip1" ControlSkinID="None" ClientSideOnItemClick="SwitchTab">
    <DesignOptions BackColor="239, 235, 222"></DesignOptions>
    <TopGroup>
        <Items>
            <eo:TabItem Text-Html="Page 1"></eo:TabItem>
            <eo:TabItem Text-Html="Page 2"></eo:TabItem>
            <eo:TabItem Text-Html="Page 3"></eo:TabItem>
            <eo:TabItem Text-Html="Page 4"></eo:TabItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:TabItem ItemID="_Default" RightIcon-Url="00010203" RightIcon-SelectedUrl="00010206" LeftIcon-Url="00010201"
            LeftIcon-SelectedUrl="00010204" Image-Url="00010202" Image-SelectedUrl="00010205" Image-Mode="TextBackground"
            Image-BackgroundRepeat="RepeatX">
            <SubGroup Style-CssText="font-family: tahoma; font-size: 8pt; background-image: url(00010200); background-repeat: repeat-x; cursor: hand;"
                OverlapDepth="8"></SubGroup>
        </eo:TabItem>
    </LookItems>
</eo:TabStrip>
<div style="padding: 10px 10px 10px 10px">
    <eo:CallbackPanel runat="server" id="CallbackPanel1" Width="100%" 
    Height="200px" LoadingHTML="Loading..." OnExecute="CallbackPanel1_Execute">
    </eo:CallbackPanel>
</div>
</asp:Content>


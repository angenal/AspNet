<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_TabStrip_and_MultiPage_Features_Overlapping_TabStrip_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    Creating overlapping TabStrip with EO.Web can never be easier. Just set the tab 
    group's <span class="highlight">OverlapDepth</span> property. The following 
    sample uses a <span class="highlight">CallbackPanel</span> to dynamically 
    update the overlap depth.
</p>
<P>Enter a new value in the text box below and click Apply, note the amount of 
    overlapping between tab items changes.</P>
<p>&nbsp;</p>
<eo:CallbackPanel runat="server" id="CallbackPanel1" Triggers="{ControlID:btnApply;Parameter:}">
    <eo:TabStrip id="TabStrip1" runat="server" ControlSkinID="None" Width="350px">
        <DesignOptions BackColor="239, 235, 222"></DesignOptions>
        <TopGroup>
            <Items>
                <eo:TabItem Text-Html="Themes"></eo:TabItem>
                <eo:TabItem Text-Html="Desktop"></eo:TabItem>
                <eo:TabItem Text-Html="Screen Saver"></eo:TabItem>
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
    <P>&nbsp;</P>
    <P>Enter a new value (0&nbsp;~ 15):
        <asp:TextBox id="txtNewDepth" Runat="server"></asp:TextBox>&nbsp;
        <asp:Button id="btnApply" Runat="server" Text="Apply" OnClick="btnApply_Click"></asp:Button></P>
    <P>
        <asp:CustomValidator id="CustomValidator1" runat="server" ErrorMessage="Overlap depth must be a number from 0 to 15."></asp:CustomValidator></P>
</eo:CallbackPanel>
</asp:Content>


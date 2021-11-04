<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Features_Accept_and_Cancel_Button_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    Use <b>AcceptButton</b> and <b>CancelButton</b> to specify the ID of the 
    "accept button" and "cancel button". The dialog closes when these buttons are 
    clicked. In this case the button's <b>CommandName</b> value will be used as the 
    dialog's result value.
</p>
<p>
    The following dialog has its <STRONG>AcceptButton</STRONG> set to the ID of the 
    "OK" <STRONG>ImageButton</STRONG>.
</p>
<eo:Dialog runat="server" id="Dialog1" BackColor="#47729F" ControlSkinID="None" Width="168px"
    Height="100px" HeaderHtml="Dialog Header" AcceptButton="ImageButton1" ContentHtml="Dialog content">
    <FooterStyleActive CssText="border-right: #22456a 1px solid; padding-right: 4px; border-top: #7d97b6 1px solid; padding-left: 4px; border-left-width: 1px; font-size: 11px; border-left-color: #728eb8; padding-bottom: 4px; color: white; padding-top: 4px; border-bottom: #22456a 1px solid; font-family: verdana"></FooterStyleActive>
    <ContentStyleActive CssText="border-right: #22456a 1px solid; padding-right: 4px; border-top: #7d97b6 1px solid; padding-left: 4px; border-left-width: 1px; font-size: 11px; border-left-color: #728eb8; padding-bottom: 4px; color: white; padding-top: 4px; border-bottom: #22456a 1px solid; font-family: verdana"></ContentStyleActive>
    <HeaderStyleActive CssText="border-right: #22456a 1px solid; padding-right: 4px; border-top: #ffbf00 3px solid; padding-left: 4px; font-weight: bold; font-size: 11px; padding-bottom: 2px; color: white; padding-top: 2px; border-bottom: #22456a 1px solid; font-family: verdana"></HeaderStyleActive>
    <FooterTemplate>
        <DIV style="TEXT-ALIGN: center">
            <asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/Images/dark_blue_dlg_ok.gif"></asp:ImageButton></DIV>
    </FooterTemplate>
</eo:Dialog>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show(false);">Show Modeless</a>
</p>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show(true);">Show Modal</a>
</p>
</asp:Content>


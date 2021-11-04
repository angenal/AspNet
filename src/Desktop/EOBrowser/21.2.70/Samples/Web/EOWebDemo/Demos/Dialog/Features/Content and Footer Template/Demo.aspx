<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Features_Content_and_Footer_Template_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web Dialog only provides the frame for the dialog; you will need to fill <b>ContentTemplate</b>/<b>FooterTemplate</b>
    property to provide the dialog content.
</p>
<p>
    The following sample houses two standard ASP.NET <STRONG>CheckBox</STRONG>
    controls in its ContentTemplate and one <STRONG>ImageButton</STRONG> control 
    in its FooterTemplate respectively.
</p>
<eo:Dialog runat="server" id="Dialog1" BackColor="#47729F" ControlSkinID="None" Width="168px"
    Height="100px" HeaderHtml="Dialog Header" AcceptButton="ImageButton1">
    <FooterStyleActive CssText="border-right: #22456a 1px solid; padding-right: 4px; border-top: #7d97b6 1px solid; padding-left: 4px; border-left-width: 1px; font-size: 11px; border-left-color: #728eb8; padding-bottom: 4px; color: white; padding-top: 4px; border-bottom: #22456a 1px solid; font-family: verdana"></FooterStyleActive>
    <HeaderStyleActive CssText="border-right: #22456a 1px solid; padding-right: 4px; border-top: #ffbf00 3px solid; padding-left: 4px; font-weight: bold; font-size: 11px; padding-bottom: 2px; color: white; padding-top: 2px; border-bottom: #22456a 1px solid; font-family: verdana"></HeaderStyleActive>
    <FooterTemplate>
        <DIV style="TEXT-ALIGN: center">
            <asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/Images/dark_blue_dlg_ok.gif"></asp:ImageButton></DIV>
    </FooterTemplate>
    <ContentStyleActive CssText="border-right: #22456a 1px solid; padding-right: 4px; border-top: #7d97b6 1px solid; padding-left: 4px; border-left-width: 1px; font-size: 11px; border-left-color: #728eb8; padding-bottom: 4px; color: white; padding-top: 4px; border-bottom: #22456a 1px solid; font-family: verdana"></ContentStyleActive>
    <ContentTemplate>
        <asp:CheckBox id="CheckBox1" runat="server" Text="Option 1"></asp:CheckBox>
        <br />
        <asp:CheckBox id="CheckBox2" runat="server" Text="Option 2"></asp:CheckBox>
    </ContentTemplate>
</eo:Dialog>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show(false);">Show Modeless</a>
</p>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show(true);">Show Modal</a>
</p>
</asp:Content>


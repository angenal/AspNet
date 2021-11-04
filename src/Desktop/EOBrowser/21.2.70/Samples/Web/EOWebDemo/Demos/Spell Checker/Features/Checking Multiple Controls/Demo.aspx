<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Spell_Checker_Features_Checking_Multiple_Controls_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web SpellChecker can check multiple controls in a single run. To use this 
    feature, simply set the SpellChecker's ControlToCheck to a list of IDs 
    separated by ",". For example, "TextBox1,TextBox2".
</p>
<asp:TextBox Runat="server" id="TextBox1" Height="150px" Width="400px" TextMode="MultiLine" title="First TextBox">This sampel uses a dialog to display the spell errors. Please refer to the product documentaton under section &quot;Using Spell Checker Dialog&quot; for more deteils.</asp:TextBox>
<asp:TextBox Runat="server" id="Textbox2" Height="150px" Width="400px" TextMode="MultiLine" title="Second TextBox">This is a second text box that contans some spell errorrs.</asp:TextBox>
<eo:SpellChecker id="SpellChecker1" runat="server" DialogID="SpellCheckerDialog1" ControlToCheck="TextBox1,TextBox2"
    StartButton="Button1"></eo:SpellChecker>
<eo:SpellCheckerDialog id="SpellCheckerDialog1" Width="320px" Height="216px" runat="server" ControlSkinID="None"
    CloseButtonUrl="00070301" BackColor="#ECE9D8" HeaderHtml="Spell Checker">
    <FooterStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 8pt; padding-bottom: 4px; padding-top: 4px; font-family: tahoma"></FooterStyleActive>
    <HeaderStyleActive CssText="padding-right: 3px; padding-left: 8px; font-weight: bold; font-size: 10pt; background-image: url(00020113); padding-bottom: 3px; color: white; padding-top: 0px; font-family: 'trebuchet ms';height:20px;"></HeaderStyleActive>
    <ContentStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 8pt; padding-bottom: 4px; padding-top: 4px; font-family: tahoma"></ContentStyleActive>
    <BorderImages BottomBorder="00020112" RightBorder="00020111" TopRightCornerBottom="00020106" TopLeftCornerRight="00020102"
        TopRightCorner="00020104" LeftBorder="00020110" TopLeftCorner="00020101" BottomRightCorner="00020108"
        TopLeftCornerBottom="00020103" BottomLeftCorner="00020107" TopRightCornerLeft="00020105" TopBorder="00020109"></BorderImages>
</eo:SpellCheckerDialog>
<p>
    <asp:Button Runat="server" id="Button1" Text="Spell Check"></asp:Button>
</p>
</asp:Content>


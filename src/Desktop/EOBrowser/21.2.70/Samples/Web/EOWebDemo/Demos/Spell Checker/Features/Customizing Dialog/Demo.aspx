<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Spell_Checker_Features_Customizing_Dialog_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<asp:textbox id="TextBox1" Runat="server" Height="200px" Width="400px" TextMode="MultiLine">When the spell checker uses a dialog to display the result, both the dialog appaearnce and layout can be customized. This sampel customizes the spell checker dialog appearance by using a different template and different styles for the buttons. </asp:textbox><eo:spellchecker id="SpellChecker1" runat="server" DialogID="SpellCheckerDialog1" ControlToCheck="TextBox1"
    StartButton="Button1"></eo:spellchecker><eo:spellcheckerdialog id="SpellCheckerDialog1" Height="216px" Width="320px" runat="server" ControlSkinID="None"
    CloseButtonUrl="00020312" BackColor="White" HeaderHtml="Dialog Title">
    <ContentTemplate>
        <TABLE cellSpacing="0" cellPadding="3" border="0">
            <TR>
                <TD colSpan="3">Content:
                </TD>
            </TR>
            <TR>
                <TD vAlign="top" width="330" colSpan="2">
                    <asp:Panel id="TextPanel" style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; BORDER-BOTTOM: gray 1px solid"
                        Height="150" Width="330" runat="server"></asp:Panel></TD>
                <TD vAlign="top">
                    <asp:LinkButton id="IgnoreOnceButton" Width="120px" runat="server" Text="Ignore Once" CssClass="spellchecker_button"></asp:LinkButton>
                    <P>
                        <asp:LinkButton id="IgnoreAllButton" Width="120px" runat="server" Text="Ignore All" CssClass="spellchecker_button"></asp:LinkButton></P>
                    <P>
                        <asp:LinkButton id="AddCustomButton" Width="120px" runat="server" Text="Add to Dictionary" CssClass="spellchecker_button"></asp:LinkButton></P>
                </TD>
            </TR>
            <TR>
                <TD colSpan="3">Suggestions:
                </TD>
            </TR>
            <TR>
                <TD vAlign="top" width="330" colSpan="2">
                    <asp:Panel id="SuggestionPanel" style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; BORDER-BOTTOM: gray 1px solid"
                        Height="100" Width="330" runat="server"></asp:Panel></TD>
                <TD vAlign="top">
                    <asp:LinkButton id="ChangeButton" Width="120px" runat="server" Text="Change" CssClass="spellchecker_button"></asp:LinkButton>
                    <P>
                        <asp:LinkButton id="ChangeAllButton" Width="120px" runat="server" Text="Change All" CssClass="spellchecker_button"></asp:LinkButton></P>
                </TD>
            </TR>
            <TR>
                <TD noWrap>Change to:
                </TD>
                <TD align="right">
                    <asp:TextBox id="ChangeToText" Width="220" runat="server"></asp:TextBox></TD>
                <TD></TD>
            </TR>
            <TR>
                <TD align="right" colSpan="3">
                    <asp:LinkButton id="CloseButton" Width="120px" runat="server" Text="Close" CssClass="spellchecker_button"></asp:LinkButton></TD>
            </TR>
        </TABLE>
    </ContentTemplate>
    <FooterStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 8pt; padding-bottom: 4px; padding-top: 4px; font-family: tahoma"></FooterStyleActive>
    <HeaderStyleActive CssText="background-image:url('00020311');color:black;font-family:'trebuchet ms';font-size:10pt;font-weight:bold;padding-bottom:5px;padding-left:8px;padding-right:3px;padding-top:0px;"></HeaderStyleActive>
    <ContentStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 8pt; padding-bottom: 4px; padding-top: 4px; font-family: tahoma"></ContentStyleActive>
    <BorderImages BottomBorder="00020305" RightBorder="00020307" TopRightCornerBottom="00020308" TopRightCorner="00020309"
        LeftBorder="00020303" TopLeftCorner="00020301" BottomRightCorner="00020306" TopLeftCornerBottom="00020302"
        BottomLeftCorner="00020304" TopBorder="00020310"></BorderImages>
</eo:spellcheckerdialog>
<p><asp:button id="Button1" Runat="server" Text="Spell Check"></asp:button></p>
</asp:Content>


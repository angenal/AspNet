<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Floater_Features_Anchors_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    In order to use EO.Web Floater, it must be "anchored" to one or more element. 
    The initial position of the anchor element determines the fixed Floater 
    position.
</p>
<p>
    <b>LeftAnchorID</b> and <b>TopAnchorID</b> are usually used to anchor the 
    Floater to the left and top edge of a given element. However <b>RightAnchorID</b>
    and <b>BottomAnchorID</b> can be used to anchor the Floater's right/bottom edge 
    to the right/bottom edge of an element.
</p>
<p>
    Special value <b>&lt;center&gt;</b> can also be used with any of the anchor 
    element to center the element horizontally or vertically.
</p>
<p>
    Try to select any option below and scroll browser window
    to see it in action. 
</p>
<p>
<b>Note</b>: You may need to reduce the size of your browser window in order to
test scrolling.
</p>
<asp:RadioButtonList Runat="server" ID="rbAnchor" RepeatDirection="Horizontal" Width="500px" AutoPostBack="True"
     OnSelectedIndexChanged="rbAnchor_SelectedIndexChanged">
    <asp:ListItem Value="Use LeftAnchorID" Selected="True">Use LeftAnchorID</asp:ListItem>
    <asp:ListItem Value="Use RightAnchorID">Use RightAnchorID</asp:ListItem>
    <asp:ListItem Value="Anchor to Center">Anchor to Center</asp:ListItem>
</asp:RadioButtonList>
<eo:CallbackPanel runat="server" id="CallbackPanel1" Triggers="{ControlID:rbAnchor;Parameter:}">
    <div id="anchor" style="WIDTH:400px;PADDING-TOP:80px;HEIGHT:100px;BACKGROUND-COLOR:#f0f0f0;TEXT-ALIGN:center">Anchor 
        Element</div>
    <eo:Floater id="Floater1" TopAnchorID="anchor" LeftAnchorID="anchor" runat="server">
        <DIV style="BORDER-RIGHT: black 1px solid; PADDING-RIGHT: 20px; BORDER-TOP: black 1px solid; PADDING-LEFT: 20px; PADDING-BOTTOM: 20px; BORDER-LEFT: black 1px solid; PADDING-TOP: 20px; BORDER-BOTTOM: black 1px solid; BACKGROUND-COLOR: white">Floating 
            contents
        </DIV>
    </eo:Floater>
</eo:CallbackPanel>
</asp:Content>


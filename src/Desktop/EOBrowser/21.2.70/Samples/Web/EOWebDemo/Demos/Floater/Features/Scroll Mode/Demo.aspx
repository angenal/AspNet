<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Floater_Features_Scroll_Mode_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    By default, EO.Web Floater fixes position both horizontally and vertically. You 
    can set the Floater's <b>ScrollMode</b> to instruct the floater to only 
    fix&nbsp;position horizontally or vertically. The following sample has 
    ScrollMode set to <b>Y</b>, which means the Floater will scroll along with the 
    page vertically, but not horizontally.
</p>
<p>
    <b>Note</b>: You may need to reduce the size of your browser window in order to 
    test scrolling.
</p>
<div id="anchor" style="WIDTH:400px;PADDING-TOP:80px;HEIGHT:100px;BACKGROUND-COLOR:#f0f0f0;TEXT-ALIGN:center">Anchor 
    Element</div>
<eo:Floater id="Floater1" TopAnchorID="anchor" LeftAnchorID="anchor" runat="server" ScrollMode="Y">
    <DIV style="BORDER-RIGHT: black 1px solid; PADDING-RIGHT: 20px; BORDER-TOP: black 1px solid; PADDING-LEFT: 20px; PADDING-BOTTOM: 20px; BORDER-LEFT: black 1px solid; PADDING-TOP: 20px; BORDER-BOTTOM: black 1px solid; BACKGROUND-COLOR: white">Floating 
        contents
    </DIV>
</eo:Floater>
</asp:Content>


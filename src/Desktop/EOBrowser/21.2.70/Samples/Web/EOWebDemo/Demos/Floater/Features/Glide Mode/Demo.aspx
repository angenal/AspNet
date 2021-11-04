<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Floater_Features_Glide_Mode_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web Floater can play glide effect when it moves. By default the floater 
    automatically decide whether it's better to play glide effect. This behavior 
    can be overriden through <b>GlideMode</b> property. The following sample has <b>GlideMode</b>
    set to <b>AlwaysOn</b>.
</p>
<div id="anchor">
</div>
<eo:Floater runat="server" id="Floater1" LeftAnchorID="anchor" TopAnchorID="anchor" GlideMode="AlwaysOn">
    <DIV style="BORDER-RIGHT: black 1px solid; PADDING-RIGHT: 20px; BORDER-TOP: black 1px solid; PADDING-LEFT: 20px; PADDING-BOTTOM: 20px; BORDER-LEFT: black 1px solid; PADDING-TOP: 20px; BORDER-BOTTOM: black 1px solid; BACKGROUND-COLOR: white">Floating 
        contents
    </DIV>
</eo:Floater>
</asp:Content>


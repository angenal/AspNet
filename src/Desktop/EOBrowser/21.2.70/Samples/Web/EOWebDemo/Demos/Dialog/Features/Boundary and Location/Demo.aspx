<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Features_Boundary_and_Location_Demo" Title="Untitled Page" %>
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>Use <b>AnchorElementID</b>, <b>ShowDirection</b> to specify the reference point 
    and the direction that the dialog expands. Use <b>OffsetX</b> and <b>OffsetY</b>
    to specify the offset against the reference point.
</p>
<p>Use <b>ConfineElementID</b> to specify the ID of the "confining element". The 
    "confine element", if set, defines the boundary in which the dialog can be 
    displayed, that is, a dialog can not be moved outside of its "confine element".
</p>
<eo:dialog id="Dialog1" runat="server" ConfineElementID="demo_confine" AnchorElementID="demo_link"
    FooterHtml="Dialog Footer" BackColor="#47729F" ControlSkinID="None" Width="168px" ContentHtml="Dialog Content"
    Height="100px" HeaderHtml="Dialog Header">
    <FooterStyleActive CssText="border-right: #22456a 1px solid; padding-right: 4px; border-top: #7d97b6 1px solid; padding-left: 4px; border-left-width: 1px; font-size: 11px; border-left-color: #728eb8; padding-bottom: 4px; color: white; padding-top: 4px; border-bottom: #22456a 1px solid; font-family: verdana"></FooterStyleActive>
    <HeaderStyleActive CssText="border-right: #22456a 1px solid; padding-right: 4px; border-top: #ffbf00 3px solid; padding-left: 4px; font-weight: bold; font-size: 11px; padding-bottom: 2px; color: white; padding-top: 2px; border-bottom: #22456a 1px solid; font-family: verdana"></HeaderStyleActive>
    <ContentStyleActive CssText="border-right: #22456a 1px solid; padding-right: 4px; border-top: #7d97b6 1px solid; padding-left: 4px; border-left-width: 1px; font-size: 11px; border-left-color: #728eb8; padding-bottom: 4px; color: white; padding-top: 4px; border-bottom: #22456a 1px solid; font-family: verdana"></ContentStyleActive>
</eo:dialog>
<p>
    <a id="demo_link" href="javascript:eo_GetObject('Dialog1').show(false);">Show Dialog</a>
</p>
<div id="demo_confine" style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; WIDTH: 400px; BORDER-BOTTOM: gray 1px solid; HEIGHT: 250px">
</div>
</asp:Content>


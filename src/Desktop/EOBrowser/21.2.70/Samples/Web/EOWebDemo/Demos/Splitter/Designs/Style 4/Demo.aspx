<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Splitter_Designs_Style_4_Demo" Title="Untitled Page" %>
<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:Splitter runat="server" Width="300px" Height="200px" id="Splitter1" BorderStyle="Solid" DividerSize="11"
    BorderWidth="1px" BorderColor="#BED6E0" ControlSkinID="None" DividerImage="00080421" Orientation="Horizontal"
    DividerCenterImage="00080422">
    <eo:SplitterPane id="SplitterPane1" Width="100px" runat="server">
        <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">Top 
            Pane Contents</DIV>
    </eo:SplitterPane>
    <eo:SplitterPane id="SplitterPane2" runat="server">
        <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">Bottom 
            Pane Contents</DIV>
    </eo:SplitterPane>
</eo:Splitter>
</asp:Content>


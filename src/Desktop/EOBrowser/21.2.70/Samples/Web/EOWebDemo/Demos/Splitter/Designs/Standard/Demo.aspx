<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Splitter_Designs_Standard_Demo" Title="Untitled Page" %>
<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:Splitter runat="server" Width="300px" Height="200px" id="Splitter1" BorderStyle="Solid" DividerSize="7"
    BorderWidth="1px" BorderColor="#A7A6AA" ControlSkinID="None" DividerImage="00080301">
    <eo:SplitterPane id="SplitterPane1" Width="100px" runat="server">
        <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">Left 
            Pane Contents</DIV>
    </eo:SplitterPane>
    <eo:SplitterPane id="SplitterPane2" runat="server">
        <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">Right 
            Pane Contents</DIV>
    </eo:SplitterPane>
</eo:Splitter>
</asp:Content>


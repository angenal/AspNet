<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Splitter_Features_Min_and_Max_Size_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    You can optionally set a minimum and maximum size for a <b>SplitterPane</b> by 
    setting its <b>MinWidth</b>, <b>MinHeight</b>, <b>MaxWidth</b> and <b>MaxHeight</b>
    property. <b>MinWidth</b> and <b>MaxWidth</b> apply to vertical splitters, <b>MinHeight</b>
    and <b>MaxHeight</b> apply to horizontal splitters.
</p>
<p>
    The left pane of the following splitter has MinWidth set to 50 and MaxWidth set 
    to 200.
</p>
<eo:Splitter runat="server" Width="300px" Height="200px" id="Splitter1" BorderStyle="Solid" DividerSize="10"
    BorderWidth="1px" BorderColor="#B5B5B5" ControlSkinID="None" DividerImage="00080411" DividerCenterImage="00080412">
    <eo:SplitterPane id="SplitterPane1" Width="100px" runat="server" MaxWidth="200" MinWidth="50">
        <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">Left 
            Pane Contents</DIV>
    </eo:SplitterPane>
    <eo:SplitterPane id="SplitterPane2" runat="server">
        <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">Right 
            Pane Contents</DIV>
    </eo:SplitterPane>
</eo:Splitter>
</asp:Content>


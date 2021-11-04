<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Splitter_Features_Nesting_Splitters_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
function OnSplitterResized(splitter)
{
    //Get the left pane's client size
    var w = splitter.getRightPane().getWidth();
    var h = splitter.getRightPane().getHeight();
    
    var splitter2 = eo_GetObject("Splitter2");
    splitter2.setSize(w, h);
}
</script>
<p>
    Multiple EO.Web Splitters can be nested together. When using EO.Web Splitters 
    this way, you should handle the outer splitter's <b>ClientSideOnResized</b> event 
    to resize the inner splitter.
</p>
<eo:Splitter runat="server" Width="400px" Height="200px" id="Splitter1" BorderStyle="Solid" DividerSize="10"
    BorderWidth="1px" BorderColor="#B5B5B5" ControlSkinID="None" DividerImage="00080411" DividerCenterImage="00080412"
    ClientSideOnResized="OnSplitterResized">
    <eo:SplitterPane id="SplitterPane1" Width="100px" runat="server">
        <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">Left 
            Pane Contents
        </DIV>
    </eo:SplitterPane>
    <eo:SplitterPane id="SplitterPane2" runat="server" ScrollBars="None">
        <eo:Splitter runat="server" Width="300px" Height="200px" id="Splitter2" BorderStyle="Solid" DividerSize="10"
            BorderWidth="0px" ControlSkinID="None" DividerImage="00080431" Orientation="Horizontal"
            DividerCenterImage="00080432">
            <eo:SplitterPane id="Splitterpane3" Width="100px" runat="server">
                <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">
                    Top Pane Contents
                </DIV>
            </eo:SplitterPane>
            <eo:SplitterPane id="Splitterpane4" runat="server">
                <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">
                    Bottom Pane Contents
                </DIV>
            </eo:SplitterPane>
        </eo:Splitter>
    </eo:SplitterPane>
</eo:Splitter>
</asp:Content>


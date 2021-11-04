<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Splitter_Features_Auto_Resize_Splitter_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web Splitter can automatically adjust height when the height of the content 
    changes -- usually due to splitter pane being resized. To use this feature,
    simply leave the Splitter's Height as empty. The following sample demonstrates 
    this feature.
</p>
<p>
    <eo:Splitter runat="server" ID="Splitter1" Width="500px" BorderStyle="Solid" DividerSize="6"
        BorderWidth="1px" ControlSkinID="None" DividerImage="00080201" BorderColor="#3B619C">
        <eo:SplitterPane id="SplitterPane1" Width="100px" runat="server">
            <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">Drag 
                the splitter bar to resize the splitter pane. When the pane is resized, the 
                height of this text block changes. Notice the splitter height changes accordingly.
            </DIV>
        </eo:SplitterPane>
        <eo:SplitterPane id="Splitterpane2" runat="server">
            <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">Drag 
                the splitter bar to resize the splitter pane. When the pane is resized, the 
                height of this text block changes. Notice the splitter height changes accordingly.
            </DIV>
        </eo:SplitterPane>
    </eo:Splitter>
<P></P>
</asp:Content>


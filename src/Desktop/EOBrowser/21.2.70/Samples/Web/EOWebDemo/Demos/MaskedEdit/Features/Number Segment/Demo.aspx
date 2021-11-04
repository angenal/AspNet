<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_MaskedEdit_Features_Number_Segment_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    This demo demonstrates a single <b>Number</b> segment. For a demo using a 
    single <b>Mask</b> segment, click <a href="javascript:GoToDemo('maskededit_mask');">
        here</a>. For a demo using multiple segments, click <a href="javascript:GoToDemo('maskededit_multiple');">
        here</a>.
</p>
<p>
    You can use <b>Number</b> segment to enter numeric value with optional decimal 
    digits. To enable decimal digits, set <b>Decimals</b> to a number rather than 
    0.
</p>
<p>
    For touch device (such as iPad) user: Use "D" key to clear the segment.
</p>
<p>
    Without decimal digits:
    <eo:MaskedEdit runat="server" id="MaskedEdit1" Width="120px">
        <eo:MaskedEditSegment SegmentType="Number"></eo:MaskedEditSegment>
    </eo:MaskedEdit>
</p>
<p>
    With 2 decimal digits:
    <eo:MaskedEdit runat="server" id="Maskededit2" Width="120px">
        <eo:MaskedEditSegment Decimals="2" SegmentType="Number"></eo:MaskedEditSegment>
    </eo:MaskedEdit>
</p>
</asp:Content>


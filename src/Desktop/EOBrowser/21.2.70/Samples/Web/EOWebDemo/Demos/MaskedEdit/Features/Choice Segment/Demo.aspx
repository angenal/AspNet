<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_MaskedEdit_Features_Choice_Segment_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    This demo demonstrates a single <b>Choice</b> segment. For a demo using a 
    single <b>Mask</b> segment, click <a href="javascript:GoToDemo('maskededit_mask');">
        here</a>. For a demo using multiple segments, click <a href="javascript:GoToDemo('maskededit_multiple');">
        here</a>.
</p>
<p>
    The following MaskedEdit control contains a single choice segment with three 
    choices: Apple, Orange and Banana. Choice segment alone is rarely useful, 
    but they are very useful when used together with other type of segments. To 
    select a choice, simply type the first letter of the choice or press up or down 
    arrow keys to change the current value.
</p>
<p>
    For touch device (such as iPad) user: Use "P" key to move to the previous choice and "N" key to move to the next choice. Use "D" key to clear the segment.
</p>
<p>
    <eo:MaskedEdit runat="server" id="MaskedEdit1" style="width:120px">
        <eo:MaskedEditSegment Choices="Apple|Orange|Banana" SegmentType="Choice"></eo:MaskedEditSegment>
    </eo:MaskedEdit>
</p>
</asp:Content>


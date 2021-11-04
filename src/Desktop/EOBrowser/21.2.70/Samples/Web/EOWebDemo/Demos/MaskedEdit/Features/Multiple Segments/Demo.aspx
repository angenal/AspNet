<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_MaskedEdit_Features_Multiple_Segments_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    The following sample demonstrates using multiple segments together to enter a 
    time value. It uses two <b>Number</b> segments,&nbsp;two <b>Literal</b> segment 
    and one <b>Choices</b> segment.
</p>
<p>
    <eo:MaskedEdit runat="server" id="MaskedEdit1" IsValid="True" style="width:100px">
        <eo:MaskedEditSegment IsRequired="True" MaxValue="23" SegmentType="Number"></eo:MaskedEditSegment>
        <eo:MaskedEditSegment Text=":" IsRequired="True"></eo:MaskedEditSegment>
        <eo:MaskedEditSegment IsRequired="True" MaxValue="59" SegmentType="Number"></eo:MaskedEditSegment>
        <eo:MaskedEditSegment Text=" " IsRequired="True"></eo:MaskedEditSegment>
        <eo:MaskedEditSegment IsRequired="True" Choices="AM|PM" SegmentType="Choice"></eo:MaskedEditSegment>
    </eo:MaskedEdit>
</p>
</asp:Content>


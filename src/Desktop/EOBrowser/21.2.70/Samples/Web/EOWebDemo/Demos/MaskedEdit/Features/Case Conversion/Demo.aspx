<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_MaskedEdit_Features_Case_Conversion_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web MaskedEdit can automatically convert user input to upper/lower case. The 
    following example takes 9 alphanumeric characters and:
    <ul>
        <li>automatically convert the first three characters to upper case;</li>
        <li>automatically convert the last three characters to lower case;</li>
        <li>do not perform any conversion for the three characters in the middle;</li>
    </ul>
      
</p>
<p>
    <eo:MaskedEdit runat="server" id="MaskedEdit1" IsValid="True" style="width:120px">
        <eo:MaskedEditSegment Mask="&gt;AAA|AAA&lt;AAA" SegmentType="Mask"></eo:MaskedEditSegment>
    </eo:MaskedEdit>
</p>
</asp:Content>


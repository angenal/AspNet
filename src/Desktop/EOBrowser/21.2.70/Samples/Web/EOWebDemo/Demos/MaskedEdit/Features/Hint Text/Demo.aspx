<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_MaskedEdit_Features_Hint_Text_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web MaskedEdit can display a "hint text" to indicate user what to enter. The 
    following sample demonstrates a masked edit control with a hint text set to 
    "Enter a number":
</p>
<p>
    <eo:MaskedEdit runat="server" id="MaskedEdit1" IsValid="True" Hint="Enter a number">
        <eo:MaskedEditSegment SegmentType="Number"></eo:MaskedEditSegment>
    </eo:MaskedEdit>
</p>
</asp:Content>


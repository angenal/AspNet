<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_MaskedEdit_Features_Validation_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web MaskedEdit control automatically validates its contents as user types 
    them in. However the validation only takes place while user types, thus it can 
    not prevent incompletely data. For example, if a segment is marked as <b>Required</b>
    but the user left it empty, then the input is not valid.
</p>
<p>
    EO.Web Controls offers&nbsp; <b>MaskedEditValidator</b> control to address this 
    issue. It works like standard ASP.NET validators.
</p>
<p>
    The following MaskedEdit uses a <b>Number</b> segment with MaxValue set to 99 
    and MinValue set to 50. It also uses a <STRONG>Choice</STRONG> segment for user 
    to choose between "Miles" and "Km". If you leave the number segment empty and 
    click "Submit", the validation will fail.
</p>
<p>
    Please enter a distance:
    <eo:MaskedEdit runat="server" id="MaskedEdit1" IsValid="True">
        <eo:MaskedEditSegment IsRequired="True" MinValue="50" MaxValue="99" SegmentType="Number"></eo:MaskedEditSegment>
        <eo:MaskedEditSegment Text=" "></eo:MaskedEditSegment>
        <eo:MaskedEditSegment IsRequired="True" Choices="Miles|Km" SegmentType="Choice"></eo:MaskedEditSegment>
    </eo:MaskedEdit>
    <asp:Button id="Button1" runat="server" Text="Submit"></asp:Button>
</p>
<p>
    <eo:MaskedEditValidator runat="server" id="MaskedEditValidator1" ControlToValidate="MaskedEdit1" ErrorMessage="Please enter a valid number between 50 and 99."></eo:MaskedEditValidator>
</p>
</asp:Content>


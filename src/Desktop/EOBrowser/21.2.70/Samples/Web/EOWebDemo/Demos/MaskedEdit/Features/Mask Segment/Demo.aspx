<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_MaskedEdit_Features_Mask_Segment_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web MaskedEdit supports multiple <b>Segment</b> types: Literal, Choice, 
    Number and Mask. When only using one single mask segment, EO.Web MaskedEdit is 
    similar to a traditional masked edit control. The following sample demonstrates 
    a MaskedEdit control with a single Mask segment.
</p>
<eo:CallbackPanel runat="server" id="CallbackPanel1" Triggers="{ControlID:lstMasks;Parameter:}">
    <P>
        <asp:DropDownList id="lstMasks" Runat="server" Width="264px" 
            OnSelectedIndexChanged="lstMasks_SelectedIndexChanged">
            <asp:ListItem>- Please Select -</asp:ListItem>
            <asp:ListItem Value="000-000-0000">U.S. Phone Number</asp:ListItem>
            <asp:ListItem Value="000-00-0000">U.S. Social Security Number</asp:ListItem>
            <asp:ListItem Value="00000">U.S. Zip Code (5 Digits)</asp:ListItem>
            <asp:ListItem Value="00000-0000">U.S. Zip Code (9 Digits)</asp:ListItem>
            <asp:ListItem Value=">AAA AAA">Canada Zip Code</asp:ListItem>
            <asp:ListItem Value="#######">Any Number</asp:ListItem>
        </asp:DropDownList></P>
    <P>
        <eo:MaskedEdit id="MaskedEdit1" runat="server" Enabled="False" style="width:120px">
            <eo:MaskedEditSegment Text=" "></eo:MaskedEditSegment>
        </eo:MaskedEdit></P>
</eo:CallbackPanel>
</asp:Content>


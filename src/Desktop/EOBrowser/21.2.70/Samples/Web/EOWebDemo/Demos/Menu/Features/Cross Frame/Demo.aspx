<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Features_Cross_Frame_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    Please click the following link to start the cross frame demo. Note that you 
    may need to temporarily disable your popup blocker to launch the demo.
</p>
<p>
    <asp:HyperLink id="HyperLink1" runat="server" Target="_blank" NavigateUrl="~/Demos/Menu/Features/Cross Frame/Frameset.htm">Cross Frame Demo</asp:HyperLink>
</p>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_File_Explorer_Features_Browse_Only_Root_Folders_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    Click the following link to open the demo page (The sample is placed in a 
    separate page because the default layout occupies more space than available in 
    this demo region).
</p>
<p>
    <asp:HyperLink id="HyperLink1" runat="server" Target="_blank" NavigateUrl="~/Demos/File Explorer/Features/Browse Only Root Folders/Demo2.aspx">View Demo</asp:HyperLink>
</p>
</asp:Content>


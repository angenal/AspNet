<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_File_Explorer_Features_Setting_Root_Folder_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    Click the following link to open the demo page (The sample is placed in a 
    separate page because the default layout occupies more space 
    than&nbsp;available in&nbsp;this demo region).
</p>
<p>
    <asp:HyperLink id="HyperLink1" runat="server" Target="_blank" NavigateUrl="~/Demos/File Explorer/Features/Setting Root Folder/Demo2.aspx">View Demo</asp:HyperLink>
</p>
</asp:Content>


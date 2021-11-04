<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Editor_Features_Auto_Resize_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p> EO.Web Editor supports percentage 
    sizing such as "100%". Click the link below to launch a page that demonstrates this 
    feature.
</p>
<asp:HyperLink Runat="server" NavigateUrl="AutoResize.aspx" Target="demo" id="HyperLink1">View Auto Resize Demo</asp:HyperLink>
</asp:Content>


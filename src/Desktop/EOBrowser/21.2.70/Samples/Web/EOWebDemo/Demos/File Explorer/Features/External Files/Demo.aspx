<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_File_Explorer_Features_External_Files_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
EO.Web FileExplorer can be used to browse files that are outside
of your Web application root. For example, even if your Web
application root is "c:\wwwroot\site1", you can still set the
FileExplorer control's <b>RootFolder</b> to "c:\" to browse
the whole drive.
</p>
<p>
See <a href="http://doc.essentialobjects.com/library/1/FileExplorer/external_files.aspx" target="doc">accessing
external file with FileExplorer</a> for more details.
</p>
</asp:Content>


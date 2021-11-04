<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_AJAX_Uploader_Standard_Features_Demo" Title="Untitled Page" %>
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>EO.Web AJAXUploader allows you to upload files in a more intuitive and straight 
    forward way. It allows you to upload one or more files at the same time and 
    displays a progress bar and progress text indicating how much has been 
    transferred. It also gives you the ability to cancel the upload. The following 
    sample demonstrated these basic features.
</p>
<P>
    <ul>
        <li>
        To upload a file, browse a file and click "Upload". Unlike the standard ASP.NET 
        HtmlInputFile control, ASP.NET AJAXUploader does not read the full posted data 
        into memory first, thus there is no real limits as how big the file can be. The 
        limits would be the harddrive space --- for that reason this sample has set a 
        limit of 30M;</li>
        <li>
            Once the upload is started, you will see the progress moving and also have the 
            ability the cancel it;
        </li>
    </ul>
<P></P>
<eo:AJAXUploader runat="server" id="AJAXUploader1" Width="400px" TempFileLocation="~/eo_upload" MaxDataSize="30000">
</eo:AJAXUploader>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_AJAX_Uploader_Max_Upload_Data_Size_Demo"
    Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        Unlike the standard ASP.NET HttpInputFile class, EO.Web AJAXUploader does not read
        the whole posted file in memory -- EO.Web AJAXUploader streams the posted file into
        a temporary file on the server side. This way it virtually has no limits on the
        size of file to be uploaded.
    </p>
    <p>
        However for security reason, you may want to limits the size of the file to be uploaded.
        This can be achieved by setting the AJAXUploader's <b>MaxDataSize</b> property.
    </p>
    <p>
        The following sample has its <b>MaxDataSize</b> set to 100K. Thus trying to upload
        a file bigger than that will fail.
    </p>
    <p>
        The default error message is displayed in English, you can handle <b>ClientSideOnError</b>
        to provide custom error messages.
    </p>
    <eo:AJAXUploader runat="server" ID="AJAXUploader1" Width="400px" TempFileLocation="~/eo_upload"
        MaxDataSize="100">
    </eo:AJAXUploader>
</asp:Content>

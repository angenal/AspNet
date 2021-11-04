<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_AJAX_Uploader_Client_Side_API_Demo" Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">

    <script type="text/javascript">
function SubmitData()
{
    //Get the AJAX uploader
    var uploader = eo_GetObject("AJAXUploader1");
    
    //Start uploading. We have set the uploader's AutoPostBack to true,
    //so if the uploading was sucessful, the page will be posted back
    //as soon as the uploading is finished. If the uploading was not
    //sucessful (for example, when no file has been selected), our
    //ClientSideOnProgress handler will be called with both total and
    //received argument as null. In that case we will call
    //_doPostBack to submit the page
    uploader.upload();
}

function uploader_canceled()
{
    //When the uploader is canceled, the uploader will not continue
    //to postback the page, so we have to post back manually at here
    //We pass a special value "NO_FILE_SUBMIT" here, our server side
    //code checks for this special value in Page_Load
    __doPostBack("NO_FILE_SUBMIT");
}
    </script>

    <p>
        This sample demonstrates how to use AJAXUploader client side JavaScript API to submit
        other form data along with the AJAXUploader.
    </p>
    <p>
        Choose File to be Uploaded:</p>
    <eo:AJAXUploader runat="server" ID="AJAXUploader1" Width="300px" AutoPostBack="True"
        TempFileLocation="~/eo_upload" ClientSideOnCancel="uploader_canceled">
        <LayoutTemplate>
            <table cellspacing="0" cellpadding="2" width="300" border="0">
                <tr>
                    <td>
                        <asp:PlaceHolder ID="InputPlaceHolder" runat="server">Input Box Place Holder</asp:PlaceHolder>
                    </td>
                </tr>
                <tr>
                    <td>
                        <eo:ProgressBar ID="ProgressBar" runat="server" ControlSkinID="Windows_XP">
                        </eo:ProgressBar>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:PlaceHolder ID="ProgressTextPlaceHolder" runat="server">Progress Text Place Holder
                        </asp:PlaceHolder>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </eo:AJAXUploader>
    <p>
        Enter a Note:</p>
    <asp:TextBox runat="server" ID="txtNote" Width="288px"></asp:TextBox>
    <p>
        <input type="button" value="Submit" onclick="SubmitData()" />
    </p>
</asp:Content>

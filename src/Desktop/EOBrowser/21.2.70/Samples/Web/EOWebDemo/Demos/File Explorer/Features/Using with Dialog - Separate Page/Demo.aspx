<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_File_Explorer_Features_Using_with_Dialog___Separate_Page_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
function dialog_accept_handler()
{
    var textBox = document.getElementById('<%=TextBox1.ClientID%>');
    textBox.value = eo_GetObject("FileExplorerHolder1").getSelectedFile();
}
</script>
<p>
    It is often not necessary load the File Explorer control until user requests 
    such feature (for example, by clicking "Browse" button). A separate <strong>FileExplorerHolder</strong>
    control is provided to support such delay loading scheme.
</p>
<p>
    To use this feature, place a FileExplorer control into a separate page, then 
    set the FileExplorerHolder's <strong>Url</strong> property to that page.
</p>
<p>
    The following sample uses client side JavaScript interface to display a
    FileExplorerHolder with a dialog, then the FileExplorerHolder control's
    client side JavaScript interface to retrieve the selected file when user
    clicks "OK" button.
</p>
<eo:Dialog runat="server" id="Dialog1" AllowResize="True" HeaderImageUrl="00020441" HeaderImageHeight="27"
    ControlSkinID="None" Width="720px" MinHeight="100" HeaderHtml='<div style="padding-top:5px">Browse File</div>'
    Height="420px" CloseButtonUrl="00020440" AcceptButton="Button1" CancelButton="Button2"
    ClientSideOnAccept="dialog_accept_handler">
    <ContentTemplate>
        <eo:FileExplorerHolder id="FileExplorerHolder1" runat="server" Width="714px" Height="360px" Url="~/Demos/File Explorer/Explorer.aspx"></eo:FileExplorerHolder>
        <div style="text-align:right;padding-right:20px;">
            <asp:Button Runat="server" ID="Button1" Text="OK" Width="80px"></asp:Button>&nbsp;&nbsp;
            <asp:Button Runat="server" ID="Button2" Text="Cancel" Width="80px"></asp:Button>
        </div>
    </ContentTemplate>
    <HeaderStyleActive CssText="background-image:url(00020442);color:#444444;font-family:'trebuchet ms';font-size:10pt;font-weight:bold;padding-bottom:7px;padding-left:8px;padding-right:0px;padding-top:0px;"></HeaderStyleActive>
    <ContentStyleActive CssText="background-color:#f0f0f0;font-family:tahoma;font-size:8pt;padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px"></ContentStyleActive>
    <BorderImages BottomBorder="00020409,00020429" RightBorder="00020407,00020427" TopRightCornerBottom="00020405,00020425"
        TopRightCorner="00020403,00020423" LeftBorder="00020406,00020426" TopLeftCorner="00020401,00020421"
        BottomRightCorner="00020410,00020430" TopLeftCornerBottom="00020404,00020424" BottomLeftCorner="00020408,00020428"
        TopBorder="00020402,00020422"></BorderImages>
</eo:Dialog>
<asp:TextBox Runat="server" ID="TextBox1" Width="300px"></asp:TextBox>
<input type="button" value="Browse" onclick="eo_GetObject('Dialog1').show();">
</asp:Content>


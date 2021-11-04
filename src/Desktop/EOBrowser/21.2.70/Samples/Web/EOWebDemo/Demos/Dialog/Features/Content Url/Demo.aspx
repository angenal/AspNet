<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Features_Content_Url_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
function Search()
{
    var dlg = eo_GetObject('Dialog1');
    var kw = document.getElementById("txtKW").value;
    var url = "http://www.google.com/search?q=" + kw;
    dlg.setContentUrl(url);
    dlg.show(true);
}
</script>
<p>
    EO.Web Dialog can display another Web page inside a dialog -- simply set the 
    dialog's <b>ContentUrl</b> property.
</p>
<eo:Dialog runat="server" id="Dialog1" ContentUrl="http://www.google.com" HeaderHtml="A Dialog Displaying Google's Homepage"
    FooterHtml="This is Google's homepage!" BorderStyle="Solid" CloseButtonUrl="00070101" MinimizeButtonUrl="00070102"
    AllowResize="True" ControlSkinID="None" Width="400px" BorderWidth="1px" Height="300px"
    ShadowColor="LightGray" BorderColor="#335C88" RestoreButtonUrl="00070103" ShadowDepth="3"
    ResizeImageUrl="00020014">
    <FooterStyleActive CssText="font-family:Tahoma;font-size:11px;padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px;"></FooterStyleActive>
    <HeaderStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; background-image: url(00070104); padding-bottom: 3px; padding-top: 3px; font-family: tahoma"></HeaderStyleActive>
    <ContentStyleActive CssText="background-color:#e5f1fd;border-top-color:#335c88;border-top-style:solid;border-top-width:1px;"></ContentStyleActive>
</eo:Dialog>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show(false);">Show Modeless</a>
</p>
<p>
    <a href="javascript:eo_GetObject('Dialog1').show(true);">Show Modal</a>
</p>
<p>
    You can also change <b>ContentUrl</b> on the client side. The following links display
    Google's home page with different query strings.
</p>
<p>
    <input id="txtKW" type="text" style="width:200px" />&nbsp;&nbsp;<a href="javascript:Search();">Show Search Result</a>
</p>
</asp:Content>


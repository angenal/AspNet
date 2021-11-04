<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Features_Client_Side_Event_Handler_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
function OnDialogCancel(e)
{
    return window.confirm("Are you sure?");
}
</script>
<p>
    EO.Web Dialog supports a set of client event handlers through which you can 
    intercept and cancel various client side events. The following sample uses <b>ClientSideOnCancel</b>
    to intercept close event.
</p>
<eo:Dialog runat="server" id="Dialog1" BorderStyle="Solid" BackColor="White" CloseButtonUrl="00070201"
    ControlSkinID="None" Width="168px" BorderWidth="1px" Height="120px" BorderColor="#728EB8"
    IconUrl="00070203" HeaderHtml="MSN Messenger" ClientSideOnCancel="OnDialogCancel">
    <HeaderStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; background-image: url(00070202); padding-bottom: 2px; padding-top: 2px; font-family: arial"></HeaderStyleActive>
    <ContentStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; padding-bottom: 4px; padding-top: 4px; font-family: verdana; background-color: #f8fafd"></ContentStyleActive>
</eo:Dialog>
<a href="javascript:eo_GetObject('Dialog1').show();">Show Dialog</a>
</asp:Content>


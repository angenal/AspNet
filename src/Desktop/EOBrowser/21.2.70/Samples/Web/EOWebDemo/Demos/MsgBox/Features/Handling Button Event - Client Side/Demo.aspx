<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_MsgBox_Features_Handling_Button_Event___Client_Side_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
function ShowDemoMsgBox()
{
    eo_MsgBox(
        "MsgBox1",        //ID of the MsgBox control
        "Hello",        //Message box title
        "This is a test message.",    //Message text
        null,            //Icon
        [
            {
                Text: "OK",        //OK button
                ClientSideHandler: "on_button_clicked"    //Client side event handler
            },
            
            {
                Text: "Cancel",    //Cancel button
                ClientSideHandler: "on_button_clicked"    //Client side event handler
            }
        ]);
}

function on_button_clicked(msgBox, buttonIndex)
{
    alert("Button #" + buttonIndex.toString() + " is clicked.");
}
</script>
<p>
    To handle button click event on the client side, initialize the button with a <strong>
        ClientSideEventHandler</strong> value. The following sample demonstrates 
    how to use this feature.
</p>
<p>
    <asp:Button Runat="server" ID="Button1" Text="Show Message Box from Server Side Code" OnClick="Button1_Click"></asp:Button>
</p>
<p>
    <input type="button" onclick="ShowDemoMsgBox()" value="Show Message Box from Client Side Code">
</p>
<p>
    <asp:Label Runat="server" ID="Label1"></asp:Label>
</p>
<eo:MsgBox runat="server" id="MsgBox1" HeaderHtml="Dialog Title" MinWidth="150" Width="320px"
    HeaderImageUrl="00020441" HeaderHtmlFormat='<div style="padding-top:4px">{0}</div>' Height="216px"
    ControlSkinID="None" MinHeight="100" HeaderImageHeight="27" AllowResize="True" CloseButtonUrl="00020440">
    <FooterStyleActive CssText="background-color:#f0f0f0; padding-right: 4px; padding-left: 4px; font-size: 8pt; padding-bottom: 4px; padding-top: 4px; font-family: tahoma"></FooterStyleActive>
    <HeaderStyleActive CssText="background-image:url(00020442);color:#444444;font-family:'trebuchet ms';font-size:10pt;font-weight:bold;padding-bottom:7px;padding-left:8px;padding-right:0px;padding-top:0px;"></HeaderStyleActive>
    <ContentStyleActive CssText="background-color:#f0f0f0;font-family:tahoma;font-size:8pt;padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px"></ContentStyleActive>
    <BorderImages BottomBorder="00020409,00020429" RightBorder="00020407,00020427" TopRightCornerBottom="00020405,00020425"
        TopRightCorner="00020403,00020423" LeftBorder="00020406,00020426" TopLeftCorner="00020401,00020421"
        BottomRightCorner="00020410,00020430" TopLeftCornerBottom="00020404,00020424" BottomLeftCorner="00020408,00020428"
        TopBorder="00020402,00020422"></BorderImages>
</eo:MsgBox>
</asp:Content>


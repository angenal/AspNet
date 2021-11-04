<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Color_Picker_Features_Client_Event_Demo"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">

    <script type="text/javascript">
function UpdateResult(colorPicker)
{
    var span = document.getElementById("spanResult");
    span.innerHTML = "New Color: " + colorPicker.getValue();
}
    </script>

    <p>
        EO.Web ColorPicker supports <b>ClientSideOnChange</b> event that allows you to execute
        your own JavaScript code when user selects a color. The following example uses this
        event to update the innerHTML of a span element.
    </p>
    <eo:ColorPicker runat="server" ID="ColorPicker1" ControlSkinID="None" ClientSideOnChange="UpdateResult">
        <TextBoxStyle CssText="border-right: #7f9db9 1px solid; border-top: #7f9db9 1px solid; border-left: #7f9db9 1px solid; border-bottom: #7f9db9 1px solid">
        </TextBoxStyle>
        <PopupStyle CssText="border-right: #999999 1px solid; border-top: #999999 1px solid; font-size: 10pt; border-left: #999999 1px solid; color: #0751b8; border-bottom: #999999 1px solid; font-family: arial; background-color: white">
        </PopupStyle>
    </eo:ColorPicker>
    <span id="spanResult"></span>
</asp:Content>

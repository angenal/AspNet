<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Editable_Label_Client_Side_Event_Demo" %>
<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
function change_handler(editableLabel, newValue)
{
    //Get the new value
    var panNewValue = document.getElementById("panNewValue");

    //Convert the new to uppercase and display it
    newValue = newValue.toUpperCase();
    panNewValue.innerHTML = "New Value: " + newValue;

    //Return the converted value
    return newValue;
}
//<!--JS_SAMPLE_END-->
    </script>
    <p>
    EO.Web.EditableLabel supports <b>ClientSideOnChange</b> event through JavaScript.
    You can provide a JavaScript handler to handle this event when the EditableLabel's
    content is changed. You can also alter or deny the new value from this handler. 
    This sample demonstrates how to automatically change the value to uppercase. To
    deny the new value, simply return <b>false</b> from your handler.
    </p>
    <eo:EditableLabel runat="server" ID="EditableLabel1" 
    Width="250px" Hint="Click to enter" ClientSideOnChange="change_handler">
        <NormalStyle CssText="border: 1px dashed #808000; background-color: white; padding: 2px;" />
        <ActiveStyle CssText="border: 1px solid black; background-color: white; padding: 2px;" />
    </eo:EditableLabel>
    <p id="panNewValue">
    </p>
</asp:Content>


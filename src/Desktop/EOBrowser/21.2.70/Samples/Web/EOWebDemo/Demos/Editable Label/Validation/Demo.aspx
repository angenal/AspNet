<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Editable_Label_Validation_Demo" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        EO.Web EditableLabel control supports standard validator controls. The following
        sample uses a RequiredFieldValidator with the EditableLabel control.
    </p>
    <eo:EditableLabel runat="server" ID="EditableLabel1" Width="200px" Hint="Click here to edit">
        <NormalStyle CssText="border: 1px dashed #808000; background-color: white; padding: 2px;" />
        <ActiveStyle CssText="border: 1px solid black; background-color: white; padding: 2px;" />
    </eo:EditableLabel>
    <asp:RequiredFieldValidator runat="server" ID="RequiredValidator1" ErrorMessage="This field is required."
        ControlToValidate="EditableLabel1" Display="Static">
    </asp:RequiredFieldValidator>
    <p>
        <asp:Button runat="server" ID="Button1" Text="Submit" />
    </p>
</asp:Content>

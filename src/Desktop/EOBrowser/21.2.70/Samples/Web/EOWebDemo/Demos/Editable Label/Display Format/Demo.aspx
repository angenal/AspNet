<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Editable_Label_Display_Format_Demo" %>
<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        Set the EditableLabel control's <b>Format</b> property to instruct the
        control to display the value with the given format. The following sample
        has the control's Format property set to "&lt;b&gt;Your Name:&lt;/b&gt;: {0}"
        so that when the control is not in edit mode, it displays "Your Name" in
        front of the text value.
    </p>
    <eo:EditableLabel runat="server" ID="EditableLabel1" 
    Width="250px" Hint="Click to enter" Format="<b>Your Name:</b> {0}">
        <NormalStyle CssText="border: 1px dashed #808000; background-color: white; padding: 2px;" />
        <ActiveStyle CssText="border: 1px solid black; background-color: white; padding: 2px;" />
    </eo:EditableLabel>
</asp:Content>


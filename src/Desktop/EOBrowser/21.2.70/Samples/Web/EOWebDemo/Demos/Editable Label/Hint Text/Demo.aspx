<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Editable_Label_Hint_Text_Demo" %>
<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        EO.Web.EditableLabel can displays a "prompt text" when the contents
        is empty. The follow EditableLabel control displays "click here to edit"
        when its Value is empty and displays its Value when it is not empty.
    </p>
    <eo:EditableLabel runat="server" ID="EditableLabel1" 
    Width="200px" Hint="Click here to edit">        
        <NormalStyle CssText="border: 1px dashed #808000; background-color: white; padding: 2px;" />
        <ActiveStyle CssText="border: 1px solid black; background-color: white; padding: 2px;" />
    </eo:EditableLabel>
    <p>
    <asp:Button runat="server" ID="Button1" Text="Check Value" 
            onclick="Button1_Click" />
    </p>
    <asp:Label runat="server" ID="Label1">
    </asp:Label>
</asp:Content>


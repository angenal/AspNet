<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Editable_Label_Server_Side_Event_Demo" %>
<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        EO.Web.EditableLabel supports <b>Changed</b> event, which is similar
        to the standard ASP.NET TextBox's TextChanged event.
    </p>
    <eo:EditableLabel runat="server" ID="EditableLabel1" 
    Width="200px" Hint="Click to edit" MaxLength="100" 
        onchanged="EditableLabel1_Changed">        
        <NormalStyle CssText="border: 1px dashed #808000; background-color: white; padding: 2px;" />
        <ActiveStyle CssText="border: 1px solid black; background-color: white; padding: 2px;" />
    </eo:EditableLabel>
    <p>
    <asp:Button runat="server" ID="Button1" Text="Submit" />
    </p>
    <p>
        <asp:Label runat="server" ID="Label1"></asp:Label>
    </p>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Editable_Label_Max_Length_Demo" %>
<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        Set the EditableLabel control's <b>MaxLength</b> property to limit
        the maximum number of characters that the user can enter. The following
        sample has MaxLength set to 100.
    </p>
    <eo:EditableLabel runat="server" ID="EditableLabel1" 
    Width="200px" Hint="Click to edit" MaxLength="100">        
        <NormalStyle CssText="border: 1px dashed #808000; background-color: white; padding: 2px;" />
        <ActiveStyle CssText="border: 1px solid black; background-color: white; padding: 2px;" />
    </eo:EditableLabel>
    <p>
</asp:Content>



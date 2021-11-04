<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Editable_Label_Basic_Feature_Demo" %>
<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <eo:EditableLabel runat="server" ID="EditableLabel1"
     Value="&lt;p&gt;This is a basic demo. Click here to edit this text. You can:&lt;/p&gt;
&lt;ul&gt;
&lt;li&gt;Enter any valid HTML markup;&lt;/li&gt;
&lt;li&gt;Enter more text and textbox will automatically grow;&lt;/li&gt;
&lt;/ul&gt;
&lt;p&gt;Click anywhere outside of the textbox or press Enter/Tab/Esc key
to exit edit mode. Use Shift+Enter to start a new line in edit mode.&lt;/p&gt;">        
    </eo:EditableLabel>
</asp:Content>


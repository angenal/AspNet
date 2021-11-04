<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Calendar_Programming_Custom_Rendering_Demo"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        EO.Web Calendar Controls support custom rendering via <span class="highlight">RenderDay</span>
        event. You can output any HTML contents into each day cell. See <a href="javascript:GoToDemo('scheduler');">
            here</a> for an example.
    </p>
</asp:Content>

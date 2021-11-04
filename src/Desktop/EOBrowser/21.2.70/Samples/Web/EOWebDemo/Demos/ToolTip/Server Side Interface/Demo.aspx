<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ToolTip_Server_Side_Interface_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        This sample demonstrates how to dynamically update the ToolTip from
        the server side.
    </p>
    <p id="panHint">
        Move mouse to here to see the current time.
    </p>
    <eo:ToolTip runat="server" ID="ToolTip1" For="panHint">
        <ContentTemplate>
            <asp:Label runat="server" ID="Label1"></asp:Label>
        </ContentTemplate>
    </eo:ToolTip>
</asp:Content>


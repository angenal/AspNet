<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Captcha_Basic_Feature_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
    EO.Web Captcha provides a reliable way to prevent SPAM/Bots by
    generating an image that can be used to test whether the client
    is a human.
    </p>
    <asp:Panel runat="server" ID="panInput">
    <eo:Captcha runat="server" ID="Captcha1" PromptHtml="">         
        <ImageStyle CssText="border: solid 1px #c0c0c0; float: left;margin-right:5px;" />
        <TextBoxStyle CssText="border: solid 1px #b7d9ed;margin-top:3px;padding-left:2px;padding-right:2px;padding-top:1px;padding-bottom:1px;width:146px;" />
        <RefreshLinkStyle CssText="margin-left:5px;" />
        <AudioLinkStyle CssText="margin-left:5px;margin-bottom:20px;" />
    </eo:Captcha>
    <p>
        <asp:Button runat="server" ID="Button1" Text="Submit" onclick="Button1_Click" />
    </p>
    </asp:Panel>
    <asp:Panel runat="server" ID="panResult" Visible="false">
        <p>
            You entered the correct code. 
        </p>
        <asp:Button runat="server" ID="Button2" Text="Try Again" 
            onclick="Button2_Click" />
    </asp:Panel>
</asp:Content>


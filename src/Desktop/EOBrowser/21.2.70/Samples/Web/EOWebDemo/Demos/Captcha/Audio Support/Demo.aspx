<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Captcha_Audio_Support_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
    EO.Captcha provides an "Audio" link button for user to read out
    CAPTCHA text. The following sample customizes <b>RefreshLinkHtml</b>
    and <b>AudioLinkHtml</b> to display an image button for refreshing
    the image and reading out the CAPTCHA text respectively.
    </p>
    <p>
    To turn off audio, either set <b>AudioLinkHtml</b> to an
    empty string or include <i>display:none;</i> CSS attribute in
    <b>AudioLinkStyle</b>.
    </p>
    <asp:Panel runat="server" ID="panInput">
        <eo:Captcha runat="server" ID="Captcha1" style="position:relative;" 
             RefreshLinkHtml="&lt;img src='refresh.gif' border='0' alt='Refresh' /&gt;"
             AudioLinkHtml="&lt;img src='audio.gif' border='0' alt='Audio' /&gt;">         
            <ImageStyle CssText="border: solid 1px #c0c0c0;position:absolute; left: 0px; top: 0px;" />
            <TextBoxStyle CssText="border: solid 1px #b7d9ed;padding-left:2px;padding-right:2px;padding-top:1px;padding-bottom:1px;width:146px;position:absolute;top:58px;" />
            <RefreshLinkStyle CssText="position:absolute;left:153px;top:3px;" />
            <AudioLinkStyle CssText="position:absolute;left:153px;top:30px;" />        
            <PromptStyle CssText="position:absolute; left:155px; top: 60px;" />
            <ErrorMessageStyle CssText="position:absolute; left:155px; top: 60px; color:red;" />
        </eo:Captcha>
        <div style="padding-top:82px">
            <asp:Button runat="server" ID="Button1" Text="Submit" onclick="Button1_Click" />
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="panResult" Visible="false">
        <p>
            You entered the correct code. 
        </p>
        <asp:Button runat="server" ID="Button2" Text="Try Again" 
            onclick="Button2_Click" />
    </asp:Panel>
</asp:Content>


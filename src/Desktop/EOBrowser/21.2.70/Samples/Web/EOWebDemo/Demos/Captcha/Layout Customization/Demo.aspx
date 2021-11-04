<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Captcha_Layout_Customization_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        EO.Web Captcha provides <b>ImageStyle</b>, <b>TextBoxStyle</b>, <b>AudioLinkStyle</b>,
        <b>RefreshLinkStyle</b>, <b>PromptStyle</b> and <b>ErrorMessageStyle</b> for customizing
        the appearance of each section with CSS. The following sample uses absolute positioning
        in each of these sections to completely rearrange the captcha layout.
    </p>
    <p>
        See <a href="http://doc.essentialobjects.com/library/1/Captcha/layout_customization.html"
            target="_blank">layout customization</a> for more details.
    </p>
    <asp:Panel runat="server" ID="panInput">
        <eo:Captcha runat="server" ID="Captcha1" Style="position: relative;">
            <RefreshLinkStyle CssText="position:absolute;left:0px;top:42px;" />
            <AudioLinkStyle CssText="position:absolute;left:50px;top:42px;" />
            <ImageStyle CssText="position:absolute;left:0px;top:62px;" />
            <TextBoxStyle CssText="position:absolute; left:0px; top: 20px; border: solid 1px #b7d9ed;margin-top:3px;padding-left:2px;padding-right:2px;padding-top:1px;padding-bottom:1px;width:146px;" />
            <PromptStyle CssText="position:absolute; left: 0px; top: 0px;" />
            <ErrorMessageStyle CssText="position:absolute; left: 0px; top: 0px; color:red;" />
        </eo:Captcha>
        <div style="padding-top: 125px">
            <asp:Button runat="server" ID="Button1" Text="Submit" OnClick="Button1_Click" />
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="panResult" Visible="false">
        <p>
            You entered the correct code.
        </p>
        <asp:Button runat="server" ID="Button2" Text="Try Again" OnClick="Button2_Click" />
    </asp:Panel>
</asp:Content>

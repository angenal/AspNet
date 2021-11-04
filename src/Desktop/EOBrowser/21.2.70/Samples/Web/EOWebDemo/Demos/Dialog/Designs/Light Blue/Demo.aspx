<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Designs_Light_Blue_Demo" Title="Untitled Page" %>
    <%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        In addition to style properties, this dialog also has <b>CloseButtonUrl</b>, <b>MinimizeButtonUrl</b>,
        <b>RestoreButtonUrl</b> and <b>ResizeImageUrl</b> set. These images create the minimize/restore
        button, close button and the resizing grip.
    </p>
    <eo:Dialog runat="server" ID="Dialog1" ControlSkinID="None" Width="300px" Height="200px"
        HeaderHtml="Dialog Header" BorderStyle="Solid" CloseButtonUrl="00070101" MinimizeButtonUrl="00070102"
        AllowResize="True" BorderWidth="1px" ShadowColor="LightGray" BorderColor="#335C88"
        RestoreButtonUrl="00070103" ShadowDepth="3" ResizeImageUrl="00020014">
        <HeaderStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; background-image: url(00070104); padding-bottom: 3px; padding-top: 3px; font-family: tahoma">
        </HeaderStyleActive>
        <ContentStyleActive CssText="border-top: #335c88 1px solid; background-color: #e5f1fd">
        </ContentStyleActive>
    </eo:Dialog>
    <p>
        <a href="javascript:eo_GetObject('Dialog1').show(false);">Show Modeless</a>
    </p>
    <p>
        <a href="javascript:eo_GetObject('Dialog1').show(true);">Show Modal</a>
    </p>
</asp:Content>

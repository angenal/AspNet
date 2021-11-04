<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Color_Picker_Features_Server_Event_Demo"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        EO.Web ColorPicker can trigger server side <b>Change</b> event when the color picker's
        <b>Value</b> property changes between post backs. By default, the color picker does
        not trigger a post back when user selects a color unless <b>AutoPostBack</b> is
        set to true.
    </p>
    <eo:CallbackPanel runat="server" ID="CallbackPanel1" Triggers="{ControlID:CheckBox1;Parameter:},{ControlID:Button1;Parameter:},{ControlID:ColorPicker1;Parameter:}">
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Enable AutoPostBack" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
        <p>
            <eo:ColorPicker ID="ColorPicker1" runat="server" ControlSkinID="None" OnChange="ColorPicker1_Change">
                <TextBoxStyle CssText="border-right: #7f9db9 1px solid; border-top: #7f9db9 1px solid; border-left: #7f9db9 1px solid; border-bottom: #7f9db9 1px solid">
                </TextBoxStyle>
                <PopupStyle CssText="border-right: #999999 1px solid; border-top: #999999 1px solid; font-size: 10pt; border-left: #999999 1px solid; color: #0751b8; border-bottom: #999999 1px solid; font-family: arial; background-color: white">
                </PopupStyle>
            </eo:ColorPicker>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server"></asp:Label></p>
        <p>
            <asp:Button ID="Button1" Text="Post Back!" runat="server"></asp:Button></p>
    </eo:CallbackPanel>
</asp:Content>

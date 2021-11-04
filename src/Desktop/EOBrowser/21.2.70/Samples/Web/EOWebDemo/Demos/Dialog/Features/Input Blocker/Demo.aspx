<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Dialog_Features_Input_Blocker_Demo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        A modal dialog with a back shade color can be effectively used as an input blocker
        to temporarily block user input.
    </p>
    <p>
        Enter some text below and then click "Submit" button.
    </p>
    <eo:CallbackPanel runat="server" ID="CallbackPanel1" LoadingDialogID="Dialog1" Triggers="{ControlID:Button1;Parameter:}">
        <p>
            Some Input:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click"></asp:Button></p>
        <p>
            <asp:Label ID="lblResult" runat="server"></asp:Label></p>
    </eo:CallbackPanel>
    <eo:Dialog runat="server" ID="Dialog1" BackShadeColor="Blue">
        <ContentTemplate>
            <table border="0">
                <tr>
                    <td align="center">
                        <img src='<%=ResolveClientUrl("~/Images/loading.gif")%>' />
                    </td>
                </tr>
                <tr>
                    <td nowrap="true">
                        Please wait...</td>
                </tr>
            </table>
        </ContentTemplate>
    </eo:Dialog>
</asp:Content>

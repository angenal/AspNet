<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Callback_Features_Misc_Features_Demo"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <h3 style="width: 100px">
        Debug Support</h3>
    <p>
        ASP.NET displays the code error when an error occurred on the server side so that
        programmer can use the information to locate and fix the error. The situation can
        be much more difficult when using an AJAX solution because the full page is not
        being reloaded.
    </p>
    <p>
        EO.Web Callback and CallbackPanel automatically checks whether a server side error
        has occurred and displays the error message.
    </p>
    <h3 style="width: 100px">
        Server Redirect</h3>
    <p>
        Sometimes it's necessary to redirect to another page during a Callback. Unfortunately
        the standard Response.Redirect does not work during callback because an AJAX callback
        does not refresh the whole page.
    </p>
    <p>
        EO.Web Callback and CallbackPanel implements a <span class="highlights">Redirect</span>
        function so that you can redirect to another page easily during a callback if necessary.
    </p>
    <p>
        &nbsp;</p>
    <p>
        The following link will open a new page that demonstrates both features. Note you
        may need to temporarily disable your popup blocker to open the demo page.
    </p>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Demo2.aspx" Target="_blank">Debug Support and Server Redirect Demo</asp:HyperLink>
    </p>
</asp:Content>

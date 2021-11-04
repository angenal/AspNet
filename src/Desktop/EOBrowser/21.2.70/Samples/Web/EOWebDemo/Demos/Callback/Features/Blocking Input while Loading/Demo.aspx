<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Callback_Features_Blocking_Input_while_Loading_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
EO.Web CallbackPanel supports <b>LoadingDialogID</b> property. The property points
to an <b>EO.Web.Dialog</b> control in the form and displays the dialog when callback
is in progress. Since the dialog is displayed as modal, it can be used to temporarily
block user input.
</p>
<p>
See <a href="javascript:GoToDemo('input_blocker');">here</a> for a working sample
demonstrating this feature.
</p>
</asp:Content>


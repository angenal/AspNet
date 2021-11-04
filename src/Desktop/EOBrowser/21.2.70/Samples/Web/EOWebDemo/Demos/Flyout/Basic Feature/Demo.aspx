<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Flyout_Basic_Feature_Demo" %>

<%@ Register src="../MovieAndTV.ascx" tagname="MovieAndTV" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        This sample demonstrates a basic flyout that is triggered when
        mouse hovers over the image button. The content of the flyout
        popup is defined by the control's <b>ContentTemplate</b> property.
        The trigger button is defined by the control's <b>For</b> property.
    </p>
    <p>
        Move mouse over <b>Movies & TV</b> button to see it in action.
    </p>
    <div>
    <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="../Images/movies_and_tv.gif"></asp:ImageButton>
    </div>
    <eo:Flyout runat="server" ID="Flyout1" For="ImageButton1">
        <ContentTemplate> 
            <uc1:MovieAndTV ID="MovieAndTV" runat="server" />
        </ContentTemplate>
    </eo:Flyout>
</asp:Content>


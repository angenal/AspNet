<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FlyoutCtrl.ascx.cs" Inherits="Demos_Flyout_Dynamic_Flyout_FlyoutCtrl" %>
<%@ Register src="../MovieAndTV.ascx" tagname="MovieAndTV" tagprefix="uc1" %>
<p>
<asp:Label runat="server" ID="lblMsg"></asp:Label>
</p>
<p>
<asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="../Images/movies_and_tv.gif"></asp:ImageButton>
</p>
<eo:Flyout runat="server" ID="Flyout1" For="ImageButton1">
    <ContentTemplate> 
        <uc1:MovieAndTV ID="MovieAndTV" runat="server" />
    </ContentTemplate>
</eo:Flyout>

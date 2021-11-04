<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Flyout_Expand_Direction_Demo" %>
<%@ Register src="../MovieAndTV.ascx" tagname="MovieAndTV" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
Set the Flyout control's <b>ExpandDirection</b> to control flyout
expand direction. The following sample demonstrates how different
settings look like.
<table width="100%">
    <tr>
        <td width="50%">
            <p>
            ExpandDirection = Auto (BottomRight)
            </p>
            <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="../Images/movies_and_tv.gif"></asp:ImageButton>
            <eo:Flyout runat="server" ID="Flyout1" For="ImageButton1" ExpandDirection="BottomRight">
                <ContentTemplate> 
                    <uc1:MovieAndTV ID="MovieAndTV1" runat="server" />
                </ContentTemplate>
            </eo:Flyout>
        </td>
        <td width="50%">
            <p>
            ExpandDirection = BottomLeft
            </p>
            <asp:ImageButton runat="server" ID="ImageButton2" ImageUrl="../Images/movies_and_tv.gif"></asp:ImageButton>
            <eo:Flyout runat="server" ID="Flyout2" For="ImageButton2" ExpandDirection="BottomLeft">
                <ContentTemplate> 
                    <uc1:MovieAndTV ID="MovieAndTV2" runat="server" />
                </ContentTemplate>
            </eo:Flyout>
        </td>
    </tr>
    <tr>
        <td width="50%">
            <p>
            ExpandDirection = All
            </p>
            <asp:ImageButton runat="server" ID="ImageButton3" ImageUrl="../Images/movies_and_tv.gif"></asp:ImageButton>
            <eo:Flyout runat="server" ID="Flyout3" For="ImageButton3" ExpandDirection="All">
                <ContentTemplate> 
                    <uc1:MovieAndTV ID="MovieAndTV3" runat="server" />
                </ContentTemplate>
            </eo:Flyout>
        </td>
        <td></td>
    </tr>
    <tr>
        <td width="50%">
            <p>
            ExpandDirection = TopRight
            </p>
            <asp:ImageButton runat="server" ID="ImageButton4" ImageUrl="../Images/movies_and_tv.gif"></asp:ImageButton>
            <eo:Flyout runat="server" ID="Flyout4" For="ImageButton4" ExpandDirection="TopRight">
                <ContentTemplate> 
                    <uc1:MovieAndTV ID="MovieAndTV4" runat="server" />
                </ContentTemplate>
            </eo:Flyout>
        </td>
        <td></td>
    </tr>
</table>
</asp:Content>


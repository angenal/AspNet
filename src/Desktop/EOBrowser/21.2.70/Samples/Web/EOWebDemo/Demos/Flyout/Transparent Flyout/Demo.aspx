<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Flyout_Transparent_Flyout_Demo" %>
<%@ Register src="../MovieAndTV.ascx" tagname="MovieAndTV" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="../Images/movies_and_tv.gif"></asp:ImageButton>
    <p>
    Move mouse over the above button and you should see this
    text below the flyout.    
    </p>
    <p>
    The <b>ContentTemplate</b> for this flyout is set to be 80%
    transparent. The setting can be achived through CSS, however
    this samples calls <span class="code">EO.Web.DOMUtils.setAlpha</span>
    utility function to handle cross browser issues.
    </p>
    <eo:Flyout runat="server" ID="Flyout1" For="ImageButton1">
        <ContentTemplate> 
            <div id="divFlyout">
                <uc1:MovieAndTV ID="MovieAndTV" runat="server" />
            </div>
        </ContentTemplate>
    </eo:Flyout>
    <script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
var div = document.getElementById("divFlyout");
EO.Web.DOMUtils.setAlpha(div.parentNode, 80);
//<!--JS_SAMPLE_END-->
    </script>
</asp:Content>


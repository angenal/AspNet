<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Rating_Maximum_Star_Count_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        By default, a Rating control has 5 "stars". Set the Rating
        control's <b>MaxStarCount</b> property to change the number of
        stars. The following sample has <b>MaxStarCount</b> set to 10.
    </p>
    <eo:Rating runat="server" ID="Rating1" ControlSkinID="None" 
        EmptyStarHoverImageUrl="00108004" EmptyStarImageUrl="00108002" 
        FullStarHoverImageUrl="00108003" FullStarImageUrl="00108001" MaxStarCount="10" 
        Value="3">
    </eo:Rating>
</asp:Content>


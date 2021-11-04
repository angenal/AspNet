<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Rating_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
    EO.Web Rating allows user to select a "rating" by selecting 
    number of stars from a given total number of stars. Key
    features include:
    </p>
    <ul>
        <li>Supports all popular browsers: IE 6.0+, FireFox 1.0+, Mozilla 1.3+, Opera 7.2+,
            Safari 1.3+ and Chrome; </li>
        <li>Works with all major ASP.NET versions since ASP.NET 2.0; </li>
        <li>Fully customizable: number of total stars, a full star image, an empty star image,
            star size, etc; </li>
        <li>Supports three precision mode: whole, half or exact. When in whole mode, a star
            can be selected or unselected as a whole; in half mode, a star can be unselected,
            half selected or fully selected; in exact mode, user can select exact value such
            as 4.1, 4.2 depending on mouse position; </li>
        <li>Supports pointer device (mouse) as well as touch device. On a touch device, user
            can set select value with a swipe; </li>
    </ul>
</asp:Content>


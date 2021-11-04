<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Slider_Value_On_Thumb_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        EO.Web Slider can display the current value on the thumb. The following sample demonstrates
        this feature. In order to display the current value on the thumb, the thumb must be large
        enough to hold the text and you must set <b>ShowValueOnThumb</b> property to <b>true</b>. You
        can also use <b>ValueCssClass</b> property to customize the CSS style of the value text.
    </p>
    <eo:Slider runat="server" ID="Slider1" 
        SelectedTrack-DisabledImageUrl="00109306" SelectedTrack-Height="3" 
        SelectedTrack-ImageUrl="00109305" ShowValueOnThumb="True" 
        Thumb-DisabledImageUrl="00109310" Thumb-Height="18" Thumb-ImageUrl="00109309" 
        Thumb-Width="30" Track-DisabledImageUrl="00109302" Track-Height="3" 
        Track-ImageUrl="00109301" Value="0" Width="300px"></eo:Slider>
</asp:Content>


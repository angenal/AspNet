<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Slider_Orientation_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        EO.Web Slider and RangeSlider can be either horizontal or vertical. To create a
        vertical slider, set the Slider's <b>Orientation</b> to <b>Vertical</b>. Very often
        you would also want to set the slider's <b>Reverse</b> to <b>true</b> when using
        vertical slider. The following slider has <b>Orientation</b> set to <b>Vertical</b>
        and <b>Reverse</b> set to <b>true</b>.
    </p>
    <div class="indent1">
        <eo:Slider runat="server" ID="Slider1" DecreaseButton-DisabledImageUrl="00109004"
            DecreaseButton-DownImageUrl="00109003" DecreaseButton-Height="20" DecreaseButton-HoverImageUrl="00109002"
            DecreaseButton-ImageUrl="00109001" DecreaseButton-Width="20" Height="300px" IncreaseButton-DisabledImageUrl="00109008"
            IncreaseButton-DownImageUrl="00109007" IncreaseButton-Height="20" IncreaseButton-HoverImageUrl="00109006"
            IncreaseButton-ImageUrl="00109005" IncreaseButton-Width="20" LargeTickImage-Height="1"
            LargeTickImage-ImageUrl="00109028" LargeTickImage-Width="20" LargeTickPosition="Both"
            Orientation="Vertical" Reverse="True" SelectedTrack-DisabledImageUrl="00109036"
            SelectedTrack-DownImageUrl="00109035" SelectedTrack-HoverImageUrl="00109034"
            SelectedTrack-ImageUrl="00109033" SelectedTrack-Width="5" SmallTickImage-Height="1"
            SmallTickImage-ImageUrl="00109027" SmallTickImage-Width="13" SmallTickPosition="Both"
            Thumb-DisabledImageUrl="00109024" Thumb-DownImageUrl="00109023" Thumb-Height="9"
            Thumb-HoverImageUrl="00109022" Thumb-ImageUrl="00109021" Thumb-Width="13" Track-DisabledImageUrl="00109016"
            Track-DownImageUrl="00109015" Track-HoverImageUrl="00109014" Track-ImageUrl="00109013"
            Track-Width="5" Value="0">
        </eo:Slider>
    </div>
</asp:Content>

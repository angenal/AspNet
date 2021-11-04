<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Slider_Labels_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <style type="text/css">
        .labels
        {
            font-family: Verdana;
            font-size: 9px;
            padding-bottom: 3px;
        }
    </style>
    <p>
        EO.Web Slider and RangeSlider can display labels at any value.
        The following sample demonstrates this feature.
    </p>
    <eo:Slider runat="server" ID="Slider1" 
        LabelPosition="TopLeft" LabelCssClass="labels" 
        LargeTickValueCssClass="labels"  LargeTickValuePosition="TopLeft"         
        DecreaseButton-DisabledImageUrl="00109004" 
        DecreaseButton-DownImageUrl="00109003" DecreaseButton-Height="20" 
        DecreaseButton-HoverImageUrl="00109002" DecreaseButton-ImageUrl="00109001" 
        DecreaseButton-Width="20" IncreaseButton-DisabledImageUrl="00109008" 
        IncreaseButton-DownImageUrl="00109007" IncreaseButton-Height="20" 
        IncreaseButton-HoverImageUrl="00109006" IncreaseButton-ImageUrl="00109005" 
        IncreaseButton-Width="20" LargeChange="1" LargeTickImage-Height="20" 
        LargeTickImage-ImageUrl="00109026" LargeTickImage-Width="1" 
        LargeTickPosition="Both" MaximumValue="10" 
        SelectedTrack-DisabledImageUrl="00109032" SelectedTrack-DownImageUrl="00109031" 
        SelectedTrack-Height="5" SelectedTrack-HoverImageUrl="00109030" 
        SelectedTrack-ImageUrl="00109029" SmallTickImage-Height="13" 
        SmallTickImage-ImageUrl="00109025" SmallTickImage-Width="1" 
        SmallTickPosition="None" Thumb-DisabledImageUrl="00109020" 
        Thumb-DownImageUrl="00109019" Thumb-Height="13" Thumb-HoverImageUrl="00109018" 
        Thumb-ImageUrl="00109017" Thumb-Width="9" Track-DisabledImageUrl="00109012" 
        Track-DownImageUrl="00109011" Track-Height="5" Track-HoverImageUrl="00109010" 
        Track-ImageUrl="00109009" Value="0" Width="400px">
        <Labels>
            <eo:SliderLabel Value="0" Text="Very Poor" />
            <eo:SliderLabel Value="2.5" Text="Poor" />
            <eo:SliderLabel Value="5" Text="Average" />
            <eo:SliderLabel Value="7.5" Text="Good" />
            <eo:SliderLabel Value="10" Text="Very Good" />
        </Labels>
    </eo:Slider>    
</asp:Content>


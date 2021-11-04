<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Slider_Basic_Feature_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        This page demonstrates the Slider and RangeSlider control. Try to move
        the thumb and then click "Submit" to get the slider values.
    </p>
    <p>
    EO.Web Slider:
    </p>
    <eo:Slider runat="server" ID="Slider1" 
        DecreaseButton-DisabledImageUrl="00109004" 
        DecreaseButton-DownImageUrl="00109003" DecreaseButton-Height="20" 
        DecreaseButton-HoverImageUrl="00109002" DecreaseButton-ImageUrl="00109001" 
        DecreaseButton-Width="20" IncreaseButton-DisabledImageUrl="00109008" 
        IncreaseButton-DownImageUrl="00109007" IncreaseButton-Height="20" 
        IncreaseButton-HoverImageUrl="00109006" IncreaseButton-ImageUrl="00109005" 
        IncreaseButton-Width="20" LargeTickImage-Height="20" 
        LargeTickImage-ImageUrl="00109026" LargeTickImage-Width="1" 
        LargeTickPosition="Both" SelectedTrack-DisabledImageUrl="00109032" 
        SelectedTrack-DownImageUrl="00109031" SelectedTrack-Height="5" 
        SelectedTrack-HoverImageUrl="00109030" SelectedTrack-ImageUrl="00109029" 
        SmallTickImage-Height="13" SmallTickImage-ImageUrl="00109025" 
        SmallTickImage-Width="1" SmallTickPosition="Both" 
        Thumb-DisabledImageUrl="00109020" Thumb-DownImageUrl="00109019" 
        Thumb-Height="13" Thumb-HoverImageUrl="00109018" Thumb-ImageUrl="00109017" 
        Thumb-Width="9" Track-DisabledImageUrl="00109012" Track-DownImageUrl="00109011" 
        Track-Height="5" Track-HoverImageUrl="00109010" Track-ImageUrl="00109009" 
        Value="0" Width="300px"></eo:Slider>
    <p>
        EO.Web RangeSlider:
    </p>
    <eo:RangeSlider runat="server" ID="RangeSlider1" 
        DecreaseButton-DisabledImageUrl="00109004" 
        DecreaseButton-DownImageUrl="00109003" DecreaseButton-Height="20" 
        DecreaseButton-HoverImageUrl="00109002" DecreaseButton-ImageUrl="00109001" 
        DecreaseButton-Width="20" HighValue="100" 
        IncreaseButton-DisabledImageUrl="00109008" 
        IncreaseButton-DownImageUrl="00109007" IncreaseButton-Height="20" 
        IncreaseButton-HoverImageUrl="00109006" IncreaseButton-ImageUrl="00109005" 
        IncreaseButton-Width="20" LargeTickImage-Height="20" 
        LargeTickImage-ImageUrl="00109026" LargeTickImage-Width="1" 
        LargeTickPosition="Both" LowValue="0" SelectedTrack-DisabledImageUrl="00109032" 
        SelectedTrack-DownImageUrl="00109031" SelectedTrack-Height="5" 
        SelectedTrack-HoverImageUrl="00109030" SelectedTrack-ImageUrl="00109029" 
        SmallTickImage-Height="13" SmallTickImage-ImageUrl="00109025" 
        SmallTickImage-Width="1" SmallTickPosition="Both" 
        Thumb-DisabledImageUrl="00109020" Thumb-DownImageUrl="00109019" 
        Thumb-Height="13" Thumb-HoverImageUrl="00109018" Thumb-ImageUrl="00109017" 
        Thumb-Width="9" Track-DisabledImageUrl="00109012" Track-DownImageUrl="00109011" 
        Track-Height="5" Track-HoverImageUrl="00109010" Track-ImageUrl="00109009" 
        Width="300px"></eo:RangeSlider>        
    <p>
        Click the following button to submit the page and get the values.
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
    </p>
    <p>
        <asp:Label runat="server" ID="lblResult"></asp:Label>
    </p>
</asp:Content>


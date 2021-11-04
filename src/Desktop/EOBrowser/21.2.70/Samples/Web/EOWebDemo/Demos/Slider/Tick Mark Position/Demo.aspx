<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Slider_Tick_Mark_Position_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        EO.Web Slider and RangeSlider can display "large tick marks" or "small tick marks"
        on either or both side of the track bar. The following sample demonstrates
        this feature. See <a href="http://www.essentialobjects.com/doc/1/slider/tickmark.aspx" target="_blank">here</a>
        for more information about tick marks.
    </p>
    <table>
        <tr>
            <td>Big Tick Mark Position:</td>
            <td>
                <asp:DropDownList runat="server" ID="cbLargeTMPos">
                    <asp:ListItem Value="None"></asp:ListItem>
                    <asp:ListItem Value="TopLeft"></asp:ListItem>
                    <asp:ListItem Value="RightBottom"></asp:ListItem>
                    <asp:ListItem Value="Both"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Small Tick Mark Position:</td>
            <td>
                <asp:DropDownList runat="server" ID="cbSmallTMPos">
                    <asp:ListItem Value="None"></asp:ListItem>
                    <asp:ListItem Value="TopLeft"></asp:ListItem>
                    <asp:ListItem Value="RightBottom"></asp:ListItem>
                    <asp:ListItem Value="Both"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <eo:Slider runat="server" ID="Slider1" 
                    DecreaseButton-DisabledImageUrl="00109004" 
                    DecreaseButton-DownImageUrl="00109003" DecreaseButton-Height="20" 
                    DecreaseButton-HoverImageUrl="00109002" DecreaseButton-ImageUrl="00109001" 
                    DecreaseButton-Width="20" IncreaseButton-DisabledImageUrl="00109008" 
                    IncreaseButton-DownImageUrl="00109007" IncreaseButton-Height="20" 
                    IncreaseButton-HoverImageUrl="00109006" IncreaseButton-ImageUrl="00109005" 
                    IncreaseButton-Width="20" LargeTickImage-Height="20" 
                    LargeTickImage-ImageUrl="00109026" LargeTickImage-Width="1" 
                    LargeTickPosition="None" SelectedTrack-DisabledImageUrl="00109032" 
                    SelectedTrack-DownImageUrl="00109031" SelectedTrack-Height="5" 
                    SelectedTrack-HoverImageUrl="00109030" SelectedTrack-ImageUrl="00109029" 
                    SmallTickImage-Height="13" SmallTickImage-ImageUrl="00109025" 
                    SmallTickImage-Width="1" SmallTickPosition="None" 
                    Thumb-DisabledImageUrl="00109020" Thumb-DownImageUrl="00109019" 
                    Thumb-Height="13" Thumb-HoverImageUrl="00109018" Thumb-ImageUrl="00109017" 
                    Thumb-Width="9" Track-DisabledImageUrl="00109012" Track-DownImageUrl="00109011" 
                    Track-Height="5" Track-HoverImageUrl="00109010" Track-ImageUrl="00109009" 
                    Value="0" Width="300px">
                </eo:Slider>
            </td>
        </tr>
    </table>
    <p>
        <asp:Button runat="server" ID="Button1" Text="Update" onclick="Button1_Click" />
    </p>
</asp:Content>


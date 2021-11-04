<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Rating_Designs_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        EO.Web Rating offers a number of built-in designs for you to use out of box. You
        can also customize the built-in designs or implement your own designs to fit your
        need. See <a href="http://www.essentialobjects.com/doc/1/rating/customize.aspx" target="_blank">
            here</a> for more details about how to customize the Rating control.
    </p>
    <table cellpadding="5">
        <tr>
            <td>
                Style 1:
            </td>
            <td>
                <eo:Rating runat="server" ID="Rating1" ControlSkinID="None" EmptyStarHoverImageUrl="00108004"
                    EmptyStarImageUrl="00108002" FullStarHoverImageUrl="00108003" FullStarImageUrl="00108001"
                    Value="3">
                </eo:Rating>
            </td>
        </tr>
        <tr>
            <td>
                Style 2:
            </td>
            <td>
                <eo:Rating runat="server" ID="Rating2" ControlSkinID="None" EmptyStarHoverImageUrl="00108008"
                    EmptyStarImageUrl="00108006" FullStarHoverImageUrl="00108007" FullStarImageUrl="00108005"
                    Value="3">
                </eo:Rating>
            </td>
        </tr>
        <tr>
            <td>
                Style 3:
            </td>
            <td>
                <eo:Rating runat="server" ID="Rating3" ControlSkinID="None" EmptyStarHoverImageUrl="00108012"
                    EmptyStarImageUrl="00108010" FullStarHoverImageUrl="00108011" FullStarImageUrl="00108009"
                    Value="3">
                </eo:Rating>
            </td>
        </tr>
        <tr>
            <td>
                Style 4:
            </td>
            <td>
                <eo:Rating runat="server" ID="Rating4" ControlSkinID="None" EmptyStarHoverImageUrl="00108016"
                    EmptyStarImageUrl="00108014" FullStarHoverImageUrl="00108015" FullStarImageUrl="00108013"
                    Value="3">
                </eo:Rating>
            </td>
        </tr>
        <tr>
            <td>
                Style 5:
            </td>
            <td>
                <eo:Rating runat="server" ID="Rating5" ControlSkinID="None" EmptyStarHoverImageUrl="00108020"
                    EmptyStarImageUrl="00108018" FullStarHoverImageUrl="00108019" FullStarImageUrl="00108017"
                    Value="3">
                </eo:Rating>
            </td>
        </tr>
        <tr>
            <td>
                Style 6:
            </td>
            <td>
                <eo:Rating runat="server" ID="Rating6" ControlSkinID="None" EmptyStarImageUrl="00108022"
                    FullStarHoverImageUrl="00108023" FullStarImageUrl="00108021" StarHeight="18"
                    StarWidth="18" Value="3">
                </eo:Rating>
            </td>
        </tr>
    </table>
</asp:Content>

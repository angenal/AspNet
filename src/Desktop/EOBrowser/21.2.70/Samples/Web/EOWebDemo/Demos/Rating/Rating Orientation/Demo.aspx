<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Rating_Rating_Orientation_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        An EO.Web Rating control can be horizontal or vertical. For both orientations
        it can also be reversed. The following sample demonstrates these features. The 
        first Rating control's <b>Orientation</b> is set <b>Vertical</b>. The second 
        Rating control also has its <b>Reversed</b> set to <b>true</b>.
    </p>
    <table width="400px">
        <tr>
            <td width="50%" align="center">
                <p style="white-space:nowrap">
                    Orientation=Vertical
                </p>
            </td>
            <td width="50%" align="center">
                <p style="white-space:nowrap">
                    Orientation=Vertical<br />
                    Reverse=True
                </p>
            </td>
        </tr>
        <tr>
            <td align="center">
                <eo:Rating runat="server" ID="Rating1" ControlSkinID="None" EmptyStarHoverImageUrl="00108004"
                    EmptyStarImageUrl="00108002" FullStarHoverImageUrl="00108003" FullStarImageUrl="00108001"
                    Orientation="Vertical" Value="3">
                </eo:Rating>
            </td>
            <td align="center">
                <eo:Rating runat="server" ID="Rating2" ControlSkinID="None" EmptyStarHoverImageUrl="00108004"
                    EmptyStarImageUrl="00108002" FullStarHoverImageUrl="00108003" FullStarImageUrl="00108001"
                    Orientation="Vertical" Reverse="true" Value="3">
                </eo:Rating>
            </td>
        </tr>
    </table>
</asp:Content>


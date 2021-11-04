<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Rating_Selection_Precision_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        EO.Web Rating control supports three different precision modes:
        Whole, Half, and Exact. When <b>Precision</b> is set to <b>Whole</b>,
        only whole numbers are allowed; When <b>Precision</b> is set to <b>Half</b>,
        only whole and half numbers are allowed; When <b>Precision</b> is set
        to <b>Exact</b>, any number is allowed.
    </p>
    <p>
        For example, when <b>MaxStarCount</b> is set to 5 and <b>Precision</b>
        is set to <b>Half</b>, it is possible for user to select "3 and a half stars".
        The default value is <b>Whole</b>, which mean user can only select full
        stars.
    </p>
    <table>
        <tr>
            <td>Precision Mode:</td>
            <td>
                <asp:DropDownList runat="server" ID="cbPrecision" AutoPostBack="True" 
                    onselectedindexchanged="cbPrecision_SelectedIndexChanged">
                    <asp:ListItem Text="Whole"></asp:ListItem>
                    <asp:ListItem Text="Half"></asp:ListItem>
                    <asp:ListItem Text="Exact"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Rating:</td>
            <td>
                <eo:Rating runat="server" ID="Rating1" ControlSkinID="None" EmptyStarHoverImageUrl="00108004"
                    EmptyStarImageUrl="00108002" FullStarHoverImageUrl="00108003" FullStarImageUrl="00108001"
                    Value="3">
                </eo:Rating>
            </td>
        </tr>
    </table>
    <p>
        <asp:Button runat="server" ID="btnGetValue" Text="Get Value" 
            onclick="btnGetValue_Click" />
    </p>
    <p>
        <asp:Label runat="server" ID="lblValue"></asp:Label>
    </p>
</asp:Content>


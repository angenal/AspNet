<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ImageZoom_Features_Positioning_Mode_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:CallbackPanel runat="server" id="CallbackPanel1" Triggers="{ControlID:rbX;Parameter:},{ControlID:rbY;Parameter:}">
    <P>By default EO.Web ImageZoom displays the big image at the center of the browser 
        window. You can customize this behavior by setting the ImageZoom's <B>PositionX</B>
        and/or <B>PositionY</B> property.
    </P>
    <P>X Position:
        <asp:RadioButtonList id="rbX" Runat="server" 
        RepeatDirection="Horizontal" Width="400px" 
        OnSelectedIndexChanged="rbX_SelectedIndexChanged">
            <asp:ListItem Value="Screen Center" Selected="True">Screen Center</asp:ListItem>
            <asp:ListItem Value="Image Center">Image Center</asp:ListItem>
            <asp:ListItem Value="Relative">Relative</asp:ListItem>
        </asp:RadioButtonList></P>
    <P>Y Position:
        <asp:RadioButtonList id="rbY" Runat="server" RepeatDirection="Horizontal" Width="400px"
         OnSelectedIndexChanged="rbY_SelectedIndexChanged">
            <asp:ListItem Value="Screen Center" Selected="True">Screen Center</asp:ListItem>
            <asp:ListItem Value="Image Center">Image Center</asp:ListItem>
            <asp:ListItem Value="Relative">Relative</asp:ListItem>
        </asp:RadioButtonList></P>
    <p>
    Note: When the positioning mode is set to <b>Relative</b>, you can also
    use the ImageZoom's <b>OffsetX</b> or <b>OffsetY</b> property to specify
    the pixel offset between the big image and small image (not demonstrated by
    this sample).
    </p>
    <p>
        Choose a positioning mode and then click the image to see it in action.
    </p>
    <P>
        <eo:ImageZoom id="ImageZoom1" Description="Palm Tree on the Beach" BigImageUrl="../../Images/palm_tree.jpg"
            SmallImageUrl="../../Images/palm_tree_small.jpg" runat="server" LoadingPanelID="loading">
            <ZoomPanelStyle CssText="background-color:#ffffff;border:solid #d0d0d0 1px;padding:5px;"></ZoomPanelStyle>
        </eo:ImageZoom></P>
    <div id="loading" style="display:none; border: solid 1px black; background-color:White; padding: 6px 20px 6px 20px">Loading...</div>
</eo:CallbackPanel>
</asp:Content>


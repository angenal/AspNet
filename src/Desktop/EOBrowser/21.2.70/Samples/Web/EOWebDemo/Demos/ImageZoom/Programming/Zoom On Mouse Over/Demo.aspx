<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ImageZoom_Programming_Zoom_On_Mouse_Over_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    Note: this sample is based on the <a href="javascript:GoToDemo('imagezoom_grid')">ImageZoom 
        with DataGrid</a> sample. Please go over that sample first.
</p>
<p>
    This sample demonstrates how to triger the&nbsp;ImageZoom on mouse move using 
    the ImageZoom control's client side JavaScript API.
</p>
<asp:DataGrid id="DataGrid1" BorderColor="Gainsboro" BorderWidth="1px" Runat="server" Width="450px"
    CellPadding="2" AutoGenerateColumns="False">
    <HeaderStyle CssClass="grid_header"></HeaderStyle>
    <Columns>
        <asp:BoundColumn DataField="Desc" HeaderText="Description"></asp:BoundColumn>
        <asp:TemplateColumn HeaderText="Image">
            <ItemTemplate>
                <div onmouseover='eo_GetObject("<%#Container.FindControl("ImageZoom1").ClientID%>").zoomIn();' style="width:120px;">
                    <eo:ImageZoom runat="server" id="ImageZoom1" SmallImageUrl='<%#DataBinder.Eval(Container.DataItem, "SmallImage")%>' BigImageUrl='<%#DataBinder.Eval(Container.DataItem, "BigImage")%>' Description='<%#DataBinder.Eval(Container.DataItem, "Desc")%>' 
 PositionX="Relative" OffsetX="100" PositionY="ImageCenter" LoadingPanelID="loading">
                        <ZoomPanelStyle CssText="background-color:#ffffff;border:solid #d0d0d0 1px;padding:5px;"></ZoomPanelStyle>
                    </eo:ImageZoom>
                </div>
            </ItemTemplate>
        </asp:TemplateColumn>
    </Columns>
</asp:DataGrid>
<div id="loading" style="display:none; border: solid 1px black; background-color:White; padding: 6px 20px 6px 20px">Loading...</div>
</asp:Content>


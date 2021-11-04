<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Programming_Client_Side_Programming_Context_Menu_with_DataGrid_Demo" Title="Untitled Page" %>
<%@ Import namespace="System.Data.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
//This function gets two parameters:
//1. e: This is the DOM event object for browsers other than IE
//      for IE it is null
//2. recId: This is the value of the ID field in our data source.
//      This value was filled during data binding.
function ShowContextMenu(e, recId)
{
    //Get the link that was clicked
    var link = document.getElementById("row_" + recId);
    
    //Get the containing row from this link so that
    //we can get contents from other cells to populate
    //our context menu
    var ele = link;
    while (ele && (ele.nodeType == 1) && (ele.tagName.toLowerCase() != "tr"))
        ele = ele.parentNode;
        
    //Found the containing row. Get the cell contents now
    var tr = ele;
    var maker = tr.cells[0].innerHTML;
    var model = tr.cells[1].innerHTML;
    var style = tr.cells[2].innerHTML;
    
    //Modify our menu using these information
    var menu = eo_GetObject("<%=Menu1.ClientID%>");
    var topGroup = menu.getTopGroup();
    topGroup.getItemByIndex(0).setText("See other cars from " + maker);
    topGroup.getItemByIndex(1).setText("See all styles for " + model); 
    topGroup.getItemByIndex(2).setText("Details on this '" + maker + " " + model + " " + style + "'");
    
    //Show the context menu
    eo_ShowContextMenu(e, "<%=Menu1.ClientID%>");
}
//<!--JS_SAMPLE_END-->
</script>
<p>
    This sample demonstrates using <span class="highlight">ContextMenu</span> with <span class="highlight">
        DataGrid</span>.
</p>
<asp:DataGrid id="DataGrid1" runat="server" BorderColor="Gainsboro" BorderWidth="1px" AllowSorting="True"
    AutoGenerateColumns="False" CellPadding="2" Width="500px">
    <Columns>
        <asp:BoundColumn DataField="Maker" HeaderText="Maker"></asp:BoundColumn>
        <asp:BoundColumn DataField="Model" HeaderText="Model"></asp:BoundColumn>
        <asp:BoundColumn DataField="Style" HeaderText="Style"></asp:BoundColumn>
        <asp:TemplateColumn HeaderText="Options">
            <ItemTemplate>
                <a href="javascript:void(0);" onclick='javascript:ShowContextMenu(event, <%#/*CSTOVB*/((DbDataRecord)Container.DataItem)["ID"]/*CSTOVB:CType(Container.DataItem, DbDataRecord).Item("ID")*/%>);' 
                id='row_<%#/*CSTOVB*/((DbDataRecord)Container.DataItem)["ID"]/*CSTOVB:CType(Container.DataItem, DbDataRecord).Item("ID")*/%>'>
                    Click for Options</a>
            </ItemTemplate>
        </asp:TemplateColumn>
    </Columns>
</asp:DataGrid>
<eo:ContextMenu ControlSkinID="None" runat="server" Width="144px" id="Menu1" ContextControlID="context_menu_div">
    <TopGroup Style-CssText="cursor:hand;font-family:Verdana;font-size:11px;">
        <Items>
            <eo:MenuItem Text-Html="See other cars from Maker"></eo:MenuItem>
            <eo:MenuItem Text-Html="See all styles for Model"></eo:MenuItem>
            <eo:MenuItem Text-Html="See details on this car"></eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="background-color:#E0E0E0;height:1px;width:1px;"></eo:MenuItem>
        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_Default"
            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                CollapseEffect-Type="GlideTopToBottom" OffsetX="3" ShadowDepth="0" OffsetY="-4" ItemSpacing="5"></SubMenu>
        </eo:MenuItem>
    </LookItems>
</eo:ContextMenu>
</asp:Content>


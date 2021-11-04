<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Import namespace="System.Data" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Programming_Data_Binding_Using_Item_Template_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>This sample demonstrates how to use an item template while populating the Menu 
    from a data source.
</p>
<h4>The Data</h4>
<p><asp:datagrid id="DataGrid1" BorderColor="gainsboro" BorderWidth="1" Runat="server" Width="450px"
        CellPadding="2">
        <HeaderStyle CssClass="grid_header"></HeaderStyle>
    </asp:datagrid></p>
<h4>The Result</h4>
<p>
    <!--ASPX_SAMPLE_BLOCK:2:24-->
    <eo:Menu runat="server" id="Menu1" Width="300px" ControlSkinID="None" TargetWindow="_blank">
        <TopGroup Style-CssText="background-image:url(00020005);border-left-color:#e0e0e0;border-left-style:solid;border-left-width:1px;border-right-color:#e0e0e0;border-right-style:solid;border-right-width:1px;border-top-color:#e0e0e0;border-top-style:solid;border-top-width:1px;cursor:hand;font-family:Verdana;font-size:11px;padding-bottom:2px;padding-left:10px;padding-right:10px;padding-top:2px;">
            <TemplateItem>
                <CustomItem>
                    <asp:CheckBox CssClass="normal" Runat="server" Text='<%#/*CSTOVB*/((DataRowView)Container.DataItem)["Country"]/*CSTOVB:CType(Container.DataItem, DataRowView).Item("Country")*/%>' style="white-space:nowrap" ID="Checkbox1">
                    </asp:CheckBox>
                </CustomItem>
                <SubMenu>
                    <TemplateItem>
                        <CustomItem>
                            <asp:CheckBox CssClass="normal" Runat="server" Text='<%#/*CSTOVB*/((DataRowView)Container.DataItem)["State"]/*CSTOVB:CType(Container.DataItem, DataRowView).Item("State")*/%>' style="white-space:nowrap" ID="Checkbox2">
                            </asp:CheckBox>
                        </CustomItem>
                        <SubMenu>
                            <TemplateItem>
                                <CustomItem>
                                    <asp:CheckBox CssClass="normal" Runat="server" Text='<%#/*CSTOVB*/((DataRowView)Container.DataItem)["City"]/*CSTOVB:CType(Container.DataItem, DataRowView).Item("City")*/%>' style="white-space:nowrap" ID="Checkbox3">
                                    </asp:CheckBox>
                                </CustomItem>
                            </TemplateItem>
                        </SubMenu>
                    </TemplateItem>
                </SubMenu>
            </TemplateItem>
        </TopGroup>
        <LookItems>
            <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_TopLevelItem"
                NormalStyle-CssText="padding-left:5px;padding-right:5px;">
                <SubMenu Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                    OffsetX="-3" ShadowDepth="0" OffsetY="3" ItemSpacing="5"></SubMenu>
            </eo:MenuItem>
            <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="width: 1px; height: 1px; background-color: #cb3e00"></eo:MenuItem>
            <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_Default"
                NormalStyle-CssText="padding-left:5px;padding-right:5px;">
                <SubMenu Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #606060; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                    OffsetX="0" ShadowDepth="0" OffsetY="0" ItemSpacing="5"></SubMenu>
            </eo:MenuItem>
        </LookItems>
    </eo:Menu></p>
</asp:Content>


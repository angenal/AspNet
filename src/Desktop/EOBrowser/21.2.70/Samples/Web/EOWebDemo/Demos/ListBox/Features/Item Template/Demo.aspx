<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ListBox_Features_Item_Template_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
    Use <b>ItemTemplate</b> to customize the format of each item. The
    following ListBox is populated from database. Its <b>ItemTemplate</b>
    contains a table with data binding expressions that display
    several fields from the data source.
    </p>
    <eo:ListBox runat="server" ID="ListBox1" ControlSkinID="None" Height="200px" 
        Width="350px">
        <BodyStyle CssText="border: solid 1px #c6c7d2;" />
        <DisabledItemStyle CssText="background-color:white; color: #c0c0c0; padding: 2px;" />
        <ItemStyle CssText="padding: 2px; background-color:white; color: black;" />
        <ListBoxStyle CssText="font-family:Tahoma; font-size:11px;" />
        <MoreItemsMessageStyle CssText="padding:2px;" />
        <SelectedItemStyle CssText="padding: 2px; background-color:#3399ff; color:white;" />
        <ItemTemplate>
            <table border="0" cellpadding="1" width="325px">
                <tr>
                    <td align="left">
                        <b><%#Eval("PostedBy")%></b>        
                    </td>
                    <td align="right">
                        <%#Eval("PostedAt", "{0:g}")%>      
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="border-bottom: solid 1px #c0c0c0;">
                        <%#Eval("Topic")%>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </eo:ListBox>
</asp:Content>


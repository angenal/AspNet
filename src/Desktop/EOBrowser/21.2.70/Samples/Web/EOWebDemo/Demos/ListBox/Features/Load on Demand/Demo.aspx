<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ListBox_Features_Load_on_Demand_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        This sample demonstrates how to use load on demand feature. To enable
        load on demand feature, you must:
    </p>
    <ul>
        <li>Set <b>TotalItemCount</b> to a positive number;</li>
        <li>Handle <b>MoreItemsNeeded</b> event;</li>
    </ul>
    <p>
        The following sample sets <b>TotalItemCount</b> to the total number
        of available items in the DB, but only loads the first 10 items initially.
        It triggers <b>MoreItemsNeeded</b> event to fetch more items from the
        server as user scrolls to the bottom.
    </p>
    <eo:ListBox runat="server" ID="ListBox1" ControlSkinID="None" Height="200px" 
        Width="350px" onmoreitemsneeded="ListBox1_MoreItemsNeeded"
        DataValueField="TopicID">
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
                        #<%#(Container.Item.ItemIndex + 1).ToString()%>
                        &nbsp;-&nbsp;
                        <%#Eval("Topic")%>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </eo:ListBox>
</asp:Content>


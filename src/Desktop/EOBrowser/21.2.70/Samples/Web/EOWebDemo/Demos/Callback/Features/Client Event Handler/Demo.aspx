<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Callback_Features_Client_Event_Handler_Demo"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">

    <script type="text/javascript">

//This function is called before every callback. We ask
//the user to confirm the action and returns false to cancel
//the callback if user choose "Cancel".
//This function only demonstrates the "BeforeExecute" handler,
//there are also "AfterExecute" and "AfterUpdate" handler
//that are called at different stages of the callback process.
function before_execute(callback)
{
    //Figure out which command it is
    var command;
    var evtTarget = callback.getEventTarget();
    if (evtTarget.indexOf("btnEdit") >= 0)
        command = "edit";
    else if (evtTarget.indexOf("btnUpdate") >= 0)
        command = "update";
    else
        command = "cancel";

    //Confirm the command
    return window.confirm("Are you sure you want to " + command + "?");
}
    </script>

    <p>
        This sample demonstrates how to use client side event handler to further control
        the callback process.
    </p>
    <eo:CallbackPanel runat="server" ID="CallbackPanel1" Triggers="{ControlID:DataGrid1;Parameter:}"
        AutoDisableContent="True" ClientSideBeforeExecute="before_execute">
        <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" BorderWidth="1"
            BorderColor="gainsboro" OnEditCommand="DataGrid1_EditCommand" OnCancelCommand="DataGrid1_CancelCommand"
            OnUpdateCommand="DataGrid1_UpdateCommand">
            <Columns>
                <asp:BoundColumn DataField="ItemID" ReadOnly="True" HeaderText="Item ID">
                    <HeaderStyle Width="80px"></HeaderStyle>
                </asp:BoundColumn>
                <asp:TemplateColumn HeaderText="Item Description">
                    <HeaderStyle Width="200px"></HeaderStyle>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ItemDescription") %>'
                            ID="Label1">
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtDesc" Text='<%# DataBinder.Eval(Container, "DataItem.ItemDescription") %>'
                            Style="width: 180px">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <HeaderStyle Width="120px"></HeaderStyle>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" Text="Edit" CommandName="Edit" ID="btnEdit" CausesValidation="false"></asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton runat="server" Text="Update" CommandName="Update" ID="btnUpdate"></asp:LinkButton>&nbsp;
                        <asp:LinkButton runat="server" Text="Cancel" CommandName="Cancel" ID="btnCancel"
                            CausesValidation="false"></asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateColumn>
            </Columns>
        </asp:DataGrid>
    </eo:CallbackPanel>
</asp:Content>

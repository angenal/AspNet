<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Spell_Checker_Features_Context_Menu_Based_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
This sample demonstrates how to use the SpellChecker to check
a DataGrid and how to pass all the changes back to the server
side.
</p>
<script type="text/javascript">
    var changedCells = new Array();

    function on_correct_error(spellChecker, element, oldText, newText) 
    {
        var e = element;
        while (e) 
        {
            if (e.tagName == "TD")
            {
                //Save changed cell
                changedCells[changedCells.length] = e;

                //Display "Save" button
                document.getElementById("<%=btnSave.ClientID%>").style.display = "";
                
                break;
            }
        
            e = e.parentNode;    
        }
    }

    function save_changes()
    {
        var data = new Array();
        var scriptEvent = eo_GetObject("<%=ScriptEvent1.ClientID%>");
        var table = document.getElementById("<%=DataGrid1.ClientID%>");

        //Collect information from all saved cells
        for (var i = 0; i < changedCells.length; i++)
        {
            var changedCell = changedCells[i];

            //Get the row and cell index
            var cellIndex = changedCell.cellIndex;
            var rowIndex = changedCell.parentNode.rowIndex;

            //Get the new text
            var newText = changedCell.innerText;
            if (newText == null)
                newText = changedCell.textContent;

            data[data.length] = [rowIndex, cellIndex, newText];
        }

        //Post back with the change data. This triggers
        //the ScriptEvent control's Command event
        scriptEvent.trigger("Save", data);
    }
</script>
<asp:DataGrid id="DataGrid1" BorderColor="Gainsboro" BorderWidth="1px" Runat="server" Width="450px"
    CellPadding="2" AutoGenerateColumns="False">
    <HeaderStyle CssClass="grid_header"></HeaderStyle>
    <Columns>
        <asp:BoundColumn DataField="Model" HeaderText="Model"></asp:BoundColumn>
        <asp:BoundColumn DataField="Description" HeaderText="Description"></asp:BoundColumn>
    </Columns>
</asp:DataGrid>
<eo:SpellChecker id="SpellChecker1" runat="server" DialogID="SpellCheckerDialog1" ControlToCheck="DataGrid1"
    StartButton="Button1" ContextMenuID="ContextMenu1" ClientSideOnCorrectError="on_correct_error"></eo:SpellChecker>
<p runat="server" id="panCheck">
    <asp:Button Runat="server" id="Button1" Text="Spell Check"></asp:Button>&nbsp;&nbsp;
    <input runat="server" id="btnSave" style="display:none" type="button" value="Save" onclick="save_changes()" />
</p>
<div runat="server" id="panResult" visible="false">
</div>
<eo:ContextMenu runat="server" id="ContextMenu1" Width="100px" ControlSkinID="None">
    <LookItems>
        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_TopLevelItem"
            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
            <SubMenu Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #5f7786; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                OffsetX="-3" ShadowDepth="0" OffsetY="3" ItemSpacing="5"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="width: 1px; height: 1px; background-color:#e0e0e0;"></eo:MenuItem>
        <eo:MenuItem HoverStyle-CssText="color:#F7B00A;padding-left:5px;padding-right:5px;" ItemID="_Default"
            NormalStyle-CssText="padding-left:5px;padding-right:5px;">
            <SubMenu Style-CssText="border-right: #e0e0e0 1px solid; padding-right: 3px; border-top: #e0e0e0 1px solid; padding-left: 3px; font-size: 12px; padding-bottom: 3px; border-left: #e0e0e0 1px solid; cursor: hand; color: #5f7786; padding-top: 3px; border-bottom: #e0e0e0 1px solid; font-family: arial; background-color: #f7f8f9"
                OffsetX="3" ShadowDepth="0" OffsetY="-4" ItemSpacing="5"></SubMenu>
        </eo:MenuItem>
    </LookItems>
</eo:ContextMenu>
<eo:ScriptEvent runat="server" ID="ScriptEvent1" OnCommand="ScriptEvent1_Command"></eo:ScriptEvent>
</asp:Content>



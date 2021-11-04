<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Splitter_Features_Persisting_Splitter_and_Scroll_Position_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web Splitter automatically persists splitter position across postbacks. It 
    can also perist splitter pane scroll position if <b>PersistScrollPosition</b> is 
    set to <b>True</b> on the <b>SplitterPane</b> object.
</p>
<p>
    The following example demonstrates this feature. Click "Submit" to post back 
    the page. Notice both splitter position and splitter pane scroll positions are 
    persisted across postbacks.
</p>
<eo:CallbackPanel runat="server" id="CallbackPanel1" Triggers="{ControlID:Button1;Parameter:}">
    <eo:Splitter id="Splitter1" runat="server" Width="300px" Height="200px" BorderStyle="Solid" DividerSize="10"
        BorderWidth="1px" BorderColor="#B5B5B5" ControlSkinID="None" DividerImage="00080411" DividerCenterImage="00080412">
        <eo:SplitterPane id="SplitterPane1" runat="server" Width="100px" PersistScrollPosition="True">
            <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; WIDTH: 300px; PADDING-TOP: 5px; HEIGHT: 300px">Left 
                Pane Contents
            </DIV>
        </eo:SplitterPane>
        <eo:SplitterPane id="SplitterPane2" runat="server" PersistScrollPosition="True">
            <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; WIDTH: 300px; PADDING-TOP: 5px; HEIGHT: 300px">Right 
                Pane Contents</DIV>
        </eo:SplitterPane>
    </eo:Splitter>
    <p>
    <asp:Panel id="Panel1" runat="server" Visible="False">The page has been posted back. Note the splitter 
retained its scroll positions.</asp:Panel>
    </p>
    <asp:Button id="Button1" runat="server" Text="Post Back Now!" OnClick="Button1_Click"></asp:Button>
    <P></P>
</eo:CallbackPanel>
</asp:Content>


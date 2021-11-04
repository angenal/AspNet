<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Splitter_Features_Auto_Resize_Contents_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
function OnSplitterResized(splitter)
{
    //Get the left pane's client size
    var w = splitter.getLeftPane().getWidth();
    var h = splitter.getLeftPane().getHeight();

    //Resize the text box
    var button = document.getElementById("<%=btnSearch.ClientID%>");
    var textBox = document.getElementById("<%=txtKeyword.ClientID%>");
    var textBoxWidth = w - button.offsetWidth - 20;
    if (textBoxWidth < 50)
        textBoxWidth = 50;
    textBox.style.width = textBoxWidth.toString() + "px";
    
    //Resize the TreeView
    var treeView = eo_GetObject("TreeView1");
    treeView.setSize(w - 16, h - 46);
}
//<!--JS_SAMPLE_END-->
</script>
<p>
Very often the contents of the splitter pane, especially that of the left pane, 
are required to automatically resize to fill the entire pane. EO.Web Splitter 
does not resize the contents for you, but it offers all the necessary 
information for you to resize them by yourself.
<p>
<p>In order to resize the contents, you should handle <b>ClientSideOnResized</b>, 
    inside the event handler you can query the new size of the splitter pane and 
    adjust the size of your contents accordingly.
</p>
<p>The following sample automatically adjust the size of the&nbsp;contents in the 
    left pane. Please switch to <b>JavaScript</b> tab for the source code.
</p>
<eo:splitter id="Splitter1" DividerImage="00080101" ControlSkinID="None" BorderColor="#A0A0A0"
    BorderWidth="1px" DividerSize="8" BorderStyle="Solid" Height="250px" Width="500px" runat="server"
    CollapseButtonImage="00080102" ExpandButtonHoverImage="00080105" ExpandButtonImage="00080104"
    CollapseButtonHoverImage="00080103" ClientSideOnResized="OnSplitterResized">
    <eo:SplitterPane id="SplitterPane1" Width="200px" runat="server" MinWidth="100" ScrollBars="None">
        <TABLE cellSpacing="2" cellPadding="2" border="0">
            <TR>
                <TD>
                    <asp:TextBox id="txtKeyword" Runat="server"></asp:TextBox></TD>
                <TD>
                    <asp:Button id="btnSearch" Runat="server" Text="Search"></asp:Button></TD>
            </TR>
            <TR>
                <TD colSpan="2">
                    <eo:TreeView id="TreeView1" ControlSkinID="None" Height="250px" Width="200px" runat="server"
                        AutoSelectSource="ItemClick">
                        <LookNodes>
                            <eo:TreeNode ImageUrl="00030203" DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;color:Gray;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
                                CollapsedImageUrl="00030201" ItemID="_Default" NormalStyle-CssText="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; COLOR: black; BORDER-TOP-STYLE: none; PADDING-TOP: 1px; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none"
                                ExpandedImageUrl="00030202" SelectedStyle-CssText="background-color:#316ac5;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:White;padding-bottom:0px;padding-left:0px;padding-right:0px;padding-top:0px;"></eo:TreeNode>
                        </LookNodes>
                        <TopGroup Style-CssText="border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:black;cursor:hand;font-family:Tahoma;font-size:8pt;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;">
                            <Nodes>
                                <eo:TreeNode Text="Welcome to MSDN Library">
                                    <SubGroup>
                                        <Nodes>
                                            <eo:TreeNode Text="How to Use the MSDN Library Table of Contents"></eo:TreeNode>
                                        </Nodes>
                                    </SubGroup>
                                </eo:TreeNode>
                                <eo:TreeNode Text="Development Tools and Languages">
                                    <SubGroup>
                                        <Nodes>
                                            <eo:TreeNode Text="Visual Studio 2005"></eo:TreeNode>
                                            <eo:TreeNode Text="Visual Studio.NET"></eo:TreeNode>
                                            <eo:TreeNode Text=".NET Framework SDK"></eo:TreeNode>
                                        </Nodes>
                                    </SubGroup>
                                </eo:TreeNode>
                                <eo:TreeNode Text=".NET Development">
                                    <SubGroup>
                                        <Nodes>
                                            <eo:TreeNode Text=".NET Framework Class Library"></eo:TreeNode>
                                            <eo:TreeNode Text=".NET Framework SDK"></eo:TreeNode>
                                            <eo:TreeNode Text="Articles and Overviews"></eo:TreeNode>
                                        </Nodes>
                                    </SubGroup>
                                </eo:TreeNode>
                                <eo:TreeNode Text="Web Development"></eo:TreeNode>
                                <eo:TreeNode Text="Win32 and COM Development"></eo:TreeNode>
                                <eo:TreeNode Text="MSDN Library Archive"></eo:TreeNode>
                            </Nodes>
                        </TopGroup>
                    </eo:TreeView></TD>
            </TR>
        </TABLE>
    </eo:SplitterPane>
    <eo:SplitterPane id="SplitterPane2" runat="server">
        <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">Right 
            Pane Contents</DIV>
    </eo:SplitterPane>
</eo:splitter>
</asp:Content>


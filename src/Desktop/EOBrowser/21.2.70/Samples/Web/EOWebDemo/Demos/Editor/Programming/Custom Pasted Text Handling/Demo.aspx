<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Editor_Programming_Custom_Pasted_Text_Handling_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
//This function handles our custom toolbar button event 
function toolbar_click_handler(toolBar, toolBarItem, subMenu)
{
    if (toolBarItem.getCommandName() == "PasteComment")
    {
        //Get the editor object
        var editor = eo_GetObject("Editor1");
    
        editor.execCommand(
            "Paste",            //Command
            "TextOnly",            //See EditorPasteFilter
            "PasteComment"        //Additional argument
            );
    }
}

//The editor's ClientSideOnPaste is set to the name 
//of this function in order for it to be called when the 
//editor is about to paste text
function editor_paste_handler(editor, text, arg)
{
    if (arg == "PasteComment")    //Handle our special case
        return "<div style=\"border: 1px solid black; background-color:#ffffcc\"><strong>Comment</strong>: " + text + "</div>";
}
//<!--JS_SAMPLE_END-->
</script>
<eo:Dialog runat="server" id="FileExplorerDialog1" Width="320px" Height="216px" ControlSkinID="None"
    HeaderHtml="Dialog Title" CloseButtonUrl="00020440" AllowResize="True" HeaderHtmlFormat='<div style="padding-top:4px">{0}</div>'
    HeaderImageUrl="00020441" HeaderImageHeight="27" MinWidth="150" MinHeight="100" AcceptButton="OK"
    CancelButton="Cancel">
    <ContentTemplate>
        <eo:FileExplorerHolder runat="server" id="Explorer1" Width="710px" Height="350px"></eo:FileExplorerHolder>
        <div style="padding: 10px; text-align:right;">
            <asp:Button Runat="server" ID="OK" Text="OK" style="width:80px"></asp:Button>
            <asp:Button Runat="server" ID="Cancel" Text="Cancel" style="width:80px"></asp:Button>
        </div>
    </ContentTemplate>
    <FooterStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 8pt; padding-bottom: 4px; padding-top: 4px; font-family: tahoma"></FooterStyleActive>
    <HeaderStyleActive CssText="background-image:url(00020442);color:#444444;font-family:'trebuchet ms';font-size:10pt;font-weight:bold;padding-bottom:7px;padding-left:8px;padding-right:0px;padding-top:0px;"></HeaderStyleActive>
    <ContentStyleActive CssText="background-color:#f0f0f0;font-family:tahoma;font-size:8pt;padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px"></ContentStyleActive>
    <BorderImages BottomBorder="00020409,00020429" RightBorder="00020407,00020427" TopRightCornerBottom="00020405,00020425"
        TopRightCorner="00020403,00020423" LeftBorder="00020406,00020426" TopLeftCorner="00020401,00020421"
        BottomRightCorner="00020410,00020430" TopLeftCornerBottom="00020404,00020424" BottomLeftCorner="00020408,00020428"
        TopBorder="00020402,00020422"></BorderImages>
</eo:Dialog>
<eo:Editor runat="server" id="Editor1" Height="320px" ToolBarSet="Basic" HighlightColor="255, 255, 192"
    Width="500px" ClientSideOnPaste="editor_paste_handler" HtmlBodyCssClass="demo_editor_body"
    TextAreaCssFile="~\EOWebDemo.css" Html='<p>EO.Web Editor supports custom pasted text handling. This sample implements a Paste Comment feature that automatically encloses the pasted text in a div element with yellow background.</p>&#13;&#10;<p>Try copy some text to the clipboard, then click <img height="16" src="../../../../images/comment.gif" width="16" /> to paste it as a comment.</p>&#13;&#10;'
    FileExplorerDialogID="FileExplorerDialog1" FileExplorerUrl="~/Demos/File Explorer/Explorer.aspx">
    <FooterStyle CssText="border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa"></FooterStyle>
    <BreadcrumbLabelStyle CssText="padding-right: 6px; padding-left: 6px; font-size: 12px; padding-top: 1px; font-family: tahoma"></BreadcrumbLabelStyle>
    <EditAreaStyle CssText="border-right: gray 1px solid; padding-right: 0px; border-top: gray 1px solid; padding-left: 0px; padding-bottom: 0px; border-left: gray 1px solid; padding-top: 0px; border-bottom: gray 1px solid"></EditAreaStyle>
    <HeaderStyle CssText="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; border-bottom: gray 1px"></HeaderStyle>
    <EmoticonStyle CssText="background-color:white;border-bottom-color:#c5d3ed;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#c5d3ed;border-left-style:solid;border-left-width:1px;border-right-color:#c5d3ed;border-right-style:solid;border-right-width:1px;border-top-color:#c5d3ed;border-top-style:solid;border-top-width:1px;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;"></EmoticonStyle>
    <BreadcrumbItemHoverStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma; background-color:#e0e0e0;"></BreadcrumbItemHoverStyle>
    <CustomHeaderTemplate>
        <eo:ToolBar id="HeaderToolBar0" Width="100%" runat="server" ClientSideOnItemClick="toolbar_click_handler"
            BackgroundImageRight="00100102" BackgroundImage="00100103" BackgroundImageLeft="00100101"
            SeparatorImage="00100104">
            <DownStyle CssText="border-right: #335ea8 1px solid; padding-right: 2px; border-top: #335ea8 1px solid; padding-left: 4px; padding-bottom: 1px; border-left: #335ea8 1px solid; padding-top: 3px; border-bottom: #335ea8 1px solid; background-color: #99afd4; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></DownStyle>
            <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 3px; border-top: #335ea8 1px solid; padding-left: 3px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; background-color: #c2cfe5; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></HoverStyle>
            <NormalStyle CssText="padding-right: 4px; padding-left: 4px; padding-bottom: 3px; border-top-style: none; padding-top: 3px; border-right-style: none; border-left-style: none; border-bottom-style: none; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></NormalStyle>
            <ItemTemplates>
                <eo:ToolBarItem Type="Custom">
                    <HoverStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></HoverStyle>
                    <DownStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></DownStyle>
                    <NormalStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></NormalStyle>
                </eo:ToolBarItem>
                <eo:ToolBarItem Type="DropDownMenu">
                    <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 3px; border-top: #335ea8 1px solid; padding-left: 3px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; background-color: #c2cfe5; cursor:hand; background-image: url(00100106); background-position-x: right;"></HoverStyle>
                    <DownStyle CssText="border-right: #335ea8 1px solid; padding-right: 2px; border-top: #335ea8 1px solid; padding-left: 4px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 3px; border-bottom: none; background-color:transparent; cursor:hand; background-image: url(00100105); background-position-x: right;"></DownStyle>
                    <NormalStyle CssText="padding-right: 4px; padding-left: 4px; padding-bottom: 3px; border-top-style: none; padding-top: 3px; border-right-style: none; border-left-style: none; border-bottom-style: none; cursor:hand; background-image: url(00100105); background-position-x: right;"></NormalStyle>
                </eo:ToolBarItem>
            </ItemTemplates>
            <Items>
                <eo:ToolBarItem ToolTip="Fonts" CommandName="Fonts" Type="Custom">
                    <CustomItem>
                        <asp:DropDownList runat="server" ID="FontDropDown" style="width:110px"></asp:DropDownList>
                    </CustomItem>
                </eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Font Sizes" CommandName="FontSizes" Type="Custom">
                    <CustomItem>
                        <asp:DropDownList runat="server" ID="FontSizeDropDown" style="width:50px"></asp:DropDownList>
                    </CustomItem>
                </eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Bold" ImageUrl="00101011" CommandName="Bold"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Italic" ImageUrl="00101012" CommandName="Italic"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Underline" ImageUrl="00101013" CommandName="Underline"></eo:ToolBarItem>
                <eo:ToolBarItem Type="Separator"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Align Left" ImageUrl="00101014" CommandName="AlignLeft"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Align Center" ImageUrl="00101015" CommandName="AlignCenter"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Align Right" ImageUrl="00101016" CommandName="AlignRight"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Align Justify" ImageUrl="00101017" CommandName="AlignJustify"></eo:ToolBarItem>
                <eo:ToolBarItem Type="Separator"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Bullet List" ImageUrl="00101019" CommandName="BulletList"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Numbered List" ImageUrl="00101020" CommandName="NumberedList"></eo:ToolBarItem>
                <eo:ToolBarItem Type="Separator"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Insert Link" ImageUrl="00101021" CommandName="InsertOrEditLink"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Insert Image" ImageUrl="00101033" CommandName="InsertOrEditImage"></eo:ToolBarItem>
                <eo:ToolBarItem Type="Separator"></eo:ToolBarItem>
                <eo:ToolBarItem ImageUrl="~\images\comment.gif" CommandName="PasteComment"></eo:ToolBarItem>
            </Items>
        </eo:ToolBar>
    </CustomHeaderTemplate>
    <TabButtonStyles>
        <SelectedStyle CssText="border-right: #335ea8 1px solid; padding-right: 6px; border-top: #335ea8 1px solid; padding-left: 6px; font-size: 12px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; font-family: tahoma; background-color: white"></SelectedStyle>
        <NormalStyle CssText="border-right: #335ea8 1px; padding-right: 7px; border-top: #335ea8 1px; padding-left: 7px; font-size: 12px; padding-bottom: 3px; border-left: #335ea8 1px; padding-top: 3px; border-bottom: #335ea8 1px; font-family: tahoma; background-color: white"></NormalStyle>
        <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 6px; border-top: #335ea8 1px solid; padding-left: 6px; font-size: 12px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; font-family: tahoma; background-color: #c2cfe5"></HoverStyle>
    </TabButtonStyles>
    <BreadcrumbDropDownStyle CssText="border-top: gray 1px solid; border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa"></BreadcrumbDropDownStyle>
    <BreadcrumbItemSeparatorStyle CssText="width: 3px; height: 10px"></BreadcrumbItemSeparatorStyle>
    <EmoticonDropDownStyle CssText="border-top: gray 1px solid; border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa"></EmoticonDropDownStyle>
    <BreadcrumbItemStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma"></BreadcrumbItemStyle>
</eo:Editor>
</asp:Content>


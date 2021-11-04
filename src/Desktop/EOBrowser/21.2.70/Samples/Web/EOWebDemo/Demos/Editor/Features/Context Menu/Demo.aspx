<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Editor_Features_Context_Menu_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
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
<eo:Editor runat="server" id="Editor1" Width="500px" HighlightColor="255, 255, 192" Height="320px"
    ToolBarSet="Basic" HtmlBodyCssClass="demo_editor_body" ContextMenuID="ContextMenu1" Html='<p>&#13;&#10;EO.Web Editor can display a context menu when user right clicks in the edit area. The context menu can contain context sensitive commands that will be shown/hidden or enabled/disabled according to the current context. This sample uses context menu to provide access to Copy, Cut and Paste and table related commands. Right click on any text and the context menu will display Copy, Cut and Paste commands. Right click on or inside the table below will display Copy, Cut and Paste along with all HTML table related commands. Please refer to the product documentation for more details about this feature.&#13;&#10;</p>&#13;&#10;<p>&#13;&#10;    <table style="WIDTH: 300px" border="1">&#13;&#10;        <tbody>&#13;&#10;            <tr>&#13;&#10;                <td>&amp;nbsp;</td>&#13;&#10;                <td>&amp;nbsp;</td>&#13;&#10;            </tr>&#13;&#10;            <tr>&#13;&#10;                <td>&amp;nbsp;</td>&#13;&#10;                <td>&amp;nbsp;</td>&#13;&#10;            </tr>&#13;&#10;        </tbody>&#13;&#10;    </table>&#13;&#10;</p>&#13;&#10;'
    TextAreaCssFile="~\EOWebDemo.css" FileExplorerDialogID="FileExplorerDialog1" FileExplorerUrl="~/Demos/File Explorer/Explorer.aspx">
    <FooterStyle CssText="border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa"></FooterStyle>
    <BreadcrumbLabelStyle CssText="padding-right: 6px; padding-left: 6px; font-size: 12px; padding-top: 1px; font-family: tahoma"></BreadcrumbLabelStyle>
    <EditAreaStyle CssText="border-right: gray 1px solid; padding-right: 0px; border-top: gray 1px solid; padding-left: 0px; padding-bottom: 0px; border-left: gray 1px solid; padding-top: 0px; border-bottom: gray 1px solid"></EditAreaStyle>
    <HeaderStyle CssText="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; border-bottom: gray 1px"></HeaderStyle>
    <EmoticonStyle CssText="background-color:white;border-bottom-color:#c5d3ed;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#c5d3ed;border-left-style:solid;border-left-width:1px;border-right-color:#c5d3ed;border-right-style:solid;border-right-width:1px;border-top-color:#c5d3ed;border-top-style:solid;border-top-width:1px;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;"></EmoticonStyle>
    <BreadcrumbItemHoverStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma; background-color:#e0e0e0;"></BreadcrumbItemHoverStyle>
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
<eo:ContextMenu runat="server" id="ContextMenu1" Width="170px" ControlSkinID="None" CheckIconUrl="OfficeCheckIcon">
    <TopGroup>
        <Items>
            <eo:MenuItem ItemID="Copy" LeftIcon-Url="00101007" Image-Url="" Text-Html="Copy"></eo:MenuItem>
            <eo:MenuItem ItemID="Cut" LeftIcon-Url="00101008" Image-Url="" Text-Html="Cut"></eo:MenuItem>
            <eo:MenuItem ItemID="Paste" LeftIcon-Url="00101009" Image-Url="" Text-Html="Paste"></eo:MenuItem>
            <eo:MenuItem IsSeparator="True"></eo:MenuItem>
            <eo:MenuItem ItemID="Table_InsertRowAbove" LeftIcon-Url="00101038" Image-Url="" Text-Html="Insert Row Above"></eo:MenuItem>
            <eo:MenuItem ItemID="Table_InsertRowBelow" LeftIcon-Url="00101039" Image-Url="" Text-Html="Insert Row Below"></eo:MenuItem>
            <eo:MenuItem ItemID="Table_DeleteRow" LeftIcon-Url="00101035" Image-Url="" Text-Html="Delete Row"></eo:MenuItem>
            <eo:MenuItem ItemID="Table_InsertColumnLeft" LeftIcon-Url="00101036" Image-Url="" Text-Html="Insert Column Left"></eo:MenuItem>
            <eo:MenuItem ItemID="Table_InsertColumnRight" LeftIcon-Url="00101037" Image-Url="" Text-Html="Insert Column Right"></eo:MenuItem>
            <eo:MenuItem ItemID="Table_DeleteColumn" LeftIcon-Url="00101034" Image-Url="" Text-Html="Delete Column"></eo:MenuItem>
            <eo:MenuItem ItemID="Table_MergeCellsDown" LeftIcon-Url="00101040" Image-Url="" Text-Html="Merge Cells Down"></eo:MenuItem>
            <eo:MenuItem ItemID="Table_MergeCellsRight" LeftIcon-Url="00101041" Image-Url="" Text-Html="Merge Cells Right"></eo:MenuItem>
            <eo:MenuItem ItemID="Table_SplitCellHorz" LeftIcon-Url="00101042" Image-Url="" Text-Html="Split Cell Horizontally"></eo:MenuItem>
            <eo:MenuItem ItemID="Table_SplitCellVert" LeftIcon-Url="00101043" Image-Url="" Text-Html="Split Cell Vertically"></eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:1px;color:lightgrey"
            Height="24" HoverStyle-CssText="background-color:#c1d2ee;border-bottom-color:#316ac5;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#316ac5;border-left-style:solid;border-left-width:1px;border-right-color:#316ac5;border-right-style:solid;border-right-width:1px;border-top-color:#316ac5;border-top-style:solid;border-top-width:1px;padding-left:4px;padding-right:4px;padding-top:0px;padding-bottom:0px;"
            ItemID="_TopLevelItem" NormalStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:1px;"
            SelectedStyle-CssText="background-color:white;border-bottom-color:#316ac5;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#316ac5;border-left-style:solid;border-left-width:1px;border-right-color:#316ac5;border-right-style:solid;border-right-width:1px;border-top-color:#316ac5;border-top-style:solid;border-top-width:1px;padding-left:4px;padding-right:4px;padding-top:0px;padding-bottom:0px;">
            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="background-color:#fcfcf9;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:black;cursor:hand;font-family:Tahoma;font-size:8pt;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
                CollapseEffect-Type="GlideTopToBottom" SideImage="Office2003SideBar" LeftIconCellWidth="25"
                ItemSpacing="3"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="background-color:#c5c2b8;height:1px;margin-left:30px;width:1px;"></eo:MenuItem>
        <eo:MenuItem DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:5px;padding-top:1px;color:lightgrey"
            Height="24" HoverStyle-CssText="background-color:#c1d2ee;border-bottom-color:#316ac5;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#316ac5;border-left-style:solid;border-left-width:1px;border-right-color:#316ac5;border-right-style:solid;border-right-width:1px;border-top-color:#316ac5;border-top-style:solid;border-top-width:1px;padding-left:1px;padding-right:4px;padding-top:0px;"
            ItemID="_Default" NormalStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:5px;padding-top:1px;"
            SelectedStyle-CssText="background-color:white;border-bottom-color:#316ac5;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#316ac5;border-left-style:solid;border-left-width:1px;border-right-color:#316ac5;border-right-style:solid;border-right-width:1px;border-top-color:#316ac5;border-top-style:solid;border-top-width:1px;padding-left:1px;padding-right:4px;padding-top:0px;"
            Text-Padding-Right="30">
            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="background-color:#fcfcf9;border-bottom-color:#999999;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#999999;border-left-style:solid;border-left-width:1px;border-right-color:#999999;border-right-style:solid;border-right-width:1px;border-top-color:#999999;border-top-style:solid;border-top-width:1px;color:black;cursor:hand;font-family:Tahoma;font-size:8pt;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
                CollapseEffect-Type="GlideTopToBottom" SideImage="Office2003SideBar" LeftIconCellWidth="25"
                ItemSpacing="3"></SubMenu>
        </eo:MenuItem>
    </LookItems>
</eo:ContextMenu>
</asp:Content>


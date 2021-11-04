<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Editor_Designs_Style_1_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    This style uses <b>CustomHeaderTemplate</b> to define a custom toolbar.
</p>
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
<eo:Editor runat="server" id="Editor1" Width="470px" HTMLBodyCssClass="demo_editor_body" FooterVisible="False"
    HighlightColor="255, 255, 192" Height="250px" ToolBarSet="Custom" TextAreaCssFile="~\EOWebDemo.css"
    FileExplorerDialogID="FileExplorerDialog1" FileExplorerUrl="~/Demos/File Explorer/Explorer.aspx">
    <FooterStyle CssText="background-color:#f8f8f8;border-bottom-color:black;border-bottom-style:solid;border-bottom-width:1px;border-left-color:black;border-left-style:solid;border-left-width:1px;border-right-color:black;border-right-style:solid;border-right-width:1px;padding-bottom:3px;padding-left:3px;padding-right:3px;padding-top:3px;"></FooterStyle>
    <BreadcrumbLabelStyle CssText="padding-right: 6px; padding-left: 6px; font-size: 12px; padding-top: 1px; font-family: tahoma"></BreadcrumbLabelStyle>
    <EditAreaStyle CssText="border-bottom-color:black;border-bottom-style:solid;border-bottom-width:1px;border-left-color:black;border-left-style:solid;border-left-width:1px;border-right-color:black;border-right-style:solid;border-right-width:1px;border-top-color:black;border-top-style:solid;border-top-width:1px;padding-bottom:0px;padding-left:0px;padding-right:0px;padding-top:0px;"></EditAreaStyle>
    <EmoticonStyle CssText="background-color:white;border-bottom-color:#c5d3ed;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#c5d3ed;border-left-style:solid;border-left-width:1px;border-right-color:#c5d3ed;border-right-style:solid;border-right-width:1px;border-top-color:#c5d3ed;border-top-style:solid;border-top-width:1px;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;"></EmoticonStyle>
    <BreadcrumbItemHoverStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma; background-color:#e0e0e0;"></BreadcrumbItemHoverStyle>
    <CustomHeaderTemplate>
        <eo:ToolBar ID="ToolBar1" runat="server" SeparatorImage="00100304">
            <ItemTemplates>
                <eo:ToolBarItem Type="Custom">
                    <HoverStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></HoverStyle>
                    <DownStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></DownStyle>
                    <NormalStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></NormalStyle>
                </eo:ToolBarItem>
            </ItemTemplates>
            <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 3px; border-top: #335ea8 1px solid; padding-left: 3px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; background-color: #c2cfe5; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></HoverStyle>
            <DownStyle CssText="border-right: #335ea8 1px solid; padding-right: 2px; border-top: #335ea8 1px solid; padding-left: 4px; padding-bottom: 1px; border-left: #335ea8 1px solid; padding-top: 3px; border-bottom: #335ea8 1px solid; background-color: #99afd4; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></DownStyle>
            <NormalStyle CssText="padding-right: 4px; padding-left: 4px; padding-bottom: 3px; border-top-style: none; padding-top: 3px; border-right-style: none; border-left-style: none; border-bottom-style: none; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;"></NormalStyle>
            <Items>
                <eo:ToolBarItem ToolTip="Bold" ImageUrl="00101011" CommandName="Bold"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Italic" ImageUrl="00101012" CommandName="Italic"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Underline" ImageUrl="00101013" CommandName="Underline"></eo:ToolBarItem>
                <eo:ToolBarItem Type="Separator"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Insert Image" ImageUrl="00101033" CommandName="InsertOrEditImage"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Insert Link" ImageUrl="00101021" CommandName="InsertOrEditLink"></eo:ToolBarItem>
                <eo:ToolBarItem Type="Separator"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Align Left" ImageUrl="00101014" CommandName="AlignLeft"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Align Center" ImageUrl="00101015" CommandName="AlignCenter"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Align Right" ImageUrl="00101016" CommandName="AlignRight"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Fonts" CommandName="Fonts" Type="Custom">
                    <CustomItem>
                        <div style="white-space:nowrap">
                            <span style="font-family:Verdana;font-size:10pt">Font:</span>
                            <asp:DropDownList runat="server" ID="FontDropDown" style="width:115px">
                                <asp:ListItem Value="Arial">Arial</asp:ListItem>
                                <asp:ListItem Value="Courier New">Courier New</asp:ListItem>
                                <asp:ListItem Value="Tahoma">Tahoma</asp:ListItem>
                                <asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
                                <asp:ListItem Value="Verdana">Verdana</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </CustomItem>
                </eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="FontSizes" CommandName="FontSizes" Type="Custom">
                    <CustomItem>
                        <asp:DropDownList runat="server" ID="FontSizeDropDown" style="width:50px">
                            <asp:ListItem Value="8pt">8pt</asp:ListItem>
                            <asp:ListItem Value="10pt">10pt</asp:ListItem>
                            <asp:ListItem Value="12pt">12pt</asp:ListItem>
                            <asp:ListItem Value="14pt">14pt</asp:ListItem>
                            <asp:ListItem Value="16pt">16pt</asp:ListItem>
                            <asp:ListItem Value="20pt">20pt</asp:ListItem>
                            <asp:ListItem Value="32pt">32pt</asp:ListItem>
                        </asp:DropDownList>
                    </CustomItem>
                </eo:ToolBarItem>
                <eo:ToolBarItem Type="Separator"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Design Mode" ImageUrl="00101051" CommandName="DesignMode"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="HTML Mode" ImageUrl="00101052" CommandName="HTMLMode"></eo:ToolBarItem>
            </Items>
        </eo:ToolBar>
    </CustomHeaderTemplate>
    <TabButtonStyles>
        <SelectedStyle CssText="border-bottom-color:#a7a6aa;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#a7a6aa;border-left-style:solid;border-left-width:1px;border-right-color:#a7a6aa;border-right-style:solid;border-right-width:1px;border-top-color:#a7a6aa;border-top-style:solid;border-top-width:1px;font-family:Verdana;font-size:12px;padding-bottom:2px;padding-left:4px;padding-right:4px;padding-top:2px;"></SelectedStyle>
        <NormalStyle CssText="font-family:Verdana;font-size:12px;padding-bottom:3px;padding-left:5px;padding-right:5px;padding-top:3px;"></NormalStyle>
        <HoverStyle CssText="background-color:#e0e0e0;border-bottom-color:#a7a6aa;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#a7a6aa;border-left-style:solid;border-left-width:1px;border-right-color:#a7a6aa;border-right-style:solid;border-right-width:1px;border-top-color:#a7a6aa;border-top-style:solid;border-top-width:1px;font-family:Verdana;font-size:12px;padding-bottom:2px;padding-left:4px;padding-right:4px;padding-top:2px;"></HoverStyle>
    </TabButtonStyles>
    <BreadcrumbDropDownStyle CssText="border-top: gray 1px solid; border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa"></BreadcrumbDropDownStyle>
    <BreadcrumbItemSeparatorStyle CssText="width: 3px; height: 10px"></BreadcrumbItemSeparatorStyle>
    <EmoticonDropDownStyle CssText="background-color:#f8f8f8;border-bottom-color:#d6d5d9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#d6d5d9;border-left-style:solid;border-left-width:1px;border-right-color:#d6d5d9;border-right-style:solid;border-right-width:1px;border-top-color:#d6d5d9;border-top-style:solid;border-top-width:1px;padding-bottom:0px;padding-left:0px;padding-right:0px;padding-top:0px;"></EmoticonDropDownStyle>
    <BreadcrumbItemStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma"></BreadcrumbItemStyle>
</eo:Editor>
</asp:Content>


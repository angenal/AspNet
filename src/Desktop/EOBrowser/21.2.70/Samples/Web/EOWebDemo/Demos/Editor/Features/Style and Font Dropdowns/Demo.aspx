<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Editor_Features_Style_and_Font_Dropdowns_Demo" Title="Untitled Page" %>
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:Editor runat="server" id="Editor1" Width="500px" HighlightColor="255, 255, 192" Height="320px"
    ToolBarSet="Custom" HtmlBodyCssClass="demo_editor_body" Html="<p>EO.Web Editor supports style, font name and &#13;&#10;font sizes drop downs. Use property <strong>Styles</strong>, &#13;&#10;<strong>FontNames</strong> and <strong>FontSizes</strong> &#13;&#10;to customize these three drop downs respectively.</p>&#13;&#10;&#13;&#10;"
    FontNames="Arial|Tahoma|Times New Roman|Verdana" FontSizes="10px|12px|16px" TextAreaCssFile="~\EOWebDemo.css">
    <FooterStyle CssText="border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa"></FooterStyle>
    <BreadcrumbLabelStyle CssText="padding-right: 6px; padding-left: 6px; font-size: 12px; padding-top: 1px; font-family: tahoma"></BreadcrumbLabelStyle>
    <EditAreaStyle CssText="border-right: gray 1px solid; padding-right: 0px; border-top: gray 1px solid; padding-left: 0px; padding-bottom: 0px; border-left: gray 1px solid; padding-top: 0px; border-bottom: gray 1px solid"></EditAreaStyle>
    <Styles>
        <eo:EditorStyle TagName="H1" Name="Heading 1" FullParagrah="True"></eo:EditorStyle>
        <eo:EditorStyle TagName="H2" Name="Heading 2" FullParagrah="True"></eo:EditorStyle>
        <eo:EditorStyle TagName="H3" Name="Heading 3" FullParagrah="True"></eo:EditorStyle>
        <eo:EditorStyle CssClass="code" Name="Code" FullParagrah="True"></eo:EditorStyle>
    </Styles>
    <HeaderStyle CssText="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; border-bottom: gray 1px"></HeaderStyle>
    <EmoticonStyle CssText="background-color:white;border-bottom-color:#c5d3ed;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#c5d3ed;border-left-style:solid;border-left-width:1px;border-right-color:#c5d3ed;border-right-style:solid;border-right-width:1px;border-top-color:#c5d3ed;border-top-style:solid;border-top-width:1px;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;"></EmoticonStyle>
    <BreadcrumbItemHoverStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma; background-color:#e0e0e0;"></BreadcrumbItemHoverStyle>
    <CustomHeaderTemplate>
        <eo:ToolBar id="HeaderToolBar0" runat="server" Width="100%" SeparatorImage="00100104" BackgroundImageLeft="00100101"
            BackgroundImage="00100103" BackgroundImageRight="00100102">
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
                <eo:ToolBarItem ToolTip="Styles" CommandName="Styles" Type="Custom">
                    <CustomItem>
                        <asp:DropDownList runat="server" ID="StyleDropDown" style="width:100px"></asp:DropDownList>
                    </CustomItem>
                </eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Fonts" CommandName="Fonts" Type="Custom">
                    <CustomItem>
                        <asp:DropDownList runat="server" ID="FontDropDown" style="width:100px"></asp:DropDownList>
                    </CustomItem>
                </eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Font Sizes" CommandName="FontSizes" Type="Custom">
                    <CustomItem>
                        <asp:DropDownList runat="server" ID="FontSizeDropDown" style="width:60px"></asp:DropDownList>
                    </CustomItem>
                </eo:ToolBarItem>
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


<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Editor_Programming_Open_and_Save_File_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<asp:checkbox id="FullHTML" Runat="server" Text="Include head and body tag when saving file."></asp:checkbox>
<eo:Editor runat="server" id="Editor1" Width="500px" HighlightColor="255, 255, 192" Height="320px"
    ToolBarSet="Basic" HtmlBodyCssClass="demo_editor_body" Html="<p>EO.Web Editor provides <strong>Save</strong> event. The event is fired when <em>Save</em> button is clicked on the toolbar. Inside the event handler you can access the editor's <strong>Html</strong> property to get the content of the editor and saves it into a file.</p><p>Loading from a file is the opposite --- reading the contents from a file and then set it the editor's <strong>Html</strong> property.</p>"
    TextAreaCssFile="~\EOWebDemo.css" OnSave="Editor1_Save">
    <FooterStyle CssText="border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa"></FooterStyle>
    <BreadcrumbLabelStyle CssText="padding-right: 6px; padding-left: 6px; font-size: 12px; padding-top: 1px; font-family: tahoma"></BreadcrumbLabelStyle>
    <EditAreaStyle CssText="border-right: gray 1px solid; padding-right: 0px; border-top: gray 1px solid; padding-left: 0px; padding-bottom: 0px; border-left: gray 1px solid; padding-top: 0px; border-bottom: gray 1px solid"></EditAreaStyle>
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
                <eo:ToolBarItem ToolTip="New" ImageUrl="00101001" CommandName="New"></eo:ToolBarItem>
                <eo:ToolBarItem ToolTip="Save" ImageUrl="00101003" CommandName="Save"></eo:ToolBarItem>
                <eo:ToolBarItem Type="Separator"></eo:ToolBarItem>
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


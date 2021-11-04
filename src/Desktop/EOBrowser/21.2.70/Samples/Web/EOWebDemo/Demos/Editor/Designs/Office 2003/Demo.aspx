<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Editor_Designs_Office_2003_Demo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        This editor uses the built-in Office 2003 style. Use the following option to choose
        the desired <b>tool bar set</b> for the editor.
    </p>
    <eo:Dialog runat="server" ID="FileExplorerDialog1" Width="320px" Height="216px" ControlSkinID="None"
        HeaderHtml="Dialog Title" CloseButtonUrl="00020440" AllowResize="True" HeaderHtmlFormat='<div style="padding-top:4px">{0}</div>'
        HeaderImageUrl="00020441" HeaderImageHeight="27" MinWidth="150" MinHeight="100"
        AcceptButton="OK" CancelButton="Cancel">
        <ContentTemplate>
            <eo:FileExplorerHolder runat="server" ID="Explorer1" Width="710px" Height="350px">
            </eo:FileExplorerHolder>
            <div style="padding: 10px; text-align: right;">
                <asp:Button runat="server" ID="OK" Text="OK" Style="width: 80px"></asp:Button>
                <asp:Button runat="server" ID="Cancel" Text="Cancel" Style="width: 80px"></asp:Button>
            </div>
        </ContentTemplate>
        <FooterStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 8pt; padding-bottom: 4px; padding-top: 4px; font-family: tahoma">
        </FooterStyleActive>
        <HeaderStyleActive CssText="background-image:url(00020442);color:#444444;font-family:'trebuchet ms';font-size:10pt;font-weight:bold;padding-bottom:7px;padding-left:8px;padding-right:0px;padding-top:0px;">
        </HeaderStyleActive>
        <ContentStyleActive CssText="background-color:#f0f0f0;font-family:tahoma;font-size:8pt;padding-bottom:4px;padding-left:4px;padding-right:4px;padding-top:4px">
        </ContentStyleActive>
        <BorderImages BottomBorder="00020409,00020429" RightBorder="00020407,00020427" TopRightCornerBottom="00020405,00020425"
            TopRightCorner="00020403,00020423" LeftBorder="00020406,00020426" TopLeftCorner="00020401,00020421"
            BottomRightCorner="00020410,00020430" TopLeftCornerBottom="00020404,00020424"
            BottomLeftCorner="00020408,00020428" TopBorder="00020402,00020422"></BorderImages>
    </eo:Dialog>
    <eo:CallbackPanel runat="server" ID="CallbackPanel1" Triggers="{ControlID:tbSet;Parameter:}"
        Height="300px" Width="500px" LoadingHTML="Please wait...">
        <asp:RadioButtonList ID="tbSet" AutoPostBack="True" RepeatDirection="Horizontal"
            runat="server" OnSelectedIndexChanged="tbSet_SelectedIndexChanged">
            <asp:ListItem Value="Basic" Selected="True">Basic</asp:ListItem>
            <asp:ListItem Value="Standard">Standard</asp:ListItem>
            <asp:ListItem Value="Full">Full</asp:ListItem>
        </asp:RadioButtonList>
        <eo:Editor ID="Editor1" Width="500px" Height="320px" runat="server" TextAreaCssFile="~\EOWebDemo.css"
            SpellCheckerID="SpellChecker1" ColorPickerID="ColorPicker1" ToolBarSet="Basic"
            HighlightColor="255, 255, 192" HtmlBodyCssClass="demo_editor_body" FileExplorerDialogID="FileExplorerDialog1"
            FileExplorerUrl="~/Demos/File Explorer/Explorer.aspx">
            <BreadcrumbItemStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma">
            </BreadcrumbItemStyle>
            <BreadcrumbItemHoverStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma; background-color:#e0e0e0;">
            </BreadcrumbItemHoverStyle>
            <EmoticonDropDownStyle CssText="border-top: gray 1px solid; border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa">
            </EmoticonDropDownStyle>
            <BreadcrumbLabelStyle CssText="padding-right: 6px; padding-left: 6px; font-size: 12px; padding-top: 1px; font-family: tahoma">
            </BreadcrumbLabelStyle>
            <BreadcrumbItemSeparatorStyle CssText="width: 3px; height: 10px"></BreadcrumbItemSeparatorStyle>
            <HeaderStyle CssText="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; border-bottom: gray 1px">
            </HeaderStyle>
            <BreadcrumbDropDownStyle CssText="border-top: gray 1px solid; border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa">
            </BreadcrumbDropDownStyle>
            <EditAreaStyle CssText="border-right: gray 1px solid; padding-right: 0px; border-top: gray 1px solid; padding-left: 0px; padding-bottom: 0px; border-left: gray 1px solid; padding-top: 0px; border-bottom: gray 1px solid">
            </EditAreaStyle>
            <EmoticonStyle CssText="background-color:white;border-bottom-color:#c5d3ed;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#c5d3ed;border-left-style:solid;border-left-width:1px;border-right-color:#c5d3ed;border-right-style:solid;border-right-width:1px;border-top-color:#c5d3ed;border-top-style:solid;border-top-width:1px;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;">
            </EmoticonStyle>
            <FooterStyle CssText="border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa">
            </FooterStyle>
            <TabButtonStyles>
                <SelectedStyle CssText="border-right: #335ea8 1px solid; padding-right: 6px; border-top: #335ea8 1px solid; padding-left: 6px; font-size: 12px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; font-family: tahoma; background-color: white">
                </SelectedStyle>
                <NormalStyle CssText="border-right: #335ea8 1px; padding-right: 7px; border-top: #335ea8 1px; padding-left: 7px; font-size: 12px; padding-bottom: 3px; border-left: #335ea8 1px; padding-top: 3px; border-bottom: #335ea8 1px; font-family: tahoma; background-color: white">
                </NormalStyle>
                <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 6px; border-top: #335ea8 1px solid; padding-left: 6px; font-size: 12px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; font-family: tahoma; background-color: #c2cfe5">
                </HoverStyle>
            </TabButtonStyles>
        </eo:Editor>
    </eo:CallbackPanel>
    <eo:ColorPicker ID="ColorPicker1" runat="server" ControlSkinID="None">
        <TextBoxStyle CssText="border-right: #7f9db9 1px solid; border-top: #7f9db9 1px solid; border-left: #7f9db9 1px solid; border-bottom: #7f9db9 1px solid">
        </TextBoxStyle>
        <PopupStyle CssText="border-right: #999999 1px solid; border-top: #999999 1px solid; font-size: 10pt; border-left: #999999 1px solid; color: #0751b8; border-bottom: #999999 1px solid; font-family: arial; background-color: white">
        </PopupStyle>
    </eo:ColorPicker>
    <eo:SpellChecker ID="SpellChecker1" runat="server" DialogID="SpellCheckerDialog1">
    </eo:SpellChecker>
    <eo:SpellCheckerDialog ID="SpellCheckerDialog1" Width="320px" Height="216px" runat="server"
        ControlSkinID="None" CloseButtonUrl="00070301" BackColor="#ECE9D8" HeaderHtml="Spell Checker">
        <FooterStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 8pt; padding-bottom: 4px; padding-top: 4px; font-family: tahoma">
        </FooterStyleActive>
        <HeaderStyleActive CssText="padding-right: 3px; padding-left: 8px; font-weight: bold; font-size: 10pt; background-image: url(00020113); padding-bottom: 3px; color: white; padding-top: 0px; font-family: 'trebuchet ms';height:20px;">
        </HeaderStyleActive>
        <ContentStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 8pt; padding-bottom: 4px; padding-top: 4px; font-family: tahoma">
        </ContentStyleActive>
        <BorderImages BottomBorder="00020112" RightBorder="00020111" TopRightCornerBottom="00020106"
            TopLeftCornerRight="00020102" TopRightCorner="00020104" LeftBorder="00020110"
            TopLeftCorner="00020101" BottomRightCorner="00020108" TopLeftCornerBottom="00020103"
            BottomLeftCorner="00020107" TopRightCornerLeft="00020105" TopBorder="00020109"></BorderImages>
    </eo:SpellCheckerDialog>
</asp:Content>

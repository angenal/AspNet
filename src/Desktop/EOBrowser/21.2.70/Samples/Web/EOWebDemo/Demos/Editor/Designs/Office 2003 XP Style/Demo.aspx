<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Editor_Designs_Office_2003_XP_Style_Demo"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <p>
        This editor uses the built-in Office 2003 XP style template. Use the following option
        to choose the desired <b>tool bar set</b> for the editor.
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
        <eo:Editor ID="Editor1" Width="500px" Height="320px" runat="server" ColorPickerID="ColorPicker1"
            SpellCheckerID="SpellChecker1" ToolBarSet="Basic" HighlightColor="255, 255, 192"
            HtmlBodyCssClass="demo_editor_body" HtmlTabButtonText='<div style="padding-left:18px;padding-top:3px;">HTML</div>'
            PreviewTabButtonText='<div style="padding-left:18px;padding-top:3px;">Preview</div>'
            ToolBarSkin="Office2003_XPStyle" DesignTabButtonText='<div style="padding-left:18px;padding-top:3px;">Design</div>'
            TextAreaCssFile="~\EOWebDemo.css" FileExplorerDialogID="FileExplorerDialog1"
            FileExplorerUrl="~/Demos/File Explorer/Explorer.aspx">
            <FooterStyle CssText="padding-right: 2px; padding-left: 2px; padding-bottom: 2px; padding-top: 0px; background-color:#9ebef5;">
            </FooterStyle>
            <BreadcrumbLabelStyle CssText="padding-right: 6px; padding-left: 6px; font-size: 12px; padding-top: 1px; font-family: tahoma">
            </BreadcrumbLabelStyle>
            <CustomFooterTemplate>
                <div style="float: left; width: 200px;">
                    <asp:PlaceHolder runat="server" ID="ViewTabs"></asp:PlaceHolder>
                </div>
                <div style="padding-top: 1px">
                    <asp:PlaceHolder runat="server" ID="Breadcrumb"></asp:PlaceHolder>
                </div>
            </CustomFooterTemplate>
            <EditAreaStyle CssText="border-bottom-color:gray;border-bottom-style:solid;border-bottom-width:1px;border-left-color:gray;border-left-style:solid;border-left-width:1px;border-right-color:gray;border-right-style:solid;border-right-width:1px;border-top-color:gray;border-top-style:solid;border-top-width:1px;">
            </EditAreaStyle>
            <DesignTabButtonStyles>
                <SelectedStyle CssText="font-size: 12px; background-image: url(00102003); width: 63px; font-family: tahoma; height: 21px">
                </SelectedStyle>
                <NormalStyle CssText="font-size: 12px; background-image: url(00102001); width: 63px; font-family: tahoma; height: 21px">
                </NormalStyle>
                <HoverStyle CssText="font-size: 12px; background-image: url(00102002); width: 63px; font-family: tahoma; height: 21px">
                </HoverStyle>
            </DesignTabButtonStyles>
            <PreviewTabButtonStyles>
                <SelectedStyle CssText="font-size: 12px; background-image: url(00102009); width: 63px; font-family: tahoma; height: 21px">
                </SelectedStyle>
                <NormalStyle CssText="font-size: 12px; background-image: url(00102007); width: 63px; font-family: tahoma; height: 21px">
                </NormalStyle>
                <HoverStyle CssText="font-size: 12px; background-image: url(00102008); width: 63px; font-family: tahoma; height: 21px">
                </HoverStyle>
            </PreviewTabButtonStyles>
            <HeaderStyle CssText="background-color:#9ebef5;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;">
            </HeaderStyle>
            <HtmlTabButtonStyles>
                <SelectedStyle CssText="font-size: 12px; background-image: url(00102006); width: 63px; font-family: tahoma; height: 21px">
                </SelectedStyle>
                <NormalStyle CssText="font-size: 12px; background-image: url(00102004); width: 63px; font-family: tahoma; height: 21px">
                </NormalStyle>
                <HoverStyle CssText="font-size: 12px; background-image: url(00102005); width: 63px; font-family: tahoma; height: 21px">
                </HoverStyle>
            </HtmlTabButtonStyles>
            <EmoticonStyle CssText="background-color:white;border-bottom-color:#c5d3ed;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#c5d3ed;border-left-style:solid;border-left-width:1px;border-right-color:#c5d3ed;border-right-style:solid;border-right-width:1px;border-top-color:#c5d3ed;border-top-style:solid;border-top-width:1px;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;">
            </EmoticonStyle>
            <BreadcrumbItemHoverStyle CssText="background-color:#ffd69c;border-bottom-color:#002d96;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#002d96;border-left-style:solid;border-left-width:1px;border-right-color:#002d96;border-right-style:solid;border-right-width:1px;border-top-color:#002d96;border-top-style:solid;border-top-width:1px;font-family:tahoma;font-size:12px;margin-top:1px;padding-bottom:1px;padding-left:3px;padding-right:3px;padding-top:1px;">
            </BreadcrumbItemHoverStyle>
            <BreadcrumbDropDownStyle CssText="border-right: #435f96 1px solid; border-top: #435f96 1px solid; border-left: #435f96 1px solid; border-bottom: #435f96 1px solid; background-color: #eef3fa">
            </BreadcrumbDropDownStyle>
            <BreadcrumbItemSeparatorStyle CssText="width: 3px; height: 10px"></BreadcrumbItemSeparatorStyle>
            <EmoticonDropDownStyle CssText="border-right: #435f96 1px solid; border-top: #435f96 1px solid; border-left: #435f96 1px solid; border-bottom: #435f96 1px solid; background-color: #eef3fa">
            </EmoticonDropDownStyle>
            <BreadcrumbItemStyle CssText="background-color:#d7e4fa;border-bottom-color:#002d96;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#002d96;border-left-style:solid;border-left-width:1px;border-right-color:#002d96;border-right-style:solid;border-right-width:1px;border-top-color:#002d96;border-top-style:solid;border-top-width:1px;font-family:tahoma;font-size:12px;margin-top:1px;padding-bottom:1px;padding-left:3px;padding-right:3px;padding-top:1px;">
            </BreadcrumbItemStyle>
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

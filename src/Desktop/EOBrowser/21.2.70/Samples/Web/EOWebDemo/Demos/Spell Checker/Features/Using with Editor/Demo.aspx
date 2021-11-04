<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Spell_Checker_Features_Using_with_Editor_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:Editor id="Editor1" Width="500px" Height="320px" runat="server" SpellCheckerID="SpellChecker1"
    ToolBarSet="Full" HighlightColor="255, 255, 192" HTMLBodyCssClass="demo_editor_body" HTMLTabButtonText='<div style="padding-left:18px;padding-top:3px;">HTML</div>'
    PreviewTabButtonText='<div style="padding-left:18px;padding-top:3px;">Preview</div>' ToolBarSkin="Office2003_XPStyle"
    DesignTabButtonText='<div style="padding-left:18px;padding-top:3px;">Design</div>' Html="<p>EO.Web&amp;nbsp;Editor can&amp;nbsp;invoke EO.Web SpellChecker to perform spell checking.&amp;nbsp;Follow these simple steps to use this feature:</p>&#13;&#10;<ol>&#13;&#10;    <li>Enable SpellCheck toolbar item. See <em>Customizing ToolBars </em>section in the product documentation for more details;</li>&#13;&#10;    <li>Place a SpellChecker and&amp;nbsp;a SpellCheckerDialog control&amp;nbsp;onto the form;</li>&#13;&#10;    <li>Set the&amp;nbsp;Editor's SpellCheckerID&amp;nbsp;to the ID of the SpellChecker control;</li>&#13;&#10;    <li>Set the SpellChecker's DialogID to the ID of the SpellCheckerDialog control;</li>&#13;&#10;</ol>&#13;&#10;<p />"
    TextAreaCssFile="~\EOWebDemo.css" ColorPickerID="ColorPicker1">
    <FooterStyle CssText="background-color:#9ebef5;padding-bottom:2px;"></FooterStyle>
    <BreadcrumbLabelStyle CssText="padding-right: 6px; padding-left: 6px; font-size: 12px; padding-top: 1px; font-family: tahoma"></BreadcrumbLabelStyle>
    <CustomFooterTemplate>
        <DIV style="FLOAT: left; WIDTH: 200px;">
            <asp:PlaceHolder runat="server" ID="ViewTabs"></asp:PlaceHolder>
        </DIV>
        <DIV style="padding-top:1px">
            <asp:PlaceHolder runat="server" ID="Breadcrumb"></asp:PlaceHolder>
        </DIV>
    </CustomFooterTemplate>
    <EditAreaStyle CssText="border-bottom-color:gray;border-bottom-style:solid;border-bottom-width:1px;border-left-color:gray;border-left-style:solid;border-left-width:1px;border-right-color:gray;border-right-style:solid;border-right-width:1px;border-top-color:gray;border-top-style:solid;border-top-width:1px;"></EditAreaStyle>
    <DesignTabButtonStyles>
        <SelectedStyle CssText="font-size: 12px; background-image: url(00102003); width: 63px; font-family: tahoma; height: 21px"></SelectedStyle>
        <NormalStyle CssText="font-size: 12px; background-image: url(00102001); width: 63px; font-family: tahoma; height: 21px"></NormalStyle>
        <HoverStyle CssText="font-size: 12px; background-image: url(00102002); width: 63px; font-family: tahoma; height: 21px"></HoverStyle>
    </DesignTabButtonStyles>
    <PreviewTabButtonStyles>
        <SelectedStyle CssText="font-size: 12px; background-image: url(00102009); width: 63px; font-family: tahoma; height: 21px"></SelectedStyle>
        <NormalStyle CssText="font-size: 12px; background-image: url(00102007); width: 63px; font-family: tahoma; height: 21px"></NormalStyle>
        <HoverStyle CssText="font-size: 12px; background-image: url(00102008); width: 63px; font-family: tahoma; height: 21px"></HoverStyle>
    </PreviewTabButtonStyles>
    <HeaderStyle CssText="background-color:#9ebef5;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></HeaderStyle>
    <HtmlTabButtonStyles>
        <SelectedStyle CssText="font-size: 12px; background-image: url(00102006); width: 63px; font-family: tahoma; height: 21px"></SelectedStyle>
        <NormalStyle CssText="font-size: 12px; background-image: url(00102004); width: 63px; font-family: tahoma; height: 21px"></NormalStyle>
        <HoverStyle CssText="font-size: 12px; background-image: url(00102005); width: 63px; font-family: tahoma; height: 21px"></HoverStyle>
    </HtmlTabButtonStyles>
    <EmoticonStyle CssText="background-color:white;border-bottom-color:#c5d3ed;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#c5d3ed;border-left-style:solid;border-left-width:1px;border-right-color:#c5d3ed;border-right-style:solid;border-right-width:1px;border-top-color:#c5d3ed;border-top-style:solid;border-top-width:1px;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;"></EmoticonStyle>
    <BreadcrumbItemHoverStyle CssText="background-color:#ffd69c;border-bottom-color:#002d96;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#002d96;border-left-style:solid;border-left-width:1px;border-right-color:#002d96;border-right-style:solid;border-right-width:1px;border-top-color:#002d96;border-top-style:solid;border-top-width:1px;font-family:tahoma;font-size:12px;margin-top:1px;padding-bottom:1px;padding-left:3px;padding-right:3px;padding-top:1px;"></BreadcrumbItemHoverStyle>
    <BreadcrumbDropDownStyle CssText="border-right: #435f96 1px solid; border-top: #435f96 1px solid; border-left: #435f96 1px solid; border-bottom: #435f96 1px solid; background-color: #eef3fa"></BreadcrumbDropDownStyle>
    <BreadcrumbItemSeparatorStyle CssText="width: 3px; height: 10px"></BreadcrumbItemSeparatorStyle>
    <EmoticonDropDownStyle CssText="border-right: #435f96 1px solid; border-top: #435f96 1px solid; border-left: #435f96 1px solid; border-bottom: #435f96 1px solid; background-color: #eef3fa"></EmoticonDropDownStyle>
    <BreadcrumbItemStyle CssText="background-color:#d7e4fa;border-bottom-color:#002d96;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#002d96;border-left-style:solid;border-left-width:1px;border-right-color:#002d96;border-right-style:solid;border-right-width:1px;border-top-color:#002d96;border-top-style:solid;border-top-width:1px;font-family:tahoma;font-size:12px;margin-top:1px;padding-bottom:1px;padding-left:3px;padding-right:3px;padding-top:1px;"></BreadcrumbItemStyle>
</eo:Editor>
<eo:ColorPicker id="ColorPicker1" runat="server" ControlSkinID="None">
    <TextBoxStyle CssText="border-right: #7f9db9 1px solid; border-top: #7f9db9 1px solid; border-left: #7f9db9 1px solid; border-bottom: #7f9db9 1px solid"></TextBoxStyle>
    <PopupStyle CssText="border-right: #999999 1px solid; border-top: #999999 1px solid; font-size: 10pt; border-left: #999999 1px solid; color: #0751b8; border-bottom: #999999 1px solid; font-family: arial; background-color: white"></PopupStyle>
</eo:ColorPicker>
<eo:SpellChecker id="SpellChecker1" runat="server" DialogID="SpellCheckerDialog1"></eo:SpellChecker>
<eo:SpellCheckerDialog id="SpellCheckerDialog1" Width="320px" Height="216px" runat="server" ControlSkinID="None"
    CloseButtonUrl="00070301" BackColor="#ECE9D8" HeaderHtml="Spell Checker">
    <FooterStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 8pt; padding-bottom: 4px; padding-top: 4px; font-family: tahoma"></FooterStyleActive>
    <HeaderStyleActive CssText="padding-right: 3px; padding-left: 8px; font-weight: bold; font-size: 10pt; background-image: url(00020113); padding-bottom: 3px; color: white; padding-top: 0px; font-family: 'trebuchet ms';height:20px;"></HeaderStyleActive>
    <ContentStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 8pt; padding-bottom: 4px; padding-top: 4px; font-family: tahoma"></ContentStyleActive>
    <BorderImages BottomBorder="00020112" RightBorder="00020111" TopRightCornerBottom="00020106" TopLeftCornerRight="00020102"
        TopRightCorner="00020104" LeftBorder="00020110" TopLeftCorner="00020101" BottomRightCorner="00020108"
        TopLeftCornerBottom="00020103" BottomLeftCorner="00020107" TopRightCornerLeft="00020105" TopBorder="00020109"></BorderImages>
</eo:SpellCheckerDialog>
</asp:Content>


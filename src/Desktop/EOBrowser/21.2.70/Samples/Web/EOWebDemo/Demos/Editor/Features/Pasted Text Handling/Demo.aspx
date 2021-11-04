<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Editor_Features_Pasted_Text_Handling_Demo"
    Title="Untitled Page" %>
<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
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
    <asp:RadioButtonList ID="tbFilter" AutoPostBack="True" RepeatDirection="Horizontal"
        runat="server" OnSelectedIndexChanged="tbFilter_SelectedIndexChanged">
        <asp:ListItem Value="None">None</asp:ListItem>
        <asp:ListItem Value="MsWordAuto" Selected="True">MsWordAuto</asp:ListItem>
        <asp:ListItem Value="MsWordWithConfirm">MsWordWithConfirm</asp:ListItem>
        <asp:ListItem Value="TextOnly">TextOnly</asp:ListItem>
        <asp:ListItem Value="TextWithLineBreak">TextWithLineBreak</asp:ListItem>
    </asp:RadioButtonList>
    <eo:Editor runat="server" ID="Editor1" Height="320px" ToolBarSet="Basic" HighlightColor="255, 255, 192"
        Width="500px" HtmlBodyCssClass="demo_editor_body" TextAreaCssFile="~\EOWebDemo.css"
        Html="<p>The Editor can automatically format/trim the pasted text when user uses Ctrl + V to copy and paste contents into the editor. To use this feature, set the Editor's <strong>PasteFilter</strong> to one of the following value:</p>&#13;&#10;<ul>&#13;&#10;    <li><strong>None</strong>. The text is pasted as is.</li>&#13;&#10;    <li><strong>MsWordAuto</strong>. The editor automatically checks whether the content is from Word, and if so, automatically cleans up unnecessary Word formatting code. </li>&#13;&#10;    <li><strong>MsWordWithConfirm</strong>. The editor automatically checks whether the content is from Word, and if so, automatically cleans up unnecessary Word formatting code.</li>&#13;&#10;    <li><strong>TextOnly</strong>. The editor automatically removes all HTML formatting.</li>&#13;&#10;    <li><strong>TextWithLineBreak</strong>. The editor automatically removes all HTML formatting, but keeps the line breaks.</li>&#13;&#10;</ul>&#13;&#10;"
        FileExplorerDialogID="FileExplorerDialog1" FileExplorerUrl="~/Demos/File Explorer/Explorer.aspx">
        <FooterStyle CssText="border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa">
        </FooterStyle>
        <BreadcrumbLabelStyle CssText="padding-right: 6px; padding-left: 6px; font-size: 12px; padding-top: 1px; font-family: tahoma">
        </BreadcrumbLabelStyle>
        <EditAreaStyle CssText="border-right: gray 1px solid; padding-right: 0px; border-top: gray 1px solid; padding-left: 0px; padding-bottom: 0px; border-left: gray 1px solid; padding-top: 0px; border-bottom: gray 1px solid">
        </EditAreaStyle>
        <HeaderStyle CssText="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; border-bottom: gray 1px">
        </HeaderStyle>
        <EmoticonStyle CssText="background-color:white;border-bottom-color:#c5d3ed;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#c5d3ed;border-left-style:solid;border-left-width:1px;border-right-color:#c5d3ed;border-right-style:solid;border-right-width:1px;border-top-color:#c5d3ed;border-top-style:solid;border-top-width:1px;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;">
        </EmoticonStyle>
        <BreadcrumbItemHoverStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma; background-color:#e0e0e0;">
        </BreadcrumbItemHoverStyle>
        <TabButtonStyles>
            <SelectedStyle CssText="border-right: #335ea8 1px solid; padding-right: 6px; border-top: #335ea8 1px solid; padding-left: 6px; font-size: 12px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; font-family: tahoma; background-color: white">
            </SelectedStyle>
            <NormalStyle CssText="border-right: #335ea8 1px; padding-right: 7px; border-top: #335ea8 1px; padding-left: 7px; font-size: 12px; padding-bottom: 3px; border-left: #335ea8 1px; padding-top: 3px; border-bottom: #335ea8 1px; font-family: tahoma; background-color: white">
            </NormalStyle>
            <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 6px; border-top: #335ea8 1px solid; padding-left: 6px; font-size: 12px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; font-family: tahoma; background-color: #c2cfe5">
            </HoverStyle>
        </TabButtonStyles>
        <BreadcrumbDropDownStyle CssText="border-top: gray 1px solid; border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa">
        </BreadcrumbDropDownStyle>
        <BreadcrumbItemSeparatorStyle CssText="width: 3px; height: 10px"></BreadcrumbItemSeparatorStyle>
        <EmoticonDropDownStyle CssText="border-top: gray 1px solid; border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa">
        </EmoticonDropDownStyle>
        <BreadcrumbItemStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma">
        </BreadcrumbItemStyle>
    </eo:Editor>
</asp:Content>

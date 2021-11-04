<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Editor_Features_Customizing_Dialogs_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<eo:Editor runat="server" id="Editor1" Width="500px" HighlightColor="255, 255, 192" Height="320px"
    ToolBarSet="Basic" HtmlBodyCssClass="demo_editor_body" Html="<p>This sample customizes both&amp;nbsp;the default&amp;nbsp;dialog template and individual dialogs. Click <i>Insert Image</i> or <i>Insert Link</i> button on the toolbar to view the modified dialogs.</p>&#13;&#10;<p>Property <strong>DialogTemplates</strong> property is used to customize the default dialog template, which is used to define the look and feel of all dialogs. </p>&#13;&#10;<p>Property <strong>DialogContents</strong> is used provide two custom dialogs: <strong>Insert&amp;nbsp;Link </strong>and <strong>Insert Image</strong>.</p>&#13;&#10;<p>Please see the sample source as well as related documentation for more details about this&amp;nbsp;feature.&amp;nbsp;</p>&#13;&#10;"
    TextAreaCssFile="~\EOWebDemo.css">
    <FooterStyle CssText="border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa"></FooterStyle>
    <BreadcrumbLabelStyle CssText="padding-right: 6px; padding-left: 6px; font-size: 12px; padding-top: 1px; font-family: tahoma"></BreadcrumbLabelStyle>
    <EditAreaStyle CssText="border-right: gray 1px solid; padding-right: 0px; border-top: gray 1px solid; padding-left: 0px; padding-bottom: 0px; border-left: gray 1px solid; padding-top: 0px; border-bottom: gray 1px solid"></EditAreaStyle>
    <DialogContents>
        <eo:EditorDialogContent CommandName="InsertOrEditLink">
            <ContentTemplate>
                <table cellSpacing="3" cellPadding="1" border="0">
                    <tr>
                        <td width="60px" nowrap="nowrap">Url:</td>
                        <td colspan="3">
                            <input type="text" name="eo_editor_insertlink_url" style="width:250px;" />
                        </td>
                    </tr>
                    <tr>
                        <td>Text:</td>
                        <td>
                            <input type="text" name="eo_editor_insertlink_text" style="width:250px;" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <input type="button" name="eo_editor_default_button" value="OK" style="width:80px;" onclick="eo_GetContainer(this, 'Editor').execDialogCommand('InsertOrEditLink', this, event);" />&nbsp;
                            <input type="button" value="Close" style="width:80px;" onclick="eo_GetContainer(this, 'Editor').closeDialog(this, event);" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </eo:EditorDialogContent>
        <eo:EditorDialogContent CommandName="InsertOrEditImage">
            <ContentTemplate>
                <table cellSpacing="3" cellPadding="1" border="0">
                    <tr>
                        <td width="60px" nowrap="nowrap">Url:</td>
                        <td colspan="3">
                            <input type="text" name="eo_editor_insertimage_url" style="width:250px;" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="4">
                            <input type="button" name="eo_editor_default_button" value="OK" style="width:80px;" onclick="eo_GetContainer(this, 'Editor').execDialogCommand('InsertOrEditImage', this, event);" />&nbsp;
                            <input type="button" value="Close" style="width:80px;" onclick="eo_GetContainer(this, 'Editor').closeDialog(this, event);" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </eo:EditorDialogContent>
    </DialogContents>
    <HeaderStyle CssText="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; border-bottom: gray 1px"></HeaderStyle>
    <EmoticonStyle CssText="background-color:white;border-bottom-color:#c5d3ed;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#c5d3ed;border-left-style:solid;border-left-width:1px;border-right-color:#c5d3ed;border-right-style:solid;border-right-width:1px;border-top-color:#c5d3ed;border-top-style:solid;border-top-width:1px;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;"></EmoticonStyle>
    <BreadcrumbItemHoverStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma; background-color:#e0e0e0;"></BreadcrumbItemHoverStyle>
    <TabButtonStyles>
        <SelectedStyle CssText="border-right: #335ea8 1px solid; padding-right: 6px; border-top: #335ea8 1px solid; padding-left: 6px; font-size: 12px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; font-family: tahoma; background-color: white"></SelectedStyle>
        <NormalStyle CssText="border-right: #335ea8 1px; padding-right: 7px; border-top: #335ea8 1px; padding-left: 7px; font-size: 12px; padding-bottom: 3px; border-left: #335ea8 1px; padding-top: 3px; border-bottom: #335ea8 1px; font-family: tahoma; background-color: white"></NormalStyle>
        <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 6px; border-top: #335ea8 1px solid; padding-left: 6px; font-size: 12px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; font-family: tahoma; background-color: #c2cfe5"></HoverStyle>
    </TabButtonStyles>
    <DialogTemplates>
        <eo:EditorDialogTemplate>
            <DialogTemplate>
                <eo:Dialog runat="server" id="Dialog1" Width="168px" BorderWidth="1px" BorderStyle="Solid"
                    ControlSkinID="None" BorderColor="#728EB8" HeaderHtml="Dialog title" BackColor="White"
                    CloseButtonUrl="00070201">
                    <HeaderStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; background-image: url(00070202); padding-bottom: 2px; padding-top: 2px; font-family: arial"></HeaderStyleActive>
                    <ContentStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 11px; padding-bottom: 4px; padding-top: 4px; font-family: verdana; background-color: #f8fafd"></ContentStyleActive>
                </eo:Dialog>
            </DialogTemplate>
        </eo:EditorDialogTemplate>
    </DialogTemplates>
    <BreadcrumbDropDownStyle CssText="border-top: gray 1px solid; border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa"></BreadcrumbDropDownStyle>
    <BreadcrumbItemSeparatorStyle CssText="width: 3px; height: 10px"></BreadcrumbItemSeparatorStyle>
    <EmoticonDropDownStyle CssText="border-top: gray 1px solid; border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa"></EmoticonDropDownStyle>
    <BreadcrumbItemStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma"></BreadcrumbItemStyle>
</eo:Editor>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_AJAX_Uploader_Upload_From_ToolBar_Demo"
    Title="Untitled Page" %>

<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">

    <script type="text/javascript">
function uploader_start()
{
    document.getElementById("uploader_div").style.display = "block";
}

function uploader_stop()
{
    document.getElementById("uploader_div").style.display = "none";
}
    </script>

    <p>
        EO.Web AJAXUploader can be used together with an EO.Web.ToolBar control so that
        user will be able to click a ToolBar button to start the upload. The following sample
        demonstrates this feature. Click <strong>Attachments</strong> button to start upload.
    </p>
    <p>
        See remark section for more details.
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
    <eo:Editor runat="server" ID="Editor1" Height="270px" ToolBarSet="Basic" HighlightColor="255, 255, 192"
        Width="500px" FileExplorerDialogID="FileExplorerDialog1" FileExplorerUrl="~/Demos/File Explorer/Explorer.aspx"
        OnSave="Editor1_Save">
        <BreadcrumbItemStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma">
        </BreadcrumbItemStyle>
        <CustomFooterTemplate>
            <div>
                <div style="float: left; width: 200px">
                    <asp:PlaceHolder ID="ViewTabs" runat="server"></asp:PlaceHolder>
                </div>
                <div>
                    <asp:PlaceHolder ID="Breadcrumb" runat="server"></asp:PlaceHolder>
                </div>
            </div>
            <eo:AJAXPostedFileList ID="AJAXPostedFileList1" runat="server">
            </eo:AJAXPostedFileList>
            <eo:CallbackPanel runat="server" ID="CallbackPanel1" Triggers="{ControlID:AJAXUploader1;Parameter:},{ControlID:Repeater1;Parameter:}"
                Style="clear: both">
                <asp:Panel runat="server" ID="Panel1" Visible="False">
                    Attachments:
                    <asp:Repeater runat="server" ID="Repeater1" OnItemDataBound="Repeater1_ItemDataBound"
                        OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblFileName"></asp:Label>
                            (
                            <asp:LinkButton runat="server" ID="lblDelete">Delete</asp:LinkButton>)&nbsp;&nbsp;
                        </ItemTemplate>
                    </asp:Repeater>
                </asp:Panel>
            </eo:CallbackPanel>
            <div id="uploader_div" style="display: none">
                <eo:AJAXUploader ID="AJAXUploader1" Width="492px" runat="server" AutoUpload="True"
                    HideDisabledToolBarButton="True" TempFileLocation="~/eo_upload" FinalFileLocation="~/eo_upload"
                    ClientSideOnStart="uploader_start" ClientSideOnDone="uploader_stop" ClientSideOnCancel="uploader_stop"
                    FinalFileList="AJAXPostedFileList1" AutoPostBack="True" OnFileUploaded="AJAXUploader1_FileUploaded">
                    <LayoutTemplate>
                        <table cellspacing="0" cellpadding="2" width="492" border="0">
                            <tr>
                                <td style="padding-top: 5px">
                                    <eo:ProgressBar ID="ProgressBar" runat="server" ControlSkinID="Windows_XP">
                                    </eo:ProgressBar>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:PlaceHolder ID="ProgressTextPlaceHolder" runat="server">Progress Text Place Holder
                                    </asp:PlaceHolder>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                </eo:AJAXUploader>
            </div>
        </CustomFooterTemplate>
        <BreadcrumbItemHoverStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma; background-color:#e0e0e0;">
        </BreadcrumbItemHoverStyle>
        <EmoticonDropDownStyle CssText="border-top: gray 1px solid; border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa">
        </EmoticonDropDownStyle>
        <BreadcrumbLabelStyle CssText="padding-right: 6px; padding-left: 6px; font-size: 12px; padding-top: 1px; font-family: tahoma">
        </BreadcrumbLabelStyle>
        <BreadcrumbItemSeparatorStyle CssText="width: 3px; height: 10px"></BreadcrumbItemSeparatorStyle>
        <HeaderStyle CssText="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; border-bottom: gray 1px">
        </HeaderStyle>
        <CustomHeaderTemplate>
            <eo:ToolBar ID="ToolBar1" Width="100%" runat="server" SeparatorImage="00100104" BackgroundImageLeft="00100101"
                BackgroundImage="00100103" BackgroundImageRight="00100102">
                <DownStyle CssText="border-right: #335ea8 1px solid; padding-right: 2px; border-top: #335ea8 1px solid; padding-left: 4px; padding-bottom: 1px; border-left: #335ea8 1px solid; padding-top: 3px; border-bottom: #335ea8 1px solid; background-color: #99afd4; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;">
                </DownStyle>
                <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 3px; border-top: #335ea8 1px solid; padding-left: 3px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; background-color: #c2cfe5; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;">
                </HoverStyle>
                <NormalStyle CssText="padding-right: 4px; padding-left: 4px; padding-bottom: 3px; border-top-style: none; padding-top: 3px; border-right-style: none; border-left-style: none; border-bottom-style: none; cursor:hand; FONT-SIZE: 12px; FONT-FAMILY: Tahoma;">
                </NormalStyle>
                <ItemTemplates>
                    <eo:ToolBarItem Type="Custom">
                        <HoverStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;">
                        </HoverStyle>
                        <DownStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;">
                        </DownStyle>
                        <NormalStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;">
                        </NormalStyle>
                    </eo:ToolBarItem>
                    <eo:ToolBarItem Type="DropDownMenu">
                        <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 3px; border-top: #335ea8 1px solid; padding-left: 3px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; background-color: #c2cfe5; cursor:hand; background-image: url(00100106); background-position-x: right;">
                        </HoverStyle>
                        <DownStyle CssText="border-right: #335ea8 1px solid; padding-right: 2px; border-top: #335ea8 1px solid; padding-left: 4px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 3px; border-bottom: none; background-color:transparent; cursor:hand; background-image: url(00100105); background-position-x: right;">
                        </DownStyle>
                        <NormalStyle CssText="padding-right: 4px; padding-left: 4px; padding-bottom: 3px; border-top-style: none; padding-top: 3px; border-right-style: none; border-left-style: none; border-bottom-style: none; cursor:hand; background-image: url(00100105); background-position-x: right;">
                        </NormalStyle>
                    </eo:ToolBarItem>
                </ItemTemplates>
                <Items>
                    <eo:ToolBarItem Text="Save" ToolTip="Save" ImageUrl="00101003" CommandName="Save">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem Type="Separator">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem ToolTip="Align Left" ImageUrl="00101014" CommandName="AlignLeft">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem ToolTip="Align Center" ImageUrl="00101015" CommandName="AlignCenter">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem ToolTip="Align Right" ImageUrl="00101016" CommandName="AlignRight">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem ToolTip="Align Justify" ImageUrl="00101017" CommandName="AlignJustify">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem Type="Separator">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem ToolTip="Bullet List" ImageUrl="00101019" CommandName="BulletList">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem ToolTip="Numbered List" ImageUrl="00101020" CommandName="NumberedList">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem Type="Separator">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem ToolTip="Insert Link" ImageUrl="00101021" CommandName="InsertOrEditLink">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem ToolTip="Insert Image" ImageUrl="00101033" CommandName="InsertOrEditImage">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem Type="Separator">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem Text="Attachments" ToolTip="Attachments" ImageUrl="00101059" CommandName="Upload">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem Text="Cancel Upload" ToolTip="Cancel Upload" ImageUrl="00101059"
                        CommandName="CancelUpload">
                    </eo:ToolBarItem>
                </Items>
            </eo:ToolBar>
        </CustomHeaderTemplate>
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
</asp:Content>

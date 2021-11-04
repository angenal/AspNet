<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Designs_Windows_Vista_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:Menu runat="server" id="Menu1" SubMenuPositionConfine="None" ControlSkinID="None" Width="300px">
    <TopGroup Style-CssText="background-image:url(00000200);color:white;font-family:Verdana;font-size:12px;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;">
        <Items>
            <eo:MenuItem LeftIcon-Url="00000201" Text-Html="Organize">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="New Folder"></eo:MenuItem>
                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00000206" Text-Html="Cut"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00000205" Text-Html="Copy"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00000207" Text-Html="Paste"></eo:MenuItem>
                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Layout">
                            <SubMenu>
                                <Items>
                                    <eo:MenuItem LeftIcon-Url="00000211" Text-Html="Search Pane"></eo:MenuItem>
                                    <eo:MenuItem LeftIcon-Url="00000212" Text-Html="Details Pane"></eo:MenuItem>
                                    <eo:MenuItem LeftIcon-Url="00000213" Text-Html="Preview Pane"></eo:MenuItem>
                                    <eo:MenuItem LeftIcon-Url="00000214" Text-Html="Navigation Pane"></eo:MenuItem>
                                </Items>
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Folder and Search Options"></eo:MenuItem>
                        <eo:MenuItem LeftIcon-Url="00000208" Text-Html="Delete"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Remove Properties"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Properties"></eo:MenuItem>
                        <eo:MenuItem IsSeparator="True"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Close"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem LeftIcon-Url="00000202" Text-Html="Explore"></eo:MenuItem>
            <eo:MenuItem LeftIcon-Url="00000203" Text-Html="Share"></eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem HoverStyle-CssText="border-bottom-color:#255068;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#255068;border-left-style:solid;border-left-width:1px;border-right-color:#255068;border-right-style:solid;border-right-width:1px;border-top-color:#255068;border-top-style:solid;border-top-width:1px;padding-bottom:3px;padding-left:4px;padding-right:4px;padding-top:3px;"
            ItemID="_TopLevelItem" NormalStyle-CssText="padding-bottom:4px;padding-left:5px;padding-right:5px;padding-top:4px;"
            Image-Url="Blank" Image-HoverUrl="00000210" Image-Mode="ItemBackground">
            <SubMenu Style-CssText="background-color:#f1f1f1;border-bottom-color:#979797;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#979797;border-left-style:solid;border-left-width:1px;border-right-color:#979797;border-right-style:solid;border-right-width:1px;border-top-color:#979797;border-top-style:solid;border-top-width:1px;cursor:hand;font-family:Verdana;font-size:8pt;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;"
                SideImage="00000209" LeftIconCellWidth="28" ItemSpacing="2"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="margin-left: 28px; width: 1px; height: 1px; background-color: #e0e0e0;"></eo:MenuItem>
        <eo:MenuItem Height="24" HoverStyle-CssText="border-right: #a8d8eb 1px solid; padding-right: 4px; border-top: #a8d8eb 1px solid; padding-left: 1px; padding-bottom: 1px; border-left: #a8d8eb 1px solid; padding-top: 1px; border-bottom: #a8d8eb 1px solid"
            ItemID="_Default" NormalStyle-CssText="padding-right: 5px; padding-left: 2px; padding-bottom: 2px; padding-top: 2px;"
            Image-Url="Blank" Image-HoverUrl="00000204" Image-Mode="ItemBackground" Text-Padding-Right="30">
            <SubMenu Style-CssText="background-color:#f1f1f1;border-bottom-color:#979797;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#979797;border-left-style:solid;border-left-width:1px;border-right-color:#979797;border-right-style:solid;border-right-width:1px;border-top-color:#979797;border-top-style:solid;border-top-width:1px;cursor:hand;font-family:Verdana;font-size:8pt;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;"
                SideImage="00000209" LeftIconCellWidth="28" ItemSpacing="2"></SubMenu>
        </eo:MenuItem>
    </LookItems>
</eo:Menu>
</asp:Content>


<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Menu_Demo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <table height="300">
        <tr>
            <td valign="top">
                <eo:Menu runat="server" ID="Menu1" ControlSkinID="None" CheckIconUrl="OfficeCheckIcon2"
                    Width="200px">
                    <TopGroup Style-CssText="background-color:#ABC7F6;">
                        <Items>
                            <eo:MenuItem Text-Html="Format">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem Text-Html="Styles...">
                                        </eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00000101" Text-Html="Foreground Color...">
                                        </eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00000100" Text-Html="Background Color...">
                                        </eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True">
                                        </eo:MenuItem>
                                        <eo:MenuItem Text-Html="Font">
                                            <SubMenu ItemSpacing="3">
                                                <Items>
                                                    <eo:MenuItem Text-Html="Bold" Checked="True">
                                                    </eo:MenuItem>
                                                    <eo:MenuItem Text-Html="Italic">
                                                    </eo:MenuItem>
                                                    <eo:MenuItem Text-Html="Underline">
                                                    </eo:MenuItem>
                                                </Items>
                                            </SubMenu>
                                        </eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True">
                                        </eo:MenuItem>
                                        <eo:MenuItem Text-Html="Horizontal Spacing">
                                        </eo:MenuItem>
                                        <eo:MenuItem Text-Html="Vertical Spacing">
                                        </eo:MenuItem>
                                        <eo:MenuItem IsSeparator="True">
                                        </eo:MenuItem>
                                        <eo:MenuItem Text-Html="Order">
                                        </eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                            <eo:MenuItem Text-Html="Layout">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem Text-Html="More Items">
                                        </eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                        </Items>
                    </TopGroup>
                    <LookItems>
                        <eo:MenuItem DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:1px;color:gray"
                            Height="24" HoverStyle-CssText="background-color:#C0D6F4;border-bottom-color:#000080;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#000080;border-left-style:solid;border-left-width:1px;border-right-color:#000080;border-right-style:solid;border-right-width:1px;border-top-color:#000080;border-top-style:solid;border-top-width:1px;padding-left:4px;padding-right:4px;padding-top:0px;padding-bottom:0px;"
                            ItemID="_TopLevelItem" NormalStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:1px;"
                            SelectedStyle-CssText="background-color:white;border-bottom-color:#000080;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#000080;border-left-style:solid;border-left-width:1px;border-right-color:#000080;border-right-style:solid;border-right-width:1px;border-top-color:#000080;border-top-style:solid;border-top-width:1px;padding-left:4px;padding-right:4px;padding-top:0px;padding-bottom:0px;">
                            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="background-color:#F6F6F6;border-bottom-color:#002D96;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#002D96;border-left-style:solid;border-left-width:1px;border-right-color:#002D96;border-right-style:solid;border-right-width:1px;border-top-color:#002D96;border-top-style:solid;border-top-width:1px;color:black;cursor:hand;font-family:Tahoma;font-size:8pt;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
                                CollapseEffect-Type="GlideTopToBottom" SideImage="Office2003SideBar2" LeftIconCellWidth="25"
                                ItemSpacing="3">
                            </SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="background-color:#6A8CCB;height:1px;margin-left:30px;width:1px;">
                        </eo:MenuItem>
                        <eo:MenuItem DisabledStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:5px;padding-top:1px;color:gray"
                            Height="24" HoverStyle-CssText="background-color:#FFEEC2;border-bottom-color:#000080;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#000080;border-left-style:solid;border-left-width:1px;border-right-color:#000080;border-right-style:solid;border-right-width:1px;border-top-color:#000080;border-top-style:solid;border-top-width:1px;padding-left:1px;padding-right:4px;padding-top:0px;"
                            ItemID="_Default" NormalStyle-CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:5px;padding-top:1px;"
                            SelectedStyle-CssText="background-color:white;border-bottom-color:#000080;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#000080;border-left-style:solid;border-left-width:1px;border-right-color:#000080;border-right-style:solid;border-right-width:1px;border-top-color:#000080;border-top-style:solid;border-top-width:1px;padding-left:1px;padding-right:4px;padding-top:0px;"
                            Text-Padding-Right="30">
                            <SubMenu ExpandEffect-Type="GlideTopToBottom" Style-CssText="background-color:#F6F6F6;border-bottom-color:#002D96;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#002D96;border-left-style:solid;border-left-width:1px;border-right-color:#002D96;border-right-style:solid;border-right-width:1px;border-top-color:#002D96;border-top-style:solid;border-top-width:1px;color:black;cursor:hand;font-family:Tahoma;font-size:8pt;padding-bottom:1px;padding-left:1px;padding-right:1px;padding-top:1px;"
                                CollapseEffect-Type="GlideTopToBottom" SideImage="Office2003SideBar2" LeftIconCellWidth="25"
                                ItemSpacing="3">
                            </SubMenu>
                        </eo:MenuItem>
                    </LookItems>
                </eo:Menu>
            </td>
            <td width="30">
            </td>
            <td valign="top">
                <p>
                    EO.Web Menu is one of the most sophisticated and versatile ASP.NET Menu on the market.
                    There are many other samples available demonstrating different features. Please
                    use the tree on the left side to navigate the demos. Key features include:
                </p>
                <ul>
                    <li>Cross browser support;</li>
                    <li>Powerful Menu Builder with preview;</li>
                    <li>Support look, skin &amp; theme. Various pre-built designs to choose from;</li>
                    <li>Extensive CSS style and image support;</li>
                    <li>60+ Expand/Collapse effects;</li>
                    <li>Data binding support;</li>
                    <li>Transparent cross frame support;</li>
                    <li>Complete client side JavaScript interface;</li>
                    <li>Full keyboard navigation&nbsp;and&nbsp;short cut support;</li>
                    <li>And much more...</li>
                </ul>
            </td>
        </tr>
    </table>
</asp:Content>

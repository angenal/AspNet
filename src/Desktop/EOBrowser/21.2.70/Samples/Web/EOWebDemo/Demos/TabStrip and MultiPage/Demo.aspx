<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_TabStrip_and_MultiPage_Demo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td valign="top">
                <eo:TabStrip runat="server" ID="TabStrip1" RowSpacing="-3" ControlSkinID="None" Width="400px"
                    MultiRow="True" MultiPageID="MultiPage1">
                    <TopGroup>
                        <Items>
                            <eo:TabItem Width="120" Text-Html="General">
                            </eo:TabItem>
                            <eo:TabItem Width="153" Text-Html="Computer Name">
                            </eo:TabItem>
                            <eo:TabItem Width="124" Text-Html="Hardware">
                            </eo:TabItem>
                            <eo:TabItem Width="124" Text-Html="Advanced">
                            </eo:TabItem>
                            <eo:TabItem Width="163" Text-Html="Automatic Updates">
                            </eo:TabItem>
                            <eo:TabItem Width="110" Text-Html="Remote">
                            </eo:TabItem>
                        </Items>
                    </TopGroup>
                    <LookItems>
                        <eo:TabItem Height="21" HoverStyle-CssText="position: relative; top: 2px; background-image: url(00010002); background-repeat: repeat-x"
                            ItemID="_Default" RightIcon-Url="00010005" RightIcon-SelectedUrl="00010009" RightIcon-HoverUrl="00010007"
                            NormalStyle-CssText="position: relative; top: 2px; background-image: url(00010001); background-repeat: repeat-x"
                            SelectedStyle-CssText="background-image: url(00010003); background-repeat: repeat-x"
                            LeftIcon-Url="00010004" LeftIcon-SelectedUrl="00010008" LeftIcon-HoverUrl="00010006"
                            Text-Padding-Top="1" Text-Padding-Bottom="2">
                            <SubGroup Style-CssText="background-image:url(00010000);background-position-y:bottom;background-repeat:repeat-x;color:black;cursor:hand;font-family:'Microsoft Sans Serif', Verdana;font-size:8.25pt;"
                                ItemSpacing="1">
                            </SubGroup>
                        </eo:TabItem>
                    </LookItems>
                </eo:TabStrip>
            </td>
            <td rowspan="2" valign="top" style="padding-left: 20px;">
                <p>
                    EO.TabStrip implements a tabbed UI for ASP.NET. Feature highlights include:
                </p>
                <ul>
                    <li>Supports all popular browsers: IE 6.0+, FireFox 1.0+, Mozilla 1.3+, Opera 7.2+,
                        Safari 1.3+ and Chrome; </li>
                    <li>Preview the TabStrip at design time instead of constantly switching between design
                        time and run time to see the result; </li>
                    <li>Allows you to easily create and apply appearance template. Also with various pre-built
                        design templates to choose from; </li>
                    <li>Supports different styles for normal, hover, selected and disabled state. Each can
                        use different left icon, right icon or background images; </li>
                    <li>Intuitive solution to create overlapping tabs by setting a single property instead
                        of creating a set of customized images with overlapping effect. The TabStrip automatically
                        generates such overlapping images for you; </li>
                    <li>Handle click event, show/hide tab item or switching pages can all be done on the
                        client side through JavaScript; </li>
                </ul>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <eo:MultiPage runat="server" ID="MultiPage1">
                    <eo:PageView ID="PageView1" runat="server">
                        <asp:Image ID="Image1" ImageUrl="~/Images/sys_prop_general.gif" runat="server"></asp:Image>
                    </eo:PageView>
                    <eo:PageView ID="Pageview2" runat="server">
                        <asp:Image ID="Image2" ImageUrl="~/Images/sys_prop_computer_name.gif" runat="server">
                        </asp:Image>
                    </eo:PageView>
                    <eo:PageView ID="Pageview3" runat="server">
                        <asp:Image ID="Image3" ImageUrl="~/Images/sys_prop_hardware.gif" runat="server">
                        </asp:Image>
                    </eo:PageView>
                    <eo:PageView ID="Pageview4" runat="server">
                        <asp:Image ID="Image4" ImageUrl="~/Images/sys_prop_advanced.gif" runat="server">
                        </asp:Image>
                    </eo:PageView>
                    <eo:PageView ID="Pageview5" runat="server">
                        <asp:Image ID="Image5" ImageUrl="~/Images/sys_prop_automatic_update.gif" runat="server">
                        </asp:Image>
                    </eo:PageView>
                    <eo:PageView ID="Pageview6" runat="server">
                        <asp:Image ID="Image6" ImageUrl="~/Images/sys_prop_remote.gif" runat="server"></asp:Image>
                    </eo:PageView>
                </eo:MultiPage>
            </td>
        </tr>
    </table>
</asp:Content>

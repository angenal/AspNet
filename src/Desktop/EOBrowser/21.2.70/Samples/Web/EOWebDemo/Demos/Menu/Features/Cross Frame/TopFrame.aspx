<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TopFrame.aspx.cs" Inherits="Demos_Menu_Features_Cross_Frame_TopFrame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link runat="server" href="~/EOWebDemo.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <p class="normal">
            A horizontal cross frame menu. Sub menu of menu item "Navigate" is rendered into
            the content frame.
        </p>
        <eo:Menu runat="server" ID="Menu1" Style="z-index: 101; position: absolute; top: 40px"
            ControlSkinID="None" Width="100%" TargetFrame="main">
            <TopGroup>
                <Items>
                    <eo:MenuItem LookID="None" HoverStyle-CssText="" ItemID="spacer" NormalStyle-CssText=""
                        Width="150" Text-Html="">
                    </eo:MenuItem>
                    <eo:MenuItem Text-Html="Home">
                    </eo:MenuItem>
                    <eo:MenuItem Text-Html="Navigate">
                        <SubMenu>
                            <Items>
                                <eo:MenuItem NavigateUrl="Content1.htm" Text-Html="To a regular HTML document">
                                </eo:MenuItem>
                                <eo:MenuItem NavigateUrl="Content2.aspx" Text-Html="To an ASP.NET page">
                                </eo:MenuItem>
                                <eo:MenuItem NavigateUrl="Content3.aspx" Text-Html="To an Adobe .PDF file">
                                </eo:MenuItem>
                            </Items>
                        </SubMenu>
                    </eo:MenuItem>
                    <eo:MenuItem Text-Html="Products">
                        <SubMenu>
                            <Items>
                                <eo:MenuItem ItemID="item3" Text-Html="Model 1">
                                    <SubMenu>
                                        <Items>
                                            <eo:MenuItem Text-Html="Model 1">
                                            </eo:MenuItem>
                                            <eo:MenuItem Text-Html="Model 2">
                                            </eo:MenuItem>
                                        </Items>
                                    </SubMenu>
                                </eo:MenuItem>
                                <eo:MenuItem ItemID="item4" Text-Html="Product 2">
                                </eo:MenuItem>
                                <eo:MenuItem ItemID="item5" Text-Html="Product 3">
                                </eo:MenuItem>
                            </Items>
                        </SubMenu>
                    </eo:MenuItem>
                    <eo:MenuItem ItemID="item1" Text-Html="Support">
                        <SubMenu>
                            <Items>
                                <eo:MenuItem ItemID="item6" Text-Html="Contact Us">
                                </eo:MenuItem>
                            </Items>
                        </SubMenu>
                    </eo:MenuItem>
                    <eo:MenuItem ItemID="item2" Text-Html="About Us">
                    </eo:MenuItem>
                </Items>
            </TopGroup>
            <LookItems>
                <eo:MenuItem IsSeparator="True" ItemID="_Separator" NormalStyle-CssText="width: 1px; height: 1px; background-color: gray; margin: 2px">
                </eo:MenuItem>
                <eo:MenuItem DisabledStyle-CssText="background-color: transparent; border-right-style: none; padding-right: 5px; padding-left: 5px; padding-bottom: 2px; padding-top: 2px; border-top-style: none; border-left-style: none; border-bottom-style: none; color: gray"
                    HoverStyle-CssText="background-color: #cccccc; border-right: #999999 1px solid; padding-right: 4px; border-top: #999999 1px solid; padding-top: 1px; border-left: #999999 1px solid; padding-left: 4px; border-bottom: #999999 1px solid; padding-bottom: 1px; "
                    ItemID="_Default" NormalStyle-CssText="background-color: transparent; border-right-style: none; padding-right: 5px; padding-left: 5px; padding-bottom: 2px; padding-top: 2px; border-top-style: none; border-left-style: none; border-bottom-style: none; color: black"
                    SelectedStyle-CssText="BORDER-RIGHT: #999999 1px solid; PADDING-RIGHT: 4px; BORDER-TOP: #999999 1px solid; PADDING-LEFT: 4px; PADDING-BOTTOM: 1px; BORDER-LEFT: #999999 1px solid; PADDING-TOP: 1px; BORDER-BOTTOM: #999999 1px solid; BACKGROUND-COLOR: white; ">
                    <SubMenu Style-CssText="font-size: 9pt; font-family: Verdana; color: black; cursor: hand; background-color: #f1f1f1; border-right: #999999 1px solid; border-top: #999999 1px solid; border-left: #999999 1px solid; border-bottom: #999999 1px solid; padding-right: 2px; padding-left: 2px; padding-bottom: 2px; padding-top: 2px"
                        LeftIconCellWidth="12" ItemSpacing="3">
                    </SubMenu>
                </eo:MenuItem>
            </LookItems>
        </eo:Menu>
    </form>
</body>
</html>

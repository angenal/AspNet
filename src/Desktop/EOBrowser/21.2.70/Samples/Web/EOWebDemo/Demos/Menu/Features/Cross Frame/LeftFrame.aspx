<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeftFrame.aspx.cs" Inherits="Demos_Menu_Features_Cross_Frame_LeftFrame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link runat="server" href="~/EOWebDemo.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <p class="normal">
            A cross frame slide menu with two sub menus rendering into the target frame.
        </p>
        <eo:SlideMenu runat="server" ID="SlideMenu1" SingleExpand="False" ControlSkinID="None"
            Width="100%" TargetFrame="main">
            <TopGroup Style-CssText="color:Black;cursor:hand;font-family:verdana;font-size:12px;">
                <Items>
                    <eo:MenuItem Text-Html="Category 1">
                        <SubMenu>
                            <Items>
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
                                <eo:MenuItem Text-Html="Child Item 1">
                                </eo:MenuItem>
                                <eo:MenuItem Text-Html="Child Item 2">
                                </eo:MenuItem>
                            </Items>
                        </SubMenu>
                    </eo:MenuItem>
                    <eo:MenuItem Text-Html="Category 2">
                        <SubMenu>
                            <Items>
                                <eo:MenuItem Text-Html="Sub Category 1">
                                    <SubMenu>
                                        <Items>
                                            <eo:MenuItem ItemID="item1" Text-Html="Child Item 1">
                                            </eo:MenuItem>
                                            <eo:MenuItem ItemID="item2" Text-Html="Child Item 2">
                                            </eo:MenuItem>
                                        </Items>
                                    </SubMenu>
                                </eo:MenuItem>
                                <eo:MenuItem Text-Html="Child Item 1">
                                </eo:MenuItem>
                                <eo:MenuItem Text-Html="Child Item 2">
                                </eo:MenuItem>
                            </Items>
                        </SubMenu>
                    </eo:MenuItem>
                    <eo:MenuItem Text-Html="Category 3">
                        <SubMenu>
                            <Items>
                                <eo:MenuItem Text-Html="Child Item 1">
                                </eo:MenuItem>
                                <eo:MenuItem Text-Html="Child Item 2">
                                </eo:MenuItem>
                                <eo:MenuItem Text-Html="Child Item 3">
                                </eo:MenuItem>
                            </Items>
                        </SubMenu>
                    </eo:MenuItem>
                </Items>
            </TopGroup>
            <LookItems>
                <eo:MenuItem Height="22" HoverStyle-CssText="background-color:#CCCCCC;color:white;padding-left:5px;"
                    ItemID="_TopLevelItem" ExpandedStyle-CssText="background-color:#CCCCCC;color:white;padding-left:5px;"
                    NormalStyle-CssText="background-color:#CCCCCC;color:Black;padding-left:5px;"
                    LeftIcon-Url="00020009" LeftIcon-ExpandedUrl="00020008">
                    <SubMenu Style-CssText="font-family:Arial;font-size:12px;font-weight:bold;" ItemSpacing="1">
                    </SubMenu>
                </eo:MenuItem>
                <eo:MenuItem Height="22" HoverStyle-CssText="background-color:#cccccc;color:White;padding-left:15px;"
                    ItemID="_Default" NormalStyle-CssText="background-color:#F0F0F0;color:black;padding-left:15px;">
                    <SubMenu Style-CssText="color:Black;cursor:hand;font-family:verdana;font-size:12px;">
                    </SubMenu>
                </eo:MenuItem>
            </LookItems>
        </eo:SlideMenu>
    </form>
</body>
</html>

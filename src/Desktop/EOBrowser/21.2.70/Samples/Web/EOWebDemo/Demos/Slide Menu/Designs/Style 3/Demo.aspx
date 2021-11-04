<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Slide_Menu_Designs_Style_3_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:SlideMenu runat="server" id="SlideMenu1" SingleExpand="False" ControlSkinID="None" Width="220px">
    <TopGroup>
        <Items>
            <eo:MenuItem Text-Html="My Account">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="email and password"></eo:MenuItem>
                        <eo:MenuItem Text-Html="my address book"></eo:MenuItem>
                        <eo:MenuItem Text-Html="Shipping preferences"></eo:MenuItem>
                        <eo:MenuItem Text-Html="subscriptions"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem Text-Html="My Orders">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="order status"></eo:MenuItem>
                        <eo:MenuItem Text-Html="most recent orders"></eo:MenuItem>
                        <eo:MenuItem Text-Html="orders in past 6 months"></eo:MenuItem>
                        <eo:MenuItem Text-Html="all orders"></eo:MenuItem>
                        <eo:MenuItem Text-Html="returns"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem Text-Html="My Support">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="customer support"></eo:MenuItem>
                        <eo:MenuItem Text-Html="community forum"></eo:MenuItem>
                        <eo:MenuItem Text-Html="service contract"></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem ItemID="_TopGroup">
            <SubMenu Style-CssText="border-right: #beb6a4 1px solid; font-weight: bold; font-size: 12px; border-left: #beb6a4 1px solid; cursor: hand; color: #4a4a44; font-family: verdana"
                LeftIconCellWidth="10"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem Height="30" ItemID="_TopLevelItem" Image-Url="00000600" Image-Mode="ItemBackground">
            <SubMenu Style-CssText="color:#555544;font-family:Verdana;font-size:12px;font-weight:normal;"
                LeftIconCellWidth="10"></SubMenu>
        </eo:MenuItem>
        <eo:MenuItem Height="34" ItemID="_Default" Image-Url="00000601" Image-HoverUrl="00000602" Image-Mode="ItemBackground"></eo:MenuItem>
    </LookItems>
</eo:SlideMenu>
</asp:Content>


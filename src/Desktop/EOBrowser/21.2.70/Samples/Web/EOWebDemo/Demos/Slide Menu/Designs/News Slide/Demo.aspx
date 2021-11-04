<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Slide_Menu_Designs_News_Slide_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<eo:SlideMenu runat="server" id="SlideMenu1" SlidePaneHeight="80" ControlSkinID="None" Width="160px">
    <TopGroup Style-CssText="font-size: 12px; cursor: hand; font-family: arial">
        <Items>
            <eo:MenuItem Text-Html="News Headline 1">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="&lt;b&gt;Breaking News&lt;/b&gt;: any &lt;font color=&quot;red&quot;&gt;HTML&lt;/font&gt; code here."></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem Text-Html="News Headline 2">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="&lt;b&gt;Breaking News&lt;/b&gt;: any &lt;font color=&quot;red&quot;&gt;HTML&lt;/font&gt; code here."></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem Text-Html="News Headline 3">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="&lt;b&gt;Breaking News&lt;/b&gt;: any &lt;font color=&quot;red&quot;&gt;HTML&lt;/font&gt; code here."></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
            <eo:MenuItem Text-Html="News Headline 4">
                <SubMenu>
                    <Items>
                        <eo:MenuItem Text-Html="&lt;b&gt;Breaking News&lt;/b&gt;: any &lt;font color=&quot;red&quot;&gt;HTML&lt;/font&gt; code here."></eo:MenuItem>
                    </Items>
                </SubMenu>
            </eo:MenuItem>
        </Items>
    </TopGroup>
    <LookItems>
        <eo:MenuItem Height="22" ItemID="_TopLevelItem" NormalStyle-CssText="background-color:White;border-bottom-color:#dddddd;border-bottom-style:solid;border-bottom-width:1px;color:#000099;"
            SelectedStyle-CssText="background-color:#CDE6F7;color:#000099;" LeftIcon-Url="00020007" LeftIcon-ExpandedUrl="00020006"></eo:MenuItem>
        <eo:MenuItem ItemID="_Default" Text-NoWrap="False" Text-Padding-Left="20"></eo:MenuItem>
    </LookItems>
</eo:SlideMenu>
</asp:Content>


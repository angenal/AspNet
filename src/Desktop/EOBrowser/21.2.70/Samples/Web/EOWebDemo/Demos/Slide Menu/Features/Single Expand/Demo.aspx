<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Slide_Menu_Features_Single_Expand_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    An EO.Web Slide Menu can be set to only allow one expanded pane at any given 
    time or each pane can expand independently. Use <span class="highlight">SingleExpand</span>
    to control whether the slide menu should only have one expanded pane. The following sample
    uses a <span class="highlight">CallbackPanel</span> to toggle SingleExpand property.
</p>
<eo:CallbackPanel runat="server" id="CallbackPanel1" Triggers="{ControlID:btnSwitch;Parameter:}">
    <TABLE cellPadding="5" border="0">
        <TR>
            <TD vAlign="top">
                <eo:SlideMenu id="SlideMenu1" runat="server" Width="195px" ControlSkinID="None" SlidePaneHeight="130">
                    <TopGroup>
                        <Items>
                            <eo:MenuItem Text-Html="CD Writing Tasks">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem LeftIcon-Url="00000011" Text-Html="Write these files to CD"></eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                            <eo:MenuItem Text-Html="File and Folder Tasks">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem LeftIcon-Url="00000007" Text-Html="Make a new folder"></eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00000008" Text-Html="Publish this folder to the &lt;br&gt; Web"></eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00000009" Text-Html="Share this folder"></eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                            <eo:MenuItem Text-Html="Other Places">
                                <SubMenu>
                                    <Items>
                                        <eo:MenuItem LeftIcon-Url="00000005" Text-Html="My Computer"></eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00000004" Text-Html="My Documents"></eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00000010" Text-Html="Shared Documents"></eo:MenuItem>
                                        <eo:MenuItem LeftIcon-Url="00000006" Text-Html="My Network Places"></eo:MenuItem>
                                    </Items>
                                </SubMenu>
                            </eo:MenuItem>
                        </Items>
                    </TopGroup>
                    <LookItems>
                        <eo:MenuItem ItemID="_TopGroup">
                            <SubMenu Style-CssText="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; FONT-WEIGHT: bold; FONT-SIZE: 11px; PADDING-BOTTOM: 5px; CURSOR: hand; PADDING-TOP: 5px; FONT-FAMILY: tahoma; BACKGROUND-COLOR: #6b7dde"
                                LeftIconCellWidth="13" ItemSpacing="15"></SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem Height="25" HoverStyle-CssText="background-image:url(&quot;00000002&quot;);color:#428EFF;background-position-x: right; background-repeat: no-repeat;background-color:white;"
                            ItemID="_TopLevelItem" NormalStyle-CssText="background-image:url(&quot;00000001&quot;);color:#215DC6;background-position-x: right; background-repeat: no-repeat;background-color:white;"
                            SelectedStyle-CssText="background-image:url(&quot;00000003&quot;);color:#215DC6;background-position-x: right; background-repeat: no-repeat;background-color:white;"
                            LeftIcon-Url="00000012">
                            <SubMenu Style-CssText="BORDER-TOP-WIDTH: 1px; BORDER-RIGHT: white 1px solid; PADDING-RIGHT: 2px; PADDING-LEFT: 13px; FONT-SIZE: 11px; FONT-WEIGHT: normal; PADDING-BOTTOM: 9px; BORDER-LEFT: white 1px solid; CURSOR: hand; COLOR: #215dc6; BORDER-TOP-COLOR: white; PADDING-TOP: 9px; BORDER-BOTTOM: white 1px solid; FONT-FAMILY: tahoma; BACKGROUND-COLOR: #d6dff7"
                                LeftIconCellWidth="19" ItemSpacing="5"></SubMenu>
                        </eo:MenuItem>
                        <eo:MenuItem HoverStyle-CssText="COLOR: #428eff; TEXT-DECORATION: underline" ItemID="_Default"
                            NormalStyle-CssText="color:#215DC6;"></eo:MenuItem>
                    </LookItems>
                </eo:SlideMenu></TD>
            <TD vAlign="top">
                <asp:LinkButton id="btnSwitch" runat="server" OnClick="btnSwitch_Click">Turn Off SingleExpand</asp:LinkButton></TD>
        </TR>
    </TABLE>
</eo:CallbackPanel>
</asp:Content>


<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ComboBox_Features_Expand_Direction_and_Effect_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
    By default, EO.Web ComboBox dropdown expands downwards. The following
    sample sets <b>ExpandDirection</b> to <b>Top</b> so the dropdown
    expands upwards.
    </p>
    <p>
    This sample also:
    
    </p>
    <ul>
        <li>Sets both <b>ExpandEffect.Type</b> and <b>CollapseEffect.Type</b> 
        to <b>GlideBottomToTop</b> so that the drop down list glides towards 
        the top. The default value is <b>GlideTopToBottom</b>;
        </li>
        <li>
            Sets both <b>ExpandEffect.Duration</b> and <b>CollapseEffect.Duration</b>
            to 150 so that the drop down expands and collapses faster. The default
            value is 300(ms).
        </li>
    </ul>
    <eo:ComboBox runat="server" ID="ComboBox1" ControlSkinID="None" 
        DefaultIcon="00101070" HintText="Type here" Width="150px" 
        ExpandDirection ="Top">
        <ExpandEffect Type="GlideBottomToTop" Duration="150" />
        <CollapseEffect Type="GlideBottomToTop" Duration="150" />
        <TextStyle CssText="font-family: tahoma; font-size: 11px;" />
        <IconStyle CssText="width:16px;height:16px;" />
        <IconAreaStyle CssText="font-family: tahoma; font-size: 11px; background-image:url(00107007); background-position: left left; background-repeat:no-repeat; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <DropDownTemplate>
            <eo:ListBox runat="server" ID="ListBox1" ControlSkinID="None" Height="150px" 
                Width="200px">
                <BodyStyle CssText="border: solid 1px #868686;" />
                <ItemListStyle CssText="padding: 1px;" />
                <DisabledItemStyle CssText="color:#c0c0c0;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                <ItemStyle CssText="color:black;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                <ListBoxStyle CssText="font-family:Tahoma; font-size:13px;background-color:white;" />
                <MoreItemsMessageStyle CssText="padding:2px;" />
                <Items>
                    <eo:ListBoxItem Text="Item 1" />
                    <eo:ListBoxItem Text="Item 2" />
                    <eo:ListBoxItem Text="Item 3" />
                    <eo:ListBoxItem Text="Item 4" />
                    <eo:ListBoxItem Text="Item 5" />
                    <eo:ListBoxItem Text="Item 6" />
                    <eo:ListBoxItem Text="Item 7" />
                    <eo:ListBoxItem Text="Item 8" />
                    <eo:ListBoxItem Text="Item 9" />
                    <eo:ListBoxItem Text="Item 10" />
                </Items>
                <SelectedItemStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                <ItemHoverStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
            </eo:ListBox>
        </DropDownTemplate>
        <ButtonStyle CssText="width:17px;height:23px;" />
        <ButtonAreaStyle CssText="background-image:url(00107005);" />
        <ButtonAreaHoverStyle CssText="background-image:url(00107006);" />
        <TextAreaStyle CssText="font-family: tahoma; font-size: 11px; border-top: solid 1px #3d7bad; border-bottom: solid 1px #b7d9ed; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <HintTextStyle CssText="font-style:italic;background-color:#c0c0c0;color:white;line-height:16px;" />
    </eo:ComboBox>
</asp:Content>


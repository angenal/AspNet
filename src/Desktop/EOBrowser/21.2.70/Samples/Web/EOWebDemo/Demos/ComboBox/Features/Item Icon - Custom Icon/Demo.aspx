<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ComboBox_Features_Item_Icon___Custom_Icon_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
function get_icon(comboBox, item)
{
    if (item)
        return '<%=ResolveUrl("~/Images/Flags/")%>' + item.getValue();
    else
        return null;
}
//<!--JS_SAMPLE_END-->
    </script>
    <p>
        This sample demonstrates how to use <b>ClientSideGetIcon</b>
        to return a custom icon for the selected item. This sample
        is very similar to 
        <a href="javascript:GoToDemo('combobox_icon')">this sample</a>
        but with the following key differences in implementation:
    </p>
    <ul>
        <li>
            In the <b>Item Icon</b> sample, Each <b>ListBoxItem</b>'s
            <b>Icon</b> property is set to the full icon path. <b>Icon</b>
            property is not used in this sample;
        </li>
        <li>
            The <b>Value</b> property is used to store the icon
            file name only without full path information;            
        </li>
        <li>
            The sample handles the ComboBox's <b>ClientSideGetIcon</b>.
            The event handler returns the full image path based on the
            file name stored in the <b>Value</b> property;
        </li>
    </ul>
    <p>
        For demonstration purpose, this sample intentionally omitted
        the icons in the drop down list. You can edit the ListBox's
        <b>ItemTemplate</b> to display the icon based on the item's
        <b>Value</b> property.
    </p>
    <eo:ComboBox runat="server" ID="ComboBox1" ControlSkinID="None" 
        HintText="Type here" Width="200px" LabelHtml="Country:" EnableKeyboardNavigation="true"
        DefaultIcon="../../../../images/question_mark.gif"
        ClientSideGetIcon="get_icon">
        <TextStyle CssText="font-family: tahoma; font-size: 11px;" />
        <IconStyle CssText="width:16px;height:11px;margin-left:2px;margin-right:2px;" />
        <IconAreaStyle CssText="font-family: tahoma; font-size: 11px; background-image:url(00107007); background-position: left left; background-repeat:no-repeat; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <DropDownTemplate>
            <eo:ListBox runat="server" ID="ListBox1" ControlSkinID="None" Height="150px" 
                Width="200px" EnableKeyboardNavigation="true">                
                <BodyStyle CssText="border: solid 1px #868686;" />
                <ItemListStyle CssText="padding: 1px;" />
                <DisabledItemStyle CssText="color:#c0c0c0;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                <ItemStyle CssText="color:black;padding-bottom:1px;padding-left:6px;padding-right:6px;padding-top:3px;height:20px;" />
                <ListBoxStyle CssText="font-family:Tahoma; font-size:13px;background-color:white;" />
                <MoreItemsMessageStyle CssText="padding:2px;" />
                <SelectedItemStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                <ItemHoverStyle CssText="background-image:url(00106003);background-repeat:repeat;border-left-color:#c0a776;border-left-style:solid;border-left-width:1px;border-right-color:#c3aa79;border-right-style:solid;border-right-width:1px;color:black;height:20px;padding-bottom:1px;padding-left:5px;padding-right:5px;padding-top:3px;" />
                <ItemTemplate>
                    <%#Container.Item.Text%>
                </ItemTemplate>
                <Items>
                    <eo:ListBoxItem Text="United States" Value="us.gif" />
                    <eo:ListBoxItem Text="United Kingdom" Value="gb.gif" />
                    <eo:ListBoxItem Text="Canada" Value="ca.gif" />
                    <eo:ListBoxItem Text="Australia" Value="au.gif" />
                    <eo:ListBoxItem Text="Germany" Value="de.gif" />
                    <eo:ListBoxItem Text="France" Value="fr.gif" />
                </Items>
            </eo:ListBox>
        </DropDownTemplate>
        <ButtonStyle CssText="width:17px;height:23px;" />
        <ButtonAreaStyle CssText="background-image:url(00107005);" />
        <ButtonAreaHoverStyle CssText="background-image:url(00107006);" />
        <TextAreaStyle CssText="font-family: tahoma; font-size: 11px; border-top: solid 1px #3d7bad; border-bottom: solid 1px #b7d9ed; vertical-align:middle;padding-left:2px; padding-right:2px;" />
        <HintTextStyle CssText="font-style:italic;background-color:#c0c0c0;color:white;line-height:16px;" />
    </eo:ComboBox>
</asp:Content>


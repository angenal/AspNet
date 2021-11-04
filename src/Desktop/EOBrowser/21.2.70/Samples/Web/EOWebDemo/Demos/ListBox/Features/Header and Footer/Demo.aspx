<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_ListBox_Features_Header_and_Footer_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        An EO.Web ListBox consists of three sections: header, body and footer.
        All three sections are fully customizable. The header and footer sections can
        often be customized to provide a distinct visual appearance, but can
        also be customized to contain additional UI elements. The following sample
        uses <b>HeaderTemplate</b> to place a <b>Label</b> control in the 
        header section and <b>FooterTemplate</b> to place two <b>LinkButton</b> 
        controls in the footer section. The <b>Label</b> in the header section 
        is used to display the last update time. The <b>Show All</b> button is 
        used to display all items initially with <b>Visible</b> set to false; 
        The <b>Update</b> button is used to "update" the list (the sample only 
        updates the label in the header section for demonstration purpose).
    </p>
    <eo:ListBox runat="server" ID="ListBox1" ControlSkinID="None" Height="150px" 
        Width="232px">
        <FooterStyle CssText="background-image:url(00106006);background-position:left bottom;background-repeat:no-repeat;" />
        <BodyStyle CssText="background-image:url(00106005); background-repeat: repeat; padding-left: 12px; padding-right:10px; padding-top: 5px; padding-bottom: 5px; " />
        <DisabledItemStyle CssText="background-color:white; color: #c0c0c0; padding: 2px;" />
        <ItemStyle CssText="background-color:white; padding: 2px; color: black;" />
        <ListBoxStyle CssText="font-family:Tahoma; font-size:11px;" />
        <FooterTemplate>
            <div style="padding-left:14px;padding-right:14px;padding-bottom:10px;padding-top:0px;">
                <asp:LinkButton runat="server" ID="btnShowAll" Text="Show All" 
                    onclick="btnShowAll_Click"></asp:LinkButton>&nbsp;|&nbsp;
                <asp:LinkButton runat="server" ID="btnUpdate" Text="Update" 
                    onclick="btnUpdate_Click"></asp:LinkButton>
            </div>
        </FooterTemplate>
        <MoreItemsMessageStyle CssText="padding:2px;" />
        <HeaderStyle CssText="background-image:url(00106004);color:white;font-weight:bold;padding-bottom:3px;padding-left:13px;padding-top:3px;" />
        <HeaderTemplate>
            All Movies - <asp:Label runat="server" ID="lblTime"></asp:Label>
        </HeaderTemplate>
        <SelectedItemStyle CssText="padding: 2px; background-color:#d4d0c8; color:black;" />
        <Items>
            <eo:ListBoxItem Text="Bad Teacher" />
            <eo:ListBoxItem Text="Bridesmaids" />
            <eo:ListBoxItem Text="Cars 2" />
            <eo:ListBoxItem Text="Cars 2 3D" Visible="false" />
            <eo:ListBoxItem Text="Green Lantern" />
            <eo:ListBoxItem Text="Green Lantern 3D" Visible="false" />
            <eo:ListBoxItem Text="The Hangover Part II" />
            <eo:ListBoxItem Text="Harry Potter and the Deathly Hallows - Part 2" Visible="false" />
            <eo:ListBoxItem Text="Kung Fu Panda 2" />
            <eo:ListBoxItem Text="Kung Fu Panda 2 3D" Visible="false" />
            <eo:ListBoxItem Text="Lord of the Rings: Return of the King - Extended Edition Event" Visible="false" />
            <eo:ListBoxItem Text="Mr. Popper's Penguins" />
            <eo:ListBoxItem Text="Pirates of the Caribbean: On Stranger Tides" />
            <eo:ListBoxItem Text="Super 8" />
            <eo:ListBoxItem Text="Super 8: The IMAX Experience" Visible="false" />
            <eo:ListBoxItem Text="Transformers: Dark of the Moon"/>
            <eo:ListBoxItem Text="Transformers: Dark of the Moon 3D" Visible="false" />
            <eo:ListBoxItem Text="Transformers: Dark of the Moon: An IMAX 3D Experience" Visible="false" />
            <eo:ListBoxItem Text="X-Men: First Class" />
        </Items>
    </eo:ListBox>
</asp:Content>


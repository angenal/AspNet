<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Editable_Label_Normal_and_Active_Style_Demo" %>
<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
        You can specify an <b>NormalStyle</b> and <b>ActiveStyle</b>
        for the EditableLabel control. NormalStyle is applied when
        the control is not in edit mode. ActiveStyle is applied when
        the control is in edit mode. The following sample has 
        different border settings for these two styles so the control
        automatically switches borders when entering/leaving edit mode.
    </p>
    <p>
        Click the text in the dashed box below to edit the text.
    </p>
    <p>
    Enter your comment: 
    </p>
    <eo:EditableLabel runat="server" ID="EditableLabel1" Value="This is cool!" Width="200px">
        <NormalStyle CssText="border: 1px dashed #808000; background-color: white; padding: 2px;" />
        <ActiveStyle CssText="border: 1px solid black; background-color: white; padding: 2px;" />
    </eo:EditableLabel>
</asp:Content>


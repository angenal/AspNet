<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Splitter_Features_Auto_Fill_Window_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
function ShowAutoFillDemo(linkId)
{
    //Get the link object
    var link = document.getElementById(linkId);
    
    //Open the target page
    window.open(link.href, "auto_fill_demo", "width=500,height=400,resizable=yes,location=yes");
}
</script>
<p>
    EO.Web Splitter can automatically fills the containing window with optional <b>HeightMargin</b>
    and <b>WidthMargin</b>. To enable this feature, simple set <b>AutoFillWindow</b>
    to <b>True</b>.
</p>
<p>
    In auto fill mode, EO.Web Splitter automatically stretches the right and the 
    bottom edge of the splitter, but keeps the top and the left edge as is. This 
    allows you to reserve space on the left/top of the splitter simply by placing
    contents before the Splitter control. The reserved space will not be 
    covered by the Splitter even if the splitter's <b>AutoFillWindow</b> is 
    set to <b>True</b>.
</p>
<p>
    <asp:HyperLink Runat="server" NavigateUrl="AutoFill1.aspx" id="HyperLink1">Auto Fill with no reserved space</asp:HyperLink>
</p>
<p>
    <asp:HyperLink Runat="server" NavigateUrl="AutoFill2.aspx" id="HyperLink2">Auto Fill with reserved space on top</asp:HyperLink>
</p>
<p>
    You can also use <b>HeightMargin</b> and <b>WidthMargin</b> to reserve space on 
    the right/bottom side of the splitter.
</p>
<p>
    <asp:HyperLink Runat="server" NavigateUrl="AutoFill3.aspx" id="HyperLink3">Auto Fill with reserved space on all sides</asp:HyperLink>
</p>
</asp:Content>


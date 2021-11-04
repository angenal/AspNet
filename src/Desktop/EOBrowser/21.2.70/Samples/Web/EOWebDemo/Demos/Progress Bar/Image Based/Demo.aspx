<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Progress_Bar_Image_Based_Demo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">

    <script type="text/javascript">
function ApplyValue()
{
    var input = document.getElementById("txtValue");
    var v = parseInt(input.value);
    if ((v >= 0) && (v <= 100))
        eo_GetObject("ProgressBar1").setValue(v);
    else
        window.alert("Please enter a valid value between 0 and 100.");
}

var g_Progress = 0;
var g_TimeoutId = null;

function TestRun(update)
{
    var pb = eo_GetObject("ProgressBar1");
    var run = document.getElementById("<%=cbRun.ClientID%>");
    if (run.checked)
    {
        if (update)
        {
            g_Progress++;
            if (g_Progress > 100)
                g_Progress = 0;
            pb.setValue(g_Progress);
        }
        else
        {
            g_Progress = pb.getValue();
        }
        
        g_TimeoutId = window.setTimeout("TestRun(true)", 100);
    }
    else
    {
        g_TimeoutId = null;
    }
}

function CleanUpDemo()
{
    if (g_TimeoutId != null)
        window.clearTimeout(g_TimeoutId);
}
    </script>

    <p>
        You can use several properties that accept images: <b>BackgroundImage</b>, <b>BackgroundImageLeft</b>,
        <b>BackgroundImageRight</b> and <b>IndicatorImage</b> to compose a progress bar.
        The follow example demonstrated a few built-in skins that are composed this way.
    </p>
    <p>
        Select a Skin:
        <asp:DropDownList ID="cbSkin" runat="server" OnSelectedIndexChanged="cbSkin_SelectedIndexChanged">
            <asp:ListItem Value="Traditional">Traditional</asp:ListItem>
            <asp:ListItem Value="Windows_2000">Windows_2000</asp:ListItem>
            <asp:ListItem Value="Windows_Vista">Windows_Vista</asp:ListItem>
            <asp:ListItem Value="Windows_XP">Windows_XP</asp:ListItem>
        </asp:DropDownList></p>
    <p>
        <asp:CheckBox ID="cbShowPerct" runat="server" Text="Show Percentage." OnCheckedChanged="cbShowPerct_CheckedChanged">
        </asp:CheckBox>
        Use this option to show/hide the percentage text.
    </p>
    <p>
        <asp:CheckBox ID="cbRepeat" Text="Repeat Indicator Image." runat="server" Checked="True"
            OnCheckedChanged="cbRepeat_CheckedChanged"></asp:CheckBox>
        Use this option to specify whether the indicator image should be repeated or not.
        To see how this property affects the progress bar, try this option combined with
        "Test Run" option.
    </p>
    <p>
        <asp:CheckBox ID="cbRun" runat="server" Text="Test Run." onclick="TestRun()"></asp:CheckBox>
        EO.Web progress bar does not move the progress indicator by itself --- you must
        provide the code to drive it. Check this option to turn on a timer to drive the
        progress bar.
    </p>
    <eo:CallbackPanel runat="server" ID="cpPB" Triggers="{ControlID:cbSkin;Parameter:},{ControlID:cbShowPerct;Parameter:},{ControlID:cbRepeat;Parameter:}"
        ClientSideBeforeExecute="CleanUpDemo" ClientSideAfterUpdate="TestRun">
        <eo:ProgressBar ID="ProgressBar1" runat="server" Value="30" ControlSkinID="Traditional"
            Width="300px">
        </eo:ProgressBar>
    </eo:CallbackPanel>
    <p>
        Set Value (0 - 100):
        <input id="txtValue" style="width: 100px" type="text">
        <input onclick="ApplyValue()" type="button" value="Apply">
    </p>
</asp:Content>

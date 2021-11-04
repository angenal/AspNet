<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Progress_Bar_CSS_Based_Demo" Title="Untitled Page" %>

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
        EO.Web ProgressBar also provides <b>IndicatorColor</b> property. You can use this
        property and several standard WebControl properties <b>BorderColor</b>, <b>BorderStyle</b>
        and <b>BorderWidth</b> to easily create a CSS-based solid color progress bar. The
        following progress bar has <b>IndicatorColor</b> set to <b>LightBlue</b>.
    </p>
    <p>
        <asp:CheckBox ID="cbShowPerct" runat="server" Text="Show Percentage." OnCheckedChanged="cbShowPerct_CheckedChanged">
        </asp:CheckBox>
        Use this option to show/hide the percentage text.
    </p>
    <p>
        <asp:CheckBox ID="cbRun" runat="server" Text="Test Run." onclick="TestRun()"></asp:CheckBox>
        EO.Web progress bar does not move the progress indicator by itself --- you must
        provide the code to drive it. Check this option to turn on a timer to drive the
        progress bar.
    </p>
    <eo:CallbackPanel runat="server" ID="cpPB" Triggers="{ControlID:cbShowPerct;Parameter:}"
        ClientSideBeforeExecute="CleanUpDemo" ClientSideAfterUpdate="TestRun">
        <eo:ProgressBar ID="ProgressBar1" runat="server" BorderColor="Black" BorderWidth="1px"
            Height="16px" IndicatorColor="LightBlue" Value="30" ControlSkinID="None" BorderStyle="Solid"
            Width="300px">
        </eo:ProgressBar>
    </eo:CallbackPanel>
    <p>
        Set Value (0 - 100):
        <input id="txtValue" style="width: 100px" type="text">
        <input onclick="ApplyValue()" type="button" value="Apply">
    </p>
</asp:Content>

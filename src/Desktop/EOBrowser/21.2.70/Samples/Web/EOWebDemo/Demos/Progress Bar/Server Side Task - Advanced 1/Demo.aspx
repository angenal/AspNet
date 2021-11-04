<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Progress_Bar_Server_Side_Task___Advanced_1_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
function OnProgress(progressBar)
{
    var extraData = progressBar.getExtraData();
    if (extraData)
    {
        //The following code demonstrates how to update
        //client side DHTML element based on the value
        //RunTask passed to us with e.UpdateProgress
        var div = document.getElementById("divStatus");
        div.innerHTML = extraData;        
    }
}
//<!--JS_SAMPLE_END-->
</script>
<p>
    <b>Note</b>:This sample is based on the more basic <a href="javascript:GoToDemo('progressbar_runtask');">
        Server Side Task</a> sample, make sure you review that sample first.
</p>
<p>
    While the progress bar is running, you can not update any other UI elements in 
    the page through traditional means because when the progress bar is running, 
    nothing in the page is being&nbsp;reloaded (A traditionaly update occurs when 
    the page is reloaded, which is not the case for progress bar).
</p>
<p>
    <b>ProgressTaskEventArgs.UpdateProgress</b> provides a second parameter for you 
    to pass additional data to the client, which you can use together with 
    JavaScript to update client UI elements when the progress bar is running. This 
    sample demonstrates how to display additional status information&nbsp;using 
    this technique.
</p>
<p>
    See Remarks tab for more details about how this sample works.
</p>
<eo:ProgressBar runat="server" id="ProgressBar1" ShowPercentage="True" IndicatorImage="00060104"
    BackgroundImageRight="00060103" ControlSkinID="None" BackgroundImage="00060101" IndicatorIncrement="7"
    BackgroundImageLeft="00060102" Width="300px" StartTaskButton="btnStart" StopTaskButton="btnStop"
    ClientSideOnValueChanged="OnProgress" OnRunTask="ProgressBar1_RunTask"></eo:ProgressBar>
<br>
<asp:LinkButton id="btnStart" runat="server">Start</asp:LinkButton>
&nbsp;
<asp:LinkButton id="btnStop" runat="server">Stop</asp:LinkButton>
<div id="divStatus"></div>
</asp:Content>


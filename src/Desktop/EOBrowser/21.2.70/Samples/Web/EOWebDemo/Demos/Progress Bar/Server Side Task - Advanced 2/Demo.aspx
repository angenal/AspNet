<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Progress_Bar_Server_Side_Task___Advanced_2_Demo"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">

    <script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
function Start()
{
    //Trigger AJAX callback with "start" parameter
    eo_Callback("<%=CallbackPanel1.ClientID%>", "start");
}

function AfterCallbackUpate(callback, extraData)
{
    if (extraData == "start")
    {
        //Now start the progress bar
        var progressBar = eo_GetObject("<%=ProgressBar1.ClientID%>");
        progressBar.startTask();
    }
}

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
        
        if (extraData == "The task is done!")
        {
            //Trigger an AJAX callback using the CallbackPanel
            //control. This will trigger the server side
            //CallbackPanel1_Execute event handler. See the 
            //documentation for more details on how to use the 
            //CallbackPanel control. Note we must use setTimeout 
            //here to make sure our code is run after the progress
            //bar has finished updating its internal states
            window.setTimeout(
                "eo_Callback('<%=CallbackPanel1.ClientID%>', 'done')",
                10);        
        }
    }
}
//<!--JS_SAMPLE_END-->
    </script>

    <p>
        <b>Note</b>:
    </p>
    <ul>
        <li>This sample is based on <a href="javascript:GoToDemo('progressbar_adv1');">Server
            Side Task - Advanced 1</a> sample, make sure you review that sample first;
            <li>This sample also uses <b>CallbackPanel</b> control. If you are not familiar with
                CallbackPanel, please review the documentation for that control; </li>
    </ul>
    <p>
        The easiest way to trigger a progress bar is by setting the progress bar's StartButton,
        however you may wish to perform other actions before starting the progress bar or
        after the task is done. This sample demonstrates how to perform such additional
        actions on the server side (see remark sections if you only need to perform such
        actions on client side).
    </p>
    <p>
        For the purpose of demonstration, these "additional actions" merely displays a few
        messages by setting a Label control's Text property. However you can modify it to
        perform any action on the server side. The UI update restriction mentioned in the
        previous sample does not apply here, because these additional actions are executed
        <b>before</b> and <b>after</b> the progress bar task run, <b>not during</b> the
        progress bar task run.
    </p>
    <p>
        See Remarks tab for more details about how this sample works.
    </p>
    <eo:ProgressBar runat="server" ID="ProgressBar1" ShowPercentage="True" IndicatorImage="00060104"
        BackgroundImageRight="00060103" ControlSkinID="None" BackgroundImage="00060101"
        IndicatorIncrement="7" BackgroundImageLeft="00060102" Width="300px" StartTaskButton="btnStart"
        StopTaskButton="btnStop" ClientSideOnValueChanged="OnProgress" OnRunTask="ProgressBar1_RunTask">
    </eo:ProgressBar>
    <br>
    <a href="javascript:Start()">Start</a> &nbsp;
    <asp:LinkButton ID="btnStop" runat="server">Stop</asp:LinkButton>
    <div id="divStatus">
    </div>
    <eo:CallbackPanel runat="server" ID="CallbackPanel1" ClientSideAfterUpdate="AfterCallbackUpate"
        OnExecute="CallbackPanel1_Execute">
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </eo:CallbackPanel>
</asp:Content>

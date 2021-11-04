<%@ Register TagPrefix="eo" NameSpace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Progress_Bar_Server_Side_Task_Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
<p>
    EO.Web ProgressBar can be associated with a server side long running task and 
    updates the UI when the server side task progresses.
</p>
<p>
    The following sample demonstrates how to use this feature. It performs a long 
    server side task that does nothing but calling System.Threading.Thread.Sleep. 
    You can switch to the code tab to view the related source code.
</p>
<p>
    For more information, please visit online documentation EO.Web.ProgressBar 
    -&gt; Moving ProgressBar (Server Side).
</p>
<eo:ProgressBar runat="server" id="ProgressBar1" ShowPercentage="True" IndicatorImage="00060104"
    BackgroundImageRight="00060103" ControlSkinID="None" BackgroundImage="00060101" IndicatorIncrement="7"
    BackgroundImageLeft="00060102" Width="300px" StartTaskButton="btnStart" StopTaskButton="btnStop" OnRunTask="ProgressBar1_RunTask">
</eo:ProgressBar>
<br>
<asp:LinkButton id="btnStart" runat="server">Start</asp:LinkButton>
&nbsp;
<asp:LinkButton id="btnStop" runat="server">Stop</asp:LinkButton>
</asp:Content>


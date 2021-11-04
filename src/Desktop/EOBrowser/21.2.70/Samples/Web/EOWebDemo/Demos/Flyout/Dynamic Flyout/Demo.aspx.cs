using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_Flyout_Dynamic_Flyout_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        //ASP.NET automatically saves control properties inside view 
        //state. However it does not automatically reload dynamically
        //loaded controls. Thus we try to load all controls that we
        //previously dynamically loaded at here manually. The data we
        //used to reload all control are saved inside hidden input
        //element "txtMsgList". For demonstration purpose, it only saves 
        //a "message" for each dynamically loaded control. You will need
        //to change this to save whatever information that is needed to
        //reconstruct your control.
        string msgList = Request.Form[txtMsgList.Name];
        if (msgList != null)
        {
            foreach (string msg in msgList.Split(
                new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
            {
                LoadFlyoutCtrl(msg);
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Load a new instance of the flyout control
        string msg = "This flyout is loaded at " + DateTime.Now;
        LoadFlyoutCtrl(msg);

        //Save the message in txtMsgList so that we can reload
        //it again in OnInit. See comment inside OnInit for more
        //detail
        string msgList = txtMsgList.Value;
        if (string.IsNullOrEmpty(msgList))
            msgList = msg;
        else
            msgList = msgList + "|" + msg;
        txtMsgList.Value = msgList;
    }

    private void LoadFlyoutCtrl(string msg)
    {
        //Load the control and add it into the page
        Demos_Flyout_Dynamic_Flyout_FlyoutCtrl flyoutCtrl =
            (Demos_Flyout_Dynamic_Flyout_FlyoutCtrl)LoadControl("FlyoutCtrl.ascx");
        Panel1.Controls.Add(flyoutCtrl);

        //Initializes the control
        flyoutCtrl.InitMsg(msg);
    }
}

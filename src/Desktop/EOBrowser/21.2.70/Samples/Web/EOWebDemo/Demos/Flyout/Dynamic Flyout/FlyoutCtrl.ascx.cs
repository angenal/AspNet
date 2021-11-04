using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_Flyout_Dynamic_Flyout_FlyoutCtrl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void InitMsg(string msg)
    {
        lblMsg.Text = msg;

         Demos_Flyout_MovieAndTV ctrl =
             (Demos_Flyout_MovieAndTV)Flyout1.FindControl("MovieAndTV");
        ctrl.InitMsg("This message is inside the flyout: " + msg);
    }
}

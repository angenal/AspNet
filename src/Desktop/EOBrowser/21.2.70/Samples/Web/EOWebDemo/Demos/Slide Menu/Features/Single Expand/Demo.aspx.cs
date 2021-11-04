using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Demos_Slide_Menu_Features_Single_Expand_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSwitch_Click(object sender, System.EventArgs e)
    {
        if (SlideMenu1.SingleExpand)
        {
            SlideMenu1.SingleExpand = false;
            btnSwitch.Text = "Turn On SingleExpand";
        }
        else
        {
            SlideMenu1.SingleExpand = true;
            btnSwitch.Text = "Turn Off SingleExpand";
        }
    }
}

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

public partial class Demos_Dialog_Features_Moving_and_Resizing_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cbMove_CheckedChanged(object sender, System.EventArgs e)
    {
        Dialog1.AllowMove = cbMove.Checked;
    }

    protected void cbResize_CheckedChanged(object sender, System.EventArgs e)
    {
        Dialog1.AllowResize = cbResize.Checked;
    }
}

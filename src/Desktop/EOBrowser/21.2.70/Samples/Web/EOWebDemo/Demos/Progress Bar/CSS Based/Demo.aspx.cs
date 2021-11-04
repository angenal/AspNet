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

public partial class Demos_Progress_Bar_CSS_Based_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cbShowPerct_CheckedChanged(object sender, System.EventArgs e)
    {
        ProgressBar1.ShowPercentage = cbShowPerct.Checked;
    }
}

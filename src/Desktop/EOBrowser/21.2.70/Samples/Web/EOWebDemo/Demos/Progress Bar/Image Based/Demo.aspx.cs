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
using EO.Web;

public partial class Demos_Progress_Bar_Image_Based_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cbSkin_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        ProgressBar1.ControlSkinID = cbSkin.SelectedItem.Text;
    }

    protected void cbShowPerct_CheckedChanged(object sender, System.EventArgs e)
    {
        ProgressBar1.ShowPercentage = cbShowPerct.Checked;
    }

    protected void cbRepeat_CheckedChanged(object sender, System.EventArgs e)
    {
        ProgressBar1.RepeatIndicatorImage = cbRepeat.Checked ? NullableBool.True : NullableBool.False;
    }
}

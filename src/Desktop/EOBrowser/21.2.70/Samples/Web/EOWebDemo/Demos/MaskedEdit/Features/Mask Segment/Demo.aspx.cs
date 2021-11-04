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

public partial class Demos_MaskedEdit_Features_Mask_Segment_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lstMasks_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string mask = lstMasks.SelectedItem.Value;
        if ((mask == string.Empty) || (mask == null))
            MaskedEdit1.Enabled = false;
        else
        {
            MaskedEdit1.Enabled = true;
            MaskedEdit1.Mask = mask;
        }
    }
}

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

public partial class Demos_TabStrip_and_MultiPage_Programming_Switch_Page_or_Tab__Server_Side_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region SAMPLE_BLOCK#1
    protected void btnNext_Click(object sender, System.EventArgs e)
    {
        int nSelectedTab = TabStrip1.SelectedIndex;
        if (nSelectedTab < 0)
            nSelectedTab = 0;
        nSelectedTab++;
        if (nSelectedTab >= TabStrip1.Items.Count)
            nSelectedTab = 0;
        TabStrip1.SelectedIndex = nSelectedTab;
    }
    #endregion
}

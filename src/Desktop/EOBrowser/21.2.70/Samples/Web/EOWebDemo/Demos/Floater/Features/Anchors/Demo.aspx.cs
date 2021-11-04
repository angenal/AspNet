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

public partial class Demos_Floater_Features_Anchors_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void rbAnchor_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        switch (rbAnchor.SelectedIndex)
        {
            case 0:
                Floater1.LeftAnchorID = "anchor";
                Floater1.RightAnchorID = null;
                break;
            case 1:
                Floater1.LeftAnchorID = null;
                Floater1.RightAnchorID = "anchor";
                break;
            case 2:
                Floater1.LeftAnchorID = null;
                Floater1.TopAnchorID = "<center>";
                break;
        }
    }
}

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

public partial class Demos_Grid_Features_Keyboard_Navigation_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Grid1.DataSource = new string[][]
                {
                    new string[]{null, "A", "B"},
                    new string[]{null, "C", "D"},
                    new string[]{null, "E", "F"},
                };
        Grid1.DataBind();
    }
}

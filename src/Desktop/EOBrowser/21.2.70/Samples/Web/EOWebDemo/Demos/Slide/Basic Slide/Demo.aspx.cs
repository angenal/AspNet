using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_Slide_Basic_Slide_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Slide1.DataSource = new string[]
        {
            "../Images/yaris_big.gif",
            "../Images/cruze_big.gif",
            "../Images/prius_big.gif",
            "../Images/miata_big.gif",
            "../Images/optima_big.gif",
            "../Images/impala_big.gif",
            "../Images/forester_big.gif",
            "../Images/highlander_big.gif",
            "../Images/q7_big.gif",
            "../Images/ridgeline_big.gif",
        };
        Slide1.DataBind();
    }
}

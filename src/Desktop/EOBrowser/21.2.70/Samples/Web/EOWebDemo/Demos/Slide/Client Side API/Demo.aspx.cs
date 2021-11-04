using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_Slide_Client_Side_API_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Slide1.DataSource = new string[]
            {
                "../Images/yaris_big.gif",
                "../Images/cruze_big.gif",
                "../Images/prius_big.gif",
                "../Images/miata_big.gif",
            };
            Slide1.DataBind();
        }
    }
}

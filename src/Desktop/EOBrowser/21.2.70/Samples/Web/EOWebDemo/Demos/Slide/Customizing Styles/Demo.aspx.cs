using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_Slide_Customizing_Styles_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Slide1.DataSource = new string[]
        {
            "../Images/biscuit.gif",
            "../Images/coffee.gif",
            "../Images/hash_brown.gif",
        };
        Slide1.DataBind();
    }
}

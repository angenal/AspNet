using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_Captcha_Basic_Feature_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Captcha1.IsValid)
        {
            panInput.Visible = false;
            panResult.Visible = true;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        panInput.Visible = true;
        panResult.Visible = false;
        Captcha1.Reset();
    }
}

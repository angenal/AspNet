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

public partial class Demos_Callback_Features_Misc_Features_Demo2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, System.EventArgs e)
    {
        if (cbError.Checked)
            throw new Exception("This exception simulates a code error.");

        if (cbRedirect.Checked)
            CallbackPanel1.Redirect("http://www.google.com");

        lblOK.Text = "Callback completed successfully at " + DateTime.Now.ToString();
        lblOK.Visible = true;
    }
}

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

public partial class Demos_Callback_Features_Auto_Disable_Contents_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, System.EventArgs e)
    {
        //Make the process to take a while
        System.Threading.Thread.Sleep(2000);

        panForm.Visible = false;
        panResult.Visible = true;
        lblResult.Text = string.Format("Your random confirmation number is {0}.", new Random().Next());
    }

    protected void btnReset_Click(object sender, System.EventArgs e)
    {
        panResult.Visible = false;
        panForm.Visible = true;
    }
}

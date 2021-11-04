using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if ((txtUserName.Text == "eopdf") &&
            (txtPassword.Text == "eopdf"))
        {
            FormsAuthentication.RedirectFromLoginPage("eopdf", false);
        }
        else
        {
            lblError.Visible = true;
        }
    }
}

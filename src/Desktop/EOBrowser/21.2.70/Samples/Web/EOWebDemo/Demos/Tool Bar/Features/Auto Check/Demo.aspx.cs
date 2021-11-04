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

public partial class Demos_Tool_Bar_Features_Auto_Check_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, System.EventArgs e)
    {
        string s = "";
        foreach (EO.Web.ToolBarItem item in ToolBar1.Items)
        {
            if (item.Pushed)
            {
                if (s != "")
                    s = s + ", ";

                s = s + item.Text;
            }
        }

        Label1.Text = "Pushed Buttons: " + s;
    }
}

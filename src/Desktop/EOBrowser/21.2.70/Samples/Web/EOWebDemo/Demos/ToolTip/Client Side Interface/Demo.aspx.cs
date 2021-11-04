using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EO.Web.Demo;

public partial class Demos_ToolTip_Client_Side_Interface_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (DemoDB db = new DemoDB())
        {
            string sql = "SELECT * FROM Topics";
            Grid1.DataSource = db.ExecuteReader(sql);
            Grid1.DataBind();
        }
    }
}

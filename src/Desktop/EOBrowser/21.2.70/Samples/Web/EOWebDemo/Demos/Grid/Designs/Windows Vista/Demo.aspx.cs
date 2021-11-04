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
using EO.Web.Demo;

public partial class Demos_Grid_Designs_Windows_Vista_Demo : System.Web.UI.Page
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

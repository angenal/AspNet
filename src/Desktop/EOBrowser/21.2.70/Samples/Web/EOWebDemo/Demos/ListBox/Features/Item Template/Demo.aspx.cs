using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using EO.Web.Demo;

public partial class Demos_ListBox_Features_Item_Template_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            using (DemoDB db = new DemoDB())
            {
                string sql = "SELECT TOP 10 * FROM Topics";

                ListBox1.DataSource = db.ExecuteReader(sql);
                ListBox1.DataBind();
            }
        }
    }
}

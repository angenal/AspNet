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

public partial class Demos_Grid_Features_Custom_Column___Advanced_3_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Grid1.DataSource = CreateDataSource();
            Grid1.DataBind();
        }
    }

    private DataTable CreateDataSource()
    {
        DataTable table = new DataTable();
        DataColumn column = new DataColumn("ItemName", typeof(string));
        table.Columns.Add(column);
        column = new DataColumn("BackOrdered", typeof(bool));
        table.Columns.Add(column);
        column = new DataColumn("AvailableOn", typeof(DateTime));
        table.Columns.Add(column);

        table.Rows.Add("Intel Core 2 Duo E7400 2.8GHz CPU", false, DateTime.MinValue);
        table.Rows.Add("Intel Celeron E3300 2.5GHz CPU", true, DateTime.MinValue);
        table.Rows.Add("Intel Core 2 Quad Q9550 2.83GHz CPU", false, DateTime.MinValue);
        table.Rows.Add("AMD Athlon 64 X2 6000+ 3.0GHz CPU", false, DateTime.MinValue);
        table.Rows.Add("AMD Phenom II X4 945 3.0GHz CPU", false, DateTime.MinValue);

        return table;
    }
}

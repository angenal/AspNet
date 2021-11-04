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
using System.Data.OleDb;
using EO.Web.Demo;

public partial class Demos_Callback_Features_Partial_Page_Updates___DataGrid_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData("Maker");
    }

    protected void DataGrid1_SortCommand(object source,
        System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        LoadData(e.SortExpression);
    }

    private void LoadData(string sortField)
    {
        using (DemoDB db = new DemoDB())
        {
            OleDbDataReader reader = db.ExecuteReader(
                "select Maker, Model, Style, Description from Cars Order By " + sortField);
            DataGrid1.DataSource = reader;
            DataGrid1.DataBind();
        }
    }
}

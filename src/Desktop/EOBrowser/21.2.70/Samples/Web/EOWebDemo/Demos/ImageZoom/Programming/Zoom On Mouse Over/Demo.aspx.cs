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

public partial class Demos_ImageZoom_Programming_Zoom_On_Mouse_Over_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataGrid1.DataSource = CreateDataTable();
        DataGrid1.DataBind();
    }

    private DataTable CreateDataTable()
    {
        DataTable table = new DataTable();
        DataColumn col = new DataColumn("BigImage", typeof(string));
        table.Columns.Add(col);
        col = new DataColumn("SmallImage", typeof(string));
        table.Columns.Add(col);
        col = new DataColumn("Desc", typeof(string));
        table.Columns.Add(col);

        table.Rows.Add(new object[]{
                "../../Images/palm_tree_medium.jpg", 
                "../../Images/palm_tree_small.jpg", 
                "Palm Tree on the Beach"});
        table.Rows.Add(new object[]{
                "../../Images/future_car_medium.jpg", 
                "../../Images/future_car_small.jpg", 
                "Wild Fire"});
        table.Rows.Add(new object[]{
                "../../Images/fishing_medium.jpg", 
                "../../Images/fishing_small.jpg", 
                "Fishing"});

        return table;
    }
}

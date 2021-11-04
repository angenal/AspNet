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

public partial class Demos_Grid_Features_Custom_Column___Advanced_2_Demo : System.Web.UI.Page
{
    #region SAMPLE_BLOCK#1
    protected void Page_Load(object sender, System.EventArgs e)
    {
        //Get the Repeater control so that we can fill it
        //later
        EO.Web.CustomColumn productColumn =
            (EO.Web.CustomColumn)Grid1.Columns[1];
        Repeater productRepeater =
            (Repeater)productColumn.EditorInstance.FindControl("Products");

        //Fill the repeater from the database
        using (DemoDB db = new DemoDB())
        {
            productRepeater.DataSource = db.ExecuteReader("SELECT * FROM Products");
            productRepeater.DataBind();
        }
    }
    #endregion

    #region SAMPLE_BLOCK#2
    protected void Grid1_ItemCommand(object sender, EO.Web.GridCommandEventArgs e)
    {
        //The first cell contains the product number
        string productNo = (string)e.Item.Cells[1].Value;

        using (DemoDB db = new DemoDB())
        {
            //Use the product number to find out the product price
            string sql = string.Format("SELECT Product_Price FROM Products WHERE Product_No = '{0}'", productNo);

            object productPrice = db.ExecuteScalar(sql);

            //Display the product price
            e.Item.Cells[2].Value = productPrice;
        }
    }
    #endregion
}

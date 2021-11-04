using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using EO.Web.Demo;

public partial class Demos_ListBox_Features_Load_on_Demand_Demo : System.Web.UI.Page
{
    #region SAMPLE_BLOCK#1
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            using (DemoDB db = new DemoDB())
            {
                //Set the total record count
                string sql = "SELECT Count(TopicID) FROM Topics";
                int nTotalCount = (int)db.ExecuteScalar(sql);
                ListBox1.TotalItemCount = nTotalCount;

                //Load the first batch
                PopulateMoreRecords();
            }
        }
    }

    private void PopulateMoreRecords()
    {
        using (DemoDB db = new DemoDB())
        {
            //Fetch the next 10 records
            string sql = "SELECT TOP 10 * FROM Topics";
            if (ListBox1.Items.Count > 0)
            {
                string value = ListBox1.Items[ListBox1.Items.Count - 1].Value;
                sql = string.Format(" {0} WHERE TopicID > {1}", sql, value);
            }
            sql = sql + " ORDER BY TopicID ASC";

            //Add new items based on the data source. When
            //DataBind is called inside MoreItemsNeeded event,
            //it automatically operates on "append" mode
            ListBox1.DataSource = db.ExecuteReader(sql);
            ListBox1.DataBind();
        }
    }

    protected void ListBox1_MoreItemsNeeded(object sender, EventArgs e)
    {
        //Load one more batch
        PopulateMoreRecords();
    }
    #endregion
}

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

public partial class Demos_Grid_Features_Server_Running_Mode_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CallbackPanel1.IsCallbackByMe)
        {
            SetRecordCount();
            LoadGridData(null);
        }
    }

    #region SAMPLE_BLOCK#1

    // Set the total number of record
    private void SetRecordCount()
    {
        using (DemoDB db = new DemoDB())
        {
            string sql = "SELECT COUNT(*) FROM Topics";

            int nRecordCount = (int)db.ExecuteScalar(sql);
            Grid1.RecordCount = nRecordCount;
        }
    }

    //Populate the grid
    private void LoadGridData(EO.Web.GridColumn sortColumn)
    {
        //Deciding sort orders
        string sortField = "PostedAt";
        string sortOrder = "DESC";
        if (sortColumn != null)
        {
            sortField = sortColumn.DataField;
            sortOrder = sortColumn.SortOrder == EO.Web.SortOrder.Ascending ? "ASC" : "DESC";
        }
        string sortOrderReverse = sortOrder == "ASC" ? "DESC" : "ASC";

        using (DemoDB db = new DemoDB())
        {
            //Only fetch data for the current page from the database.
            //This is achieved by utilizing the "TOP n" clause supported
            //by Access/SQL Server database combined with sort orders.
            //Similar but different mechanism maybe needed with other
            //type of database engines.
            string sql1 = string.Format(
                "SELECT TOP {0} * FROM Topics ORDER BY {1} {2}",
                (Grid1.CurrentPage + 1) * Grid1.PageSize, sortField, sortOrder);

            string sql2 = string.Format(
                "SELECT TOP {0} * FROM ({1}) ORDER BY {2} {3}",
                Grid1.PageSize, sql1, sortField, sortOrderReverse);

            string sql3 = string.Format(
                "SELECT * FROM ({0}) ORDER BY {1} {2}",
                sql2, sortField, sortOrder);

            OleDbDataReader reader = db.ExecuteReader(sql3);
            Grid1.DataSource = reader;
            Grid1.DataBind();
        }
    }
    #endregion

    protected void Grid1_PageIndexChanged(object sender, System.EventArgs e)
    {
        LoadGridData(null);
    }

    protected void Grid1_ColumnSort(object sender, EO.Web.GridColumnEventArgs e)
    {
        LoadGridData(e.Column);
    }
}

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

public partial class Demos_Grid_Features_Callback_Running_Mode_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Grid1.IsCallbackByMe)
        {
            SetRecordCount();
            LoadGridData(null);
        }
    }

    #region SAMPLE_BLOCK#1
    private void SetRecordCount()
    {
        using (DemoDB db = new DemoDB())
        {
            string sql = "SELECT COUNT(*) FROM Topics";

            int nRecordCount = (int)db.ExecuteScalar(sql);
            Grid1.RecordCount = nRecordCount;
        }
    }

    private void LoadGridData(EO.Web.GridColumn sortColumn)
    {
        string sortField;
        string sortOrder;
        if (sortColumn == null)
            sortColumn = Grid1.SortColumn;
        if (sortColumn != null)
        {
            sortField = sortColumn.DataField;
            sortOrder = sortColumn.SortOrder == EO.Web.SortOrder.Ascending ? "ASC" : "DESC";
        }
        else
        {
            sortField = "PostedAt";
            sortOrder = "DESC";
        }
        string sortOrderReverse = sortOrder == "ASC" ? "DESC" : "ASC";

        using (DemoDB db = new DemoDB())
        {
            //Number of records to display in the current page
            int recordsForCurrentPage = Grid1.PageSize;

            //Number of records included by the current page and
            //all pages before the current page
            int recordsTillCurrentPage = (Grid1.CurrentPage + 1) * Grid1.PageSize;

            //The current page may be the last page, in which
            //case the total number of available records may
            //be less than PageSize
            if (recordsTillCurrentPage > Grid1.RecordCount)
            {
                recordsForCurrentPage -= recordsTillCurrentPage - Grid1.RecordCount;
                recordsTillCurrentPage = Grid1.RecordCount;
            }

            string sql1 = string.Format(
                "SELECT TOP {0} * FROM Topics ORDER BY {1} {2}",
                recordsTillCurrentPage, sortField, sortOrder);

            string sql2 = string.Format(
                "SELECT TOP {0} * FROM ({1}) ORDER BY {2} {3}",
                recordsForCurrentPage, sql1, sortField, sortOrderReverse);

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

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

public partial class Demos_Grid_Features_Client_Running_Mode_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //IsCallbackByMe condition is similar to checking 
        //Page.IsPostBack in a page without using 
        //CallbackPanel. It is not necessary to repopulate
        //the grid every time when view state is enabled
        if (!CallbackPanel1.IsCallbackByMe)
            LoadGridData(null);
    }

    private void LoadGridData(EO.Web.GridColumn sortColumn)
    {
        using (DemoDB db = new DemoDB())
        {
            string sql = "SELECT * FROM Topics";
            if (sortColumn != null)
                sql = string.Format("{0} {1}", sql, sortColumn.OrderByClause);

            Grid1.DataSource = db.ExecuteReader(sql);
            Grid1.DataBind();
        }
    }

    protected void btnPaging_CheckedChanged(object sender, System.EventArgs e)
    {
        Grid1.AllowPaging = btnPaging.Checked;

        //Only enable the scroll bar checkbox when paging is
        //is enabled to avoid a huge grid without scrollbars
        btnScroll.Enabled = btnPaging.Checked;
        if (!Grid1.AllowPaging)
        {
            btnScroll.Checked = true;
            Grid1.ScrollBars = EO.Web.ScrollBars.Auto;
        }
    }

    protected void btnSorting_CheckedChanged(object sender, System.EventArgs e)
    {
        EO.Web.GridColumn sortColumn = null;
        foreach (EO.Web.GridColumn column in Grid1.Columns)
        {
            column.AllowSort = btnSorting.Checked;
            if (column.SortOrder != EO.Web.SortOrder.None)
                sortColumn = column;
        }
        if (btnSorting.Checked && (sortColumn == null))
        {
            sortColumn = Grid1.Columns[1];
            sortColumn.SortOrder = EO.Web.SortOrder.Ascending;
        }
        LoadGridData(sortColumn);
    }

    protected void btnScroll_CheckedChanged(object sender, System.EventArgs e)
    {
        if (btnScroll.Checked)
            Grid1.ScrollBars = EO.Web.ScrollBars.Auto;
        else
            Grid1.ScrollBars = EO.Web.ScrollBars.None;
    }
}

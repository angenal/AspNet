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

public partial class Demos_Grid_Features_Edit_Grid_Data___Traditional_Style_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //IsCallbackByMe condition is similar to checking 
        //Page.IsPostBack in a page without using 
        //CallbackPanel. It is not necessary to repopulate
        //the grid every time when view state is enabled
        if (!CallbackPanel1.IsCallbackByMe)
        {
            using (DemoDB db = new DemoDB())
            {
                string sql = "SELECT * FROM Topics";
                Grid1.DataSource = db.ExecuteReader(sql);
                Grid1.DataBind();
            }
        }
    }

    protected void Grid1_ItemChanged(object sender, EO.Web.GridItemEventArgs e)
    {
    }

    protected void Button1_Click(object sender, System.EventArgs e)
    {
        panChanges.Visible = true;

        string s = string.Empty;
        if (Grid1.ChangedItems.Length == 0)
            s += "No item has changed.";
        else
        {
            foreach (EO.Web.GridItem item in Grid1.ChangedItems)
            {
                string text = string.Format(
                    "Item Changed: Key = {0}, Posted At -> {1}, Posted By -> {2}, Topic -> {3}",
                    item.Key,
                    item.Cells["PostedAt"].Value,
                    item.Cells["PostedBy"].Value,
                    item.Cells["Topic"].Value);

                s += "<br />";
                s += text;
            }
        }

        Literal info = new Literal();
        info.Text = s;
        panChanges.Controls.Add(info);
    }
}

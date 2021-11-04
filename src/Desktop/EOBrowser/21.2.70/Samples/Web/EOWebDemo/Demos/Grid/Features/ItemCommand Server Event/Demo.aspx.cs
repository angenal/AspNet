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

public partial class Demos_Grid_Features_ItemCommand_Server_Event_Demo : System.Web.UI.Page
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

    #region SAMPLE_BLOCK#1
    protected void Grid1_ItemCommand(object sender, EO.Web.GridCommandEventArgs e)
    {
        //Check whether it is from our client side
        //JavaScript call
        if (e.CommandName == "select")
        {
            string s = string.Empty;
            s += "Row Index:" + e.Item.Index.ToString();
            s += "<br />Posted At:" + e.Item.Cells[1].Value.ToString();
            s += "<br />Posted By:" + e.Item.Cells[2].Value.ToString();
            s += "<br />Topic:" + e.Item.Cells[3].Value.ToString();
            lblInfo.Text = s;
        }
    }
    #endregion
}

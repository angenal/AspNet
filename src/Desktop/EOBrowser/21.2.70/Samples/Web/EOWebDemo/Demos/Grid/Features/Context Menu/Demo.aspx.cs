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

public partial class Demos_Grid_Features_Context_Menu_Demo : System.Web.UI.Page
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

    protected void Menu1_ItemClick(object sender, EO.Web.NavigationItemEventArgs e)
    {
        //Code to save changes goes here
    }
}

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

public partial class Demos_Menu_Programming_Server_Side_Programming_Server_Side_Event_Handling_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region SAMPLE_BLOCK#1
    protected void Menu1_ItemClick(object sender, EO.Web.NavigationItemEventArgs e)
    {
        lblMsg.Text = string.Format("Menu item '{0}' was clicked.", ((EO.Web.MenuItem)e.NavigationItem).Text);
    }
    #endregion
}

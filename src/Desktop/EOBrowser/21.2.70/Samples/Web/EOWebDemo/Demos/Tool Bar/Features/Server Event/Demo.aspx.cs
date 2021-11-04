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

public partial class Demos_Tool_Bar_Features_Server_Event_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ToolBar1_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        Label1.Text = string.Format("Item '{0}' clicked.", e.Item.CommandName);
    }
}

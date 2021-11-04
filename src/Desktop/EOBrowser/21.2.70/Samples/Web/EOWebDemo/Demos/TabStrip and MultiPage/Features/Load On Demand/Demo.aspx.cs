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

public partial class Demos_TabStrip_and_MultiPage_Features_Load_On_Demand_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            LoadPage(0);
    }

    private void LoadPage(int index)
    {

        //Perform a very lengthy work
        System.Threading.Thread.Sleep(500);

        //Load the new page content
        System.Web.UI.Control tabPageContent = null;
        if (index < 3)
        {
            string tabPagePath = string.Format("TabPages/TabPage{0}.ascx", index + 1);
            tabPageContent = LoadControl(tabPagePath);
        }
        else
        {
            tabPageContent = new System.Web.UI.LiteralControl(
                string.Format("This is a very complicated page generated at <span class=\"highlight\">{0}</span>. " +
                "The server code performed a lengthy operation before loading this page.",
                DateTime.Now));
        }
        CallbackPanel1.Controls.Add(tabPageContent);
    }

    protected void CallbackPanel1_Execute(object sender, EO.Web.CallbackEventArgs e)
    {
        LoadPage(int.Parse(e.Parameter));
    }
}

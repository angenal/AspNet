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

public partial class Demos_Menu_Features_Accessibility_Features_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InitToolTip(MenuForToolTip.Items);
    }

    private void InitToolTip(EO.Web.MenuItemCollection items)
    {
        foreach (EO.Web.MenuItem item in items)
        {
            item.ToolTip = item.Text.Html;
            item.Status = item.Text.Html;

            InitToolTip(item.SubMenu.Items);
        }
    }
}

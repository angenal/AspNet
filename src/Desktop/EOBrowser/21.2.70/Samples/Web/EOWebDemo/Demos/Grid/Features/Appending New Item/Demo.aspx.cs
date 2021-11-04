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

public partial class Demos_Grid_Features_Appending_New_Item_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, System.EventArgs e)
    {
        foreach (EO.Web.GridItem item in Grid1.AddedItems)
        {
            string s = string.Format("{0}, {1}",
                item.Cells[0].Value, item.Cells[1].Value);

            System.Diagnostics.Debug.WriteLine(s);
        }
    }
}

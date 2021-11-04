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

public partial class Demos_Grid_Features_Appending_New_Item_with_JavaScript_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, System.EventArgs e)
    {
        //Use AddedItems to access all newly added items
        foreach (EO.Web.GridItem item in Grid1.AddedItems)
        {
            //Get the cell value
            object cellValue = item.Cells[1].Value;

            if (cellValue != null)
            {
                //Perform additional task....
            }
        }

        if (Grid1.AddedItems.Length == 0)
            lblResult.Text = "No Item has been added!";
        else
            lblResult.Text = Grid1.AddedItems.Length.ToString() + " item(s) have been added!";
    }
}

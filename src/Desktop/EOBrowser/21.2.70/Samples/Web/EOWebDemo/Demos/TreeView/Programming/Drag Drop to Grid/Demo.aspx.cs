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

public partial class Demos_TreeView_Programming_Drag_Drop_to_Grid_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //IsCallbackByMe condition is similar to checking 
        //Page.IsPostBack in a page without using 
        //CallbackPanel. We should not re-initialize the Grid
        //when the page posts back
        if (!CallbackPanel1.IsCallbackByMe)
        {
            //Initialize the Grid to contain a single "Total" item
            Grid1.DataSource = new object[1];
            Grid1.DataBind();
            Grid1.Items[0].Cells[0].Value = "Total";
        }
    }

    protected void btnSubmit_Click(object sender, System.EventArgs e)
    {
        panInput.Visible = false;
        panResult.Visible = true;
        btnSubmit.Visible = false;

        //Display all added items
        string result = "Items: <br />";
        foreach (EO.Web.GridItem item in Grid1.AddedItems)
        {
            result += string.Format("{0}, {1}, ${2}<br />",
                item.Cells[0].Value, item.Cells[1].Value, item.Cells[2].Value);
        }
        lblResult.Text = result;
    }
}

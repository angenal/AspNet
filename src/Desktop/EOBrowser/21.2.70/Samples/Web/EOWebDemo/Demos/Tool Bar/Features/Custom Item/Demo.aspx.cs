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

public partial class Demos_Tool_Bar_Features_Custom_Item_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, System.EventArgs e)
    {
        //Hookup SelectedIndexChanged event handler for the DropDownList
        System.Web.UI.Control customItem = ToolBar1.Items[0].CustomItemInstance;
        DropDownList list = (DropDownList)customItem.FindControl("DropDownList1");
        list.SelectedIndexChanged += new EventHandler(list_SelectedIndexChanged);
    }

    private void list_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList list = (DropDownList)sender;
        Label1.Text = string.Format("'{0}' selected.", list.SelectedItem.Value);
    }
}

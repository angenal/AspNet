using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_ListBox_Features_Header_and_Footer_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        foreach (EO.Web.ListBoxItem item in ListBox1.Items)
            item.Visible = true;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Label label = (Label)ListBox1.HeaderContainer.FindControl("lblTime");
        label.Text = DateTime.Now.ToString("t");
    }
}

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

public partial class Demos_Menu_Programming_Server_Side_Programming_Dynamically_Modifying_Menu_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Set elements width
        txtNewItemText.Style["width"] = "150px";
        btnAddTopItem.Style["width"] = "120px";
        btnAddSubItem.Style["width"] = "120px";
        btnReset.Style["width"] = "100px";

        //Reset the menu during initial load
        if (!CallbackPanel1.IsCallbackByMe)
            btnReset_Click(this, EventArgs.Empty);
    }

    #region SAMPLE_BLOCK#1
    protected void btnAddTopItem_Click(object sender, System.EventArgs e)
    {
        //Add to the main menu
        Menu1.Items.Add(txtNewItemText.Text);
    }

    protected void btnAddSubItem_Click(object sender, System.EventArgs e)
    {
        //Add to the first sub menu
        Menu1.Items[0].SubMenu.Items.Add(txtNewItemText.Text);
    }

    protected void btnReset_Click(object sender, System.EventArgs e)
    {
        Menu1.Items.Clear();
        Menu1.Items.Add("Menu Item 1");
        txtNewItemText.Text = string.Empty;
    }
    #endregion
}

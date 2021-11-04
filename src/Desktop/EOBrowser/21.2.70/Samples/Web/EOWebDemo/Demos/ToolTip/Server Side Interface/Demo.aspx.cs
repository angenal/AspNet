using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_ToolTip_Server_Side_Interface_Demo : System.Web.UI.Page
{
    #region SAMPLE_BLOCK#1
    protected void Page_Load(object sender, EventArgs e)
    {
        //Get the Label control inside the ToolTip's ContentTemplate
        Label label = (Label)ToolTip1.ContentContainer.FindControl("Label1");

        //Set the label's Text
        label.Text = "The Current Time Is: " + DateTime.Now.ToString();
    }
    #endregion
}

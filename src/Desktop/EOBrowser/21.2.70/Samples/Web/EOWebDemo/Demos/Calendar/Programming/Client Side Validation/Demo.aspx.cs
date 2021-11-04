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

public partial class Demos_Calendar_Programming_Client_Side_Validation_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, System.EventArgs e)
    {
        panInput.Visible = false;
        lblResult.Visible = true;
        lblResult.Text = string.Format("Start date is {0:d}, end date is {1:d}.",
            StartDatePicker.SelectedDate, EndDatePicker.SelectedDate);
    }
}

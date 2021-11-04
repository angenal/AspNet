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

public partial class Demos_Calendar_Features_Multi_Month_Calendar_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkButton1_Click(object sender, System.EventArgs e)
    {
        switch (LinkButton1.Text)
        {
            case "Switch To 2 Months":
                LinkButton1.Text = "Switch To 4 Months";
                Calendar1.MonthRows = 1;
                Calendar1.MonthColumns = 2;
                break;
            case "Switch To 4 Months":
                LinkButton1.Text = "Switch To 1 Month";
                Calendar1.MonthRows = 2;
                Calendar1.MonthColumns = 2;
                break;
            case "Switch To 1 Month":
                LinkButton1.Text = "Switch To 2 Months";
                Calendar1.MonthRows = 1;
                Calendar1.MonthColumns = 1;
                break;
        }
    }
}

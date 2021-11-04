using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_Rating_Selection_Precision_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cbPrecision_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (cbPrecision.SelectedIndex)
        {
            case 0:
                Rating1.Precision = EO.Web.RatingPrecision.Whole;
                break;
            case 1:
                Rating1.Precision = EO.Web.RatingPrecision.Half;
                break;
            case 2:
                Rating1.Precision = EO.Web.RatingPrecision.Exact;
                break;
        }
    }
    protected void btnGetValue_Click(object sender, EventArgs e)
    {
        lblValue.Text = "Result: " + Rating1.Value.ToString();
    }
}

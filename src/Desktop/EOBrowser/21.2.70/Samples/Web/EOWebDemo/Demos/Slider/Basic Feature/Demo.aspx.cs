using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_Slider_Basic_Feature_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        lblResult.Text = string.Format(
            "Slider Value: {0}, Range Slider Value: {1} - {2}",
            Slider1.Value, RangeSlider1.LowValue, RangeSlider1.HighValue);
    }
}

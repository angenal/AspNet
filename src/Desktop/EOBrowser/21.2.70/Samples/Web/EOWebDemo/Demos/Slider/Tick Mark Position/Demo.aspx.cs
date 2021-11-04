using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_Slider_Tick_Mark_Position_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        switch (cbLargeTMPos.SelectedIndex)
        {
            case 0:
                Slider1.LargeTickPosition = EO.Web.SliderTickPosition.None;
                break;
            case 1:
                Slider1.LargeTickPosition = EO.Web.SliderTickPosition.TopLeft;
                break;
            case 2:
                Slider1.LargeTickPosition = EO.Web.SliderTickPosition.BottomRight;
                break;
            case 3:
                Slider1.LargeTickPosition = EO.Web.SliderTickPosition.Both;
                break;
        }
        switch (cbSmallTMPos.SelectedIndex)
        {
            case 0:
                Slider1.SmallTickPosition = EO.Web.SliderTickPosition.None;
                break;
            case 1:
                Slider1.SmallTickPosition = EO.Web.SliderTickPosition.TopLeft;
                break;
            case 2:
                Slider1.SmallTickPosition = EO.Web.SliderTickPosition.BottomRight;
                break;
            case 3:
                Slider1.SmallTickPosition = EO.Web.SliderTickPosition.Both;
                break;
        }
    }
}

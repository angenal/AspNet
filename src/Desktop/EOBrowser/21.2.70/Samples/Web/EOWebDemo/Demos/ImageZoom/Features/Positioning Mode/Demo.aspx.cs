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

public partial class Demos_ImageZoom_Features_Positioning_Mode_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void rbX_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        switch (rbX.SelectedIndex)
        {
            case 0:
                ImageZoom1.PositionX = EO.Web.ImageZoomPosition.ScreenCenter;
                break;
            case 1:
                ImageZoom1.PositionX = EO.Web.ImageZoomPosition.ImageCenter;
                break;
            case 2:
                ImageZoom1.PositionX = EO.Web.ImageZoomPosition.Relative;

                //Optionally, you can set the offset
                //ImageZoom1.OffsetX = 10;
                break;
        }
    }

    protected void rbY_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        switch (rbY.SelectedIndex)
        {
            case 0:
                ImageZoom1.PositionY = EO.Web.ImageZoomPosition.ScreenCenter;
                break;
            case 1:
                ImageZoom1.PositionY = EO.Web.ImageZoomPosition.ImageCenter;
                break;
            case 2:
                ImageZoom1.PositionY = EO.Web.ImageZoomPosition.Relative;

                //Optionally, you can set the offset
                //ImageZoom1.OffsetY = 10;
                break;
        }
    }
}

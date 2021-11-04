using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_ToolTip_Animation_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Get the new animation type
        EO.Web.ToolTipAnimation animationType;        
        animationType = (EO.Web.ToolTipAnimation)Enum.Parse(
            typeof(EO.Web.ToolTipAnimation), cbAnimationType.SelectedValue.ToString());

        //Get the new animation duration
        int animationDuration = 300;
        int.TryParse(txtDuration.Text, out animationDuration);
        if (animationDuration < 50)
            animationDuration = 50;
        if (animationDuration > 5000)
            animationDuration = 5000;

        //Apply both and update ToolTip text
        ToolTip1.Animation = animationType;
        ToolTip1.AnimationDuration = animationDuration;
        ToolTip1.BodyHtml = string.Format(
            "<b>Animation Type:</b>&nbsp;{0}<br /><b>Animation Duration:</b>&nbsp;{1}",
            animationType, animationDuration);
    }
}

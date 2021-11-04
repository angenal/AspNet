using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_Captcha_Image_Customization_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region SAMPLE_BLOCK#1
    protected void btnApply_Click(object sender, EventArgs e)
    {
        //Set image options
        Captcha1.ImageNoiseLevel = GetNoiseLevel(lbImageNoiseLevel);
        Captcha1.ImageBackColor = GetColor(lbImageBackColor);
        Captcha1.TextFontFamily = lbTextFont.SelectedItem.Text;
        Captcha1.TextNoiseLevel = GetNoiseLevel(lbTextNoiseLevel);
        Captcha1.TextColor = GetColor(lbTextColor);
        Captcha1.LineNoiseLevel = GetNoiseLevel(lbLineNoiseLevel);
        Captcha1.LineColor = GetColor(lbLineColor);

        //Regenerate the image
        Captcha1.Reset();
    }
    #endregion

    private EO.Web.CaptchaNoiseLevel GetNoiseLevel(EO.Web.ListBox listBox)
    {
        switch (listBox.SelectedIndex)
        {
            case 0:
                return EO.Web.CaptchaNoiseLevel.None;
            case 1:
                return EO.Web.CaptchaNoiseLevel.Low;
            case 2:
                return EO.Web.CaptchaNoiseLevel.Medium;
            default:
                return EO.Web.CaptchaNoiseLevel.High;
        }
    }

    private System.Drawing.Color GetColor(EO.Web.ListBox listBox)
    {
        return System.Drawing.Color.FromName(listBox.SelectedItem.Text);
    }
}

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
using EO.Web;

public partial class Demos_MsgBox_Features_Button_Type_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        switch (DropDownList1.SelectedIndex)
        {
            case 0:
                MsgBox1.MsgBoxButtonType = MsgBoxButtonType.PushButton;
                break;
            case 1:
                MsgBox1.MsgBoxButtonType = MsgBoxButtonType.LinkButton;
                break;
            case 2:
                MsgBox1.MsgBoxButtonType = MsgBoxButtonType.ImageButton;
                break;
            case 3:
                MsgBox1.MsgBoxButtonType = MsgBoxButtonType.Custom;
                break;
        }
    }

    protected void Button1_Click(object sender, System.EventArgs e)
    {
        MsgBoxButton button = null;
        switch (MsgBox1.MsgBoxButtonType)
        {
            case MsgBoxButtonType.PushButton:
            case MsgBoxButtonType.LinkButton:
                button = new MsgBoxButton("OK");
                break;
            case MsgBoxButtonType.ImageButton:
                button = new MsgBoxButton("~/images/button_ok.gif");
                break;
            case MsgBoxButtonType.Custom:
                button = new MsgBoxButton("<div class='button_style'>OK</div>");
                break;
        }
        MsgBox1.Show("Hello",
            "This is a test message", null, button);
    }
}

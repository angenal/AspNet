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

public partial class Demos_Color_Picker_Features_Server_Event_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ColorPicker1_Change(object sender, System.EventArgs e)
    {
        Label1.Text = "Selected Color:" + ColorPicker1.Value.ToString();
    }

    protected void CheckBox1_CheckedChanged(object sender, System.EventArgs e)
    {
        ColorPicker1.AutoPostBack = CheckBox1.Checked;
    }
}

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

public partial class Demos_MsgBox_Features_Showing_Message_Box___Server_Side_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region SAMPLE_BLOCK#1
    protected void Button1_Click(object sender, System.EventArgs e)
    {
        //Display the message box
        MsgBox1.Show(
            "Hello", "This is a test message.", null,
            new EO.Web.MsgBoxButton("~/images/button_ok.gif"),
            new EO.Web.MsgBoxButton("~/images/button_cancel.gif"));

        //Message box displayed now
        Label1.Text = "MsgBox displayed at " + DateTime.Now.ToString();
    }
    #endregion
}

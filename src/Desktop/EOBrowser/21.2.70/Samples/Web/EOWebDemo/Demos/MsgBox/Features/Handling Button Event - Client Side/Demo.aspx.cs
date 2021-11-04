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

public partial class Demos_MsgBox_Features_Handling_Button_Event___Client_Side_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region SAMPLE_BLOCK#1
    protected void Button1_Click(object sender, System.EventArgs e)
    {
        //Call Show to display the message box with two buttons.
        //Note both button are provided a second argument
        //"on_button_clicked". This is the name of the client
        //side JavaScript function you wish the MsgBox control
        //to call when a button is clicked
        MsgBox1.Show(
            "Hello", "This is a test message.", null,
            new EO.Web.MsgBoxButton("OK", "on_button_clicked"),
            new EO.Web.MsgBoxButton("Cancel", "on_button_clicked"));

        Label1.Text = "MsgBox displayed at " + DateTime.Now.ToString();
    }
    #endregion
}

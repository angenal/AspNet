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

public partial class Demos_MsgBox_Features_Handling_Button_Event___Server_Side_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region SAMPLE_BLOCK#1
    protected void Button1_Click(object sender, System.EventArgs e)
    {
        //Display a message box with two buttons. Note
        //a CommandName value "Delete" is supplied to the
        //"Yes" button. This instructs the MsgBox to trigger
        //server side ButtonClick event when the button is
        //clicked
        MsgBox1.Show("Confirm Delete",
            "Please confirm if you wish to delete this record (Just a demo, nothing is to be deleted really).", null,
            new EO.Web.MsgBoxButton("Yes", null, "Delete"),
            new EO.Web.MsgBoxButton("Cancel"));

        Label1.Text = "MsgBox displayed at " + DateTime.Now.ToString();
    }
    #endregion

    #region SAMPLE_BLOCK#2
    protected void MsgBox1_ButtonClick(
        object sender, System.Web.UI.WebControls.CommandEventArgs e)
    {
        //Use the command name to determine which
        //button was clicked
        if (e.CommandName == "Delete")
        {
            //Proceed to delete....
            Label1.Text = "Record has been deleted (Just a demo, nothing was really deleted).";
        }
    }
    #endregion
}

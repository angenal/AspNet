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

public partial class Demos_AJAX_Uploader_Delay_Post_Back_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region SAMPLE_BLOCK#1
    protected void btnSend_Click(object sender, System.EventArgs e)
    {
        //Hide the uploader
        panInput.Visible = false;

        //Update the status text
        lblResult.Text = string.Format("You have uploaded {0} file(s).", AJAXUploader1.PostedFiles.Length);

    }
    #endregion
}

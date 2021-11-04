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

public partial class Demos_AJAX_Uploader_Client_Side_API_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Request.Form["__EVENTTARGET"] == "NO_FILE_SUBMIT")
        {
            //No file is submitted
            //Process the input here
        }
    }

    private void AJAXUploader1_FileUploaded(object sender, System.EventArgs e)
    {
        //A file has been submitted
        //Process the input here
    }
}

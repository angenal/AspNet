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

public partial class Demos_AJAX_Uploader_Server_Side_Event_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region SAMPLE_BLOCK#1
    protected void AJAXUploader1_FileUploaded(object sender, System.EventArgs e)
    {
        //Get all the posted files
        EO.Web.AJAXPostedFile[] files = AJAXUploader1.PostedFiles;

        //Delete all posted files
        string s = string.Empty;
        foreach (EO.Web.AJAXPostedFile file in files)
        {
            s += System.IO.Path.GetFileName(file.TempFileName);
            s += "<br />";
        }

        lblFiles.Text = s;
    }
    #endregion
}

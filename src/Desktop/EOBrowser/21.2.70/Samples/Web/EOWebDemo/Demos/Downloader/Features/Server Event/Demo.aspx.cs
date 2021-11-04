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

public partial class Demos_Downloader_Features_Server_Event_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Downloader1.FilePath = Request.MapPath("~/Demos/Demo.mdb");
    }

    #region SAMPLE_BLOCK#1
    private void Downloader1_Download(object sender, EO.Web.DownloadEventArgs e)
    {
        Label2.Text = "File downloaded at " + DateTime.Now;
    }
    #endregion
}

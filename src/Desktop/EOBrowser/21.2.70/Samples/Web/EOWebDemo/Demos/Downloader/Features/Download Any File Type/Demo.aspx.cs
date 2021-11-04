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

public partial class Demos_Downloader_Features_Download_Any_File_Type_Demo : System.Web.UI.Page
{
    #region SAMPLE_BLOCK#1
    protected void Page_Load(object sender, System.EventArgs e)
    {
        Downloader1.FilePath = MapPath("Demo.aspx");
        Downloader2.FilePath = MapPath("~/Images/BMW235.jpg");
    }
    #endregion
}

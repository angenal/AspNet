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

public partial class Demos_File_Explorer_Features_Permission_Control_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void chkAllowCreateFolder_CheckedChanged(object sender, System.EventArgs e)
    {
        FileExplorer1.AllowCreateFolder = chkAllowCreateFolder.Checked;
    }

    protected void chkAllowRenameFolder_CheckedChanged(object sender, System.EventArgs e)
    {
        FileExplorer1.AllowRenameFolder = chkAllowRenameFolder.Checked;
    }

    protected void chkAllowDeleteFolder_CheckedChanged(object sender, System.EventArgs e)
    {
        FileExplorer1.AllowDeleteFolder = chkAllowDeleteFolder.Checked;
    }

    protected void chkAllowUpload_CheckedChanged(object sender, System.EventArgs e)
    {
        FileExplorer1.AllowUpload = chkAllowUpload.Checked;
    }

    protected void chkAllowRenameFile_CheckedChanged(object sender, System.EventArgs e)
    {
        FileExplorer1.AllowRenameFile = chkAllowRenameFile.Checked;
    }

    protected void chkAllowDeleteFile_CheckedChanged(object sender, System.EventArgs e)
    {
        FileExplorer1.AllowDeleteFile = chkAllowDeleteFile.Checked;
    }
}

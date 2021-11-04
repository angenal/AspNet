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

public partial class Demos_File_Explorer_Features_Filtering_Files___By_Regular_Expression_Demo2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkButton1_Click(object sender, System.EventArgs e)
    {
        FileExplorer1.FileNameFilter = "2008-08[\\w\\W]*";
    }

    protected void LinkButton2_Click(object sender, System.EventArgs e)
    {
        FileExplorer1.FileNameFilter = null;
    }
}

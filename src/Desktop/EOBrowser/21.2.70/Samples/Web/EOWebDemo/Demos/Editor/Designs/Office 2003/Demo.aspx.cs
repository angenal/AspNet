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
using EO.Web;

public partial class Demos_Editor_Designs_Office_2003_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void tbSet_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        switch (tbSet.SelectedIndex)
        {
            case 0:
                Editor1.ToolBarSet = EditorToolBarSet.Basic;
                break;
            case 1:
                Editor1.ToolBarSet = EditorToolBarSet.Standard;
                break;
            case 2:
                Editor1.ToolBarSet = EditorToolBarSet.Full;
                break;
        }
    }
}

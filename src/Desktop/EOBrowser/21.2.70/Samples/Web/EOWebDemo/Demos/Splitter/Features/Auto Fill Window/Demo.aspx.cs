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

public partial class Demos_Splitter_Features_Auto_Fill_Window_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Attach an onclick handler to each of the hyper link
        //so that it calls our JavaScript function to open the
        //target page
        AttachHandler(HyperLink1);
        AttachHandler(HyperLink2);
        AttachHandler(HyperLink3);
    }

    private void AttachHandler(HyperLink link)
    {
        link.Attributes["onclick"] =
            string.Format("ShowAutoFillDemo('{0}');return false;", link.ClientID);
    }
}

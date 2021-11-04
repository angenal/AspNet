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

public partial class Demos_Editor_Features_Line_Break_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void rbBreakMode_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        switch (rbBreakMode.SelectedIndex)
        {
            case 0:
                Editor1.LineBreakMode = LineBreakMode.P;
                Editor1.Html = "Editor1.LineBreakMode = LineBreakMode.P;";
                break;
            case 1:
                Editor1.LineBreakMode = LineBreakMode.Br;
                Editor1.Html = "Editor1.LineBreakMode = LineBreakMode.Br;";
                break;
            case 2:
                Editor1.LineBreakMode = LineBreakMode.Div;
                Editor1.Html = "Editor1.LineBreakMode = LineBreakMode.Div;";
                break;
        }
    }
}

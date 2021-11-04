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

public partial class Demos_TabStrip_and_MultiPage_Features_Overlapping_TabStrip_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtNewDepth.Style["width"] = "100px";
        btnApply.Style["width"] = "80px";
    }
    private void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        args.IsValid = false;
        try
        {
            int n = int.Parse(txtNewDepth.Text);
            if ((n >= 0) && (n <= 15))
                args.IsValid = true;
        }
        /*CSTOVB*/
        catch
        /*CSTOVB:<id>catch|Catch Else</id>Catch*/
        {
        }
    }

    protected void btnApply_Click(object sender, System.EventArgs e)
    {
        if (!Page.IsValid)
            return;

        //Apply the new overlap depth
        TabStrip1.TopGroup.OverlapDepth = int.Parse(txtNewDepth.Text);
    }
}

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_ASPX_To_PDF_Basic_Feature_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region SAMPLE_BLOCK#1
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Export the current page as PDF
        ASPXToPDF1.RenderAsPDF();
    }
    #endregion
}

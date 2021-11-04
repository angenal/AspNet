using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_ASPX_To_PDF_Customize_Save_As_File_Name_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region SAMPLE_BLOCK#1
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Get the current time
        DateTime now = DateTime.Now;

        //Create a file name based on the current time
        string fileName = string.Format(
            "Report-{0:yyyy-MM-dd}.pdf", now);

        //Export the current page as PDF
        ASPXToPDF1.RenderAsPDF(fileName);
    }
    #endregion
}

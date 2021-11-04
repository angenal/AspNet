using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EO.Pdf;

public partial class Demos_ASPX_To_PDF_BeforeRender_Event_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region SAMPLE_BLOCK#1
    protected void ASPXToPDF1_BeforeRender(object sender, EventArgs e)
    {
        //Set the page size as A5
        HtmlToPdf.Options.PageSize = PdfPageSizes.A5;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Export the current page as PDF
        ASPXToPDF1.RenderAsPDF();
    }
    #endregion
}

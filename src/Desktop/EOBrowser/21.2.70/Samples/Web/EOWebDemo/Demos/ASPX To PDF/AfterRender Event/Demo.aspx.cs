using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using EO.Pdf;

public partial class Demos_ASPX_To_PDF_AfterRender_Event_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region SAMPLE_BLOCK#1
    protected void ASPXToPDF1_AfterRender(object sender, EventArgs e)
    {
        //Cast the Result property to HtmlToPdfResult
        HtmlToPdfResult result = HtmlToPdf.Result;

        //Get the result document
        PdfDocument doc = result.PdfDocument;

        //Create the "time stamp" text
        string html = "Created at " + DateTime.Now.ToString();

        //Render the text on each page
        try
        {
            foreach (PdfPage page in doc.Pages)
            {
                //Set the output area as the top of the page
                HtmlToPdf.Options.OutputArea = new RectangleF(1, 0.5f, 6.5f, 1);

                //Place time stamp on the page
                HtmlToPdf.ConvertHtml(html, page);
            }
        }
        finally
        {
            //Reset OutputArea to default value so that it
            //will not affect any further conversions
            HtmlToPdf.Options.OutputArea = new RectangleF();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Export the current page as PDF
        ASPXToPDF1.RenderAsPDF();
    }
    #endregion
}

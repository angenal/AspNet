using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EO.Pdf;

public partial class HtmlToPdf1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnConvert_Click(object sender, EventArgs e)
    {
        //Create a PdfDocument object and convert
        //the Url into the PdfDocument object
        PdfDocument doc = new PdfDocument();
        HtmlToPdf.ConvertUrl(txtUrl.Text, doc);

        //Setup HttpResponse headers
        HttpResponse resp = HttpContext.Current.Response;
        resp.Clear();
        resp.ClearHeaders();
        resp.ContentType = "application/pdf";

        //Send the PdfDocument to the client
        doc.Save(resp.OutputStream);

        Response.End();
    }
}

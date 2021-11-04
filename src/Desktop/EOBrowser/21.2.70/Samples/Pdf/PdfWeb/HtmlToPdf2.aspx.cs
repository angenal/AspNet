using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.IO;
using EO.Pdf;
using EO.Web;

public partial class HtmlToPdf2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private class PdfGenerator : DynamicDownloadContent
    {
        protected override void GenerateContent()
        {
            //Convert the Url to PdfDocument
            PdfDocument doc = new PdfDocument();
            try
            {
                HtmlToPdf.ConvertUrl(Arguments["Url"], doc);
            }
            catch (Exception ex)
            {
                //Output the exception message to the PDF
                //file in case the conversion fails
                doc = new PdfDocument();

                string errorMsg = string.Format(
                    "<p>Exception:</p><pre>{0}</pre>",
                    HttpUtility.HtmlEncode(ex.ToString()));

                HtmlToPdf.ConvertHtml(errorMsg, doc);
            }

            //Convert to a byte array
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            byte[] data = stream.ToArray();

            //Send to the client
            SetFileName("HtmlToPdf_Demo.pdf", data.Length);
            Write(data, 0, data.Length);
        }
    }

    protected void Downloader1_Download(object sender, EO.Web.DownloadEventArgs e)
    {
        //Save the Url argument
        NameValueCollection args = new NameValueCollection();
        args["Url"] = txtUrl.Text;

        //Start dynamic download
        e.DynamicDownload(typeof(PdfGenerator), args);

        //Hide the input panel
        divInput.Visible = false;
    }
}

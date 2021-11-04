using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using EO.Pdf;

public partial class HtmlToPdf3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnConvert_Click(object sender, EventArgs e)
    {
        //Create a temp file name as the output PDF file.
        //Because we use the Downloader control, the temp
        //file name extension does not matter
        string tempFileName = Path.GetTempFileName();

        // !!!!!! IMPORTANT !!!!!
        //In real life applications you must make sure the 
        //temp files are later deleted. For example, you 
        //can write the temp file name into a table along 
        //with the file creation time, then periodically 
        //scans the table to find expired files and delete 
        //them

        //Convert into the temp file
        HtmlToPdf.ConvertUrl(txtUrl.Text, tempFileName);

        //Allow Downloader to download this file. The
        //Downloader's SaveAsFileName is set to 
        //HtmlToPdf_Demo.pdf, so client will see that
        //file name instead of the real physical file name
        Downloader1.FilePath = tempFileName;

        divInput.Visible = false;
        divResult.Visible = true;
    }
}

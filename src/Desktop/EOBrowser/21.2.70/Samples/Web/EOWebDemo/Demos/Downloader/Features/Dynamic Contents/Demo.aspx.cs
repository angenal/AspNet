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
using System.Collections.Specialized;
using System.Text;

public partial class Demos_Downloader_Features_Dynamic_Contents_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region SAMPLE_BLOCK#1
    protected void Downloader1_Download(object sender, EO.Web.DownloadEventArgs e)
    {
        NameValueCollection args = new NameValueCollection();
        args["LineCount"] = TextBox1.Text;

        //Start a dynamic download
        e.DynamicDownload(typeof(ContentGenerator), args);
    }

    //You must create a new class that derives from 
    //EO.Web.DynamicDownloadContent to dynamically
    //generate the download content
    private class ContentGenerator : EO.Web.DynamicDownloadContent
    {
        protected override void GenerateContent()
        {
            //Get the argument we passed in
            int nLineCount = 0;
            try
            {
                nLineCount = int.Parse(this.Arguments["LineCount"]);
            }
            catch
            {
                nLineCount = 1;
            }

            //Set the file name. You should also specify
            //contentLength (the second parameter) if you
            //know the content length in advance. The
            //browser will not be able to display progress
            //information if contentLength is not set
            SetFileName("TestDownload.txt", -1);

            //Generates the content
            for (int i = 0; i < nLineCount; i++)
            {
                string line = string.Format("Line {0}\r\n", i + 1);

                byte[] buffer = Encoding.ASCII.GetBytes(line);

                Write(buffer, 0, buffer.Length);
            }
        }
    }
    #endregion
}

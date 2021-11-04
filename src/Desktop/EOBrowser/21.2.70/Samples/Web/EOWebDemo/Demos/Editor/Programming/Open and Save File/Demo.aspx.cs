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
using System.IO;
using System.Text.RegularExpressions;

public partial class Demos_Editor_Programming_Open_and_Save_File_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            LoadFile();
    }

    protected void Editor1_Save(object sender, System.EventArgs e)
    {
        SaveFile();
    }

    private string GetFileName()
    {
        return Server.MapPath("~/Demos/EditorContent.html");
    }

    private void LoadFile()
    {
        string fileName = GetFileName();
        if (File.Exists(fileName))
        {
            using (StreamReader reader = File.OpenText(GetFileName()))
            {
                string html = reader.ReadToEnd();

                Regex regex = new Regex(@"<body[\w\W]*>([\w\W]*)</body>", RegexOptions.IgnoreCase);
                Match match = regex.Match(html);
                if (match.Success)
                    Editor1.Html = match.Value;
                else
                    Editor1.Html = html;
            }
        }
    }

    private void SaveFile()
    {
        try
        {
            using (StreamWriter writer = File.CreateText(GetFileName()))
            {
                string html = Editor1.Html;

                if (FullHTML.Checked)
                    html = string.Format("<html><head></head><body>{0}</body></htm>", html);

                writer.Write(html);
            }
        }
        catch (Exception e)
        {
            Editor1.Html = "An exception has occured: " + e.Message + "<br />" +
                "Please check whether the application has permission to create " +
                "the file.";
        }
    }
}

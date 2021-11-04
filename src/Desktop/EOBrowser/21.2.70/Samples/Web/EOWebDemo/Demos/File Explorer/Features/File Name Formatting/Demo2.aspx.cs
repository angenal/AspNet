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

public partial class Demos_File_Explorer_Features_File_Name_Formatting_Demo2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void FileExplorer1_FileUploaded(object sender, EO.Web.FileExplorerEventArgs e)
    {
        string fileName = e.FileName;

        //Prefix the file name with current date information
        string dir = System.IO.Path.GetDirectoryName(fileName);
        fileName = System.IO.Path.GetFileName(fileName);
        fileName = string.Format("{0:yyyy-MM-dd}_{1}", DateTime.Now, fileName);
        fileName = System.IO.Path.Combine(dir, fileName);

        //Make sure no other files in the directory have the same name
        fileName = EO.Web.FileExplorer.CreateUniqueFileName(fileName);

        //Rename the file
        System.IO.File.Move(e.FileName, fileName);
    }
}

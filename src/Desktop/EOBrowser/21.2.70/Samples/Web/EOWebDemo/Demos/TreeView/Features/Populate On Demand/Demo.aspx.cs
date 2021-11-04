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

public partial class Demos_TreeView_Features_Populate_On_Demand_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region SAMPLE_BLOCK#1

    protected void TreeView1_ItemPopulate(object sender, EO.Web.NavigationItemEventArgs e)
    {
        //Get the parent node
        EO.Web.TreeNode parentNode = (EO.Web.TreeNode)e.NavigationItem;

        //Get the root path
        string parentDir = Server.MapPath("~/Demos");

        //Combine the root path with the node's Value property,
        //in which we stores the relative path to the root
        if (parentNode.Value == null)
            parentNode.Value = string.Empty;
        parentDir = Path.Combine(parentDir, parentNode.Value);

        //Find all the directories
        string[] dirs = Directory.GetDirectories(parentDir);
        foreach (string dir in dirs)
        {
            string dirName = Path.GetFileName(dir);
            EO.Web.TreeNode dirNode = new EO.Web.TreeNode(dirName);

            //Directories can have child items. So at here we
            //store the path associated with this directory to
            //its Value property and set PopulateOnDemand to true
            dirNode.Value = Path.Combine(parentNode.Value, dir);
            dirNode.PopulateOnDemand = true;

            parentNode.SubGroup.Nodes.Add(dirNode);
        }

        //Find all files
        string[] files = Directory.GetFiles(parentDir);
        foreach (string file in files)
        {
            string fileName = Path.GetFileName(file);
            EO.Web.TreeNode fileNode = new EO.Web.TreeNode(fileName);
            parentNode.SubGroup.Nodes.Add(fileNode);
        }
    }
    #endregion
}

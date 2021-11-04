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

public partial class Demos_Splitter_Features_Auto_Fill_Contents_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CallbackPanel1_Execute(object sender, EO.Web.CallbackEventArgs e)
    {
        //Find the node that was clicked
        EO.Web.TreeNode node =
            (EO.Web.TreeNode)TreeView1.FindItem(e.Parameter);

        Grid1.Items.Clear();
        foreach (EO.Web.TreeNode childNode in node.ChildNodes)
        {
            EO.Web.GridItem item = Grid1.CreateItem();
            item.Cells[1].Value = childNode.Text;
            item.Cells[2].Value = childNode.ChildNodes.Count;
            Grid1.Items.Add(item);
        }
    }
}

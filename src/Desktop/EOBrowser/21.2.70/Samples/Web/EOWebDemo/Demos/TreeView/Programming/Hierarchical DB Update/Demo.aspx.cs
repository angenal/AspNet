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

public partial class Demos_TreeView_Programming_Hierarchical_DB_Update_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Usually you would use IsPostBack to determine whether
        //you need to populate the TreeView. However that does
        //not work at here because this Demo itself is being
        //dynamically loaded by a Callback, which is implemented
        //as a HTTP POST and result in IsPostBack returning true
        if (!CallbackPanel1.IsCallbackByMe)
        {
            TreeView1.DataSource = GetDataSet();
            TreeView1.DataBind();
        }
    }

    protected void Button1_Click(object sender, System.EventArgs e)
    {
        Label1.Text = "Changes saved to data source at " + DateTime.Now.ToString();
    }

    protected void Button2_Click(object sender, System.EventArgs e)
    {
        TreeView1.DataSource = GetDataSet();
        TreeView1.DataBind();
        Label2.Text = "Repopulated from data source at " + DateTime.Now.ToString();
    }

    private DataSet GetDataSet()
    {
        //Create an in-memory DataSet object and stores
        //it in the Session object. This is not necessary
        //if you creates the DataSet directly from your
        //back-end database.
        string key = GetType().FullName + "_data";
        DataSet data = Session[key] as DataSet;
        if (data != null)
            return (DataSet)data;

        data = CreateDataSet();
        Session[key] = data;
        return data;
    }

    private DataSet CreateDataSet()
    {
        //Define a DataSet
        DataSet ds = new DataSet();

        //Create the DataTable object
        DataTable table = ds.Tables.Add("Folders");
        DataColumn folderID =
            table.Columns.Add("FolderID", typeof(int));
        DataColumn parentFolderID =
            table.Columns.Add("ParentFolderID", typeof(int));
        DataColumn sortOrder =
            table.Columns.Add("SortOrder", typeof(float));
        DataColumn folderName =
            table.Columns.Add("FolderName", typeof(string));
        table.Rows.Add(new object[] { 1, null, 1, "Local Disk (C:)" });
        table.Rows.Add(new object[] { 2, null, 2, "Local Disk (D:)" });
        table.Rows.Add(new object[] { 3, null, 3, "Local Disk (E:)" });
        table.Rows.Add(new object[] { 4, 1, 1, "My Documents" });
        table.Rows.Add(new object[] { 5, 1, 2, "Program Files" });
        table.Rows.Add(new object[] { 6, 1, 3, "Windows" });
        table.Rows.Add(new object[] { 7, 1, 4, "Temp" });
        table.Rows.Add(new object[] { 8, 2, 1, "Data" });
        table.Rows.Add(new object[] { 9, 2, 2, "Backup" });

        //The following code adds a calculated column and set the
        //sort order. If you populate the DataSet from your back
        //end database, you should do this in your SQL statement, 
        //which should be (presumably) more efficient

        //Add a calculated column that concatenates "FolderID"
        //and "SortOrder" into a single value. For example, 
        //FolderID 1 and SortOrder 3 results in a combined string
        //value "1,3". This value is being populated into
        //each TreeNode's Value property, so that later on
        //we will be able to tell each TreeNode's folder ID and
        //sort order without consulting the data source again
        DataColumn nodeData =
            table.Columns.Add("NodeData", typeof(string));
        nodeData.Expression = "Convert(FolderID, 'System.String') + ',' + Convert(SortOrder, 'System.String')";

        //Setting the sort order
        table.DefaultView.Sort = "SortOrder Asc";

        //Define relations
        DataRelation r = ds.Relations.Add(folderID, parentFolderID);
        r.Nested = true;

        return ds;
    }

    protected void TreeView1_ItemMoved(object sender, EO.Web.TreeNodeMovedEventArgs e)
    {
        int newParentID = GetNodeID(e.Node.ParentNode);
        if (newParentID != GetNodeID(e.OldParent))
        {
            //Need to update this node's parent ID
            UpdateParentID(GetNodeID(e.Node), newParentID);
        }

        //Continue to update sort order
        UpdateSortOrder(e);
    }

    // Retrieve node ID (folderID) from a TreeNode object
    private int GetNodeID(EO.Web.TreeNode node)
    {
        if (node.Value == null)
            return -1;

        return int.Parse(node.Value.Split(',')[0]);
    }

    // Retrieve sort order from a TreeNode object
    private float GetSortOrder(EO.Web.TreeNode node)
    {
        if (node.Value == null)
            return 0;

        return float.Parse(node.Value.Split(',')[1], System.Globalization.CultureInfo.InvariantCulture);
    }

    private void UpdateSortOrder(EO.Web.TreeNodeMovedEventArgs e)
    {
        EO.Web.TreeNode node = e.Node;
        int nodeId = GetNodeID(node);
        EO.Web.TreeNode parentNode = node.ParentNode;

        //Find out the previous node's sort order
        float prevNodeSortOrder = 0;
        if (e.PreviousNode != null)
            prevNodeSortOrder = GetSortOrder(e.PreviousNode);

        //Find out next node's sort order
        float nextNodeSortOrder = prevNodeSortOrder + 2;
        if (e.NextNode != null)
            nextNodeSortOrder = GetSortOrder(e.NextNode);

        //Calculate the new sort order
        float newSortOrder = (prevNodeSortOrder + nextNodeSortOrder) / 2;

        //Update your database....
        UpdateSortOrder(nodeId, newSortOrder);

        //The following two lines are new
        int folderId = int.Parse(node.Value.Split(',')[0]);
        node.Value =
            string.Format("{0}, {1}", folderId, newSortOrder);
    }

    private void UpdateParentID(int nodeId, int parentId)
    {
        //Here we update our in-memory DataSet object,
        //You should change this to update your back-end
        //database

        DataSet ds = GetDataSet();
        DataTable table = ds.Tables["Folders"];
        DataRow[] rows = table.Select("folderId = " + nodeId.ToString());
        if (rows.Length > 0)
        {
            if (parentId == -1)    //No parent node
                rows[0]["ParentFolderID"] = DBNull.Value;
            else
                rows[0]["ParentFolderID"] = parentId;
        }
    }

    private void UpdateSortOrder(int nodeId, float newSortOrder)
    {
        //Here we update our in-memory DataSet object,
        //You should change this to update your back-end
        //database

        DataSet ds = GetDataSet();
        DataTable table = ds.Tables["Folders"];
        DataRow[] rows = table.Select("folderId = " + nodeId.ToString());
        if (rows.Length > 0)
            rows[0]["SortOrder"] = newSortOrder;
    }
}

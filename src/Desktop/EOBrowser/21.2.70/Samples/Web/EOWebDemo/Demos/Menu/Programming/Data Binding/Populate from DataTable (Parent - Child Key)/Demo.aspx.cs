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

public partial class Demos_Menu_Programming_Data_Binding_Populate_from_DataTable__Parent___Child_Key_Demo : System.Web.UI.Page
{
    #region SAMPLE_BLOCK#1
    protected void Page_Load(object sender, System.EventArgs e)
    {
        DataSet mainDs = CreateDataSet();

        // Specify the data source. Here we bind to the Menu. You
        // can also bind to any sub menu.
        Menu1.DataSource = mainDs;

        // Bind the "Website" column in the table to 
        // "NavigateUrl" property.
        EO.Web.DataBinding binding = new EO.Web.DataBinding();
        binding.DataField = "FolderName";
        binding.Property = "Text-Html";
        Menu1.Bindings.Add(binding);

        // Populate from the data source (mainTable);
        Menu1.DataBind();

        // Bind the mainTable to DataGrid for demostration purpose.
        DataGrid1.DataSource = mainDs.Tables["Folders"];
        DataGrid1.DataBind();
    }
    #endregion

    #region SAMPLE_BLOCK#2
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
        DataColumn folderName =
            table.Columns.Add("FolderName", typeof(string));
        table.Rows.Add(new object[] { 1, null, "Root" });
        table.Rows.Add(new object[] { 2, 1, "My Documents" });
        table.Rows.Add(new object[] { 3, 1, "Windows" });
        table.Rows.Add(new object[] { 4, 3, "System32" });
        table.Rows.Add(new object[] { 5, 3, "Temp" });

        //Define relations
        DataRelation r = ds.Relations.Add(folderID, parentFolderID);
        r.Nested = true;

        return ds;
    }
    #endregion
}

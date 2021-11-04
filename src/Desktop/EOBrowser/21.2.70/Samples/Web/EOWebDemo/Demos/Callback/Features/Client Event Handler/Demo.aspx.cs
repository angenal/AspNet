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

public partial class Demos_Callback_Features_Client_Event_Handler_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InitDataSource();

        if (!CallbackPanel1.IsCallbackByMe)
            BindData();
    }

    //Here we save the data in a session variable. The same
    //data can also be saved in view state.
    private DataTable m_DataSource;
    private const string DataSourceVarName = "Callback.Features.ClientEventHandlers.DataSource";

    private void InitDataSource()
    {
        //Initialize the data source only once
        m_DataSource = (DataTable)Session[DataSourceVarName];
        if (m_DataSource == null)
        {
            //Create the DataTable object
            DataTable table = new DataTable();
            DataColumn folderID =
                table.Columns.Add("ItemID", typeof(int));
            DataColumn parentFolderID =
                table.Columns.Add("ItemDescription", typeof(string));
            table.Rows.Add(new object[] { 1, "Item 1" });
            table.Rows.Add(new object[] { 2, "Item 2" });
            table.Rows.Add(new object[] { 3, "Item 3" });

            Session[DataSourceVarName] = table;
            m_DataSource = table;
        }
    }

    private void BindData()
    {
        DataGrid1.DataSource = m_DataSource;
        DataGrid1.DataBind();
    }

    protected void DataGrid1_EditCommand(object source,
        System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        DataGrid1.EditItemIndex = e.Item.ItemIndex;
        BindData();
    }

    protected void DataGrid1_CancelCommand(object source,
        System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        DataGrid1.EditItemIndex = -1;
        BindData();
    }

    protected void DataGrid1_UpdateCommand(object source,
        System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        //Get the new value and update our data
        TextBox tbDesc = (TextBox)e.Item.Cells[1].FindControl("txtDesc");
        m_DataSource.Rows[e.Item.ItemIndex]["ItemDescription"] = tbDesc.Text;

        //Turn off edit mode for the grid
        DataGrid1.EditItemIndex = -1;

        //Repopulate the grid with new data
        BindData();
    }
}

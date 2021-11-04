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
using EO.Web;

public partial class Demos_AJAX_Uploader_File_List_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #region SAMPLE_BLOCK#1
    protected void AJAXUploader1_FileUploaded(object sender, System.EventArgs e)
    {
        //Refresh the Grid
        DataGrid1.DataSource = AJAXPostedFileList1.Items;
        DataGrid1.DataBind();
    }

    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        //Get the AJAXPostedFile object associated to this row
        AJAXPostedFile file = (AJAXPostedFile)e.Item.DataItem;

        if (file != null)
        {
            //Set the file name label
            Label label = (Label)e.Item.Cells[0].FindControl("lblFileName");
            label.Text = System.IO.Path.GetFileName(file.FinalFileName);

            //Set the file size label
            label = (Label)e.Item.Cells[1].FindControl("lblFileSize");
            label.Text = file.Length.ToString();
        }
    }

    protected void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        //Delete the file
        AJAXPostedFileList1.Delete(e.Item.ItemIndex);

        //Refresh the Grid
        DataGrid1.DataSource = AJAXPostedFileList1.Items;
        DataGrid1.DataBind();
    }
    #endregion
}

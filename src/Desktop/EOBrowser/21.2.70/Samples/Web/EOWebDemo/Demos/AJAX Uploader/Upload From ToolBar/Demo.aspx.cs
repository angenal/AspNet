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

public partial class Demos_AJAX_Uploader_Upload_From_ToolBar_Demo : System.Web.UI.Page
{
    #region SAMPLE_BLOCK#1
    protected void Page_Load(object sender, System.EventArgs e)
    {
        //Get the toolbar control
        EO.Web.ToolBar toolBar = (EO.Web.ToolBar)
            Editor1.HeaderContainer.FindControl("ToolBar1");
        //Get the uploader control
        EO.Web.AJAXUploader uploader = (EO.Web.AJAXUploader)
            Editor1.FooterContainer.FindControl("AJAXUploader1");

        //Set the uploader's StartToolBarButton and StopToolBarButton.
        //These two properties associate the toolbar buttons to the
        //uploader
        uploader.StartToolBarButton = toolBar.ClientID + ":" + "Upload";
        uploader.StopToolBarButton = toolBar.ClientID + ":" + "CancelUpload";
    }
    #endregion

    #region SAMPLE_BLOCK#2
    protected void AJAXUploader1_FileUploaded(object sender, System.EventArgs e)
    {
        //Find the CallbackPanel
        EO.Web.CallbackPanel cp = (EO.Web.CallbackPanel)
            Editor1.FooterContainer.FindControl("CallbackPanel1");

        //Find the AJAXPostedFileList object
        AJAXPostedFileList list =
            (AJAXPostedFileList)cp.FindControl("AJAXPostedFileList1");

        //Update the file list Repeater
        UpdateFileList(cp, list);
    }

    protected void Repeater1_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        //Get the AJAXPostedFile object associated to this row
        AJAXPostedFile file = (AJAXPostedFile)e.Item.DataItem;

        if (file != null)
        {
            //Set the file name label
            Label label = (Label)e.Item.FindControl("lblFileName");
            label.Text = System.IO.Path.GetFileName(file.FinalFileName);
        }
    }

    protected void Repeater1_ItemCommand(object sender, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
        //Find the CallbackPanel
        EO.Web.CallbackPanel cp = (EO.Web.CallbackPanel)
            Editor1.FooterContainer.FindControl("CallbackPanel1");

        //Find the AJAXPostedFileList
        AJAXPostedFileList list =
            (AJAXPostedFileList)cp.FindControl("AJAXPostedFileList1");

        //Delet the file from the list
        list.Delete(e.Item.ItemIndex);

        //Update the file list repeater
        UpdateFileList(cp, list);
    }

    private void UpdateFileList(EO.Web.CallbackPanel cp, AJAXPostedFileList list)
    {
        //Refresh the Repeater
        Repeater repeater = (Repeater)cp.FindControl("Repeater1");
        repeater.DataSource = list.Items;
        repeater.DataBind();

        //Display the repeater only when the list is not empty
        Panel panel = (Panel)cp.FindControl("Panel1");
        panel.Visible = list.Items.Length > 0;
    }

    protected void Editor1_Save(object sender, System.EventArgs e)
    {
        //Use the following code to get the Editor text
        string html = Editor1.Html;
        //Process the HTML....

        //Find the CallbackPanel
        EO.Web.CallbackPanel cp = (EO.Web.CallbackPanel)
            Editor1.FooterContainer.FindControl("CallbackPanel1");

        //Find the AJAXPostedFileList
        AJAXPostedFileList list =
            (AJAXPostedFileList)cp.FindControl("AJAXPostedFileList1");

        //Use the following code to get the attachments
        foreach (AJAXPostedFile file in list.Items)
        {
            string fileName = file.FinalFileName;

            //Process the file.....
        }
    }
    #endregion
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class ASPXToPDF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            BindNoteList();
    }

    private void BindNoteList()
    {
        //Populate the list from session variable
        ArrayList list = Session["note_list"] as ArrayList;
        if ((list == null) || (list.Count == 0))
        {
            panListEmpty.Visible = true;
            rptNotes.Visible = false;
        }
        else
        {
            panListEmpty.Visible = false;
            rptNotes.Visible = true;
            rptNotes.DataSource = list;
            rptNotes.DataBind();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //Add the note into session variable
        ArrayList list = Session["note_list"] as ArrayList;
        if (list == null)
        {
            list = new ArrayList();
            Session["note_list"] = list;
        }
        list.Add(txtNote.Text);
        BindNoteList();
    }

    protected void btnToPDF_Click(object sender, EventArgs e)
    {
        //Hide "Add" and "Render as PDF" section
        panAdd.Visible = false;
        panToPDF.Visible = false;

        //Render the result as PDF
        ASPXToPDF1.RenderAsPDF("notes.pdf");
    }
}

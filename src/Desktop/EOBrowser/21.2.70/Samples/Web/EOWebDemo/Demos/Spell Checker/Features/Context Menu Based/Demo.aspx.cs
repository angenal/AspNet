using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Demos_Spell_Checker_Features_Context_Menu_Based_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataGrid1.DataSource = CreateDataTable();
            DataGrid1.DataBind();
        }
    }

    private DataTable CreateDataTable()
    {
        DataTable table = new DataTable();
        table.Columns.Add("Model", typeof(string));
        table.Columns.Add("Description", typeof(string));
        table.Rows.Add(new object[]{"F-15 Eagle", 
                                            "All-weather tactical fighter designed to gain and maintan air superiority in areial combat."});
        table.Rows.Add(new object[]{"F-16 Falcon", 
                                           "Multirole jet fighter aircraft originaly developed by General Dynamics."});
        table.Rows.Add(new object[]{"F-22 Raptor", 
                                           "A stealth air superority fighter, also has multiple capabilitties such as ground attack and electronic warfare."});
        return table;
    }

    protected void ScriptEvent1_Command(object sender, CommandEventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<p>The following cells have been changed:</p>");
        object[] changes = (object[])e.CommandArgument;
        for (int i = 0; i < changes.Length; i++)
        {
            object[] change = (object[])changes[i];

            int rowIndex = (int)change[0];
            int cellIndex = (int)change[1];
            string newText = (string)change[2];

            sb.Append(string.Format("<p>Row={0}, Cell={1}, New Text={2}</p>", rowIndex, cellIndex, newText));
        }

        panResult.InnerHtml = sb.ToString();

        panCheck.Visible = false;
        panResult.Visible = true;
    }
}

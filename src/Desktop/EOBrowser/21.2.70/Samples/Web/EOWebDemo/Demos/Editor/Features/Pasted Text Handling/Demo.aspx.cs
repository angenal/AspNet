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

public partial class Demos_Editor_Features_Pasted_Text_Handling_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void tbFilter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //Get the selected option
        EO.Web.EditorPasteFilter filter = (EO.Web.EditorPasteFilter)
            Enum.Parse(typeof(EO.Web.EditorPasteFilter), tbFilter.SelectedValue);

        //Set the new paste filter
        Editor1.PasteFilter = filter;
    }
}

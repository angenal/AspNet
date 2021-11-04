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
using EO.Web.Demo;

public partial class Demos_Grid_Features_Conditional_Formatting_Demo : System.Web.UI.Page
{
    #region SAMPLE_BLOCK#1
    protected void Page_Load(object sender, System.EventArgs e)
    {
        using (DemoDB db = new DemoDB())
        {
            //Populate the grid from the data source. Here we 
            //creates a new field "StyleSet". The value of 
            //"StyleSet" is 'support' if PostedBy is 'support',
            //Otherwise it's empty. This field is used by the
            //Grid's StyleSetIDField property
            string sql = "SELECT IIF(PostedBy='eo_support', 'support', '') as StyleSet, * FROM Topics";
            Grid1.DataSource = db.ExecuteReader(sql);
            Grid1.DataBind();
        }
    }
    #endregion
}

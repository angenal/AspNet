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

public partial class Demos_Grid_Features_Custom_Column_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Grid1.DataSource =
            new object[]{
                                new object[]{"Q1. Knowledge of the product", 0},
                                new object[]{"Q2. Courteousness", 0},
                                new object[]{"Q3. Willingness to help", 0},
                                new object[]{"Q4. Efficiency/quickness", 0},
                                new object[]{"Q5. Ability to complete transaction", 0},
                            };

        Grid1.DataBind();
    }
}

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

public partial class Demos_Grid_Features_Custom_Column___Advanced_Demo : System.Web.UI.Page
{
    #region SAMPLE_BLOCK#1
    protected void Page_Load(object sender, System.EventArgs e)
    {
        //Get the Repeater control so that we can fill it
        //later
        EO.Web.CustomColumn productColumn =
            (EO.Web.CustomColumn)Grid1.Columns[1];
        Repeater productRepeater =
            (Repeater)productColumn.EditorInstance.FindControl("Products");

        //Fill the repeater from the database
        using (DemoDB db = new DemoDB())
        {
            productRepeater.DataSource = db.ExecuteReader("SELECT * FROM Products");
            productRepeater.DataBind();
        }
    }
    #endregion

    #region SAMPLE_BLOCK#2
    protected void Button1_Click(object sender, System.EventArgs e)
    {
        foreach (EO.Web.GridItem item in Grid1.AddedItems)
        {
            //Get the product name
            string productName = (string)item.Cells[1].Value;

            //Get the product quantity. Note user may have
            //entered something other than a number, so we
            //also check that
            int productQty = 0;
            try
            {
                productQty = int.Parse((string)item.Cells[2].Value);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

                //Ignore the exception
            }

            //The Grid provides all the information about what
            //have been added/changed, but it does not save them
            //to the database for you. You should write code to
            //use whatever means that's best/easiest for you to
            //save the newly added item here

            //Add your code to save productName and productQty
            //into the database
        }

        Label1.Visible = true;
    }
    #endregion
}

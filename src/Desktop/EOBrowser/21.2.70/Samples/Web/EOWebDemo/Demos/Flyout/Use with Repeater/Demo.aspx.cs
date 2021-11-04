using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Demos_Flyout_Use_with_Repeater_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Repeater1.DataSource = CreateDataTable();
        Repeater1.DataBind();
    }

    private DataTable CreateDataTable()
    {
        DataTable table = new DataTable();
        table.Columns.Add("small_tn_path", typeof(string));
        table.Columns.Add("title", typeof(string));
        table.Columns.Add("cast", typeof(string));
        table.Columns.Add("rating", typeof(string));
        table.Columns.Add("format", typeof(string));
        table.Columns.Add("review_rating", typeof(float));
        table.Columns.Add("total_reviews", typeof(int));
        table.Columns.Add("list_price", typeof(float));
        table.Columns.Add("price", typeof(float));

        table.Rows.Add(
            "../Images/tn_avatar.jpg",
            "Avatar (Two-Disc Blu-ray/DVD Combo) [Blu-ray] (2009)",
            "<b>Starring</b>: <a href='javascript:void(0);'>Sam Worthington</a>, <a href='javascript:void(0)'>Zoe Saldana</a> <b>Director</b>: <a href='javascript:void(0);'>James Cameron</a> ",
            "../Images/pg_13.gif",
            "../Images/blu_ray.gif",
            3.4F,
            1143,
            39.99,
            14.99);
        table.Rows.Add("../Images/tn_true_blood.jpg",
            "True Blood: The Complete Second Season (HBO Series)",
            "<b>Starring:</b> <a href='javascript:void(0);'>Anna Paquin</a>, <a href='javascript:void(0)'>Stephen Moyer</a>, <a href='javascript:void(0);'>More...</a>",            
            "../Images/pg_13.gif",
            "../Images/dvd.gif",
            4F,
            117,
            59.99,
            32.99);
        table.Rows.Add("../Images/tn_24.jpg",
            "24: Season Eight",
            "<b>Starring:</b> <a href='javascript:void(0);'>Kiefer Sutherland</a>, <a href='javascript:void(0);'>Mary Lynn Rajskub</a>",
            "../Images/pg_13.gif",
            "../Images/dvd.gif",
            5F,
            10,
            59.98,
            38.99);
        table.Rows.Add("../Images/tn_lost.jpg",
            "Lost: The Complete Sixth And Final Season",
            "<b>Starring:</b><a href='javascript:void(0);'>Sam Anderson</a>, <a href='javascript:void(0);'>Adewale Akinnuoye-Agbaje</a>, <a href='javascript:void(0);'>More...</a>",
            "../Images/pg_13.gif",
            "../Images/dvd.gif",
            4.6F,
            22,
            279.99,
            194.99);

        return table;
    }

    protected string GetRatingBarWidth(object rating)
    {
        return string.Format("{0}px", (int)Math.Round((float)rating * 13));
    }

    protected string GetSavings()
    {
        float listPrice = (float)Eval("list_price");
        float price = (float)Eval("price");
        float saving = listPrice - price;
        return string.Format("${0:##.00} ({1}%)", saving, (int)(saving * 100 / listPrice));
    }
}

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Demos_ComboBox_Features_Drop_Down_Template___Advanced_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Grid1.DataSource = CreateDataSource();
            Grid1.DataBind();
        }
    }

    private DataTable CreateDataSource()
    {
        DataTable table = new DataTable();
        table.Columns.Add("Title", typeof(string));
        table.Columns.Add("Artist", typeof(string));
        table.Columns.Add("Price", typeof(decimal));
        table.Rows.Add("Rave On Buddy Holly", "Various Artists", 7.99);
        table.Rows.Add("The Harrow & The Harvest", "Gillian Welch", 7.99);
        table.Rows.Add("Taking Back Sunday", "Taking Back Sunday", 7.99);
        table.Rows.Add("Four", "Beyonce", 11.99);
        table.Rows.Add("Culture of Fear", "Thievery Corporation", 8.99);
        table.Rows.Add("When The Sun Goes Down", "Selena Gomez", 9.49);
        table.Rows.Add("Better Day", "Dolly Parton", 7.49);
        table.Rows.Add("20 - Volume 4", "Martin & Wood Medeski", 1.98);
        table.Rows.Add("The Runner", "The Boxer Rebellion", 3.96);
        table.Rows.Add("How Come b/w Good I'm Wishing", "Avi Baffalo", 1.89);
        table.Rows.Add("Whenever", "Cirque Du Soleil", 1.98);
        table.Rows.Add("Something For The Pain", "Redlight King", 5.00);
        table.Rows.Add("Pint of Blood", "Jolie Holland", 5.00);
        table.Rows.Add("This Loud Morning", "David Cook", 11.99);
        table.Rows.Add("Weekend At Burnie's", "Curren$y", 5.00);
        table.Rows.Add("Songs In A Minor", "Alicia Keys", 13.99);
        table.Rows.Add("Finally Famous", "Big Sean", 5.00);
        table.Rows.Add("Liquid Zoo", "100 Monkeys", 7.99);
        table.Rows.Add("Lightbox", "Spiro", 9.99);
        table.Rows.Add("I'm American", "Billy Ray Cyrus", 5.99);
        return table;
    }
}

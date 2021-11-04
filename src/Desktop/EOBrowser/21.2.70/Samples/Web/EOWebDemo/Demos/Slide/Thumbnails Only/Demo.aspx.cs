using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Demos_Slide_Thumbnails_Only_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Slide1.DataSource = CreateDataSource();
        Slide1.DataBind();
    }

    private DataTable CreateDataSource()
    {
        DataTable table = new DataTable();
        table.Columns.Add("image", typeof(string));
        table.Columns.Add("thumbnail", typeof(string));
        table.Columns.Add("title", typeof(string));
        table.Columns.Add("summary", typeof(string));
        table.Columns.Add("link_text", typeof(string));

        table.Rows.Add(
            "../Images/yaris_big.gif",
            "../Images/yaris_small.gif",
            "Toyota Yaris",
            "The Toyota Yaris is a subcompact car produced by Toyota since 1999, replacing the Starlet.",
            "Best Subcompact Car");
        table.Rows.Add(
            "../Images/cruze_big.gif",
            "../Images/cruze_small.gif",
            "Chevrolet Cruze",
            "The Chevrolet Cruze is a small car that has been made by General Motors since 2008.",
            "Best Compact Car");
        table.Rows.Add(
            "../Images/prius_big.gif",
            "../Images/prius_small.gif",
            "Toyota Prius",
            "The Toyota Prius is a full hybrid electric automobile developed by Toyota and manufactured by the company since 1997. Initially offered as a 4-door sedan, it has been produced only as a 5-door hatchback from 2003 onwards.",
            "Best Compact Hybrid");
        table.Rows.Add(
            "../Images/miata_big.gif",
            "../Images/miata_small.gif",
            "Mazda MX-5 Miata",
            "The Mazda MX-5, released as the Mazda MX-5 Miata in North America and as the Eunos Roadster or Mazda Roadster in Japan, is a lightweight two-seater roadster with a front-engine, rear-wheel-drive layout.",
            "Best Sports Car");
        table.Rows.Add(
            "../Images/optima_big.gif",
            "../Images/optima_small.gif",
            "Kia Optima",
            "The Kia Optima is a midsized 4-door sedan manufactured by Kia Motors since 2000 and marketed globally through various nameplates.",
            "Best Midsized Sedan");
        table.Rows.Add(
            "../Images/impala_big.gif",
            "../Images/impala_small.gif",
            "Chevrolet Impala",
            "The Chevrolet Impala is a full-size car built by Chevrolet for model years 1958-85, 1994-96, and since 2000 onwards.",
            "Best Large Sedan");
        table.Rows.Add(
            "../Images/forester_big.gif",
            "../Images/forester_small.gif",
            "Subaru Forester",
            "The Subaru Forester is a compact crossover SUV manufactured since 1997 by Subaru.",
            "Best Small SUV");
        table.Rows.Add(
            "../Images/highlander_big.gif",
            "../Images/highlander_small.gif",
            "Toyota Highlander",
            "The Toyota Highlander, also known as the Toyota Kluger, is a mid-size crossover SUV produced by Toyota.",
            "Best Midsized SUV");
        table.Rows.Add(
            "../Images/q7_big.gif",
            "../Images/q7_small.gif",
            "Audi Q7",
            "The Audi Q7 is a mid-size luxury crossover SUV of the German manufacturer Audi, unveiled in September 2002 at the Frankfurt Motor Show. ",
            "Best Luxury SUV");
        table.Rows.Add(
            "../Images/ridgeline_big.gif",
            "../Images/ridgeline_small.gif",
            "Honda Ridgeline",
            "The Honda Ridgeline is a sport utility truck (SUT) by Honda, North America and is categorized by some as a lifestyle pickup.",
            "Best Compact Pickup");

        return table;
    }
}

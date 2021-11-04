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

public partial class Demos_Menu_Programming_Data_Binding_Populate_from_DataTable_Demo : System.Web.UI.Page
{
    #region SAMPLE_BLOCK#1
    protected void Page_Load(object sender, System.EventArgs e)
    {
        DataTable mainTable = CreateDataTable();

        // Specify the data source. Here we bind to the Menu. You
        // can also bind to any sub menu.
        Menu1.DataSource = mainTable;

        // Bind the "Country","State" and "City" columns in the table 
        // to the default property (Text) of each menu item in the group.
        // when binding to default properties, you do not need to use 
        // MenuDataBinding class. Otherwise, you need to use 
        // MenudataBinding class to bind to the other properties.
        Menu1.DataFields = "Country|State|City";

        // Bind the "Website" column in the table to "NavigateUrl" 
        // property.
        EO.Web.DataBinding binding = new EO.Web.DataBinding();
        binding.DataField = "WebSite";
        binding.Property = "NavigateUrl";

        // Add this MenuDataBinding class into the group's binding 
        // collection. 
        Menu1.Bindings.Add(binding);

        // Populate from the data source (mainTable);
        Menu1.DataBind();

        // Bind the mainTable to DataGrid for demostration purpose.
        DataGrid1.DataSource = mainTable;
        DataGrid1.DataBind();
    }
    #endregion

    #region SAMPLE_BLOCK#2

    // If your data source is a database, and it contains Country,
    // State and City tables with relationship, you can easy use a
    // SQL statement to create the table:  
    // SELECT Country.Name, State.Name, City.Name, City.WebSite 
    //   FROM Country, State, City 
    //   WHERE Country.ID = State.CountryID and State.ID = City.StateID 
    private DataTable CreateDataTable()
    {
        DataTable table = new DataTable();
        table.Columns.Add("Country", typeof(string));
        table.Columns.Add("State", typeof(string));
        table.Columns.Add("City", typeof(string));
        table.Columns.Add("WebSite", typeof(string));
        table.Columns.Add("Population", typeof(int));
        table.Rows.Add(new object[]{"U.S.A", "GA", 
                "Atlanta", "http://www.atlantaga.gov", "123456"});
        table.Rows.Add(new object[]{"U.S.A", "GA", 
                "Savannah", "http://www.ci.savannah.ga.us", "200000"});
        table.Rows.Add(new object[]{"U.S.A", "FL", 
                "Miami", "http://www.ci.miami.fl.us", "3000"});
        table.Rows.Add(new object[]{"U.S.A", "FL", 
                "Orlando", "http://www.cityoforlando.net", "4000"});
        table.Rows.Add(new object[]{"Canada", "ON", 
                "Toronto", "http://www.city.toronto.on.ca", "50000"});

        return table;
    }
    #endregion
}

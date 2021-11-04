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

public partial class Demos_Menu_Programming_Data_Binding_Populate_from_DataSet_Demo : System.Web.UI.Page
{
    #region SAMPLE_BLOCK#1
    protected void Page_Load(object sender, System.EventArgs e)
    {
        // Prepare the DataSet
        DataSet mainDs = CreateDataSet();

        Menu1.DataSource = mainDs;

        // Bind the CountryName, StateName and CityName columns 
        // to the 1st, 2nd and 3rd levels' item text
        Menu1.DataFields = "CountryName|StateName|CityName";

        // Bind the CityWebSite to the 3rd level menu item's 
        // NavigateUrl property.
        EO.Web.DataBinding dataBinding = new EO.Web.DataBinding();

        // Depth is relative to the top level data bound
        // menu group. 
        // Set it to 0 if you wish to bind to "CountryName" item,
        // set it to 1 if you wish to bind to "StateName" item,
        // set it to 2 if you wish to bind to "CityName" item.
        // In this sample, we want to bind to "CityName" item.
        dataBinding.Depth = 2;
        dataBinding.DataField = "CityWebSite";
        dataBinding.Property = "NavigateUrl";
        Menu1.Bindings.Add(dataBinding);

        Menu1.DataBind();

        // Bind the three tables in the data set into DataGrid 
        // for demostration purpose.
        DataGrid1.DataSource = mainDs.Tables["Countries"];
        DataGrid1.DataBind();

        DataGrid2.DataSource = mainDs.Tables["States"];
        DataGrid2.DataBind();

        DataGrid3.DataSource = mainDs.Tables["Cities"];
        DataGrid3.DataBind();
    }
    #endregion

    #region SAMPLE_BLOCK#2
    private DataSet CreateDataSet()
    {
        DataSet ds = new DataSet();

        //Create Countries table
        DataTable dtCountries = ds.Tables.Add("Countries");
        DataColumn dtCountries_CountryID =
            dtCountries.Columns.Add("CountryID", typeof(int));
        DataColumn dtCountries_CountryName =
            dtCountries.Columns.Add("CountryName", typeof(string));
        dtCountries.Rows.Add(new object[] { 1, "U.S.A." });
        dtCountries.Rows.Add(new object[] { 2, "Canada" });

        //Create States table
        DataTable dtStates = ds.Tables.Add("States");
        DataColumn dtStates_StateID =
            dtStates.Columns.Add("StateID", typeof(int));
        DataColumn dtStates_CountryID =
            dtStates.Columns.Add("CountryID", typeof(int));
        DataColumn dtStates_StateName =
            dtStates.Columns.Add("StateName", typeof(string));
        dtStates.Rows.Add(new object[] { 1, 1, "GA" });
        dtStates.Rows.Add(new object[] { 2, 1, "FL" });
        dtStates.Rows.Add(new object[] { 3, 2, "ON" });

        //Create City table
        DataTable dtCities = ds.Tables.Add("Cities");
        DataColumn dtCities_CityID =
            dtCities.Columns.Add("CityID", typeof(int));
        DataColumn dtCities_StateID =
            dtCities.Columns.Add("StateID", typeof(int));
        DataColumn dtCities_CityName =
            dtCities.Columns.Add("CityName", typeof(string));
        DataColumn dtCities_CityWebSite =
            dtCities.Columns.Add("CityWebSite", typeof(string));
        DataColumn dtCities_Population =
            dtCities.Columns.Add("CityPopulation", typeof(int));
        dtCities.Rows.Add(new object[]{1, 1, "Atlanta", 
                "http://www.atlantaga.gov", "123456"});
        dtCities.Rows.Add(new object[]{2, 1, "Savannah", 
                "http://www.ci.savannah.ga.us", "200000"});
        dtCities.Rows.Add(new object[]{3, 2, "Miami", 
                "http://www.ci.miami.fl.us", "3000"});
        dtCities.Rows.Add(new object[]{4, 2, "Orlando", 
                "http://www.cityoforlando.net", "4000"});
        dtCities.Rows.Add(new object[]{5, 3, "Toronto", 
                "http://www.city.toronto.on.ca", "50000"});

        //Define relations
        DataRelation r1 = ds.Relations.Add(
            dtCountries_CountryID, dtStates_CountryID);
        r1.Nested = true;

        DataRelation r2 = ds.Relations.Add(
            dtStates_StateID, dtCities_StateID);
        r2.Nested = true;

        return ds;
    }
    #endregion
}

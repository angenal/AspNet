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
using System.Data.OleDb;
using EO.Web.Demo;

public partial class Demos_Callback_Features_Partial_Page_Updates___Cars_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //This function handles the CallbackPanel's Execute event to load
    //the car information. The code can be placed here or inside each
    //radio button's CheckedChanged event handler, the result would be
    //the same
    protected void cbCars_Execute(object sender, EO.Web.CallbackEventArgs e)
    {
        string maker = e.Parameter;

        // Contace backend database to retrieve the 
        // requested car information.
        BussinessLayer_Car car =
            new BussinessLayer_Car(maker);

        // Update the ASP.NET controls inside this Callback to 
        // reflect the new car information.
        lCarMake.Text = car.Maker;
        lCarModel.Text = car.Model;
        lCarStyle.Text = car.Style;
        lCarDescription.Text = car.Description;
        imgCar.ImageUrl = car.ImageUrl;

        //Also set imgCar.Visible to true because the image
        //initially was not visible
        imgCar.Visible = true;
    }

    // Internal class used to contact the backend database and retrieve
    // the requested car information.
    internal class BussinessLayer_Car
    {
        private string m_Maker;
        private string m_Model;
        private string m_Style;
        private string m_Description;
        private string m_ImageUrl;

        public BussinessLayer_Car(string maker)
        {
            GetCarFromTable(maker);
        }

        #region Public properties

        public string Maker
        {
            get
            {
                return m_Maker;
            }
            set
            {
                m_Maker = value;
            }
        }

        public string Model
        {
            get
            {
                return m_Model;
            }
            set
            {
                m_Model = value;
            }
        }

        public string Style
        {
            get
            {
                return m_Style;
            }
            set
            {
                m_Style = value;
            }
        }

        public string Description
        {
            get
            {
                return m_Description;
            }
            set
            {
                m_Description = value;
            }
        }

        public string ImageUrl
        {
            get
            {
                return m_ImageUrl;
            }
            set
            {
                m_ImageUrl = value;
            }
        }
        #endregion

        #region Private functions

        // The method used to retrieve car information from the backend database.
        private void GetCarFromTable(string maker)
        {
            using (DemoDB db = new DemoDB())
            {
                // Get car data from database
                string sql = "Select * from Cars Where " + "Maker='" + maker + "'";

                using (OleDbDataReader reader = db.ExecuteReader(sql))
                {
                    while (reader.Read())
                    {
                        m_Maker = reader["Maker"].ToString();
                        m_Model = reader["Model"].ToString();
                        m_Style = reader["Style"].ToString();
                        m_Description = reader["Description"].ToString();
                        m_ImageUrl = reader["Image"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
